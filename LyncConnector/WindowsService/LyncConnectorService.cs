using System.ServiceProcess;
using ARGUSnet.LyncConnector.Services;
using ARGUSnet.LyncConnector.WindowsService.Infrastructure;

namespace ARGUSnet.LyncConnector.WindowsService
{
    internal partial class LyncConnectorService : ServiceBase
    {
        private readonly LyncService _lyncService;

        public LyncConnectorService(LyncService lyncService)
        {
            _lyncService = lyncService;
            InitializeComponent();
            ServiceName = Constants.SERVICE_NAME;
            EventLog.Log = Constants.SERVICE_LOG_NAME;

            CanPauseAndContinue = false;
        }

        #region Protected Methods

        protected override void OnStart(string[] args)
        {
            _lyncService.StartListeningContactInformationChanged();
        }

        protected override void OnStop()
        {
            _lyncService.StopListeningContactInformationChanged();
        }

        #endregion
    }
}