using System;
using System.Windows.Input;

namespace ARGUSnet.RaspberryPiTooling.WpfUI.Commands
{
    internal class ActionCommand : ICommand
    {
        private readonly Action _action;
        private readonly Func<bool> _canExecute;

        public ActionCommand(Action action)
            : this(action, null)
        {
        }

        public ActionCommand(Action action, Func<bool> canExecute)
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
            _action();
        }

        #endregion
    }
}