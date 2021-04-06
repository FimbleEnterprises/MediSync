using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.GotDotNet;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Messages;
using MediSync.Events;
using System.Windows.Forms;
using Microsoft.Crm.Sdk.Messages;

namespace MediSync {
    public class JobList : List<JobList.Job> {

		public const string SYSTEMUSER_ENTITY_LOGICALNAME = "systemuser";
		public const string TEAM_ENTITY_LOGICALNAME = "team";

		public const string CENTRAL_TIMEZONE_NAME = "Central Standard Time";
		public const string NORWAY_TIMEZONE_NAME = "Central European Standard Time";


		public static bool DoSilently { get; set; }

        private static string CrmDbNameQualifier = Settings.CrmDbQualifyingPrefix;

        // The property representing the list of Job objects found 
        public static List<Job> RetrievedJobs { get; set; }

        public static int RunningJobCount() {
			

			int i = 0;
            foreach (Job _job in RetrievedJobs) {
                if (_job.IsRunning) {
                    i++;
                }
            }
            return i;
        }

        public static List<Job> RunningJobs() {
            List<Job> runningJobs = new List<Job>();
            foreach (Job _job in RetrievedJobs) {
                if (_job.IsRunning) {
                    runningJobs.Add(_job);
                }
            }
            return runningJobs;
        }

        /// <summary>
        /// Returns all MediSync jobs 
        /// </summary>
        /// <returns></returns>
        public static List<Job> QueryServerForJobs(bool EnabledJobsOnly = true) {
            SqlConnection conn = new SqlConnection(Settings.CRMConnString);
            string jobQuery = Settings.GetJobListQuery;
            SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();
            da.SelectCommand = new SqlCommand(jobQuery, conn);
            if (EnabledJobsOnly) {
                da.SelectCommand.CommandText += "WHERE msus_Enabled = 1";
            }
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try {
                da.Fill(ds);
                dt = ds.Tables[0];
            } catch (Exception e) {
                Log.Write.Append(e.Message, e);
                return null;
            }
            List<Job> unsorted = new List<Job>();
            int index = 0;
            int count = ds.Tables[0].Rows.Count;
            foreach (DataRow dr in ds.Tables[0].Rows) {
                index += 1;
                unsorted.Add(new Job(dr));
                System.Threading.Thread.Sleep(150);
            }
            List<Job> sortedList = unsorted.OrderByDescending(job => job.msus_Priority).ToList();
            List<Job> jobs =  new List<Job>();
            JobList.RetrievedJobs = new List<Job>();
            foreach (Job job in sortedList) {
                JobList.RetrievedJobs.Add(job);
            }
            return JobList.RetrievedJobs ;
        }

		public class Job {
			public const string ENTITY_ID_COLUMN = "ENTITYID";
			public const string CREATECOLUMN = "CREATE";
			public const string UPDATECOLUMN = "UPDATE";
			public const string DELETECOLUMN = "DELETE";

			/// <summary>
			/// Denotes the type of update to make in the CRM system using the 
			/// SDK
			/// </summary>
			public enum CRUD {
				CREATE = 0, UPDATE = 1, DELETE = 2
			}
			public bool IsWorkflowJob = false;
			public int SetWorkflowStatusTo = 32;
			public string WorkflowGuid = "";
			public bool NoDelete = false;
			public bool NoCreate = false;
			public bool IsCrmBasedModifiedOnDatetime = false;
            public MyPublisher job_Publisher { get; set; }
            public MySubscriber job_Subscriber { get; set; }
            // public static OrganizationServiceProxy _serviceProxy;
            public string _medisyncJobGuid;
			public Guid _medisyncguid;
			public ServerConnection.Configuration conn;
			EntityMetadata MyEntityMetadata { get; set; } = null;
			EntityCollection AllTargetEntityRecords { get; set; } = null;
			List<EntityCollection> LookupTargetedEntities {
				get;
				set;
			}
			public FieldMap fieldMap {
				get; set;
			}
			public string axModifiedOnColumn;
			public string axLastWriteTimeColumn;
			public string msus_medisyncId {
				get;
			}
			public string CreatedOn {
				get;
			}
			public string CreatedBy {
				get;
			}
            public JobResult jobResult { get; set; } 
			public string ModifiedOn {
				get;
			}
			public string ModifiedBy {
				get;
			}
			public string CreatedOnBehalfBy {
				get;
			}

			public bool ForceFullUpdate { get; set; } = false;

			public string ModifiedOnBehalfBy {
				get;
			} 

			public long timezonerawvalue { get; set; }

			public string GetTimezoneCode() {
				switch(this.timezonerawvalue) {
					case 745820000:
						return "Greenwich Standard Time";
					case 745820001:
						return "GMT Standard Time";
					case 745820002:
						return "UTC";
					case 745820003:
						return "Central Standard Time";
					case 745820004:
						return "Central European Standard Time";
					default:
						return "UTC";
				}
			}
			public string OwnerId {
				get;
			}
			public int OwnerIdType {
				get;
			}
			public bool ExemptFromFullSyncs = true;
			public string OwningBusinessUnit {
				get;
			}
			public int statecode {
				get;
			}
			public int statuscode {
				get;
			}
			public string VersionNumber {
				get;
			}
			public string ImportSequenceNumber {
				get;
			}
			public string OverriddenCreatedOn {
				get;
			}
			public string TimeZoneRuleVersionNumber {
				get;
			}
			public string UTCConversionTimeZoneCode {
				get;
			}
			public string msus_name {
				get;
			}
			public bool msus_Enabled {
				get;
			}
			public string msus_LastRunUTC {
				get;
			}
			public string msus_LastWriteDate { get; set; }
			public bool msus_LastRunSuccessful {
				get;
			}
			public int msus_Priority {
				get;
			}
			public string msus_Runasuser {
				get;
			}
			public string msus_Runasuserpassword {
				get;
			}
			public string msus_SQLQuery {
				get; set;
			}
			public string targetEntityLogicalName { get; private set; }
			public string targetEntityPrimaryKey { get; private set; }
			public string msus_FromClause {
				get;
				set;
			}
			protected DataRow ConsumedDataRow {
				get; set;
			}
			public string JobLog { get; set; }
			public string msus_AxJoinColumn {
				get; private set;
			}
			public string msus_CrmJoinColumn {
				get; private set;
			}
			public string msus_is_crm_based_modifiedon_datetime {
				get;
				set;
			}
			public List<string> msus_AxTargetCols {
				get; private set;
			}
			public List<string> msus_CrmTargetCols {
				get; private set;
			}
			public string msus_CrmJoinTable {
				get; private set;
			}
			public string msus_AxJoinTable {
				get; private set;
			}

			public bool IsRunning { get; set; } = true;
			private EntityCollection entitiesToCreate {
				get; set;
			}
			private EntityCollection entitiesToUpdate {
				get; set;
			}
			private EntityCollection entitiesToDeactivate {
				get; set;
			}
			public Reconciler.ReconcileJob Worker {
				get; set;
			}
			public bool ForceFullDailyUpdate { get; internal set; }

			public string Result() {
				return this.jobResult.RecordsCreated + " records created.  " + this.jobResult.RecordsUpdated + " records updated.  " +
					this.jobResult.RecordsDeleted + " records deleted.";
			}

			public void AppendLog(string msg) {
				StringBuilder sb = new StringBuilder(this.JobLog);
				sb.AppendLine(msg);
			}

            /// <summary>
            /// Instantiates a Job object that can be executed by calling its Execute() method.
            /// When Execute() is called the job will attempt to retrieve AX data and apply it 
            /// to the CRM entity.
            /// </summary>
            /// <param name="dr">A DataRow object as returned by the JobList.GetJobs() static function.</param>
            public Job(DataRow dr) {
                job_Publisher = new MyPublisher();
                job_Subscriber = new MySubscriber();
                job_Publisher.OnProgressEvent += job_Subscriber.OnEventFire;
				this.JobLog = "";
                this._medisyncJobGuid = dr["msus_medisyncId"].ToString();
                this.msus_medisyncId = dr["msus_medisyncId"].ToString();
                this.CreatedOn = dr["CreatedOn"].ToString();
                this.CreatedBy = dr["CreatedBy"].ToString();
				this.ExemptFromFullSyncs = (bool) dr["msus_exempt_from_full_syncs"];
                this.ModifiedOn = dr["ModifiedOn"].ToString();
                this.ModifiedBy = dr["ModifiedBy"].ToString();
                this.CreatedOnBehalfBy = dr["CreatedOnBehalfBy"].ToString();
                this.ModifiedOnBehalfBy = dr["ModifiedOnBehalfBy"].ToString();
                this.OwnerId = dr["OwnerId"].ToString();
                this.OwnerIdType = Int32.Parse(dr["OwnerIdType"].ToString());
				if (dr["msus_workflow_job"] != DBNull.Value) {
					this.IsWorkflowJob = (bool)dr["msus_workflow_job"];
					if (IsWorkflowJob) {
						this.WorkflowGuid = dr["msus_workflow_guid"].ToString();
						this.SetWorkflowStatusTo = Int32.Parse(dr["msus_set_workflow_status_to"].ToString());
					}
				} else {
					this.IsWorkflowJob = false;
				}
				
				this.OwningBusinessUnit = dr["OwningBusinessUnit"].ToString();
                this.statecode = Int32.Parse(dr["statecode"].ToString());
                this.statuscode = Int32.Parse(dr["statuscode"].ToString());
                this.VersionNumber = dr["VersionNumber"].ToString();
                this.ImportSequenceNumber = dr["ImportSequenceNumber"].ToString();
                this.OverriddenCreatedOn = dr["OverriddenCreatedOn"].ToString();
                this.TimeZoneRuleVersionNumber = dr["TimeZoneRuleVersionNumber"].ToString();
                this.UTCConversionTimeZoneCode = dr["UTCConversionTimeZoneCode"].ToString();
				if (dr["msus_target_timezone"] != DBNull.Value) {
					this.timezonerawvalue = int.Parse(dr["msus_target_timezone"].ToString());
				} else {
					this.timezonerawvalue = 745820002;
				}
                this.msus_name = dr["msus_name"].ToString();
                this.msus_Enabled = (bool)dr["msus_Enabled"];
				this.msus_LastWriteDate = dr["msus_lastwritedate"].ToString();

				if (dr["msus_do_not_delete"] != DBNull.Value) {
					this.NoDelete = (bool)dr["msus_do_not_delete"];
				} else {
					this.NoDelete = false;
				}

				//if (dr["msus_modifiedon_is_a_crm_column"] != DBNull.Value) {
				//	this.IsCrmBasedModifiedOnDatetime = (bool)dr["msus_modifiedon_is_a_crm_column"];
				//} else {
				//	this.IsCrmBasedModifiedOnDatetime = false;
				//}

				if (dr["msus_do_not_create"] != DBNull.Value) {
					this.NoCreate = (bool)dr["msus_do_not_create"];
				} else {
					this.NoCreate = false;
				}

				string strSafeDate = dr["msus_lastrun_utc"].ToString();
				DateTime dtSafeDate = Convert.ToDateTime(strSafeDate);
				// Log.Write.Append("WHERE last run > " + dtSafeDate.ToString());
				this.msus_LastRunUTC = dtSafeDate.ToString();

                this.msus_LastRunSuccessful = (bool)dr["msus_LastRunSuccessful"];
                this.msus_Priority = Int32.Parse(dr["msus_Priority"].ToString());
                this.msus_Runasuser = dr["msus_Runasuser"].ToString();
                this.msus_Runasuserpassword = dr["msus_Runasuserpassword"].ToString();
                this.msus_AxJoinColumn = dr["new_AXjoincolumn"].ToString();
                this.msus_CrmJoinColumn = dr["new_CRMjoincolumn"].ToString();
                this.msus_AxTargetCols = makeListOfStrings(dr["new_AXTargetCols"].ToString());
                this.msus_CrmTargetCols = makeListOfStrings(dr["new_CRMTargetCols"].ToString());
                this.msus_CrmJoinTable = dr["new_CRMJoinTable"].ToString();
                this.msus_FromClause = dr["msus_FromClause"].ToString();
                this.msus_AxJoinTable = dr["new_AXJoinTable"].ToString();
                this.targetEntityLogicalName = dr["new_Targetentity"].ToString();
                this.targetEntityPrimaryKey = dr["msus_target_entity_alias"].ToString();
				this.axModifiedOnColumn = dr["msus_axdatecolumn"].ToString();
				if (dr["msus_lastwritedate"] != System.DBNull.Value) {
					this.axLastWriteTimeColumn = dr["msus_lastwritedate"].ToString();
				} else {
					this.axLastWriteTimeColumn = "1/1/2000";
				}

				//Log.Write.Append("Old modified on: " + this.ModifiedOn);
				DateTime dtModifiedDateSafe = Convert.ToDateTime(this.ModifiedOn);
				this.ModifiedOn = dtModifiedDateSafe.ToString();
				//Log.Write.Append("New modified on: " + this.ModifiedOn);

				// Populate the FieldMap object
				this.fieldMap = new FieldMap(this.msus_AxTargetCols, this.msus_CrmTargetCols);
            }

			private List<string> makeListOfStrings(string newLineDelimitedList) {
				List<string> list = new List<string>();
				foreach (string s in newLineDelimitedList.Split('\n')) {
					list.Add(s);
				}
				return list;
			}

			private string MakeSql() {

				Log.Write.Append("MakeSQL() - Modified on: " + this.msus_LastRunUTC);

				//if (this.msus_LastWriteDate == null) {
				//	this.msus_LastWriteDate == "1/1/2000";
				//}
				if (this.msus_LastWriteDate == null || this.msus_LastWriteDate == "" || this.ForceFullUpdate) {
					this.msus_LastWriteDate = "1/1/2000";
				} 
				DateTime safeDtLastWriteDate = Convert.ToDateTime(this.msus_LastWriteDate);
				DateTime dtLastWriteDate = new DateTime(safeDtLastWriteDate.Year, safeDtLastWriteDate.Month, safeDtLastWriteDate.Day,
					safeDtLastWriteDate.Hour, safeDtLastWriteDate.Minute, safeDtLastWriteDate.Second);

				if (this.ForceFullDailyUpdate) {
					dtLastWriteDate = dtLastWriteDate.Subtract(new TimeSpan(24, 0, 0));
					Log.Write.Append("FULL DAILY UPDATE!");
				}

				DateTime dtTimeZoneCorrectedLastWriteDatetim = dtLastWriteDate;
				
				TimeZoneInfo CENTRAL_TIMEZONE = TimeZoneInfo.FindSystemTimeZoneById(CENTRAL_TIMEZONE_NAME);

				// If the modifiedon column is a table from the CRM db then we must convert the time to CET as it is in CST by default.
				// AX based modifiedon columns are in CET by default and no conversion is necessary.

				if (this.timezonerawvalue == 745820002) {
					dtTimeZoneCorrectedLastWriteDatetim = TimeZoneInfo.ConvertTimeToUtc(dtLastWriteDate, CENTRAL_TIMEZONE);
				} else if (this.timezonerawvalue == 745820003) {
					dtTimeZoneCorrectedLastWriteDatetim = dtTimeZoneCorrectedLastWriteDatetim;
				} else {
					dtTimeZoneCorrectedLastWriteDatetim = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dtLastWriteDate, CENTRAL_TIMEZONE_NAME, GetTimezoneCode());
				}

				Log.Write.Append("Year:" + dtTimeZoneCorrectedLastWriteDatetim.Year + ", Month: " + dtTimeZoneCorrectedLastWriteDatetim.Month + ", Day: " + dtTimeZoneCorrectedLastWriteDatetim.Day + ", Hour: " + dtTimeZoneCorrectedLastWriteDatetim.Hour + ", Minutes: " + dtTimeZoneCorrectedLastWriteDatetim.Minute + ", Seconds: " + dtTimeZoneCorrectedLastWriteDatetim.Second);

				// Will be the formatted string of columnns for each AX and CRM to be inserted into the SELECT clause
				var formattedSelectClause = "";

				foreach (MapEntry e in this.fieldMap) {
					StringBuilder sb = new StringBuilder();
					var c = " ," + e.AX + " AS " + e.CRM + " ";
					sb.Append(c + "\n");
					formattedSelectClause = sb.ToString();
				}

				string crmAlias = parseOutAlias(this.msus_CrmJoinColumn);
				string axAlias = parseOutAlias(this.msus_AxJoinColumn);

				// Start building the query
				string sql = "SELECT \n" +
								"   CAST(CASE WHEN " + this.msus_CrmJoinColumn + " IS NULL \n" +
								"   THEN 1 ELSE 0 END as bit) \n" +
								"    AS [CREATE] \n" +
								"  ,CAST(CASE WHEN " + this.msus_AxJoinColumn + " IS NULL \n" +
								"   THEN 1 ELSE 0 END as bit) \n" +
								"    AS [DELETE] \n" +
								"  ,CAST(CASE WHEN " + this.msus_AxJoinColumn + " IS NOT NULL \n" +
								"   AND " + this.msus_CrmJoinColumn + " IS NOT NULL \n" +
								"    THEN 1 ELSE 0 END as bit) \n" +
								"     AS [UPDATE] \n" +
								"  ," + this.targetEntityPrimaryKey + " AS [ENTITYID] \n" +
								this.fieldMap.ToSQL() +
							"FROM \n" +
								this.msus_FromClause + " \n " +
							"FULL JOIN " + this.msus_CrmJoinTable + " as " + crmAlias + "\n" +
							"   on " + this.msus_AxJoinColumn + " = " + this.msus_CrmJoinColumn + "  \n" +
							"WHERE \n" + axModifiedOnColumn + " >= '" +
								dtLastWriteDate.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss'.'fff") + "'";

				//Convert(datetime, '" + dtModifiedOn.ToString().Replace(".","/") + "')
				this.msus_SQLQuery = sql;
				this.AppendLog(sql);
				if (this.ForceFullUpdate) {
					this.AppendLog("** FULL UPDATE RUNNING! **");
					Log.Write.Append("** FULL UPDATE RUNNING! **");
				}
				Log.Write.Append("MakeSQL() - New LastWriteDate (CST): " + dtTimeZoneCorrectedLastWriteDatetim);
				Log.Write.Append("SQL Query: \n" + sql);
				return sql;
				
			}

			public struct DateTimeWithZone {
				private readonly DateTime utcDateTime;
				private readonly TimeZoneInfo timeZone;

				public DateTimeWithZone(DateTime dateTime, TimeZoneInfo timeZone) {
					var dateTimeUnspec = DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
					utcDateTime = TimeZoneInfo.ConvertTimeToUtc(dateTimeUnspec, timeZone);
					this.timeZone = timeZone;
				}

				public DateTime UniversalTime { get { return utcDateTime; } }

				public TimeZoneInfo TimeZone { get { return timeZone; } }

				public DateTime Time {
					get {
						DateTime result = TimeZoneInfo.ConvertTime(utcDateTime, timeZone);
						return result;
					}
				}
			}

			/// <summary>
			/// Returns all text starting at the beginning and ending (but including) with the first ']' found.
			/// </summary>
			/// <param name="value">The value to parse</param>
			/// <returns>Hopefully the alias used in the join arguments within the FROM clause.</returns>
			private string parseOutAlias(string value) {
				int firstClosingBracket = value.IndexOf(']');
				return value.Substring(0, firstClosingBracket + 1);
			}

			/// <summary>
			/// Queries the AX and CRM databases and determines what records must be created, updated 
			/// or deleted.
			/// </summary>
			/// <returns>A dataset that can be consumed by the Prepare method</returns>
			private DataSet GetDatasetOfChanges() {
				SqlConnection conn = new SqlConnection(Settings.AXConnString);
				SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();
				string sql = this.MakeSql();
				da.SelectCommand = new SqlCommand(sql, conn);
				da.SelectCommand.CommandTimeout = 240000;
				DataSet ds = new DataSet();
				DataTable dt = new DataTable();

				try {
					da.Fill(ds);
					dt = ds.Tables[0];
				} catch (Exception e) {
					Log.Write.Append(e.Message, e);
					return null;
				}
				return ds;
			}

			/// <summary>
			/// Retrieves the CRM record from this CRM entity where the AXJoin columnn == CRMJoin column.  
			/// </summary>
			/// <returns>An Entity object which represents a record from the current CRM entity.</returns>
			private Entity RetrieveCrmRecordMatchingAxRecord() {

				if (this.AllTargetEntityRecords == null) {
					this.AllTargetEntityRecords = RetrieveAllRecordsFromEntity();
				}

				foreach (Entity entity in AllTargetEntityRecords.Entities) {
					//do SHIT Here();
				}

				return new Entity();
			}

			/// <summary>
			/// Gets all records from the current target entity currently in the CRM system.
			/// </summary>
			/// <param name="entity">The entity's logical name</param>
			/// <returns>A collection of Entity objects (which are entity records)</returns>
			private EntityCollection RetrieveAllRecordsFromEntity() {
				return GetGuidForEveryRecordInEntity(this.targetEntityLogicalName);
			}

			/// <summary>
			/// Retrieves the CRM record from this CRM entity where the AXJoin columnn == CRMJoin column.  
			/// </summary>
			/// <returns>An Entity object which represents a record from the current CRM entity.</returns>
			private Entity GetEntityRecordGuidByAttributeValue(string entityToQuery, string lookingFor) {
				FilterExpression codeFilter = new FilterExpression(LogicalOperator.And);
				codeFilter.AddCondition(this.msus_CrmJoinColumn, ConditionOperator.Equal, msus_AxJoinColumn);
				EntityCollection records;
				ColumnSet cols = new ColumnSet();
				cols.AddColumn(lookingFor);
				QueryExpression query = new QueryExpression {
					EntityName = this.targetEntityLogicalName,
					ColumnSet = cols,
					Criteria = codeFilter
				};
				try {
                    OrganizationServiceProxy proxy = CRM.getProxy();
                    records = proxy.RetrieveMultiple(query);
                    proxy.Dispose();
				} catch (Exception e) {
					Log.Write.Append(e.Message, e);
					System.Threading.Thread.Sleep(3000);
					throw;
				}
				return records[0];
			}

			/// <summary>
			/// Gets the GUID value for all records from the specified target entity.
			/// </summary>
			/// <param name="entity">The entity's logical name</param>
			/// <returns>A collection of Entity objects (which are entity records)</returns>
			private EntityCollection GetGuidForEveryRecordInEntity(string entity) {
				EntityCollection records = new EntityCollection();
				FilterExpression codeFilter = new FilterExpression(LogicalOperator.And);
				ColumnSet colset = new ColumnSet();
				colset.AddColumn(entity.ToLower() + "id");
				QueryExpression query = new QueryExpression {
					EntityName = entity,
					ColumnSet = colset
				};
                OrganizationServiceProxy proxy = CRM.getProxy();
                EntityCollection collection;
                using (proxy) {
                    collection = proxy.RetrieveMultiple(query);
                }
                    return collection;
			}

			private EntityCollection createAndConfigureAsyncJobUpdateCollection () {
				IOrganizationService _service = CRM.GetService();
				QueryExpression BulkOperation = new QueryExpression("asyncoperation");
				FilterExpression Filter = BulkOperation.Criteria.AddFilter(LogicalOperator.And);
				Filter.AddCondition("name", ConditionOperator.Equal, this.WorkflowGuid);
				Filter.AddCondition("statuscode", ConditionOperator.NotEqual, 30);
				Filter.AddCondition("statuscode", ConditionOperator.NotEqual, 31);
				Filter.AddCondition("statuscode", ConditionOperator.NotEqual, 32);
				EntityCollection BulkOperationCollection = _service.RetrieveMultiple(BulkOperation);

				int statusReason = 32;
				int state = 3;

				switch (this.SetWorkflowStatusTo) {
					case 745820001:
						statusReason = 32;
						state = 3;
						break;
					case 745820000:
						statusReason = 0;
						state = 0;
						break;
				}

				int BulkOperationRecordCount = BulkOperationCollection.Entities.Count;
				if (BulkOperationRecordCount > 0) {
					Entity BulkOperationJob = new Entity("asyncoperation");
					foreach (Entity job in BulkOperationCollection.Entities)  {
						BulkOperationJob["asyncoperationid"] = job.Id;
						OptionSetValue StatusReason = new OptionSetValue(statusReason);
						OptionSetValue StateCode = new OptionSetValue(state);
						BulkOperationJob["statecode"] = StateCode;
						BulkOperationJob["statuscode"] = StatusReason;
						entitiesToUpdate.Entities.Add(BulkOperationJob);
						//_service.Update(BulkOperationJob);
						//Log.Write.Append("Something...");
					}
				}
				return entitiesToUpdate;
			}

			/// <summary>
			/// Loops through each row of the returned SQL data and determines what needs to be
			/// created, updated and deleted in CRM.  
			/// 
			/// It creates one EntityCollection object (which is simply a list of individual CRM
			/// records) for each of these CRUD operations.  These collections are used by the 
			/// CRM service to actually update the CRM entity records.  
			/// 
			/// The source dataset is supplied by the query generated by the user's 
			/// input into the MediSync entity as interfaced from the website
			/// </summary>
			private void PrepareCrudLists() {
				//if (MyEntityMetadata == null ||
				//		MyEntityMetadata.SchemaName.ToLower()
				//			!= this.new_targetentity.ToLower()) {
				//	this.MyEntityMetadata = GetEntityMetadata();
				//}
				//if (MyEntityMetadata == null)
				//return;
				object fval;
				DataSet jobDataset = null;
				List<DataRow> deleteRows = new List<DataRow>();
				entitiesToCreate = new EntityCollection();
				entitiesToUpdate = new EntityCollection();
				entitiesToDeactivate = new EntityCollection() ;
				try {

					if (IsWorkflowJob) {
						createAndConfigureAsyncJobUpdateCollection();
						if (entitiesToUpdate != null) {
							job_Publisher.OnProgress(entitiesToUpdate.Entities.Count + " AsyncJobs to update");
						}
						return;
					}

					jobDataset = GetDatasetOfChanges();
					if (jobDataset == null || jobDataset.Tables[0].Rows.Count == 0) {
						return;
					}
				} catch (Exception e) {
					Log.Write.Append(e.Message, e);
				}
				
                // Connect to the Organization service. 
                // The using statement assures that the service proxy will be properly disposed.
                OrganizationServiceProxy proxy = CRM.getProxy();
				IOrganizationService service = CRM.GetService();
				using (proxy) {

					// Instaniate an account object.
					Entity EntityRecord = null;
					
						foreach (DataRow row in jobDataset.Tables[0].Rows) {
							try {
								bool Update = (bool)row[UPDATECOLUMN];
								bool Create = (bool)row[CREATECOLUMN];
								bool Delete = (bool)row[DELETECOLUMN];

							if (Create) { 
									EntityRecord = new Entity(this.targetEntityLogicalName);
								}

							if (Update || Delete) {
								// In order to update or delete an entity record, we need the entity record's guid - we get that from our 
								// metadata that we retreived earlier by parsing its attributes looking for a our CRM join
								// column value which should always be unique to that CRM entity record.
								object strGUID = row[ENTITY_ID_COLUMN].ToString();
								// Create an EntityRecord that has an existing GUID
								if (strGUID != DBNull.Value) {
									EntityRecord = new Entity(this.targetEntityLogicalName,
													new Guid(strGUID.ToString()));
								}
							}

							// Update all columns in the entity with their values from AX
							foreach (MapEntry entry in this.fieldMap) {
								if (Create || Update) {

									// AX field value
									Object value = row[entry.CRM_strip_brackets];

									// Ensure AX field is not null
									if (value != DBNull.Value) {
										// The name of the field to update
										string fname = entry.CRM_strip_brackets.ToLower();
										try {
											// Converts the value for the crm field from what the AX db stored it as to what the CRM
											// field requires.  Without this InvalidCast exceptions become almost a certainty and 
											// will prevent the sync.  (Tough to debug too!)
											try {
												fval = ConvertEntityValuePerFieldRequirement(fname, value.ToString());
											} catch (Exception e4) {
												Log.Write.Append(fname.ToString() + " " + e4.Message);
												throw;
											}

											// Lookups can only be updated using the GUID of the value you wish it to display.
											if (isLookup(fname)) {
												EntityRecord[fname] =
												new EntityReference(this.targetEntityLogicalName, new Guid(fval.ToString()));

											} else if (isOptionSet(fname)) {
												try {
													EntityRecord.Attributes.Add(fname, new OptionSetValue((int)fval));
												} catch (Exception) {
													EntityRecord[fname] = EntityRecord.FormattedValues[fname];
												}
											} else if (isState(fname)) {
												try {
													EntityRecord.Attributes.Add(fname, new OptionSetValue((int)fval));
													EntityRecord.Attributes.Add("statuscode", new OptionSetValue(-1));
												} catch (Exception) {
													EntityRecord[fname] = EntityRecord.FormattedValues[fname];
												}
											} else if (isStatus(fname)) {
												try {
													EntityRecord.Attributes.Add(fname, new OptionSetValue((int)fval));
												} catch (Exception) {
													EntityRecord[fname] = EntityRecord.FormattedValues[fname];
												}
											} else {
												EntityRecord[fname] = fval;
											}
										} catch (Exception error) {
											Log.Write.Append("Error on entry: " + entry.AX + " - " + entry.CRM, error);
										}
									} // end if db col is null
								} // end if (create||update)
							} // end foreach field(in entity)

								if (Create)
									if (!this.NoCreate) {
										entitiesToCreate.Entities.Add(EntityRecord);
									}
								if (Update)
									entitiesToUpdate.Entities.Add(EntityRecord);
								if (Delete) {
									if (!this.NoDelete) {
										entitiesToDeactivate.Entities.Add(EntityRecord);
									}
								}
							} catch (Exception ex) {
								Log.Write.Append(ex.Message, ex);
							}

						} // END foreach row
				} // END using CRM.serviceProxy
			} // END function
			
			//bool entityExists(EntityCollection entityCollection, string attribute, string value) {
			//	foreach (Entity entity in entityCollection.Entities) {
			//		if (entity.Attributes[attribute].ToString() == value) {
			//			return true;
			//		}
			//	}
			//	return false;
			//}

			public void Execute() {
				try {
                    this.IsRunning = true;
					this.AppendLog("Getting metadata for entity " + this.targetEntityLogicalName + "...");
                    job_Publisher.OnProgress("Getting metadata for entity " + this.targetEntityLogicalName + "...");
                    this.MyEntityMetadata = GetEntityMetadata();
                    job_Publisher.OnProgress("Preparing CRUD lists...");
					this.AppendLog("Preparing CRUD lists...");

					// Prepare collection lists of entities to create, update and delete (three static List<EntityCollections> are filled).
					PrepareCrudLists();

					// Having issues updating sales order lines due to sales orders being locked.  This method attempts to unlock
					// the parent sales orders before attempting to add the sales order lines.
					unlockSalesOrderEntities(entitiesToCreate);
					unlockSalesOrderEntities(entitiesToDeactivate);
					unlockSalesOrderEntities(entitiesToUpdate);

                    job_Publisher.OnProgress("Performing CRUD operations...");
					this.AppendLog("Performing CRUD operations...");
					Reconciler updater = new Reconciler(this);
					updater.AddJob(new Reconciler.ReconcileJob(this, this.entitiesToCreate, CRUD.CREATE, updater));
					updater.AddJob(new Reconciler.ReconcileJob(this, this.entitiesToUpdate, CRUD.UPDATE, updater));
					updater.AddJob(new Reconciler.ReconcileJob(this, this.entitiesToDeactivate, CRUD.DELETE, updater));
					updater.RunAll();
				} catch (Exception e) {
					Log.Write.Append(e.Message, e);
				}
			}

			private void unlockSalesOrderEntities(EntityCollection entityCollection) {
				// Loop through this bucket's entities and add them to the request
				foreach (Entity entity in entityCollection.Entities) {
					try {
						if (entity.LogicalName.Equals("salesorderdetail")) {
							EntityReference ef = (EntityReference)entity.Attributes["salesorderid"];
							// Unlock the order pricing
							UnlockSalesOrderPricingRequest unlockOrderRequest =
								new UnlockSalesOrderPricingRequest() {
									SalesOrderId = ef.Id
								};
								OrganizationResponse organizationResponse = CRM.serviceProxy.Execute(unlockOrderRequest);
								if (organizationResponse.Results.Values != null) {
									Log.Write.Append("Had to unlock a sales order...");
									Log.Write.Append("Unlock request result:\n" + organizationResponse.Results.Values.ToString());
								}
						}
					} catch (Exception e) {

					}
				}
			}

			public EntityCollection GetLookupReferencedEntities() {
				EntityCollection coll = new EntityCollection();
				if (LookupTargetedEntities == null)
					LookupTargetedEntities = new List<EntityCollection>();
				foreach (AttributeMetadata a in MyEntityMetadata.Attributes) {
					if (a.AttributeType == AttributeTypeCode.Lookup) {
						string logiName = a.LogicalName;
						LookupAttributeMetadata lookupMetadata = (LookupAttributeMetadata) a;
						string Target = lookupMetadata.Targets[0];
						bool alreadyRetrieved = false;
						foreach (EntityCollection existing in LookupTargetedEntities) {
							if (existing.EntityName == Target) {
								alreadyRetrieved = true;
							}
						}
						if (!alreadyRetrieved) {
							LookupTargetedEntities.Add(GetGuidForEveryRecordInEntity(Target));
						}
					}
				}
				return coll;
			}

			public override string ToString() {
				return this.msus_name
							+ " - Priority: "
								+ this.msus_Priority
									+ " - Enabled: "
										+ this.msus_Enabled;
			}
           
			/// <summary>
			/// Gets then prints to the console a summary list of changes that would be performed 
			/// if this job were executed.
			/// </summary>
			public void PrintPotentialChangesToConsole(bool waitForInput = false) {
                if (DoSilently) { return; }
				DataSet ds = GetDatasetOfChanges();
				int dels = 0, inserts = 0, edits = 0;
				int changes = ds.Tables[0].Rows.Count;
				foreach (DataRow dr in ds.Tables[0].Rows) {
					bool Update = (bool) dr["UPDATE"];
					bool Create = (bool) dr["CREATE"];
					bool Delete = (bool) dr["DELETE"];
					if (Update == true) {
						edits += 1;
					}
					if (Create == true) {
						inserts += 1;
					}
					if (Delete == true) {
						dels += 1;
					}
				}
				if (waitForInput) {

				}
			}


			/// <summary>
			/// Contains a list of Field objects
			/// </summary>
			public class FieldMap : List<MapEntry> {

				public FieldMap(List<string> axFields, List<string> crmFields) {
					for (int i = 0; i < axFields.Count; i++) {
						MapEntry field = new MapEntry(axFields[i], crmFields[i]);
						this.Add(field);
					}
				}

				public FieldMap(string[] axFields, string[] crmFields) {
					for (int i = 0; i < axFields.Length - 1; i++) {
						MapEntry field = new MapEntry(axFields[i], crmFields[i]);
						this.Add(field);
					}
				}

				/// <summary>
				/// Creates a columnset that can be consumbed the CRM SDK to instruct what columns to return from a CRM entity.
				/// </summary>
				/// <returns>A populated ColumnSet object.</returns>
				public ColumnSet MakeColumnSet() {
					ColumnSet colset = new ColumnSet();
					foreach (MapEntry mapEntry in this) {
						colset.AddColumn(mapEntry.CRM);
					}
					return colset;
				}

				public ColumnSet MakeColumnSet(bool noBrackets, bool toLower = true) {
					ColumnSet colset = new ColumnSet();
					foreach (MapEntry mapEntry in this) {
						if (toLower) {
							colset.AddColumn(mapEntry.CRM_strip_brackets.ToLower());
						} else {
							colset.AddColumn(mapEntry.CRM_strip_brackets);
						}
					}
					return colset;
				}

				public override string ToString() {
					StringBuilder sb = new StringBuilder();
					foreach (Job.MapEntry mapEntry in this) {
						sb.AppendLine(mapEntry.ToString());
					}
					return sb.ToString();
				}

				public string ToSQL() {
					StringBuilder sb = new StringBuilder();
					foreach (Job.MapEntry mapEntry in this) {

						sb.AppendLine("  ," + (mapEntry.ToString().TrimStart(' ')));
					}
					return sb.ToString();
				}
			}

			/// <summary>
			/// Represents a single field mapping between AX and CRM.
			/// </summary>
			public class MapEntry {
				public string AX {
					get; set;
				}
				public string CRM {
					get; set;
				}
				public string MyProperty {
					get; set;
				}
				public string CRM_strip_brackets {
					get {
						return CRM.Replace("[", "").Replace("]", "");
					}
				}

				/// <summary>
				/// Constructs a Field object which represents a shared datapoint between
				/// each system and the field names each system uses to house it. 
				/// </summary>
				/// <param name="ax">The name of the field containing this data in AX.</param>
				/// <param name="crm">The name of the field containing this data in CRM.</param>
				public MapEntry(string ax, string crm) {
					this.AX = ax;
					this.CRM = crm;
				}
				public override string ToString() {
					string c = " ,ax." + this.AX + " AS " + this.CRM + " ";
					return " " + this.AX + " AS " + this.CRM + " ";
				}
			}

			/// <summary>
			/// Represents the results of the job.
			/// </summary>
			public class JobResult {

				public int RecordsCreated { get; set; } = 0;
				public int RecordsUpdated { get; set; } = 0;
				public int RecordsDeleted { get; set; } = 0;
				public List<JobError> ErrorsEncountered {
					get; private set;
				}
				public DateTime CompletedAt {
					get; set;
				}

				public int ErrorCount() {
					if (ErrorsEncountered == null) {
						return 0;
					} else {
						return ErrorsEncountered.Count;
					}
				}

				/// <summary>
				/// An empty JobResult object.
				/// </summary>
				public JobResult() {
					this.ErrorsEncountered = new List<JobError>();
				}

				/// <summary>
				/// Instantiates a new JobResult object.
				/// </summary>
				/// <param name="created">The number of records created within the CRM database.</param>
				/// <param name="updated">The number of records updated within the CRM database.</param>
				/// <param name="deleted">The number of records deelted from the CRM database.</param>
				public JobResult(int created, int updated, int deleted) {
					this.RecordsCreated = created;
					this.RecordsUpdated = updated;
					this.RecordsDeleted = deleted;
				}

				/// <summary>
				/// Instantiates a new JobResult object.
				/// </summary>
				/// <param name="created">The number of records created within the CRM database.</param>
				/// <param name="updated">The number of records updated within the CRM database.</param>
				/// <param name="deleted">The number of records deelted from the CRM database.</param>
				/// <param name="errors">A list of JobError objects representing errors while working with 
				/// specific entities</param>
				public JobResult(int created, int updated, int deleted, List<JobError> errors) {
					this.RecordsCreated = created;
					this.RecordsUpdated = updated;
					this.RecordsDeleted = deleted;
					if (this.ErrorsEncountered.Count > 0) {
						this.ErrorsEncountered = errors;
					}
				}

				public string SqlQueryUsed { get; set; }

				public string JobName { get; set; }
				/// <summary>
				/// Adds a JobError object to the ErrorsEncountered list of JobError objects
				/// </summary>
				/// <param name="error"></param>
				public void AppendError(JobError error) {
					this.ErrorsEncountered.Add(error);
				}

				/// <summary>
				/// Provides a summary of the job's results when attempting to update the CRM database.
				/// </summary>
				/// <returns>A summary string showing either an error or the CRUD results.</returns>
				public override string ToString() {
					StringBuilder sb = new StringBuilder();
					sb.Append(this.RecordsCreated + " record(s) created, " +
							this.RecordsUpdated + " record(s) updated, " +
								this.RecordsDeleted + ", record(s) deleted");

					if (ErrorsEncountered.Count > 0) {
						int i = 0; // we only want to show the first 5 errors or we overflow the db column
						foreach (JobError err in ErrorsEncountered) {
							if (i <= 5) {
								sb.Append("\n" + err.ToString());
							} else {
								sb.Append("\n" + "There were " + (ErrorCount() - i) + " more errors.");
							}
							i++;
						}
						sb.AppendLine(this.ErrorsEncountered.Count + ", error(s)");
					}
					return sb.ToString();
				}

                public class JobError {
					public string Error {
						get; set;
					}
					public string Entity {
						get; set;
					}
					public CRUD OperationType {
                        get; set;
                    }


                    public JobError(string error, string entity, CRUD OperationType) {
                        this.Error = error;
                        this.Entity = entity;
                        this.OperationType = OperationType;
                    }

                    /// <summary>
                    /// Returns a summary of the results from this job's execution.
                    /// </summary>
                    /// <returns></returns>
                    public override string ToString() {
						string verb;
						switch (OperationType) {
							case CRUD.CREATE:
								verb = "creating entity: " + this.Entity.ToUpper();
								break;
							case CRUD.UPDATE:
								verb = "updating entity: " + this.Entity.ToUpper();
								break;
							case CRUD.DELETE:
								verb = "deleting entity: " + this.Entity.ToUpper();
								break;
							default:
								verb = "performing an unknown operation on entity: " +
									this.Entity.ToUpper();
								break;
						}
						return "While " + verb + "\nEncountered error: \n" + this.Error;
					}
				}// END JobError
			}// END JobResult

			public class Reconciler {
                public MyPublisher reconciler_Publisher { get; set; }
                public MySubscriber reconciler_Subscriber { get; set; }
                
                private int runningJobs = 1;
				public Job MasterJob { get; set; }
				public List<ReconcileJob> ReconcileJobs { get; set; }
                
                public Reconciler(Job MasterJob) {
                    reconciler_Publisher = new MyPublisher();
                    reconciler_Subscriber = new MySubscriber();
                    reconciler_Publisher.OnProgressEvent += reconciler_Subscriber.OnEventFire;
                    this.MasterJob = MasterJob;
					this.ReconcileJobs = new List<ReconcileJob>();
				}

                public void AddJob(ReconcileJob job) {
                    job.reconJob_Publisher = reconciler_Publisher;
                    job.SqlQueryUsed = MasterJob.msus_SQLQuery;
                    job.EnitityAffected = MasterJob.targetEntityLogicalName;
					this.ReconcileJobs.Add(job);
				}

				public void RunAll() {
					runningJobs = 0;
					foreach (ReconcileJob Task in ReconcileJobs) {
						try {
							Task.Start();
							_Completed(Task);
							MasterJob.AppendLog("Finished crud type: " + Task.GetOperation());
						} catch (Exception e) {
							Log.Write.Append(e.Message, e);
							throw;
						}
                    }
				}
                
                public void ReconciliationCompleted() {
                    // LogJobResult(msg, errorCount);
                }

                public static void LogJobResult(Job MasterJob, bool omitMainText = false) {

					// Updates the msus_lastrun_utc field on the MediSync job
					bool msus_lastrun_utcWasUpdatedSuccessfully = LogJobResultOnJobRecord(MasterJob);

					OrganizationServiceProxy proxy = null;
                    try {
                        // Instaniate a MediSync log object.
                        Entity entity = new Entity("msus_medisynclog");

                        // Set the required attributes. For account, only the name is required. 
                        // See the Entity Metadata topic in the SDK documentatio to determine 
                        // which attributes must be set for each entity.
                        entity["msus_name"] = MasterJob.msus_name;
                        proxy = CRM.getProxy();
						using (proxy) {
							// Create an account record named Fourth Coffee.
							Guid _guid = proxy.Create(entity);
							string _medisyncjobid = MasterJob._medisyncguid.ToString();

							// Create a column set to define which attributes should be retrieved.
							ColumnSet attributes = new ColumnSet(new string[] { "msus_name", "msus_jobresult", "msus_sqlquery", "msus_medisync_job", "msus_recordscreated", "msus_recordsdeleted", "msus_recordsupdated", "msus_errorsencountered", "msus_deleteswereforbidden", "msus_createswereforbidden" });

							// Retrieve the record's attributes.
							entity = proxy.Retrieve(entity.LogicalName, _guid, attributes);

							EntityMetadata metadata = GetEntityMetadata(entity, proxy);
							string rslt = "";
							if (MasterJob.jobResult != null) rslt = MasterJob.jobResult.ToString();
							if (msus_lastrun_utcWasUpdatedSuccessfully) {
								rslt += "\n\nmsus_lastrun_utc was successfully updated.";
							}
							AttributeMetadata attribute = GetAttributeMetadata(metadata, "msus_jobresult", rslt);
							if (omitMainText == false) {
								if (MasterJob.jobResult != null && MasterJob.jobResult.ErrorCount() > 0) {
									entity["msus_jobresult"] = MasterJob.jobResult.ToString();
								} else {
									entity["msus_jobresult"] = MasterJob.Result() + "\n" + MasterJob.JobLog;
								}
							} else {
								entity["msus_jobresult"] = "Log too verbose.  \nSummary:\nCreated: " + MasterJob.jobResult.RecordsCreated + " Updated" +
									MasterJob.jobResult.RecordsUpdated + " Deleted: " + MasterJob.jobResult.RecordsDeleted + " Errors: " + MasterJob.jobResult.ErrorCount();

							}
                            entity["msus_sqlquery"] = MasterJob.msus_SQLQuery;
                            entity["msus_medisync_job"] = new EntityReference(
                                entity.LogicalName, new Guid(MasterJob._medisyncJobGuid));

							if (MasterJob.jobResult.RecordsCreated > 0 ||
									MasterJob.jobResult.RecordsUpdated > 0 || 
										MasterJob.jobResult.RecordsDeleted > 0) {
								entity["msus_recordscreated"] = ConvertEntityValuePerFieldRequirement(metadata,
								"msus_recordscreated", MasterJob.jobResult.RecordsCreated.ToString());
								entity["msus_jobexitcode"] = "Success";
								entity["msus_lastwritedate"] = ConvertEntityValuePerFieldRequirement(metadata, "msus_lastwritedate",DateTime.UtcNow.ToString());
							} else if (MasterJob.jobResult.ErrorCount() > 0) {
								entity["msus_jobexitcode"] = "Failed";
							} else {
								entity["msus_jobexitcode"] = "Nothing to do";
								entity["msus_jobresult"] = "Nothing to do";
							}

							entity["msus_errorsencountered"] = ConvertEntityValuePerFieldRequirement(metadata,
									"msus_errorsencountered", MasterJob.jobResult.ErrorCount().ToString());

							entity["msus_recordsdeleted"] = ConvertEntityValuePerFieldRequirement(metadata,
								"msus_recordsdeleted", MasterJob.jobResult.RecordsDeleted.ToString());

							entity["msus_recordsupdated"] = ConvertEntityValuePerFieldRequirement(metadata,
								"msus_recordsupdated", MasterJob.jobResult.RecordsUpdated.ToString());

							entity["msus_recordscreated"] = ConvertEntityValuePerFieldRequirement(metadata,
								"msus_recordscreated", MasterJob.jobResult.RecordsCreated.ToString());

							entity["msus_createswereforbidden"] = ConvertEntityValuePerFieldRequirement(metadata, "msus_createswereforbidden", MasterJob.NoCreate.ToString());

							entity["msus_deleteswereforbidden"] = ConvertEntityValuePerFieldRequirement(metadata, "msus_deleteswereforbidden", MasterJob.NoDelete.ToString());


							// Update the account.
							proxy.Update(entity);
                        }
                    } catch (Exception e) {
						Log.Write.Append("\n********************\n", null);
                        Log.Write.Append(e.Message, e);
						Log.Write.Append(e.Source + "\n" + e.StackTrace + "\n" + e.InnerException);
						Log.Write.Append(e.ToString(), null);
						Log.Write.Append("Job: " + MasterJob.msus_name, null);
						Log.Write.Append("\n********************\n", e);
					} finally {
                        if (proxy != null) {
                            proxy.Dispose();
                        }
                    }
                }

				public static bool LogJobResultOnJobRecord(Job MasterJob) {

					DateTime timeNowCST = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, CENTRAL_TIMEZONE_NAME);
					DateTime norgeTimeNow = DateTime.UtcNow;

					OrganizationServiceProxy proxy = null;
					try {
						proxy = CRM.getProxy();

						// Instaniate a MediSync log object.
						Entity entity = new Entity("msus_medisync", new Guid(MasterJob._medisyncJobGuid));
						entity["msus_lastrun_utc"] = timeNowCST;

						if (MasterJob.jobResult.RecordsCreated > 0 ||
									MasterJob.jobResult.RecordsUpdated > 0 ||
										MasterJob.jobResult.RecordsDeleted > 0) {
							entity["msus_lastwrite_cst"] = timeNowCST;
							entity["msus_lastwritedate"] = norgeTimeNow;
							entity["msus_lastrunresult"] = "Success";
						} else if (MasterJob.jobResult.ErrorCount() > 0) {
							entity["msus_lastrunresult"] = "Failed";
						} else {
							entity["msus_lastrunresult"] = "Nothing to do";
						}


						UpdateRequest updateRequest = new UpdateRequest { Target = entity };
						using (proxy) {
							OrganizationResponse response = proxy.Execute(updateRequest);
							if (response != null) {
								return true;
							} else if (response.Results.Count > 0) {
								return false;
							} else {
								return false;
							}

						}
					} catch (Exception e) {
						Log.Write.Append("\n********************\n", null);
						Log.Write.Append(e.Message, e);
						Log.Write.Append(e.Source + "\n" + e.StackTrace + "\n" + e.InnerException);
						Log.Write.Append(e.ToString(), null);
						Log.Write.Append("Job: " + MasterJob.msus_name, null);
						Log.Write.Append("\n********************\n", e);
						return false;
					} finally {
						if (proxy != null) {
							proxy.Dispose();
						}
					}
				}

				public void _Completed(ReconcileJob rJob) {
                    StringBuilder rslt = new StringBuilder("");
                    rJob.isRunning = false;
                    reconciler_Publisher.ReconcileJobDone(rJob);
                }

                public class ReconcileJob : MediSync.Interfaces.ITask {

                    //              Vars and properties           
                    // ****************************************** //                   
                    public MyPublisher reconJob_Publisher { get; set; }
                    public MySubscriber reconJob_Subscriber { get; set; }
                    public Reconciler MyReconciler { get; set; }
                    public string SqlQueryUsed { get; set; }
                    public string EnitityAffected { get; set; }
                    public bool wasSuccessful = true;
                    public bool isRunning = false;
                    public string results = "";
                    public int JobID;
                    public int errorCount = 0;
                    public string errorList = "";
                    public Job MasterJob { get; set; }
                    public EntityCollection Entitylist {
                        get; set;
                    }
                    public CRUD OperationType {
                        get; set;
                    }
                    public int Progress {
                        get; set;
                    }
                    public int Max {
                        get; set;
                    }
                    //private JobResult JobResult {
                    //    get; set;
                    //}
                    public Boolean submittedReport {
                        get;
                        set;
                    }
                    public String[] MakeTableRow() {
                        String[] row = new String[] { GetOperation(), isRunning.ToString(), GetRecordsAffected().ToString(), this.MasterJob.jobResult.ErrorCount().ToString() };
                        return row;
                    }
                    public string GetOperation() {
                        switch (OperationType) {
                            case CRUD.CREATE:
                                return "Create";
                            case CRUD.UPDATE:
                                return "Update";
                            case CRUD.DELETE:
                                return "Delete";
                            default:
                                return "";
                        }
                    }
                    //public string recordsCreated;
                    //public string recordsDeleted;
                    //public string recordsUpdated;

                    // Constructor
                    // ****************************************** //  
                    public ReconcileJob(Job job, EntityCollection entityList, CRUD operationTypeobserver, Reconciler reconciler) {
                        this.reconJob_Publisher = new MyPublisher();
                        this.reconJob_Subscriber = new MySubscriber();
                        this.reconJob_Publisher.OnProgressEvent += this.reconJob_Subscriber.OnEventFire;
                        this.MyReconciler = reconciler;
                        this.MasterJob = job;
                        this.Entitylist = entityList;
						this.OperationType = operationTypeobserver;
                        initialize();
                    }
                    
                    //                  Events
                    // ****************************************** //  
                    public void Finished(object result) {
                        isRunning = false;
                        submittedReport = true;
                        this.reconJob_Publisher.OnProgress("");
                        foreach (Job j in RetrievedJobs) {
                            if (j.IsRunning) {
                                reconJob_Publisher.OnProgress("");
                            }
                        }
                    }
                    
                    public void Cancelled(object result) {

                    }

                    public void OnProgress(object progress) {

                    }
                    
                    //                  METHODS                   
                    // ****************************************** //
                    public string getResultSummary() {
                        StringBuilder sb = new StringBuilder("");
                        sb.AppendLine(this.MasterJob.jobResult.RecordsCreated.ToString());
                        sb.AppendLine(this.MasterJob.jobResult.RecordsUpdated.ToString());
                        sb.AppendLine(this.MasterJob.jobResult.RecordsDeleted.ToString());
                        return sb.ToString();
                    }
                   
                    public int GetRecordsAffected() {
                        return this.MasterJob.jobResult.RecordsCreated + this.MasterJob.jobResult.RecordsUpdated + this.MasterJob.jobResult.RecordsDeleted;
                    }

                    private void initialize() {
                        this.MasterJob.jobResult = new JobResult();
                        this.MasterJob.jobResult.SqlQueryUsed = "SQL: \n" + this.SqlQueryUsed;
                        this.MasterJob.jobResult.JobName = this.EnitityAffected;
                    }

                    public int Start() {
                        this.isRunning = true;
                        string msg = "";
                        int maxProg = Entitylist.Entities.Count();

						switch (OperationType) {
                            case CRUD.CREATE :
                                msg = "Creating (" + this.MasterJob.targetEntityLogicalName + ") records (" + this.Entitylist.Entities.Count + ")";
                                this.reconJob_Publisher.OnProgress(msg);
                                JobID = 0;
								if (Entitylist.Entities.Count == 0) {
									this.MasterJob.jobResult.RecordsCreated = 0;
									return JobID;
								}
								try {
                                    this.isRunning = true;
                                    this.MasterJob.jobResult.RecordsCreated = CreateMany();
                                } catch (Exception e1) {
									this.MyReconciler.MasterJob.AppendLog(e1.Message);
                                    Log.Write.Append(e1.Message, e1);
                                    this.isRunning = false;
                                    wasSuccessful = false;
                                } finally {
                                    this.isRunning = false;
                                }
                                break;

                            case CRUD.UPDATE :
                                msg = "Updating (" + this.MasterJob.targetEntityLogicalName + ") records (" + this.Entitylist.Entities.Count + ")";
                                this.reconJob_Publisher.OnProgress(msg);
                                JobID = 1;
								if (Entitylist.Entities.Count == 0) {
									this.MasterJob.jobResult.RecordsUpdated = 0;
									return JobID;
								}
								try {
                                    this.isRunning = true;
                                    this.MasterJob.jobResult.RecordsUpdated = UpdateMany();
                                    
                                } catch (Exception e1) {
									this.MyReconciler.MasterJob.AppendLog(e1.Message);
									Log.Write.Append(e1.Message, e1);
                                    this.isRunning = false;
                                    wasSuccessful = false;
                                } finally {
                                    this.isRunning = false;
                                }
                                break;

                            case CRUD.DELETE :
                                msg = "Deleting (" + this.MasterJob.targetEntityLogicalName + ") records (" + this.Entitylist.Entities.Count + ")";
                                this.reconJob_Publisher.OnProgress(msg);
                                JobID = 2;
								if (Entitylist.Entities.Count == 0) {
									this.MasterJob.jobResult.RecordsDeleted = 0;
									return JobID;
								}
								try {
                                    this.isRunning = true;
                                    this.MasterJob.jobResult.RecordsDeleted = DeactivateMany();
                                } catch (Exception e1) {
									this.MyReconciler.MasterJob.AppendLog(e1.Message);
									Log.Write.Append(e1.Message, e1);
                                    this.isRunning = false;
                                    wasSuccessful = false;
                                } finally {
                                    this.isRunning = false;
                                }
                                break;
                        }
                        return JobID;
                    }

                    private int CreateMany() {
                        int i = 0;
                        int successes = 0;
                        OrganizationServiceProxy proxy = CRM.getProxy();
                        using (proxy) {

							List<EntityCollection> entityListList = MakeBatches(this.Entitylist);
							foreach (EntityCollection entityList in entityListList) {
								
								// Create an ExecuteMultipleRequest object.
								ExecuteMultipleRequest requestWithResults = new ExecuteMultipleRequest() {
									// Assign settings that define execution behavior: continue on error, return responses. 
									Settings = new ExecuteMultipleSettings() {
										ContinueOnError = true,
										ReturnResponses = true
									},
									// Create an empty organization request collection.
									Requests = new OrganizationRequestCollection()
								};

								// Add a CreateRequest for each entity to the request collection.
								foreach (var entity in entityList.Entities) {
									i += 1;
									CreateRequest createRequest = new CreateRequest { Target = entity };
									requestWithResults.Requests.Add(createRequest);
								}


								// Execute all the requests in the request collection using a single web method call.
								ExecuteMultipleResponse responseWithResults =
									(ExecuteMultipleResponse)proxy.Execute(requestWithResults);


								// Display the results returned in the responses.
								foreach (var responseItem in responseWithResults.Responses) {
									// A valid response.
									if (responseItem.Response != null) {
										this.MasterJob.jobResult.RecordsCreated += 1;
										successes += 1;
									}
									// An error has occurred.
									else if (responseItem.Fault != null) {
										JobResult.JobError error = new JobResult.JobError((responseItem.Fault.Message),							this.MasterJob.targetEntityLogicalName, CRUD.CREATE);
										this.MasterJob.jobResult.ErrorsEncountered.Add(error);
										Log.Write.Append(error.Entity + " - " + error.Error);
									} // end if error
								} // end for each response
							} // end for each entity collection in the collections list

							this.isRunning = false;
                            Finished("Created: " + successes + " records");

                            this.reconJob_Publisher.OnProgress(this.MasterJob.jobResult.RecordsCreated + " records created");
                        }
                        return this.MasterJob.jobResult.RecordsCreated;
                    }

                    private int UpdateMany(bool setAsInactive = false) {

						if (this.MasterJob.IsWorkflowJob) {
							return CancelMany();
						} else {
							int i = 0;
							int successes = 0;
							OrganizationServiceProxy proxy = CRM.getProxy();
							using (proxy) {
								// Add a CreateRequest for each entity to the request collection.
								List<EntityCollection> entityListList = MakeBatches(this.Entitylist);
								foreach (EntityCollection entityList in entityListList) {

									// Create an ExecuteMultipleRequest object.
									ExecuteMultipleRequest requestWithResults = new ExecuteMultipleRequest() {
										// Assign settings that define execution behavior: continue on error, return responses.
										Settings = new ExecuteMultipleSettings() {
											ContinueOnError = false,
											ReturnResponses = true
										},
										// Create an empty organization request collection.
										Requests = new OrganizationRequestCollection()
									};

									// Loop through this bucket's entities and add them to the request
									foreach (var entity in entityList.Entities) {
										i += 1;

										if (setAsInactive) {
											entity.Attributes["statecode"] = new OptionSetValue(1);
										}

										UpdateRequest updateRequest = new UpdateRequest { Target = entity };
										requestWithResults.Requests.Add(updateRequest);
									}

									// Execute all the requests in the request collection using a single web method call.
									ExecuteMultipleResponse responseWithResults =
										(ExecuteMultipleResponse)proxy.Execute(requestWithResults);

									// Display the results returned in the responses.
									foreach (var responseItem in responseWithResults.Responses) {
										// A valid response.
										if (responseItem.Response != null) {
											successes += 1;
											if (!setAsInactive) {
												this.MasterJob.jobResult.RecordsUpdated += 1;
											} else {
												this.MasterJob.jobResult.RecordsDeleted += 1;
											}

										} else if (responseItem.Fault != null) {
											JobResult.JobError error = new JobResult.JobError((responseItem.Fault.Message),
												this.MasterJob.targetEntityLogicalName, CRUD.CREATE);
											this.MasterJob.jobResult.ErrorsEncountered.Add(error);
										} // end if error
									} // end for each response
								} // end for each entity collection in the collections list

								this.isRunning = false;

								if (!setAsInactive) {
									Finished("Updated: " + successes + " records");
								} else {
									Finished("Deleted: " + successes + " records");
								}
								this.reconJob_Publisher.OnProgress(this.MasterJob.jobResult.RecordsUpdated.ToString() + " records updated");
							}
							return successes;
						}
                    }

					private int CancelMany() {
						int i = 0;
						int successes = 0;
						OrganizationServiceProxy proxy = CRM.getProxy();
						using (proxy) {
							// Add a CreateRequest for each entity to the request collection.
							List<EntityCollection> entityListList = MakeBatches(this.Entitylist);
							foreach (EntityCollection entityList in entityListList) {

								// Create an ExecuteMultipleRequest object.
								ExecuteMultipleRequest requestWithResults = new ExecuteMultipleRequest() {
									// Assign settings that define execution behavior: continue on error, return responses.
									Settings = new ExecuteMultipleSettings() {
										ContinueOnError = false,
										ReturnResponses = true
									},
									// Create an empty organization request collection.
									Requests = new OrganizationRequestCollection()
								};

								// Execute all the requests in the request collection using a single web method call.
								ExecuteMultipleResponse responseWithResults =
									(ExecuteMultipleResponse)proxy.Execute(requestWithResults);

								// Display the results returned in the responses.
								foreach (var responseItem in responseWithResults.Responses) {
									// A valid response.
									if (responseItem.Response != null) {
										successes += 1;
										this.MasterJob.jobResult.RecordsUpdated += 1;
									} else if (responseItem.Fault != null) {
										JobResult.JobError error = new JobResult.JobError((responseItem.Fault.Message),
											this.MasterJob.targetEntityLogicalName, CRUD.CREATE);
										this.MasterJob.jobResult.ErrorsEncountered.Add(error);
									} // end if error
								} // end for each response
							} // end for each entity collection in the collections list

							this.isRunning = false;
							Finished("Updated: " + successes + " workflow records");
							this.reconJob_Publisher.OnProgress(this.MasterJob.jobResult.RecordsUpdated.ToString() + " workflow records updated");
						}
						return successes;
					}

					private int UpdateMany() {
						return UpdateMany(false);
					}

					private int DeactivateMany() {
						return UpdateMany(true);
					}

					//private int DeleteMany() {
					//                   int i = 0;
					//                   int successes = 0;
					//                   OrganizationServiceProxy proxy = CRM.getProxy();
					//                   using (proxy) {
					//		List<EntityCollection> entityListList = MakeBatches(this.Entitylist);
					//		foreach (EntityCollection entityList in entityListList) {
					//			// Create an ExecuteMultipleRequest object.
					//			ExecuteMultipleRequest requestWithResults = new ExecuteMultipleRequest() {
					//				// Assign settings that define execution behavior: continue on error, return responses. 
					//				Settings = new ExecuteMultipleSettings() {
					//					ContinueOnError = false,
					//					ReturnResponses = true
					//				},
					//				// Create an empty organization request collection.
					//				Requests = new OrganizationRequestCollection()
					//			};

					//			// Add a CreateRequest for each entity to the request collection.
					//			foreach (var entity in Entitylist.Entities) {
					//				DeleteRequest deleteRequest = new DeleteRequest {
					//					Target = new EntityReference(entity.LogicalName)
					//				};
					//				requestWithResults.Requests.Add(deleteRequest);
					//			}

					//			// Execute all the requests in the request collection using a single web method call.
					//			ExecuteMultipleResponse responseWithResults =
					//				(ExecuteMultipleResponse)proxy.Execute(requestWithResults);

					//			// Display the results returned in the responses.
					//			foreach (var responseItem in responseWithResults.Responses) {
					//				if (responseItem.Response != null) {
					//					this.JobResult.RecordsDeleted += 1;
					//					successes += 1;
					//				}
					//				// An error has occurred.
					//				else if (responseItem.Fault != null) {
					//					JobResult.JobError error = new JobResult.JobError((responseItem.Fault.Message),
					//						this.job.targetEntityLogicalName, CRUD.CREATE);
					//					this.JobResult.ErrorsEncountered.Add(error);
					//				} // end if error
					//			} // end for each response
					//		} // end for each entity collection in the collections list

					//		this.isRunning = false;
					//                       recordsDeleted = "Deleted " + successes + " records.";
					//                       Finished("Deleted: " + successes + " records");
					//                       this.reconJob_Publisher.OnProgress(recordsDeleted + " records deleted");
					//                   }
					//                   return successes;
					//               }

					private List<EntityCollection> MakeBatches(EntityCollection largeList) {
						List<EntityCollection> entityCollectionCollection = new List<EntityCollection>();
						EntityCollection entityCollection = new EntityCollection();
						int i = 0;

						foreach (Entity entity in largeList.Entities) {
							i++;
							entityCollection.Entities.Add(entity);
							if (i > Settings.BatchLimit) {
								entityCollectionCollection.Add(entityCollection);
								entityCollection = new EntityCollection();
								i = 0;
								string msg = "Reached " + Settings.BatchLimit + " entities - batching will be utilized.";
								this.MyReconciler.MasterJob.AppendLog(msg);
								Log.Write.Append(msg);
							}
						}

						entityCollectionCollection.Add(entityCollection);
						return entityCollectionCollection;
					}

                    public String Report() {
                        switch (OperationType) {
                            case CRUD.CREATE:
                                return this.MasterJob.jobResult.RecordsCreated + " records created.";
                            case CRUD.UPDATE:
                                return this.MasterJob.jobResult.RecordsUpdated + " records updated.";
                            case CRUD.DELETE:
                                return this.MasterJob.jobResult.RecordsDeleted + " records deleted.";
                            default:
                                return MasterJob.jobResult.ToString();
                        }
                    }

                    public String FullReport() {
                        return MasterJob.jobResult.ToString();
                    }
                }
            }
            /// <summary>
            /// Attempts to get the 
            /// </summary>
            /// <param name="entity"></param>
            /// <param name="field"></param>
            /// <returns></returns>
            public EntityMetadata GetEntityMetadata() {
				EntityMetadata result;
                OrganizationServiceProxy proxy = CRM.getProxy();
                using (proxy) {
                    RetrieveEntityRequest req = new RetrieveEntityRequest();
                    req.RetrieveAsIfPublished = true;
                    req.LogicalName = this.targetEntityLogicalName;
                    req.EntityFilters = EntityFilters.Attributes;
                    RetrieveEntityResponse resp = (RetrieveEntityResponse)proxy.Execute(req);
                    result = resp.EntityMetadata;
                }
				return result;
			}

            /// <summary>
            /// Attempts to get the 
            /// </summary>
            /// <param name="entity"></param>
            /// <param name="field"></param>
            /// <returns></returns>
            public static EntityMetadata GetEntityMetadata(Entity entity, OrganizationServiceProxy proxy) {
                EntityMetadata result;
                using (proxy) {
                    RetrieveEntityRequest req = new RetrieveEntityRequest();
                    req.RetrieveAsIfPublished = true;
                    req.LogicalName = entity.LogicalName;
                    req.EntityFilters = EntityFilters.Attributes;
                    RetrieveEntityResponse resp = (RetrieveEntityResponse)proxy.Execute(req);
                    result = resp.EntityMetadata;
                }
                return result;
            }

            public string GetEntityGuid(string UniqueFieldName, string UniqueFieldValue) {
				foreach (AttributeMetadata a in MyEntityMetadata.Attributes) {
					if (a.LogicalName.ToString().ToLower() == UniqueFieldName.ToString().ToLower())
						return a.MetadataId.ToString();
				}
				return null;
			}

			/// <summary>
			/// Looks through the EntityMetadata collection and using a unique value returns all of that 
			/// entitity's metadata.
			/// </summary>
			/// <param name="UniqueFieldName">Probably the Join column the SQL query used</param>
			/// <param name="UniqueFieldValue">The value of the join column the SQL query used</param>
			/// <returns>An AttributeMetadata object for the desired field</returns>
			public AttributeMetadata GetAttributeMetadata(string UniqueFieldName, string UniqueFieldValue) {
				foreach (AttributeMetadata a in MyEntityMetadata.Attributes) {
					if (a.LogicalName.ToString().ToLower() == UniqueFieldName.ToString().ToLower())
						return a;
				}
				return null;
			}

            public static AttributeMetadata GetAttributeMetadata(EntityMetadata entityMetadata, string UniqueFieldName, string UniqueFieldValue) {
                foreach (AttributeMetadata a in entityMetadata.Attributes) {
                    if (a.LogicalName.ToString().ToLower() == UniqueFieldName.ToString().ToLower())
                        return a;
                }
                return null;
            }

            /// <summary>
			/// Looks through the EntityMetadata collection and using a unique value returns all of that 
			/// entitity's metadata.
			/// </summary>
			/// <param name="UniqueFieldName">Probably the Join column the SQL query used</param>
			/// <param name="UniqueFieldValue">The value of the join column the SQL query used</param>
			/// <returns>An AttributeMetadata object for the desired field</returns>
            public object ConvertEntityValuePerFieldRequirement(string fieldLogicalName, string desiredValue) {
                return ConvertEntityValuePerFieldRequirement(this.MyEntityMetadata, fieldLogicalName, desiredValue);
            }

			int CountDecimalDigits(decimal n) {
				return n.ToString(System.Globalization.CultureInfo.InvariantCulture)
						//.TrimEnd('0') uncomment if you don't want to count trailing zeroes
						.SkipWhile(c => c != '.')
						.Skip(1)
						.Count();
			}

			static int CountDecimalDigits(string n) {
				return n.ToString(System.Globalization.CultureInfo.InvariantCulture)
						//.TrimEnd('0') uncomment if you don't want to count trailing zeroes
						.SkipWhile(c => c != '.')
						.Skip(1)
						.Count();
			}


			/// <summary>
			/// Analyzes the EntityMetadata collection for the specified field then attempts to convert
			/// the value for the field the proper type.  Without this, IllegalCast exceptions would be 
			/// everywhere.
			/// </summary>
			/// <param name="fieldLogicalName">The field to find and analyze.</param>
			/// <param name="desiredValue">The value to attempt conversion on.</param>
			/// <returns></returns>
			public static object ConvertEntityValuePerFieldRequirement(EntityMetadata entityMetadata, string fieldLogicalName, string desiredValue) {

				foreach (AttributeMetadata a in entityMetadata.Attributes) {
					try {
						// Get the attribute type
						if (a.LogicalName.ToLower() == fieldLogicalName.ToLower()) {
							a.AttributeType.GetType();
							switch (a.AttributeType) {
								case AttributeTypeCode.BigInt:
									if (desiredValue == "")
										desiredValue = "0";
									return Convert.ToInt64(desiredValue);
								case AttributeTypeCode.Boolean:
									if (desiredValue == "0")
										desiredValue = "False";
									if (desiredValue == "1")
										desiredValue = "True";
									return Convert.ToBoolean(desiredValue);
								case AttributeTypeCode.Customer:
									if (desiredValue == null)
										desiredValue = "";
									return desiredValue;
								case AttributeTypeCode.DateTime:
									try {
										return Convert.ToDateTime(desiredValue);
									} catch (Exception) {
										return new DateTime(1900, 1, 1);
									}
								case AttributeTypeCode.Decimal:
									if (desiredValue == "")
										desiredValue = "0";
									return Convert.ToDecimal(desiredValue);
								case AttributeTypeCode.Double:
									if (desiredValue == "")
										desiredValue = "0";
									return Convert.ToDouble(desiredValue);
								case AttributeTypeCode.EntityName:
									if (desiredValue == null)
										desiredValue = "";
									return desiredValue;
								case AttributeTypeCode.Integer:
									if (desiredValue == "")
										desiredValue = "0";
									try {
										if (CountDecimalDigits(desiredValue) > 3) {
											return Convert.ToInt32(Convert.ToDecimal(desiredValue)).ToString();
										}
										return Convert.ToInt32(desiredValue);
									} catch (Exception conversionFailure) {
										try {
											return Convert.ToInt32(Convert.ToDouble(desiredValue));
										} catch (Exception secondConversionFailure) {
											throw;
										}
									}
								case AttributeTypeCode.Lookup:
									if (desiredValue == null)
										desiredValue = "";
									return desiredValue;
								case AttributeTypeCode.ManagedProperty:
									if (desiredValue == "0")
										desiredValue = "False";
									if (desiredValue == "1")
										desiredValue = "True";
									return new BooleanManagedProperty(Convert.ToBoolean(desiredValue));
								case AttributeTypeCode.Memo:
									if (desiredValue == null)
										desiredValue = "";
									return desiredValue;
								case AttributeTypeCode.Money:
									if (desiredValue == "")
										desiredValue = "0";
									return new Money(Convert.ToDecimal(desiredValue));
								case AttributeTypeCode.Owner:
									if (desiredValue == null)
										desiredValue = "";
									return desiredValue;
								case AttributeTypeCode.Picklist:
									if (desiredValue == "")
										desiredValue = "0";
									return Convert.ToInt32(Convert.ToDouble(desiredValue));
								case AttributeTypeCode.State:
									if (desiredValue == "")
										desiredValue = "0";
									return Convert.ToInt32(Convert.ToDouble(desiredValue));
								case AttributeTypeCode.Status:
									if (desiredValue == "")
										desiredValue = "0";
									return Convert.ToInt32(Convert.ToDouble(desiredValue));
								case AttributeTypeCode.String:
									if (desiredValue == null)
										desiredValue = "";
									return desiredValue;
								case AttributeTypeCode.Uniqueidentifier:
									if (desiredValue == null)
										desiredValue = "";
									return desiredValue;
								case AttributeTypeCode.Virtual:
									if (desiredValue == null)
										desiredValue = "";
									return desiredValue;
								default:
									if (desiredValue == null)
										desiredValue = "";
									return desiredValue;
							}
						}
					} catch (Exception castError) {
						Log.Write.Append("Failed to cast value (" + desiredValue + ") to field: " + fieldLogicalName);
						throw;
					}
				}
				return null;
			}

			public bool isLookup(string fieldname) { return isLookup(fieldname, MyEntityMetadata); }

			public static bool isLookup(string fieldname, EntityMetadata entityMetadata) {
				foreach (AttributeMetadata a in entityMetadata.Attributes) {
					if (a.LogicalName.ToString().ToLower() == fieldname.ToString().ToLower())
						if (a.AttributeType == AttributeTypeCode.Lookup) {
							return true;
						} else {
							return false;
						}
				}
				return false;
			}

			public bool isOptionSet(string fieldname) { return isOptionSet(fieldname, MyEntityMetadata); }

			public static bool isOptionSet(string fieldname, EntityMetadata entityMetadata) {
				foreach (AttributeMetadata a in entityMetadata.Attributes) {
					if (a.LogicalName.ToString().ToLower() == fieldname.ToString().ToLower())
						return a.AttributeType == AttributeTypeCode.Picklist;
				}
				return false;
			}

			public bool isState(string fieldname) { return isState(fieldname, MyEntityMetadata); }

				public static bool isState(string fieldname, EntityMetadata entityMetadata) {
				foreach (AttributeMetadata a in entityMetadata.Attributes) {
					if (a.LogicalName.ToString().ToLower() == fieldname.ToString().ToLower())
						return a.AttributeType == AttributeTypeCode.State;
				}
				return false;
			}

			public bool isOwnerLookup(string fieldname) { return isOwnerLookup(fieldname, MyEntityMetadata); }

			public static bool isOwnerLookup(string fieldname, EntityMetadata entityMetadata) {
				foreach (AttributeMetadata a in entityMetadata.Attributes) {
					if (a.LogicalName.ToString().ToLower() == fieldname.ToString().ToLower()) {
						if (a.AttributeType == AttributeTypeCode.Owner) {
							return true;
						}
					}
				}
				return false;
			}

			public bool isCustomerLookup(string fieldname) {return isCustomerLookup(fieldname, MyEntityMetadata); }

			public static bool isCustomerLookup(string fieldname, EntityMetadata entityMetadata) {
				foreach (AttributeMetadata a in entityMetadata.Attributes) {
					if (a.LogicalName.ToString().ToLower() == fieldname.ToString().ToLower()) {
						if (a.AttributeType == AttributeTypeCode.Customer) {
							return true;
						}
					}
				}
				return false;
			}

			public bool isStatus(string fieldname) { return isStatus(fieldname, MyEntityMetadata); }

			public static bool isStatus(string fieldname, EntityMetadata entityMetadata) {
				foreach (AttributeMetadata a in entityMetadata.Attributes) {
					if (a.LogicalName.ToString().ToLower() == fieldname.ToString().ToLower())
						return a.AttributeType == AttributeTypeCode.Status;
				}
				return false;
			}
		}
	}

    namespace OnOffs {
        class Mgrs {
        public static void updateManagers() {

        }
    }

    }
}
