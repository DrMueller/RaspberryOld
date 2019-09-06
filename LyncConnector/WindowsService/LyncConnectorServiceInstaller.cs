using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;
using ARGUSnet.LyncConnector.WindowsService.Infrastructure;

namespace ARGUSnet.LyncConnector.WindowsService
{
    [RunInstaller(true)]
    public class WindowsServiceInstaller : Installer
    {
        public WindowsServiceInstaller()
        {
            ServiceProcessInstaller serviceProcessInstaller =
                new ServiceProcessInstaller();
            ServiceInstaller serviceInstaller = new ServiceInstaller();

            //# Service Account Information
            serviceProcessInstaller.Account = ServiceAccount.LocalSystem;
            serviceProcessInstaller.Username = null;
            serviceProcessInstaller.Password = null;

            //# Service Information
            serviceInstaller.DisplayName = Constants.SERVICE_DISPLAYNAME;
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            serviceInstaller.Description = Constants.SERVICE_DESCRIPTION;

            //# This must be identical to the WindowsService.ServiceBase name
            //# set in the constructor of WindowsService.cs
            serviceInstaller.ServiceName = Constants.SERVICE_NAME;

            Installers.Add(serviceProcessInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}