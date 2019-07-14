using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using PtaSheet.Infrastructure;
using PtaSheet.Infrastructure.Events;
using System.Windows.Input;

namespace PtaSheet.ViewModels
{
    public sealed class EditorMenuBarViewModel : BindableBase
    {

        private Model.PtaConnection _connection;
        private readonly StatusEvent _statusEvent;
        private ICommand _saveCommand;
        private ICommand _returnCommand;

        public ICommand SaveCommand
        {
            get => _saveCommand;
            private set => SetProperty(ref _saveCommand, value);
        }
        public ICommand ReturnCommand
        {
            get => _returnCommand;
            private set => SetProperty(ref _returnCommand, value);
        }



        public EditorMenuBarViewModel() { }
        public EditorMenuBarViewModel(IRegionNavigationService navServ, IRegionManager regionManager, IEventAggregator eventAggregator, Model.PtaConnection connection)
        {
            _statusEvent = eventAggregator.GetEvent<StatusEvent>();
            _connection = connection;
            SaveCommand = new DelegateCommand(SaveAllChanges);
            ReturnCommand = new DelegateCommand(() =>
            {
                SaveAllChanges();
                navServ.Journal.GoBack();
            });
        }


        private void SaveAllChanges()
        {
            _statusEvent.Publish("Saving Changes...");
            var changes = _connection.SaveChanges();
            _statusEvent.Publish($"Applied {changes:N0} change(s) to the database");
        }

    }

}