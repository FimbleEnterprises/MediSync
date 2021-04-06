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
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using static MediSync.JobList;
using MediSync.Events;
using System.Threading;
using System.Threading.Tasks;
using MediSync.Interfaces;
using MyEventsHelper;

namespace MediSync.Events {

    public enum MyEvents {
        JobCompletedEvent,
        ReconcileJobCompletedEvent,
        ProgressUpdateEvent
    }

    public class MyEventArgs : EventArgs {
        public MyEventArgs(MyEvents myEvents) {
            this.MyEvents = myEvents;
        }

        public MyEvents MyEvents { get; private set; }
    }

    public class MyPublisher {
        public event EventHandler<MyEventArgs> OnProgressEvent; // 
        public event EventHandler<MyEventArgs> JobCompletedEvent;
        public event EventHandler<MyEventArgs> ReconcileJobCompletedEvent;
        
        public void ReconcileJobDone(Job.Reconciler.ReconcileJob rJob) {
            EventsHelper.Fire(ReconcileJobCompletedEvent, rJob, new MyEventArgs(MyEvents.ReconcileJobCompletedEvent));
        }
        public void JobDone(Job job) {
            EventsHelper.Fire(JobCompletedEvent, job, new MyEventArgs(MyEvents.JobCompletedEvent));
        }
        public void OnProgress(string e) {
            EventsHelper.Fire(OnProgressEvent, e, new MyEventArgs(MyEvents.ProgressUpdateEvent));
        }
    }

    public class MySubscriber {

        public void OnEventFire(object sender, MyEventArgs args) {
            string appendMsg = "";
            bool updateSpinner = false;
            switch (args.MyEvents) {
                case MyEvents.JobCompletedEvent:
                    updateSpinner = true;
                    Job job = (Job)sender;
                    appendMsg = job.msus_name + " completed.";
                    break;
                case MyEvents.ReconcileJobCompletedEvent:
                    Job.Reconciler.ReconcileJob rJob = (Job.Reconciler.ReconcileJob)sender;
                    appendMsg = rJob.OperationType + " completed for job (" + rJob.MasterJob.msus_name + ")";
					rJob.MyReconciler.MasterJob.AppendLog(appendMsg);

					break;
                case MyEvents.ProgressUpdateEvent:
                    appendMsg = sender.ToString();
                    break;
            }

            ThreadStart threadMethod = delegate {
                MainForm.WriteToConsole(appendMsg, updateSpinner);
            };

            Thread thread = new Thread(threadMethod);
            thread.Start();
            thread.Join();
        } 
    }
}

namespace MediSync {
    /// <summary>
    /// Demonstrates how to do basic entity operations like create, retrieve,
    /// update, and delete.
    /// If you want to run this sample repeatedly, you have the option to 
    /// delete all the records created at the end of execution.
    /// </summary>mainFormPublisher.OnProgress("
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
    public static int jobsRunning = 0;
    public static int jobsCompleted = 0;
    static PerrysNetConsole.LoadIndicator Spinner { get; set; }
    public static MyPublisher mainFormPublisher;
    public static MySubscriber mainFormSubscriber;

    public static void Main(string[] args) {
            
        mainFormPublisher = new MyPublisher();
        mainFormSubscriber = new MySubscriber();
        mainFormPublisher.OnProgressEvent += mainFormSubscriber.OnEventFire;

        Console.Title = "MediSync";
        if (args != null && args.Length > 0) {
            for (int i = 0; i < args.Length; i++) {
                args[i] = args[i].ToString().ToLower();
                if (args[i] == "show_config") {
                    var config1 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    MessageBox.Show(config1.FilePath);

                    var config2 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    MessageBox.Show(config2.FilePath);
                } else if (args[i] == "force_full_update") {
					Log.Write.Clear();
					DoAllJobs(true);
				} else if (args[i] == "force_daily_update") {
					Log.Write.Clear();
					DoAllJobs(false, true);
				}  else if (args[i] == "force_daily_update") {
					Log.Write.Clear();
					DoAllJobs(false, true);
				} else if (args[i] == "force_daily_update") {
					Log.Write.Clear();
					DoAllJobs(false, true);
				} else if (args[i] == "reset_password") {
						prepareCrmShit(true);
				}
			}
        } else {
			try {
				Log.Write.Clear();
				DoAllJobs();
			} catch (Exception e) {
				Log.Write.Append(e.Message, e);
				throw;
			}
			System.Environment.Exit(0);
        }
    }
        
    public static void DoAllJobs(bool forcefullupdate = false, bool forceFullDailyUpdate = false) {
            WriteToConsole("Retrieving CRM configurations...", true);
            prepareCrmShit();
			List<Job> jobsToRemoveForSomeReason = new List<Job>();
            WriteToConsole("Getting available jobs...", true);
            JobList.RetrievedJobs = JobList.QueryServerForJobs(true);
            if (JobList.RetrievedJobs == null) {
                return;
            } else {
				for (int i = 0; i < JobList.RetrievedJobs.Count; i++) {
					if (forcefullupdate || forceFullDailyUpdate) {
						Job job = JobList.RetrievedJobs[i];
						if (job.ExemptFromFullSyncs) {
							jobsToRemoveForSomeReason.Add(job);
						}
					}
				}
				if (jobsToRemoveForSomeReason.Count > 0) {
					foreach (Job job in jobsToRemoveForSomeReason) {
						JobList.RetrievedJobs.Remove(job);
						Log.Write.Append("Removed a job " + job.msus_name + "that was exempt from full/daily syncs.");
					}
				}
			}

            Console.Clear();
            WriteToConsole("", true);
            foreach (Job j in JobList.RetrievedJobs) {
				try {
					j.ForceFullUpdate = forcefullupdate;
					j.ForceFullDailyUpdate = forceFullDailyUpdate;
					j.Execute();
					j.IsRunning = false;
					mainFormPublisher.JobDone(j);
					j.AppendLog("Attempting to log the job result to MediSync logs...");
					mainFormPublisher.OnProgress("Attempting to log the job result to MediSync logs...");
					try {
						Job.Reconciler.LogJobResult(j);
					} catch (Exception) {
						Job.Reconciler.LogJobResult(j, true);
						throw;
					}
					mainFormPublisher.OnProgress("MediSync logs were updated.");
				} catch (Exception e) {
					Log.Write.Append("\n************************\n");
					Log.Write.Append("JOB: " + j.msus_name);
					Log.Write.Append(e.Message, e);
					Log.Write.Append("\n************************\n");
				}
            }
            mainFormPublisher = null;
            mainFormSubscriber = null;
			
			return;
        }
		
    public static void WriteToConsole(string text = "", bool resetSpinner = false) {

        int runningJobs = 0;
        ConsoleHelper.Clear();

        if (JobList.RetrievedJobs == null) {
            ConsoleHelper.WriteLine(text);
            ConsoleHelper.Spinner.Start("Working...", ConsoleForeground.Yellow);
            return;
        }
        foreach (Job job in JobList.RetrievedJobs) {
            if (job.IsRunning) { 
                runningJobs += 1;
            }
        }
            
        foreach (Job _job in JobList.RetrievedJobs) {
            if (_job.IsRunning) {
                ConsoleHelper.WriteLine("Running " + _job.msus_name, ConsoleForeground.Green, true);
            } else {
                ConsoleHelper.WriteLine("Finished " + _job.msus_name, ConsoleForeground.LightGray, true);
            }
        }
        if (text.Length > 0) {
            ConsoleHelper.WriteLine(text, ConsoleForeground.Olive, true);
        } else {
            ConsoleHelper.WriteLine();
        }
        ConsoleHelper.Spinner.Start(runningJobs + " of " + JobList.RetrievedJobs.Count + " jobs running.", ConsoleForeground.Olive);

        if (runningJobs == 0) {
            ConsoleHelper.Spinner.Destroy();
        }
    }

		public static void prepareCrmShit() {
			// ConsoleHelper.Spinner.Start();
			CRM.Connect();
			// ConsoleHelper.Spinner.Stop();
			// ConsoleHelper.Clear();

		}

		public static void prepareCrmShit(bool resetPass) {
        ConsoleHelper.Spinner.Start();
        CRM.Connect(resetPass);
        ConsoleHelper.Spinner.Stop();
        ConsoleHelper.Clear();
            
    }
	
    public static void QueryAndShowAvailableJobs(bool availableOnly = true) {
        ConsoleHelper.Clear(true);
        ConsoleHelper.Spinner.Start();
        ConsoleHelper.WriteLine();
        ConsoleHelper.WriteLine("Querying server for available jobs...", ConsoleForeground.Green);
        List<Job> Jobs = MediSync.JobList.QueryServerForJobs(availableOnly);
        ConsoleHelper.Spinner.Stop();
        ConsoleHelper.Spinner.Destroy();
        if (Jobs != null) {
            ConsoleHelper.Clear(true);
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

	public static void undeleteAll() {

	}
	}
}