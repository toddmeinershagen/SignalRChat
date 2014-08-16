using System;
using System.Threading;
using FluentAssertions;
using NLog.Common;
using NUnit.Framework;

namespace NLog.SignalR.UnitTests
{
    [TestFixture]
    public class SignalRTargetTests
    {
        [Test]
        public void given_proxy_creation_fails_when_writing_should_not_throw()
        {
            var target = new SignalRTarget();

            Action action = () =>
            {
                AsyncContinuation continuation = ex => { };
                target.WriteAsyncLogEvent(new AsyncLogEventInfo(new LogEventInfo(LogLevel.Trace, "Logger", "This is the message"), continuation));
                target.Flush(continuation);
                Thread.Sleep(1000);
            };

            action.ShouldNotThrow();
        }
    }
}
