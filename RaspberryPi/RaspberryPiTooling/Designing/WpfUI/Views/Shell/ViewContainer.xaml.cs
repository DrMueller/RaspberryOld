using System.Windows;
using System.Windows.Input;
using ARGUSnet.RaspberryPiTooling.WpfUI.Commands;
using ARGUSnet.RaspberryPiTooling.WpfUI.Infrastructure.Singletons;
using ARGUSnet.RaspberryPiTooling.WpfUI.ViewModels.Shell;
using Microsoft.Practices.Unity;

namespace ARGUSnet.RaspberryPiTooling.WpfUI.Views.Shell
{
    /// <summary>
    /// Interaction logic for ViewContainer.xaml
    /// </summary>
    public partial class ViewContainer : Window
    {
        public ViewContainer()
        {
            DataContext = UnityContainerInstance.Instance.Resolve<ViewModelContainer>();
            InitializeComponent();
        }

        #region Properties

        public ICommand CloseCommand => new ActionCommand(Close);

        #endregion
    }
}