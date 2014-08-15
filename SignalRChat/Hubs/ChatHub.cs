using Microsoft.AspNet.SignalR;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(dynamic logEvent)
        {
            Clients.All.broadcastMessage(logEvent);
        }
    }
}