using Prism.Ioc;
using PtaSheet.Views;
using System.Windows;

namespace PtaSheet
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<Model.PtaConnection>();
            containerRegistry.RegisterForNavigation<Editor>();
            containerRegistry.RegisterForNavigation<MainMenuBar>();
            containerRegistry.RegisterForNavigation<EditorMenuBar>();
        }
    }
}
