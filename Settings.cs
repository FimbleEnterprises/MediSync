using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediSync { 
    class Settings {

        public static string AXConnString = "Data Source=gu-sxd7e-025\\AX;Initial Catalog=MicrosoftDynamicsAX;Persist Security Info=True;User ID=gu51;Password=WeberVPN";
        public static string DbUser = "gu51";
        public static string DbPass = "WeberVPN";
        public static string CrmProdUrl = "http://gu-sxd7e-019/Medistim/";
        public static string DefaultCrmServerChoice = "1";
        public static string GetJobListQuery = "					SELECT 					  [msus_medisyncId] 					 ,[CreatedOn] 					 ,[CreatedBy] 					 ,[ModifiedOn] 					 ,[ModifiedBy] 					 ,[CreatedOnBehalfBy] 					 ,[ModifiedOnBehalfBy] 					 ,[OwnerId] 					 ,[OwnerIdType] 					 ,[OwningBusinessUnit] 					 ,[statecode]				,[msus_lastwritedate] 					 ,[statuscode] 					 ,[VersionNumber] 					 ,[ImportSequenceNumber] 					 ,[OverriddenCreatedOn] 					 ,[TimeZoneRuleVersionNumber] 					 ,[UTCConversionTimeZoneCode] 					 ,[msus_name] 					 ,[msus_Enabled] 					 ,[msus_Interval] 					 ,[msus_Lastrun] 					 ,[msus_LastRunSuccessful] 					 ,[msus_Priority] 					 ,[msus_Runasuser] 					 ,[msus_Runasuserpassword] 					 ,[new_Targetentity] ,[msus_target_entity_alias] 					 ,[new_AXjoincolumn] 					 , [new_CRMjoincolumn] 					 ,[new_AXTargetCols] 					 ,[new_CRMTargetCols] 					 ,[new_CRMJoinTable] 					 ,[new_AXJoinTable] 					 ,[msus_lastrun_utc] ,[msus_FromClause] 					 ,[msus_axdatecolumn], [msus_exempt_from_full_syncs], [msus_workflow_guid], [msus_workflow_job] ,[msus_set_workflow_status_to], [msus_do_not_delete], [msus_do_not_create], [msus_target_timezone]				FROM [msus_medisyncBase]";
        public static string CRMConnString = "Data Source=gu-sxd7e-025\\CRM;Initial Catalog=Medistim_MSCRM;Persist Security Info=True;User ID=gu51;Password=WeberVPN";
        public static string CrmDbQualifyingPrefix = "[CRM].Medistim_MSCRM.[dbo]";

		// Max is 999 which is also the default
		public static int BatchLimit = 999;

    }
}
