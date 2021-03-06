﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Timers
{
    /// <summary>
    /// A timer based on System.Threading.Timer.
    /// Calls the TimerFired method every 10 seconds. Waits 0 seconds before it starts.
    /// </summary>
    public sealed class SystemThreadingTimer : INotifyPropertyChanged
    {
        private Timer timer;
        private string timerData;

        public SystemThreadingTimer()
        {
            Timer = new Timer(TimerFired, null, 0, 10000);
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
        /// This callback does not occur on the UI thread. This is run on a thread-pool thread.
        /// </summary>
        private void TimerFired(object state)
        {
            TimerData = $"The threading timer fired at {DateTime.Now}.";
        }

        private void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
