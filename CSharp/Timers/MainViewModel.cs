namespace Timers
{
    public sealed class MainViewModel : ViewModel
    {
        private SystemThreadingTimer timer;

        public MainViewModel(SystemThreadingTimer timerDependency)
        {
            timer = timerDependency;
        }

        public SystemThreadingTimer Timer
        {
            get
            {
                return timer;
            }
            set
            {
                if (timer != value)
                {
                    timer = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
