using System.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace AzureHelpers
{
    public abstract class WcfWebRole : RoleEntryPoint
    {
        public override bool OnStart()
        {
            Trace.TraceInformation("Run() *********");

            Trace.TraceInformation("{0} - {1} -----------------",
                                   RoleEnvironment.CurrentRoleInstance.Id,
                                   RoleEnvironment.IsAvailable);
            return base.OnStart();
        }
    }
}