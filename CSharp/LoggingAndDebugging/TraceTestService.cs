using System;
using System.Diagnostics;

namespace LoggingAndDebugging
{
    public sealed class TraceTestService
    {
        private EventLog eventLog;

        public TraceTestService()
        {
            eventLog = new EventLog("Application");
            eventLog.Source = "Application";
        }

        public void TestTrace()
        {
            // Trace will also be used in the release build.
            Trace.WriteLine($"{DateTime.Now}: This is a test of trace.");
        }

        public void TestDebug()
        {
            // Debug isn't run in the release build.
            Debug.WriteLine($"{DateTime.Now}: This is a test of trace.");
        }

        public void TestTraceAssert()
        {
            Trace.Assert(false, "This is a trace assert message.", "This is a detailed message.");
        }

        public void TestEventLogging()
        {
            eventLog.WriteEntry("Testing writing to the Windows event log.", EventLogEntryType.Information, 258, 1);
        }
    }
}
