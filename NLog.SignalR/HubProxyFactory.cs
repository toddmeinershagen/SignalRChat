using Microsoft.AspNet.SignalR.Client;

namespace NLog.SignalR
{
    public class HubProxyFactory : IHubProxyFactory
    {
        public IHubProxy Create(string uri, string hubName)
        {
            var hubConnection = new HubConnection(uri);
            var proxy = hubConnection.CreateHubProxy(hubName);
            hubConnection.Start().Wait();

            proxy.Invoke("Notify", hubConnection.ConnectionId);

            return proxy;
        }
    }
}