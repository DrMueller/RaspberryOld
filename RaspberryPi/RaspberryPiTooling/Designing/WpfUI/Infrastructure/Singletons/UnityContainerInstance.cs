using Microsoft.Practices.Unity;

namespace ARGUSnet.RaspberryPiTooling.WpfUI.Infrastructure.Singletons
{
    internal class UnityContainerInstance
    {
        #region Properties

        internal static UnityContainer Instance { get; private set; }

        #endregion

        #region Public/Internal Methods

        internal static void Initialize(UnityContainer unityContainer)
        {
            Instance = unityContainer;
        }

        #endregion
    }
}