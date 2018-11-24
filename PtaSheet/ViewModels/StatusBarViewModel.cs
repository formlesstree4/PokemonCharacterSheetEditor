using Prism.Events;
using Prism.Mvvm;
using PtaSheet.Infrastructure.Events;
using System.Timers;

namespace PtaSheet.ViewModels
{

    /// <summary>
    ///     Creates a new instance of the <see cref="StatusBarViewModel"/>
    /// </summary>
    public sealed class StatusBarViewModel : BindableBase
    {
        private static System.TimeSpan DefaultTimeout = System.TimeSpan.FromSeconds(5);
        private Timer _timer;
        private string _statusMessage = "";


        /// <summary>
        ///     Gets the current message to display in the status bar.
        /// </summary>
        public string StatusMessage
        {
            get => _statusMessage;
            private set => SetProperty(ref _statusMessage, value);
        }



        public StatusBarViewModel()
        {
            StatusMessage = "Hello Designer";
        }

        /// <summary>
        ///     Creates a new instance of the <see cref="StatusBarViewModel"/>
        /// </summary>
        /// <param name="eventAggregator"></param>
        public StatusBarViewModel(IEventAggregator eventAggregator)
        {
            _timer = new Timer(DefaultTimeout.TotalMilliseconds)
            {
                AutoReset = false,
                Enabled = false
            };
            _timer.Elapsed += StatusBarTimerTick;
            eventAggregator.GetEvent<StatusEvent>().Subscribe(newMessage =>
            {
                _timer.Stop();
                StatusMessage = newMessage;
                _timer.Start();
            });
        }

        private void StatusBarTimerTick(object sender, ElapsedEventArgs e)
        {
            StatusMessage = string.Empty;
        }
    }

}