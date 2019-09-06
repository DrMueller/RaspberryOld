using System.Windows.Input;

namespace ARGUSnet.RaspberryPiTooling.WpfUI.ViewModels.Shell
{
    public class ViewModelCommand
    {
        public ViewModelCommand(string displayName, ICommand command)
        {
            DisplayName = displayName;
            Command = command;
        }

        #region Properties

        public ICommand Command { get; private set; }

        public string DisplayName { get; private set; }

        #endregion
    }
}