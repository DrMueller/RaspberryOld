using System;
using Microsoft.Practices.Unity;

namespace ARGUSnet.LyncConnector.WindowsService.Infrastructure
{
    internal static class UnityContainerSingleton
    {
        private static readonly Lazy<UnityContainer> _lazyUnityContainer = new Lazy<UnityContainer>(Create);

        #region Properties

        internal static UnityContainer Instance => _lazyUnityContainer.Value;

        #endregion

        #region Private Methods

        private static UnityContainer Create()
        {
            return new UnityContainer();
        }

        #endregion
    }
}