using System.Web.UI;
using Microsoft.AspNet.SignalR;
using NLog.SignalR;

namespace SignalRChat.Hubs
{
    public class LoggingHub : Hub<ILoggingHub>
    {
        public void Log(LogEvent logEvent)
        {
            Clients.Others.Log(logEvent);
        }
    }

    //public class LoggingHub : Hub
    //{
    //    public void Send(dynamic logEvent)
    //    {
    //        Clients.Others.Log(logEvent);
    //    }
    //}

}