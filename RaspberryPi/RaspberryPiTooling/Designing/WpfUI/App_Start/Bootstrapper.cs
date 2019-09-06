using ARGUSnet.RaspberryPiTooling.WpfUI.Infrastructure.Singletons;
using Microsoft.Practices.Unity;

namespace ARGUSnet.RaspberryPiTooling.WpfUI.App_Start
{
    internal static class Bootstrapper
    {
        #region Public/Internal Methods

        internal static void Initialize()
        {
            InitializeUnityContainer();
            ViewModelMappingInitializer.Initialize();
        }

        #endregion

        #region Private Methods

        private static void InitializeUnityContainer()
        {
            var uc = new UnityContainer();
            UnityContainerInstance.Initialize(uc);
        }

        #endregion
    }
}