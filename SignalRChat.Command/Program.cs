using System;
using Microsoft.AspNet.SignalR.Client;

namespace SignalRChat.Command
{
    class Program
    {
        static void Main(string[] args)
        {
            var hubConnection = new HubConnection("http://localhost:1602");
            var chat = hubConnection.CreateHubProxy("ChatHub");
            chat.On<string, string>("broadcastMessage", DisplayMessage);
            hubConnection.Start().Wait();
            chat.Invoke("Notify", "Console app", hubConnection.ConnectionId);
            string msg = null;

            while ((msg = Console.ReadLine()) != null)
            {
                chat.Invoke("Send", "Console app", msg).Wait();
            }
        }

        static void DisplayMessage(string name, string message)
        {
            Console.Write(name + ": "); Console.WriteLine(message);
        }
    }
}
