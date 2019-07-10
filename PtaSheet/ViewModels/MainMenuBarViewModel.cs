using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using PtaSheet.Infrastructure;
using PtaSheet.Infrastructure.Events;
using PtaSheet.Views;
using System.Windows.Input;

namespace PtaSheet.ViewModels
{
    public class MainMenuBarViewModel : BindableBase
    {

        private ICommand _loadEditorCommand;
        private ICommand _loadPtaSheetCommand;
        private StatusEvent _statusEvent;
        private WindowTitleEvent _titleEvent;


        public ICommand LoadEditorCommand
        {
            get => _loadEditorCommand;
            private set => SetProperty(ref _loadEditorCommand, value);
        }
        public ICommand LoadPtaSheetCommand
        {
            get => _loadPtaSheetCommand;
            private set => SetProperty(ref _loadPtaSheetCommand, value);
        }


        public MainMenuBarViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _statusEvent = eventAggregator.GetEvent<StatusEvent>();
            _titleEvent = eventAggregator.GetEvent<WindowTitleEvent>();
            LoadEditorCommand = new DelegateCommand(() =>
            {
                _statusEvent.Publish("Loading PtaSheet Editor...");
                regionManager.RequestNavigate(Constants.MainWindowRegionName, nameof(Editor));
                _statusEvent.Publish("Editor loaded!");
                _titleEvent.Publish("PtaSheet - Data Editor");
            });

            LoadPtaSheetCommand = new DelegateCommand(() =>
            {
                _statusEvent.Publish("PtaSheet MainWindow not yet finished!");
            });
        }
    }
}
