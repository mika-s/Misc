namespace Timers
{
    public sealed class MainViewModel : ViewModel
    {
        private SystemThreadingTimer systemThreadingTimer;
        private SystemTimersTimer systemTimersTimer;
        private SystemWindowsFormsTimer systemWindowsFormsTimer;

        public MainViewModel(SystemThreadingTimer systemThreadingtimerDependency, SystemTimersTimer systemTimersTimerDependency, 
            SystemWindowsFormsTimer systemWindowsFormsTimerDependency)
        {
            SystemThreadingTimer = systemThreadingtimerDependency;
            SystemTimersTimer = systemTimersTimerDependency;
            SystemWindowsFormsTimer = systemWindowsFormsTimerDependency;
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

        public SystemWindowsFormsTimer SystemWindowsFormsTimer
        {
            get
            {
                return systemWindowsFormsTimer;
            }
            set
            {
                if (systemWindowsFormsTimer != value)
                {
                    systemWindowsFormsTimer = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
