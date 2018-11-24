using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using PtaSheet.Infrastructure.Events;
using System.Windows.Input;

namespace PtaSheet.ViewModels
{
    public sealed class EditorViewModel : BindableBase
    {

        private readonly StatusEvent _statusEvent;
        private ICommand _capabilitiesCommand;
        private ICommand _abilitiesCommand;



        public ICommand CapabilitiesCommand
        {
            get => _capabilitiesCommand;
            private set => SetProperty(ref _capabilitiesCommand, value);
        }

        public ICommand AbilitiesCommand
        {
            get => _abilitiesCommand;
            private set => SetProperty(ref _abilitiesCommand, value);
        }



        public EditorViewModel() { }
        public EditorViewModel(IEventAggregator eventAggregator, Model.PtaConnection connection)
        {
            _statusEvent = eventAggregator.GetEvent<StatusEvent>();
            CapabilitiesCommand = new DelegateCommand(() =>
            {
                _statusEvent.Publish("From Capabilities");
            });
            AbilitiesCommand = new DelegateCommand(() =>
            {
                _statusEvent.Publish("From abilities");
            });
        }

    }

}