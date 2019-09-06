using System;
using ARGUSnet.RaspberryPiTooling.WpfUI.Infrastructure.Singletons;
using Microsoft.Practices.Unity;

namespace ARGUSnet.RaspberryPiTooling.WpfUI.ViewModels.Shell
{
    public class ViewModelFactory
    {
        #region Public/Internal Methods

        internal ViewModelBase CreateViewModel(Type targetType)
        {
            if (!typeof(ViewModelBase).IsAssignableFrom(targetType))
            {
                throw new ArgumentException($"Type {targetType.Name} can't be assigned from ViewModelBase.");
            }

            var result = (ViewModelBase)UnityContainerInstance.Instance.Resolve(targetType);
            return result;
        }

        #endregion
    }
}