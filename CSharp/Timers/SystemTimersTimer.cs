using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;

namespace Timers
{
    /// <summary>
    /// A timer based on System.Timers.Timer.
    /// Calls the TimerFired method every 10 seconds. Starts immidiatly.
    /// </summary>
    public sealed class SystemTimersTimer : INotifyPropertyChanged
    {
        private Timer timer;
        private string timerData;

        public SystemTimersTimer()
        {
            Timer = new Timer();
            Timer.Elapsed += TimerFired;
            Timer.Enabled = true;
            Timer.Interval = 10000;
            Timer.Start();

            // This timer does not fire immidiatly, but it can be done by calling the event handler manually.
            TimerFired(this, null);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Timer Timer
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

        public string TimerData
        {
            get
            {
                return timerData;
            }
            set
            {
                if (timerData != value)
                {
                    timerData = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// This method is not run on the UI thread, but is run on a thread-pool thread.
        /// </summary>
        private void TimerFired(object sender, ElapsedEventArgs e)
        {
            TimerData = $"The timers timer fired at {DateTime.Now}.";
        }

        private void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
