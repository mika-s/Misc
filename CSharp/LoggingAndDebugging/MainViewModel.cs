namespace LoggingAndDebugging
{
    public sealed class MainViewModel : ViewModel
    {
        private TraceTestService traceTesting;

        public MainViewModel()
        {
            traceTesting = new TraceTestService();

            TestTraceCommand = new DelegateCommand<string>(TestTraceExecute);
            TestDebugCommand = new DelegateCommand<string>(TestDebugExecute);
            TestTraceAssertCommand = new DelegateCommand<string>(TestTraceAssertExecute);
            TestEventLogCommand = new DelegateCommand<string>(TestEventLogExecute);
        }

        public DelegateCommand<string> TestTraceCommand { get; private set; }

        public DelegateCommand<string> TestDebugCommand { get; private set; }

        public DelegateCommand<string> TestTraceAssertCommand { get; private set; }

        public DelegateCommand<string> TestEventLogCommand { get; private set; }

        private void TestTraceExecute(string parameter)
        {
            traceTesting.TestTrace();
        }

        private void TestDebugExecute(string parameter)
        {
            traceTesting.TestDebug();
        }

        private void TestTraceAssertExecute(string parameter)
        {
            traceTesting.TestTraceAssert();
        }

        private void TestEventLogExecute(string parameter)
        {
            traceTesting.TestEventLogging();
        }
    }
}
