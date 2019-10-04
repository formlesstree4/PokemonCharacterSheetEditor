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
            regionManager.RegisterViewWithRegion(Constants.EditorCapabilityRegionName, typeof(Views.Editors.CapabilityEditor));
            regionManager.RegisterViewWithRegion(Constants.EditorAbilityRegionName, typeof(Views.Editors.AbilityEditor));
            regionManager.RegisterViewWithRegion(Constants.EditorMoveRegionName, typeof(Views.Editors.MoveEditor));
            regionManager.RegisterViewWithRegion(Constants.EditorPokemonRegionName, typeof(Views.Editors.PokemonEditor));

            regionManager.RequestNavigate(Constants.MenuBarRegionName, nameof(Views.EditorMenuBar));
        }
    }
}