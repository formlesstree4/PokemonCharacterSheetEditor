using System.Collections.ObjectModel;
using System.Windows;

namespace PokemonCharacterSheetEditor.DbEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        



        public MainWindow()
        {
            T = new ObservableCollection<Test>();
            //DataContext = this;
            InitializeComponent();
            T.Add(new Test { Name = "Bulbasaur" });
            T.Add(new Test { Name = "Ivysaur" });
            T.Add(new Test { Name = "Venasaur" });

        }
    }


    public sealed class Test
    {
        public string Name { get; set; }
    }

}