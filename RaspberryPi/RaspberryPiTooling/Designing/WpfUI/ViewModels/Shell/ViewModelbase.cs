using System;
using ARGUSnet.RaspberryPiTooling.WpfUI.Infrastructure.ExceptionHandling;

namespace ARGUSnet.RaspberryPiTooling.WpfUI.ViewModels.Shell
{
    public abstract class ViewModelBase
    {
        private readonly ExceptionHandler _exceptionHandler;
        private Action<Type> _switchViewModelCallback;

        protected ViewModelBase(ExceptionHandler exceptionHandler)
        {
            _exceptionHandler = exceptionHandler;
        }

        #region Properties

        public abstract string DisplayName { get; }

        #endregion

        #region Public/Internal Methods

        internal void SetExceptionCallback(Action<Exception> callback)
        {
            _exceptionHandler.SetExceptionCallback(callback);
        }

        internal void SetSwitchViewModelCallback(Action<Type> callback)
        {
            _switchViewModelCallback = callback;
        }

        #endregion

        #region Protected Methods

        protected void HandledAction(Action action)
        {
            _exceptionHandler.HandledAction(action);
        }

        protected void SwitchToViewModel<T>()
            where T : ViewModelBase
        {
            _switchViewModelCallback(typeof(T));
        }

        #endregion
    }
}