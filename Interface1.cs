using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MediSync.JobList.Job.Reconciler;

namespace MediSync.Interfaces {

    public interface ISimpleTask {
        void Finished(object result);
    }

    public interface ITask {
        void Finished(object result);
        void Cancelled(object result);
        void OnProgress(object progress);
    }


}

namespace MediSync.Log {
    public static class Write {

		public static void Clear() {
			string path = Path.Combine(Path.Combine(Environment.CurrentDirectory), "ErrorLog.log");
			
			try {
				if (!File.Exists(path)) {
					File.Create(path);
					TextWriter tw = new StreamWriter(path);
					tw.Write("");
					tw.Close();
				} else if (File.Exists(path)) {
					TextWriter tw = new StreamWriter(path, true);
					tw.WriteLine("");
					tw.Close();
				}
			} catch (Exception) {

				throw;
			}
		}
        
        public static void Append(string text, Exception e = null) {
			
            string path = Path.Combine(Path.Combine(Environment.CurrentDirectory),"ErrorLog.log");
            string line = DateTime.Now + ": " + text;
			if (e != null) {
				line = line + "\nStackTrace:\n" + e.StackTrace;
			}
            try {
                if (!File.Exists(path)) {
                    File.Create(path);
                    TextWriter tw = new StreamWriter(path);
                    tw.WriteLine(line);
                    tw.Close();
                } else if (File.Exists(path)) {
                    TextWriter tw = new StreamWriter(path, true);
                    tw.WriteLine(line);
                    tw.Close();
                }
            } catch (Exception) {

                throw;
            }
        }
    }
}
