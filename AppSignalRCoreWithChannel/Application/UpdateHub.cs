using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AppSignalRCoreWithChannel.Application
{
    public class UpdateHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            string name = Context.User.Identity.Name;
            Groups.AddToGroupAsync(Context.ConnectionId, name);
            base.OnConnectedAsync();
            return Task.CompletedTask;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            string name = Context.User.Identity.Name;
            base.OnDisconnectedAsync(exception);
            return Task.CompletedTask;
        }
    }
}
