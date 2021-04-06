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

namespace MediSync {
    public class DbMonitor {

        public static OrganizationServiceProxy _serviceProxy;
        public static IOrganizationService _service;
        public static ServerConnection.Configuration _serverConfig;
        public JobList JobList { get; set; }
        

        public DbMonitor(ServerConnection.Configuration serverConfig) {

        }

        // Assignable properties
        #region Parameters

        /// <summary>
        /// The default database connection string.
        /// </summary>
        public const String DEFAULT_CONNECTION_STRING = "" +
            "Data Source=GU-SXD7E-025\\AX;"+
            "Initial Catalog=MicrosoftDynamicsAX;"+
            "Persist Security Info=True;"+
			"User ID=gu-axprodbc;" +
			"Password=MostCopy52Table";

        /// <summary>
        /// Represents the table name within the CRM database that represents the entity to update and its data.
        /// </summary>
        public String CrmEntityDbTableName { get; set; }
        //TODO: Implement the CRM table name associated with this AX data.

        /// <summary>
        /// The interval with which the select query will be executed
        /// </summary>
        public int interval {
            get { return _interval; }
            set { _interval = value; }
        }
        private int _interval = 60000;

        // The timer used to query the db
        private static Timer timer;

        /// <summary>
        /// The SQL command to execute to facilitate changes to a table.
        /// </summary>
        public SqlCommand sqlCommand {
            get; set;
        }

        /// <summary>
        /// Instantiates a DbMonitor object with a default interval of 10 seconds.
        /// </summary>
        /// <param name="sqlCommand">The select statement to run against the database</param>
        public DbMonitor(SqlCommand sqlCommand) {
            this.sqlCommand = sqlCommand;
        }

        /// <summary>
        /// Instantiates a DbMonitor object.
        /// </summary>
        /// <param name="sqlCommand">The select statement to run against the database.</param>
        /// <param name="interval">The interval with which the select statement will be called.</param>
        public DbMonitor(int interval, SqlCommand sqlCommand) {
            this.interval = interval;
            this.sqlCommand = sqlCommand;
        }
        #endregion

        #region handleUserInput
        private void handleUserInput() {
            System.Console.Clear();
            ConsoleHelper.WriteLine("Starting monitor...",ConsoleForeground.Green);
            ConsoleHelper.WriteLine("Type \"stop\" to stop monitoring for changes.", ConsoleForeground.DarkGray);
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Threading.Thread.Sleep(800);

            String input = System.Console.ReadLine();
            if (input.ToLower().Contains("stop")) {
                input = "stop";
            }
            switch (input) {
                case "stop":
                    kill();
                    ConsoleHelper.WriteLine("Stopping the monitor...", ConsoleForeground.Red);
                    System.Threading.Thread.Sleep(700);
                    ConsoleHelper.WaitForInput(true);
                    break;
                default:
                    handleUserInput();
                    break;
            }
        }
        #endregion

        /// <summary>
        /// Stops the timer if it exists and is enabled.
        /// </summary>
        public void stop() {
            if (timer != null && timer.Enabled) {
                timer.Stop();
            }
        }

        /// <summary>
        /// Stops and kills the timer if it exists and is enabled.
        /// </summary>
        public void cancel() {
            if (timer != null && timer.Enabled) {
                timer.Stop();
                timer.Dispose();
            }
        }

        /// <summary>
        /// Kills the timer if it exists whether it is enabled or not.
        /// </summary>
        public void kill() {
            if (timer != null) {
                if (timer.Enabled == true) {
                    timer.Stop();
                    timer.Enabled = false;
                }
                timer.Dispose();
            }
        }

        /// <summary>
        /// Starts the timer!  Buckle up!
        /// </summary>
        public void start() {
            if (timer != null && timer.Enabled) {
                timer.Stop();
                timer.Dispose();
            }
            timer = new Timer(1000);
            timer.Elapsed += new ElapsedEventHandler(OnTimerTick);
            timer.Enabled = true;
            ConsoleHelper.WriteLine("Starting monitor...", ConsoleForeground.DarkGreen);
            handleUserInput();
        }

        /// <summary>
        /// Raised when the timer has reached its interval and "ticks" then resets
        /// itself until the next interval.
        /// </summary>
        /// <param name="source">The timer object raising this event.</param>
        /// <param name="e">ElapsedEventArgs to play with if you like.</param>
        public void OnTimerTick(object source, ElapsedEventArgs e) {
            timer.Interval = this.interval;
            timer.Enabled = false;
            // ChangedRows changedRows = scanForChanges();
            ChangedRows changedRows = null;
            timer.Enabled = true;
            if (changedRows != null && changedRows.Count() > 0) {
                ConsoleHelper.AppendGood(changedRows.ToString());
                handleUserInput();
            } else {
                ConsoleHelper.AppendWarning("No rows have changed.");
                handleUserInput();
            }
        }

        // Represents a list of all rows that have changed within the time specified.
        public class ChangedRows {
            public String TableName { get; set; }
            public List<Row> Rows { get; set; }

            /// <summary>
            /// The table name that is being queried
            /// </summary>
            /// <param name="tableName"></param>
            public ChangedRows(String tableName) {
                this.Rows = new List<Row>();
            }
            /// <summary>
            /// The individual rows returned by the SQL query
            /// </summary>
            /// <param name="tableName">The name of the table being queried</param>
            /// <param name="changedRows">A structured list of Row objects - each object representative of a row returned by the SQL query.</param>
            public ChangedRows(String tableName, List<Row> changedRows) {
                this.Rows = changedRows;
            }

            /// <summary>
            /// Count of Row objects returned by the SQL query.
            /// </summary>
            /// <returns></returns>
            public int Count() {
                return Rows.Count;
            }

            /// <summary>
            /// Adds a Row object to the list.
            /// </summary>
            /// <param name="row"></param>
            public void Add(Row row) {
                this.Rows.Add(row);
            }

            /// <summary>
            /// Removes the specified Row obect from the list.
            /// </summary>
            /// <param name="row">The specific Row to kill.</param>
            public void Remove(Row row) {
                this.Rows.Remove(row);
            }

            /// <summary>
            /// Kills the Row object at the specified index.
            /// </summary>
            /// <param name="fromPosition"></param>
            public void Remove(int fromPosition) {
                this.Rows.RemoveAt(fromPosition);
            }

            /// <summary>
            /// Returns a verbose (very verbose!) description of each row contained in the list of Row objects.
            /// </summary>
            /// <returns></returns>
            public override string ToString() {
                StringBuilder sb = new StringBuilder();
                sb.Append(TableName);
                sb.AppendLine("Has " + Rows.Count + " changed rows:");
                foreach (Row row in Rows) {
                    sb.AppendLine(row.ToString());
                }
                return sb.ToString();
            }

            /// <summary>
            /// An object representing a singe datarow.
            /// </summary>
            public class Row {
                public List<Column> Columns { get; set; }
                public Row() {
                    this.Columns = new List<Column>();
                }

                /// <summary>
                /// A datarow returned by a SQL query
                /// </summary>
                /// <param name="rowColumns">A list of colunmn names</param>
                public Row(List<Column> rowColumns) {
                    this.Columns = rowColumns;
                }

                /// <summary>
                /// Adds a column to the list of row columnns
                /// </summary>
                /// <param name="column">Column's name</param>
                public void Add(Column column) {
                    this.Columns.Add(column);
                }

                /// <summary>
                /// Removes a column from the list of row columns
                /// </summary>
                /// <param name="column">The Column object to remove.</param>
                public void Remove(Column column) {
                    this.Columns.Remove(column);
                }

                /// <summary>
                /// Removes a Column object at the specified index.
                /// </summary>
                /// <param name="fromPosition">The index with which to find the soon to be dead Column object.</param>
                public void Remove(int fromPosition) {
                    this.Columns.RemoveAt(fromPosition);
                }

                /// <summary>
                /// A verbose description of the columns contained in this datarow.
                /// </summary>
                /// <returns></returns>
                public override string ToString() {
                    StringBuilder sb = new StringBuilder();
                    foreach (Column column in this.Columns) {
                        sb.Append("Column:" + column.columnName + " (" + column.columnValue + ") ");
                    }
                    return sb.ToString();
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public class Column {
                //TODO: Implement the CRM related table column member.
                /// <summary>
                /// This name represents the name of the column in the target 
                /// CRM entity's table within the CRM database.
                /// that this AX data shall be mapped to.  
                /// DON'T SCREW UP THIS COLUMN NAME!
                /// </summary>
                public String relatedToCrmColumnName { get; set; }
                public String columnName { get; set; }
                public Object columnValue { get; set; }

                /// <summary>
                /// Instantiate an empty Column object.
                /// </summary>
                public Column() {

                }

                //public Column(String columnName, Object columnValue) {
                //    this.columnName = columnName;
                //    this.columnValue = columnValue;
                //}

                public Column(String columnName, Object columnValue, String relatedToCrmColumnName) {
                    this.columnName = columnName;
                    this.columnValue = columnValue;
                    this.relatedToCrmColumnName = relatedToCrmColumnName;
                }
            }
        }
    }
}
