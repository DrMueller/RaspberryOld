using System;
using System.Windows.Input;

namespace ARGUSnet.RaspberryPiTooling.WpfUI.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _action;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action<object> action)
            : this(action, null)
        {
        }

        public RelayCommand(Action<object> action, Func<bool> canExecute)
        {
            _canExecute = canExecute;
            _action = action;
        }

        #region ICommand

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }

        #endregion
    }
}