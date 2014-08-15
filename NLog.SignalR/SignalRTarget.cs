using System;
using Microsoft.AspNet.SignalR.Client;
using NLog.Common;
using NLog.Config;
using NLog.Targets;

namespace NLog.SignalR
{
    [Target("SignalR")]
    public class SignalRTarget : TargetWithLayout
    {
        [RequiredParameter]
        public string Uri { get; set; }

        [RequiredParameter]
        public string HubName { get; set; }

        [RequiredParameter]
        public string MethodName { get; set; }

        public IHubProxyFactory ProxyFactory { get; set; }

        private IHubProxy _proxy;

        public SignalRTarget()
        {
            ProxyFactory = new HubProxyFactory();
        }

        protected override void InitializeTarget()
        {
            _proxy = ProxyFactory.Create(Uri, HubName);
            base.InitializeTarget();
        }

        protected override void Write(AsyncLogEventInfo logEvent)
        {
            base.Write(logEvent);
            var renderedMessage = Layout.Render(logEvent.LogEvent);
            var item = new LogItem(logEvent.LogEvent, renderedMessage);
            _proxy.Invoke(MethodName, item);
        }

        public class LogItem
        {
            public string Level { get; private set; }
            public DateTime TimeStamp { get; private set; }
            public string Message { get; private set; }

            public LogItem(LogEventInfo eventInfo, string renderedMessage)
            {
                Level = eventInfo.Level.Name;
                TimeStamp = eventInfo.TimeStamp.ToUniversalTime();
                Message = renderedMessage;
            }
        }
    }
}