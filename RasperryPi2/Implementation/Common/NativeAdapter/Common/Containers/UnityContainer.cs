using uc = Microsoft.Practices.Unity;

namespace ARGUSnet.RasperryPi2.NativeAdapter.Common.Containers
{
    internal static class UnityContainer
    {
        #region Fields

        private static uc.UnityContainer _containerInstance;

        #endregion Fields

        #region Properties

        internal static uc.UnityContainer ContainerInstance
        {
            get
            {
                if (_containerInstance == null)
                {
                    SetupContainerInstance();
                }

                return _containerInstance;
            }
        }

        #endregion Properties

        #region Private Methods

        private static void SetupContainerInstance()
        {
            _containerInstance = new uc.UnityContainer();
        }

        #endregion Private Methods
    }
}