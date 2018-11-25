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
            eventAggregator.GetEvent<WindowTitleEvent>().Subscribe((title) =>
            {
                WindowTitle = title;
            });
            regionManager.RegisterViewWithRegion(Constants.MenuBarRegionName, typeof(MainMenuBar));
            regionManager.RegisterViewWithRegion(Constants.StatusRegionName, typeof(StatusBar));
        }

    }

}