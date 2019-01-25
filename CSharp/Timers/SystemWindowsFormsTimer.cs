using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Timers
{
    /// <summary>
    /// A timer based on System.Windows.Forms.Timer. Should be used for Windows Forms applications only.
    /// Calls the TimerFired method every 10 seconds. Starts immediately.
    /// </summary>
    /// <remarks> From MSDN:
    /// The Windows Forms Timer component is single-threaded, and is limited to an accuracy of 55 milliseconds.
    /// If you require a multithreaded timer with greater accuracy, use the Timer class in the System.Timers namespace.</remarks>
    public sealed class SystemWindowsFormsTimer : INotifyPropertyChanged
    {
        private Timer timer;
        private string timerData;

        public SystemWindowsFormsTimer()
        {
            Timer = new Timer();
            Timer.Tick += TimerFired;
            Timer.Interval = 10000;
            Timer.Enabled = true;
            TimerFired(this, null);
        }

        /// <summary>
        /// This method is run on the UI thread.
        /// </summary>
        private void TimerFired(object sender, EventArgs e)
        {
            TimerData = $"The forms timer fired at {DateTime.Now}.";
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

        private void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
