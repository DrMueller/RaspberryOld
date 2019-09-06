using System;
using System.Collections.Generic;
using ARGUSnet.RaspberryPiTooling.WpfUI.Commands;
using ARGUSnet.RaspberryPiTooling.WpfUI.Infrastructure.ExceptionHandling;
using PropertyChanged;

namespace ARGUSnet.RaspberryPiTooling.WpfUI.ViewModels.Shell
{
    [ImplementPropertyChanged]
    internal class ViewModelContainer
    {
        private readonly ExceptionHandler _exceptionHandler;
        private readonly ViewModelFactory _viewModelFactory;

        public ViewModelContainer(ExceptionHandler exceptionHandler, ViewModelFactory viewModelFactory)
        {
            _exceptionHandler = exceptionHandler;
            _viewModelFactory = viewModelFactory;
            InformationText = "Here could be your Text..";
            ApplyViewModel<LedDesignViewModel>();
        }

        #region Properties

        public ViewModelBase CurrentContent { get; private set; }

        public string InformationText { get; private set; }

        public IEnumerable<ViewModelCommand> NavigationCommands
        {
            get
            {
                return new List<ViewModelCommand>
                {
                    new ViewModelCommand("LED",
                        new ActionCommand(() =>
                        {
                            ApplyViewModel<LedDesignViewModel>();
                        }))
                };
            }
        }

        #endregion

        #region Private Methods

        private void ApplyViewModel(Type targetType)
        {
            _exceptionHandler.HandledAction(
                () =>
                {
                    var vm = _viewModelFactory.CreateViewModel(targetType);
                    vm.SetExceptionCallback(ShowExceptionMessage);
                    vm.SetSwitchViewModelCallback(ApplyViewModel);
                    CurrentContent = vm;
                });
        }

        private void ApplyViewModel<T>()
            where T : ViewModelBase
        {
            ApplyViewModel(typeof(T));
        }

        private void ShowExceptionMessage(Exception ex)
        {
            var text = ex.Message;
            InformationText = text;
        }

        #endregion
    }
}