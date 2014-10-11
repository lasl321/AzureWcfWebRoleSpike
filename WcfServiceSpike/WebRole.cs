using System.Diagnostics;
using AzureHelpers;

namespace WcfServiceSpike
{
    public class WebRole : WcfWebRole
    {
        public override bool OnStart()
        {
            Trace.TraceInformation("from WebRole class");
            return base.OnStart();
        }
    }
}