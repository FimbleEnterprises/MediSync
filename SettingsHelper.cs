using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediSync {
    class SettingsHelper {

        private const String DEFAULT_CRM_CONN_STRING = "";

        Properties.Settings config;
        public SettingsHelper() {
            config = new Properties.Settings();
            
        }
        
        public static void setCrmConnectionString(String connString) {
            
        }

    }
}
