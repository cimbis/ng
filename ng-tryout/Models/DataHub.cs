using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Ngtryout.Models
{

    public class DataHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "DataUsers");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "DataUsers");
            await base.OnDisconnectedAsync(exception);
        }

        public async Task Send(string message)
        {
            await Clients.All.SendAsync("Send", message);
        }
    }
}
