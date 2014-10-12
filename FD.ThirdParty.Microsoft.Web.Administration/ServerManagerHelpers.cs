using System;
using System.Linq;
using Microsoft.Web.Administration;

namespace FD.ThirdParty.Microsoft.Web.Administration
{
    public static class ServerManagerHelpers
    {
        private const string ProtocolNameTcp = "net.tcp";
        private const string ProtocolNameHttp = "http";

        public static Action<ServerManager> AddTcpProtocol(string siteName)
        {
            return serverManager =>
            {
                foreach (var application in serverManager.Sites[siteName].Applications)
                {
                    application.EnabledProtocols = string.Format(
                        "{0},{1}",
                        ProtocolNameHttp,
                        ProtocolNameTcp);
                }
            };
        }

        public static Action<ServerManager> AddTcpBinding(string siteName, int port)
        {
            return serverManager =>
            {
                var site = serverManager.Sites[siteName];
                var bindings = site.Bindings;
                if (bindings.Any(x => x.Protocol == ProtocolNameTcp))
                {
                    return;
                }

                var element = bindings.CreateElement();
                element.BindingInformation = string.Format("{0}:*", port);
                element.Protocol = ProtocolNameTcp;
                site.Bindings.Add(element);
            };
        }
    }
}