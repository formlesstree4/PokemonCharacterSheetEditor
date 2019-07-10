using Prism.Mvvm;
using Prism.Regions;
using PtaSheet.Infrastructure;

namespace PtaSheet.ViewModels
{
    public sealed class EditorViewModel : BindableBase
    {
        public EditorViewModel() { }
        public EditorViewModel(IRegionManager regionManager)
        {
            regionManager.RegisterViewWithRegion(Constants.EditorCapabilityRegionName, typeof(Views.CapabilityEditor));
            regionManager.RegisterViewWithRegion(Constants.EditorAbilityRegionName, typeof(Views.AbilityEditor));
            regionManager.RegisterViewWithRegion(Constants.EditorMoveRegionName, typeof(Views.MoveEditor));

            regionManager.RequestNavigate(Constants.MenuBarRegionName, nameof(Views.EditorMenuBar));
        }
    }
}