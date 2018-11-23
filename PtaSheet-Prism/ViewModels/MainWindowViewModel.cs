using Prism.Mvvm;
using System.Linq;

namespace PtaSheet_Prism.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {
            var provider = new PtaSheet_Provider.mainEntities();
            var poke = provider.Pokemons.Local.FirstOrDefault();
            System.Diagnostics.Debugger.Break();
            //var x = (from pokemon in  select pokemon);
            //provider.Pokemons.F
        }
    }
}
