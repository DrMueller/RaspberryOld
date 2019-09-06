using System.Windows;
using ARGUSnet.RaspberryPiTooling.WpfUI.Infrastructure.Singletons;
using ARGUSnet.RaspberryPiTooling.WpfUI.Views.Shell;
using Microsoft.Practices.Unity;

namespace ARGUSnet.RaspberryPiTooling.WpfUI.App_Start
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Protected Methods

        protected override void OnStartup(StartupEventArgs e)
        {
            Bootstrapper.Initialize();
            var viewContainer = UnityContainerInstance.Instance.Resolve<ViewContainer>();
            viewContainer.ShowDialog();
        }

        #endregion
    }
}