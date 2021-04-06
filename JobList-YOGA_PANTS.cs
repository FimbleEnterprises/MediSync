using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.GotDotNet;
using MediSync;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using System.ComponentModel;
using System.Threading;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Messages;
using System.ServiceModel;
using PerrysNetConsole;

namespace MediSync {
	public class JobList : List<JobList.Job> {

		private static string CrmDbNameQualifier = Properties.Settings.Default.CrmDbQualifyingPrefix;

		// The property representing the list of Job objects found 
		private static List<Job> retrievedJobs { get; set; }

		/// <summary>
		/// Returns all MediSync jobs 
		/// </summary>
		/// <returns></returns>
		public static JobList QueryServerForJobs(bool EnabledJobsOnly = true) {
			SqlConnection conn = new SqlConnection(Properties.Settings.Default.CRMConnString);
			string jobQuery = Properties.Settings.Default.GetJobListQuery;
			JobList joblist = new JobList();
			SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();
			da.SelectCommand = new SqlCommand(jobQuery, conn);
			if (EnabledJobsOnly) {
				da.SelectCommand.CommandText += "WHERE msus_Enabled = 1";
			}
			DataSet ds = new DataSet();
			DataTable dt = new DataTable();
			ConsoleHelper.WriteLine("Connected.  Requesting jobs...", ConsoleForeground.Green, true);
			try {
				da.Fill(ds);
				dt = ds.Tables[0];
			} catch (Exception e) {
				ConsoleHelper.WriteLine("Failed to get jobs!\n\n" + e.Message, ConsoleForeground.Red, true);
				ConsoleHelper.PressAnyKey();
				ConsoleHelper.WaitForInput(true, true);
			}
			JobList unsorted = new JobList();
			int index = 0;
			int count = ds.Tables[0].Rows.Count;
			foreach (DataRow dr in ds.Tables[0].Rows) {
				index += 1;
				ConsoleHelper.WriteLine("Parsing job " + index + " of " + count + "...", ConsoleForeground.Green, true);
				unsorted.Add(new Job(dr));
				System.Threading.Thread.Sleep(150);
			}
			List<Job> sortedList =
				unsorted.OrderByDescending(job => job.msus_Priority).ToList();
			foreach (Job job in sortedList) {
				joblist.Add(job);
			}
			return joblist;
		}

		// Console babysitting
		public void HandleConsoleInput() {
			ConsoleHelper.WriteLine();
			System.Console.ReadLine();
		}

		public void PrintToConsole() {
			int index = 0;
			Console.Clear();
			ConsoleHelper.WriteLine("\nJobs found: (" + this.Count + ")", ConsoleForeground.Green);
			ConsoleHelper.WriteLine("List:", ConsoleForeground.Green);

			foreach (Job Job in this) {
				index += 1;
				ConsoleHelper.WriteLine("" + index + ". " + Job.ToString(), ConsoleForeground.White);
				ConsoleHelper.WriteLine("\n\n");
			}
			String keyPressed = ConsoleHelper.PressAnyNumberKey(
				"Select a job for more details or press any other key to continue", true);
			int num;
			bool isNumeric = int.TryParse(keyPressed, out num);
			if (isNumeric) {
				if (num <= this.Count()) {
					ConsoleHelper.Clear(true);
					// This method blocks and handles user input.
					this[num - 1].PrintDetailsToConsole();
					// When it releases control we'll  end up here.
					ConsoleHelper.PressAnyKey();
					PrintToConsole();
				} else { // User pressed a number but no job was associated with it.
						 // Reprint job list.
					PrintToConsole();
				}
			} else { // Number not pressed.
					 // Exit out to main menu.
				ConsoleHelper.WaitForInput(true, true);
			}
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

			// public static OrganizationServiceProxy _serviceProxy;

			public Guid _onHandInvGUID;
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
			public string msus_medisyncId {
				get;
			}
			public string CreatedOn {
				get;
			}
			public string CreatedBy {
				get;
			}
			public string ModifiedOn {
				get;
			}
			public string ModifiedBy {
				get;
			}
			public string CreatedOnBehalfBy {
				get;
			}
			public string ModifiedOnBehalfBy {
				get;
			}
			public string OwnerId {
				get;
			}
			public int OwnerIdType {
				get;
			}
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
			public int msus_Interval {
				get;
			}
			public string msus_LastRunUTC {
				get;
			}
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
				get;
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
			public string msus_AxJoinColumn {
				get; private set;
			}
			public string msus_CrmJoinColumn {
				get; private set;
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
			private EntityCollection entitiesToCreate {
				get; set;
			}
			private EntityCollection entitiesToUpdate {
				get; set;
			}
			private EntityCollection entitiesToDelete {
				get; set;
			}
			public Reconciler.ReconcileJob Worker {
				get; set;
			}


			/// <summary>
			/// Instantiates a Job object that can be executed by calling its Execute() method.
			/// When Execute() is called the job will attempt to retrieve AX data and apply it 
			/// to the CRM entity.
			/// </summary>
			/// <param name="dr">A DataRow object as returned by the JobList.GetJobs() static function.</param>
			public Job(DataRow dr) {
				this.msus_medisyncId = dr["msus_medisyncId"].ToString();
				this.CreatedOn = dr["CreatedOn"].ToString();
				this.CreatedBy = dr["CreatedBy"].ToString();
				this.ModifiedOn = dr["ModifiedOn"].ToString();
				this.ModifiedBy = dr["ModifiedBy"].ToString();
				this.CreatedOnBehalfBy = dr["CreatedOnBehalfBy"].ToString();
				this.ModifiedOnBehalfBy = dr["ModifiedOnBehalfBy"].ToString();
				this.OwnerId = dr["OwnerId"].ToString();
				this.OwnerIdType = Int32.Parse(dr["OwnerIdType"].ToString());
				this.OwningBusinessUnit = dr["OwningBusinessUnit"].ToString();
				this.statecode = Int32.Parse(dr["statecode"].ToString());
				this.statuscode = Int32.Parse(dr["statuscode"].ToString());
				this.VersionNumber = dr["VersionNumber"].ToString();
				this.ImportSequenceNumber = dr["ImportSequenceNumber"].ToString();
				this.OverriddenCreatedOn = dr["OverriddenCreatedOn"].ToString();
				this.TimeZoneRuleVersionNumber = dr["TimeZoneRuleVersionNumber"].ToString();
				this.UTCConversionTimeZoneCode = dr["UTCConversionTimeZoneCode"].ToString();
				this.msus_name = dr["msus_name"].ToString();
				this.msus_Enabled = (bool) dr["msus_Enabled"];
				this.msus_Interval = Int32.Parse(dr["msus_Interval"].ToString());
				this.msus_LastRunUTC = dr["msus_lastrun_utc"].ToString();
				this.msus_LastRunSuccessful = (bool) dr["msus_LastRunSuccessful"];
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
				// Populate the FieldMap object
				this.fieldMap = new FieldMap(this.msus_AxTargetCols, this.msus_CrmTargetCols);

			}

			public int IntervalMins() {
				return ((msus_Interval / 1000) / 60);
			}

			private List<string> makeListOfStrings(string newLineDelimitedList) {
				List<string> list = new List<string>();
				foreach (string s in newLineDelimitedList.Split('\n')) {
					list.Add(s);
				}
				return list;
			}

			private string MakeSql() {
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
							"   on " + this.msus_AxJoinColumn + " = " + this.msus_CrmJoinColumn + " \n" +
							"WHERE \n" +
								this.axModifiedOnColumn + "   >= '" + this.msus_LastRunUTC + "' collate DATABASE_DEFAULT";

				return sql;
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
				SqlConnection conn = new SqlConnection(Properties.Settings.Default.AXConnString);
				SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();
				string sql = this.MakeSql();
				da.SelectCommand = new SqlCommand(sql, conn);
				DataSet ds = new DataSet();
				DataTable dt = new DataTable();
				ConsoleHelper.Spinner.Start("Looking for changes...");

				try {
					da.Fill(ds);
					dt = ds.Tables[0];
				} catch (Exception ex) {
					ConsoleHelper.WriteLine("Failed to get changes!\n\n" + ex.Message, ConsoleForeground.Red, true);
					ConsoleHelper.PressAnyKey();
					ConsoleHelper.WaitForInput(true, true);
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
					ConsoleHelper.Spinner.Start("Retreiving GUID for " + lookingFor + " in: " + entityToQuery + "...");
					records = CRM.service.RetrieveMultiple(query);
				} catch (Exception e) {
					ConsoleHelper.WriteLine(e.Message, ConsoleForeground.Red);
					System.Threading.Thread.Sleep(3000);
                    ;
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
				return CRM.service.RetrieveMultiple(query);
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
				ConsoleHelper.Spinner.Stop();
				ConsoleHelper.Spinner.Start("Preparing CRUD lists...");

				//if (MyEntityMetadata == null ||
				//		MyEntityMetadata.SchemaName.ToLower()
				//			!= this.new_targetentity.ToLower()) {
				//	this.MyEntityMetadata = GetEntityMetadata();
				//}
				//if (MyEntityMetadata == null)
				//return;
				DataSet jobDataset;
				List<DataRow> deleteRows = new List<DataRow>();
				entitiesToCreate = new EntityCollection();
				entitiesToUpdate = new EntityCollection();
				entitiesToDelete = new EntityCollection();
				try {
					jobDataset = GetDatasetOfChanges();
				} catch (Exception err) {
					ConsoleHelper.WriteLine(err.Message, ConsoleForeground.Red);
					System.Threading.Thread.Sleep(5000);
					ConsoleHelper.Spinner.Stop();
					ConsoleHelper.WaitForInput(true, true);
					throw;
				}

				// Connect to the Organization service. 
				// The using statement assures that the service proxy will be properly disposed.

				using (CRM.serviceProxy) {

					// Instaniate an account object.
					Entity EntityRecord = null;

					foreach (DataRow row in jobDataset.Tables[0].Rows) {

						try {


							bool Update = (bool) row[UPDATECOLUMN];
							bool Create = (bool) row[CREATECOLUMN];
							bool Delete = (bool) row[DELETECOLUMN];

							if (Create)
								EntityRecord = new Entity(this.targetEntityLogicalName);

							if (Update || Delete) {
								// In order to update or delete an entity record, we need the entity record's guid - we get that from our 
								// metadata that we retreived earlier by parsing its attributes looking for a our CRM join
								// column value which should always be unique to that CRM entity record.
								object strGUID = row[ENTITY_ID_COLUMN].ToString();
								// Create an EntityRecord that has an existing GUID
								if (strGUID != DBNull.Value)
									EntityRecord = new Entity(this.targetEntityLogicalName,
												   new Guid(strGUID.ToString()));
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

										// Converts the value for the crm field from what the AX db stored it as to what the CRM
										// field requires.  Without this InvalidCast exceptions become an almost certainty and 
										// will prevent the sync.  (Tough to debug too!)
										object fval = ConvertEntityValuePerFieldRequirement(fname, value.ToString());

										// Lookups can only be updated using the GUID of the value you wish it to display.
										if (isLookup(fname))
											EntityRecord[fname] = new EntityReference(this.targetEntityLogicalName, new Guid(fval.ToString()));
										else
											EntityRecord[fname] = fval;

									} // end if db col is null
								} // end if (create||update)
							} // end foreach field(in entity)
							if (Create)
								entitiesToCreate.Entities.Add(EntityRecord);
							if (Update)
								entitiesToUpdate.Entities.Add(EntityRecord);
							if (Delete)
								entitiesToDelete.Entities.Add(EntityRecord);
						} catch (Exception ex) {
							ConsoleHelper.WriteLine(ex.Message, ConsoleForeground.Red);
						} finally {
							ConsoleHelper.Spinner.Stop();
						}

					} // END foreach row
				} // END using CRM.serviceProxy
			} // END function

			public void Execute() {
				try {
					ConsoleHelper.Clear(true);
					ConsoleHelper.WriteLine(this.ToString());

					ConsoleHelper.Spinner.Start("Getting entity metadata...");
					this.MyEntityMetadata = GetEntityMetadata();
					ConsoleHelper.Spinner.Stop();

					PrepareCrudLists();
					ConsoleHelper.Spinner.Stop();

					Reconciler updater = new Reconciler(this);
					updater.AddJob(new Reconciler.ReconcileJob(this.entitiesToCreate, CRUD.CREATE));
					updater.AddJob(new Reconciler.ReconcileJob(this.entitiesToUpdate, CRUD.UPDATE));
					updater.AddJob(new Reconciler.ReconcileJob(this.entitiesToDelete, CRUD.DELETE));
					ConsoleHelper.Clear();
					ConsoleHelper.Spinner.Start();
					updater.RunAll();

				} catch (Exception e) {
					//TODO FAIL LOGIC
				}
			}

			public EntityCollection GetLookupReferencedEntities() {
				ConsoleHelper.Spinner.Stop();

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
							ConsoleHelper.Spinner.Stop();
							ConsoleHelper.Spinner.Start("Getting records for targeted entity: " + Target);
							LookupTargetedEntities.Add(GetGuidForEveryRecordInEntity(Target));
							ConsoleHelper.Spinner.Stop();
						}
					}
				}
				return coll;
			}

			public override string ToString() {
				return this.msus_name
							+ " - Every " + IntervalMins()
								+ " minutes - Priority: "
									+ this.msus_Priority
										+ " - Enabled: "
											+ this.msus_Enabled;
			}

			public void PrintToConsole() {

				ConsoleForeground enabledColor = ConsoleForeground.Red;
				if (this.msus_Enabled == true) {
					enabledColor = ConsoleForeground.Green;
				}

				ConsoleHelper.WriteLine();
				ConsoleHelper.Write(this.msus_name
							+ " - Every " + IntervalMins()
								+ " minutes - Priority: "
									+ this.msus_Priority
										+ " - Enabled: "
											, ConsoleForeground.Aquamarine);
				ConsoleHelper.Write("" + this.msus_Enabled.ToString(), enabledColor);
			}

			public void PrintDetailsToConsole() {
				ConsoleHelper.Clear();
				ConsoleHelper.WriteLine("Job name:", ConsoleForeground.White);
				this.PrintToConsole();
				ConsoleHelper.CarriageReturn();
				ConsoleHelper.WriteLine("SQL:", ConsoleForeground.White);
				ConsoleHelper.WriteLine(this.MakeSql(), ConsoleForeground.Aquamarine);
				ConsoleHelper.CarriageReturn();
				ConsoleHelper.WriteLine("Mapping instructions: ", ConsoleForeground.White);
				ConsoleHelper.WriteLine(this.fieldMap.ToString().Replace(" AS ", " >> "), ConsoleForeground.Aquamarine);
				ConsoleHelper.WriteLine();
				ConsoleHelper.WriteLine("Press 2 to execute this job now", ConsoleForeground.Green);
				string key = Console.ReadKey().KeyChar.ToString();
				if (key == "2") {
					Execute();
				}
			}

			/// <summary>
			/// Gets then prints to the console a summary list of changes that would be performed 
			/// if this job were executed.
			/// </summary>
			public void PrintPotentialChangesToConsole(bool waitForInput = false) {
				DataSet ds = GetDatasetOfChanges();
				int dels = 0, inserts = 0, edits = 0;
				int changes = ds.Tables[0].Rows.Count;
				ConsoleHelper.WriteLine(changes + " changes found:", ConsoleForeground.Magenta);
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
				ConsoleHelper.WriteLine("Found: " + inserts + " creates, " + edits + " edits and " + dels + " deletes.");
				ConsoleHelper.Spinner.Stop();
				if (waitForInput) {
					ConsoleHelper.WaitForInput(false, false);
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
					return ErrorsEncountered.Count;
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
					this.ErrorsEncountered = errors;
				}

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
								this.RecordsDeleted + ", record(s) deleted, " +
									this.ErrorsEncountered.Count + ", error(s)");

					if (ErrorsEncountered.Count > 0) {
						foreach (JobError err in ErrorsEncountered) {
							sb.Append("\n" + err.ToString());
						}
					}
					return sb.ToString();
				}


				public class JobError {
					public Exception Error {
						get; set;
					}
					public Entity Entity {
						get; set;
					}
					public CRUD OperationType {
						get; set;
					}

					/// <summary>
					/// Builds a new JobError object representing an error while working with a 
					/// specific entity
					/// </summary>
					/// <param name="e">The Exception thrown</param>
					/// <param name="entity">The CRM Entity being worked on</param>
					/// <param name="OperationType">The operation being performed on the specific 
					/// CRM Entity</param>
					public JobError(Exception e, Entity entity, CRUD OperationType) {
						this.Error = e;
						this.Entity = entity;
						this.OperationType = OperationType;
					}

					public JobError(string error, Entity entity, CRUD OperationType) {
						this.Error = new Exception(error);
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
								verb = "creating entity: " + this.Entity.LogicalName.ToUpper();
								break;
							case CRUD.UPDATE:
								verb = "updating entity: " + this.Entity.LogicalName.ToUpper();
								break;
							case CRUD.DELETE:
								verb = "deleting entity: " + this.Entity.LogicalName.ToUpper();
								break;
							default:
								verb = "performing an unknown operation on entity: " +
									this.Entity.LogicalName.ToUpper();
								break;
						}
						return "While " + verb + "\nEncountered error: \n" + Error.Message;
					}
				}// END JobError
			}// END JobResult

			public class Reconciler {
				private int runningJobs = 0;
				public Job MasterJob { get; set; }
				public List<ReconcileJob> ReconcileJobs { get; set; }


				public Reconciler(Job MasterJob) {
					this.MasterJob = MasterJob;
					this.ReconcileJobs = new List<ReconcileJob>();
				}
				public void AddJob(ReconcileJob job) {
					this.ReconcileJobs.Add(job);
				}

				public void RunAll() {
					runningJobs = 0;
					foreach (ReconcileJob Job in ReconcileJobs) {
						runningJobs += 1;
						BackgroundWorker bgw = new BackgroundWorker();
						bgw.DoWork += _DoWork;
						bgw.RunWorkerCompleted += _Completed;
						bgw.RunWorkerAsync(Job);

					}
					RefreshTable();
					ConsoleHelper.Spinner.Start("Working...");
				}

				public void RefreshTable() {
					ConsoleHelper.Clear(true);
					this.MasterJob.PrintToConsole();
					ConsoleHelper.WriteLine();
					ConsoleHelper.WriteLine("Syncing with CRM...", ConsoleForeground.Yellow);
					TableBuilder.Build(this.ReconcileJobs);
				}

				private void _Completed(Object sender, RunWorkerCompletedEventArgs e) {
					runningJobs -= 1;
					foreach (ReconcileJob job in this.ReconcileJobs) {
						if (!job.isRunning && !job.submittedReport) {
							job.spinner.Stop();
							ConsoleHelper.WriteLine(job.Report(), ConsoleForeground.Yellow);
							job.submittedReport = true;
							RefreshTable();
						}
					}
					if (runningJobs == 0) {
						MainForm.QueryAndShowAvailableJobs(true);
					}
				}

				private void _DoWork(Object sender, DoWorkEventArgs e) {
					ReconcileJob task = (ReconcileJob) e.Argument;
					task.Start();
				}

				public class ReconcileJob {
					/// <summary>
					/// Tripped if error was encountered on any CRUD operation
					/// </summary>
					public bool wasSuccessful = true;
					/// <summary>
					/// Turned on when job is executed, turned off upon its completion 
					/// regardless of success.
					/// </summary>
					public bool isRunning = false;
					/// <summary>
					/// Summary of the job's changes
					/// </summary>
					public string results = "";
					public PerrysNetConsole.LoadIndicator spinner;
					public int JobID;
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
					public JobResult JobResult {
						get; set;
					}
					public Boolean submittedReport {
						get;
						set;
					}


					public String[] MakeTableRow() {
						String[] row = new String[] { GetOperation(), isRunning.ToString(), GetRecordsAffected().ToString(), this.JobResult.ErrorCount().ToString() };
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

					public ReconcileJob(EntityCollection entitylist, CRUD operationType) {
						this.Entitylist = entitylist;
						this.OperationType = operationType;
						initialize();
					}

					public int GetRecordsAffected() {
						return this.JobResult.RecordsCreated + this.JobResult.RecordsUpdated + this.JobResult.RecordsDeleted;
					}

					private void initialize() {
						this.JobResult = new JobResult();
						ConsoleHelper.WriteLine();
						this.spinner = ConsoleHelper.Spinner.CreateNew();

					}

					public int Start() {
						this.isRunning = true;
						string msg = "";
						int maxProg = Entitylist.Entities.Count();
						switch (OperationType) {
							case CRUD.CREATE:
								msg = "Creating records (" + this.Entitylist.Entities.Count + ")";
								JobID = 0;
								try {
									this.isRunning = true;
									CreateMany();
								} catch (Exception e1) {
									this.isRunning = false;
									wasSuccessful = false;
								} finally {
									this.isRunning = false;
								}
								break;
							case CRUD.UPDATE:
								msg = "Updating records (" + this.Entitylist.Entities.Count + ")";
								JobID = 1;
								try {
									this.isRunning = true;
									UpdateMany();
								} catch (Exception e1) {
									this.isRunning = false;
									wasSuccessful = false;
								} finally {
									this.isRunning = false;
								}
								break;
							case CRUD.DELETE:
								msg = "Deleting records (" + this.Entitylist.Entities.Count + ")";
								JobID = 2;
								try {
									this.isRunning = true;
									DeleteMany();
								} catch (Exception e1) {
									this.isRunning = false;
									wasSuccessful = false;
								} finally {
									this.isRunning = false;
								}
								break;
						}
						this.spinner.Message = msg;
						PerrysNetConsole.Progress bar = new PerrysNetConsole.Progress();

						this.spinner.Start();
						return JobID;
					}

					private void CreateMany() {
						int i = 0;
						using (CRM.getProxy()) {
							Entity curEntity = null;
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

							// Add a CreateRequest for each entity to the request collection.
							foreach (var entity in this.Entitylist.Entities) {
								i += 1;
								CreateRequest createRequest = new CreateRequest { Target = entity };
								requestWithResults.Requests.Add(createRequest);
							}

							// Execute all the requests in the request collection using a single web method call.
							ExecuteMultipleResponse responseWithResults =
								(ExecuteMultipleResponse) CRM.serviceProxy.Execute(requestWithResults);

							// Display the results returned in the responses.
							foreach (var responseItem in responseWithResults.Responses) {
								// A valid response.
								if (responseItem.Response != null) {
									this.JobResult.RecordsCreated += 1;
									ConsoleHelper.ReuseLine(responseItem.Response.Results.ToString(), ConsoleForeground.Green);
								}
								// An error has occurred.
								else if (responseItem.Fault != null) {
									JobResult.JobError error = new JobResult.JobError(new Exception(responseItem.Fault.Message), curEntity, CRUD.CREATE);
									this.JobResult.ErrorsEncountered.Add(error);
								}
							}
							// ConsoleHelper.ReuseLine(Report(CRUD.CREATE), ConsoleForeground.Green);
						}
					}
					private void UpdateMany() {
						int i = 0;
						using (CRM.getProxy()) {
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

							// Add a CreateRequest for each entity to the request collection.
							foreach (var entity in Entitylist.Entities) {

								i += 1;
								UpdateRequest updateRequest = new UpdateRequest { Target = entity };
								requestWithResults.Requests.Add(updateRequest);
							}

							// Execute all the requests in the request collection using a single web method call.
							ExecuteMultipleResponse responseWithResults =
								(ExecuteMultipleResponse) CRM.serviceProxy.Execute(requestWithResults);

							// Display the results returned in the responses.
							foreach (var responseItem in responseWithResults.Responses) {
								// A valid response.
								if (responseItem.Response != null) {
									this.JobResult.RecordsCreated += 1;
								}
								// An error has occurred.
								else if (responseItem.Fault != null) {
									JobResult.JobError error = new JobResult.JobError(new Exception(responseItem.Fault.Message), Entitylist.Entities[i], CRUD.UPDATE);
									this.JobResult.ErrorsEncountered.Add(error);
								}
							}
							// ConsoleHelper.ReuseLine(Report(CRUD.UPDATE), ConsoleForeground.Green);
						}
					}
					private void DeleteMany() {
						int i = 0;
						using (CRM.getProxy()) {

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

							// Add a CreateRequest for each entity to the request collection.
							foreach (var entity in Entitylist.Entities) {
								DeleteRequest deleteRequest = new DeleteRequest { Target = new EntityReference(entity.LogicalName) };
								requestWithResults.Requests.Add(deleteRequest);
							}

							// Execute all the requests in the request collection using a single web method call.
							ExecuteMultipleResponse responseWithResults =
								(ExecuteMultipleResponse) CRM.serviceProxy.Execute(requestWithResults);

							// Display the results returned in the responses.
							foreach (var responseItem in responseWithResults.Responses) {
								if (responseItem.Response != null) {
									this.JobResult.RecordsCreated += 1;
									ConsoleHelper.ReuseLine(responseItem.Response.Results.ToString(), ConsoleForeground.Green);
								}
								// An error has occurred.
								else if (responseItem.Fault != null) {
									JobResult.JobError error = new JobResult.JobError(new Exception(responseItem.Fault.Message), Entitylist.Entities[i], CRUD.DELETE);
									this.JobResult.ErrorsEncountered.Add(error);
								}
							}
							// ConsoleHelper.ReuseLine(Report(CRUD.DELETE), ConsoleForeground.Green);
						}
					}

					public String Report() {
						switch (OperationType) {
							case CRUD.CREATE:
								return this.JobResult.RecordsUpdated + " records created.";
							case CRUD.UPDATE:
								return this.JobResult.RecordsUpdated + " records updated.";
							case CRUD.DELETE:
								return this.JobResult.RecordsDeleted + " records deleted.";
							default:
								return JobResult.ToString();
						}
					}
					//public override string ToString() {
					//	return this.JobResult.ToString();
					//}

				}

				public class TableBuilder {

					private static RowCollection rowCollection = null;

					private static RowConf MakeHeader() {
						String[] headerdata = null;

						headerdata = new String[] {
							"Operation",
							"Running",
							"Records affected",
							"Errors",
						};
						RowConf header = RowConf.Create(headerdata);
						return header;
					}

					private static List<RowCollection> MakeRows(List<ReconcileJob> jobs) {

						List<RowCollection> allCols = new List<RowCollection>();

						RowConf createRow = RowConf.Create(jobs[0].MakeTableRow());
						RowConf updateRow = RowConf.Create(jobs[1].MakeTableRow());
						RowConf deleteRow = RowConf.Create(jobs[2].MakeTableRow());

						RowCollection created = RowCollection.Create(createRow);
						RowCollection updated = RowCollection.Create(updateRow);
						RowCollection deleted = RowCollection.Create(deleteRow);

						allCols.Add(created);
						allCols.Add(updated);
						allCols.Add(deleted);

						return allCols;
					}

					private static RowCollection Colorize(RowCollection rowcolection) {

						RowCollection original = rowcolection;
						ColorScheme RED = new ColorScheme(ConsoleColor.DarkRed, ConsoleColor.White);
						ColorScheme GREEN = new ColorScheme(ConsoleColor.DarkGreen, ConsoleColor.White);
						ColorScheme DEFAULT = new ColorScheme(ConsoleColor.Black, ConsoleColor.White);
						try {

							rowcolection.Settings.Color = delegate (RowConf me, int colindex, String s) {
								bool running = (me.Data[1] == "True");
								bool notRunning = (me.Data[1] == "False");
								int errs = 0;
								bool errors = (Int32.TryParse(me.Data[3], out errs));
								switch (colindex) {
									case 1:
										if (running) {
											return GREEN;
										} else if (notRunning) {
											return RED;
										} else {
											return DEFAULT;
										}
									case 3:
										if (errs > 0) {
											return RED;
										} else {
											return DEFAULT;
										}
									default:
										return DEFAULT;
								}
							};

							// highlight padding in column 0
							rowcolection.Settings.IsHighlightPadding = delegate (RowConf me, int colindex, String s) {
								return (colindex == 0);
							};
						} catch (Exception ex) {
							return original;
						}

						return rowcolection;
					}


					public static void Build(string title, List<ReconcileJob> jobs) {

						Console.Clear();

						ConsoleHelper.WriteLine();
						ConsoleHelper.WriteLine("Syncing with CRM...", ConsoleForeground.Yellow);

						CoEx.WindowHeight = CoEx.WindowHeightMax - 10;
						CoEx.BufferHeight = 256;

						RowCollection.DefaultSettings.Border.Enabled = true; // enable bordering
						RowCollection.DefaultSettings.Border.HorizontalLineBody
							= BorderConf.HorizontalLineAfterHeaderFunc; // line between the rows

						RowConf header = MakeHeader();
						List<RowCollection> rows = MakeRows(jobs);

						List<RowCollection> colorizedRows = new List<RowCollection>();

						foreach (RowCollection row in rows) {
							colorizedRows.Add(Colorize(row));
						}

						CoEx.WriteLine();

						foreach (RowCollection row in colorizedRows) {
							row.Import(0, header);
							CoEx.WriteTable(row);
						}

					}

					public static void Build(List<ReconcileJob> jobs) {
						Build("", jobs);
					}
				}
			}
			/// <summary>
			/// Attempts to get the 
			/// </summary>
			/// <param name="entity"></param>
			/// <param name="field"></param>
			/// <returns></returns>
			public static EntityMetadata GetEntityMetadata(string entityLogicalName) {
                
                EntityMetadata result;
				ConsoleHelper.Spinner.Stop();
				ConsoleHelper.Spinner.Start("Retreiving all metadata for entity: " + entityLogicalName + "...");
				using (CRM.serviceProxy) {
					RetrieveEntityRequest req = new RetrieveEntityRequest();
					req.RetrieveAsIfPublished = true;
                    req.LogicalName = entityLogicalName;
					req.EntityFilters = EntityFilters.Attributes;
					RetrieveEntityResponse resp = (RetrieveEntityResponse) CRM.serviceProxy.Execute(req);
					result = resp.EntityMetadata;
					ConsoleHelper.Spinner.Stop();
					// ConsoleHelper.WriteLine("Metadata " + this.new_targetentity + " retrieved.", ConsoleForeground.LightGray);
				}
				return result;
			}

            public EntityMetadata GetEntityMetadata()
            {
                return GetEntityMetadata(this.targetEntityLogicalName);
            }

			public string GetEntityGuid(string UniqueFieldName, string UniqueFieldValue) {
				foreach (AttributeMetadata a in MyEntityMetadata.Attributes) {
					if (a.LogicalName.ToString().ToLower() == UniqueFieldName.ToString().ToLower())
						return a.MetadataId.ToString();
				}
				return null;
			}

			public bool isLookup(string fieldname) {
				foreach (AttributeMetadata a in MyEntityMetadata.Attributes) {
					if (a.LogicalName.ToString().ToLower() == fieldname.ToString().ToLower())
						return a.AttributeType == AttributeTypeCode.Lookup;
				}
				return false;
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

			/// <summary>
			/// Analyzes the EntityMetadata collection for the specified field then attempts to convert
			/// the value for the field the proper type.  Without this, IllegalCast exceptions would be 
			/// everywhere.
			/// </summary>
			/// <param name="fieldLogicalName">The field to find and analyze.</param>
			/// <param name="desiredValue">The value to attempt conversion on.</param>
			/// <returns></returns>
			public object ConvertEntityValuePerFieldRequirement(string fieldLogicalName, string desiredValue) {

				foreach (AttributeMetadata a in MyEntityMetadata.Attributes) {

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
								return new BooleanManagedProperty(Convert.ToBoolean(desiredValue));
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
								return Convert.ToInt32(Convert.ToDouble(desiredValue));
							case AttributeTypeCode.Lookup:
								if (desiredValue == null)
									desiredValue = "";
								return desiredValue;
							case AttributeTypeCode.ManagedProperty:
								if (desiredValue == "0")
									desiredValue = "False";
								if (desiredValue == "1")
									desiredValue = "True";
								return Convert.ToBoolean(desiredValue);
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
				}
				return null;
			}
		}
	}
	}
