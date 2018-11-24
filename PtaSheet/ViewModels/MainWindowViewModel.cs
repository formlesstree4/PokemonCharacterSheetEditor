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
    public sealed class MainWindowViewModel : BindableBase
    {

        private string _windowTitle = "";
        private ICommand _loadEditorCommand;
        private ICommand _loadPtaSheetCommand;
        private StatusEvent _statusEvent;



        public string WindowTitle
        {
            get => _windowTitle;
            private set => SetProperty(ref _windowTitle, value);
        }
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



        public MainWindowViewModel() { }
        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : this()
        {
            WindowTitle = "PtaSheet";
            _statusEvent = eventAggregator.GetEvent<StatusEvent>();
            regionManager.RegisterViewWithRegion(Constants.StatusRegionName, typeof(StatusBar));

            LoadEditorCommand = new DelegateCommand(() =>
            {
                var region = regionManager.Regions[Constants.MainWindowRegionName];
                _statusEvent.Publish("Loading PtaSheet Editor...");
                regionManager.RequestNavigate(Constants.MainWindowRegionName, nameof(Editor));
                WindowTitle = "PtaSheet Editor";
            });

            LoadPtaSheetCommand = new DelegateCommand(() =>
            {
                _statusEvent.Publish("PtaSheet MainWindow not yet finished!");
            });

        }

    }

}