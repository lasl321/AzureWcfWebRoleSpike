using System;
using Microsoft.Web.Administration;

namespace FD.ThirdParty.Microsoft.Web.Administration
{
    public static class ServerManagerExtensions
    {
        public static void Execute(this ServerManager serverManager, params Action<ServerManager>[] actions)
        {
            foreach (var action in actions)
            {
                action(serverManager);
            }
        }
    }
}