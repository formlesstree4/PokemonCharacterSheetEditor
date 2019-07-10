using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using PtaSheet.Infrastructure;
using PtaSheet.Infrastructure.Events;
using PtaSheet.Views;

namespace PtaSheet.ViewModels
{
    public sealed class MainWindowViewModel : BindableBase
    {

        private string _windowTitle = "";



        public string WindowTitle
        {
            get => _windowTitle;
            private set => SetProperty(ref _windowTitle, value);
        }




        public MainWindowViewModel() { WindowTitle = "PtaSheet"; }
        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : this()
        {
            _statusEvent = eventAggregator.GetEvent<StatusEvent>();
            regionManager.RegisterViewWithRegion(Constants.StatusRegionName, typeof(StatusBar));

            LoadEditorCommand = new DelegateCommand(() =>
            {
                _statusEvent.Publish("Loading PtaSheet Editor...");
                regionManager.RequestNavigate(Constants.MainWindowRegionName, nameof(Editor));
                _statusEvent.Publish("Editor loaded!");
                WindowTitle = "PtaSheet - Data Editor";
            });

            LoadPtaSheetCommand = new DelegateCommand(() =>
            eventAggregator.GetEvent<WindowTitleEvent>().Subscribe((title) =>
            {
                WindowTitle = title;
            });
            regionManager.RegisterViewWithRegion(Constants.MenuBarRegionName, typeof(MainMenuBar));
            regionManager.RegisterViewWithRegion(Constants.StatusRegionName, typeof(StatusBar));
        }

    }

}