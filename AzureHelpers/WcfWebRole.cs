using FD.ThirdParty.Microsoft.Web.Administration;
using Microsoft.Web.Administration;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace AzureHelpers
{
    public abstract class WcfWebRole : RoleEntryPoint
    {
        protected virtual string SiteName
        {
            get { return string.Format("{0}_Web", RoleEnvironment.CurrentRoleInstance.Id); }
        }

        protected virtual string EndpointName
        {
            get { return "TCP Endpoint"; }
        }

        public override bool OnStart()
        {
            if (RoleEnvironment.IsAvailable && !RoleEnvironment.IsEmulated)
            {
                using (var serverManager = new ServerManager())
                {
                    var siteName = SiteName;

                    var port = RoleEnvironment
                        .CurrentRoleInstance
                        .InstanceEndpoints[EndpointName]
                        .IPEndpoint
                        .Port;

                    serverManager.Execute(
                        ServerManagerHelpers.AddTcpProtocol(siteName),
                        ServerManagerHelpers.AddTcpBinding(siteName, port));

                    serverManager.CommitChanges();
                }
            }

            return base.OnStart();
        }
    }
}