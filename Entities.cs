using Microsoft.GotDotNet;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

[assembly: Microsoft.Xrm.Sdk.Client.ProxyTypesAssemblyAttribute()]

namespace CrmEarlyBound {
	public class CrmEntities {

		/// <summary>
		/// Process whose execution can proceed independently or in the background.
		/// </summary>
		[System.Runtime.Serialization.DataContractAttribute()]
		[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("asyncoperation")]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.0.0.9369")]
		[System.Data.Services.Common.DataServiceKeyAttribute("Id")]
		[System.Data.Services.IgnorePropertiesAttribute("Item", "Attributes", "EntityState", "FormattedValues", "RelatedEntities", "ExtensionData")]
		[Microsoft.Xrm.Client.Metadata.EntityAttribute("AsyncOperationSet")]
		public partial class AsyncOperation : Microsoft.Xrm.Client.CrmEntity {

			public static class Fields {
				public const string AsyncOperationId = "asyncoperationid";
				public const string Id = "asyncoperationid";
				public const string CompletedOn = "completedon";
				public const string CorrelationId = "correlationid";
				public const string CorrelationUpdatedTime = "correlationupdatedtime";
				public const string CreatedBy = "createdby";
				public const string CreatedOn = "createdon";
				public const string CreatedOnBehalfBy = "createdonbehalfby";
				public const string Data = "data";
				public const string DependencyToken = "dependencytoken";
				public const string Depth = "depth";
				public const string ErrorCode = "errorcode";
				public const string ExecutionTimeSpan = "executiontimespan";
				public const string FriendlyMessage = "friendlymessage";
				public const string HostId = "hostid";
				public const string IsWaitingForEvent = "iswaitingforevent";
				public const string Message = "message";
				public const string MessageName = "messagename";
				public const string ModifiedBy = "modifiedby";
				public const string ModifiedOn = "modifiedon";
				public const string ModifiedOnBehalfBy = "modifiedonbehalfby";
				public const string Name = "name";
				public const string OperationType = "operationtype";
				public const string OwnerId = "ownerid";
				public const string OwningBusinessUnit = "owningbusinessunit";
				public const string OwningExtensionId = "owningextensionid";
				public const string OwningTeam = "owningteam";
				public const string OwningUser = "owninguser";
				public const string ParentPluginExecutionId = "parentpluginexecutionid";
				public const string PostponeUntil = "postponeuntil";
				public const string PrimaryEntityType = "primaryentitytype";
				public const string RecurrencePattern = "recurrencepattern";
				public const string RecurrenceStartTime = "recurrencestarttime";
				public const string RegardingObjectId = "regardingobjectid";
				public const string RequestId = "requestid";
				public const string RetryCount = "retrycount";
				public const string Sequence = "sequence";
				public const string StartedOn = "startedon";
				public const string StateCode = "statecode";
				public const string StatusCode = "statuscode";
				public const string Subtype = "subtype";
				public const string TimeZoneRuleVersionNumber = "timezoneruleversionnumber";
				public const string UTCConversionTimeZoneCode = "utcconversiontimezonecode";
				public const string WorkflowActivationId = "workflowactivationid";
				public const string WorkflowStageName = "workflowstagename";
			}

			/// <summary>
			/// Default Constructor.
			/// </summary>
			public AsyncOperation() :
					base(EntityLogicalName) {
			}

			public const string EntityLogicalName = "asyncoperation";

			public const string PrimaryIdAttribute = "asyncoperationid";

			public const string PrimaryNameAttribute = "name";

			public const int EntityTypeCode = 4700;

			/// <summary>
			/// Unique identifier of the system job.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("asyncoperationid")]
			public System.Nullable<System.Guid> AsyncOperationId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("asyncoperationid");
				}
				set {
					this.SetPrimaryIdAttributeValue<System.Nullable<System.Guid>>("AsyncOperationId", "asyncoperationid", value);
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("asyncoperationid")]
			public override System.Guid Id {
				get {
					return base.Id;
				}
				set {
					this.AsyncOperationId = value;
				}
			}

			/// <summary>
			/// Date and time when the system job was completed.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("completedon")]
			public System.Nullable<System.DateTime> CompletedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("completedon");
				}
			}

			/// <summary>
			/// Unique identifier used to correlate between multiple SDK requests and system jobs.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("correlationid")]
			public System.Nullable<System.Guid> CorrelationId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("correlationid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("CorrelationId", "correlationid", value);
				}
			}

			/// <summary>
			/// Last time the correlation depth was updated.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("correlationupdatedtime")]
			public System.Nullable<System.DateTime> CorrelationUpdatedTime {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("correlationupdatedtime");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.DateTime>>("CorrelationUpdatedTime", "correlationupdatedtime", value);
				}
			}

			/// <summary>
			/// Unique identifier of the user who created the system job.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
			public Microsoft.Xrm.Client.CrmEntityReference CreatedBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
				}
			}

			/// <summary>
			/// Date and time when the system job was created.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
			public System.Nullable<System.DateTime> CreatedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
				}
			}

			/// <summary>
			/// Unique identifier of the delegate user who created the asyncoperation.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
			public Microsoft.Xrm.Client.CrmEntityReference CreatedOnBehalfBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("CreatedOnBehalfBy", "createdonbehalfby", value);
				}
			}

			/// <summary>
			/// Unstructured data associated with the system job.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("data")]
			public string Data {
				get {
					return this.GetAttributeValue<string>("data");
				}
				set {
					this.SetAttributeValue<string>("Data", "data", value);
				}
			}

			/// <summary>
			/// Execution of all operations with the same dependency token is serialized.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("dependencytoken")]
			public string DependencyToken {
				get {
					return this.GetAttributeValue<string>("dependencytoken");
				}
				set {
					this.SetAttributeValue<string>("DependencyToken", "dependencytoken", value);
				}
			}

			/// <summary>
			/// Number of SDK calls made since the first call.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("depth")]
			public System.Nullable<int> Depth {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("depth");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("Depth", "depth", value);
				}
			}

			/// <summary>
			/// Error code returned from a canceled system job.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("errorcode")]
			public System.Nullable<int> ErrorCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("errorcode");
				}
			}

			/// <summary>
			/// Time that the system job has taken to execute.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("executiontimespan")]
			public System.Nullable<double> ExecutionTimeSpan {
				get {
					return this.GetAttributeValue<System.Nullable<double>>("executiontimespan");
				}
			}

			/// <summary>
			/// Message provided by the system job.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("friendlymessage")]
			public string FriendlyMessage {
				get {
					return this.GetAttributeValue<string>("friendlymessage");
				}
				set {
					this.SetAttributeValue<string>("FriendlyMessage", "friendlymessage", value);
				}
			}

			/// <summary>
			/// Unique identifier of the host that owns this system job.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("hostid")]
			public string HostId {
				get {
					return this.GetAttributeValue<string>("hostid");
				}
				set {
					this.SetAttributeValue<string>("HostId", "hostid", value);
				}
			}

			/// <summary>
			/// Indicates that the system job is waiting for an event.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("iswaitingforevent")]
			public System.Nullable<bool> IsWaitingForEvent {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("iswaitingforevent");
				}
			}

			/// <summary>
			/// Message related to the system job.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("message")]
			public string Message {
				get {
					return this.GetAttributeValue<string>("message");
				}
			}

			/// <summary>
			/// Name of the message that started this system job.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("messagename")]
			public string MessageName {
				get {
					return this.GetAttributeValue<string>("messagename");
				}
				set {
					this.SetAttributeValue<string>("MessageName", "messagename", value);
				}
			}

			/// <summary>
			/// Unique identifier of the user who last modified the system job.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
			public Microsoft.Xrm.Client.CrmEntityReference ModifiedBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
				}
			}

			/// <summary>
			/// Date and time when the system job was last modified.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
			public System.Nullable<System.DateTime> ModifiedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
				}
			}

			/// <summary>
			/// Unique identifier of the delegate user who last modified the asyncoperation.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
			public Microsoft.Xrm.Client.CrmEntityReference ModifiedOnBehalfBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ModifiedOnBehalfBy", "modifiedonbehalfby", value);
				}
			}

			/// <summary>
			/// Name of the system job.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("name")]
			public string Name {
				get {
					return this.GetAttributeValue<string>("name");
				}
				set {
					this.SetAttributeValue<string>("Name", "name", value);
				}
			}

			/// <summary>
			/// Type of the system job.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("operationtype")]
			public System.Nullable<int> OperationType {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("operationtype");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("OperationType", "operationtype", value);
				}
			}

			/// <summary>
			/// Unique identifier of the user or team who owns the system job.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ownerid")]
			public Microsoft.Xrm.Client.CrmEntityReference OwnerId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ownerid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("OwnerId", "ownerid", value);
				}
			}

			/// <summary>
			/// Unique identifier of the business unit that owns the system job.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningbusinessunit")]
			public Microsoft.Xrm.Client.CrmEntityReference OwningBusinessUnit {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningbusinessunit");
				}
			}

			/// <summary>
			/// Unique identifier of the owning extension with which the system job is associated.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningextensionid")]
			public Microsoft.Xrm.Client.CrmEntityReference OwningExtensionId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningextensionid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("OwningExtensionId", "owningextensionid", value);
				}
			}

			/// <summary>
			/// Unique identifier of the team who owns the record.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningteam")]
			public Microsoft.Xrm.Client.CrmEntityReference OwningTeam {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningteam");
				}
			}

			/// <summary>
			/// Unique identifier of the user who owns the record.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owninguser")]
			public Microsoft.Xrm.Client.CrmEntityReference OwningUser {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owninguser");
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("parentpluginexecutionid")]
			public System.Nullable<System.Guid> ParentPluginExecutionId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("parentpluginexecutionid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("ParentPluginExecutionId", "parentpluginexecutionid", value);
				}
			}

			/// <summary>
			/// Indicates whether the system job should run only after the specified date and time.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("postponeuntil")]
			public System.Nullable<System.DateTime> PostponeUntil {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("postponeuntil");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.DateTime>>("PostponeUntil", "postponeuntil", value);
				}
			}

			/// <summary>
			/// Type of entity with which the system job is primarily associated.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("primaryentitytype")]
			public string PrimaryEntityType {
				get {
					return this.GetAttributeValue<string>("primaryentitytype");
				}
				set {
					this.SetAttributeValue<string>("PrimaryEntityType", "primaryentitytype", value);
				}
			}

			/// <summary>
			/// Pattern of the system job's recurrence.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("recurrencepattern")]
			public string RecurrencePattern {
				get {
					return this.GetAttributeValue<string>("recurrencepattern");
				}
				set {
					this.SetAttributeValue<string>("RecurrencePattern", "recurrencepattern", value);
				}
			}

			/// <summary>
			/// Starting time in UTC for the recurrence pattern.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("recurrencestarttime")]
			public System.Nullable<System.DateTime> RecurrenceStartTime {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("recurrencestarttime");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.DateTime>>("RecurrenceStartTime", "recurrencestarttime", value);
				}
			}

			/// <summary>
			/// Unique identifier of the object with which the system job is associated.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("regardingobjectid")]
			public Microsoft.Xrm.Client.CrmEntityReference RegardingObjectId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("regardingobjectid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("RegardingObjectId", "regardingobjectid", value);
				}
			}

			/// <summary>
			/// Unique identifier of the request that generated the system job.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("requestid")]
			public System.Nullable<System.Guid> RequestId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("requestid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("RequestId", "requestid", value);
				}
			}

			/// <summary>
			/// Number of times to retry the system job.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("retrycount")]
			public System.Nullable<int> RetryCount {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("retrycount");
				}
			}

			/// <summary>
			/// Order in which operations were submitted.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sequence")]
			public System.Nullable<long> Sequence {
				get {
					return this.GetAttributeValue<System.Nullable<long>>("sequence");
				}
			}

			/// <summary>
			/// Date and time when the system job was started.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("startedon")]
			public System.Nullable<System.DateTime> StartedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("startedon");
				}
			}

			/// <summary>
			/// Status of the system job.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statecode")]
			public System.Nullable<int> StateCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("statecode");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("StateCode", "statecode", value);
				}
			}

			/// <summary>
			/// Reason for the status of the system job.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statuscode")]
			public System.Nullable<int> StatusCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("statuscode");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("StatusCode", "statuscode", value);
				}
			}

			/// <summary>
			/// The Subtype of the Async Job
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("subtype")]
			public System.Nullable<int> Subtype {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("subtype");
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezoneruleversionnumber")]
			public System.Nullable<int> TimeZoneRuleVersionNumber {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("timezoneruleversionnumber");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TimeZoneRuleVersionNumber", "timezoneruleversionnumber", value);
				}
			}

			/// <summary>
			/// Time zone code that was in use when the record was created.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("utcconversiontimezonecode")]
			public System.Nullable<int> UTCConversionTimeZoneCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("utcconversiontimezonecode");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("UTCConversionTimeZoneCode", "utcconversiontimezonecode", value);
				}
			}

			/// <summary>
			/// Unique identifier of the workflow activation related to the system job.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("workflowactivationid")]
			public Microsoft.Xrm.Client.CrmEntityReference WorkflowActivationId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("workflowactivationid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("WorkflowActivationId", "workflowactivationid", value);
				}
			}

			/// <summary>
			/// Name of a workflow stage.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("workflowstagename")]
			public string WorkflowStageName {
				get {
					return this.GetAttributeValue<string>("workflowstagename");
				}
			}

			/// <summary>
			/// Constructor for populating via LINQ queries given a LINQ anonymous type
			/// <param name="anonymousType">LINQ anonymous type.</param>
			/// </summary>
			public AsyncOperation(object anonymousType) :
					this() {
				foreach (var p in anonymousType.GetType().GetProperties()) {
					var value = p.GetValue(anonymousType, null);
					var name = p.Name.ToLower();

					if (name.EndsWith("enum") && value.GetType().BaseType == typeof(System.Enum)) {
						value = new Microsoft.Xrm.Sdk.OptionSetValue((int)value);
						name = name.Remove(name.Length - "enum".Length);
					}

					switch (name) {
						case "id":
							base.Id = (System.Guid)value;
							Attributes["asyncoperationid"] = base.Id;
							break;
						case "asyncoperationid":
							var id = (System.Nullable<System.Guid>)value;
							if (id == null) { continue; }
							base.Id = id.Value;
							Attributes[name] = base.Id;
							break;
						case "formattedvalues":
							// Add Support for FormattedValues
							FormattedValues.AddRange((Microsoft.Xrm.Sdk.FormattedValueCollection)value);
							break;
						default:
							Attributes[name] = value;
							break;
					}
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("operationtype")]
			public virtual AsyncOperation_OperationType? OperationTypeEnum {
				get {
					return ((AsyncOperation_OperationType?)(EntityOptionSetEnum.GetEnum(this, "operationtype")));
				}
				set {
					OperationType = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statecode")]
			public virtual AsyncOperationState? StateCodeEnum {
				get {
					return ((AsyncOperationState?)(EntityOptionSetEnum.GetEnum(this, "statecode")));
				}
				set {
					StateCode = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statuscode")]
			public virtual AsyncOperation_StatusCode? StatusCodeEnum {
				get {
					return ((AsyncOperation_StatusCode?)(EntityOptionSetEnum.GetEnum(this, "statuscode")));
				}
				set {
					StatusCode = (int?)value;
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Runtime.Serialization.DataContractAttribute()]
		[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("msus_trip_entry")]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.0.0.9369")]
		[System.Data.Services.Common.DataServiceKeyAttribute("Id")]
		[System.Data.Services.IgnorePropertiesAttribute("Item", "Attributes", "EntityState", "FormattedValues", "RelatedEntities", "ExtensionData")]
		[Microsoft.Xrm.Client.Metadata.EntityAttribute("msus_trip_entrySet")]
		public partial class msus_trip_entry : Microsoft.Xrm.Client.CrmEntity {

			public static class Fields {
				public const string CreatedBy = "createdby";
				public const string CreatedOn = "createdon";
				public const string CreatedOnBehalfBy = "createdonbehalfby";
				public const string ImportSequenceNumber = "importsequencenumber";
				public const string ModifiedBy = "modifiedby";
				public const string ModifiedOn = "modifiedon";
				public const string ModifiedOnBehalfBy = "modifiedonbehalfby";
				public const string msus_comment = "msus_comment";
				public const string msus_full_trip = "msus_full_trip";
				public const string msus_lat = "msus_lat";
				public const string msus_lon = "msus_lon";
				public const string msus_name = "msus_name";
				public const string msus_speed = "msus_speed";
				public const string msus_trip_entryId = "msus_trip_entryid";
				public const string Id = "msus_trip_entryid";
				public const string msus_tripcode = "msus_tripcode";
				public const string msus_was_paused = "msus_was_paused";
				public const string OverriddenCreatedOn = "overriddencreatedon";
				public const string OwnerId = "ownerid";
				public const string OwningBusinessUnit = "owningbusinessunit";
				public const string OwningTeam = "owningteam";
				public const string OwningUser = "owninguser";
				public const string processid = "processid";
				public const string stageid = "stageid";
				public const string StateCode = "statecode";
				public const string StatusCode = "statuscode";
				public const string TimeZoneRuleVersionNumber = "timezoneruleversionnumber";
				public const string traversedpath = "traversedpath";
				public const string UTCConversionTimeZoneCode = "utcconversiontimezonecode";
				public const string VersionNumber = "versionnumber";
			}

			/// <summary>
			/// Default Constructor.
			/// </summary>
			public msus_trip_entry() :
					base(EntityLogicalName) {
			}

			public const string EntityLogicalName = "msus_trip_entry";

			public const string PrimaryIdAttribute = "msus_trip_entryid";

			public const string PrimaryNameAttribute = "msus_name";

			public const int EntityTypeCode = 10081;

			/// <summary>
			/// Unique identifier of the user who created the record.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
			public Microsoft.Xrm.Client.CrmEntityReference CreatedBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
				}
			}

			/// <summary>
			/// Date and time when the record was created.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
			public System.Nullable<System.DateTime> CreatedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
				}
			}

			/// <summary>
			/// Unique identifier of the delegate user who created the record.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
			public Microsoft.Xrm.Client.CrmEntityReference CreatedOnBehalfBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("CreatedOnBehalfBy", "createdonbehalfby", value);
				}
			}

			/// <summary>
			/// Sequence number of the import that created this record.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("importsequencenumber")]
			public System.Nullable<int> ImportSequenceNumber {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("importsequencenumber");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("ImportSequenceNumber", "importsequencenumber", value);
				}
			}

			/// <summary>
			/// Unique identifier of the user who modified the record.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
			public Microsoft.Xrm.Client.CrmEntityReference ModifiedBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
				}
			}

			/// <summary>
			/// Date and time when the record was modified.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
			public System.Nullable<System.DateTime> ModifiedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
				}
			}

			/// <summary>
			/// Unique identifier of the delegate user who modified the record.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
			public Microsoft.Xrm.Client.CrmEntityReference ModifiedOnBehalfBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ModifiedOnBehalfBy", "modifiedonbehalfby", value);
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msus_comment")]
			public string msus_comment {
				get {
					return this.GetAttributeValue<string>("msus_comment");
				}
				set {
					this.SetAttributeValue<string>("msus_comment", "msus_comment", value);
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msus_full_trip")]
			public Microsoft.Xrm.Client.CrmEntityReference msus_full_trip {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("msus_full_trip");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("msus_full_trip", "msus_full_trip", value);
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msus_lat")]
			public System.Nullable<decimal> msus_lat {
				get {
					return this.GetAttributeValue<System.Nullable<decimal>>("msus_lat");
				}
				set {
					this.SetAttributeValue<System.Nullable<decimal>>("msus_lat", "msus_lat", value);
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msus_lon")]
			public System.Nullable<decimal> msus_lon {
				get {
					return this.GetAttributeValue<System.Nullable<decimal>>("msus_lon");
				}
				set {
					this.SetAttributeValue<System.Nullable<decimal>>("msus_lon", "msus_lon", value);
				}
			}

			/// <summary>
			/// The name of the custom entity.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msus_name")]
			public string msus_name {
				get {
					return this.GetAttributeValue<string>("msus_name");
				}
				set {
					this.SetAttributeValue<string>("msus_name", "msus_name", value);
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msus_speed")]
			public System.Nullable<int> msus_speed {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("msus_speed");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("msus_speed", "msus_speed", value);
				}
			}

			/// <summary>
			/// Unique identifier for entity instances
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msus_trip_entryid")]
			public System.Nullable<System.Guid> msus_trip_entryId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("msus_trip_entryid");
				}
				set {
					this.SetPrimaryIdAttributeValue<System.Nullable<System.Guid>>("msus_trip_entryId", "msus_trip_entryid", value);
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msus_trip_entryid")]
			public override System.Guid Id {
				get {
					return base.Id;
				}
				set {
					this.msus_trip_entryId = value;
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msus_tripcode")]
			public System.Nullable<int> msus_tripcode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("msus_tripcode");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("msus_tripcode", "msus_tripcode", value);
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msus_was_paused")]
			public System.Nullable<bool> msus_was_paused {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("msus_was_paused");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("msus_was_paused", "msus_was_paused", value);
				}
			}

			/// <summary>
			/// Date and time that the record was migrated.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("overriddencreatedon")]
			public System.Nullable<System.DateTime> OverriddenCreatedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("overriddencreatedon");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.DateTime>>("OverriddenCreatedOn", "overriddencreatedon", value);
				}
			}

			/// <summary>
			/// Owner Id
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ownerid")]
			public Microsoft.Xrm.Client.CrmEntityReference OwnerId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ownerid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("OwnerId", "ownerid", value);
				}
			}

			/// <summary>
			/// Unique identifier for the business unit that owns the record
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningbusinessunit")]
			public Microsoft.Xrm.Client.CrmEntityReference OwningBusinessUnit {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningbusinessunit");
				}
			}

			/// <summary>
			/// Unique identifier for the team that owns the record.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningteam")]
			public Microsoft.Xrm.Client.CrmEntityReference OwningTeam {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningteam");
				}
			}

			/// <summary>
			/// Unique identifier for the user that owns the record.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owninguser")]
			public Microsoft.Xrm.Client.CrmEntityReference OwningUser {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owninguser");
				}
			}

			/// <summary>
			/// Contains the id of the process associated with the entity.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("processid")]
			public System.Nullable<System.Guid> processid {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("processid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("processid", "processid", value);
				}
			}

			/// <summary>
			/// Contains the id of the stage where the entity is located.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("stageid")]
			public System.Nullable<System.Guid> stageid {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("stageid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("stageid", "stageid", value);
				}
			}

			/// <summary>
			/// Status of the Trip Entry
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statecode")]
			public System.Nullable<int> StateCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("statecode");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("StateCode", "statecode", value);
				}
			}

			/// <summary>
			/// Reason for the status of the Trip Entry
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statuscode")]
			public System.Nullable<int> StatusCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("statuscode");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("StatusCode", "statuscode", value);
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezoneruleversionnumber")]
			public System.Nullable<int> TimeZoneRuleVersionNumber {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("timezoneruleversionnumber");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TimeZoneRuleVersionNumber", "timezoneruleversionnumber", value);
				}
			}

			/// <summary>
			/// A comma separated list of string values representing the unique identifiers of stages in a Business Process Flow Instance in the order that they occur.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("traversedpath")]
			public string traversedpath {
				get {
					return this.GetAttributeValue<string>("traversedpath");
				}
				set {
					this.SetAttributeValue<string>("traversedpath", "traversedpath", value);
				}
			}

			/// <summary>
			/// Time zone code that was in use when the record was created.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("utcconversiontimezonecode")]
			public System.Nullable<int> UTCConversionTimeZoneCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("utcconversiontimezonecode");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("UTCConversionTimeZoneCode", "utcconversiontimezonecode", value);
				}
			}

			/// <summary>
			/// Version Number
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
			public System.Nullable<long> VersionNumber {
				get {
					return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
				}
			}

			/// <summary>
			/// Constructor for populating via LINQ queries given a LINQ anonymous type
			/// <param name="anonymousType">LINQ anonymous type.</param>
			/// </summary>
			public msus_trip_entry(object anonymousType) :
					this() {
				foreach (var p in anonymousType.GetType().GetProperties()) {
					var value = p.GetValue(anonymousType, null);
					var name = p.Name.ToLower();

					if (name.EndsWith("enum") && value.GetType().BaseType == typeof(System.Enum)) {
						value = new Microsoft.Xrm.Sdk.OptionSetValue((int)value);
						name = name.Remove(name.Length - "enum".Length);
					}

					switch (name) {
						case "id":
							base.Id = (System.Guid)value;
							Attributes["msus_trip_entryid"] = base.Id;
							break;
						case "msus_trip_entryid":
							var id = (System.Nullable<System.Guid>)value;
							if (id == null) { continue; }
							base.Id = id.Value;
							Attributes[name] = base.Id;
							break;
						case "formattedvalues":
							// Add Support for FormattedValues
							FormattedValues.AddRange((Microsoft.Xrm.Sdk.FormattedValueCollection)value);
							break;
						default:
							Attributes[name] = value;
							break;
					}
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statecode")]
			public virtual msus_trip_entryState? StateCodeEnum {
				get {
					return ((msus_trip_entryState?)(EntityOptionSetEnum.GetEnum(this, "statecode")));
				}
				set {
					StateCode = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statuscode")]
			public virtual msus_trip_entry_StatusCode? StatusCodeEnum {
				get {
					return ((msus_trip_entry_StatusCode?)(EntityOptionSetEnum.GetEnum(this, "statuscode")));
				}
				set {
					StatusCode = (int?)value;
				}
			}
		}

		/// <summary>
		/// Top level of the Microsoft Dynamics 365 business hierarchy. The organization can be a specific business, holding company, or corporation.
		/// </summary>
		[System.Runtime.Serialization.DataContractAttribute()]
		[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("organization")]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.0.0.9369")]
		[System.Data.Services.Common.DataServiceKeyAttribute("Id")]
		[System.Data.Services.IgnorePropertiesAttribute("Item", "Attributes", "EntityState", "FormattedValues", "RelatedEntities", "ExtensionData")]
		[Microsoft.Xrm.Client.Metadata.EntityAttribute("OrganizationSet")]
		public partial class Organization : Microsoft.Xrm.Client.CrmEntity {

			public static class Fields {
				public const string ACIWebEndpointUrl = "aciwebendpointurl";
				public const string AcknowledgementTemplateId = "acknowledgementtemplateid";
				public const string AllowAddressBookSyncs = "allowaddressbooksyncs";
				public const string AllowAutoResponseCreation = "allowautoresponsecreation";
				public const string AllowAutoUnsubscribe = "allowautounsubscribe";
				public const string AllowAutoUnsubscribeAcknowledgement = "allowautounsubscribeacknowledgement";
				public const string AllowClientMessageBarAd = "allowclientmessagebarad";
				public const string AllowEntityOnlyAudit = "allowentityonlyaudit";
				public const string AllowMarketingEmailExecution = "allowmarketingemailexecution";
				public const string AllowOfflineScheduledSyncs = "allowofflinescheduledsyncs";
				public const string AllowOutlookScheduledSyncs = "allowoutlookscheduledsyncs";
				public const string AllowUnresolvedPartiesOnEmailSend = "allowunresolvedpartiesonemailsend";
				public const string AllowUserFormModePreference = "allowuserformmodepreference";
				public const string AllowUsersSeeAppdownloadMessage = "allowusersseeappdownloadmessage";
				public const string AllowWebExcelExport = "allowwebexcelexport";
				public const string AMDesignator = "amdesignator";
				public const string AppDesignerExperienceEnabled = "appdesignerexperienceenabled";
				public const string AutoApplyDefaultonCaseCreate = "autoapplydefaultoncasecreate";
				public const string AutoApplyDefaultonCaseUpdate = "autoapplydefaultoncaseupdate";
				public const string AutoApplySLA = "autoapplysla";
				public const string AzureSchedulerJobCollectionName = "azureschedulerjobcollectionname";
				public const string BaseCurrencyId = "basecurrencyid";
				public const string BaseCurrencyPrecision = "basecurrencyprecision";
				public const string BaseCurrencySymbol = "basecurrencysymbol";
				public const string BingMapsApiKey = "bingmapsapikey";
				public const string BlockedAttachments = "blockedattachments";
				public const string BulkOperationPrefix = "bulkoperationprefix";
				public const string BusinessClosureCalendarId = "businessclosurecalendarid";
				public const string CalendarType = "calendartype";
				public const string CampaignPrefix = "campaignprefix";
				public const string CascadeStatusUpdate = "cascadestatusupdate";
				public const string CasePrefix = "caseprefix";
				public const string CategoryPrefix = "categoryprefix";
				public const string ContractPrefix = "contractprefix";
				public const string CortanaProactiveExperienceEnabled = "cortanaproactiveexperienceenabled";
				public const string CreatedBy = "createdby";
				public const string CreatedOn = "createdon";
				public const string CreatedOnBehalfBy = "createdonbehalfby";
				public const string CreateProductsWithoutParentInActiveState = "createproductswithoutparentinactivestate";
				public const string CurrencyDecimalPrecision = "currencydecimalprecision";
				public const string CurrencyDisplayOption = "currencydisplayoption";
				public const string CurrencyFormatCode = "currencyformatcode";
				public const string CurrencySymbol = "currencysymbol";
				public const string CurrentBulkOperationNumber = "currentbulkoperationnumber";
				public const string CurrentCampaignNumber = "currentcampaignnumber";
				public const string CurrentCaseNumber = "currentcasenumber";
				public const string CurrentCategoryNumber = "currentcategorynumber";
				public const string CurrentContractNumber = "currentcontractnumber";
				public const string CurrentImportSequenceNumber = "currentimportsequencenumber";
				public const string CurrentInvoiceNumber = "currentinvoicenumber";
				public const string CurrentKaNumber = "currentkanumber";
				public const string CurrentKbNumber = "currentkbnumber";
				public const string CurrentOrderNumber = "currentordernumber";
				public const string CurrentParsedTableNumber = "currentparsedtablenumber";
				public const string CurrentQuoteNumber = "currentquotenumber";
				public const string DateFormatCode = "dateformatcode";
				public const string DateFormatString = "dateformatstring";
				public const string DateSeparator = "dateseparator";
				public const string DaysSinceRecordLastModifiedMaxValue = "dayssincerecordlastmodifiedmaxvalue";
				public const string DecimalSymbol = "decimalsymbol";
				public const string DefaultCountryCode = "defaultcountrycode";
				public const string DefaultCrmCustomName = "defaultcrmcustomname";
				public const string DefaultEmailServerProfileId = "defaultemailserverprofileid";
				public const string DefaultEmailSettings = "defaultemailsettings";
				public const string DefaultMobileOfflineProfileId = "defaultmobileofflineprofileid";
				public const string DefaultRecurrenceEndRangeType = "defaultrecurrenceendrangetype";
				public const string DefaultThemeData = "defaultthemedata";
				public const string DelegatedAdminUserId = "delegatedadminuserid";
				public const string DisabledReason = "disabledreason";
				public const string DisableSocialCare = "disablesocialcare";
				public const string DiscountCalculationMethod = "discountcalculationmethod";
				public const string DisplayNavigationTour = "displaynavigationtour";
				public const string EmailConnectionChannel = "emailconnectionchannel";
				public const string EmailCorrelationEnabled = "emailcorrelationenabled";
				public const string EmailSendPollingPeriod = "emailsendpollingperiod";
				public const string EnableBingMapsIntegration = "enablebingmapsintegration";
				public const string EnableLPAuthoring = "enablelpauthoring";
				public const string EnableMicrosoftFlowIntegration = "enablemicrosoftflowintegration";
				public const string EnablePricingOnCreate = "enablepricingoncreate";
				public const string EnableSmartMatching = "enablesmartmatching";
				public const string EnforceReadOnlyPlugins = "enforcereadonlyplugins";
				public const string EntityImage = "entityimage";
				public const string EntityImage_Timestamp = "entityimage_timestamp";
				public const string EntityImage_URL = "entityimage_url";
				public const string EntityImageId = "entityimageid";
				public const string ExpireChangeTrackingInDays = "expirechangetrackingindays";
				public const string ExpireSubscriptionsInDays = "expiresubscriptionsindays";
				public const string ExternalBaseUrl = "externalbaseurl";
				public const string ExternalPartyCorrelationKeys = "externalpartycorrelationkeys";
				public const string ExternalPartyEntitySettings = "externalpartyentitysettings";
				public const string FeatureSet = "featureset";
				public const string FiscalCalendarStart = "fiscalcalendarstart";
				public const string FiscalPeriodFormat = "fiscalperiodformat";
				public const string FiscalPeriodFormatPeriod = "fiscalperiodformatperiod";
				public const string FiscalPeriodType = "fiscalperiodtype";
				public const string FiscalSettingsUpdated = "fiscalsettingsupdated";
				public const string FiscalYearDisplayCode = "fiscalyeardisplaycode";
				public const string FiscalYearFormat = "fiscalyearformat";
				public const string FiscalYearFormatPrefix = "fiscalyearformatprefix";
				public const string FiscalYearFormatSuffix = "fiscalyearformatsuffix";
				public const string FiscalYearFormatYear = "fiscalyearformatyear";
				public const string FiscalYearPeriodConnect = "fiscalyearperiodconnect";
				public const string FullNameConventionCode = "fullnameconventioncode";
				public const string FutureExpansionWindow = "futureexpansionwindow";
				public const string GenerateAlertsForErrors = "generatealertsforerrors";
				public const string GenerateAlertsForInformation = "generatealertsforinformation";
				public const string GenerateAlertsForWarnings = "generatealertsforwarnings";
				public const string GetStartedPaneContentEnabled = "getstartedpanecontentenabled";
				public const string GlobalAppendUrlParametersEnabled = "globalappendurlparametersenabled";
				public const string GlobalHelpUrl = "globalhelpurl";
				public const string GlobalHelpUrlEnabled = "globalhelpurlenabled";
				public const string GoalRollupExpiryTime = "goalrollupexpirytime";
				public const string GoalRollupFrequency = "goalrollupfrequency";
				public const string GrantAccessToNetworkService = "grantaccesstonetworkservice";
				public const string HashDeltaSubjectCount = "hashdeltasubjectcount";
				public const string HashFilterKeywords = "hashfilterkeywords";
				public const string HashMaxCount = "hashmaxcount";
				public const string HashMinAddressCount = "hashminaddresscount";
				public const string HighContrastThemeData = "highcontrastthemedata";
				public const string IgnoreInternalEmail = "ignoreinternalemail";
				public const string IncomingEmailExchangeEmailRetrievalBatchSize = "incomingemailexchangeemailretrievalbatchsize";
				public const string InitialVersion = "initialversion";
				public const string IntegrationUserId = "integrationuserid";
				public const string InvoicePrefix = "invoiceprefix";
				public const string IsActionCardEnabled = "isactioncardenabled";
				public const string IsActivityAnalysisEnabled = "isactivityanalysisenabled";
				public const string IsAppMode = "isappmode";
				public const string IsAppointmentAttachmentSyncEnabled = "isappointmentattachmentsyncenabled";
				public const string IsAssignedTasksSyncEnabled = "isassignedtaskssyncenabled";
				public const string IsAuditEnabled = "isauditenabled";
				public const string IsAutoDataCaptureEnabled = "isautodatacaptureenabled";
				public const string IsAutoSaveEnabled = "isautosaveenabled";
				public const string IsConflictDetectionEnabledForMobileClient = "isconflictdetectionenabledformobileclient";
				public const string IsContactMailingAddressSyncEnabled = "iscontactmailingaddresssyncenabled";
				public const string IsDefaultCountryCodeCheckEnabled = "isdefaultcountrycodecheckenabled";
				public const string IsDelegateAccessEnabled = "isdelegateaccessenabled";
				public const string IsDelveActionHubIntegrationEnabled = "isdelveactionhubintegrationenabled";
				public const string IsDisabled = "isdisabled";
				public const string IsDuplicateDetectionEnabled = "isduplicatedetectionenabled";
				public const string IsDuplicateDetectionEnabledForImport = "isduplicatedetectionenabledforimport";
				public const string IsDuplicateDetectionEnabledForOfflineSync = "isduplicatedetectionenabledforofflinesync";
				public const string IsDuplicateDetectionEnabledForOnlineCreateUpdate = "isduplicatedetectionenabledforonlinecreateupdate";
				public const string IsEmailMonitoringAllowed = "isemailmonitoringallowed";
				public const string IsEmailServerProfileContentFilteringEnabled = "isemailserverprofilecontentfilteringenabled";
				public const string IsEnabledForAllRoles = "isenabledforallroles";
				public const string IsExternalSearchIndexEnabled = "isexternalsearchindexenabled";
				public const string IsFiscalPeriodMonthBased = "isfiscalperiodmonthbased";
				public const string IsFolderAutoCreatedonSP = "isfolderautocreatedonsp";
				public const string IsFolderBasedTrackingEnabled = "isfolderbasedtrackingenabled";
				public const string IsFullTextSearchEnabled = "isfulltextsearchenabled";
				public const string IsHierarchicalSecurityModelEnabled = "ishierarchicalsecuritymodelenabled";
				public const string IsMailboxForcedUnlockingEnabled = "ismailboxforcedunlockingenabled";
				public const string IsMailboxInactiveBackoffEnabled = "ismailboxinactivebackoffenabled";
				public const string IsMobileClientOnDemandSyncEnabled = "ismobileclientondemandsyncenabled";
				public const string IsMobileOfflineEnabled = "ismobileofflineenabled";
				public const string IsOfficeGraphEnabled = "isofficegraphenabled";
				public const string IsOneDriveEnabled = "isonedriveenabled";
				public const string IsPresenceEnabled = "ispresenceenabled";
				public const string IsPreviewEnabledForActionCard = "ispreviewenabledforactioncard";
				public const string IsPreviewForAutoCaptureEnabled = "ispreviewforautocaptureenabled";
				public const string IsPreviewForEmailMonitoringAllowed = "ispreviewforemailmonitoringallowed";
				public const string IsRelationshipInsightsEnabled = "isrelationshipinsightsenabled";
				public const string IsResourceBookingExchangeSyncEnabled = "isresourcebookingexchangesyncenabled";
				public const string IsSOPIntegrationEnabled = "issopintegrationenabled";
				public const string IsUserAccessAuditEnabled = "isuseraccessauditenabled";
				public const string ISVIntegrationCode = "isvintegrationcode";
				public const string KaPrefix = "kaprefix";
				public const string KbPrefix = "kbprefix";
				public const string KMSettings = "kmsettings";
				public const string LanguageCode = "languagecode";
				public const string LocaleId = "localeid";
				public const string LongDateFormatCode = "longdateformatcode";
				public const string MailboxIntermittentIssueMinRange = "mailboxintermittentissueminrange";
				public const string MailboxPermanentIssueMinRange = "mailboxpermanentissueminrange";
				public const string MaxAppointmentDurationDays = "maxappointmentdurationdays";
				public const string MaxConditionsForMobileOfflineFilters = "maxconditionsformobileofflinefilters";
				public const string MaxDepthForHierarchicalSecurityModel = "maxdepthforhierarchicalsecuritymodel";
				public const string MaxFolderBasedTrackingMappings = "maxfolderbasedtrackingmappings";
				public const string MaximumActiveBusinessProcessFlowsAllowedPerEntity = "maximumactivebusinessprocessflowsallowedperentity";
				public const string MaximumDynamicPropertiesAllowed = "maximumdynamicpropertiesallowed";
				public const string MaximumEntitiesWithActiveSLA = "maximumentitieswithactivesla";
				public const string MaximumSLAKPIPerEntityWithActiveSLA = "maximumslakpiperentitywithactivesla";
				public const string MaximumTrackingNumber = "maximumtrackingnumber";
				public const string MaxProductsInBundle = "maxproductsinbundle";
				public const string MaxRecordsForExportToExcel = "maxrecordsforexporttoexcel";
				public const string MaxRecordsForLookupFilters = "maxrecordsforlookupfilters";
				public const string MaxSupportedInternetExplorerVersion = "maxsupportedinternetexplorerversion";
				public const string MaxUploadFileSize = "maxuploadfilesize";
				public const string MaxVerboseLoggingMailbox = "maxverboseloggingmailbox";
				public const string MaxVerboseLoggingSyncCycles = "maxverboseloggingsynccycles";
				public const string MinAddressBookSyncInterval = "minaddressbooksyncinterval";
				public const string MinOfflineSyncInterval = "minofflinesyncinterval";
				public const string MinOutlookSyncInterval = "minoutlooksyncinterval";
				public const string MobileOfflineMinLicenseProd = "mobileofflineminlicenseprod";
				public const string MobileOfflineMinLicenseTrial = "mobileofflineminlicensetrial";
				public const string MobileOfflineSyncInterval = "mobileofflinesyncinterval";
				public const string ModifiedBy = "modifiedby";
				public const string ModifiedOn = "modifiedon";
				public const string ModifiedOnBehalfBy = "modifiedonbehalfby";
				public const string Name = "name";
				public const string NegativeCurrencyFormatCode = "negativecurrencyformatcode";
				public const string NegativeFormatCode = "negativeformatcode";
				public const string NextTrackingNumber = "nexttrackingnumber";
				public const string NotifyMailboxOwnerOfEmailServerLevelAlerts = "notifymailboxownerofemailserverlevelalerts";
				public const string NumberFormat = "numberformat";
				public const string NumberGroupFormat = "numbergroupformat";
				public const string NumberSeparator = "numberseparator";
				public const string OfficeAppsAutoDeploymentEnabled = "officeappsautodeploymentenabled";
				public const string OfficeGraphDelveUrl = "officegraphdelveurl";
				public const string OOBPriceCalculationEnabled = "oobpricecalculationenabled";
				public const string OrderPrefix = "orderprefix";
				public const string OrganizationId = "organizationid";
				public const string Id = "organizationid";
				public const string OrgDbOrgSettings = "orgdborgsettings";
				public const string OrgInsightsEnabled = "orginsightsenabled";
				public const string ParsedTableColumnPrefix = "parsedtablecolumnprefix";
				public const string ParsedTablePrefix = "parsedtableprefix";
				public const string PastExpansionWindow = "pastexpansionwindow";
				public const string Picture = "picture";
				public const string PinpointLanguageCode = "pinpointlanguagecode";
				public const string PluginTraceLogSetting = "plugintracelogsetting";
				public const string PMDesignator = "pmdesignator";
				public const string PostMessageWhitelistDomains = "postmessagewhitelistdomains";
				public const string PowerBiFeatureEnabled = "powerbifeatureenabled";
				public const string PricingDecimalPrecision = "pricingdecimalprecision";
				public const string PrivacyStatementUrl = "privacystatementurl";
				public const string PrivilegeUserGroupId = "privilegeusergroupid";
				public const string PrivReportingGroupId = "privreportinggroupid";
				public const string PrivReportingGroupName = "privreportinggroupname";
				public const string ProductRecommendationsEnabled = "productrecommendationsenabled";
				public const string QuickFindRecordLimitEnabled = "quickfindrecordlimitenabled";
				public const string QuotePrefix = "quoteprefix";
				public const string RecurrenceDefaultNumberOfOccurrences = "recurrencedefaultnumberofoccurrences";
				public const string RecurrenceExpansionJobBatchInterval = "recurrenceexpansionjobbatchinterval";
				public const string RecurrenceExpansionJobBatchSize = "recurrenceexpansionjobbatchsize";
				public const string RecurrenceExpansionSynchCreateMax = "recurrenceexpansionsynchcreatemax";
				public const string ReferenceSiteMapXml = "referencesitemapxml";
				public const string RenderSecureIFrameForEmail = "rendersecureiframeforemail";
				public const string ReportingGroupId = "reportinggroupid";
				public const string ReportingGroupName = "reportinggroupname";
				public const string ReportScriptErrors = "reportscripterrors";
				public const string RequireApprovalForQueueEmail = "requireapprovalforqueueemail";
				public const string RequireApprovalForUserEmail = "requireapprovalforuseremail";
				public const string RestrictStatusUpdate = "restrictstatusupdate";
				public const string RiErrorStatus = "rierrorstatus";
				public const string SampleDataImportId = "sampledataimportid";
				public const string SchemaNamePrefix = "schemanameprefix";
				public const string SharePointDeploymentType = "sharepointdeploymenttype";
				public const string ShareToPreviousOwnerOnAssign = "sharetopreviousowneronassign";
				public const string ShowKBArticleDeprecationNotification = "showkbarticledeprecationnotification";
				public const string ShowWeekNumber = "showweeknumber";
				public const string SignupOutlookDownloadFWLink = "signupoutlookdownloadfwlink";
				public const string SiteMapXml = "sitemapxml";
				public const string SlaPauseStates = "slapausestates";
				public const string SocialInsightsEnabled = "socialinsightsenabled";
				public const string SocialInsightsInstance = "socialinsightsinstance";
				public const string SocialInsightsTermsAccepted = "socialinsightstermsaccepted";
				public const string SortId = "sortid";
				public const string SqlAccessGroupId = "sqlaccessgroupid";
				public const string SqlAccessGroupName = "sqlaccessgroupname";
				public const string SQMEnabled = "sqmenabled";
				public const string SupportUserId = "supportuserid";
				public const string SuppressSLA = "suppresssla";
				public const string SystemUserId = "systemuserid";
				public const string TagMaxAggressiveCycles = "tagmaxaggressivecycles";
				public const string TagPollingPeriod = "tagpollingperiod";
				public const string TaskBasedFlowEnabled = "taskbasedflowenabled";
				public const string TextAnalyticsEnabled = "textanalyticsenabled";
				public const string TimeFormatCode = "timeformatcode";
				public const string TimeFormatString = "timeformatstring";
				public const string TimeSeparator = "timeseparator";
				public const string TimeZoneRuleVersionNumber = "timezoneruleversionnumber";
				public const string TokenExpiry = "tokenexpiry";
				public const string TokenKey = "tokenkey";
				public const string TrackingPrefix = "trackingprefix";
				public const string TrackingTokenIdBase = "trackingtokenidbase";
				public const string TrackingTokenIdDigits = "trackingtokeniddigits";
				public const string UniqueSpecifierLength = "uniquespecifierlength";
				public const string UnresolveEmailAddressIfMultipleMatch = "unresolveemailaddressifmultiplematch";
				public const string UseInbuiltRuleForDefaultPricelistSelection = "useinbuiltrulefordefaultpricelistselection";
				public const string UseLegacyRendering = "uselegacyrendering";
				public const string UsePositionHierarchy = "usepositionhierarchy";
				public const string UserAccessAuditingInterval = "useraccessauditinginterval";
				public const string UseReadForm = "usereadform";
				public const string UserGroupId = "usergroupid";
				public const string UseSkypeProtocol = "useskypeprotocol";
				public const string UTCConversionTimeZoneCode = "utcconversiontimezonecode";
				public const string V3CalloutConfigHash = "v3calloutconfighash";
				public const string VersionNumber = "versionnumber";
				public const string WebResourceHash = "webresourcehash";
				public const string WeekStartDayCode = "weekstartdaycode";
				public const string WidgetProperties = "widgetproperties";
				public const string YammerGroupId = "yammergroupid";
				public const string YammerNetworkPermalink = "yammernetworkpermalink";
				public const string YammerOAuthAccessTokenExpired = "yammeroauthaccesstokenexpired";
				public const string YammerPostMethod = "yammerpostmethod";
				public const string YearStartWeekCode = "yearstartweekcode";
			}

			/// <summary>
			/// Default Constructor.
			/// </summary>
			public Organization() :
					base(EntityLogicalName) {
			}

			public const string EntityLogicalName = "organization";

			public const string PrimaryIdAttribute = "organizationid";

			public const string PrimaryNameAttribute = "name";

			public const int EntityTypeCode = 1019;

			/// <summary>
			/// ACI Web Endpoint URL.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("aciwebendpointurl")]
			public string ACIWebEndpointUrl {
				get {
					return this.GetAttributeValue<string>("aciwebendpointurl");
				}
				set {
					this.SetAttributeValue<string>("ACIWebEndpointUrl", "aciwebendpointurl", value);
				}
			}

			/// <summary>
			/// Unique identifier of the template to be used for acknowledgement when a user unsubscribes.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("acknowledgementtemplateid")]
			public Microsoft.Xrm.Client.CrmEntityReference AcknowledgementTemplateId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("acknowledgementtemplateid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("AcknowledgementTemplateId", "acknowledgementtemplateid", value);
				}
			}

			/// <summary>
			/// Indicates whether background address book synchronization in Microsoft Office Outlook is allowed.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("allowaddressbooksyncs")]
			public System.Nullable<bool> AllowAddressBookSyncs {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("allowaddressbooksyncs");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("AllowAddressBookSyncs", "allowaddressbooksyncs", value);
				}
			}

			/// <summary>
			/// Indicates whether automatic response creation is allowed.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("allowautoresponsecreation")]
			public System.Nullable<bool> AllowAutoResponseCreation {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("allowautoresponsecreation");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("AllowAutoResponseCreation", "allowautoresponsecreation", value);
				}
			}

			/// <summary>
			/// Indicates whether automatic unsubscribe is allowed.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("allowautounsubscribe")]
			public System.Nullable<bool> AllowAutoUnsubscribe {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("allowautounsubscribe");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("AllowAutoUnsubscribe", "allowautounsubscribe", value);
				}
			}

			/// <summary>
			/// Indicates whether automatic unsubscribe acknowledgement email is allowed to send.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("allowautounsubscribeacknowledgement")]
			public System.Nullable<bool> AllowAutoUnsubscribeAcknowledgement {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("allowautounsubscribeacknowledgement");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("AllowAutoUnsubscribeAcknowledgement", "allowautounsubscribeacknowledgement", value);
				}
			}

			/// <summary>
			/// Indicates whether Outlook Client message bar advertisement is allowed.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("allowclientmessagebarad")]
			public System.Nullable<bool> AllowClientMessageBarAd {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("allowclientmessagebarad");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("AllowClientMessageBarAd", "allowclientmessagebarad", value);
				}
			}

			/// <summary>
			/// Indicates whether auditing of changes to entity is allowed when no attributes have changed.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("allowentityonlyaudit")]
			public System.Nullable<bool> AllowEntityOnlyAudit {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("allowentityonlyaudit");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("AllowEntityOnlyAudit", "allowentityonlyaudit", value);
				}
			}

			/// <summary>
			/// Indicates whether marketing emails execution is allowed.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("allowmarketingemailexecution")]
			public System.Nullable<bool> AllowMarketingEmailExecution {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("allowmarketingemailexecution");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("AllowMarketingEmailExecution", "allowmarketingemailexecution", value);
				}
			}

			/// <summary>
			/// Indicates whether background offline synchronization in Microsoft Office Outlook is allowed.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("allowofflinescheduledsyncs")]
			public System.Nullable<bool> AllowOfflineScheduledSyncs {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("allowofflinescheduledsyncs");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("AllowOfflineScheduledSyncs", "allowofflinescheduledsyncs", value);
				}
			}

			/// <summary>
			/// Indicates whether scheduled synchronizations to Outlook are allowed.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("allowoutlookscheduledsyncs")]
			public System.Nullable<bool> AllowOutlookScheduledSyncs {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("allowoutlookscheduledsyncs");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("AllowOutlookScheduledSyncs", "allowoutlookscheduledsyncs", value);
				}
			}

			/// <summary>
			/// Indicates whether users are allowed to send email to unresolved parties (parties must still have an email address).
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("allowunresolvedpartiesonemailsend")]
			public System.Nullable<bool> AllowUnresolvedPartiesOnEmailSend {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("allowunresolvedpartiesonemailsend");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("AllowUnresolvedPartiesOnEmailSend", "allowunresolvedpartiesonemailsend", value);
				}
			}

			/// <summary>
			/// Indicates whether individuals can select their form mode preference in their personal options.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("allowuserformmodepreference")]
			public System.Nullable<bool> AllowUserFormModePreference {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("allowuserformmodepreference");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("AllowUserFormModePreference", "allowuserformmodepreference", value);
				}
			}

			/// <summary>
			/// Indicates whether the showing tablet application notification bars in a browser is allowed.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("allowusersseeappdownloadmessage")]
			public System.Nullable<bool> AllowUsersSeeAppdownloadMessage {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("allowusersseeappdownloadmessage");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("AllowUsersSeeAppdownloadMessage", "allowusersseeappdownloadmessage", value);
				}
			}

			/// <summary>
			/// Indicates whether Web-based export of grids to Microsoft Office Excel is allowed.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("allowwebexcelexport")]
			public System.Nullable<bool> AllowWebExcelExport {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("allowwebexcelexport");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("AllowWebExcelExport", "allowwebexcelexport", value);
				}
			}

			/// <summary>
			/// AM designator to use throughout Microsoft Dynamics CRM.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("amdesignator")]
			public string AMDesignator {
				get {
					return this.GetAttributeValue<string>("amdesignator");
				}
				set {
					this.SetAttributeValue<string>("AMDesignator", "amdesignator", value);
				}
			}

			/// <summary>
			/// Indicates whether the appDesignerExperience is enabled for the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("appdesignerexperienceenabled")]
			public System.Nullable<bool> AppDesignerExperienceEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("appdesignerexperienceenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("AppDesignerExperienceEnabled", "appdesignerexperienceenabled", value);
				}
			}

			/// <summary>
			/// Select whether to auto apply the default customer entitlement on case creation.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("autoapplydefaultoncasecreate")]
			public System.Nullable<bool> AutoApplyDefaultonCaseCreate {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("autoapplydefaultoncasecreate");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("AutoApplyDefaultonCaseCreate", "autoapplydefaultoncasecreate", value);
				}
			}

			/// <summary>
			/// Select whether to auto apply the default customer entitlement on case update.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("autoapplydefaultoncaseupdate")]
			public System.Nullable<bool> AutoApplyDefaultonCaseUpdate {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("autoapplydefaultoncaseupdate");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("AutoApplyDefaultonCaseUpdate", "autoapplydefaultoncaseupdate", value);
				}
			}

			/// <summary>
			/// Indicates whether to Auto-apply SLA on case record update after SLA was manually applied.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("autoapplysla")]
			public System.Nullable<bool> AutoApplySLA {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("autoapplysla");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("AutoApplySLA", "autoapplysla", value);
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("azureschedulerjobcollectionname")]
			public string AzureSchedulerJobCollectionName {
				get {
					return this.GetAttributeValue<string>("azureschedulerjobcollectionname");
				}
				set {
					this.SetAttributeValue<string>("AzureSchedulerJobCollectionName", "azureschedulerjobcollectionname", value);
				}
			}

			/// <summary>
			/// Unique identifier of the base currency of the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("basecurrencyid")]
			public Microsoft.Xrm.Client.CrmEntityReference BaseCurrencyId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("basecurrencyid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("BaseCurrencyId", "basecurrencyid", value);
				}
			}

			/// <summary>
			/// Number of decimal places that can be used for the base currency.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("basecurrencyprecision")]
			public System.Nullable<int> BaseCurrencyPrecision {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("basecurrencyprecision");
				}
			}

			/// <summary>
			/// Symbol used for the base currency.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("basecurrencysymbol")]
			public string BaseCurrencySymbol {
				get {
					return this.GetAttributeValue<string>("basecurrencysymbol");
				}
			}

			/// <summary>
			/// Api Key to be used in requests to Bing Maps services.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("bingmapsapikey")]
			public string BingMapsApiKey {
				get {
					return this.GetAttributeValue<string>("bingmapsapikey");
				}
				set {
					this.SetAttributeValue<string>("BingMapsApiKey", "bingmapsapikey", value);
				}
			}

			/// <summary>
			/// Prevent upload or download of certain attachment types that are considered dangerous.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("blockedattachments")]
			public string BlockedAttachments {
				get {
					return this.GetAttributeValue<string>("blockedattachments");
				}
				set {
					this.SetAttributeValue<string>("BlockedAttachments", "blockedattachments", value);
				}
			}

			/// <summary>
			/// Prefix used for bulk operation numbering.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("bulkoperationprefix")]
			public string BulkOperationPrefix {
				get {
					return this.GetAttributeValue<string>("bulkoperationprefix");
				}
				set {
					this.SetAttributeValue<string>("BulkOperationPrefix", "bulkoperationprefix", value);
				}
			}

			/// <summary>
			/// Unique identifier of the business closure calendar of organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("businessclosurecalendarid")]
			public System.Nullable<System.Guid> BusinessClosureCalendarId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("businessclosurecalendarid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("BusinessClosureCalendarId", "businessclosurecalendarid", value);
				}
			}

			/// <summary>
			/// Calendar type for the system. Set to Gregorian US by default.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("calendartype")]
			public System.Nullable<int> CalendarType {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("calendartype");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("CalendarType", "calendartype", value);
				}
			}

			/// <summary>
			/// Prefix used for campaign numbering.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("campaignprefix")]
			public string CampaignPrefix {
				get {
					return this.GetAttributeValue<string>("campaignprefix");
				}
				set {
					this.SetAttributeValue<string>("CampaignPrefix", "campaignprefix", value);
				}
			}

			/// <summary>
			/// Flag to cascade Update on incident.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("cascadestatusupdate")]
			public System.Nullable<bool> CascadeStatusUpdate {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("cascadestatusupdate");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("CascadeStatusUpdate", "cascadestatusupdate", value);
				}
			}

			/// <summary>
			/// Prefix to use for all cases throughout Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("caseprefix")]
			public string CasePrefix {
				get {
					return this.GetAttributeValue<string>("caseprefix");
				}
				set {
					this.SetAttributeValue<string>("CasePrefix", "caseprefix", value);
				}
			}

			/// <summary>
			/// Type the prefix to use for all categories in Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("categoryprefix")]
			public string CategoryPrefix {
				get {
					return this.GetAttributeValue<string>("categoryprefix");
				}
				set {
					this.SetAttributeValue<string>("CategoryPrefix", "categoryprefix", value);
				}
			}

			/// <summary>
			/// Prefix to use for all contracts throughout Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contractprefix")]
			public string ContractPrefix {
				get {
					return this.GetAttributeValue<string>("contractprefix");
				}
				set {
					this.SetAttributeValue<string>("ContractPrefix", "contractprefix", value);
				}
			}

			/// <summary>
			/// Indicates whether the feature CortanaProactiveExperience Flow processes should be enabled for the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("cortanaproactiveexperienceenabled")]
			public System.Nullable<bool> CortanaProactiveExperienceEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("cortanaproactiveexperienceenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("CortanaProactiveExperienceEnabled", "cortanaproactiveexperienceenabled", value);
				}
			}

			/// <summary>
			/// Unique identifier of the user who created the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
			public Microsoft.Xrm.Client.CrmEntityReference CreatedBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
				}
			}

			/// <summary>
			/// Date and time when the organization was created.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
			public System.Nullable<System.DateTime> CreatedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
				}
			}

			/// <summary>
			/// Unique identifier of the delegate user who created the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
			public Microsoft.Xrm.Client.CrmEntityReference CreatedOnBehalfBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("CreatedOnBehalfBy", "createdonbehalfby", value);
				}
			}

			/// <summary>
			/// Enable Initial state of newly created products to be Active instead of Draft
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createproductswithoutparentinactivestate")]
			public System.Nullable<bool> CreateProductsWithoutParentInActiveState {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("createproductswithoutparentinactivestate");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("CreateProductsWithoutParentInActiveState", "createproductswithoutparentinactivestate", value);
				}
			}

			/// <summary>
			/// Number of decimal places that can be used for currency.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("currencydecimalprecision")]
			public System.Nullable<int> CurrencyDecimalPrecision {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("currencydecimalprecision");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("CurrencyDecimalPrecision", "currencydecimalprecision", value);
				}
			}

			/// <summary>
			/// Indicates whether to display money fields with currency code or currency symbol.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("currencydisplayoption")]
			public System.Nullable<int> CurrencyDisplayOption {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("currencydisplayoption");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("CurrencyDisplayOption", "currencydisplayoption", value);
				}
			}

			/// <summary>
			/// Information about how currency symbols are placed throughout Microsoft Dynamics CRM.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("currencyformatcode")]
			public System.Nullable<int> CurrencyFormatCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("currencyformatcode");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("CurrencyFormatCode", "currencyformatcode", value);
				}
			}

			/// <summary>
			/// Symbol used for currency throughout Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("currencysymbol")]
			public string CurrencySymbol {
				get {
					return this.GetAttributeValue<string>("currencysymbol");
				}
				set {
					this.SetAttributeValue<string>("CurrencySymbol", "currencysymbol", value);
				}
			}

			/// <summary>
			/// Current bulk operation number.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("currentbulkoperationnumber")]
			public System.Nullable<int> CurrentBulkOperationNumber {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("currentbulkoperationnumber");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("CurrentBulkOperationNumber", "currentbulkoperationnumber", value);
				}
			}

			/// <summary>
			/// Current campaign number.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("currentcampaignnumber")]
			public System.Nullable<int> CurrentCampaignNumber {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("currentcampaignnumber");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("CurrentCampaignNumber", "currentcampaignnumber", value);
				}
			}

			/// <summary>
			/// First case number to use.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("currentcasenumber")]
			public System.Nullable<int> CurrentCaseNumber {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("currentcasenumber");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("CurrentCaseNumber", "currentcasenumber", value);
				}
			}

			/// <summary>
			/// Enter the first number to use for Categories.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("currentcategorynumber")]
			public System.Nullable<int> CurrentCategoryNumber {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("currentcategorynumber");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("CurrentCategoryNumber", "currentcategorynumber", value);
				}
			}

			/// <summary>
			/// First contract number to use.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("currentcontractnumber")]
			public System.Nullable<int> CurrentContractNumber {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("currentcontractnumber");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("CurrentContractNumber", "currentcontractnumber", value);
				}
			}

			/// <summary>
			/// Import sequence to use.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("currentimportsequencenumber")]
			public System.Nullable<int> CurrentImportSequenceNumber {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("currentimportsequencenumber");
				}
			}

			/// <summary>
			/// First invoice number to use.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("currentinvoicenumber")]
			public System.Nullable<int> CurrentInvoiceNumber {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("currentinvoicenumber");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("CurrentInvoiceNumber", "currentinvoicenumber", value);
				}
			}

			/// <summary>
			/// Enter the first number to use for knowledge articles.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("currentkanumber")]
			public System.Nullable<int> CurrentKaNumber {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("currentkanumber");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("CurrentKaNumber", "currentkanumber", value);
				}
			}

			/// <summary>
			/// First article number to use.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("currentkbnumber")]
			public System.Nullable<int> CurrentKbNumber {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("currentkbnumber");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("CurrentKbNumber", "currentkbnumber", value);
				}
			}

			/// <summary>
			/// First order number to use.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("currentordernumber")]
			public System.Nullable<int> CurrentOrderNumber {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("currentordernumber");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("CurrentOrderNumber", "currentordernumber", value);
				}
			}

			/// <summary>
			/// First parsed table number to use.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("currentparsedtablenumber")]
			public System.Nullable<int> CurrentParsedTableNumber {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("currentparsedtablenumber");
				}
			}

			/// <summary>
			/// First quote number to use.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("currentquotenumber")]
			public System.Nullable<int> CurrentQuoteNumber {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("currentquotenumber");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("CurrentQuoteNumber", "currentquotenumber", value);
				}
			}

			/// <summary>
			/// Information about how the date is displayed throughout Microsoft CRM.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("dateformatcode")]
			public System.Nullable<int> DateFormatCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("dateformatcode");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("DateFormatCode", "dateformatcode", value);
				}
			}

			/// <summary>
			/// String showing how the date is displayed throughout Microsoft CRM.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("dateformatstring")]
			public string DateFormatString {
				get {
					return this.GetAttributeValue<string>("dateformatstring");
				}
				set {
					this.SetAttributeValue<string>("DateFormatString", "dateformatstring", value);
				}
			}

			/// <summary>
			/// Character used to separate the month, the day, and the year in dates throughout Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("dateseparator")]
			public string DateSeparator {
				get {
					return this.GetAttributeValue<string>("dateseparator");
				}
				set {
					this.SetAttributeValue<string>("DateSeparator", "dateseparator", value);
				}
			}

			/// <summary>
			/// The maximum value for the Mobile Offline setting Days since record last modified
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("dayssincerecordlastmodifiedmaxvalue")]
			public System.Nullable<int> DaysSinceRecordLastModifiedMaxValue {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("dayssincerecordlastmodifiedmaxvalue");
				}
			}

			/// <summary>
			/// Symbol used for decimal in Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("decimalsymbol")]
			public string DecimalSymbol {
				get {
					return this.GetAttributeValue<string>("decimalsymbol");
				}
				set {
					this.SetAttributeValue<string>("DecimalSymbol", "decimalsymbol", value);
				}
			}

			/// <summary>
			/// Text area to enter default country code.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("defaultcountrycode")]
			public string DefaultCountryCode {
				get {
					return this.GetAttributeValue<string>("defaultcountrycode");
				}
				set {
					this.SetAttributeValue<string>("DefaultCountryCode", "defaultcountrycode", value);
				}
			}

			/// <summary>
			/// Name of the default crm custom.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("defaultcrmcustomname")]
			public string DefaultCrmCustomName {
				get {
					return this.GetAttributeValue<string>("defaultcrmcustomname");
				}
				set {
					this.SetAttributeValue<string>("DefaultCrmCustomName", "defaultcrmcustomname", value);
				}
			}

			/// <summary>
			/// Unique identifier of the default email server profile.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("defaultemailserverprofileid")]
			public Microsoft.Xrm.Client.CrmEntityReference DefaultEmailServerProfileId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("defaultemailserverprofileid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("DefaultEmailServerProfileId", "defaultemailserverprofileid", value);
				}
			}

			/// <summary>
			/// XML string containing the default email settings that are applied when a user or queue is created.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("defaultemailsettings")]
			public string DefaultEmailSettings {
				get {
					return this.GetAttributeValue<string>("defaultemailsettings");
				}
				set {
					this.SetAttributeValue<string>("DefaultEmailSettings", "defaultemailsettings", value);
				}
			}

			/// <summary>
			/// Unique identifier of the default mobile offline profile.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("defaultmobileofflineprofileid")]
			public Microsoft.Xrm.Client.CrmEntityReference DefaultMobileOfflineProfileId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("defaultmobileofflineprofileid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("DefaultMobileOfflineProfileId", "defaultmobileofflineprofileid", value);
				}
			}

			/// <summary>
			/// Type of default recurrence end range date.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("defaultrecurrenceendrangetype")]
			public System.Nullable<int> DefaultRecurrenceEndRangeType {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("defaultrecurrenceendrangetype");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("DefaultRecurrenceEndRangeType", "defaultrecurrenceendrangetype", value);
				}
			}

			/// <summary>
			/// Default theme data for the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("defaultthemedata")]
			public string DefaultThemeData {
				get {
					return this.GetAttributeValue<string>("defaultthemedata");
				}
				set {
					this.SetAttributeValue<string>("DefaultThemeData", "defaultthemedata", value);
				}
			}

			/// <summary>
			/// Unique identifier of the delegated admin user for the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("delegatedadminuserid")]
			public System.Nullable<System.Guid> DelegatedAdminUserId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("delegatedadminuserid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("DelegatedAdminUserId", "delegatedadminuserid", value);
				}
			}

			/// <summary>
			/// Reason for disabling the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("disabledreason")]
			public string DisabledReason {
				get {
					return this.GetAttributeValue<string>("disabledreason");
				}
			}

			/// <summary>
			/// Indicates whether Social Care is disabled.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("disablesocialcare")]
			public System.Nullable<bool> DisableSocialCare {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("disablesocialcare");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("DisableSocialCare", "disablesocialcare", value);
				}
			}

			/// <summary>
			/// Discount calculation method for the QOOI product.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("discountcalculationmethod")]
			public System.Nullable<int> DiscountCalculationMethod {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("discountcalculationmethod");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("DiscountCalculationMethod", "discountcalculationmethod", value);
				}
			}

			/// <summary>
			/// Indicates whether or not navigation tour is displayed.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("displaynavigationtour")]
			public System.Nullable<bool> DisplayNavigationTour {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("displaynavigationtour");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("DisplayNavigationTour", "displaynavigationtour", value);
				}
			}

			/// <summary>
			/// Select if you want to use the Email Router or server-side synchronization for email processing.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("emailconnectionchannel")]
			public System.Nullable<int> EmailConnectionChannel {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("emailconnectionchannel");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("EmailConnectionChannel", "emailconnectionchannel", value);
				}
			}

			/// <summary>
			/// Flag to turn email correlation on or off.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("emailcorrelationenabled")]
			public System.Nullable<bool> EmailCorrelationEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("emailcorrelationenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("EmailCorrelationEnabled", "emailcorrelationenabled", value);
				}
			}

			/// <summary>
			/// Normal polling frequency used for sending email in Microsoft Office Outlook.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("emailsendpollingperiod")]
			public System.Nullable<int> EmailSendPollingPeriod {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("emailsendpollingperiod");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("EmailSendPollingPeriod", "emailsendpollingperiod", value);
				}
			}

			/// <summary>
			/// Enable Integration with Bing Maps
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("enablebingmapsintegration")]
			public System.Nullable<bool> EnableBingMapsIntegration {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("enablebingmapsintegration");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("EnableBingMapsIntegration", "enablebingmapsintegration", value);
				}
			}

			/// <summary>
			/// Select to enable learning path auhtoring.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("enablelpauthoring")]
			public System.Nullable<bool> EnableLPAuthoring {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("enablelpauthoring");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("EnableLPAuthoring", "enablelpauthoring", value);
				}
			}

			/// <summary>
			/// Enable Integration with Microsoft Flow
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("enablemicrosoftflowintegration")]
			public System.Nullable<bool> EnableMicrosoftFlowIntegration {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("enablemicrosoftflowintegration");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("EnableMicrosoftFlowIntegration", "enablemicrosoftflowintegration", value);
				}
			}

			/// <summary>
			/// Enable pricing calculations on a Create call.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("enablepricingoncreate")]
			public System.Nullable<bool> EnablePricingOnCreate {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("enablepricingoncreate");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("EnablePricingOnCreate", "enablepricingoncreate", value);
				}
			}

			/// <summary>
			/// Use Smart Matching.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("enablesmartmatching")]
			public System.Nullable<bool> EnableSmartMatching {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("enablesmartmatching");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("EnableSmartMatching", "enablesmartmatching", value);
				}
			}

			/// <summary>
			/// Organization setting to enforce read only plugins.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("enforcereadonlyplugins")]
			public System.Nullable<bool> EnforceReadOnlyPlugins {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("enforcereadonlyplugins");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("EnforceReadOnlyPlugins", "enforcereadonlyplugins", value);
				}
			}

			/// <summary>
			/// The default image for the entity.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityimage")]
			public byte[] EntityImage {
				get {
					return this.GetAttributeValue<byte[]>("entityimage");
				}
				set {
					this.SetAttributeValue<byte[]>("EntityImage", "entityimage", value);
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityimage_timestamp")]
			public System.Nullable<long> EntityImage_Timestamp {
				get {
					return this.GetAttributeValue<System.Nullable<long>>("entityimage_timestamp");
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityimage_url")]
			public string EntityImage_URL {
				get {
					return this.GetAttributeValue<string>("entityimage_url");
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityimageid")]
			public System.Nullable<System.Guid> EntityImageId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("entityimageid");
				}
			}

			/// <summary>
			/// Maximum number of days to keep change tracking deleted records
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("expirechangetrackingindays")]
			public System.Nullable<int> ExpireChangeTrackingInDays {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("expirechangetrackingindays");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("ExpireChangeTrackingInDays", "expirechangetrackingindays", value);
				}
			}

			/// <summary>
			/// Maximum number of days before deleting inactive subscriptions.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("expiresubscriptionsindays")]
			public System.Nullable<int> ExpireSubscriptionsInDays {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("expiresubscriptionsindays");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("ExpireSubscriptionsInDays", "expiresubscriptionsindays", value);
				}
			}

			/// <summary>
			/// Specify the base URL to use to look for external document suggestions.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("externalbaseurl")]
			public string ExternalBaseUrl {
				get {
					return this.GetAttributeValue<string>("externalbaseurl");
				}
				set {
					this.SetAttributeValue<string>("ExternalBaseUrl", "externalbaseurl", value);
				}
			}

			/// <summary>
			/// XML string containing the ExternalPartyEnabled entities correlation keys for association of existing External Party instance entities to newly created IsExternalPartyEnabled entities.For internal use only
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("externalpartycorrelationkeys")]
			public string ExternalPartyCorrelationKeys {
				get {
					return this.GetAttributeValue<string>("externalpartycorrelationkeys");
				}
				set {
					this.SetAttributeValue<string>("ExternalPartyCorrelationKeys", "externalpartycorrelationkeys", value);
				}
			}

			/// <summary>
			/// XML string containing the ExternalPartyEnabled entities settings.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("externalpartyentitysettings")]
			public string ExternalPartyEntitySettings {
				get {
					return this.GetAttributeValue<string>("externalpartyentitysettings");
				}
				set {
					this.SetAttributeValue<string>("ExternalPartyEntitySettings", "externalpartyentitysettings", value);
				}
			}

			/// <summary>
			/// Features to be enabled as an XML BLOB.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("featureset")]
			public string FeatureSet {
				get {
					return this.GetAttributeValue<string>("featureset");
				}
				set {
					this.SetAttributeValue<string>("FeatureSet", "featureset", value);
				}
			}

			/// <summary>
			/// Start date for the fiscal period that is to be used throughout Microsoft CRM.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("fiscalcalendarstart")]
			public System.Nullable<System.DateTime> FiscalCalendarStart {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("fiscalcalendarstart");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.DateTime>>("FiscalCalendarStart", "fiscalcalendarstart", value);
				}
			}

			/// <summary>
			/// Information that specifies how the name of the fiscal period is displayed throughout Microsoft CRM.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("fiscalperiodformat")]
			public string FiscalPeriodFormat {
				get {
					return this.GetAttributeValue<string>("fiscalperiodformat");
				}
				set {
					this.SetAttributeValue<string>("FiscalPeriodFormat", "fiscalperiodformat", value);
				}
			}

			/// <summary>
			/// Format in which the fiscal period will be displayed.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("fiscalperiodformatperiod")]
			public System.Nullable<int> FiscalPeriodFormatPeriod {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("fiscalperiodformatperiod");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("FiscalPeriodFormatPeriod", "fiscalperiodformatperiod", value);
				}
			}

			/// <summary>
			/// Type of fiscal period used throughout Microsoft CRM.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("fiscalperiodtype")]
			public System.Nullable<int> FiscalPeriodType {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("fiscalperiodtype");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("FiscalPeriodType", "fiscalperiodtype", value);
				}
			}

			/// <summary>
			/// Information that specifies whether the fiscal settings have been updated.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("fiscalsettingsupdated")]
			[System.ObsoleteAttribute()]
			public System.Nullable<bool> FiscalSettingsUpdated {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("fiscalsettingsupdated");
				}
			}

			/// <summary>
			/// Information that specifies whether the fiscal year should be displayed based on the start date or the end date of the fiscal year.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("fiscalyeardisplaycode")]
			public System.Nullable<int> FiscalYearDisplayCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("fiscalyeardisplaycode");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("FiscalYearDisplayCode", "fiscalyeardisplaycode", value);
				}
			}

			/// <summary>
			/// Information that specifies how the name of the fiscal year is displayed throughout Microsoft CRM.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("fiscalyearformat")]
			public string FiscalYearFormat {
				get {
					return this.GetAttributeValue<string>("fiscalyearformat");
				}
				set {
					this.SetAttributeValue<string>("FiscalYearFormat", "fiscalyearformat", value);
				}
			}

			/// <summary>
			/// Prefix for the display of the fiscal year.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("fiscalyearformatprefix")]
			public System.Nullable<int> FiscalYearFormatPrefix {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("fiscalyearformatprefix");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("FiscalYearFormatPrefix", "fiscalyearformatprefix", value);
				}
			}

			/// <summary>
			/// Suffix for the display of the fiscal year.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("fiscalyearformatsuffix")]
			public System.Nullable<int> FiscalYearFormatSuffix {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("fiscalyearformatsuffix");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("FiscalYearFormatSuffix", "fiscalyearformatsuffix", value);
				}
			}

			/// <summary>
			/// Format for the year.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("fiscalyearformatyear")]
			public System.Nullable<int> FiscalYearFormatYear {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("fiscalyearformatyear");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("FiscalYearFormatYear", "fiscalyearformatyear", value);
				}
			}

			/// <summary>
			/// Information that specifies how the names of the fiscal year and the fiscal period should be connected when displayed together.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("fiscalyearperiodconnect")]
			public string FiscalYearPeriodConnect {
				get {
					return this.GetAttributeValue<string>("fiscalyearperiodconnect");
				}
				set {
					this.SetAttributeValue<string>("FiscalYearPeriodConnect", "fiscalyearperiodconnect", value);
				}
			}

			/// <summary>
			/// Order in which names are to be displayed throughout Microsoft CRM.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("fullnameconventioncode")]
			public System.Nullable<int> FullNameConventionCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("fullnameconventioncode");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("FullNameConventionCode", "fullnameconventioncode", value);
				}
			}

			/// <summary>
			/// Specifies the maximum number of months in future for which the recurring activities can be created.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("futureexpansionwindow")]
			public System.Nullable<int> FutureExpansionWindow {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("futureexpansionwindow");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("FutureExpansionWindow", "futureexpansionwindow", value);
				}
			}

			/// <summary>
			/// Indicates whether alerts will be generated for errors.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("generatealertsforerrors")]
			public System.Nullable<bool> GenerateAlertsForErrors {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("generatealertsforerrors");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("GenerateAlertsForErrors", "generatealertsforerrors", value);
				}
			}

			/// <summary>
			/// Indicates whether alerts will be generated for information.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("generatealertsforinformation")]
			public System.Nullable<bool> GenerateAlertsForInformation {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("generatealertsforinformation");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("GenerateAlertsForInformation", "generatealertsforinformation", value);
				}
			}

			/// <summary>
			/// Indicates whether alerts will be generated for warnings.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("generatealertsforwarnings")]
			public System.Nullable<bool> GenerateAlertsForWarnings {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("generatealertsforwarnings");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("GenerateAlertsForWarnings", "generatealertsforwarnings", value);
				}
			}

			/// <summary>
			/// Indicates whether Get Started content is enabled for this organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("getstartedpanecontentenabled")]
			public System.Nullable<bool> GetStartedPaneContentEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("getstartedpanecontentenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("GetStartedPaneContentEnabled", "getstartedpanecontentenabled", value);
				}
			}

			/// <summary>
			/// Indicates whether the append URL parameters is enabled.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("globalappendurlparametersenabled")]
			public System.Nullable<bool> GlobalAppendUrlParametersEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("globalappendurlparametersenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("GlobalAppendUrlParametersEnabled", "globalappendurlparametersenabled", value);
				}
			}

			/// <summary>
			/// URL for the web page global help.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("globalhelpurl")]
			public string GlobalHelpUrl {
				get {
					return this.GetAttributeValue<string>("globalhelpurl");
				}
				set {
					this.SetAttributeValue<string>("GlobalHelpUrl", "globalhelpurl", value);
				}
			}

			/// <summary>
			/// Indicates whether the customizable global help is enabled.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("globalhelpurlenabled")]
			public System.Nullable<bool> GlobalHelpUrlEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("globalhelpurlenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("GlobalHelpUrlEnabled", "globalhelpurlenabled", value);
				}
			}

			/// <summary>
			/// Number of days after the goal's end date after which the rollup of the goal stops automatically.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("goalrollupexpirytime")]
			public System.Nullable<int> GoalRollupExpiryTime {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("goalrollupexpirytime");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("GoalRollupExpiryTime", "goalrollupexpirytime", value);
				}
			}

			/// <summary>
			/// Number of hours between automatic rollup jobs .
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("goalrollupfrequency")]
			public System.Nullable<int> GoalRollupFrequency {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("goalrollupfrequency");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("GoalRollupFrequency", "goalrollupfrequency", value);
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("grantaccesstonetworkservice")]
			public System.Nullable<bool> GrantAccessToNetworkService {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("grantaccesstonetworkservice");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("GrantAccessToNetworkService", "grantaccesstonetworkservice", value);
				}
			}

			/// <summary>
			/// Maximum difference allowed between subject keywords count of the email messaged to be correlated
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("hashdeltasubjectcount")]
			public System.Nullable<int> HashDeltaSubjectCount {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("hashdeltasubjectcount");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("HashDeltaSubjectCount", "hashdeltasubjectcount", value);
				}
			}

			/// <summary>
			/// Filter Subject Keywords
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("hashfilterkeywords")]
			public string HashFilterKeywords {
				get {
					return this.GetAttributeValue<string>("hashfilterkeywords");
				}
				set {
					this.SetAttributeValue<string>("HashFilterKeywords", "hashfilterkeywords", value);
				}
			}

			/// <summary>
			/// Maximum number of subject keywords or recipients used for correlation
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("hashmaxcount")]
			public System.Nullable<int> HashMaxCount {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("hashmaxcount");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("HashMaxCount", "hashmaxcount", value);
				}
			}

			/// <summary>
			/// Minimum number of recipients required to match for email messaged to be correlated
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("hashminaddresscount")]
			public System.Nullable<int> HashMinAddressCount {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("hashminaddresscount");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("HashMinAddressCount", "hashminaddresscount", value);
				}
			}

			/// <summary>
			/// High contrast theme data for the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("highcontrastthemedata")]
			public string HighContrastThemeData {
				get {
					return this.GetAttributeValue<string>("highcontrastthemedata");
				}
				set {
					this.SetAttributeValue<string>("HighContrastThemeData", "highcontrastthemedata", value);
				}
			}

			/// <summary>
			/// Indicates whether incoming email sent by internal Microsoft Dynamics 365 users or queues should be tracked.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ignoreinternalemail")]
			public System.Nullable<bool> IgnoreInternalEmail {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("ignoreinternalemail");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IgnoreInternalEmail", "ignoreinternalemail", value);
				}
			}

			/// <summary>
			/// Setting for the Async Service Mailbox Queue. Defines the retrieval batch size of exchange server.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("incomingemailexchangeemailretrievalbatchsize")]
			public System.Nullable<int> IncomingEmailExchangeEmailRetrievalBatchSize {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("incomingemailexchangeemailretrievalbatchsize");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("IncomingEmailExchangeEmailRetrievalBatchSize", "incomingemailexchangeemailretrievalbatchsize", value);
				}
			}

			/// <summary>
			/// Initial version of the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("initialversion")]
			public string InitialVersion {
				get {
					return this.GetAttributeValue<string>("initialversion");
				}
				set {
					this.SetAttributeValue<string>("InitialVersion", "initialversion", value);
				}
			}

			/// <summary>
			/// Unique identifier of the integration user for the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("integrationuserid")]
			public System.Nullable<System.Guid> IntegrationUserId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("integrationuserid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("IntegrationUserId", "integrationuserid", value);
				}
			}

			/// <summary>
			/// Prefix to use for all invoice numbers throughout Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("invoiceprefix")]
			public string InvoicePrefix {
				get {
					return this.GetAttributeValue<string>("invoiceprefix");
				}
				set {
					this.SetAttributeValue<string>("InvoicePrefix", "invoiceprefix", value);
				}
			}

			/// <summary>
			/// Indicates whether the feature Action Card should be enabled for the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isactioncardenabled")]
			public System.Nullable<bool> IsActionCardEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isactioncardenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsActionCardEnabled", "isactioncardenabled", value);
				}
			}

			/// <summary>
			/// Indicates whether the feature Relationship Analytics should be enabled for the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isactivityanalysisenabled")]
			public System.Nullable<bool> IsActivityAnalysisEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isactivityanalysisenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsActivityAnalysisEnabled", "isactivityanalysisenabled", value);
				}
			}

			/// <summary>
			/// Indicates whether loading of Microsoft Dynamics 365 in a browser window that does not have address, tool, and menu bars is enabled.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isappmode")]
			public System.Nullable<bool> IsAppMode {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isappmode");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsAppMode", "isappmode", value);
				}
			}

			/// <summary>
			/// Enable or disable attachments sync for outlook and exchange.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isappointmentattachmentsyncenabled")]
			public System.Nullable<bool> IsAppointmentAttachmentSyncEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isappointmentattachmentsyncenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsAppointmentAttachmentSyncEnabled", "isappointmentattachmentsyncenabled", value);
				}
			}

			/// <summary>
			/// Enable or disable assigned tasks sync for outlook and exchange.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isassignedtaskssyncenabled")]
			public System.Nullable<bool> IsAssignedTasksSyncEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isassignedtaskssyncenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsAssignedTasksSyncEnabled", "isassignedtaskssyncenabled", value);
				}
			}

			/// <summary>
			/// Enable or disable auditing of changes.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isauditenabled")]
			public System.Nullable<bool> IsAuditEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isauditenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsAuditEnabled", "isauditenabled", value);
				}
			}

			/// <summary>
			/// Indicates whether the feature Auto Capture should be enabled for the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isautodatacaptureenabled")]
			public System.Nullable<bool> IsAutoDataCaptureEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isautodatacaptureenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsAutoDataCaptureEnabled", "isautodatacaptureenabled", value);
				}
			}

			/// <summary>
			/// Information on whether auto save is enabled.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isautosaveenabled")]
			public System.Nullable<bool> IsAutoSaveEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isautosaveenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsAutoSaveEnabled", "isautosaveenabled", value);
				}
			}

			/// <summary>
			/// Information that specifies whether conflict detection for mobile client is enabled.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isconflictdetectionenabledformobileclient")]
			public System.Nullable<bool> IsConflictDetectionEnabledForMobileClient {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isconflictdetectionenabledformobileclient");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsConflictDetectionEnabledForMobileClient", "isconflictdetectionenabledformobileclient", value);
				}
			}

			/// <summary>
			/// Enable or disable mailing address sync for outlook and exchange.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("iscontactmailingaddresssyncenabled")]
			public System.Nullable<bool> IsContactMailingAddressSyncEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("iscontactmailingaddresssyncenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsContactMailingAddressSyncEnabled", "iscontactmailingaddresssyncenabled", value);
				}
			}

			/// <summary>
			/// Enable or disable country code selection.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isdefaultcountrycodecheckenabled")]
			public System.Nullable<bool> IsDefaultCountryCodeCheckEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isdefaultcountrycodecheckenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsDefaultCountryCodeCheckEnabled", "isdefaultcountrycodecheckenabled", value);
				}
			}

			/// <summary>
			/// Enable Delegation Access content
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isdelegateaccessenabled")]
			public System.Nullable<bool> IsDelegateAccessEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isdelegateaccessenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsDelegateAccessEnabled", "isdelegateaccessenabled", value);
				}
			}

			/// <summary>
			/// Indicates whether the feature Action Hub should be enabled for the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isdelveactionhubintegrationenabled")]
			public System.Nullable<bool> IsDelveActionHubIntegrationEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isdelveactionhubintegrationenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsDelveActionHubIntegrationEnabled", "isdelveactionhubintegrationenabled", value);
				}
			}

			/// <summary>
			/// Information that specifies whether the organization is disabled.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isdisabled")]
			public System.Nullable<bool> IsDisabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isdisabled");
				}
			}

			/// <summary>
			/// Indicates whether duplicate detection of records is enabled.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isduplicatedetectionenabled")]
			public System.Nullable<bool> IsDuplicateDetectionEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isduplicatedetectionenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsDuplicateDetectionEnabled", "isduplicatedetectionenabled", value);
				}
			}

			/// <summary>
			/// Indicates whether duplicate detection of records during import is enabled.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isduplicatedetectionenabledforimport")]
			public System.Nullable<bool> IsDuplicateDetectionEnabledForImport {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isduplicatedetectionenabledforimport");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsDuplicateDetectionEnabledForImport", "isduplicatedetectionenabledforimport", value);
				}
			}

			/// <summary>
			/// Indicates whether duplicate detection of records during offline synchronization is enabled.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isduplicatedetectionenabledforofflinesync")]
			public System.Nullable<bool> IsDuplicateDetectionEnabledForOfflineSync {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isduplicatedetectionenabledforofflinesync");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsDuplicateDetectionEnabledForOfflineSync", "isduplicatedetectionenabledforofflinesync", value);
				}
			}

			/// <summary>
			/// Indicates whether duplicate detection during online create or update is enabled.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isduplicatedetectionenabledforonlinecreateupdate")]
			public System.Nullable<bool> IsDuplicateDetectionEnabledForOnlineCreateUpdate {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isduplicatedetectionenabledforonlinecreateupdate");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsDuplicateDetectionEnabledForOnlineCreateUpdate", "isduplicatedetectionenabledforonlinecreateupdate", value);
				}
			}

			/// <summary>
			/// Allow tracking recipient activity on sent emails.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isemailmonitoringallowed")]
			public System.Nullable<bool> IsEmailMonitoringAllowed {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isemailmonitoringallowed");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsEmailMonitoringAllowed", "isemailmonitoringallowed", value);
				}
			}

			/// <summary>
			/// Enable Email Server Profile content filtering
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isemailserverprofilecontentfilteringenabled")]
			public System.Nullable<bool> IsEmailServerProfileContentFilteringEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isemailserverprofilecontentfilteringenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsEmailServerProfileContentFilteringEnabled", "isemailserverprofilecontentfilteringenabled", value);
				}
			}

			/// <summary>
			/// Indicates whether appmodule is enabled for all roles
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isenabledforallroles")]
			public System.Nullable<bool> IsEnabledForAllRoles {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isenabledforallroles");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsEnabledForAllRoles", "isenabledforallroles", value);
				}
			}

			/// <summary>
			/// Select whether data can be synchronized with an external search index.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isexternalsearchindexenabled")]
			public System.Nullable<bool> IsExternalSearchIndexEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isexternalsearchindexenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsExternalSearchIndexEnabled", "isexternalsearchindexenabled", value);
				}
			}

			/// <summary>
			/// Indicates whether the fiscal period is displayed as the month number.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isfiscalperiodmonthbased")]
			public System.Nullable<bool> IsFiscalPeriodMonthBased {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isfiscalperiodmonthbased");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsFiscalPeriodMonthBased", "isfiscalperiodmonthbased", value);
				}
			}

			/// <summary>
			/// Select whether folders should be automatically created on SharePoint.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isfolderautocreatedonsp")]
			public System.Nullable<bool> IsFolderAutoCreatedonSP {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isfolderautocreatedonsp");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsFolderAutoCreatedonSP", "isfolderautocreatedonsp", value);
				}
			}

			/// <summary>
			/// Enable or disable folder based tracking for Server Side Sync.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isfolderbasedtrackingenabled")]
			public System.Nullable<bool> IsFolderBasedTrackingEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isfolderbasedtrackingenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsFolderBasedTrackingEnabled", "isfolderbasedtrackingenabled", value);
				}
			}

			/// <summary>
			/// Indicates whether full-text search for Quick Find entities should be enabled for the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isfulltextsearchenabled")]
			public System.Nullable<bool> IsFullTextSearchEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isfulltextsearchenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsFullTextSearchEnabled", "isfulltextsearchenabled", value);
				}
			}

			/// <summary>
			/// Enable Hierarchical Security Model
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ishierarchicalsecuritymodelenabled")]
			public System.Nullable<bool> IsHierarchicalSecurityModelEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("ishierarchicalsecuritymodelenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsHierarchicalSecurityModelEnabled", "ishierarchicalsecuritymodelenabled", value);
				}
			}

			/// <summary>
			/// Enable or disable forced unlocking for Server Side Sync mailboxes.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ismailboxforcedunlockingenabled")]
			public System.Nullable<bool> IsMailboxForcedUnlockingEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("ismailboxforcedunlockingenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsMailboxForcedUnlockingEnabled", "ismailboxforcedunlockingenabled", value);
				}
			}

			/// <summary>
			/// Enable or disable mailbox keep alive for Server Side Sync.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ismailboxinactivebackoffenabled")]
			public System.Nullable<bool> IsMailboxInactiveBackoffEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("ismailboxinactivebackoffenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsMailboxInactiveBackoffEnabled", "ismailboxinactivebackoffenabled", value);
				}
			}

			/// <summary>
			/// Information that specifies whether mobile client on demand sync is enabled.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ismobileclientondemandsyncenabled")]
			public System.Nullable<bool> IsMobileClientOnDemandSyncEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("ismobileclientondemandsyncenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsMobileClientOnDemandSyncEnabled", "ismobileclientondemandsyncenabled", value);
				}
			}

			/// <summary>
			/// Indicates whether the feature MobileOffline should be enabled for the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ismobileofflineenabled")]
			public System.Nullable<bool> IsMobileOfflineEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("ismobileofflineenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsMobileOfflineEnabled", "ismobileofflineenabled", value);
				}
			}

			/// <summary>
			/// Indicates whether the feature OfficeGraph should be enabled for the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isofficegraphenabled")]
			public System.Nullable<bool> IsOfficeGraphEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isofficegraphenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsOfficeGraphEnabled", "isofficegraphenabled", value);
				}
			}

			/// <summary>
			/// Indicates whether the feature One Drive should be enabled for the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isonedriveenabled")]
			public System.Nullable<bool> IsOneDriveEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isonedriveenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsOneDriveEnabled", "isonedriveenabled", value);
				}
			}

			/// <summary>
			/// Information on whether IM presence is enabled.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ispresenceenabled")]
			public System.Nullable<bool> IsPresenceEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("ispresenceenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsPresenceEnabled", "ispresenceenabled", value);
				}
			}

			/// <summary>
			/// Indicates whether the Preview feature for Action Card should be enabled for the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ispreviewenabledforactioncard")]
			public System.Nullable<bool> IsPreviewEnabledForActionCard {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("ispreviewenabledforactioncard");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsPreviewEnabledForActionCard", "ispreviewenabledforactioncard", value);
				}
			}

			/// <summary>
			/// Indicates whether the feature Auto Capture should be enabled for the organization at Preview Settings.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ispreviewforautocaptureenabled")]
			public System.Nullable<bool> IsPreviewForAutoCaptureEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("ispreviewforautocaptureenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsPreviewForAutoCaptureEnabled", "ispreviewforautocaptureenabled", value);
				}
			}

			/// <summary>
			/// Is Preview For Email Monitoring Allowed.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ispreviewforemailmonitoringallowed")]
			public System.Nullable<bool> IsPreviewForEmailMonitoringAllowed {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("ispreviewforemailmonitoringallowed");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsPreviewForEmailMonitoringAllowed", "ispreviewforemailmonitoringallowed", value);
				}
			}

			/// <summary>
			/// Indicates whether the feature Relationship Insights should be enabled for the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isrelationshipinsightsenabled")]
			public System.Nullable<bool> IsRelationshipInsightsEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isrelationshipinsightsenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsRelationshipInsightsEnabled", "isrelationshipinsightsenabled", value);
				}
			}

			/// <summary>
			/// Indicates if the synchronization of user resource booking with Exchange is enabled at organization level.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isresourcebookingexchangesyncenabled")]
			public System.Nullable<bool> IsResourceBookingExchangeSyncEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isresourcebookingexchangesyncenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsResourceBookingExchangeSyncEnabled", "isresourcebookingexchangesyncenabled", value);
				}
			}

			/// <summary>
			/// Enable sales order processing integration.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("issopintegrationenabled")]
			public System.Nullable<bool> IsSOPIntegrationEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("issopintegrationenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsSOPIntegrationEnabled", "issopintegrationenabled", value);
				}
			}

			/// <summary>
			/// Enable or disable auditing of user access.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isuseraccessauditenabled")]
			public System.Nullable<bool> IsUserAccessAuditEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isuseraccessauditenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsUserAccessAuditEnabled", "isuseraccessauditenabled", value);
				}
			}

			/// <summary>
			/// Indicates whether loading of Microsoft Dynamics 365 in a browser window that does not have address, tool, and menu bars is enabled.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isvintegrationcode")]
			[System.ObsoleteAttribute()]
			public System.Nullable<int> ISVIntegrationCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("isvintegrationcode");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("ISVIntegrationCode", "isvintegrationcode", value);
				}
			}

			/// <summary>
			/// Type the prefix to use for all knowledge articles in Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("kaprefix")]
			public string KaPrefix {
				get {
					return this.GetAttributeValue<string>("kaprefix");
				}
				set {
					this.SetAttributeValue<string>("KaPrefix", "kaprefix", value);
				}
			}

			/// <summary>
			/// Prefix to use for all articles in Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("kbprefix")]
			public string KbPrefix {
				get {
					return this.GetAttributeValue<string>("kbprefix");
				}
				set {
					this.SetAttributeValue<string>("KbPrefix", "kbprefix", value);
				}
			}

			/// <summary>
			/// XML string containing the Knowledge Management settings that are applied in Knowledge Management Wizard.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("kmsettings")]
			public string KMSettings {
				get {
					return this.GetAttributeValue<string>("kmsettings");
				}
				set {
					this.SetAttributeValue<string>("KMSettings", "kmsettings", value);
				}
			}

			/// <summary>
			/// Preferred language for the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("languagecode")]
			public System.Nullable<int> LanguageCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("languagecode");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("LanguageCode", "languagecode", value);
				}
			}

			/// <summary>
			/// Unique identifier of the locale of the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("localeid")]
			public System.Nullable<int> LocaleId {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("localeid");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("LocaleId", "localeid", value);
				}
			}

			/// <summary>
			/// Information that specifies how the Long Date format is displayed in Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("longdateformatcode")]
			public System.Nullable<int> LongDateFormatCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("longdateformatcode");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("LongDateFormatCode", "longdateformatcode", value);
				}
			}

			/// <summary>
			/// Lower Threshold For Mailbox Intermittent Issue.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mailboxintermittentissueminrange")]
			public System.Nullable<int> MailboxIntermittentIssueMinRange {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("mailboxintermittentissueminrange");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("MailboxIntermittentIssueMinRange", "mailboxintermittentissueminrange", value);
				}
			}

			/// <summary>
			/// Lower Threshold For Mailbox Permanent Issue.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mailboxpermanentissueminrange")]
			public System.Nullable<int> MailboxPermanentIssueMinRange {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("mailboxpermanentissueminrange");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("MailboxPermanentIssueMinRange", "mailboxpermanentissueminrange", value);
				}
			}

			/// <summary>
			/// Maximum number of days an appointment can last.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("maxappointmentdurationdays")]
			public System.Nullable<int> MaxAppointmentDurationDays {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("maxappointmentdurationdays");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("MaxAppointmentDurationDays", "maxappointmentdurationdays", value);
				}
			}

			/// <summary>
			/// Maximum number of conditions allowed for mobile offline filters
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("maxconditionsformobileofflinefilters")]
			public System.Nullable<int> MaxConditionsForMobileOfflineFilters {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("maxconditionsformobileofflinefilters");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("MaxConditionsForMobileOfflineFilters", "maxconditionsformobileofflinefilters", value);
				}
			}

			/// <summary>
			/// Maximum depth for hierarchy security propagation.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("maxdepthforhierarchicalsecuritymodel")]
			public System.Nullable<int> MaxDepthForHierarchicalSecurityModel {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("maxdepthforhierarchicalsecuritymodel");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("MaxDepthForHierarchicalSecurityModel", "maxdepthforhierarchicalsecuritymodel", value);
				}
			}

			/// <summary>
			/// Maximum number of Folder Based Tracking mappings user can add
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("maxfolderbasedtrackingmappings")]
			public System.Nullable<int> MaxFolderBasedTrackingMappings {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("maxfolderbasedtrackingmappings");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("MaxFolderBasedTrackingMappings", "maxfolderbasedtrackingmappings", value);
				}
			}

			/// <summary>
			/// Maximum number of active business process flows allowed per entity
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("maximumactivebusinessprocessflowsallowedperentity")]
			public System.Nullable<int> MaximumActiveBusinessProcessFlowsAllowedPerEntity {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("maximumactivebusinessprocessflowsallowedperentity");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("MaximumActiveBusinessProcessFlowsAllowedPerEntity", "maximumactivebusinessprocessflowsallowedperentity", value);
				}
			}

			/// <summary>
			/// Restrict the maximum number of product properties for a product family/bundle
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("maximumdynamicpropertiesallowed")]
			public System.Nullable<int> MaximumDynamicPropertiesAllowed {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("maximumdynamicpropertiesallowed");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("MaximumDynamicPropertiesAllowed", "maximumdynamicpropertiesallowed", value);
				}
			}

			/// <summary>
			/// Maximum number of active SLA allowed per entity in online
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("maximumentitieswithactivesla")]
			public System.Nullable<int> MaximumEntitiesWithActiveSLA {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("maximumentitieswithactivesla");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("MaximumEntitiesWithActiveSLA", "maximumentitieswithactivesla", value);
				}
			}

			/// <summary>
			/// Maximum number of SLA KPI per active SLA allowed for entity in online
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("maximumslakpiperentitywithactivesla")]
			public System.Nullable<int> MaximumSLAKPIPerEntityWithActiveSLA {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("maximumslakpiperentitywithactivesla");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("MaximumSLAKPIPerEntityWithActiveSLA", "maximumslakpiperentitywithactivesla", value);
				}
			}

			/// <summary>
			/// Maximum tracking number before recycling takes place.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("maximumtrackingnumber")]
			public System.Nullable<int> MaximumTrackingNumber {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("maximumtrackingnumber");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("MaximumTrackingNumber", "maximumtrackingnumber", value);
				}
			}

			/// <summary>
			/// Restrict the maximum no of items in a bundle
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("maxproductsinbundle")]
			public System.Nullable<int> MaxProductsInBundle {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("maxproductsinbundle");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("MaxProductsInBundle", "maxproductsinbundle", value);
				}
			}

			/// <summary>
			/// Maximum number of records that will be exported to a static Microsoft Office Excel worksheet when exporting from the grid.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("maxrecordsforexporttoexcel")]
			public System.Nullable<int> MaxRecordsForExportToExcel {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("maxrecordsforexporttoexcel");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("MaxRecordsForExportToExcel", "maxrecordsforexporttoexcel", value);
				}
			}

			/// <summary>
			/// Maximum number of lookup and picklist records that can be selected by user for filtering.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("maxrecordsforlookupfilters")]
			public System.Nullable<int> MaxRecordsForLookupFilters {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("maxrecordsforlookupfilters");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("MaxRecordsForLookupFilters", "maxrecordsforlookupfilters", value);
				}
			}

			/// <summary>
			/// The maximum version of IE to run browser emulation for in Outlook client
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("maxsupportedinternetexplorerversion")]
			public System.Nullable<int> MaxSupportedInternetExplorerVersion {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("maxsupportedinternetexplorerversion");
				}
			}

			/// <summary>
			/// Maximum allowed size of an attachment.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("maxuploadfilesize")]
			public System.Nullable<int> MaxUploadFileSize {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("maxuploadfilesize");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("MaxUploadFileSize", "maxuploadfilesize", value);
				}
			}

			/// <summary>
			/// Maximum number of mailboxes that can be toggled for verbose logging
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("maxverboseloggingmailbox")]
			public System.Nullable<int> MaxVerboseLoggingMailbox {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("maxverboseloggingmailbox");
				}
			}

			/// <summary>
			/// Maximum number of sync cycles for which verbose logging will be enabled by default
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("maxverboseloggingsynccycles")]
			public System.Nullable<int> MaxVerboseLoggingSyncCycles {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("maxverboseloggingsynccycles");
				}
			}

			/// <summary>
			/// Normal polling frequency used for address book synchronization in Microsoft Office Outlook.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("minaddressbooksyncinterval")]
			public System.Nullable<int> MinAddressBookSyncInterval {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("minaddressbooksyncinterval");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("MinAddressBookSyncInterval", "minaddressbooksyncinterval", value);
				}
			}

			/// <summary>
			/// Normal polling frequency used for background offline synchronization in Microsoft Office Outlook.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("minofflinesyncinterval")]
			public System.Nullable<int> MinOfflineSyncInterval {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("minofflinesyncinterval");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("MinOfflineSyncInterval", "minofflinesyncinterval", value);
				}
			}

			/// <summary>
			/// Minimum allowed time between scheduled Outlook synchronizations.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("minoutlooksyncinterval")]
			public System.Nullable<int> MinOutlookSyncInterval {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("minoutlooksyncinterval");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("MinOutlookSyncInterval", "minoutlooksyncinterval", value);
				}
			}

			/// <summary>
			/// Minimum number of user license required for mobile offline service by production/preview organization
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mobileofflineminlicenseprod")]
			public System.Nullable<int> MobileOfflineMinLicenseProd {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("mobileofflineminlicenseprod");
				}
			}

			/// <summary>
			/// Minimum number of user license required for mobile offline service by trial organization
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mobileofflineminlicensetrial")]
			public System.Nullable<int> MobileOfflineMinLicenseTrial {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("mobileofflineminlicensetrial");
				}
			}

			/// <summary>
			/// Sync interval for mobile offline.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mobileofflinesyncinterval")]
			public System.Nullable<int> MobileOfflineSyncInterval {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("mobileofflinesyncinterval");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("MobileOfflineSyncInterval", "mobileofflinesyncinterval", value);
				}
			}

			/// <summary>
			/// Unique identifier of the user who last modified the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
			public Microsoft.Xrm.Client.CrmEntityReference ModifiedBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
				}
			}

			/// <summary>
			/// Date and time when the organization was last modified.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
			public System.Nullable<System.DateTime> ModifiedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
				}
			}

			/// <summary>
			/// Unique identifier of the delegate user who last modified the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
			public Microsoft.Xrm.Client.CrmEntityReference ModifiedOnBehalfBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ModifiedOnBehalfBy", "modifiedonbehalfby", value);
				}
			}

			/// <summary>
			/// Name of the organization. The name is set when Microsoft CRM is installed and should not be changed.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("name")]
			public string Name {
				get {
					return this.GetAttributeValue<string>("name");
				}
				set {
					this.SetAttributeValue<string>("Name", "name", value);
				}
			}

			/// <summary>
			/// Information that specifies how negative currency numbers are displayed throughout Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("negativecurrencyformatcode")]
			public System.Nullable<int> NegativeCurrencyFormatCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("negativecurrencyformatcode");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("NegativeCurrencyFormatCode", "negativecurrencyformatcode", value);
				}
			}

			/// <summary>
			/// Information that specifies how negative numbers are displayed throughout Microsoft CRM.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("negativeformatcode")]
			public System.Nullable<int> NegativeFormatCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("negativeformatcode");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("NegativeFormatCode", "negativeformatcode", value);
				}
			}

			/// <summary>
			/// Next token to be placed on the subject line of an email message.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("nexttrackingnumber")]
			public System.Nullable<int> NextTrackingNumber {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("nexttrackingnumber");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("NextTrackingNumber", "nexttrackingnumber", value);
				}
			}

			/// <summary>
			/// Indicates whether mailbox owners will be notified of email server profile level alerts.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("notifymailboxownerofemailserverlevelalerts")]
			public System.Nullable<bool> NotifyMailboxOwnerOfEmailServerLevelAlerts {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("notifymailboxownerofemailserverlevelalerts");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("NotifyMailboxOwnerOfEmailServerLevelAlerts", "notifymailboxownerofemailserverlevelalerts", value);
				}
			}

			/// <summary>
			/// Specification of how numbers are displayed throughout Microsoft CRM.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("numberformat")]
			public string NumberFormat {
				get {
					return this.GetAttributeValue<string>("numberformat");
				}
				set {
					this.SetAttributeValue<string>("NumberFormat", "numberformat", value);
				}
			}

			/// <summary>
			/// Specifies how numbers are grouped in Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("numbergroupformat")]
			public string NumberGroupFormat {
				get {
					return this.GetAttributeValue<string>("numbergroupformat");
				}
				set {
					this.SetAttributeValue<string>("NumberGroupFormat", "numbergroupformat", value);
				}
			}

			/// <summary>
			/// Symbol used for number separation in Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("numberseparator")]
			public string NumberSeparator {
				get {
					return this.GetAttributeValue<string>("numberseparator");
				}
				set {
					this.SetAttributeValue<string>("NumberSeparator", "numberseparator", value);
				}
			}

			/// <summary>
			/// Indicates whether the Office Apps auto deployment is enabled for the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("officeappsautodeploymentenabled")]
			public System.Nullable<bool> OfficeAppsAutoDeploymentEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("officeappsautodeploymentenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("OfficeAppsAutoDeploymentEnabled", "officeappsautodeploymentenabled", value);
				}
			}

			/// <summary>
			/// The url to open the Delve for the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("officegraphdelveurl")]
			public string OfficeGraphDelveUrl {
				get {
					return this.GetAttributeValue<string>("officegraphdelveurl");
				}
				set {
					this.SetAttributeValue<string>("OfficeGraphDelveUrl", "officegraphdelveurl", value);
				}
			}

			/// <summary>
			/// Enable OOB pricing calculation logic for Opportunity, Quote, Order and Invoice entities.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("oobpricecalculationenabled")]
			public System.Nullable<bool> OOBPriceCalculationEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("oobpricecalculationenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("OOBPriceCalculationEnabled", "oobpricecalculationenabled", value);
				}
			}

			/// <summary>
			/// Prefix to use for all orders throughout Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("orderprefix")]
			public string OrderPrefix {
				get {
					return this.GetAttributeValue<string>("orderprefix");
				}
				set {
					this.SetAttributeValue<string>("OrderPrefix", "orderprefix", value);
				}
			}

			/// <summary>
			/// Unique identifier of the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("organizationid")]
			public System.Nullable<System.Guid> OrganizationId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("organizationid");
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("organizationid")]
			public override System.Guid Id {
				get {
					return base.Id;
				}
				set {
					base.Id = value;
				}
			}

			/// <summary>
			/// Organization settings stored in Organization Database.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("orgdborgsettings")]
			public string OrgDbOrgSettings {
				get {
					return this.GetAttributeValue<string>("orgdborgsettings");
				}
				set {
					this.SetAttributeValue<string>("OrgDbOrgSettings", "orgdborgsettings", value);
				}
			}

			/// <summary>
			/// Select whether to turn on OrgInsights for the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("orginsightsenabled")]
			public System.Nullable<bool> OrgInsightsEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("orginsightsenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("OrgInsightsEnabled", "orginsightsenabled", value);
				}
			}

			/// <summary>
			/// Prefix used for parsed table columns.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("parsedtablecolumnprefix")]
			public string ParsedTableColumnPrefix {
				get {
					return this.GetAttributeValue<string>("parsedtablecolumnprefix");
				}
			}

			/// <summary>
			/// Prefix used for parsed tables.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("parsedtableprefix")]
			public string ParsedTablePrefix {
				get {
					return this.GetAttributeValue<string>("parsedtableprefix");
				}
			}

			/// <summary>
			/// Specifies the maximum number of months in past for which the recurring activities can be created.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("pastexpansionwindow")]
			public System.Nullable<int> PastExpansionWindow {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("pastexpansionwindow");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("PastExpansionWindow", "pastexpansionwindow", value);
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("picture")]
			public string Picture {
				get {
					return this.GetAttributeValue<string>("picture");
				}
				set {
					this.SetAttributeValue<string>("Picture", "picture", value);
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("pinpointlanguagecode")]
			public System.Nullable<int> PinpointLanguageCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("pinpointlanguagecode");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("PinpointLanguageCode", "pinpointlanguagecode", value);
				}
			}

			/// <summary>
			/// Plug-in Trace Log Setting for the Organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("plugintracelogsetting")]
			public System.Nullable<int> PluginTraceLogSetting {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("plugintracelogsetting");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("PluginTraceLogSetting", "plugintracelogsetting", value);
				}
			}

			/// <summary>
			/// PM designator to use throughout Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("pmdesignator")]
			public string PMDesignator {
				get {
					return this.GetAttributeValue<string>("pmdesignator");
				}
				set {
					this.SetAttributeValue<string>("PMDesignator", "pmdesignator", value);
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("postmessagewhitelistdomains")]
			public string PostMessageWhitelistDomains {
				get {
					return this.GetAttributeValue<string>("postmessagewhitelistdomains");
				}
				set {
					this.SetAttributeValue<string>("PostMessageWhitelistDomains", "postmessagewhitelistdomains", value);
				}
			}

			/// <summary>
			/// Indicates whether the Power BI feature should be enabled for the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("powerbifeatureenabled")]
			public System.Nullable<bool> PowerBiFeatureEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("powerbifeatureenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("PowerBiFeatureEnabled", "powerbifeatureenabled", value);
				}
			}

			/// <summary>
			/// Number of decimal places that can be used for prices.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("pricingdecimalprecision")]
			public System.Nullable<int> PricingDecimalPrecision {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("pricingdecimalprecision");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("PricingDecimalPrecision", "pricingdecimalprecision", value);
				}
			}

			/// <summary>
			/// Privacy Statement URL
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("privacystatementurl")]
			public string PrivacyStatementUrl {
				get {
					return this.GetAttributeValue<string>("privacystatementurl");
				}
				set {
					this.SetAttributeValue<string>("PrivacyStatementUrl", "privacystatementurl", value);
				}
			}

			/// <summary>
			/// Unique identifier of the default privilege for users in the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("privilegeusergroupid")]
			public System.Nullable<System.Guid> PrivilegeUserGroupId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("privilegeusergroupid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("PrivilegeUserGroupId", "privilegeusergroupid", value);
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("privreportinggroupid")]
			public System.Nullable<System.Guid> PrivReportingGroupId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("privreportinggroupid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("PrivReportingGroupId", "privreportinggroupid", value);
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("privreportinggroupname")]
			public string PrivReportingGroupName {
				get {
					return this.GetAttributeValue<string>("privreportinggroupname");
				}
				set {
					this.SetAttributeValue<string>("PrivReportingGroupName", "privreportinggroupname", value);
				}
			}

			/// <summary>
			/// Select whether to turn on product recommendations for the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("productrecommendationsenabled")]
			public System.Nullable<bool> ProductRecommendationsEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("productrecommendationsenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("ProductRecommendationsEnabled", "productrecommendationsenabled", value);
				}
			}

			/// <summary>
			/// Indicates whether a quick find record limit should be enabled for this organization (allows for faster Quick Find queries but prevents overly broad searches).
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("quickfindrecordlimitenabled")]
			public System.Nullable<bool> QuickFindRecordLimitEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("quickfindrecordlimitenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("QuickFindRecordLimitEnabled", "quickfindrecordlimitenabled", value);
				}
			}

			/// <summary>
			/// Prefix to use for all quotes throughout Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("quoteprefix")]
			public string QuotePrefix {
				get {
					return this.GetAttributeValue<string>("quoteprefix");
				}
				set {
					this.SetAttributeValue<string>("QuotePrefix", "quoteprefix", value);
				}
			}

			/// <summary>
			/// Specifies the default value for number of occurrences field in the recurrence dialog.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("recurrencedefaultnumberofoccurrences")]
			public System.Nullable<int> RecurrenceDefaultNumberOfOccurrences {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("recurrencedefaultnumberofoccurrences");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("RecurrenceDefaultNumberOfOccurrences", "recurrencedefaultnumberofoccurrences", value);
				}
			}

			/// <summary>
			/// Specifies the interval (in seconds) for pausing expansion job.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("recurrenceexpansionjobbatchinterval")]
			public System.Nullable<int> RecurrenceExpansionJobBatchInterval {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("recurrenceexpansionjobbatchinterval");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("RecurrenceExpansionJobBatchInterval", "recurrenceexpansionjobbatchinterval", value);
				}
			}

			/// <summary>
			/// Specifies the value for number of instances created in on demand job in one shot.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("recurrenceexpansionjobbatchsize")]
			public System.Nullable<int> RecurrenceExpansionJobBatchSize {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("recurrenceexpansionjobbatchsize");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("RecurrenceExpansionJobBatchSize", "recurrenceexpansionjobbatchsize", value);
				}
			}

			/// <summary>
			/// Specifies the maximum number of instances to be created synchronously after creating a recurring appointment.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("recurrenceexpansionsynchcreatemax")]
			public System.Nullable<int> RecurrenceExpansionSynchCreateMax {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("recurrenceexpansionsynchcreatemax");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("RecurrenceExpansionSynchCreateMax", "recurrenceexpansionsynchcreatemax", value);
				}
			}

			/// <summary>
			/// XML string that defines the navigation structure for the application. This is the site map from the previously upgraded build and is used in a 3-way merge during upgrade.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("referencesitemapxml")]
			[System.ObsoleteAttribute()]
			public string ReferenceSiteMapXml {
				get {
					return this.GetAttributeValue<string>("referencesitemapxml");
				}
				set {
					this.SetAttributeValue<string>("ReferenceSiteMapXml", "referencesitemapxml", value);
				}
			}

			/// <summary>
			/// Flag to render the body of email in the Web form in an IFRAME with the security='restricted' attribute set. This is additional security but can cause a credentials prompt.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("rendersecureiframeforemail")]
			public System.Nullable<bool> RenderSecureIFrameForEmail {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("rendersecureiframeforemail");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("RenderSecureIFrameForEmail", "rendersecureiframeforemail", value);
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("reportinggroupid")]
			public System.Nullable<System.Guid> ReportingGroupId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("reportinggroupid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("ReportingGroupId", "reportinggroupid", value);
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("reportinggroupname")]
			public string ReportingGroupName {
				get {
					return this.GetAttributeValue<string>("reportinggroupname");
				}
				set {
					this.SetAttributeValue<string>("ReportingGroupName", "reportinggroupname", value);
				}
			}

			/// <summary>
			/// Picklist for selecting the organization preference for reporting scripting errors.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("reportscripterrors")]
			public System.Nullable<int> ReportScriptErrors {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("reportscripterrors");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("ReportScriptErrors", "reportscripterrors", value);
				}
			}

			/// <summary>
			/// Indicates whether Send As Other User privilege is enabled.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("requireapprovalforqueueemail")]
			public System.Nullable<bool> RequireApprovalForQueueEmail {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("requireapprovalforqueueemail");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("RequireApprovalForQueueEmail", "requireapprovalforqueueemail", value);
				}
			}

			/// <summary>
			/// Indicates whether Send As Other User privilege is enabled.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("requireapprovalforuseremail")]
			public System.Nullable<bool> RequireApprovalForUserEmail {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("requireapprovalforuseremail");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("RequireApprovalForUserEmail", "requireapprovalforuseremail", value);
				}
			}

			/// <summary>
			/// Flag to restrict Update on incident.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("restrictstatusupdate")]
			public System.Nullable<bool> RestrictStatusUpdate {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("restrictstatusupdate");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("RestrictStatusUpdate", "restrictstatusupdate", value);
				}
			}

			/// <summary>
			/// Error status of Relationship Insights provisioning.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("rierrorstatus")]
			public System.Nullable<int> RiErrorStatus {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("rierrorstatus");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("RiErrorStatus", "rierrorstatus", value);
				}
			}

			/// <summary>
			/// Unique identifier of the sample data import job.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sampledataimportid")]
			public System.Nullable<System.Guid> SampleDataImportId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("sampledataimportid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("SampleDataImportId", "sampledataimportid", value);
				}
			}

			/// <summary>
			/// Prefix used for custom entities and attributes.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("schemanameprefix")]
			public string SchemaNamePrefix {
				get {
					return this.GetAttributeValue<string>("schemanameprefix");
				}
				set {
					this.SetAttributeValue<string>("SchemaNamePrefix", "schemanameprefix", value);
				}
			}

			/// <summary>
			/// Indicates which SharePoint deployment type is configured for Server to Server. (Online or On-Premises)
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sharepointdeploymenttype")]
			public System.Nullable<int> SharePointDeploymentType {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("sharepointdeploymenttype");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("SharePointDeploymentType", "sharepointdeploymenttype", value);
				}
			}

			/// <summary>
			/// Information that specifies whether to share to previous owner on assign.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sharetopreviousowneronassign")]
			public System.Nullable<bool> ShareToPreviousOwnerOnAssign {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("sharetopreviousowneronassign");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("ShareToPreviousOwnerOnAssign", "sharetopreviousowneronassign", value);
				}
			}

			/// <summary>
			/// Select whether to display a KB article deprecation notification to the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("showkbarticledeprecationnotification")]
			public System.Nullable<bool> ShowKBArticleDeprecationNotification {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("showkbarticledeprecationnotification");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("ShowKBArticleDeprecationNotification", "showkbarticledeprecationnotification", value);
				}
			}

			/// <summary>
			/// Information that specifies whether to display the week number in calendar displays throughout Microsoft CRM.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("showweeknumber")]
			public System.Nullable<bool> ShowWeekNumber {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("showweeknumber");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("ShowWeekNumber", "showweeknumber", value);
				}
			}

			/// <summary>
			/// CRM for Outlook Download URL
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("signupoutlookdownloadfwlink")]
			public string SignupOutlookDownloadFWLink {
				get {
					return this.GetAttributeValue<string>("signupoutlookdownloadfwlink");
				}
				set {
					this.SetAttributeValue<string>("SignupOutlookDownloadFWLink", "signupoutlookdownloadfwlink", value);
				}
			}

			/// <summary>
			/// XML string that defines the navigation structure for the application.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sitemapxml")]
			[System.ObsoleteAttribute()]
			public string SiteMapXml {
				get {
					return this.GetAttributeValue<string>("sitemapxml");
				}
				set {
					this.SetAttributeValue<string>("SiteMapXml", "sitemapxml", value);
				}
			}

			/// <summary>
			/// Contains the on hold case status values.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("slapausestates")]
			public string SlaPauseStates {
				get {
					return this.GetAttributeValue<string>("slapausestates");
				}
				set {
					this.SetAttributeValue<string>("SlaPauseStates", "slapausestates", value);
				}
			}

			/// <summary>
			/// Flag for whether the organization is using Social Insights.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("socialinsightsenabled")]
			public System.Nullable<bool> SocialInsightsEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("socialinsightsenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("SocialInsightsEnabled", "socialinsightsenabled", value);
				}
			}

			/// <summary>
			/// Identifier for the Social Insights instance for the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("socialinsightsinstance")]
			public string SocialInsightsInstance {
				get {
					return this.GetAttributeValue<string>("socialinsightsinstance");
				}
				set {
					this.SetAttributeValue<string>("SocialInsightsInstance", "socialinsightsinstance", value);
				}
			}

			/// <summary>
			/// Flag for whether the organization has accepted the Social Insights terms of use.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("socialinsightstermsaccepted")]
			public System.Nullable<bool> SocialInsightsTermsAccepted {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("socialinsightstermsaccepted");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("SocialInsightsTermsAccepted", "socialinsightstermsaccepted", value);
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sortid")]
			public System.Nullable<int> SortId {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("sortid");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("SortId", "sortid", value);
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sqlaccessgroupid")]
			public System.Nullable<System.Guid> SqlAccessGroupId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("sqlaccessgroupid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("SqlAccessGroupId", "sqlaccessgroupid", value);
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sqlaccessgroupname")]
			public string SqlAccessGroupName {
				get {
					return this.GetAttributeValue<string>("sqlaccessgroupname");
				}
				set {
					this.SetAttributeValue<string>("SqlAccessGroupName", "sqlaccessgroupname", value);
				}
			}

			/// <summary>
			/// Setting for SQM data collection, 0 no, 1 yes enabled
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sqmenabled")]
			public System.Nullable<bool> SQMEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("sqmenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("SQMEnabled", "sqmenabled", value);
				}
			}

			/// <summary>
			/// Unique identifier of the support user for the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("supportuserid")]
			public System.Nullable<System.Guid> SupportUserId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("supportuserid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("SupportUserId", "supportuserid", value);
				}
			}

			/// <summary>
			/// Indicates whether SLA is suppressed.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("suppresssla")]
			public System.Nullable<bool> SuppressSLA {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("suppresssla");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("SuppressSLA", "suppresssla", value);
				}
			}

			/// <summary>
			/// Unique identifier of the system user for the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("systemuserid")]
			public System.Nullable<System.Guid> SystemUserId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("systemuserid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("SystemUserId", "systemuserid", value);
				}
			}

			/// <summary>
			/// Maximum number of aggressive polling cycles executed for email auto-tagging when a new email is received.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("tagmaxaggressivecycles")]
			public System.Nullable<int> TagMaxAggressiveCycles {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("tagmaxaggressivecycles");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TagMaxAggressiveCycles", "tagmaxaggressivecycles", value);
				}
			}

			/// <summary>
			/// Normal polling frequency used for email receive auto-tagging in outlook.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("tagpollingperiod")]
			public System.Nullable<int> TagPollingPeriod {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("tagpollingperiod");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TagPollingPeriod", "tagpollingperiod", value);
				}
			}

			/// <summary>
			/// Select whether to turn on task flows for the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("taskbasedflowenabled")]
			public System.Nullable<bool> TaskBasedFlowEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("taskbasedflowenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("TaskBasedFlowEnabled", "taskbasedflowenabled", value);
				}
			}

			/// <summary>
			/// Select whether to turn on text analytics for the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("textanalyticsenabled")]
			public System.Nullable<bool> TextAnalyticsEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("textanalyticsenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("TextAnalyticsEnabled", "textanalyticsenabled", value);
				}
			}

			/// <summary>
			/// Information that specifies how the time is displayed throughout Microsoft CRM.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timeformatcode")]
			public System.Nullable<int> TimeFormatCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("timeformatcode");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("TimeFormatCode", "timeformatcode", value);
				}
			}

			/// <summary>
			/// Text for how time is displayed in Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timeformatstring")]
			public string TimeFormatString {
				get {
					return this.GetAttributeValue<string>("timeformatstring");
				}
				set {
					this.SetAttributeValue<string>("TimeFormatString", "timeformatstring", value);
				}
			}

			/// <summary>
			/// Text for how the time separator is displayed throughout Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timeseparator")]
			public string TimeSeparator {
				get {
					return this.GetAttributeValue<string>("timeseparator");
				}
				set {
					this.SetAttributeValue<string>("TimeSeparator", "timeseparator", value);
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezoneruleversionnumber")]
			public System.Nullable<int> TimeZoneRuleVersionNumber {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("timezoneruleversionnumber");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TimeZoneRuleVersionNumber", "timezoneruleversionnumber", value);
				}
			}

			/// <summary>
			/// Duration used for token expiration.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("tokenexpiry")]
			public System.Nullable<int> TokenExpiry {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("tokenexpiry");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TokenExpiry", "tokenexpiry", value);
				}
			}

			/// <summary>
			/// Token key.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("tokenkey")]
			public string TokenKey {
				get {
					return this.GetAttributeValue<string>("tokenkey");
				}
				set {
					this.SetAttributeValue<string>("TokenKey", "tokenkey", value);
				}
			}

			/// <summary>
			/// History list of tracking token prefixes.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("trackingprefix")]
			public string TrackingPrefix {
				get {
					return this.GetAttributeValue<string>("trackingprefix");
				}
				set {
					this.SetAttributeValue<string>("TrackingPrefix", "trackingprefix", value);
				}
			}

			/// <summary>
			/// Base number used to provide separate tracking token identifiers to users belonging to different deployments.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("trackingtokenidbase")]
			public System.Nullable<int> TrackingTokenIdBase {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("trackingtokenidbase");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TrackingTokenIdBase", "trackingtokenidbase", value);
				}
			}

			/// <summary>
			/// Number of digits used to represent a tracking token identifier.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("trackingtokeniddigits")]
			public System.Nullable<int> TrackingTokenIdDigits {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("trackingtokeniddigits");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TrackingTokenIdDigits", "trackingtokeniddigits", value);
				}
			}

			/// <summary>
			/// Number of characters appended to invoice, quote, and order numbers.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("uniquespecifierlength")]
			public System.Nullable<int> UniqueSpecifierLength {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("uniquespecifierlength");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("UniqueSpecifierLength", "uniquespecifierlength", value);
				}
			}

			/// <summary>
			/// Indicates whether email address should be unresolved if multiple matches are found
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("unresolveemailaddressifmultiplematch")]
			public System.Nullable<bool> UnresolveEmailAddressIfMultipleMatch {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("unresolveemailaddressifmultiplematch");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("UnresolveEmailAddressIfMultipleMatch", "unresolveemailaddressifmultiplematch", value);
				}
			}

			/// <summary>
			/// Flag indicates whether to Use Inbuilt Rule For DefaultPricelist.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("useinbuiltrulefordefaultpricelistselection")]
			public System.Nullable<bool> UseInbuiltRuleForDefaultPricelistSelection {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("useinbuiltrulefordefaultpricelistselection");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("UseInbuiltRuleForDefaultPricelistSelection", "useinbuiltrulefordefaultpricelistselection", value);
				}
			}

			/// <summary>
			/// Select whether to use legacy form rendering.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("uselegacyrendering")]
			public System.Nullable<bool> UseLegacyRendering {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("uselegacyrendering");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("UseLegacyRendering", "uselegacyrendering", value);
				}
			}

			/// <summary>
			/// Use position hierarchy
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("usepositionhierarchy")]
			public System.Nullable<bool> UsePositionHierarchy {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("usepositionhierarchy");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("UsePositionHierarchy", "usepositionhierarchy", value);
				}
			}

			/// <summary>
			/// The interval at which user access is checked for auditing.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("useraccessauditinginterval")]
			public System.Nullable<int> UserAccessAuditingInterval {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("useraccessauditinginterval");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("UserAccessAuditingInterval", "useraccessauditinginterval", value);
				}
			}

			/// <summary>
			/// Indicates whether the read-optimized form should be enabled for this organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("usereadform")]
			public System.Nullable<bool> UseReadForm {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("usereadform");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("UseReadForm", "usereadform", value);
				}
			}

			/// <summary>
			/// Unique identifier of the default group of users in the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("usergroupid")]
			public System.Nullable<System.Guid> UserGroupId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("usergroupid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("UserGroupId", "usergroupid", value);
				}
			}

			/// <summary>
			/// Indicates default protocol selected for organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("useskypeprotocol")]
			public System.Nullable<bool> UseSkypeProtocol {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("useskypeprotocol");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("UseSkypeProtocol", "useskypeprotocol", value);
				}
			}

			/// <summary>
			/// Time zone code that was in use when the record was created.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("utcconversiontimezonecode")]
			public System.Nullable<int> UTCConversionTimeZoneCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("utcconversiontimezonecode");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("UTCConversionTimeZoneCode", "utcconversiontimezonecode", value);
				}
			}

			/// <summary>
			/// Hash of the V3 callout configuration file.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("v3calloutconfighash")]
			public string V3CalloutConfigHash {
				get {
					return this.GetAttributeValue<string>("v3calloutconfighash");
				}
			}

			/// <summary>
			/// Version number of the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
			public System.Nullable<long> VersionNumber {
				get {
					return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
				}
			}

			/// <summary>
			/// Hash value of web resources.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("webresourcehash")]
			public string WebResourceHash {
				get {
					return this.GetAttributeValue<string>("webresourcehash");
				}
				set {
					this.SetAttributeValue<string>("WebResourceHash", "webresourcehash", value);
				}
			}

			/// <summary>
			/// Designated first day of the week throughout Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("weekstartdaycode")]
			public System.Nullable<int> WeekStartDayCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("weekstartdaycode");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("WeekStartDayCode", "weekstartdaycode", value);
				}
			}

			/// <summary>
			/// For Internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("widgetproperties")]
			public string WidgetProperties {
				get {
					return this.GetAttributeValue<string>("widgetproperties");
				}
				set {
					this.SetAttributeValue<string>("WidgetProperties", "widgetproperties", value);
				}
			}

			/// <summary>
			/// Denotes the Yammer group ID
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("yammergroupid")]
			public System.Nullable<int> YammerGroupId {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("yammergroupid");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("YammerGroupId", "yammergroupid", value);
				}
			}

			/// <summary>
			/// Denotes the Yammer network permalink
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("yammernetworkpermalink")]
			public string YammerNetworkPermalink {
				get {
					return this.GetAttributeValue<string>("yammernetworkpermalink");
				}
				set {
					this.SetAttributeValue<string>("YammerNetworkPermalink", "yammernetworkpermalink", value);
				}
			}

			/// <summary>
			/// Denotes whether the OAuth access token for Yammer network has expired
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("yammeroauthaccesstokenexpired")]
			public System.Nullable<bool> YammerOAuthAccessTokenExpired {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("yammeroauthaccesstokenexpired");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("YammerOAuthAccessTokenExpired", "yammeroauthaccesstokenexpired", value);
				}
			}

			/// <summary>
			/// Internal Use Only
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("yammerpostmethod")]
			public System.Nullable<int> YammerPostMethod {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("yammerpostmethod");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("YammerPostMethod", "yammerpostmethod", value);
				}
			}

			/// <summary>
			/// Information that specifies how the first week of the year is specified in Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("yearstartweekcode")]
			public System.Nullable<int> YearStartWeekCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("yearstartweekcode");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("YearStartWeekCode", "yearstartweekcode", value);
				}
			}

			/// <summary>
			/// Constructor for populating via LINQ queries given a LINQ anonymous type
			/// <param name="anonymousType">LINQ anonymous type.</param>
			/// </summary>
			public Organization(object anonymousType) :
					this() {
				foreach (var p in anonymousType.GetType().GetProperties()) {
					var value = p.GetValue(anonymousType, null);
					var name = p.Name.ToLower();

					if (name.EndsWith("enum") && value.GetType().BaseType == typeof(System.Enum)) {
						value = new Microsoft.Xrm.Sdk.OptionSetValue((int)value);
						name = name.Remove(name.Length - "enum".Length);
					}

					switch (name) {
						case "id":
							base.Id = (System.Guid)value;
							Attributes["organizationid"] = base.Id;
							break;
						case "organizationid":
							var id = (System.Nullable<System.Guid>)value;
							if (id == null) { continue; }
							base.Id = id.Value;
							Attributes[name] = base.Id;
							break;
						case "formattedvalues":
							// Add Support for FormattedValues
							FormattedValues.AddRange((Microsoft.Xrm.Sdk.FormattedValueCollection)value);
							break;
						default:
							Attributes[name] = value;
							break;
					}
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("currencydisplayoption")]
			public virtual Organization_CurrencyDisplayOption? CurrencyDisplayOptionEnum {
				get {
					return ((Organization_CurrencyDisplayOption?)(EntityOptionSetEnum.GetEnum(this, "currencydisplayoption")));
				}
				set {
					CurrencyDisplayOption = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("defaultrecurrenceendrangetype")]
			public virtual Organization_DefaultRecurrenceEndRangeType? DefaultRecurrenceEndRangeTypeEnum {
				get {
					return ((Organization_DefaultRecurrenceEndRangeType?)(EntityOptionSetEnum.GetEnum(this, "defaultrecurrenceendrangetype")));
				}
				set {
					DefaultRecurrenceEndRangeType = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("discountcalculationmethod")]
			public virtual Organization_DiscountCalculationMethod? DiscountCalculationMethodEnum {
				get {
					return ((Organization_DiscountCalculationMethod?)(EntityOptionSetEnum.GetEnum(this, "discountcalculationmethod")));
				}
				set {
					DiscountCalculationMethod = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("emailconnectionchannel")]
			public virtual Organization_EmailConnectionChannel? EmailConnectionChannelEnum {
				get {
					return ((Organization_EmailConnectionChannel?)(EntityOptionSetEnum.GetEnum(this, "emailconnectionchannel")));
				}
				set {
					EmailConnectionChannel = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("fiscalperiodformatperiod")]
			public virtual Organization_FiscalPeriodFormatPeriod? FiscalPeriodFormatPeriodEnum {
				get {
					return ((Organization_FiscalPeriodFormatPeriod?)(EntityOptionSetEnum.GetEnum(this, "fiscalperiodformatperiod")));
				}
				set {
					FiscalPeriodFormatPeriod = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("fiscalyearformatprefix")]
			public virtual Organization_FiscalYearFormatPrefix? FiscalYearFormatPrefixEnum {
				get {
					return ((Organization_FiscalYearFormatPrefix?)(EntityOptionSetEnum.GetEnum(this, "fiscalyearformatprefix")));
				}
				set {
					FiscalYearFormatPrefix = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("fiscalyearformatsuffix")]
			public virtual Organization_FiscalYearFormatSuffix? FiscalYearFormatSuffixEnum {
				get {
					return ((Organization_FiscalYearFormatSuffix?)(EntityOptionSetEnum.GetEnum(this, "fiscalyearformatsuffix")));
				}
				set {
					FiscalYearFormatSuffix = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("fiscalyearformatyear")]
			public virtual Organization_FiscalYearFormatYear? FiscalYearFormatYearEnum {
				get {
					return ((Organization_FiscalYearFormatYear?)(EntityOptionSetEnum.GetEnum(this, "fiscalyearformatyear")));
				}
				set {
					FiscalYearFormatYear = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("fullnameconventioncode")]
			public virtual Organization_FullNameConventionCode? FullNameConventionCodeEnum {
				get {
					return ((Organization_FullNameConventionCode?)(EntityOptionSetEnum.GetEnum(this, "fullnameconventioncode")));
				}
				set {
					FullNameConventionCode = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("negativeformatcode")]
			public virtual Organization_NegativeFormatCode? NegativeFormatCodeEnum {
				get {
					return ((Organization_NegativeFormatCode?)(EntityOptionSetEnum.GetEnum(this, "negativeformatcode")));
				}
				set {
					NegativeFormatCode = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("plugintracelogsetting")]
			public virtual Organization_PluginTraceLogSetting? PluginTraceLogSettingEnum {
				get {
					return ((Organization_PluginTraceLogSetting?)(EntityOptionSetEnum.GetEnum(this, "plugintracelogsetting")));
				}
				set {
					PluginTraceLogSetting = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("reportscripterrors")]
			public virtual Organization_ReportScriptErrors? ReportScriptErrorsEnum {
				get {
					return ((Organization_ReportScriptErrors?)(EntityOptionSetEnum.GetEnum(this, "reportscripterrors")));
				}
				set {
					ReportScriptErrors = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sharepointdeploymenttype")]
			public virtual Organization_SharePointDeploymentType? SharePointDeploymentTypeEnum {
				get {
					return ((Organization_SharePointDeploymentType?)(EntityOptionSetEnum.GetEnum(this, "sharepointdeploymenttype")));
				}
				set {
					SharePointDeploymentType = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("yammerpostmethod")]
			public virtual Organization_YammerPostMethod? YammerPostMethodEnum {
				get {
					return ((Organization_YammerPostMethod?)(EntityOptionSetEnum.GetEnum(this, "yammerpostmethod")));
				}
				set {
					YammerPostMethod = (int?)value;
				}
			}
		}

		/// <summary>
		/// System chart attached to an entity.
		/// </summary>
		[System.Runtime.Serialization.DataContractAttribute()]
		[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("savedqueryvisualization")]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.0.0.9369")]
		[System.Data.Services.Common.DataServiceKeyAttribute("Id")]
		[System.Data.Services.IgnorePropertiesAttribute("Item", "Attributes", "EntityState", "FormattedValues", "RelatedEntities", "ExtensionData")]
		[Microsoft.Xrm.Client.Metadata.EntityAttribute("SavedQueryVisualizationSet")]
		public partial class SavedQueryVisualization : Microsoft.Xrm.Client.CrmEntity {

			public static class Fields {
				public const string CanBeDeleted = "canbedeleted";
				public const string ChartType = "charttype";
				public const string ComponentState = "componentstate";
				public const string CreatedBy = "createdby";
				public const string CreatedOn = "createdon";
				public const string CreatedOnBehalfBy = "createdonbehalfby";
				public const string DataDescription = "datadescription";
				public const string Description = "description";
				public const string IntroducedVersion = "introducedversion";
				public const string IsCustomizable = "iscustomizable";
				public const string IsDefault = "isdefault";
				public const string IsManaged = "ismanaged";
				public const string ModifiedBy = "modifiedby";
				public const string ModifiedOn = "modifiedon";
				public const string ModifiedOnBehalfBy = "modifiedonbehalfby";
				public const string Name = "name";
				public const string OrganizationId = "organizationid";
				public const string OverwriteTime = "overwritetime";
				public const string PresentationDescription = "presentationdescription";
				public const string PrimaryEntityTypeCode = "primaryentitytypecode";
				public const string SavedQueryVisualizationId = "savedqueryvisualizationid";
				public const string Id = "savedqueryvisualizationid";
				public const string SavedQueryVisualizationIdUnique = "savedqueryvisualizationidunique";
				public const string SolutionId = "solutionid";
				public const string Type = "type";
				public const string VersionNumber = "versionnumber";
				public const string WebResourceId = "webresourceid";
			}

			/// <summary>
			/// Default Constructor.
			/// </summary>
			public SavedQueryVisualization() :
					base(EntityLogicalName) {
			}

			public const string EntityLogicalName = "savedqueryvisualization";

			public const string PrimaryIdAttribute = "savedqueryvisualizationid";

			public const string PrimaryNameAttribute = "name";

			public const int EntityTypeCode = 1111;

			/// <summary>
			/// Tells whether the saved query visualization can be deleted.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("canbedeleted")]
			public Microsoft.Xrm.Sdk.BooleanManagedProperty CanBeDeleted {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.BooleanManagedProperty>("canbedeleted");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.BooleanManagedProperty>("CanBeDeleted", "canbedeleted", value);
				}
			}

			/// <summary>
			/// Indicates the library used to render the visualization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("charttype")]
			public System.Nullable<int> ChartType {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("charttype");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("ChartType", "charttype", value);
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("componentstate")]
			public System.Nullable<int> ComponentState {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("componentstate");
				}
			}

			/// <summary>
			/// Unique identifier of the user who created the system chart.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
			public Microsoft.Xrm.Client.CrmEntityReference CreatedBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
				}
			}

			/// <summary>
			/// Date and time when the system chart was created.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
			public System.Nullable<System.DateTime> CreatedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
				}
			}

			/// <summary>
			/// Unique identifier of the delegate user who created the system chart.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
			public Microsoft.Xrm.Client.CrmEntityReference CreatedOnBehalfBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("CreatedOnBehalfBy", "createdonbehalfby", value);
				}
			}

			/// <summary>
			/// XML string used to define the underlying data for the system chart.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("datadescription")]
			public string DataDescription {
				get {
					return this.GetAttributeValue<string>("datadescription");
				}
				set {
					this.SetAttributeValue<string>("DataDescription", "datadescription", value);
				}
			}

			/// <summary>
			/// Description of the system chart.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("description")]
			public string Description {
				get {
					return this.GetAttributeValue<string>("description");
				}
				set {
					this.SetAttributeValue<string>("Description", "description", value);
				}
			}

			/// <summary>
			/// Version in which the form is introduced.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("introducedversion")]
			public string IntroducedVersion {
				get {
					return this.GetAttributeValue<string>("introducedversion");
				}
				set {
					this.SetAttributeValue<string>("IntroducedVersion", "introducedversion", value);
				}
			}

			/// <summary>
			/// Information that specifies whether this component can be customized.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("iscustomizable")]
			public Microsoft.Xrm.Sdk.BooleanManagedProperty IsCustomizable {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.BooleanManagedProperty>("iscustomizable");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.BooleanManagedProperty>("IsCustomizable", "iscustomizable", value);
				}
			}

			/// <summary>
			/// Indicates whether the system chart is the default chart for the entity.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isdefault")]
			public System.Nullable<bool> IsDefault {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isdefault");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsDefault", "isdefault", value);
				}
			}

			/// <summary>
			/// Indicates whether the solution component is part of a managed solution.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ismanaged")]
			public System.Nullable<bool> IsManaged {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("ismanaged");
				}
			}

			/// <summary>
			/// Unique identifier of the user who last modified the system chart.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
			public Microsoft.Xrm.Client.CrmEntityReference ModifiedBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
				}
			}

			/// <summary>
			/// Date and time when the system chart was last modified.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
			public System.Nullable<System.DateTime> ModifiedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
				}
			}

			/// <summary>
			/// Unique identifier of the delegate user who last modified the system chart.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
			public Microsoft.Xrm.Client.CrmEntityReference ModifiedOnBehalfBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ModifiedOnBehalfBy", "modifiedonbehalfby", value);
				}
			}

			/// <summary>
			/// Name of the system chart.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("name")]
			public string Name {
				get {
					return this.GetAttributeValue<string>("name");
				}
				set {
					this.SetAttributeValue<string>("Name", "name", value);
				}
			}

			/// <summary>
			/// Unique identifier of the organization associated with the system chart.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("organizationid")]
			public Microsoft.Xrm.Client.CrmEntityReference OrganizationId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("organizationid");
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("overwritetime")]
			public System.Nullable<System.DateTime> OverwriteTime {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("overwritetime");
				}
			}

			/// <summary>
			/// XML string used to define the presentation properties of the system chart.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("presentationdescription")]
			public string PresentationDescription {
				get {
					return this.GetAttributeValue<string>("presentationdescription");
				}
				set {
					this.SetAttributeValue<string>("PresentationDescription", "presentationdescription", value);
				}
			}

			/// <summary>
			/// Type of entity with which the system chart is attached.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("primaryentitytypecode")]
			public string PrimaryEntityTypeCode {
				get {
					return this.GetAttributeValue<string>("primaryentitytypecode");
				}
				set {
					this.SetAttributeValue<string>("PrimaryEntityTypeCode", "primaryentitytypecode", value);
				}
			}

			/// <summary>
			/// Unique identifier of the system chart.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("savedqueryvisualizationid")]
			public System.Nullable<System.Guid> SavedQueryVisualizationId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("savedqueryvisualizationid");
				}
				set {
					this.SetPrimaryIdAttributeValue<System.Nullable<System.Guid>>("SavedQueryVisualizationId", "savedqueryvisualizationid", value);
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("savedqueryvisualizationid")]
			public override System.Guid Id {
				get {
					return base.Id;
				}
				set {
					this.SavedQueryVisualizationId = value;
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("savedqueryvisualizationidunique")]
			public System.Nullable<System.Guid> SavedQueryVisualizationIdUnique {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("savedqueryvisualizationidunique");
				}
			}

			/// <summary>
			/// Unique identifier of the associated solution.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("solutionid")]
			public System.Nullable<System.Guid> SolutionId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("solutionid");
				}
			}

			/// <summary>
			/// Specifies where the chart will be used, 0 for data centric as well as interaction centric and 1 for just interaction centric
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("type")]
			public System.Nullable<int> Type {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("type");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("Type", "type", value);
				}
			}

			/// <summary>
			/// Version number of the system chart.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
			public System.Nullable<long> VersionNumber {
				get {
					return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
				}
			}

			/// <summary>
			/// Unique identifier of the Web resource that will be displayed in the system chart.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("webresourceid")]
			public Microsoft.Xrm.Client.CrmEntityReference WebResourceId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("webresourceid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("WebResourceId", "webresourceid", value);
				}
			}

			/// <summary>
			/// Constructor for populating via LINQ queries given a LINQ anonymous type
			/// <param name="anonymousType">LINQ anonymous type.</param>
			/// </summary>
			public SavedQueryVisualization(object anonymousType) :
					this() {
				foreach (var p in anonymousType.GetType().GetProperties()) {
					var value = p.GetValue(anonymousType, null);
					var name = p.Name.ToLower();

					if (name.EndsWith("enum") && value.GetType().BaseType == typeof(System.Enum)) {
						value = new Microsoft.Xrm.Sdk.OptionSetValue((int)value);
						name = name.Remove(name.Length - "enum".Length);
					}

					switch (name) {
						case "id":
							base.Id = (System.Guid)value;
							Attributes["savedqueryvisualizationid"] = base.Id;
							break;
						case "savedqueryvisualizationid":
							var id = (System.Nullable<System.Guid>)value;
							if (id == null) { continue; }
							base.Id = id.Value;
							Attributes[name] = base.Id;
							break;
						case "formattedvalues":
							// Add Support for FormattedValues
							FormattedValues.AddRange((Microsoft.Xrm.Sdk.FormattedValueCollection)value);
							break;
						default:
							Attributes[name] = value;
							break;
					}
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("charttype")]
			public virtual SavedQueryVisualization_ChartType? ChartTypeEnum {
				get {
					return ((SavedQueryVisualization_ChartType?)(EntityOptionSetEnum.GetEnum(this, "charttype")));
				}
				set {
					ChartType = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("componentstate")]
			public virtual ComponentState? ComponentStateEnum {
				get {
					return ((ComponentState?)(EntityOptionSetEnum.GetEnum(this, "componentstate")));
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("type")]
			public virtual SavedQueryVisualization_Type? TypeEnum {
				get {
					return ((SavedQueryVisualization_Type?)(EntityOptionSetEnum.GetEnum(this, "type")));
				}
				set {
					Type = (int?)value;
				}
			}
		}

		/// <summary>
		/// Organization-owned entity customizations including form layout and dashboards.
		/// </summary>
		[System.Runtime.Serialization.DataContractAttribute()]
		[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("systemform")]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.0.0.9369")]
		[System.Data.Services.Common.DataServiceKeyAttribute("Id")]
		[System.Data.Services.IgnorePropertiesAttribute("Item", "Attributes", "EntityState", "FormattedValues", "RelatedEntities", "ExtensionData")]
		[Microsoft.Xrm.Client.Metadata.EntityAttribute("SystemFormSet")]
		public partial class SystemForm : Microsoft.Xrm.Client.CrmEntity {

			public static class Fields {
				public const string AncestorFormId = "ancestorformid";
				public const string CanBeDeleted = "canbedeleted";
				public const string ComponentState = "componentstate";
				public const string Description = "description";
				public const string FormActivationState = "formactivationstate";
				public const string FormId = "formid";
				public const string Id = "formid";
				public const string FormIdUnique = "formidunique";
				public const string FormPresentation = "formpresentation";
				public const string FormXml = "formxml";
				public const string IntroducedVersion = "introducedversion";
				public const string IsAIRMerged = "isairmerged";
				public const string IsCustomizable = "iscustomizable";
				public const string IsDefault = "isdefault";
				public const string IsDesktopEnabled = "isdesktopenabled";
				public const string IsManaged = "ismanaged";
				public const string IsTabletEnabled = "istabletenabled";
				public const string Name = "name";
				public const string ObjectTypeCode = "objecttypecode";
				public const string OrganizationId = "organizationid";
				public const string OverwriteTime = "overwritetime";
				public const string PublishedOn = "publishedon";
				public const string SolutionId = "solutionid";
				public const string Type = "type";
				public const string UniqueName = "uniquename";
				public const string Version = "version";
				public const string VersionNumber = "versionnumber";
			}

			/// <summary>
			/// Default Constructor.
			/// </summary>
			public SystemForm() :
					base(EntityLogicalName) {
			}

			public const string EntityLogicalName = "systemform";

			public const string PrimaryIdAttribute = "formid";

			public const string PrimaryNameAttribute = "name";

			public const int EntityTypeCode = 1030;

			/// <summary>
			/// Unique identifier of the parent form.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ancestorformid")]
			public Microsoft.Xrm.Client.CrmEntityReference AncestorFormId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ancestorformid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("AncestorFormId", "ancestorformid", value);
				}
			}

			/// <summary>
			/// Information that specifies whether this component can be deleted.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("canbedeleted")]
			public Microsoft.Xrm.Sdk.BooleanManagedProperty CanBeDeleted {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.BooleanManagedProperty>("canbedeleted");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.BooleanManagedProperty>("CanBeDeleted", "canbedeleted", value);
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("componentstate")]
			public System.Nullable<int> ComponentState {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("componentstate");
				}
			}

			/// <summary>
			/// Description of the form or dashboard.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("description")]
			public string Description {
				get {
					return this.GetAttributeValue<string>("description");
				}
				set {
					this.SetAttributeValue<string>("Description", "description", value);
				}
			}

			/// <summary>
			/// Specifies the state of the form.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("formactivationstate")]
			public System.Nullable<int> FormActivationState {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("formactivationstate");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("FormActivationState", "formactivationstate", value);
				}
			}

			/// <summary>
			/// Unique identifier of the record type form.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("formid")]
			public System.Nullable<System.Guid> FormId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("formid");
				}
				set {
					this.SetPrimaryIdAttributeValue<System.Nullable<System.Guid>>("FormId", "formid", value);
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("formid")]
			public override System.Guid Id {
				get {
					return base.Id;
				}
				set {
					this.FormId = value;
				}
			}

			/// <summary>
			/// Unique identifier of the form used when synchronizing customizations for the Microsoft Dynamics 365 client for Outlook.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("formidunique")]
			public System.Nullable<System.Guid> FormIdUnique {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("formidunique");
				}
			}

			/// <summary>
			/// Specifies whether this form is in the updated UI layout in Microsoft Dynamics CRM 2015 or Microsoft Dynamics CRM Online 2015 Update.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("formpresentation")]
			public System.Nullable<int> FormPresentation {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("formpresentation");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("FormPresentation", "formpresentation", value);
				}
			}

			/// <summary>
			/// XML representation of the form layout.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("formxml")]
			public string FormXml {
				get {
					return this.GetAttributeValue<string>("formxml");
				}
				set {
					this.SetAttributeValue<string>("FormXml", "formxml", value);
				}
			}

			/// <summary>
			/// Version in which the form is introduced.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("introducedversion")]
			public string IntroducedVersion {
				get {
					return this.GetAttributeValue<string>("introducedversion");
				}
				set {
					this.SetAttributeValue<string>("IntroducedVersion", "introducedversion", value);
				}
			}

			/// <summary>
			/// Specifies whether this form is merged with the updated UI layout in Microsoft Dynamics CRM 2015 or Microsoft Dynamics CRM Online 2015 Update.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isairmerged")]
			public System.Nullable<bool> IsAIRMerged {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isairmerged");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsAIRMerged", "isairmerged", value);
				}
			}

			/// <summary>
			/// Information that specifies whether this component can be customized.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("iscustomizable")]
			public Microsoft.Xrm.Sdk.BooleanManagedProperty IsCustomizable {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.BooleanManagedProperty>("iscustomizable");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.BooleanManagedProperty>("IsCustomizable", "iscustomizable", value);
				}
			}

			/// <summary>
			/// Information that specifies whether the form or the dashboard is the system default.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isdefault")]
			public System.Nullable<bool> IsDefault {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isdefault");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsDefault", "isdefault", value);
				}
			}

			/// <summary>
			/// Information that specifies whether the dashboard is enabled for desktop.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isdesktopenabled")]
			public System.Nullable<bool> IsDesktopEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isdesktopenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsDesktopEnabled", "isdesktopenabled", value);
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ismanaged")]
			public System.Nullable<bool> IsManaged {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("ismanaged");
				}
			}

			/// <summary>
			/// Information that specifies whether the dashboard is enabled for tablet.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("istabletenabled")]
			public System.Nullable<bool> IsTabletEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("istabletenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsTabletEnabled", "istabletenabled", value);
				}
			}

			/// <summary>
			/// Name of the form.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("name")]
			public string Name {
				get {
					return this.GetAttributeValue<string>("name");
				}
				set {
					this.SetAttributeValue<string>("Name", "name", value);
				}
			}

			/// <summary>
			/// Code that represents the record type.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("objecttypecode")]
			public string ObjectTypeCode {
				get {
					return this.GetAttributeValue<string>("objecttypecode");
				}
				set {
					this.SetAttributeValue<string>("ObjectTypeCode", "objecttypecode", value);
				}
			}

			/// <summary>
			/// Unique identifier of the organization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("organizationid")]
			public Microsoft.Xrm.Client.CrmEntityReference OrganizationId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("organizationid");
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("overwritetime")]
			public System.Nullable<System.DateTime> OverwriteTime {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("overwritetime");
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("publishedon")]
			public System.Nullable<System.DateTime> PublishedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("publishedon");
				}
			}

			/// <summary>
			/// Unique identifier of the associated solution.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("solutionid")]
			public System.Nullable<System.Guid> SolutionId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("solutionid");
				}
			}

			/// <summary>
			/// Type of the form, for example, Dashboard or Preview.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("type")]
			public System.Nullable<int> Type {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("type");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("Type", "type", value);
				}
			}

			/// <summary>
			/// Unique Name
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("uniquename")]
			public string UniqueName {
				get {
					return this.GetAttributeValue<string>("uniquename");
				}
				set {
					this.SetAttributeValue<string>("UniqueName", "uniquename", value);
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("version")]
			public System.Nullable<int> Version {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("version");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("Version", "version", value);
				}
			}

			/// <summary>
			/// Represents a version of customizations to be synchronized with the Microsoft Dynamics 365 client for Outlook.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
			public System.Nullable<long> VersionNumber {
				get {
					return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
				}
			}

			/// <summary>
			/// Constructor for populating via LINQ queries given a LINQ anonymous type
			/// <param name="anonymousType">LINQ anonymous type.</param>
			/// </summary>
			public SystemForm(object anonymousType) :
					this() {
				foreach (var p in anonymousType.GetType().GetProperties()) {
					var value = p.GetValue(anonymousType, null);
					var name = p.Name.ToLower();

					if (name.EndsWith("enum") && value.GetType().BaseType == typeof(System.Enum)) {
						value = new Microsoft.Xrm.Sdk.OptionSetValue((int)value);
						name = name.Remove(name.Length - "enum".Length);
					}

					switch (name) {
						case "id":
							base.Id = (System.Guid)value;
							Attributes["formid"] = base.Id;
							break;
						case "formid":
							var id = (System.Nullable<System.Guid>)value;
							if (id == null) { continue; }
							base.Id = id.Value;
							Attributes[name] = base.Id;
							break;
						case "formattedvalues":
							// Add Support for FormattedValues
							FormattedValues.AddRange((Microsoft.Xrm.Sdk.FormattedValueCollection)value);
							break;
						default:
							Attributes[name] = value;
							break;
					}
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("componentstate")]
			public virtual ComponentState? ComponentStateEnum {
				get {
					return ((ComponentState?)(EntityOptionSetEnum.GetEnum(this, "componentstate")));
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("formactivationstate")]
			public virtual SystemForm_FormActivationState? FormActivationStateEnum {
				get {
					return ((SystemForm_FormActivationState?)(EntityOptionSetEnum.GetEnum(this, "formactivationstate")));
				}
				set {
					FormActivationState = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("formpresentation")]
			public virtual SystemForm_FormPresentation? FormPresentationEnum {
				get {
					return ((SystemForm_FormPresentation?)(EntityOptionSetEnum.GetEnum(this, "formpresentation")));
				}
				set {
					FormPresentation = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("type")]
			public virtual SystemForm_Type? TypeEnum {
				get {
					return ((SystemForm_Type?)(EntityOptionSetEnum.GetEnum(this, "type")));
				}
				set {
					Type = (int?)value;
				}
			}
		}

		/// <summary>
		/// Person with access to the Microsoft CRM system and who owns objects in the Microsoft CRM database.
		/// </summary>
		[System.Runtime.Serialization.DataContractAttribute()]
		[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("systemuser")]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.0.0.9369")]
		[System.Data.Services.Common.DataServiceKeyAttribute("Id")]
		[System.Data.Services.IgnorePropertiesAttribute("Item", "Attributes", "EntityState", "FormattedValues", "RelatedEntities", "ExtensionData")]
		[Microsoft.Xrm.Client.Metadata.EntityAttribute("SystemUserSet")]
		public partial class SystemUser : Microsoft.Xrm.Client.CrmEntity {

			public static class Fields {
				public const string AccessMode = "accessmode";
				public const string Address1_AddressId = "address1_addressid";
				public const string Address1_AddressTypeCode = "address1_addresstypecode";
				public const string Address1_City = "address1_city";
				public const string Address1_Composite = "address1_composite";
				public const string Address1_Country = "address1_country";
				public const string Address1_County = "address1_county";
				public const string Address1_Fax = "address1_fax";
				public const string Address1_Latitude = "address1_latitude";
				public const string Address1_Line1 = "address1_line1";
				public const string Address1_Line2 = "address1_line2";
				public const string Address1_Line3 = "address1_line3";
				public const string Address1_Longitude = "address1_longitude";
				public const string Address1_Name = "address1_name";
				public const string Address1_PostalCode = "address1_postalcode";
				public const string Address1_PostOfficeBox = "address1_postofficebox";
				public const string Address1_ShippingMethodCode = "address1_shippingmethodcode";
				public const string Address1_StateOrProvince = "address1_stateorprovince";
				public const string Address1_Telephone1 = "address1_telephone1";
				public const string Address1_Telephone2 = "address1_telephone2";
				public const string Address1_Telephone3 = "address1_telephone3";
				public const string Address1_UPSZone = "address1_upszone";
				public const string Address1_UTCOffset = "address1_utcoffset";
				public const string Address2_AddressId = "address2_addressid";
				public const string Address2_AddressTypeCode = "address2_addresstypecode";
				public const string Address2_City = "address2_city";
				public const string Address2_Composite = "address2_composite";
				public const string Address2_Country = "address2_country";
				public const string Address2_County = "address2_county";
				public const string Address2_Fax = "address2_fax";
				public const string Address2_Latitude = "address2_latitude";
				public const string Address2_Line1 = "address2_line1";
				public const string Address2_Line2 = "address2_line2";
				public const string Address2_Line3 = "address2_line3";
				public const string Address2_Longitude = "address2_longitude";
				public const string Address2_Name = "address2_name";
				public const string Address2_PostalCode = "address2_postalcode";
				public const string Address2_PostOfficeBox = "address2_postofficebox";
				public const string Address2_ShippingMethodCode = "address2_shippingmethodcode";
				public const string Address2_StateOrProvince = "address2_stateorprovince";
				public const string Address2_Telephone1 = "address2_telephone1";
				public const string Address2_Telephone2 = "address2_telephone2";
				public const string Address2_Telephone3 = "address2_telephone3";
				public const string Address2_UPSZone = "address2_upszone";
				public const string Address2_UTCOffset = "address2_utcoffset";
				public const string ApplicationId = "applicationid";
				public const string ApplicationIdUri = "applicationiduri";
				public const string AzureActiveDirectoryObjectId = "azureactivedirectoryobjectid";
				public const string BusinessUnitId = "businessunitid";
				public const string CalendarId = "calendarid";
				public const string CALType = "caltype";
				public const string col_NewTeamHolder = "col_newteamholder";
				public const string CreatedBy = "createdby";
				public const string CreatedOn = "createdon";
				public const string CreatedOnBehalfBy = "createdonbehalfby";
				public const string DefaultFiltersPopulated = "defaultfilterspopulated";
				public const string DefaultMailbox = "defaultmailbox";
				public const string DefaultOdbFolderName = "defaultodbfoldername";
				public const string DisabledReason = "disabledreason";
				public const string DisplayInServiceViews = "displayinserviceviews";
				public const string DomainName = "domainname";
				public const string EmailRouterAccessApproval = "emailrouteraccessapproval";
				public const string EmployeeId = "employeeid";
				public const string EntityImage = "entityimage";
				public const string EntityImage_Timestamp = "entityimage_timestamp";
				public const string EntityImage_URL = "entityimage_url";
				public const string EntityImageId = "entityimageid";
				public const string ExchangeRate = "exchangerate";
				public const string FirstName = "firstname";
				public const string FullName = "fullname";
				public const string GovernmentId = "governmentid";
				public const string HomePhone = "homephone";
				public const string ImportSequenceNumber = "importsequencenumber";
				public const string IncomingEmailDeliveryMethod = "incomingemaildeliverymethod";
				public const string InternalEMailAddress = "internalemailaddress";
				public const string InviteStatusCode = "invitestatuscode";
				public const string IsDisabled = "isdisabled";
				public const string IsEmailAddressApprovedByO365Admin = "isemailaddressapprovedbyo365admin";
				public const string IsIntegrationUser = "isintegrationuser";
				public const string IsLicensed = "islicensed";
				public const string IsSyncWithDirectory = "issyncwithdirectory";
				public const string JobTitle = "jobtitle";
				public const string LastName = "lastname";
				public const string MiddleName = "middlename";
				public const string MobileAlertEMail = "mobilealertemail";
				public const string MobileOfflineProfileId = "mobileofflineprofileid";
				public const string MobilePhone = "mobilephone";
				public const string ModifiedBy = "modifiedby";
				public const string ModifiedOn = "modifiedon";
				public const string ModifiedOnBehalfBy = "modifiedonbehalfby";
				public const string msus_allow_medibuddy_access = "msus_allow_medibuddy_access";
				public const string msus_DIRPERSONNAME_PERSONID = "msus_dirpersonname_personid";
				public const string msus_fcm_token = "msus_fcm_token";
				public const string msus_HCMWORKER_RECID = "msus_hcmworker_recid";
				public const string msus_ismanager = "msus_ismanager";
				public const string msus_medibuddy_managed_territories = "msus_medibuddy_managed_territories";
				public const string msus_msusa_domain_name = "msus_msusa_domain_name";
				public const string new_ManagerId = "new_managerid";
				public const string new_many_user_to_salesregion = "new_many_user_to_salesregion";
				public const string new_mw_options_case_autogeneratefedexlinks = "new_mw_options_case_autogeneratefedexlinks";
				public const string NickName = "nickname";
				public const string OrganizationId = "organizationid";
				public const string OutgoingEmailDeliveryMethod = "outgoingemaildeliverymethod";
				public const string OverriddenCreatedOn = "overriddencreatedon";
				public const string ParentSystemUserId = "parentsystemuserid";
				public const string PassportHi = "passporthi";
				public const string PassportLo = "passportlo";
				public const string PersonalEMailAddress = "personalemailaddress";
				public const string PhotoUrl = "photourl";
				public const string PositionId = "positionid";
				public const string PreferredAddressCode = "preferredaddresscode";
				public const string PreferredEmailCode = "preferredemailcode";
				public const string PreferredPhoneCode = "preferredphonecode";
				public const string ProcessId = "processid";
				public const string QueueId = "queueid";
				public const string Salutation = "salutation";
				public const string SetupUser = "setupuser";
				public const string SharePointEmailAddress = "sharepointemailaddress";
				public const string SiteId = "siteid";
				public const string Skills = "skills";
				public const string StageId = "stageid";
				public const string SystemUserId = "systemuserid";
				public const string Id = "systemuserid";
				public const string TerritoryId = "territoryid";
				public const string TimeZoneRuleVersionNumber = "timezoneruleversionnumber";
				public const string Title = "title";
				public const string TransactionCurrencyId = "transactioncurrencyid";
				public const string TraversedPath = "traversedpath";
				public const string UserLicenseType = "userlicensetype";
				public const string UTCConversionTimeZoneCode = "utcconversiontimezonecode";
				public const string VersionNumber = "versionnumber";
				public const string WindowsLiveID = "windowsliveid";
				public const string YammerEmailAddress = "yammeremailaddress";
				public const string YammerUserId = "yammeruserid";
				public const string YomiFirstName = "yomifirstname";
				public const string YomiFullName = "yomifullname";
				public const string YomiLastName = "yomilastname";
				public const string YomiMiddleName = "yomimiddlename";
			}

			/// <summary>
			/// Default Constructor.
			/// </summary>
			public SystemUser() :
					base(EntityLogicalName) {
			}

			public const string EntityLogicalName = "systemuser";

			public const string PrimaryIdAttribute = "systemuserid";

			public const string PrimaryNameAttribute = "fullname";

			public const int EntityTypeCode = 8;

			/// <summary>
			/// Type of user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("accessmode")]
			public System.Nullable<int> AccessMode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("accessmode");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("AccessMode", "accessmode", value);
				}
			}

			/// <summary>
			/// Unique identifier for address 1.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_addressid")]
			public System.Nullable<System.Guid> Address1_AddressId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("address1_addressid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("Address1_AddressId", "address1_addressid", value);
				}
			}

			/// <summary>
			/// Type of address for address 1, such as billing, shipping, or primary address.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_addresstypecode")]
			public System.Nullable<int> Address1_AddressTypeCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("address1_addresstypecode");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("Address1_AddressTypeCode", "address1_addresstypecode", value);
				}
			}

			/// <summary>
			/// City name for address 1.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_city")]
			public string Address1_City {
				get {
					return this.GetAttributeValue<string>("address1_city");
				}
				set {
					this.SetAttributeValue<string>("Address1_City", "address1_city", value);
				}
			}

			/// <summary>
			/// Shows the complete primary address.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_composite")]
			public string Address1_Composite {
				get {
					return this.GetAttributeValue<string>("address1_composite");
				}
			}

			/// <summary>
			/// Country/region name in address 1.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_country")]
			public string Address1_Country {
				get {
					return this.GetAttributeValue<string>("address1_country");
				}
				set {
					this.SetAttributeValue<string>("Address1_Country", "address1_country", value);
				}
			}

			/// <summary>
			/// County name for address 1.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_county")]
			public string Address1_County {
				get {
					return this.GetAttributeValue<string>("address1_county");
				}
				set {
					this.SetAttributeValue<string>("Address1_County", "address1_county", value);
				}
			}

			/// <summary>
			/// Fax number for address 1.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_fax")]
			public string Address1_Fax {
				get {
					return this.GetAttributeValue<string>("address1_fax");
				}
				set {
					this.SetAttributeValue<string>("Address1_Fax", "address1_fax", value);
				}
			}

			/// <summary>
			/// Latitude for address 1.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_latitude")]
			public System.Nullable<double> Address1_Latitude {
				get {
					return this.GetAttributeValue<System.Nullable<double>>("address1_latitude");
				}
				set {
					this.SetAttributeValue<System.Nullable<double>>("Address1_Latitude", "address1_latitude", value);
				}
			}

			/// <summary>
			/// First line for entering address 1 information.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_line1")]
			public string Address1_Line1 {
				get {
					return this.GetAttributeValue<string>("address1_line1");
				}
				set {
					this.SetAttributeValue<string>("Address1_Line1", "address1_line1", value);
				}
			}

			/// <summary>
			/// Second line for entering address 1 information.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_line2")]
			public string Address1_Line2 {
				get {
					return this.GetAttributeValue<string>("address1_line2");
				}
				set {
					this.SetAttributeValue<string>("Address1_Line2", "address1_line2", value);
				}
			}

			/// <summary>
			/// Third line for entering address 1 information.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_line3")]
			public string Address1_Line3 {
				get {
					return this.GetAttributeValue<string>("address1_line3");
				}
				set {
					this.SetAttributeValue<string>("Address1_Line3", "address1_line3", value);
				}
			}

			/// <summary>
			/// Longitude for address 1.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_longitude")]
			public System.Nullable<double> Address1_Longitude {
				get {
					return this.GetAttributeValue<System.Nullable<double>>("address1_longitude");
				}
				set {
					this.SetAttributeValue<System.Nullable<double>>("Address1_Longitude", "address1_longitude", value);
				}
			}

			/// <summary>
			/// Name to enter for address 1.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_name")]
			public string Address1_Name {
				get {
					return this.GetAttributeValue<string>("address1_name");
				}
				set {
					this.SetAttributeValue<string>("Address1_Name", "address1_name", value);
				}
			}

			/// <summary>
			/// ZIP Code or postal code for address 1.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_postalcode")]
			public string Address1_PostalCode {
				get {
					return this.GetAttributeValue<string>("address1_postalcode");
				}
				set {
					this.SetAttributeValue<string>("Address1_PostalCode", "address1_postalcode", value);
				}
			}

			/// <summary>
			/// Post office box number for address 1.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_postofficebox")]
			public string Address1_PostOfficeBox {
				get {
					return this.GetAttributeValue<string>("address1_postofficebox");
				}
				set {
					this.SetAttributeValue<string>("Address1_PostOfficeBox", "address1_postofficebox", value);
				}
			}

			/// <summary>
			/// Method of shipment for address 1.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_shippingmethodcode")]
			public System.Nullable<int> Address1_ShippingMethodCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("address1_shippingmethodcode");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("Address1_ShippingMethodCode", "address1_shippingmethodcode", value);
				}
			}

			/// <summary>
			/// State or province for address 1.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_stateorprovince")]
			public string Address1_StateOrProvince {
				get {
					return this.GetAttributeValue<string>("address1_stateorprovince");
				}
				set {
					this.SetAttributeValue<string>("Address1_StateOrProvince", "address1_stateorprovince", value);
				}
			}

			/// <summary>
			/// First telephone number associated with address 1.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_telephone1")]
			public string Address1_Telephone1 {
				get {
					return this.GetAttributeValue<string>("address1_telephone1");
				}
				set {
					this.SetAttributeValue<string>("Address1_Telephone1", "address1_telephone1", value);
				}
			}

			/// <summary>
			/// Second telephone number associated with address 1.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_telephone2")]
			public string Address1_Telephone2 {
				get {
					return this.GetAttributeValue<string>("address1_telephone2");
				}
				set {
					this.SetAttributeValue<string>("Address1_Telephone2", "address1_telephone2", value);
				}
			}

			/// <summary>
			/// Third telephone number associated with address 1.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_telephone3")]
			public string Address1_Telephone3 {
				get {
					return this.GetAttributeValue<string>("address1_telephone3");
				}
				set {
					this.SetAttributeValue<string>("Address1_Telephone3", "address1_telephone3", value);
				}
			}

			/// <summary>
			/// United Parcel Service (UPS) zone for address 1.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_upszone")]
			public string Address1_UPSZone {
				get {
					return this.GetAttributeValue<string>("address1_upszone");
				}
				set {
					this.SetAttributeValue<string>("Address1_UPSZone", "address1_upszone", value);
				}
			}

			/// <summary>
			/// UTC offset for address 1. This is the difference between local time and standard Coordinated Universal Time.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_utcoffset")]
			public System.Nullable<int> Address1_UTCOffset {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("address1_utcoffset");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("Address1_UTCOffset", "address1_utcoffset", value);
				}
			}

			/// <summary>
			/// Unique identifier for address 2.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_addressid")]
			public System.Nullable<System.Guid> Address2_AddressId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("address2_addressid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("Address2_AddressId", "address2_addressid", value);
				}
			}

			/// <summary>
			/// Type of address for address 2, such as billing, shipping, or primary address.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_addresstypecode")]
			public System.Nullable<int> Address2_AddressTypeCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("address2_addresstypecode");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("Address2_AddressTypeCode", "address2_addresstypecode", value);
				}
			}

			/// <summary>
			/// City name for address 2.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_city")]
			public string Address2_City {
				get {
					return this.GetAttributeValue<string>("address2_city");
				}
				set {
					this.SetAttributeValue<string>("Address2_City", "address2_city", value);
				}
			}

			/// <summary>
			/// Shows the complete secondary address.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_composite")]
			public string Address2_Composite {
				get {
					return this.GetAttributeValue<string>("address2_composite");
				}
			}

			/// <summary>
			/// Country/region name in address 2.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_country")]
			public string Address2_Country {
				get {
					return this.GetAttributeValue<string>("address2_country");
				}
				set {
					this.SetAttributeValue<string>("Address2_Country", "address2_country", value);
				}
			}

			/// <summary>
			/// County name for address 2.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_county")]
			public string Address2_County {
				get {
					return this.GetAttributeValue<string>("address2_county");
				}
				set {
					this.SetAttributeValue<string>("Address2_County", "address2_county", value);
				}
			}

			/// <summary>
			/// Fax number for address 2.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_fax")]
			public string Address2_Fax {
				get {
					return this.GetAttributeValue<string>("address2_fax");
				}
				set {
					this.SetAttributeValue<string>("Address2_Fax", "address2_fax", value);
				}
			}

			/// <summary>
			/// Latitude for address 2.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_latitude")]
			public System.Nullable<double> Address2_Latitude {
				get {
					return this.GetAttributeValue<System.Nullable<double>>("address2_latitude");
				}
				set {
					this.SetAttributeValue<System.Nullable<double>>("Address2_Latitude", "address2_latitude", value);
				}
			}

			/// <summary>
			/// First line for entering address 2 information.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_line1")]
			public string Address2_Line1 {
				get {
					return this.GetAttributeValue<string>("address2_line1");
				}
				set {
					this.SetAttributeValue<string>("Address2_Line1", "address2_line1", value);
				}
			}

			/// <summary>
			/// Second line for entering address 2 information.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_line2")]
			public string Address2_Line2 {
				get {
					return this.GetAttributeValue<string>("address2_line2");
				}
				set {
					this.SetAttributeValue<string>("Address2_Line2", "address2_line2", value);
				}
			}

			/// <summary>
			/// Third line for entering address 2 information.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_line3")]
			public string Address2_Line3 {
				get {
					return this.GetAttributeValue<string>("address2_line3");
				}
				set {
					this.SetAttributeValue<string>("Address2_Line3", "address2_line3", value);
				}
			}

			/// <summary>
			/// Longitude for address 2.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_longitude")]
			public System.Nullable<double> Address2_Longitude {
				get {
					return this.GetAttributeValue<System.Nullable<double>>("address2_longitude");
				}
				set {
					this.SetAttributeValue<System.Nullable<double>>("Address2_Longitude", "address2_longitude", value);
				}
			}

			/// <summary>
			/// Name to enter for address 2.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_name")]
			public string Address2_Name {
				get {
					return this.GetAttributeValue<string>("address2_name");
				}
				set {
					this.SetAttributeValue<string>("Address2_Name", "address2_name", value);
				}
			}

			/// <summary>
			/// ZIP Code or postal code for address 2.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_postalcode")]
			public string Address2_PostalCode {
				get {
					return this.GetAttributeValue<string>("address2_postalcode");
				}
				set {
					this.SetAttributeValue<string>("Address2_PostalCode", "address2_postalcode", value);
				}
			}

			/// <summary>
			/// Post office box number for address 2.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_postofficebox")]
			public string Address2_PostOfficeBox {
				get {
					return this.GetAttributeValue<string>("address2_postofficebox");
				}
				set {
					this.SetAttributeValue<string>("Address2_PostOfficeBox", "address2_postofficebox", value);
				}
			}

			/// <summary>
			/// Method of shipment for address 2.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_shippingmethodcode")]
			public System.Nullable<int> Address2_ShippingMethodCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("address2_shippingmethodcode");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("Address2_ShippingMethodCode", "address2_shippingmethodcode", value);
				}
			}

			/// <summary>
			/// State or province for address 2.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_stateorprovince")]
			public string Address2_StateOrProvince {
				get {
					return this.GetAttributeValue<string>("address2_stateorprovince");
				}
				set {
					this.SetAttributeValue<string>("Address2_StateOrProvince", "address2_stateorprovince", value);
				}
			}

			/// <summary>
			/// First telephone number associated with address 2.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_telephone1")]
			public string Address2_Telephone1 {
				get {
					return this.GetAttributeValue<string>("address2_telephone1");
				}
				set {
					this.SetAttributeValue<string>("Address2_Telephone1", "address2_telephone1", value);
				}
			}

			/// <summary>
			/// Second telephone number associated with address 2.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_telephone2")]
			public string Address2_Telephone2 {
				get {
					return this.GetAttributeValue<string>("address2_telephone2");
				}
				set {
					this.SetAttributeValue<string>("Address2_Telephone2", "address2_telephone2", value);
				}
			}

			/// <summary>
			/// Third telephone number associated with address 2.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_telephone3")]
			public string Address2_Telephone3 {
				get {
					return this.GetAttributeValue<string>("address2_telephone3");
				}
				set {
					this.SetAttributeValue<string>("Address2_Telephone3", "address2_telephone3", value);
				}
			}

			/// <summary>
			/// United Parcel Service (UPS) zone for address 2.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_upszone")]
			public string Address2_UPSZone {
				get {
					return this.GetAttributeValue<string>("address2_upszone");
				}
				set {
					this.SetAttributeValue<string>("Address2_UPSZone", "address2_upszone", value);
				}
			}

			/// <summary>
			/// UTC offset for address 2. This is the difference between local time and standard Coordinated Universal Time.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_utcoffset")]
			public System.Nullable<int> Address2_UTCOffset {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("address2_utcoffset");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("Address2_UTCOffset", "address2_utcoffset", value);
				}
			}

			/// <summary>
			/// The identifier for the application. This is used to access data in another application.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("applicationid")]
			public System.Nullable<System.Guid> ApplicationId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("applicationid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("ApplicationId", "applicationid", value);
				}
			}

			/// <summary>
			/// The URI used as a unique logical identifier for the external app. This can be used to validate the application.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("applicationiduri")]
			public string ApplicationIdUri {
				get {
					return this.GetAttributeValue<string>("applicationiduri");
				}
			}

			/// <summary>
			/// This is the application directory object Id.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("azureactivedirectoryobjectid")]
			public System.Nullable<System.Guid> AzureActiveDirectoryObjectId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("azureactivedirectoryobjectid");
				}
			}

			/// <summary>
			/// Unique identifier of the business unit with which the user is associated.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("businessunitid")]
			public Microsoft.Xrm.Client.CrmEntityReference BusinessUnitId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("businessunitid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("BusinessUnitId", "businessunitid", value);
				}
			}

			/// <summary>
			/// Fiscal calendar associated with the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("calendarid")]
			public Microsoft.Xrm.Client.CrmEntityReference CalendarId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("calendarid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("CalendarId", "calendarid", value);
				}
			}

			/// <summary>
			/// License type of user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("caltype")]
			public System.Nullable<int> CALType {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("caltype");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("CALType", "caltype", value);
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("col_newteamholder")]
			public Microsoft.Xrm.Client.CrmEntityReference col_NewTeamHolder {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("col_newteamholder");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("col_NewTeamHolder", "col_newteamholder", value);
				}
			}

			/// <summary>
			/// Unique identifier of the user who created the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
			public Microsoft.Xrm.Client.CrmEntityReference CreatedBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
				}
			}

			/// <summary>
			/// Date and time when the user was created.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
			public System.Nullable<System.DateTime> CreatedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
				}
			}

			/// <summary>
			/// Unique identifier of the delegate user who created the systemuser.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
			public Microsoft.Xrm.Client.CrmEntityReference CreatedOnBehalfBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("CreatedOnBehalfBy", "createdonbehalfby", value);
				}
			}

			/// <summary>
			/// Indicates if default outlook filters have been populated.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("defaultfilterspopulated")]
			public System.Nullable<bool> DefaultFiltersPopulated {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("defaultfilterspopulated");
				}
			}

			/// <summary>
			/// Select the mailbox associated with this user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("defaultmailbox")]
			public Microsoft.Xrm.Client.CrmEntityReference DefaultMailbox {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("defaultmailbox");
				}
			}

			/// <summary>
			/// Type a default folder name for the user's OneDrive For Business location.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("defaultodbfoldername")]
			public string DefaultOdbFolderName {
				get {
					return this.GetAttributeValue<string>("defaultodbfoldername");
				}
			}

			/// <summary>
			/// Reason for disabling the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("disabledreason")]
			public string DisabledReason {
				get {
					return this.GetAttributeValue<string>("disabledreason");
				}
			}

			/// <summary>
			/// Whether to display the user in service views.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("displayinserviceviews")]
			public System.Nullable<bool> DisplayInServiceViews {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("displayinserviceviews");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("DisplayInServiceViews", "displayinserviceviews", value);
				}
			}

			/// <summary>
			/// Active Directory domain of which the user is a member.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("domainname")]
			public string DomainName {
				get {
					return this.GetAttributeValue<string>("domainname");
				}
				set {
					this.SetAttributeValue<string>("DomainName", "domainname", value);
				}
			}

			/// <summary>
			/// Shows the status of the primary email address.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("emailrouteraccessapproval")]
			public System.Nullable<int> EmailRouterAccessApproval {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("emailrouteraccessapproval");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("EmailRouterAccessApproval", "emailrouteraccessapproval", value);
				}
			}

			/// <summary>
			/// Employee identifier for the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("employeeid")]
			public string EmployeeId {
				get {
					return this.GetAttributeValue<string>("employeeid");
				}
				set {
					this.SetAttributeValue<string>("EmployeeId", "employeeid", value);
				}
			}

			/// <summary>
			/// Shows the default image for the record.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityimage")]
			public byte[] EntityImage {
				get {
					return this.GetAttributeValue<byte[]>("entityimage");
				}
				set {
					this.SetAttributeValue<byte[]>("EntityImage", "entityimage", value);
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityimage_timestamp")]
			public System.Nullable<long> EntityImage_Timestamp {
				get {
					return this.GetAttributeValue<System.Nullable<long>>("entityimage_timestamp");
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityimage_url")]
			public string EntityImage_URL {
				get {
					return this.GetAttributeValue<string>("entityimage_url");
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityimageid")]
			public System.Nullable<System.Guid> EntityImageId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("entityimageid");
				}
			}

			/// <summary>
			/// Exchange rate for the currency associated with the systemuser with respect to the base currency.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("exchangerate")]
			public System.Nullable<decimal> ExchangeRate {
				get {
					return this.GetAttributeValue<System.Nullable<decimal>>("exchangerate");
				}
			}

			/// <summary>
			/// First name of the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("firstname")]
			public string FirstName {
				get {
					return this.GetAttributeValue<string>("firstname");
				}
				set {
					this.SetAttributeValue<string>("FirstName", "firstname", value);
				}
			}

			/// <summary>
			/// Full name of the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("fullname")]
			public string FullName {
				get {
					return this.GetAttributeValue<string>("fullname");
				}
			}

			/// <summary>
			/// Government identifier for the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("governmentid")]
			public string GovernmentId {
				get {
					return this.GetAttributeValue<string>("governmentid");
				}
				set {
					this.SetAttributeValue<string>("GovernmentId", "governmentid", value);
				}
			}

			/// <summary>
			/// Home phone number for the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("homephone")]
			public string HomePhone {
				get {
					return this.GetAttributeValue<string>("homephone");
				}
				set {
					this.SetAttributeValue<string>("HomePhone", "homephone", value);
				}
			}

			/// <summary>
			/// Unique identifier of the data import or data migration that created this record.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("importsequencenumber")]
			public System.Nullable<int> ImportSequenceNumber {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("importsequencenumber");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("ImportSequenceNumber", "importsequencenumber", value);
				}
			}

			/// <summary>
			/// Incoming email delivery method for the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("incomingemaildeliverymethod")]
			public System.Nullable<int> IncomingEmailDeliveryMethod {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("incomingemaildeliverymethod");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("IncomingEmailDeliveryMethod", "incomingemaildeliverymethod", value);
				}
			}

			/// <summary>
			/// Internal email address for the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("internalemailaddress")]
			public string InternalEMailAddress {
				get {
					return this.GetAttributeValue<string>("internalemailaddress");
				}
				set {
					this.SetAttributeValue<string>("InternalEMailAddress", "internalemailaddress", value);
				}
			}

			/// <summary>
			/// User invitation status.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("invitestatuscode")]
			public System.Nullable<int> InviteStatusCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("invitestatuscode");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("InviteStatusCode", "invitestatuscode", value);
				}
			}

			/// <summary>
			/// Information about whether the user is enabled.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isdisabled")]
			public System.Nullable<bool> IsDisabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isdisabled");
				}
			}

			/// <summary>
			/// Shows the status of approval of the email address by O365 Admin.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isemailaddressapprovedbyo365admin")]
			public System.Nullable<bool> IsEmailAddressApprovedByO365Admin {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isemailaddressapprovedbyo365admin");
				}
			}

			/// <summary>
			/// Check if user is an integration user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isintegrationuser")]
			public System.Nullable<bool> IsIntegrationUser {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isintegrationuser");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsIntegrationUser", "isintegrationuser", value);
				}
			}

			/// <summary>
			/// Information about whether the user is licensed.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("islicensed")]
			public System.Nullable<bool> IsLicensed {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("islicensed");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsLicensed", "islicensed", value);
				}
			}

			/// <summary>
			/// Information about whether the user is synced with the directory.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("issyncwithdirectory")]
			public System.Nullable<bool> IsSyncWithDirectory {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("issyncwithdirectory");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsSyncWithDirectory", "issyncwithdirectory", value);
				}
			}

			/// <summary>
			/// Job title of the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("jobtitle")]
			public string JobTitle {
				get {
					return this.GetAttributeValue<string>("jobtitle");
				}
				set {
					this.SetAttributeValue<string>("JobTitle", "jobtitle", value);
				}
			}

			/// <summary>
			/// Last name of the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("lastname")]
			public string LastName {
				get {
					return this.GetAttributeValue<string>("lastname");
				}
				set {
					this.SetAttributeValue<string>("LastName", "lastname", value);
				}
			}

			/// <summary>
			/// Middle name of the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("middlename")]
			public string MiddleName {
				get {
					return this.GetAttributeValue<string>("middlename");
				}
				set {
					this.SetAttributeValue<string>("MiddleName", "middlename", value);
				}
			}

			/// <summary>
			/// Mobile alert email address for the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mobilealertemail")]
			public string MobileAlertEMail {
				get {
					return this.GetAttributeValue<string>("mobilealertemail");
				}
				set {
					this.SetAttributeValue<string>("MobileAlertEMail", "mobilealertemail", value);
				}
			}

			/// <summary>
			/// Items contained with a particular SystemUser.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mobileofflineprofileid")]
			public Microsoft.Xrm.Client.CrmEntityReference MobileOfflineProfileId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("mobileofflineprofileid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("MobileOfflineProfileId", "mobileofflineprofileid", value);
				}
			}

			/// <summary>
			/// Mobile phone number for the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mobilephone")]
			public string MobilePhone {
				get {
					return this.GetAttributeValue<string>("mobilephone");
				}
				set {
					this.SetAttributeValue<string>("MobilePhone", "mobilephone", value);
				}
			}

			/// <summary>
			/// Unique identifier of the user who last modified the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
			public Microsoft.Xrm.Client.CrmEntityReference ModifiedBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
				}
			}

			/// <summary>
			/// Date and time when the user was last modified.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
			public System.Nullable<System.DateTime> ModifiedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
				}
			}

			/// <summary>
			/// Unique identifier of the delegate user who last modified the systemuser.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
			public Microsoft.Xrm.Client.CrmEntityReference ModifiedOnBehalfBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ModifiedOnBehalfBy", "modifiedonbehalfby", value);
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msus_allow_medibuddy_access")]
			public System.Nullable<bool> msus_allow_medibuddy_access {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("msus_allow_medibuddy_access");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("msus_allow_medibuddy_access", "msus_allow_medibuddy_access", value);
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msus_dirpersonname_personid")]
			public string msus_DIRPERSONNAME_PERSONID {
				get {
					return this.GetAttributeValue<string>("msus_dirpersonname_personid");
				}
				set {
					this.SetAttributeValue<string>("msus_DIRPERSONNAME_PERSONID", "msus_dirpersonname_personid", value);
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msus_fcm_token")]
			public string msus_fcm_token {
				get {
					return this.GetAttributeValue<string>("msus_fcm_token");
				}
				set {
					this.SetAttributeValue<string>("msus_fcm_token", "msus_fcm_token", value);
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msus_hcmworker_recid")]
			public string msus_HCMWORKER_RECID {
				get {
					return this.GetAttributeValue<string>("msus_hcmworker_recid");
				}
				set {
					this.SetAttributeValue<string>("msus_HCMWORKER_RECID", "msus_hcmworker_recid", value);
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msus_ismanager")]
			public System.Nullable<bool> msus_ismanager {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("msus_ismanager");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("msus_ismanager", "msus_ismanager", value);
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msus_medibuddy_managed_territories")]
			public string msus_medibuddy_managed_territories {
				get {
					return this.GetAttributeValue<string>("msus_medibuddy_managed_territories");
				}
				set {
					this.SetAttributeValue<string>("msus_medibuddy_managed_territories", "msus_medibuddy_managed_territories", value);
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msus_msusa_domain_name")]
			public string msus_msusa_domain_name {
				get {
					return this.GetAttributeValue<string>("msus_msusa_domain_name");
				}
				set {
					this.SetAttributeValue<string>("msus_msusa_domain_name", "msus_msusa_domain_name", value);
				}
			}

			/// <summary>
			/// Unique identifier for Territory associated with User.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("new_managerid")]
			public Microsoft.Xrm.Client.CrmEntityReference new_ManagerId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("new_managerid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("new_ManagerId", "new_managerid", value);
				}
			}

			/// <summary>
			/// Unique identifier for User associated with User.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("new_many_user_to_salesregion")]
			public Microsoft.Xrm.Client.CrmEntityReference new_many_user_to_salesregion {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("new_many_user_to_salesregion");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("new_many_user_to_salesregion", "new_many_user_to_salesregion", value);
				}
			}

			/// <summary>
			/// Automatically attempts to recognize FedEx tracking numbers you type into case notes and provide a link to track the package.  Must be 12 numbers, without spaces: (e.g. 123456789012 ).
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("new_mw_options_case_autogeneratefedexlinks")]
			public System.Nullable<bool> new_mw_options_case_autogeneratefedexlinks {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("new_mw_options_case_autogeneratefedexlinks");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("new_mw_options_case_autogeneratefedexlinks", "new_mw_options_case_autogeneratefedexlinks", value);
				}
			}

			/// <summary>
			/// Nickname of the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("nickname")]
			public string NickName {
				get {
					return this.GetAttributeValue<string>("nickname");
				}
				set {
					this.SetAttributeValue<string>("NickName", "nickname", value);
				}
			}

			/// <summary>
			/// Unique identifier of the organization associated with the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("organizationid")]
			public System.Nullable<System.Guid> OrganizationId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("organizationid");
				}
			}

			/// <summary>
			/// Outgoing email delivery method for the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("outgoingemaildeliverymethod")]
			public System.Nullable<int> OutgoingEmailDeliveryMethod {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("outgoingemaildeliverymethod");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("OutgoingEmailDeliveryMethod", "outgoingemaildeliverymethod", value);
				}
			}

			/// <summary>
			/// Date and time that the record was migrated.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("overriddencreatedon")]
			public System.Nullable<System.DateTime> OverriddenCreatedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("overriddencreatedon");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.DateTime>>("OverriddenCreatedOn", "overriddencreatedon", value);
				}
			}

			/// <summary>
			/// Unique identifier of the manager of the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("parentsystemuserid")]
			public Microsoft.Xrm.Client.CrmEntityReference ParentSystemUserId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("parentsystemuserid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ParentSystemUserId", "parentsystemuserid", value);
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("passporthi")]
			public System.Nullable<int> PassportHi {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("passporthi");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("PassportHi", "passporthi", value);
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("passportlo")]
			public System.Nullable<int> PassportLo {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("passportlo");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("PassportLo", "passportlo", value);
				}
			}

			/// <summary>
			/// Personal email address of the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("personalemailaddress")]
			public string PersonalEMailAddress {
				get {
					return this.GetAttributeValue<string>("personalemailaddress");
				}
				set {
					this.SetAttributeValue<string>("PersonalEMailAddress", "personalemailaddress", value);
				}
			}

			/// <summary>
			/// URL for the Website on which a photo of the user is located.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("photourl")]
			public string PhotoUrl {
				get {
					return this.GetAttributeValue<string>("photourl");
				}
				set {
					this.SetAttributeValue<string>("PhotoUrl", "photourl", value);
				}
			}

			/// <summary>
			/// User's position in hierarchical security model.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("positionid")]
			public Microsoft.Xrm.Client.CrmEntityReference PositionId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("positionid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("PositionId", "positionid", value);
				}
			}

			/// <summary>
			/// Preferred address for the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("preferredaddresscode")]
			public System.Nullable<int> PreferredAddressCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("preferredaddresscode");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("PreferredAddressCode", "preferredaddresscode", value);
				}
			}

			/// <summary>
			/// Preferred email address for the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("preferredemailcode")]
			public System.Nullable<int> PreferredEmailCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("preferredemailcode");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("PreferredEmailCode", "preferredemailcode", value);
				}
			}

			/// <summary>
			/// Preferred phone number for the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("preferredphonecode")]
			public System.Nullable<int> PreferredPhoneCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("preferredphonecode");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("PreferredPhoneCode", "preferredphonecode", value);
				}
			}

			/// <summary>
			/// Shows the ID of the process.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("processid")]
			public System.Nullable<System.Guid> ProcessId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("processid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("ProcessId", "processid", value);
				}
			}

			/// <summary>
			/// Unique identifier of the default queue for the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("queueid")]
			public Microsoft.Xrm.Client.CrmEntityReference QueueId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("queueid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("QueueId", "queueid", value);
				}
			}

			/// <summary>
			/// Salutation for correspondence with the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("salutation")]
			public string Salutation {
				get {
					return this.GetAttributeValue<string>("salutation");
				}
				set {
					this.SetAttributeValue<string>("Salutation", "salutation", value);
				}
			}

			/// <summary>
			/// Check if user is a setup user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("setupuser")]
			public System.Nullable<bool> SetupUser {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("setupuser");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("SetupUser", "setupuser", value);
				}
			}

			/// <summary>
			/// SharePoint Work Email Address
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sharepointemailaddress")]
			public string SharePointEmailAddress {
				get {
					return this.GetAttributeValue<string>("sharepointemailaddress");
				}
				set {
					this.SetAttributeValue<string>("SharePointEmailAddress", "sharepointemailaddress", value);
				}
			}

			/// <summary>
			/// Site at which the user is located.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("siteid")]
			public Microsoft.Xrm.Client.CrmEntityReference SiteId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("siteid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("SiteId", "siteid", value);
				}
			}

			/// <summary>
			/// Skill set of the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("skills")]
			public string Skills {
				get {
					return this.GetAttributeValue<string>("skills");
				}
				set {
					this.SetAttributeValue<string>("Skills", "skills", value);
				}
			}

			/// <summary>
			/// Shows the ID of the stage.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("stageid")]
			public System.Nullable<System.Guid> StageId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("stageid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("StageId", "stageid", value);
				}
			}

			/// <summary>
			/// Unique identifier for the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("systemuserid")]
			public System.Nullable<System.Guid> SystemUserId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("systemuserid");
				}
				set {
					this.SetPrimaryIdAttributeValue<System.Nullable<System.Guid>>("SystemUserId", "systemuserid", value);
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("systemuserid")]
			public override System.Guid Id {
				get {
					return base.Id;
				}
				set {
					this.SystemUserId = value;
				}
			}

			/// <summary>
			/// Unique identifier of the territory to which the user is assigned.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("territoryid")]
			public Microsoft.Xrm.Client.CrmEntityReference TerritoryId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("territoryid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("TerritoryId", "territoryid", value);
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezoneruleversionnumber")]
			public System.Nullable<int> TimeZoneRuleVersionNumber {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("timezoneruleversionnumber");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TimeZoneRuleVersionNumber", "timezoneruleversionnumber", value);
				}
			}

			/// <summary>
			/// Title of the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("title")]
			public string Title {
				get {
					return this.GetAttributeValue<string>("title");
				}
				set {
					this.SetAttributeValue<string>("Title", "title", value);
				}
			}

			/// <summary>
			/// Unique identifier of the currency associated with the systemuser.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("transactioncurrencyid")]
			public Microsoft.Xrm.Client.CrmEntityReference TransactionCurrencyId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("transactioncurrencyid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("TransactionCurrencyId", "transactioncurrencyid", value);
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("traversedpath")]
			public string TraversedPath {
				get {
					return this.GetAttributeValue<string>("traversedpath");
				}
				set {
					this.SetAttributeValue<string>("TraversedPath", "traversedpath", value);
				}
			}

			/// <summary>
			/// Shows the type of user license.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("userlicensetype")]
			public System.Nullable<int> UserLicenseType {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("userlicensetype");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("UserLicenseType", "userlicensetype", value);
				}
			}

			/// <summary>
			/// Time zone code that was in use when the record was created.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("utcconversiontimezonecode")]
			public System.Nullable<int> UTCConversionTimeZoneCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("utcconversiontimezonecode");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("UTCConversionTimeZoneCode", "utcconversiontimezonecode", value);
				}
			}

			/// <summary>
			/// Version number of the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
			public System.Nullable<long> VersionNumber {
				get {
					return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
				}
			}

			/// <summary>
			/// Windows Live ID
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("windowsliveid")]
			public string WindowsLiveID {
				get {
					return this.GetAttributeValue<string>("windowsliveid");
				}
				set {
					this.SetAttributeValue<string>("WindowsLiveID", "windowsliveid", value);
				}
			}

			/// <summary>
			/// User's Yammer login email address
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("yammeremailaddress")]
			public string YammerEmailAddress {
				get {
					return this.GetAttributeValue<string>("yammeremailaddress");
				}
				set {
					this.SetAttributeValue<string>("YammerEmailAddress", "yammeremailaddress", value);
				}
			}

			/// <summary>
			/// User's Yammer ID
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("yammeruserid")]
			public string YammerUserId {
				get {
					return this.GetAttributeValue<string>("yammeruserid");
				}
				set {
					this.SetAttributeValue<string>("YammerUserId", "yammeruserid", value);
				}
			}

			/// <summary>
			/// Pronunciation of the first name of the user, written in phonetic hiragana or katakana characters.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("yomifirstname")]
			public string YomiFirstName {
				get {
					return this.GetAttributeValue<string>("yomifirstname");
				}
				set {
					this.SetAttributeValue<string>("YomiFirstName", "yomifirstname", value);
				}
			}

			/// <summary>
			/// Pronunciation of the full name of the user, written in phonetic hiragana or katakana characters.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("yomifullname")]
			public string YomiFullName {
				get {
					return this.GetAttributeValue<string>("yomifullname");
				}
			}

			/// <summary>
			/// Pronunciation of the last name of the user, written in phonetic hiragana or katakana characters.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("yomilastname")]
			public string YomiLastName {
				get {
					return this.GetAttributeValue<string>("yomilastname");
				}
				set {
					this.SetAttributeValue<string>("YomiLastName", "yomilastname", value);
				}
			}

			/// <summary>
			/// Pronunciation of the middle name of the user, written in phonetic hiragana or katakana characters.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("yomimiddlename")]
			public string YomiMiddleName {
				get {
					return this.GetAttributeValue<string>("yomimiddlename");
				}
				set {
					this.SetAttributeValue<string>("YomiMiddleName", "yomimiddlename", value);
				}
			}

			/// <summary>
			/// Constructor for populating via LINQ queries given a LINQ anonymous type
			/// <param name="anonymousType">LINQ anonymous type.</param>
			/// </summary>
			public SystemUser(object anonymousType) :
					this() {
				foreach (var p in anonymousType.GetType().GetProperties()) {
					var value = p.GetValue(anonymousType, null);
					var name = p.Name.ToLower();

					if (name.EndsWith("enum") && value.GetType().BaseType == typeof(System.Enum)) {
						value = new Microsoft.Xrm.Sdk.OptionSetValue((int)value);
						name = name.Remove(name.Length - "enum".Length);
					}

					switch (name) {
						case "id":
							base.Id = (System.Guid)value;
							Attributes["systemuserid"] = base.Id;
							break;
						case "systemuserid":
							var id = (System.Nullable<System.Guid>)value;
							if (id == null) { continue; }
							base.Id = id.Value;
							Attributes[name] = base.Id;
							break;
						case "formattedvalues":
							// Add Support for FormattedValues
							FormattedValues.AddRange((Microsoft.Xrm.Sdk.FormattedValueCollection)value);
							break;
						default:
							Attributes[name] = value;
							break;
					}
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("accessmode")]
			public virtual SystemUser_AccessMode? AccessModeEnum {
				get {
					return ((SystemUser_AccessMode?)(EntityOptionSetEnum.GetEnum(this, "accessmode")));
				}
				set {
					AccessMode = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_addresstypecode")]
			public virtual SystemUser_Address1_AddressTypeCode? Address1_AddressTypeCodeEnum {
				get {
					return ((SystemUser_Address1_AddressTypeCode?)(EntityOptionSetEnum.GetEnum(this, "address1_addresstypecode")));
				}
				set {
					Address1_AddressTypeCode = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_shippingmethodcode")]
			public virtual SystemUser_Address1_ShippingMethodCode? Address1_ShippingMethodCodeEnum {
				get {
					return ((SystemUser_Address1_ShippingMethodCode?)(EntityOptionSetEnum.GetEnum(this, "address1_shippingmethodcode")));
				}
				set {
					Address1_ShippingMethodCode = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_addresstypecode")]
			public virtual SystemUser_Address2_AddressTypeCode? Address2_AddressTypeCodeEnum {
				get {
					return ((SystemUser_Address2_AddressTypeCode?)(EntityOptionSetEnum.GetEnum(this, "address2_addresstypecode")));
				}
				set {
					Address2_AddressTypeCode = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_shippingmethodcode")]
			public virtual SystemUser_Address2_ShippingMethodCode? Address2_ShippingMethodCodeEnum {
				get {
					return ((SystemUser_Address2_ShippingMethodCode?)(EntityOptionSetEnum.GetEnum(this, "address2_shippingmethodcode")));
				}
				set {
					Address2_ShippingMethodCode = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("caltype")]
			public virtual SystemUser_CALType? CALTypeEnum {
				get {
					return ((SystemUser_CALType?)(EntityOptionSetEnum.GetEnum(this, "caltype")));
				}
				set {
					CALType = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("emailrouteraccessapproval")]
			public virtual SystemUser_EmailRouterAccessApproval? EmailRouterAccessApprovalEnum {
				get {
					return ((SystemUser_EmailRouterAccessApproval?)(EntityOptionSetEnum.GetEnum(this, "emailrouteraccessapproval")));
				}
				set {
					EmailRouterAccessApproval = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("incomingemaildeliverymethod")]
			public virtual SystemUser_IncomingEmailDeliveryMethod? IncomingEmailDeliveryMethodEnum {
				get {
					return ((SystemUser_IncomingEmailDeliveryMethod?)(EntityOptionSetEnum.GetEnum(this, "incomingemaildeliverymethod")));
				}
				set {
					IncomingEmailDeliveryMethod = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("invitestatuscode")]
			public virtual SystemUser_InviteStatusCode? InviteStatusCodeEnum {
				get {
					return ((SystemUser_InviteStatusCode?)(EntityOptionSetEnum.GetEnum(this, "invitestatuscode")));
				}
				set {
					InviteStatusCode = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("outgoingemaildeliverymethod")]
			public virtual SystemUser_OutgoingEmailDeliveryMethod? OutgoingEmailDeliveryMethodEnum {
				get {
					return ((SystemUser_OutgoingEmailDeliveryMethod?)(EntityOptionSetEnum.GetEnum(this, "outgoingemaildeliverymethod")));
				}
				set {
					OutgoingEmailDeliveryMethod = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("preferredaddresscode")]
			public virtual SystemUser_PreferredAddressCode? PreferredAddressCodeEnum {
				get {
					return ((SystemUser_PreferredAddressCode?)(EntityOptionSetEnum.GetEnum(this, "preferredaddresscode")));
				}
				set {
					PreferredAddressCode = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("preferredemailcode")]
			public virtual SystemUser_PreferredEmailCode? PreferredEmailCodeEnum {
				get {
					return ((SystemUser_PreferredEmailCode?)(EntityOptionSetEnum.GetEnum(this, "preferredemailcode")));
				}
				set {
					PreferredEmailCode = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("preferredphonecode")]
			public virtual SystemUser_PreferredPhoneCode? PreferredPhoneCodeEnum {
				get {
					return ((SystemUser_PreferredPhoneCode?)(EntityOptionSetEnum.GetEnum(this, "preferredphonecode")));
				}
				set {
					PreferredPhoneCode = (int?)value;
				}
			}
		}

		/// <summary>
		/// Generic activity representing work needed to be done.
		/// </summary>
		[System.Runtime.Serialization.DataContractAttribute()]
		[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("task")]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.0.0.9369")]
		[System.Data.Services.Common.DataServiceKeyAttribute("Id")]
		[System.Data.Services.IgnorePropertiesAttribute("Item", "Attributes", "EntityState", "FormattedValues", "RelatedEntities", "ExtensionData")]
		[Microsoft.Xrm.Client.Metadata.EntityAttribute("TaskSet")]
		public partial class Task : Microsoft.Xrm.Client.CrmEntity {

			public static class Fields {
				public const string ActivityAdditionalParams = "activityadditionalparams";
				public const string ActivityId = "activityid";
				public const string Id = "activityid";
				public const string ActivityTypeCode = "activitytypecode";
				public const string ActualDurationMinutes = "actualdurationminutes";
				public const string ActualEnd = "actualend";
				public const string ActualStart = "actualstart";
				public const string Category = "category";
				public const string CreatedBy = "createdby";
				public const string CreatedOn = "createdon";
				public const string CreatedOnBehalfBy = "createdonbehalfby";
				public const string CrmTaskAssignedUniqueId = "crmtaskassigneduniqueid";
				public const string Description = "description";
				public const string ExchangeRate = "exchangerate";
				public const string ImportSequenceNumber = "importsequencenumber";
				public const string IsBilled = "isbilled";
				public const string IsRegularActivity = "isregularactivity";
				public const string IsWorkflowCreated = "isworkflowcreated";
				public const string LastOnHoldTime = "lastonholdtime";
				public const string ModifiedBy = "modifiedby";
				public const string ModifiedOn = "modifiedon";
				public const string ModifiedOnBehalfBy = "modifiedonbehalfby";
				public const string OnHoldTime = "onholdtime";
				public const string OverriddenCreatedOn = "overriddencreatedon";
				public const string OwnerId = "ownerid";
				public const string OwningBusinessUnit = "owningbusinessunit";
				public const string OwningTeam = "owningteam";
				public const string OwningUser = "owninguser";
				public const string PercentComplete = "percentcomplete";
				public const string PriorityCode = "prioritycode";
				public const string ProcessId = "processid";
				public const string RegardingObjectId = "regardingobjectid";
				public const string ScheduledDurationMinutes = "scheduleddurationminutes";
				public const string ScheduledEnd = "scheduledend";
				public const string ScheduledStart = "scheduledstart";
				public const string ServiceId = "serviceid";
				public const string SLAId = "slaid";
				public const string SLAInvokedId = "slainvokedid";
				public const string SortDate = "sortdate";
				public const string StageId = "stageid";
				public const string StateCode = "statecode";
				public const string StatusCode = "statuscode";
				public const string Subcategory = "subcategory";
				public const string Subject = "subject";
				public const string SubscriptionId = "subscriptionid";
				public const string TimeZoneRuleVersionNumber = "timezoneruleversionnumber";
				public const string TransactionCurrencyId = "transactioncurrencyid";
				public const string TraversedPath = "traversedpath";
				public const string UTCConversionTimeZoneCode = "utcconversiontimezonecode";
				public const string VersionNumber = "versionnumber";
			}

			/// <summary>
			/// Default Constructor.
			/// </summary>
			public Task() :
					base(EntityLogicalName) {
			}

			public const string EntityLogicalName = "task";

			public const string PrimaryIdAttribute = "activityid";

			public const string PrimaryNameAttribute = "subject";

			public const int EntityTypeCode = 4212;

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("activityadditionalparams")]
			public string ActivityAdditionalParams {
				get {
					return this.GetAttributeValue<string>("activityadditionalparams");
				}
				set {
					this.SetAttributeValue<string>("ActivityAdditionalParams", "activityadditionalparams", value);
				}
			}

			/// <summary>
			/// Unique identifier of the task.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("activityid")]
			public System.Nullable<System.Guid> ActivityId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("activityid");
				}
				set {
					this.SetPrimaryIdAttributeValue<System.Nullable<System.Guid>>("ActivityId", "activityid", value);
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("activityid")]
			public override System.Guid Id {
				get {
					return base.Id;
				}
				set {
					this.ActivityId = value;
				}
			}

			/// <summary>
			/// Type of activity.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("activitytypecode")]
			public string ActivityTypeCode {
				get {
					return this.GetAttributeValue<string>("activitytypecode");
				}
			}

			/// <summary>
			/// Type the number of minutes spent on the task. The duration is used in reporting.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("actualdurationminutes")]
			public System.Nullable<int> ActualDurationMinutes {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("actualdurationminutes");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("ActualDurationMinutes", "actualdurationminutes", value);
				}
			}

			/// <summary>
			/// Enter the actual end date and time of the task. By default, it displays when the activity was completed or canceled.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("actualend")]
			public System.Nullable<System.DateTime> ActualEnd {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("actualend");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.DateTime>>("ActualEnd", "actualend", value);
				}
			}

			/// <summary>
			/// Enter the actual start date and time for the task. By default, it displays when the task was created.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("actualstart")]
			public System.Nullable<System.DateTime> ActualStart {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("actualstart");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.DateTime>>("ActualStart", "actualstart", value);
				}
			}

			/// <summary>
			/// Type a category to identify the task type, such as lead gathering or customer follow up, to tie the task to a business group or function.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("category")]
			public string Category {
				get {
					return this.GetAttributeValue<string>("category");
				}
				set {
					this.SetAttributeValue<string>("Category", "category", value);
				}
			}

			/// <summary>
			/// Shows who created the record.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
			public Microsoft.Xrm.Client.CrmEntityReference CreatedBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
				}
			}

			/// <summary>
			/// Shows the date and time when the record was created. The date and time are displayed in the time zone selected in Microsoft Dynamics 365 options.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
			public System.Nullable<System.DateTime> CreatedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
				}
			}

			/// <summary>
			/// Shows who created the record on behalf of another user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
			public Microsoft.Xrm.Client.CrmEntityReference CreatedOnBehalfBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("CreatedOnBehalfBy", "createdonbehalfby", value);
				}
			}

			/// <summary>
			/// Assigned Task Unique Id
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("crmtaskassigneduniqueid")]
			public System.Nullable<System.Guid> CrmTaskAssignedUniqueId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("crmtaskassigneduniqueid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("CrmTaskAssignedUniqueId", "crmtaskassigneduniqueid", value);
				}
			}

			/// <summary>
			/// Type additional information to describe the task.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("description")]
			public string Description {
				get {
					return this.GetAttributeValue<string>("description");
				}
				set {
					this.SetAttributeValue<string>("Description", "description", value);
				}
			}

			/// <summary>
			/// Shows the conversion rate of the record's currency. The exchange rate is used to convert all money fields in the record from the local currency to the system's default currency.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("exchangerate")]
			public System.Nullable<decimal> ExchangeRate {
				get {
					return this.GetAttributeValue<System.Nullable<decimal>>("exchangerate");
				}
			}

			/// <summary>
			/// Unique identifier of the data import or data migration that created this record.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("importsequencenumber")]
			public System.Nullable<int> ImportSequenceNumber {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("importsequencenumber");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("ImportSequenceNumber", "importsequencenumber", value);
				}
			}

			/// <summary>
			/// Information which specifies whether the task was billed as part of resolving a case.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isbilled")]
			public System.Nullable<bool> IsBilled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isbilled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsBilled", "isbilled", value);
				}
			}

			/// <summary>
			/// Information regarding whether the activity is a regular activity type or event type.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isregularactivity")]
			public System.Nullable<bool> IsRegularActivity {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isregularactivity");
				}
			}

			/// <summary>
			/// Information which specifies if the task was created from a workflow rule.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isworkflowcreated")]
			public System.Nullable<bool> IsWorkflowCreated {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isworkflowcreated");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsWorkflowCreated", "isworkflowcreated", value);
				}
			}

			/// <summary>
			/// Contains the date and time stamp of the last on hold time.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("lastonholdtime")]
			public System.Nullable<System.DateTime> LastOnHoldTime {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("lastonholdtime");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.DateTime>>("LastOnHoldTime", "lastonholdtime", value);
				}
			}

			/// <summary>
			/// Shows who last updated the record.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
			public Microsoft.Xrm.Client.CrmEntityReference ModifiedBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
				}
			}

			/// <summary>
			/// Shows the date and time when the record was last updated. The date and time are displayed in the time zone selected in Microsoft Dynamics 365 options.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
			public System.Nullable<System.DateTime> ModifiedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
				}
			}

			/// <summary>
			/// Shows who last updated the record on behalf of another user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
			public Microsoft.Xrm.Client.CrmEntityReference ModifiedOnBehalfBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ModifiedOnBehalfBy", "modifiedonbehalfby", value);
				}
			}

			/// <summary>
			/// Shows how long, in minutes, that the record was on hold.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("onholdtime")]
			public System.Nullable<int> OnHoldTime {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("onholdtime");
				}
			}

			/// <summary>
			/// Date and time that the record was migrated.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("overriddencreatedon")]
			public System.Nullable<System.DateTime> OverriddenCreatedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("overriddencreatedon");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.DateTime>>("OverriddenCreatedOn", "overriddencreatedon", value);
				}
			}

			/// <summary>
			/// Enter the user or team who is assigned to manage the record. This field is updated every time the record is assigned to a different user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ownerid")]
			public Microsoft.Xrm.Client.CrmEntityReference OwnerId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ownerid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("OwnerId", "ownerid", value);
				}
			}

			/// <summary>
			/// Shows the record owner's business unit.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningbusinessunit")]
			public Microsoft.Xrm.Client.CrmEntityReference OwningBusinessUnit {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningbusinessunit");
				}
			}

			/// <summary>
			/// Unique identifier of the team that owns the task.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningteam")]
			public Microsoft.Xrm.Client.CrmEntityReference OwningTeam {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningteam");
				}
			}

			/// <summary>
			/// Unique identifier of the user that owns the task.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owninguser")]
			public Microsoft.Xrm.Client.CrmEntityReference OwningUser {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owninguser");
				}
			}

			/// <summary>
			/// Type the percentage complete value for the task to track tasks to completion.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("percentcomplete")]
			public System.Nullable<int> PercentComplete {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("percentcomplete");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("PercentComplete", "percentcomplete", value);
				}
			}

			/// <summary>
			/// Select the priority so that preferred customers or critical issues are handled quickly.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("prioritycode")]
			public System.Nullable<int> PriorityCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("prioritycode");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("PriorityCode", "prioritycode", value);
				}
			}

			/// <summary>
			/// Shows the ID of the process.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("processid")]
			public System.Nullable<System.Guid> ProcessId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("processid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("ProcessId", "processid", value);
				}
			}

			/// <summary>
			/// Unique identifier of the object with which the task is associated.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("regardingobjectid")]
			public Microsoft.Xrm.Client.CrmEntityReference RegardingObjectId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("regardingobjectid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("RegardingObjectId", "regardingobjectid", value);
				}
			}

			/// <summary>
			/// Scheduled duration of the task, specified in minutes.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("scheduleddurationminutes")]
			public System.Nullable<int> ScheduledDurationMinutes {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("scheduleddurationminutes");
				}
			}

			/// <summary>
			/// Enter the expected due date and time.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("scheduledend")]
			public System.Nullable<System.DateTime> ScheduledEnd {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("scheduledend");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.DateTime>>("ScheduledEnd", "scheduledend", value);
				}
			}

			/// <summary>
			/// Enter the expected due date and time.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("scheduledstart")]
			public System.Nullable<System.DateTime> ScheduledStart {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("scheduledstart");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.DateTime>>("ScheduledStart", "scheduledstart", value);
				}
			}

			/// <summary>
			/// Choose the service that is associated with this activity.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("serviceid")]
			public Microsoft.Xrm.Client.CrmEntityReference ServiceId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("serviceid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ServiceId", "serviceid", value);
				}
			}

			/// <summary>
			/// Choose the service level agreement (SLA) that you want to apply to the Task record.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("slaid")]
			public Microsoft.Xrm.Client.CrmEntityReference SLAId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("slaid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("SLAId", "slaid", value);
				}
			}

			/// <summary>
			/// Last SLA that was applied to this Task. This field is for internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("slainvokedid")]
			public Microsoft.Xrm.Client.CrmEntityReference SLAInvokedId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("slainvokedid");
				}
			}

			/// <summary>
			/// Shows the date and time by which the activities are sorted.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sortdate")]
			public System.Nullable<System.DateTime> SortDate {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("sortdate");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.DateTime>>("SortDate", "sortdate", value);
				}
			}

			/// <summary>
			/// Shows the ID of the stage.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("stageid")]
			public System.Nullable<System.Guid> StageId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("stageid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("StageId", "stageid", value);
				}
			}

			/// <summary>
			/// Shows whether the task is open, completed, or canceled. Completed and canceled tasks are read-only and can't be edited.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statecode")]
			public System.Nullable<int> StateCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("statecode");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("StateCode", "statecode", value);
				}
			}

			/// <summary>
			/// Select the task's status.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statuscode")]
			public System.Nullable<int> StatusCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("statuscode");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("StatusCode", "statuscode", value);
				}
			}

			/// <summary>
			/// Type a subcategory to identify the task type and relate the activity to a specific product, sales region, business group, or other function.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("subcategory")]
			public string Subcategory {
				get {
					return this.GetAttributeValue<string>("subcategory");
				}
				set {
					this.SetAttributeValue<string>("Subcategory", "subcategory", value);
				}
			}

			/// <summary>
			/// Type a short description about the objective or primary topic of the task.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("subject")]
			public string Subject {
				get {
					return this.GetAttributeValue<string>("subject");
				}
				set {
					this.SetAttributeValue<string>("Subject", "subject", value);
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("subscriptionid")]
			public System.Nullable<System.Guid> SubscriptionId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("subscriptionid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("SubscriptionId", "subscriptionid", value);
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezoneruleversionnumber")]
			public System.Nullable<int> TimeZoneRuleVersionNumber {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("timezoneruleversionnumber");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TimeZoneRuleVersionNumber", "timezoneruleversionnumber", value);
				}
			}

			/// <summary>
			/// Choose the local currency for the record to make sure budgets are reported in the correct currency.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("transactioncurrencyid")]
			public Microsoft.Xrm.Client.CrmEntityReference TransactionCurrencyId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("transactioncurrencyid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("TransactionCurrencyId", "transactioncurrencyid", value);
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("traversedpath")]
			public string TraversedPath {
				get {
					return this.GetAttributeValue<string>("traversedpath");
				}
				set {
					this.SetAttributeValue<string>("TraversedPath", "traversedpath", value);
				}
			}

			/// <summary>
			/// Time zone code that was in use when the record was created.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("utcconversiontimezonecode")]
			public System.Nullable<int> UTCConversionTimeZoneCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("utcconversiontimezonecode");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("UTCConversionTimeZoneCode", "utcconversiontimezonecode", value);
				}
			}

			/// <summary>
			/// Version number of the task.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
			public System.Nullable<long> VersionNumber {
				get {
					return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
				}
			}

			/// <summary>
			/// Constructor for populating via LINQ queries given a LINQ anonymous type
			/// <param name="anonymousType">LINQ anonymous type.</param>
			/// </summary>
			public Task(object anonymousType) :
					this() {
				foreach (var p in anonymousType.GetType().GetProperties()) {
					var value = p.GetValue(anonymousType, null);
					var name = p.Name.ToLower();

					if (name.EndsWith("enum") && value.GetType().BaseType == typeof(System.Enum)) {
						value = new Microsoft.Xrm.Sdk.OptionSetValue((int)value);
						name = name.Remove(name.Length - "enum".Length);
					}

					switch (name) {
						case "id":
							base.Id = (System.Guid)value;
							Attributes["activityid"] = base.Id;
							break;
						case "activityid":
							var id = (System.Nullable<System.Guid>)value;
							if (id == null) { continue; }
							base.Id = id.Value;
							Attributes[name] = base.Id;
							break;
						case "formattedvalues":
							// Add Support for FormattedValues
							FormattedValues.AddRange((Microsoft.Xrm.Sdk.FormattedValueCollection)value);
							break;
						default:
							Attributes[name] = value;
							break;
					}
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("prioritycode")]
			public virtual Task_PriorityCode? PriorityCodeEnum {
				get {
					return ((Task_PriorityCode?)(EntityOptionSetEnum.GetEnum(this, "prioritycode")));
				}
				set {
					PriorityCode = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statecode")]
			public virtual TaskState? StateCodeEnum {
				get {
					return ((TaskState?)(EntityOptionSetEnum.GetEnum(this, "statecode")));
				}
				set {
					StateCode = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statuscode")]
			public virtual Task_StatusCode? StatusCodeEnum {
				get {
					return ((Task_StatusCode?)(EntityOptionSetEnum.GetEnum(this, "statuscode")));
				}
				set {
					StatusCode = (int?)value;
				}
			}
		}

		/// <summary>
		/// Collection of system users that routinely collaborate. Teams can be used to simplify record sharing and provide team members with common access to organization data when team members belong to different Business Units.
		/// </summary>
		[System.Runtime.Serialization.DataContractAttribute()]
		[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("team")]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.0.0.9369")]
		[System.Data.Services.Common.DataServiceKeyAttribute("Id")]
		[System.Data.Services.IgnorePropertiesAttribute("Item", "Attributes", "EntityState", "FormattedValues", "RelatedEntities", "ExtensionData")]
		[Microsoft.Xrm.Client.Metadata.EntityAttribute("TeamSet")]
		public partial class Team : Microsoft.Xrm.Client.CrmEntity {

			public static class Fields {
				public const string AdministratorId = "administratorid";
				public const string BusinessUnitId = "businessunitid";
				public const string CreatedBy = "createdby";
				public const string CreatedOn = "createdon";
				public const string CreatedOnBehalfBy = "createdonbehalfby";
				public const string Description = "description";
				public const string EMailAddress = "emailaddress";
				public const string ExchangeRate = "exchangerate";
				public const string ImportSequenceNumber = "importsequencenumber";
				public const string IsDefault = "isdefault";
				public const string ModifiedBy = "modifiedby";
				public const string ModifiedOn = "modifiedon";
				public const string ModifiedOnBehalfBy = "modifiedonbehalfby";
				public const string Name = "name";
				public const string OrganizationId = "organizationid";
				public const string OverriddenCreatedOn = "overriddencreatedon";
				public const string ProcessId = "processid";
				public const string QueueId = "queueid";
				public const string RegardingObjectId = "regardingobjectid";
				public const string StageId = "stageid";
				public const string SystemManaged = "systemmanaged";
				public const string TeamId = "teamid";
				public const string Id = "teamid";
				public const string TeamTemplateId = "teamtemplateid";
				public const string TeamType = "teamtype";
				public const string TransactionCurrencyId = "transactioncurrencyid";
				public const string TraversedPath = "traversedpath";
				public const string VersionNumber = "versionnumber";
				public const string YomiName = "yominame";
			}

			/// <summary>
			/// Default Constructor.
			/// </summary>
			public Team() :
					base(EntityLogicalName) {
			}

			public const string EntityLogicalName = "team";

			public const string PrimaryIdAttribute = "teamid";

			public const string PrimaryNameAttribute = "name";

			public const int EntityTypeCode = 9;

			/// <summary>
			/// Unique identifier of the user primary responsible for the team.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("administratorid")]
			public Microsoft.Xrm.Client.CrmEntityReference AdministratorId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("administratorid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("AdministratorId", "administratorid", value);
				}
			}

			/// <summary>
			/// Unique identifier of the business unit with which the team is associated.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("businessunitid")]
			public Microsoft.Xrm.Client.CrmEntityReference BusinessUnitId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("businessunitid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("BusinessUnitId", "businessunitid", value);
				}
			}

			/// <summary>
			/// Unique identifier of the user who created the team.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
			public Microsoft.Xrm.Client.CrmEntityReference CreatedBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
				}
			}

			/// <summary>
			/// Date and time when the team was created.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
			public System.Nullable<System.DateTime> CreatedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
				}
			}

			/// <summary>
			/// Unique identifier of the delegate user who created the team.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
			public Microsoft.Xrm.Client.CrmEntityReference CreatedOnBehalfBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("CreatedOnBehalfBy", "createdonbehalfby", value);
				}
			}

			/// <summary>
			/// Description of the team.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("description")]
			public string Description {
				get {
					return this.GetAttributeValue<string>("description");
				}
				set {
					this.SetAttributeValue<string>("Description", "description", value);
				}
			}

			/// <summary>
			/// Email address for the team.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("emailaddress")]
			public string EMailAddress {
				get {
					return this.GetAttributeValue<string>("emailaddress");
				}
				set {
					this.SetAttributeValue<string>("EMailAddress", "emailaddress", value);
				}
			}

			/// <summary>
			/// Exchange rate for the currency associated with the team with respect to the base currency.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("exchangerate")]
			public System.Nullable<decimal> ExchangeRate {
				get {
					return this.GetAttributeValue<System.Nullable<decimal>>("exchangerate");
				}
			}

			/// <summary>
			/// Unique identifier of the data import or data migration that created this record.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("importsequencenumber")]
			public System.Nullable<int> ImportSequenceNumber {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("importsequencenumber");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("ImportSequenceNumber", "importsequencenumber", value);
				}
			}

			/// <summary>
			/// Information about whether the team is a default business unit team.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isdefault")]
			public System.Nullable<bool> IsDefault {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isdefault");
				}
			}

			/// <summary>
			/// Unique identifier of the user who last modified the team.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
			public Microsoft.Xrm.Client.CrmEntityReference ModifiedBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
				}
			}

			/// <summary>
			/// Date and time when the team was last modified.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
			public System.Nullable<System.DateTime> ModifiedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
				}
			}

			/// <summary>
			/// Unique identifier of the delegate user who last modified the team.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
			public Microsoft.Xrm.Client.CrmEntityReference ModifiedOnBehalfBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ModifiedOnBehalfBy", "modifiedonbehalfby", value);
				}
			}

			/// <summary>
			/// Name of the team.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("name")]
			public string Name {
				get {
					return this.GetAttributeValue<string>("name");
				}
				set {
					this.SetAttributeValue<string>("Name", "name", value);
				}
			}

			/// <summary>
			/// Unique identifier of the organization associated with the team.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("organizationid")]
			public System.Nullable<System.Guid> OrganizationId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("organizationid");
				}
			}

			/// <summary>
			/// Date and time that the record was migrated.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("overriddencreatedon")]
			public System.Nullable<System.DateTime> OverriddenCreatedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("overriddencreatedon");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.DateTime>>("OverriddenCreatedOn", "overriddencreatedon", value);
				}
			}

			/// <summary>
			/// Shows the ID of the process.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("processid")]
			public System.Nullable<System.Guid> ProcessId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("processid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("ProcessId", "processid", value);
				}
			}

			/// <summary>
			/// Unique identifier of the default queue for the team.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("queueid")]
			public Microsoft.Xrm.Client.CrmEntityReference QueueId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("queueid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("QueueId", "queueid", value);
				}
			}

			/// <summary>
			/// Choose the record that the team relates to.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("regardingobjectid")]
			public Microsoft.Xrm.Client.CrmEntityReference RegardingObjectId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("regardingobjectid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("RegardingObjectId", "regardingobjectid", value);
				}
			}

			/// <summary>
			/// Shows the ID of the stage.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("stageid")]
			public System.Nullable<System.Guid> StageId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("stageid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("StageId", "stageid", value);
				}
			}

			/// <summary>
			/// Select whether the team will be managed by the system.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("systemmanaged")]
			public System.Nullable<bool> SystemManaged {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("systemmanaged");
				}
			}

			/// <summary>
			/// Unique identifier for the team.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("teamid")]
			public System.Nullable<System.Guid> TeamId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("teamid");
				}
				set {
					this.SetPrimaryIdAttributeValue<System.Nullable<System.Guid>>("TeamId", "teamid", value);
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("teamid")]
			public override System.Guid Id {
				get {
					return base.Id;
				}
				set {
					this.TeamId = value;
				}
			}

			/// <summary>
			/// Shows the team template that is associated with the team.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("teamtemplateid")]
			public Microsoft.Xrm.Client.CrmEntityReference TeamTemplateId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("teamtemplateid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("TeamTemplateId", "teamtemplateid", value);
				}
			}

			/// <summary>
			/// Select the team type.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("teamtype")]
			public System.Nullable<int> TeamType {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("teamtype");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("TeamType", "teamtype", value);
				}
			}

			/// <summary>
			/// Unique identifier of the currency associated with the team.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("transactioncurrencyid")]
			public Microsoft.Xrm.Client.CrmEntityReference TransactionCurrencyId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("transactioncurrencyid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("TransactionCurrencyId", "transactioncurrencyid", value);
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("traversedpath")]
			public string TraversedPath {
				get {
					return this.GetAttributeValue<string>("traversedpath");
				}
				set {
					this.SetAttributeValue<string>("TraversedPath", "traversedpath", value);
				}
			}

			/// <summary>
			/// Version number of the team.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
			public System.Nullable<long> VersionNumber {
				get {
					return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
				}
			}

			/// <summary>
			/// Pronunciation of the full name of the team, written in phonetic hiragana or katakana characters.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("yominame")]
			public string YomiName {
				get {
					return this.GetAttributeValue<string>("yominame");
				}
				set {
					this.SetAttributeValue<string>("YomiName", "yominame", value);
				}
			}

			/// <summary>
			/// Constructor for populating via LINQ queries given a LINQ anonymous type
			/// <param name="anonymousType">LINQ anonymous type.</param>
			/// </summary>
			public Team(object anonymousType) :
					this() {
				foreach (var p in anonymousType.GetType().GetProperties()) {
					var value = p.GetValue(anonymousType, null);
					var name = p.Name.ToLower();

					if (name.EndsWith("enum") && value.GetType().BaseType == typeof(System.Enum)) {
						value = new Microsoft.Xrm.Sdk.OptionSetValue((int)value);
						name = name.Remove(name.Length - "enum".Length);
					}

					switch (name) {
						case "id":
							base.Id = (System.Guid)value;
							Attributes["teamid"] = base.Id;
							break;
						case "teamid":
							var id = (System.Nullable<System.Guid>)value;
							if (id == null) { continue; }
							base.Id = id.Value;
							Attributes[name] = base.Id;
							break;
						case "formattedvalues":
							// Add Support for FormattedValues
							FormattedValues.AddRange((Microsoft.Xrm.Sdk.FormattedValueCollection)value);
							break;
						default:
							Attributes[name] = value;
							break;
					}
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("teamtype")]
			public virtual Team_TeamType? TeamTypeEnum {
				get {
					return ((Team_TeamType?)(EntityOptionSetEnum.GetEnum(this, "teamtype")));
				}
				set {
					TeamType = (int?)value;
				}
			}
		}

		/// <summary>
		/// Territory represents sales regions.
		/// </summary>
		[System.Runtime.Serialization.DataContractAttribute()]
		[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("territory")]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.0.0.9369")]
		[System.Data.Services.Common.DataServiceKeyAttribute("Id")]
		[System.Data.Services.IgnorePropertiesAttribute("Item", "Attributes", "EntityState", "FormattedValues", "RelatedEntities", "ExtensionData")]
		[Microsoft.Xrm.Client.Metadata.EntityAttribute("TerritorySet")]
		public partial class Territory : Microsoft.Xrm.Client.CrmEntity {

			public static class Fields {
				public const string CreatedBy = "createdby";
				public const string CreatedOn = "createdon";
				public const string CreatedOnBehalfBy = "createdonbehalfby";
				public const string Description = "description";
				public const string EntityImage = "entityimage";
				public const string EntityImage_Timestamp = "entityimage_timestamp";
				public const string EntityImage_URL = "entityimage_url";
				public const string EntityImageId = "entityimageid";
				public const string ExchangeRate = "exchangerate";
				public const string ImportSequenceNumber = "importsequencenumber";
				public const string ManagerId = "managerid";
				public const string ModifiedBy = "modifiedby";
				public const string ModifiedOn = "modifiedon";
				public const string ModifiedOnBehalfBy = "modifiedonbehalfby";
				public const string msus_ManagerOptionSet = "msus_manageroptionset";
				public const string msus_SalesRegion = "msus_salesregion";
				public const string Name = "name";
				public const string new_BusinessUnit = "new_businessunit";
				public const string new_mw_territory_originating = "new_mw_territory_originating";
				public const string new_SalesRepresentative = "new_salesrepresentative";
				public const string OrganizationId = "organizationid";
				public const string OverriddenCreatedOn = "overriddencreatedon";
				public const string TerritoryId = "territoryid";
				public const string Id = "territoryid";
				public const string TransactionCurrencyId = "transactioncurrencyid";
				public const string VersionNumber = "versionnumber";
			}

			/// <summary>
			/// Default Constructor.
			/// </summary>
			public Territory() :
					base(EntityLogicalName) {
			}

			public const string EntityLogicalName = "territory";

			public const string PrimaryIdAttribute = "territoryid";

			public const string PrimaryNameAttribute = "name";

			public const int EntityTypeCode = 2013;

			/// <summary>
			/// Unique identifier of the user who created the territory.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
			public Microsoft.Xrm.Client.CrmEntityReference CreatedBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
				}
			}

			/// <summary>
			/// Date and time when the territory was created.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
			public System.Nullable<System.DateTime> CreatedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
				}
			}

			/// <summary>
			/// Unique identifier of the delegate user who created the territory.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
			public Microsoft.Xrm.Client.CrmEntityReference CreatedOnBehalfBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("CreatedOnBehalfBy", "createdonbehalfby", value);
				}
			}

			/// <summary>
			/// Description of the territory.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("description")]
			public string Description {
				get {
					return this.GetAttributeValue<string>("description");
				}
				set {
					this.SetAttributeValue<string>("Description", "description", value);
				}
			}

			/// <summary>
			/// The default image for the entity.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityimage")]
			public byte[] EntityImage {
				get {
					return this.GetAttributeValue<byte[]>("entityimage");
				}
				set {
					this.SetAttributeValue<byte[]>("EntityImage", "entityimage", value);
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityimage_timestamp")]
			public System.Nullable<long> EntityImage_Timestamp {
				get {
					return this.GetAttributeValue<System.Nullable<long>>("entityimage_timestamp");
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityimage_url")]
			public string EntityImage_URL {
				get {
					return this.GetAttributeValue<string>("entityimage_url");
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityimageid")]
			public System.Nullable<System.Guid> EntityImageId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("entityimageid");
				}
			}

			/// <summary>
			/// Exchange rate for the currency associated with the territory with respect to the base currency.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("exchangerate")]
			public System.Nullable<decimal> ExchangeRate {
				get {
					return this.GetAttributeValue<System.Nullable<decimal>>("exchangerate");
				}
			}

			/// <summary>
			/// Unique identifier of the data import or data migration that created this record.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("importsequencenumber")]
			public System.Nullable<int> ImportSequenceNumber {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("importsequencenumber");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("ImportSequenceNumber", "importsequencenumber", value);
				}
			}

			/// <summary>
			/// Unique identifier of the manager of the territory.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("managerid")]
			public Microsoft.Xrm.Client.CrmEntityReference ManagerId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("managerid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ManagerId", "managerid", value);
				}
			}

			/// <summary>
			/// Unique identifier of the user who last modified the territory.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
			public Microsoft.Xrm.Client.CrmEntityReference ModifiedBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
				}
			}

			/// <summary>
			/// Date and time when the territory was last modified.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
			public System.Nullable<System.DateTime> ModifiedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
				}
			}

			/// <summary>
			/// Unique identifier of the delegate user who last modified the territory.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
			public Microsoft.Xrm.Client.CrmEntityReference ModifiedOnBehalfBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ModifiedOnBehalfBy", "modifiedonbehalfby", value);
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msus_manageroptionset")]
			public System.Nullable<int> msus_ManagerOptionSet {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("msus_manageroptionset");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("msus_ManagerOptionSet", "msus_manageroptionset", value);
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msus_salesregion")]
			public Microsoft.Xrm.Client.CrmEntityReference msus_SalesRegion {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("msus_salesregion");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("msus_SalesRegion", "msus_salesregion", value);
				}
			}

			/// <summary>
			/// Name of the territory.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("name")]
			public string Name {
				get {
					return this.GetAttributeValue<string>("name");
				}
				set {
					this.SetAttributeValue<string>("Name", "name", value);
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("new_businessunit")]
			public Microsoft.Xrm.Client.CrmEntityReference new_BusinessUnit {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("new_businessunit");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("new_BusinessUnit", "new_businessunit", value);
				}
			}

			/// <summary>
			/// Relationship between territory and lead
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("new_mw_territory_originating")]
			public Microsoft.Xrm.Client.CrmEntityReference new_mw_territory_originating {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("new_mw_territory_originating");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("new_mw_territory_originating", "new_mw_territory_originating", value);
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("new_salesrepresentative")]
			public Microsoft.Xrm.Client.CrmEntityReference new_SalesRepresentative {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("new_salesrepresentative");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("new_SalesRepresentative", "new_salesrepresentative", value);
				}
			}

			/// <summary>
			/// Unique identifier of the organization associated with the territory.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("organizationid")]
			public Microsoft.Xrm.Client.CrmEntityReference OrganizationId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("organizationid");
				}
			}

			/// <summary>
			/// Date and time that the record was migrated.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("overriddencreatedon")]
			public System.Nullable<System.DateTime> OverriddenCreatedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("overriddencreatedon");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.DateTime>>("OverriddenCreatedOn", "overriddencreatedon", value);
				}
			}

			/// <summary>
			/// Unique identifier of the territory.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("territoryid")]
			public System.Nullable<System.Guid> TerritoryId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("territoryid");
				}
				set {
					this.SetPrimaryIdAttributeValue<System.Nullable<System.Guid>>("TerritoryId", "territoryid", value);
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("territoryid")]
			public override System.Guid Id {
				get {
					return base.Id;
				}
				set {
					this.TerritoryId = value;
				}
			}

			/// <summary>
			/// Unique identifier of the currency associated with the territory.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("transactioncurrencyid")]
			public Microsoft.Xrm.Client.CrmEntityReference TransactionCurrencyId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("transactioncurrencyid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("TransactionCurrencyId", "transactioncurrencyid", value);
				}
			}

			/// <summary>
			/// Version number of the territory.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
			public System.Nullable<long> VersionNumber {
				get {
					return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
				}
			}

			/// <summary>
			/// Constructor for populating via LINQ queries given a LINQ anonymous type
			/// <param name="anonymousType">LINQ anonymous type.</param>
			/// </summary>
			public Territory(object anonymousType) :
					this() {
				foreach (var p in anonymousType.GetType().GetProperties()) {
					var value = p.GetValue(anonymousType, null);
					var name = p.Name.ToLower();

					if (name.EndsWith("enum") && value.GetType().BaseType == typeof(System.Enum)) {
						value = new Microsoft.Xrm.Sdk.OptionSetValue((int)value);
						name = name.Remove(name.Length - "enum".Length);
					}

					switch (name) {
						case "id":
							base.Id = (System.Guid)value;
							Attributes["territoryid"] = base.Id;
							break;
						case "territoryid":
							var id = (System.Nullable<System.Guid>)value;
							if (id == null) { continue; }
							base.Id = id.Value;
							Attributes[name] = base.Id;
							break;
						case "formattedvalues":
							// Add Support for FormattedValues
							FormattedValues.AddRange((Microsoft.Xrm.Sdk.FormattedValueCollection)value);
							break;
						default:
							Attributes[name] = value;
							break;
					}
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msus_manageroptionset")]
			public virtual Territory_msus_ManagerOptionSet? msus_ManagerOptionSetEnum {
				get {
					return ((Territory_msus_ManagerOptionSet?)(EntityOptionSetEnum.GetEnum(this, "msus_manageroptionset")));
				}
				set {
					msus_ManagerOptionSet = (int?)value;
				}
			}
		}

		/// <summary>
		/// User-owned dashboards.
		/// </summary>
		[System.Runtime.Serialization.DataContractAttribute()]
		[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("userform")]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.0.0.9369")]
		[System.Data.Services.Common.DataServiceKeyAttribute("Id")]
		[System.Data.Services.IgnorePropertiesAttribute("Item", "Attributes", "EntityState", "FormattedValues", "RelatedEntities", "ExtensionData")]
		[Microsoft.Xrm.Client.Metadata.EntityAttribute("UserFormSet")]
		public partial class UserForm : Microsoft.Xrm.Client.CrmEntity {

			public static class Fields {
				public const string CreatedBy = "createdby";
				public const string CreatedOn = "createdon";
				public const string CreatedOnBehalfBy = "createdonbehalfby";
				public const string Description = "description";
				public const string FormXml = "formxml";
				public const string IsTabletEnabled = "istabletenabled";
				public const string ModifiedBy = "modifiedby";
				public const string ModifiedOn = "modifiedon";
				public const string ModifiedOnBehalfBy = "modifiedonbehalfby";
				public const string Name = "name";
				public const string ObjectTypeCode = "objecttypecode";
				public const string OwnerId = "ownerid";
				public const string OwningBusinessUnit = "owningbusinessunit";
				public const string OwningTeam = "owningteam";
				public const string OwningUser = "owninguser";
				public const string Type = "type";
				public const string UserFormId = "userformid";
				public const string Id = "userformid";
				public const string VersionNumber = "versionnumber";
			}

			/// <summary>
			/// Default Constructor.
			/// </summary>
			public UserForm() :
					base(EntityLogicalName) {
			}

			public const string EntityLogicalName = "userform";

			public const string PrimaryIdAttribute = "userformid";

			public const string PrimaryNameAttribute = "name";

			public const int EntityTypeCode = 1031;

			/// <summary>
			/// Shows who created the record.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
			public Microsoft.Xrm.Client.CrmEntityReference CreatedBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
				}
			}

			/// <summary>
			/// Shows the date and time when the record was created. The date and time are displayed in the time zone selected in Microsoft Dynamics 365 options.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
			public System.Nullable<System.DateTime> CreatedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
				}
			}

			/// <summary>
			/// Shows who created the record on behalf of another user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
			public Microsoft.Xrm.Client.CrmEntityReference CreatedOnBehalfBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("CreatedOnBehalfBy", "createdonbehalfby", value);
				}
			}

			/// <summary>
			/// Type additional information to describe the form or dashboard, such as the filter criteria or intended audience.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("description")]
			public string Description {
				get {
					return this.GetAttributeValue<string>("description");
				}
				set {
					this.SetAttributeValue<string>("Description", "description", value);
				}
			}

			/// <summary>
			/// Shows the XML representation of the layout of the form or dashboard.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("formxml")]
			public string FormXml {
				get {
					return this.GetAttributeValue<string>("formxml");
				}
				set {
					this.SetAttributeValue<string>("FormXml", "formxml", value);
				}
			}

			/// <summary>
			/// Information that specifies whether the dashboard is enabled for tablet.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("istabletenabled")]
			public System.Nullable<bool> IsTabletEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("istabletenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsTabletEnabled", "istabletenabled", value);
				}
			}

			/// <summary>
			/// Shows who last updated the record.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
			public Microsoft.Xrm.Client.CrmEntityReference ModifiedBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
				}
			}

			/// <summary>
			/// Shows the date and time when the record was last updated. The date and time are displayed in the time zone selected in Microsoft Dynamics 365 options.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
			public System.Nullable<System.DateTime> ModifiedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
				}
			}

			/// <summary>
			/// Shows who created the record on behalf of another user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
			public Microsoft.Xrm.Client.CrmEntityReference ModifiedOnBehalfBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ModifiedOnBehalfBy", "modifiedonbehalfby", value);
				}
			}

			/// <summary>
			/// Type a descriptive name for the form or dashboard.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("name")]
			public string Name {
				get {
					return this.GetAttributeValue<string>("name");
				}
				set {
					this.SetAttributeValue<string>("Name", "name", value);
				}
			}

			/// <summary>
			/// Shows the record type (entity) code that the form applies to.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("objecttypecode")]
			public string ObjectTypeCode {
				get {
					return this.GetAttributeValue<string>("objecttypecode");
				}
				set {
					this.SetAttributeValue<string>("ObjectTypeCode", "objecttypecode", value);
				}
			}

			/// <summary>
			/// Enter the user or team who is assigned to manage the record. This field is updated every time the record is assigned to a different user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ownerid")]
			public Microsoft.Xrm.Client.CrmEntityReference OwnerId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ownerid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("OwnerId", "ownerid", value);
				}
			}

			/// <summary>
			/// Shows the business unit that the record owner belongs to.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningbusinessunit")]
			public Microsoft.Xrm.Client.CrmEntityReference OwningBusinessUnit {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningbusinessunit");
				}
			}

			/// <summary>
			/// Unique identifier of the team who owns the dashboard.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningteam")]
			public Microsoft.Xrm.Client.CrmEntityReference OwningTeam {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningteam");
				}
			}

			/// <summary>
			/// Unique identifier of the user who owns the dashboard.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owninguser")]
			public Microsoft.Xrm.Client.CrmEntityReference OwningUser {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owninguser");
				}
			}

			/// <summary>
			/// Select the form type.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("type")]
			public System.Nullable<int> Type {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("type");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("Type", "type", value);
				}
			}

			/// <summary>
			/// Unique identifier of the user dashboard.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("userformid")]
			public System.Nullable<System.Guid> UserFormId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("userformid");
				}
				set {
					this.SetPrimaryIdAttributeValue<System.Nullable<System.Guid>>("UserFormId", "userformid", value);
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("userformid")]
			public override System.Guid Id {
				get {
					return base.Id;
				}
				set {
					this.UserFormId = value;
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
			public System.Nullable<long> VersionNumber {
				get {
					return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
				}
			}

			/// <summary>
			/// Constructor for populating via LINQ queries given a LINQ anonymous type
			/// <param name="anonymousType">LINQ anonymous type.</param>
			/// </summary>
			public UserForm(object anonymousType) :
					this() {
				foreach (var p in anonymousType.GetType().GetProperties()) {
					var value = p.GetValue(anonymousType, null);
					var name = p.Name.ToLower();

					if (name.EndsWith("enum") && value.GetType().BaseType == typeof(System.Enum)) {
						value = new Microsoft.Xrm.Sdk.OptionSetValue((int)value);
						name = name.Remove(name.Length - "enum".Length);
					}

					switch (name) {
						case "id":
							base.Id = (System.Guid)value;
							Attributes["userformid"] = base.Id;
							break;
						case "userformid":
							var id = (System.Nullable<System.Guid>)value;
							if (id == null) { continue; }
							base.Id = id.Value;
							Attributes[name] = base.Id;
							break;
						case "formattedvalues":
							// Add Support for FormattedValues
							FormattedValues.AddRange((Microsoft.Xrm.Sdk.FormattedValueCollection)value);
							break;
						default:
							Attributes[name] = value;
							break;
					}
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("type")]
			public virtual UserForm_Type? TypeEnum {
				get {
					return ((UserForm_Type?)(EntityOptionSetEnum.GetEnum(this, "type")));
				}
				set {
					Type = (int?)value;
				}
			}
		}

		/// <summary>
		/// Chart attached to an entity.
		/// </summary>
		[System.Runtime.Serialization.DataContractAttribute()]
		[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("userqueryvisualization")]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.0.0.9369")]
		[System.Data.Services.Common.DataServiceKeyAttribute("Id")]
		[System.Data.Services.IgnorePropertiesAttribute("Item", "Attributes", "EntityState", "FormattedValues", "RelatedEntities", "ExtensionData")]
		[Microsoft.Xrm.Client.Metadata.EntityAttribute("UserQueryVisualizationSet")]
		public partial class UserQueryVisualization : Microsoft.Xrm.Client.CrmEntity {

			public static class Fields {
				public const string ChartType = "charttype";
				public const string CreatedBy = "createdby";
				public const string CreatedOn = "createdon";
				public const string CreatedOnBehalfBy = "createdonbehalfby";
				public const string DataDescription = "datadescription";
				public const string Description = "description";
				public const string IsDefault = "isdefault";
				public const string ModifiedBy = "modifiedby";
				public const string ModifiedOn = "modifiedon";
				public const string ModifiedOnBehalfBy = "modifiedonbehalfby";
				public const string Name = "name";
				public const string OwnerId = "ownerid";
				public const string OwningBusinessUnit = "owningbusinessunit";
				public const string OwningTeam = "owningteam";
				public const string OwningUser = "owninguser";
				public const string PresentationDescription = "presentationdescription";
				public const string PrimaryEntityTypeCode = "primaryentitytypecode";
				public const string UserQueryVisualizationId = "userqueryvisualizationid";
				public const string Id = "userqueryvisualizationid";
				public const string VersionNumber = "versionnumber";
				public const string WebResourceId = "webresourceid";
			}

			/// <summary>
			/// Default Constructor.
			/// </summary>
			public UserQueryVisualization() :
					base(EntityLogicalName) {
			}

			public const string EntityLogicalName = "userqueryvisualization";

			public const string PrimaryIdAttribute = "userqueryvisualizationid";

			public const string PrimaryNameAttribute = "name";

			public const int EntityTypeCode = 1112;

			/// <summary>
			/// Indicates the library used to render the visualization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("charttype")]
			public System.Nullable<int> ChartType {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("charttype");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("ChartType", "charttype", value);
				}
			}

			/// <summary>
			/// Shows who created the record.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
			public Microsoft.Xrm.Client.CrmEntityReference CreatedBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
				}
			}

			/// <summary>
			/// Shows the date and time when the record was created. The date and time are displayed in the time zone selected in Microsoft Dynamics 365 options.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
			public System.Nullable<System.DateTime> CreatedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
				}
			}

			/// <summary>
			/// Shows who created the record on behalf of another user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
			public Microsoft.Xrm.Client.CrmEntityReference CreatedOnBehalfBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("CreatedOnBehalfBy", "createdonbehalfby", value);
				}
			}

			/// <summary>
			/// Shows the fields that are used to display data in a chart, stored in XML format.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("datadescription")]
			public string DataDescription {
				get {
					return this.GetAttributeValue<string>("datadescription");
				}
				set {
					this.SetAttributeValue<string>("DataDescription", "datadescription", value);
				}
			}

			/// <summary>
			/// Type additional information to describe the chart, such as the filter criteria or intended audience.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("description")]
			public string Description {
				get {
					return this.GetAttributeValue<string>("description");
				}
				set {
					this.SetAttributeValue<string>("Description", "description", value);
				}
			}

			/// <summary>
			/// Select whether the chart is the default chart for the view that it is associated with.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isdefault")]
			public System.Nullable<bool> IsDefault {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isdefault");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsDefault", "isdefault", value);
				}
			}

			/// <summary>
			/// Shows who last updated the record.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
			public Microsoft.Xrm.Client.CrmEntityReference ModifiedBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
				}
			}

			/// <summary>
			/// Shows the date and time when the record was last updated. The date and time are displayed in the time zone selected in Microsoft Dynamics 365 options.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
			public System.Nullable<System.DateTime> ModifiedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
				}
			}

			/// <summary>
			/// Shows who created the record on behalf of another user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
			public Microsoft.Xrm.Client.CrmEntityReference ModifiedOnBehalfBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ModifiedOnBehalfBy", "modifiedonbehalfby", value);
				}
			}

			/// <summary>
			/// Type a descriptive name for the chart.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("name")]
			public string Name {
				get {
					return this.GetAttributeValue<string>("name");
				}
				set {
					this.SetAttributeValue<string>("Name", "name", value);
				}
			}

			/// <summary>
			/// Enter the user or team who is assigned to manage the record. This field is updated every time the record is assigned to a different user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ownerid")]
			public Microsoft.Xrm.Client.CrmEntityReference OwnerId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ownerid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("OwnerId", "ownerid", value);
				}
			}

			/// <summary>
			/// Shows the business unit that the record owner belongs to.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningbusinessunit")]
			public Microsoft.Xrm.Client.CrmEntityReference OwningBusinessUnit {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningbusinessunit");
				}
			}

			/// <summary>
			/// Unique identifier of the team who owns the user chart.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningteam")]
			public Microsoft.Xrm.Client.CrmEntityReference OwningTeam {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningteam");
				}
			}

			/// <summary>
			/// Unique identifier of the team who owns the user chart.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owninguser")]
			public Microsoft.Xrm.Client.CrmEntityReference OwningUser {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owninguser");
				}
			}

			/// <summary>
			/// Contains the chart's formatting details and presentation properties, stored in XML format.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("presentationdescription")]
			public string PresentationDescription {
				get {
					return this.GetAttributeValue<string>("presentationdescription");
				}
				set {
					this.SetAttributeValue<string>("PresentationDescription", "presentationdescription", value);
				}
			}

			/// <summary>
			/// Type of entity which the user chart is attached.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("primaryentitytypecode")]
			public string PrimaryEntityTypeCode {
				get {
					return this.GetAttributeValue<string>("primaryentitytypecode");
				}
				set {
					this.SetAttributeValue<string>("PrimaryEntityTypeCode", "primaryentitytypecode", value);
				}
			}

			/// <summary>
			/// Unique identifier of the user chart.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("userqueryvisualizationid")]
			public System.Nullable<System.Guid> UserQueryVisualizationId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("userqueryvisualizationid");
				}
				set {
					this.SetPrimaryIdAttributeValue<System.Nullable<System.Guid>>("UserQueryVisualizationId", "userqueryvisualizationid", value);
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("userqueryvisualizationid")]
			public override System.Guid Id {
				get {
					return base.Id;
				}
				set {
					this.UserQueryVisualizationId = value;
				}
			}

			/// <summary>
			/// Version number of the user chart.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
			public System.Nullable<long> VersionNumber {
				get {
					return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
				}
			}

			/// <summary>
			/// Shows the web resource that will be displayed in the chart to the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("webresourceid")]
			public Microsoft.Xrm.Client.CrmEntityReference WebResourceId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("webresourceid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("WebResourceId", "webresourceid", value);
				}
			}

			/// <summary>
			/// Constructor for populating via LINQ queries given a LINQ anonymous type
			/// <param name="anonymousType">LINQ anonymous type.</param>
			/// </summary>
			public UserQueryVisualization(object anonymousType) :
					this() {
				foreach (var p in anonymousType.GetType().GetProperties()) {
					var value = p.GetValue(anonymousType, null);
					var name = p.Name.ToLower();

					if (name.EndsWith("enum") && value.GetType().BaseType == typeof(System.Enum)) {
						value = new Microsoft.Xrm.Sdk.OptionSetValue((int)value);
						name = name.Remove(name.Length - "enum".Length);
					}

					switch (name) {
						case "id":
							base.Id = (System.Guid)value;
							Attributes["userqueryvisualizationid"] = base.Id;
							break;
						case "userqueryvisualizationid":
							var id = (System.Nullable<System.Guid>)value;
							if (id == null) { continue; }
							base.Id = id.Value;
							Attributes[name] = base.Id;
							break;
						case "formattedvalues":
							// Add Support for FormattedValues
							FormattedValues.AddRange((Microsoft.Xrm.Sdk.FormattedValueCollection)value);
							break;
						default:
							Attributes[name] = value;
							break;
					}
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("charttype")]
			public virtual UserQueryVisualization_ChartType? ChartTypeEnum {
				get {
					return ((UserQueryVisualization_ChartType?)(EntityOptionSetEnum.GetEnum(this, "charttype")));
				}
				set {
					ChartType = (int?)value;
				}
			}
		}

		/// <summary>
		/// User's preferred settings.
		/// </summary>
		[System.Runtime.Serialization.DataContractAttribute()]
		[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("usersettings")]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.0.0.9369")]
		[System.Data.Services.Common.DataServiceKeyAttribute("Id")]
		[System.Data.Services.IgnorePropertiesAttribute("Item", "Attributes", "EntityState", "FormattedValues", "RelatedEntities", "ExtensionData")]
		[Microsoft.Xrm.Client.Metadata.EntityAttribute("UserSettingsSet")]
		public partial class UserSettings : Microsoft.Xrm.Client.CrmEntity {

			public static class Fields {
				public const string AddressBookSyncInterval = "addressbooksyncinterval";
				public const string AdvancedFindStartupMode = "advancedfindstartupmode";
				public const string AllowEmailCredentials = "allowemailcredentials";
				public const string AMDesignator = "amdesignator";
				public const string AutoCreateContactOnPromote = "autocreatecontactonpromote";
				public const string BusinessUnitId = "businessunitid";
				public const string CalendarType = "calendartype";
				public const string CreatedBy = "createdby";
				public const string CreatedOn = "createdon";
				public const string CreatedOnBehalfBy = "createdonbehalfby";
				public const string CurrencyDecimalPrecision = "currencydecimalprecision";
				public const string CurrencyFormatCode = "currencyformatcode";
				public const string CurrencySymbol = "currencysymbol";
				public const string DataValidationModeForExportToExcel = "datavalidationmodeforexporttoexcel";
				public const string DateFormatCode = "dateformatcode";
				public const string DateFormatString = "dateformatstring";
				public const string DateSeparator = "dateseparator";
				public const string DecimalSymbol = "decimalsymbol";
				public const string DefaultCalendarView = "defaultcalendarview";
				public const string DefaultCountryCode = "defaultcountrycode";
				public const string DefaultDashboardId = "defaultdashboardid";
				public const string DefaultSearchExperience = "defaultsearchexperience";
				public const string EmailPassword = "emailpassword";
				public const string EmailUsername = "emailusername";
				public const string EntityFormMode = "entityformmode";
				public const string FullNameConventionCode = "fullnameconventioncode";
				public const string GetStartedPaneContentEnabled = "getstartedpanecontentenabled";
				public const string HelpLanguageId = "helplanguageid";
				public const string HomepageArea = "homepagearea";
				public const string HomepageLayout = "homepagelayout";
				public const string HomepageSubarea = "homepagesubarea";
				public const string IgnoreUnsolicitedEmail = "ignoreunsolicitedemail";
				public const string IncomingEmailFilteringMethod = "incomingemailfilteringmethod";
				public const string IsAppsForCrmAlertDismissed = "isappsforcrmalertdismissed";
				public const string IsAutoDataCaptureEnabled = "isautodatacaptureenabled";
				public const string IsDefaultCountryCodeCheckEnabled = "isdefaultcountrycodecheckenabled";
				public const string IsDuplicateDetectionEnabledWhenGoingOnline = "isduplicatedetectionenabledwhengoingonline";
				public const string IsGuidedHelpEnabled = "isguidedhelpenabled";
				public const string IsResourceBookingExchangeSyncEnabled = "isresourcebookingexchangesyncenabled";
				public const string IsSendAsAllowed = "issendasallowed";
				public const string LastAlertsViewedTime = "lastalertsviewedtime";
				public const string LocaleId = "localeid";
				public const string LongDateFormatCode = "longdateformatcode";
				public const string ModifiedBy = "modifiedby";
				public const string ModifiedOn = "modifiedon";
				public const string ModifiedOnBehalfBy = "modifiedonbehalfby";
				public const string NegativeCurrencyFormatCode = "negativecurrencyformatcode";
				public const string NegativeFormatCode = "negativeformatcode";
				public const string NextTrackingNumber = "nexttrackingnumber";
				public const string NumberGroupFormat = "numbergroupformat";
				public const string NumberSeparator = "numberseparator";
				public const string OfflineSyncInterval = "offlinesyncinterval";
				public const string OutlookSyncInterval = "outlooksyncinterval";
				public const string PagingLimit = "paginglimit";
				public const string PersonalizationSettings = "personalizationsettings";
				public const string PMDesignator = "pmdesignator";
				public const string PricingDecimalPrecision = "pricingdecimalprecision";
				public const string ReportScriptErrors = "reportscripterrors";
				public const string ResourceBookingExchangeSyncVersion = "resourcebookingexchangesyncversion";
				public const string ShowWeekNumber = "showweeknumber";
				public const string SplitViewState = "splitviewstate";
				public const string SyncContactCompany = "synccontactcompany";
				public const string SystemUserId = "systemuserid";
				public const string Id = "systemuserid";
				public const string TimeFormatCode = "timeformatcode";
				public const string TimeFormatString = "timeformatstring";
				public const string TimeSeparator = "timeseparator";
				public const string TimeZoneBias = "timezonebias";
				public const string TimeZoneCode = "timezonecode";
				public const string TimeZoneDaylightBias = "timezonedaylightbias";
				public const string TimeZoneDaylightDay = "timezonedaylightday";
				public const string TimeZoneDaylightDayOfWeek = "timezonedaylightdayofweek";
				public const string TimeZoneDaylightHour = "timezonedaylighthour";
				public const string TimeZoneDaylightMinute = "timezonedaylightminute";
				public const string TimeZoneDaylightMonth = "timezonedaylightmonth";
				public const string TimeZoneDaylightSecond = "timezonedaylightsecond";
				public const string TimeZoneDaylightYear = "timezonedaylightyear";
				public const string TimeZoneStandardBias = "timezonestandardbias";
				public const string TimeZoneStandardDay = "timezonestandardday";
				public const string TimeZoneStandardDayOfWeek = "timezonestandarddayofweek";
				public const string TimeZoneStandardHour = "timezonestandardhour";
				public const string TimeZoneStandardMinute = "timezonestandardminute";
				public const string TimeZoneStandardMonth = "timezonestandardmonth";
				public const string TimeZoneStandardSecond = "timezonestandardsecond";
				public const string TimeZoneStandardYear = "timezonestandardyear";
				public const string TrackingTokenId = "trackingtokenid";
				public const string TransactionCurrencyId = "transactioncurrencyid";
				public const string UILanguageId = "uilanguageid";
				public const string UseCrmFormForAppointment = "usecrmformforappointment";
				public const string UseCrmFormForContact = "usecrmformforcontact";
				public const string UseCrmFormForEmail = "usecrmformforemail";
				public const string UseCrmFormForTask = "usecrmformfortask";
				public const string UseImageStrips = "useimagestrips";
				public const string UserProfile = "userprofile";
				public const string VersionNumber = "versionnumber";
				public const string VisualizationPaneLayout = "visualizationpanelayout";
				public const string WorkdayStartTime = "workdaystarttime";
				public const string WorkdayStopTime = "workdaystoptime";
			}

			/// <summary>
			/// Default Constructor.
			/// </summary>
			public UserSettings() :
					base(EntityLogicalName) {
			}

			public const string EntityLogicalName = "usersettings";

			public const string PrimaryIdAttribute = "systemuserid";

			public const int EntityTypeCode = 150;

			/// <summary>
			/// Normal polling frequency used for address book synchronization in Microsoft Office Outlook.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("addressbooksyncinterval")]
			public System.Nullable<int> AddressBookSyncInterval {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("addressbooksyncinterval");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("AddressBookSyncInterval", "addressbooksyncinterval", value);
				}
			}

			/// <summary>
			/// Default mode, such as simple or detailed, for advanced find.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("advancedfindstartupmode")]
			public System.Nullable<int> AdvancedFindStartupMode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("advancedfindstartupmode");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("AdvancedFindStartupMode", "advancedfindstartupmode", value);
				}
			}

			/// <summary>
			/// This attribute is no longer used. The data is now in the Mailbox.AllowEmailConnectorToUseCredentials attribute.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("allowemailcredentials")]
			[System.ObsoleteAttribute()]
			public System.Nullable<bool> AllowEmailCredentials {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("allowemailcredentials");
				}
			}

			/// <summary>
			/// AM designator to use in Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("amdesignator")]
			public string AMDesignator {
				get {
					return this.GetAttributeValue<string>("amdesignator");
				}
				set {
					this.SetAttributeValue<string>("AMDesignator", "amdesignator", value);
				}
			}

			/// <summary>
			/// Auto-create contact on client promote
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("autocreatecontactonpromote")]
			public System.Nullable<int> AutoCreateContactOnPromote {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("autocreatecontactonpromote");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("AutoCreateContactOnPromote", "autocreatecontactonpromote", value);
				}
			}

			/// <summary>
			/// Unique identifier of the business unit with which the user is associated.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("businessunitid")]
			public System.Nullable<System.Guid> BusinessUnitId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("businessunitid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("BusinessUnitId", "businessunitid", value);
				}
			}

			/// <summary>
			/// Calendar type for the system. Set to Gregorian US by default.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("calendartype")]
			public System.Nullable<int> CalendarType {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("calendartype");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("CalendarType", "calendartype", value);
				}
			}

			/// <summary>
			/// Unique identifier of the user who created the user settings.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
			public Microsoft.Xrm.Client.CrmEntityReference CreatedBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
				}
			}

			/// <summary>
			/// Date and time when the user settings object was created.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
			public System.Nullable<System.DateTime> CreatedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
				}
			}

			/// <summary>
			/// Unique identifier of the delegate user who created the usersettings.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
			public Microsoft.Xrm.Client.CrmEntityReference CreatedOnBehalfBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("CreatedOnBehalfBy", "createdonbehalfby", value);
				}
			}

			/// <summary>
			/// Number of decimal places that can be used for currency.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("currencydecimalprecision")]
			[System.ObsoleteAttribute()]
			public System.Nullable<int> CurrencyDecimalPrecision {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("currencydecimalprecision");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("CurrencyDecimalPrecision", "currencydecimalprecision", value);
				}
			}

			/// <summary>
			/// Information about how currency symbols are placed in Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("currencyformatcode")]
			public System.Nullable<int> CurrencyFormatCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("currencyformatcode");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("CurrencyFormatCode", "currencyformatcode", value);
				}
			}

			/// <summary>
			/// Symbol used for currency in Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("currencysymbol")]
			public string CurrencySymbol {
				get {
					return this.GetAttributeValue<string>("currencysymbol");
				}
				set {
					this.SetAttributeValue<string>("CurrencySymbol", "currencysymbol", value);
				}
			}

			/// <summary>
			/// Information that specifies the level of data validation in excel worksheets exported in a format suitable for import.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("datavalidationmodeforexporttoexcel")]
			public System.Nullable<int> DataValidationModeForExportToExcel {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("datavalidationmodeforexporttoexcel");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("DataValidationModeForExportToExcel", "datavalidationmodeforexporttoexcel", value);
				}
			}

			/// <summary>
			/// Information about how the date is displayed in Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("dateformatcode")]
			public System.Nullable<int> DateFormatCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("dateformatcode");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("DateFormatCode", "dateformatcode", value);
				}
			}

			/// <summary>
			/// String showing how the date is displayed throughout Microsoft 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("dateformatstring")]
			public string DateFormatString {
				get {
					return this.GetAttributeValue<string>("dateformatstring");
				}
				set {
					this.SetAttributeValue<string>("DateFormatString", "dateformatstring", value);
				}
			}

			/// <summary>
			/// Character used to separate the month, the day, and the year in dates in Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("dateseparator")]
			public string DateSeparator {
				get {
					return this.GetAttributeValue<string>("dateseparator");
				}
				set {
					this.SetAttributeValue<string>("DateSeparator", "dateseparator", value);
				}
			}

			/// <summary>
			/// Symbol used for decimal in Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("decimalsymbol")]
			public string DecimalSymbol {
				get {
					return this.GetAttributeValue<string>("decimalsymbol");
				}
				set {
					this.SetAttributeValue<string>("DecimalSymbol", "decimalsymbol", value);
				}
			}

			/// <summary>
			/// Default calendar view for the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("defaultcalendarview")]
			public System.Nullable<int> DefaultCalendarView {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("defaultcalendarview");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("DefaultCalendarView", "defaultcalendarview", value);
				}
			}

			/// <summary>
			/// Text area to enter default country code.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("defaultcountrycode")]
			public string DefaultCountryCode {
				get {
					return this.GetAttributeValue<string>("defaultcountrycode");
				}
				set {
					this.SetAttributeValue<string>("DefaultCountryCode", "defaultcountrycode", value);
				}
			}

			/// <summary>
			/// Unique identifier of the default dashboard.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("defaultdashboardid")]
			public System.Nullable<System.Guid> DefaultDashboardId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("defaultdashboardid");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.Guid>>("DefaultDashboardId", "defaultdashboardid", value);
				}
			}

			/// <summary>
			/// Default search experience for the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("defaultsearchexperience")]
			public System.Nullable<int> DefaultSearchExperience {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("defaultsearchexperience");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("DefaultSearchExperience", "defaultsearchexperience", value);
				}
			}

			/// <summary>
			/// This attribute is no longer used. The data is now in the Mailbox.Password attribute.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("emailpassword")]
			[System.ObsoleteAttribute()]
			public string EmailPassword {
				get {
					return this.GetAttributeValue<string>("emailpassword");
				}
			}

			/// <summary>
			/// This attribute is no longer used. The data is now in the Mailbox.UserName attribute.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("emailusername")]
			[System.ObsoleteAttribute()]
			public string EmailUsername {
				get {
					return this.GetAttributeValue<string>("emailusername");
				}
			}

			/// <summary>
			/// Indicates the form mode to be used.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityformmode")]
			public System.Nullable<int> EntityFormMode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("entityformmode");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("EntityFormMode", "entityformmode", value);
				}
			}

			/// <summary>
			/// Order in which names are to be displayed in Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("fullnameconventioncode")]
			public System.Nullable<int> FullNameConventionCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("fullnameconventioncode");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("FullNameConventionCode", "fullnameconventioncode", value);
				}
			}

			/// <summary>
			/// Information that specifies whether the Get Started pane in lists is enabled.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("getstartedpanecontentenabled")]
			public System.Nullable<bool> GetStartedPaneContentEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("getstartedpanecontentenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("GetStartedPaneContentEnabled", "getstartedpanecontentenabled", value);
				}
			}

			/// <summary>
			/// Unique identifier of the Help language.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("helplanguageid")]
			public System.Nullable<int> HelpLanguageId {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("helplanguageid");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("HelpLanguageId", "helplanguageid", value);
				}
			}

			/// <summary>
			/// Web site home page for the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("homepagearea")]
			public string HomepageArea {
				get {
					return this.GetAttributeValue<string>("homepagearea");
				}
				set {
					this.SetAttributeValue<string>("HomepageArea", "homepagearea", value);
				}
			}

			/// <summary>
			/// Configuration of the home page layout.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("homepagelayout")]
			public string HomepageLayout {
				get {
					return this.GetAttributeValue<string>("homepagelayout");
				}
				set {
					this.SetAttributeValue<string>("HomepageLayout", "homepagelayout", value);
				}
			}

			/// <summary>
			/// Web site page for the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("homepagesubarea")]
			public string HomepageSubarea {
				get {
					return this.GetAttributeValue<string>("homepagesubarea");
				}
				set {
					this.SetAttributeValue<string>("HomepageSubarea", "homepagesubarea", value);
				}
			}

			/// <summary>
			/// Information that specifies whether a user account is to ignore unsolicited email (deprecated).
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ignoreunsolicitedemail")]
			public System.Nullable<bool> IgnoreUnsolicitedEmail {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("ignoreunsolicitedemail");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IgnoreUnsolicitedEmail", "ignoreunsolicitedemail", value);
				}
			}

			/// <summary>
			/// Incoming email filtering method.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("incomingemailfilteringmethod")]
			public System.Nullable<int> IncomingEmailFilteringMethod {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("incomingemailfilteringmethod");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("IncomingEmailFilteringMethod", "incomingemailfilteringmethod", value);
				}
			}

			/// <summary>
			/// Show or dismiss alert for Apps for 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isappsforcrmalertdismissed")]
			public System.Nullable<bool> IsAppsForCrmAlertDismissed {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isappsforcrmalertdismissed");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsAppsForCrmAlertDismissed", "isappsforcrmalertdismissed", value);
				}
			}

			/// <summary>
			/// Indicates whether to use the Auto Capture feature enabled or not.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isautodatacaptureenabled")]
			public System.Nullable<bool> IsAutoDataCaptureEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isautodatacaptureenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsAutoDataCaptureEnabled", "isautodatacaptureenabled", value);
				}
			}

			/// <summary>
			/// Enable or disable country code selection .
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isdefaultcountrycodecheckenabled")]
			public System.Nullable<bool> IsDefaultCountryCodeCheckEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isdefaultcountrycodecheckenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsDefaultCountryCodeCheckEnabled", "isdefaultcountrycodecheckenabled", value);
				}
			}

			/// <summary>
			/// Indicates if duplicate detection is enabled when going online.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isduplicatedetectionenabledwhengoingonline")]
			public System.Nullable<bool> IsDuplicateDetectionEnabledWhenGoingOnline {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isduplicatedetectionenabledwhengoingonline");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsDuplicateDetectionEnabledWhenGoingOnline", "isduplicatedetectionenabledwhengoingonline", value);
				}
			}

			/// <summary>
			/// Enable or disable guided help.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isguidedhelpenabled")]
			public System.Nullable<bool> IsGuidedHelpEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isguidedhelpenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsGuidedHelpEnabled", "isguidedhelpenabled", value);
				}
			}

			/// <summary>
			/// Indicates if the synchronization of user resource booking with Exchange is enabled at user level.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isresourcebookingexchangesyncenabled")]
			public System.Nullable<bool> IsResourceBookingExchangeSyncEnabled {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("isresourcebookingexchangesyncenabled");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsResourceBookingExchangeSyncEnabled", "isresourcebookingexchangesyncenabled", value);
				}
			}

			/// <summary>
			/// Indicates if send as other user privilege is enabled or not.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("issendasallowed")]
			public System.Nullable<bool> IsSendAsAllowed {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("issendasallowed");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("IsSendAsAllowed", "issendasallowed", value);
				}
			}

			/// <summary>
			/// Shows the last time when the traces were read from the database.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("lastalertsviewedtime")]
			public System.Nullable<System.DateTime> LastAlertsViewedTime {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("lastalertsviewedtime");
				}
				set {
					this.SetAttributeValue<System.Nullable<System.DateTime>>("LastAlertsViewedTime", "lastalertsviewedtime", value);
				}
			}

			/// <summary>
			/// Unique identifier of the user locale.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("localeid")]
			public System.Nullable<int> LocaleId {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("localeid");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("LocaleId", "localeid", value);
				}
			}

			/// <summary>
			/// Information that specifies how Long Date is displayed throughout Microsoft 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("longdateformatcode")]
			public System.Nullable<int> LongDateFormatCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("longdateformatcode");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("LongDateFormatCode", "longdateformatcode", value);
				}
			}

			/// <summary>
			/// Unique identifier of the user who last modified the user settings.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
			public Microsoft.Xrm.Client.CrmEntityReference ModifiedBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
				}
			}

			/// <summary>
			/// Date and time when the user settings object was last modified.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
			public System.Nullable<System.DateTime> ModifiedOn {
				get {
					return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
				}
			}

			/// <summary>
			/// Unique identifier of the delegate user who last modified the usersettings.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
			public Microsoft.Xrm.Client.CrmEntityReference ModifiedOnBehalfBy {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ModifiedOnBehalfBy", "modifiedonbehalfby", value);
				}
			}

			/// <summary>
			/// Information that specifies how negative currency numbers are displayed in Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("negativecurrencyformatcode")]
			public System.Nullable<int> NegativeCurrencyFormatCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("negativecurrencyformatcode");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("NegativeCurrencyFormatCode", "negativecurrencyformatcode", value);
				}
			}

			/// <summary>
			/// Information that specifies how negative numbers are displayed in Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("negativeformatcode")]
			public System.Nullable<int> NegativeFormatCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("negativeformatcode");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("NegativeFormatCode", "negativeformatcode", value);
				}
			}

			/// <summary>
			/// Next tracking number.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("nexttrackingnumber")]
			public System.Nullable<int> NextTrackingNumber {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("nexttrackingnumber");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("NextTrackingNumber", "nexttrackingnumber", value);
				}
			}

			/// <summary>
			/// Information that specifies how numbers are grouped in Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("numbergroupformat")]
			public string NumberGroupFormat {
				get {
					return this.GetAttributeValue<string>("numbergroupformat");
				}
				set {
					this.SetAttributeValue<string>("NumberGroupFormat", "numbergroupformat", value);
				}
			}

			/// <summary>
			/// Symbol used for number separation in Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("numberseparator")]
			public string NumberSeparator {
				get {
					return this.GetAttributeValue<string>("numberseparator");
				}
				set {
					this.SetAttributeValue<string>("NumberSeparator", "numberseparator", value);
				}
			}

			/// <summary>
			/// Normal polling frequency used for background offline synchronization in Microsoft Office Outlook.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("offlinesyncinterval")]
			public System.Nullable<int> OfflineSyncInterval {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("offlinesyncinterval");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("OfflineSyncInterval", "offlinesyncinterval", value);
				}
			}

			/// <summary>
			/// Normal polling frequency used for record synchronization in Microsoft Office Outlook.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("outlooksyncinterval")]
			public System.Nullable<int> OutlookSyncInterval {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("outlooksyncinterval");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("OutlookSyncInterval", "outlooksyncinterval", value);
				}
			}

			/// <summary>
			/// Information that specifies how many items to list on a page in list views.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("paginglimit")]
			public System.Nullable<int> PagingLimit {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("paginglimit");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("PagingLimit", "paginglimit", value);
				}
			}

			/// <summary>
			/// For internal use only.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("personalizationsettings")]
			public string PersonalizationSettings {
				get {
					return this.GetAttributeValue<string>("personalizationsettings");
				}
				set {
					this.SetAttributeValue<string>("PersonalizationSettings", "personalizationsettings", value);
				}
			}

			/// <summary>
			/// PM designator to use in Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("pmdesignator")]
			public string PMDesignator {
				get {
					return this.GetAttributeValue<string>("pmdesignator");
				}
				set {
					this.SetAttributeValue<string>("PMDesignator", "pmdesignator", value);
				}
			}

			/// <summary>
			/// Number of decimal places that can be used for prices.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("pricingdecimalprecision")]
			[System.ObsoleteAttribute()]
			public System.Nullable<int> PricingDecimalPrecision {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("pricingdecimalprecision");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("PricingDecimalPrecision", "pricingdecimalprecision", value);
				}
			}

			/// <summary>
			/// Picklist for selecting the user preference for reporting scripting errors.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("reportscripterrors")]
			public System.Nullable<int> ReportScriptErrors {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("reportscripterrors");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("ReportScriptErrors", "reportscripterrors", value);
				}
			}

			/// <summary>
			/// The version number for resource booking synchronization with Exchange.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("resourcebookingexchangesyncversion")]
			public System.Nullable<long> ResourceBookingExchangeSyncVersion {
				get {
					return this.GetAttributeValue<System.Nullable<long>>("resourcebookingexchangesyncversion");
				}
				set {
					this.SetAttributeValue<System.Nullable<long>>("ResourceBookingExchangeSyncVersion", "resourcebookingexchangesyncversion", value);
				}
			}

			/// <summary>
			/// Information that specifies whether to display the week number in calendar displays in Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("showweeknumber")]
			public System.Nullable<bool> ShowWeekNumber {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("showweeknumber");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("ShowWeekNumber", "showweeknumber", value);
				}
			}

			/// <summary>
			/// For Internal use only
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("splitviewstate")]
			public System.Nullable<bool> SplitViewState {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("splitviewstate");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("SplitViewState", "splitviewstate", value);
				}
			}

			/// <summary>
			/// Indicates if the company field in Microsoft Office Outlook items are set during Outlook synchronization.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("synccontactcompany")]
			public System.Nullable<bool> SyncContactCompany {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("synccontactcompany");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("SyncContactCompany", "synccontactcompany", value);
				}
			}

			/// <summary>
			/// Unique identifier of the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("systemuserid")]
			public System.Nullable<System.Guid> SystemUserId {
				get {
					return this.GetAttributeValue<System.Nullable<System.Guid>>("systemuserid");
				}
				set {
					this.SetPrimaryIdAttributeValue<System.Nullable<System.Guid>>("SystemUserId", "systemuserid", value);
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("systemuserid")]
			public override System.Guid Id {
				get {
					return base.Id;
				}
				set {
					this.SystemUserId = value;
				}
			}

			/// <summary>
			/// Information that specifies how the time is displayed in Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timeformatcode")]
			public System.Nullable<int> TimeFormatCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("timeformatcode");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TimeFormatCode", "timeformatcode", value);
				}
			}

			/// <summary>
			/// Text for how time is displayed in Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timeformatstring")]
			public string TimeFormatString {
				get {
					return this.GetAttributeValue<string>("timeformatstring");
				}
				set {
					this.SetAttributeValue<string>("TimeFormatString", "timeformatstring", value);
				}
			}

			/// <summary>
			/// Text for how time is displayed in Microsoft Dynamics 365.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timeseparator")]
			public string TimeSeparator {
				get {
					return this.GetAttributeValue<string>("timeseparator");
				}
				set {
					this.SetAttributeValue<string>("TimeSeparator", "timeseparator", value);
				}
			}

			/// <summary>
			/// Local time zone adjustment for the user. System calculated based on the time zone selected.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezonebias")]
			public System.Nullable<int> TimeZoneBias {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("timezonebias");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TimeZoneBias", "timezonebias", value);
				}
			}

			/// <summary>
			/// Local time zone for the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezonecode")]
			public System.Nullable<int> TimeZoneCode {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("timezonecode");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TimeZoneCode", "timezonecode", value);
				}
			}

			/// <summary>
			/// Local time zone daylight adjustment for the user. System calculated based on the time zone selected.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezonedaylightbias")]
			public System.Nullable<int> TimeZoneDaylightBias {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("timezonedaylightbias");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TimeZoneDaylightBias", "timezonedaylightbias", value);
				}
			}

			/// <summary>
			/// Local time zone daylight day for the user. System calculated based on the time zone selected.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezonedaylightday")]
			public System.Nullable<int> TimeZoneDaylightDay {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("timezonedaylightday");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TimeZoneDaylightDay", "timezonedaylightday", value);
				}
			}

			/// <summary>
			/// Local time zone daylight day of week for the user. System calculated based on the time zone selected in Options.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezonedaylightdayofweek")]
			public System.Nullable<int> TimeZoneDaylightDayOfWeek {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("timezonedaylightdayofweek");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TimeZoneDaylightDayOfWeek", "timezonedaylightdayofweek", value);
				}
			}

			/// <summary>
			/// Local time zone daylight hour for the user. System calculated based on the time zone selected.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezonedaylighthour")]
			public System.Nullable<int> TimeZoneDaylightHour {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("timezonedaylighthour");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TimeZoneDaylightHour", "timezonedaylighthour", value);
				}
			}

			/// <summary>
			/// Local time zone daylight minute for the user. System calculated based on the time zone selected.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezonedaylightminute")]
			public System.Nullable<int> TimeZoneDaylightMinute {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("timezonedaylightminute");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TimeZoneDaylightMinute", "timezonedaylightminute", value);
				}
			}

			/// <summary>
			/// Local time zone daylight month for the user. System calculated based on the time zone selected.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezonedaylightmonth")]
			public System.Nullable<int> TimeZoneDaylightMonth {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("timezonedaylightmonth");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TimeZoneDaylightMonth", "timezonedaylightmonth", value);
				}
			}

			/// <summary>
			/// Local time zone daylight second for the user. System calculated based on the time zone selected.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezonedaylightsecond")]
			public System.Nullable<int> TimeZoneDaylightSecond {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("timezonedaylightsecond");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TimeZoneDaylightSecond", "timezonedaylightsecond", value);
				}
			}

			/// <summary>
			/// Local time zone daylight year for the user. System calculated based on the time zone selected.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezonedaylightyear")]
			public System.Nullable<int> TimeZoneDaylightYear {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("timezonedaylightyear");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TimeZoneDaylightYear", "timezonedaylightyear", value);
				}
			}

			/// <summary>
			/// Local time zone standard time bias for the user. System calculated based on the time zone selected.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezonestandardbias")]
			public System.Nullable<int> TimeZoneStandardBias {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("timezonestandardbias");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TimeZoneStandardBias", "timezonestandardbias", value);
				}
			}

			/// <summary>
			/// Local time zone standard day for the user. System calculated based on the time zone selected.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezonestandardday")]
			public System.Nullable<int> TimeZoneStandardDay {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("timezonestandardday");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TimeZoneStandardDay", "timezonestandardday", value);
				}
			}

			/// <summary>
			/// Local time zone standard day of week for the user. System calculated based on the time zone selected.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezonestandarddayofweek")]
			public System.Nullable<int> TimeZoneStandardDayOfWeek {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("timezonestandarddayofweek");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TimeZoneStandardDayOfWeek", "timezonestandarddayofweek", value);
				}
			}

			/// <summary>
			/// Local time zone standard hour for the user. System calculated based on the time zone selected.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezonestandardhour")]
			public System.Nullable<int> TimeZoneStandardHour {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("timezonestandardhour");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TimeZoneStandardHour", "timezonestandardhour", value);
				}
			}

			/// <summary>
			/// Local time zone standard minute for the user. System calculated based on the time zone selected.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezonestandardminute")]
			public System.Nullable<int> TimeZoneStandardMinute {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("timezonestandardminute");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TimeZoneStandardMinute", "timezonestandardminute", value);
				}
			}

			/// <summary>
			/// Local time zone standard month for the user. System calculated based on the time zone selected.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezonestandardmonth")]
			public System.Nullable<int> TimeZoneStandardMonth {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("timezonestandardmonth");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TimeZoneStandardMonth", "timezonestandardmonth", value);
				}
			}

			/// <summary>
			/// Local time zone standard second for the user. System calculated based on the time zone selected.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezonestandardsecond")]
			public System.Nullable<int> TimeZoneStandardSecond {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("timezonestandardsecond");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TimeZoneStandardSecond", "timezonestandardsecond", value);
				}
			}

			/// <summary>
			/// Local time zone standard year for the user. System calculated based on the time zone selected.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezonestandardyear")]
			public System.Nullable<int> TimeZoneStandardYear {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("timezonestandardyear");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TimeZoneStandardYear", "timezonestandardyear", value);
				}
			}

			/// <summary>
			/// Tracking token ID.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("trackingtokenid")]
			public System.Nullable<int> TrackingTokenId {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("trackingtokenid");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("TrackingTokenId", "trackingtokenid", value);
				}
			}

			/// <summary>
			/// Unique identifier of the default currency of the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("transactioncurrencyid")]
			public Microsoft.Xrm.Client.CrmEntityReference TransactionCurrencyId {
				get {
					return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("transactioncurrencyid");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("TransactionCurrencyId", "transactioncurrencyid", value);
				}
			}

			/// <summary>
			/// Unique identifier of the language in which to view the user interface (UI).
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("uilanguageid")]
			public System.Nullable<int> UILanguageId {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("uilanguageid");
				}
				set {
					this.SetAttributeValue<System.Nullable<int>>("UILanguageId", "uilanguageid", value);
				}
			}

			/// <summary>
			/// Indicates whether to use the Microsoft Dynamics 365 appointment form within Microsoft Office Outlook for creating new appointments.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("usecrmformforappointment")]
			public System.Nullable<bool> UseCrmFormForAppointment {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("usecrmformforappointment");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("UseCrmFormForAppointment", "usecrmformforappointment", value);
				}
			}

			/// <summary>
			/// Indicates whether to use the Microsoft Dynamics 365 contact form within Microsoft Office Outlook for creating new contacts.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("usecrmformforcontact")]
			public System.Nullable<bool> UseCrmFormForContact {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("usecrmformforcontact");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("UseCrmFormForContact", "usecrmformforcontact", value);
				}
			}

			/// <summary>
			/// Indicates whether to use the Microsoft Dynamics 365 email form within Microsoft Office Outlook for creating new emails.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("usecrmformforemail")]
			public System.Nullable<bool> UseCrmFormForEmail {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("usecrmformforemail");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("UseCrmFormForEmail", "usecrmformforemail", value);
				}
			}

			/// <summary>
			/// Indicates whether to use the Microsoft Dynamics 365 task form within Microsoft Office Outlook for creating new tasks.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("usecrmformfortask")]
			public System.Nullable<bool> UseCrmFormForTask {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("usecrmformfortask");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("UseCrmFormForTask", "usecrmformfortask", value);
				}
			}

			/// <summary>
			/// Indicates whether image strips are used to render images.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("useimagestrips")]
			public System.Nullable<bool> UseImageStrips {
				get {
					return this.GetAttributeValue<System.Nullable<bool>>("useimagestrips");
				}
				set {
					this.SetAttributeValue<System.Nullable<bool>>("UseImageStrips", "useimagestrips", value);
				}
			}

			/// <summary>
			/// Specifies user profile ids in comma separated list.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("userprofile")]
			public string UserProfile {
				get {
					return this.GetAttributeValue<string>("userprofile");
				}
				set {
					this.SetAttributeValue<string>("UserProfile", "userprofile", value);
				}
			}

			/// <summary>
			/// 
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
			public System.Nullable<long> VersionNumber {
				get {
					return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
				}
			}

			/// <summary>
			/// The layout of the visualization pane.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("visualizationpanelayout")]
			public System.Nullable<int> VisualizationPaneLayout {
				get {
					return this.GetAttributeValue<System.Nullable<int>>("visualizationpanelayout");
				}
				set {
					this.SetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("VisualizationPaneLayout", "visualizationpanelayout", value);
				}
			}

			/// <summary>
			/// Workday start time for the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("workdaystarttime")]
			public string WorkdayStartTime {
				get {
					return this.GetAttributeValue<string>("workdaystarttime");
				}
				set {
					this.SetAttributeValue<string>("WorkdayStartTime", "workdaystarttime", value);
				}
			}

			/// <summary>
			/// Workday stop time for the user.
			/// </summary>
			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("workdaystoptime")]
			public string WorkdayStopTime {
				get {
					return this.GetAttributeValue<string>("workdaystoptime");
				}
				set {
					this.SetAttributeValue<string>("WorkdayStopTime", "workdaystoptime", value);
				}
			}

			/// <summary>
			/// Constructor for populating via LINQ queries given a LINQ anonymous type
			/// <param name="anonymousType">LINQ anonymous type.</param>
			/// </summary>
			public UserSettings(object anonymousType) :
					this() {
				foreach (var p in anonymousType.GetType().GetProperties()) {
					var value = p.GetValue(anonymousType, null);
					var name = p.Name.ToLower();

					if (name.EndsWith("enum") && value.GetType().BaseType == typeof(System.Enum)) {
						value = new Microsoft.Xrm.Sdk.OptionSetValue((int)value);
						name = name.Remove(name.Length - "enum".Length);
					}

					switch (name) {
						case "id":
							base.Id = (System.Guid)value;
							Attributes["systemuserid"] = base.Id;
							break;
						case "systemuserid":
							var id = (System.Nullable<System.Guid>)value;
							if (id == null) { continue; }
							base.Id = id.Value;
							Attributes[name] = base.Id;
							break;
						case "formattedvalues":
							// Add Support for FormattedValues
							FormattedValues.AddRange((Microsoft.Xrm.Sdk.FormattedValueCollection)value);
							break;
						default:
							Attributes[name] = value;
							break;
					}
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("datavalidationmodeforexporttoexcel")]
			public virtual UserSettings_DataValidationModeForExportToExcel? DataValidationModeForExportToExcelEnum {
				get {
					return ((UserSettings_DataValidationModeForExportToExcel?)(EntityOptionSetEnum.GetEnum(this, "datavalidationmodeforexporttoexcel")));
				}
				set {
					DataValidationModeForExportToExcel = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("defaultsearchexperience")]
			public virtual UserSettings_DefaultSearchExperience? DefaultSearchExperienceEnum {
				get {
					return ((UserSettings_DefaultSearchExperience?)(EntityOptionSetEnum.GetEnum(this, "defaultsearchexperience")));
				}
				set {
					DefaultSearchExperience = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityformmode")]
			public virtual UserSettings_EntityFormMode? EntityFormModeEnum {
				get {
					return ((UserSettings_EntityFormMode?)(EntityOptionSetEnum.GetEnum(this, "entityformmode")));
				}
				set {
					EntityFormMode = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("incomingemailfilteringmethod")]
			public virtual UserSettings_IncomingEmailFilteringMethod? IncomingEmailFilteringMethodEnum {
				get {
					return ((UserSettings_IncomingEmailFilteringMethod?)(EntityOptionSetEnum.GetEnum(this, "incomingemailfilteringmethod")));
				}
				set {
					IncomingEmailFilteringMethod = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("reportscripterrors")]
			public virtual UserSettings_ReportScriptErrors? ReportScriptErrorsEnum {
				get {
					return ((UserSettings_ReportScriptErrors?)(EntityOptionSetEnum.GetEnum(this, "reportscripterrors")));
				}
				set {
					ReportScriptErrors = (int?)value;
				}
			}

			[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("visualizationpanelayout")]
			public virtual UserSettings_VisualizationPaneLayout? VisualizationPaneLayoutEnum {
				get {
					return ((UserSettings_VisualizationPaneLayout?)(EntityOptionSetEnum.GetEnum(this, "visualizationpanelayout")));
				}
				set {
					VisualizationPaneLayout = (int?)value;
				}
			}
		}

		/// <summary>
		/// Represents a source of entities bound to a CRM service. It tracks and manages changes made to the retrieved entities.
		/// </summary>
		[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.0.0.9369")]
		public partial class CrmServiceContext : Microsoft.Xrm.Client.CrmOrganizationServiceContext {

			/// <summary>
			/// Constructor.
			/// </summary>
			public CrmServiceContext() {
			}

			/// <summary>
			/// Constructor.
			/// </summary>
			public CrmServiceContext(Microsoft.Xrm.Client.CrmConnection connection) :
					base(connection) {
			}

			/// <summary>
			/// Constructor.
			/// </summary>
			public CrmServiceContext(string contextName) :
					base(contextName) {
			}

			/// <summary>
			/// Constructor.
			/// </summary>
			public CrmServiceContext(Microsoft.Xrm.Sdk.IOrganizationService service) :
					base(service) {
			}

			/// <summary>
			/// Gets a binding to the set of all <see cref="CrmEarlyBound.AsyncOperation"/> entities.
			/// </summary>
			public System.Linq.IQueryable<CrmEarlyBound.AsyncOperation> AsyncOperationSet {
				get {
					return this.CreateQuery<CrmEarlyBound.AsyncOperation>();
				}
			}

			/// <summary>
			/// Gets a binding to the set of all <see cref="CrmEarlyBound.msus_trip_entry"/> entities.
			/// </summary>
			public System.Linq.IQueryable<CrmEarlyBound.msus_trip_entry> msus_trip_entrySet {
				get {
					return this.CreateQuery<CrmEarlyBound.msus_trip_entry>();
				}
			}

			/// <summary>
			/// Gets a binding to the set of all <see cref="CrmEarlyBound.Organization"/> entities.
			/// </summary>
			public System.Linq.IQueryable<CrmEarlyBound.Organization> OrganizationSet {
				get {
					return this.CreateQuery<CrmEarlyBound.Organization>();
				}
			}

			/// <summary>
			/// Gets a binding to the set of all <see cref="CrmEarlyBound.SavedQueryVisualization"/> entities.
			/// </summary>
			public System.Linq.IQueryable<CrmEarlyBound.SavedQueryVisualization> SavedQueryVisualizationSet {
				get {
					return this.CreateQuery<CrmEarlyBound.SavedQueryVisualization>();
				}
			}

			/// <summary>
			/// Gets a binding to the set of all <see cref="CrmEarlyBound.SystemForm"/> entities.
			/// </summary>
			public System.Linq.IQueryable<CrmEarlyBound.SystemForm> SystemFormSet {
				get {
					return this.CreateQuery<CrmEarlyBound.SystemForm>();
				}
			}

			/// <summary>
			/// Gets a binding to the set of all <see cref="CrmEarlyBound.SystemUser"/> entities.
			/// </summary>
			public System.Linq.IQueryable<CrmEarlyBound.SystemUser> SystemUserSet {
				get {
					return this.CreateQuery<CrmEarlyBound.SystemUser>();
				}
			}

			/// <summary>
			/// Gets a binding to the set of all <see cref="CrmEarlyBound.Task"/> entities.
			/// </summary>
			public System.Linq.IQueryable<CrmEarlyBound.Task> TaskSet {
				get {
					return this.CreateQuery<CrmEarlyBound.Task>();
				}
			}

			/// <summary>
			/// Gets a binding to the set of all <see cref="CrmEarlyBound.Team"/> entities.
			/// </summary>
			public System.Linq.IQueryable<CrmEarlyBound.Team> TeamSet {
				get {
					return this.CreateQuery<CrmEarlyBound.Team>();
				}
			}

			/// <summary>
			/// Gets a binding to the set of all <see cref="CrmEarlyBound.Territory"/> entities.
			/// </summary>
			public System.Linq.IQueryable<CrmEarlyBound.Territory> TerritorySet {
				get {
					return this.CreateQuery<CrmEarlyBound.Territory>();
				}
			}

			/// <summary>
			/// Gets a binding to the set of all <see cref="CrmEarlyBound.UserForm"/> entities.
			/// </summary>
			public System.Linq.IQueryable<CrmEarlyBound.UserForm> UserFormSet {
				get {
					return this.CreateQuery<CrmEarlyBound.UserForm>();
				}
			}

			/// <summary>
			/// Gets a binding to the set of all <see cref="CrmEarlyBound.UserQueryVisualization"/> entities.
			/// </summary>
			public System.Linq.IQueryable<CrmEarlyBound.UserQueryVisualization> UserQueryVisualizationSet {
				get {
					return this.CreateQuery<CrmEarlyBound.UserQueryVisualization>();
				}
			}

			/// <summary>
			/// Gets a binding to the set of all <see cref="CrmEarlyBound.UserSettings"/> entities.
			/// </summary>
			public System.Linq.IQueryable<CrmEarlyBound.UserSettings> UserSettingsSet {
				get {
					return this.CreateQuery<CrmEarlyBound.UserSettings>();
				}
			}
		}

		internal sealed class EntityOptionSetEnum {

			public static System.Nullable<int> GetEnum(Microsoft.Xrm.Sdk.Entity entity, string attributeLogicalName) {
				if (entity.Attributes.ContainsKey(attributeLogicalName)) {
					Microsoft.Xrm.Sdk.OptionSetValue value = entity.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>(attributeLogicalName);
					if (value != null) {
						return value.Value;
					}
				}
				return null;
			}
		}
	}
}
