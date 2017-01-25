namespace Timers
{
    public sealed class MainViewModel : ViewModel
    {
        private SystemThreadingTimer systemThreadingTimer;
        private SystemTimersTimer systemTimersTimer;

        public MainViewModel(SystemThreadingTimer systemThreadingtimerDependency, SystemTimersTimer systemTimersTimerDependency)
        {
            SystemThreadingTimer = systemThreadingtimerDependency;
            SystemTimersTimer = systemTimersTimerDependency;
        }

        public SystemThreadingTimer SystemThreadingTimer
        {
            get
            {
                return systemThreadingTimer;
            }
            set
            {
                if (systemThreadingTimer != value)
                {
                    systemThreadingTimer = value;
                    NotifyPropertyChanged();
                }
            }
        }
        
        public SystemTimersTimer SystemTimersTimer
        {
            get
            {
                return systemTimersTimer;
            }
            set
            {
                if (systemTimersTimer != value)
                {
                    systemTimersTimer = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
