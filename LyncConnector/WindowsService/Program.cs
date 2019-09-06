using System.ServiceProcess;
using ARGUSnet.LyncConnector.WindowsService.Infrastructure;
using Microsoft.Practices.Unity;

namespace ARGUSnet.LyncConnector.WindowsService
{
    static class Program
    {
        #region Private Methods

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var servicesToRun = new ServiceBase[]
            {
                UnityContainerSingleton.Instance.Resolve<LyncConnectorService>()
            };
            ServiceBase.Run(servicesToRun);
        }

        #endregion
    }
}