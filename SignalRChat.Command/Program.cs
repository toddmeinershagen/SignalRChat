using System;
using Microsoft.AspNet.SignalR.Client.Hubs;
using NLog;

namespace SignalRChat.Command
{
    class Program
    {
        static void Main(string[] args)
        {
            //var hubConnection = new HubConnection("http://localhost:1602");
            //var chat = hubConnection.CreateHubProxy("ChatHub");
            //chat.On<string, string>("broadcastMessage", DisplayMessage);
            //hubConnection.Start().Wait();
            //chat.Invoke("Notify", "Console app", hubConnection.ConnectionId);
            string msg = null;

            while ((msg = Console.ReadLine()) != null)
            {
                //chat.Invoke("Send", "Console app", msg).Wait();
                LogManager.GetCurrentClassLogger().Trace(msg, new Exception("This is the exception message."));
            }
        }
    }
}
