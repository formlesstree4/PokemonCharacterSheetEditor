using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PokemonCharacterSheetEditor.DbEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<Test> T { get; set; }



        public MainWindow()
        {
            T = new ObservableCollection<Test>();
            //DataContext = this;
            InitializeComponent();
            T.Add(new Test { Name = "Bulbasaur" });
        }
    }


    public sealed class Test
    {
        public string Name { get; set; }
    }

}