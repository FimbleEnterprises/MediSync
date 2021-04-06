using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Discovery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MediSync {

	public class CRM {
		#region
		public static ServerConnection.Configuration config;
		private static OrganizationServiceProxy _serviceProxy;
		public static OrganizationServiceProxy serviceProxy {
			get {
				if (config == null) {
					Connect();
				}

				if (_serviceProxy == null) {
					_serviceProxy = getProxy();
				}
				return _serviceProxy;
			}
			private set {
				if (config == null) {
					Connect();
				}
				_serviceProxy = value;
			}
		}
		public static IOrganizationService _service;
		public static IOrganizationService service {
			get {
				if (config == null) {
					Connect();
				}

				if (_service == null) {
					_service = GetService();
				}
				return _service;
			}
			private set {
				if (config == null) {
					Connect();
				}
				_service = value;
			}
		}
		#endregion

		
		#region Public Methods
		public static ServerConnection.Configuration Connect(bool forceReconnect = false) {

			try {
				// Obtain the target organization's Web address and client logon 
				// credentials from the user.
				ServerConnection serverConnect = new ServerConnection();
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

				if (CRM.config == null || forceReconnect == true)
					CRM.config = serverConnect.GetServerConfiguration(forceReconnect);

			} catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault> ex) {
				Console.WriteLine("The application terminated with an error.");
				Console.WriteLine("Timestamp: {0}", ex.Detail.Timestamp);
				Console.WriteLine("Code: {0}", ex.Detail.ErrorCode);
				Console.WriteLine("Message: {0}", ex.Detail.Message);
				Console.WriteLine("Plugin Trace: {0}", ex.Detail.TraceText);
				Console.WriteLine("Inner Fault: {0}",
					null == ex.Detail.InnerFault ? "No Inner Fault" : "Has Inner Fault");
			} catch (System.TimeoutException ex) {
				Console.WriteLine("The application terminated with an error.");
				Console.WriteLine("Message: {0}", ex.Message);
				Console.WriteLine("Stack Trace: {0}", ex.StackTrace);
				Console.WriteLine("Inner Fault: {0}",
					null == ex.InnerException.Message ? "No Inner Fault" : ex.InnerException.Message);
			} catch (System.Exception ex) {
				Console.WriteLine("The application terminated with an error.");
				Console.WriteLine(ex.Message);

				// Display the details of the inner exception.
				if (ex.InnerException != null) {
					Console.WriteLine(ex.InnerException.Message);

					FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault> fe = ex.InnerException
						as FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>;
					if (fe != null) {
						Console.WriteLine("Timestamp: {0}", fe.Detail.Timestamp);
						Console.WriteLine("Code: {0}", fe.Detail.ErrorCode);
						Console.WriteLine("Message: {0}", fe.Detail.Message);
						Console.WriteLine("Plugin Trace: {0}", fe.Detail.TraceText);
						Console.WriteLine("Inner Fault: {0}",
							null == fe.Detail.InnerFault ? "No Inner Fault" : "Has Inner Fault");
					}
				}
			} finally {
				Console.WriteLine("Press <Enter> to exit.");
			}
			return CRM.config;
		}
		#endregion

		#region
		/// <summary>
		/// This method first connects to the Organization service. Afterwards,
		/// create, retrieve, update, and delete operations are performed on the 
		/// SharePoint location records.
		/// </summary>
		/// <param name="serverConfig">Contains server connection information.</param>
		/// <param name="promptforDelete">When True, the user will be prompted to delete all
		/// created entities.</param>
		public static OrganizationServiceProxy getProxy() {
			try {
				if (config == null)
					config = Connect();

				// Connect to the Organization service. 
				// The using statement assures that the service proxy will be properly disposed.

				System.ServiceModel.Description.ClientCredentials creds = new System.ServiceModel.Description.ClientCredentials();

				config.Credentials.UserName.UserName = "gu-3PColumbus@medistim.com";
				config.Credentials.Windows.ClientCredential.Password = "LeaveUpwardSpite12";
				config.Credentials.UserName.Password = "LeaveUpwardSpite12";
				// config.DeviceCredentials.UserName.UserName = "gu-3PColumbus@medistim.com";
				// config.DeviceCredentials.UserName.Password = "LeaveUpwardSpite12";

				using (OrganizationServiceProxy proxy = new OrganizationServiceProxy
                    (config.OrganizationUri, config.HomeRealmUri, config.Credentials, config.DeviceCredentials)) {
					// This statement is required to enable early-bound type support.
					proxy.EnableProxyTypes();
					return proxy;
				}
			} // Catch any service fault exceptions that Microsoft Dynamics CRM throws.
			catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>) {
				// You can handle an exception here or pass it back to the calling method.
				throw;
			}

		}

		public static IOrganizationService GetService() {
			if (config == null)
				config = Connect();
			try {
                return (IOrganizationService) getProxy();
			}
			// Catch any service fault exceptions that Microsoft Dynamics CRM throws.
			catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>) {
				// You can handle an exception here or pass it back to the calling method.
				throw;
			}
		}
		#endregion
	}
}
