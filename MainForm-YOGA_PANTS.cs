using System;
using System.ServiceModel;

// These namespaces are found in the Microsoft.Xrm.Sdk.dll assembly
// located in the SDK\bin folder of the SDK download.
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Data.SqlClient;
using Microsoft.GotDotNet;
using System.Reflection;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk.Metadata;

namespace MediSync {
    /// <summary>
    /// Demonstrates how to do basic entity operations like create, retrieve,
    /// update, and delete.
    /// If you want to run this sample repeatedly, you have the option to 
    /// delete all the records created at the end of execution.
    /// </summary>
    public class MainForm {
        
        public static OrganizationServiceProxy _serviceProxy;
        public static IOrganizationService _service;
        public static ServerConnection.Configuration config;

        private bool _cancelCurrentOperation = false;
        public bool CancelCurrentOperation {
            get {
                return _cancelCurrentOperation;
            }
            set {
                _cancelCurrentOperation = value; 
            }
        }
        

        //TODO: Refactor this entire class - it's written as a test - now make it ready for production!
        
        public static DbMonitor dbMonitor;
        private static int DEFAULT_INTERVAL = 60000;
        
        public static void Main(string[] args) {
			//var param1 = args[0];
			//if (!string.IsNullOrEmpty(param1)) {
			//	MessageBox.Show((param1.ToString()));
			//}

			//ConsoleHelper.Spinner.Start();
            CRM.Connect();
            EntityMetadata mdata = JobList.Job.GetEntityMetadata("msus_onhandinventorytotals");
            ConsoleHelper.Spinner.Stop();
            ConsoleHelper.WaitForInput(true, true);
        }

        public static void QueryAndShowAvailableJobs(bool availableOnly = true) {
			
            ConsoleHelper.Clear(true);
            ConsoleHelper.Spinner.Start();
            ConsoleHelper.WriteLine();
            ConsoleHelper.WriteLine("Querying server for available jobs...", ConsoleForeground.Green);
            JobList Jobs = JobList.QueryServerForJobs(availableOnly);
            ConsoleHelper.Spinner.Stop();
            ConsoleHelper.Spinner.Destroy();
            if (Jobs != null) {
                ConsoleHelper.Clear(true);
                Jobs.PrintToConsole();
            }

            

            Console.WriteLine();
            ConsoleHelper.PressAnyKey();
            ConsoleHelper.WaitForInput(true, true);
        }

        public static DbMonitor setupMonitor(String storedProcedureName, int timerInterval) {
            SqlConnection conn = new SqlConnection(DbMonitor.DEFAULT_CONNECTION_STRING);
            SqlCommand sqlCmd = new SqlCommand(storedProcedureName, conn);
            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@MINUTESAGO", (int)50000);
            DbMonitor monitor = new DbMonitor(timerInterval, sqlCmd);
            return monitor;
        }

        public static DbMonitor setupMonitor(String storedProcedureName) {
            return setupMonitor(storedProcedureName, DEFAULT_INTERVAL);
        }

        public static void startDbMonitor() {
            DbMonitor monitor = setupMonitor("[mw_CustomAxViews].[dbo].uspINVENTONHAND_CHANGED_x_MINS_AGO");
            monitor.start();
        }
    }
}