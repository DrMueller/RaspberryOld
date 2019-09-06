using ARGUSnet.LyncConnector.Integration.Lync;
using ARGUSnet.LyncConnector.Integration.RaspberryPi;
using ARGUSnet.LyncConnector.Model.Lync.EventArgs;

namespace ARGUSnet.LyncConnector.Services
{
    public class LyncService
    {
        private readonly LyncIntegration _lyncIntegration;
        private readonly RaspberryPiIntegration _raspberryPiIntegration;

        public LyncService(LyncIntegration lyncIntegration, RaspberryPiIntegration raspberryPiIntegration)
        {
            _lyncIntegration = lyncIntegration;
            _raspberryPiIntegration = raspberryPiIntegration;
        }

        #region Public/Internal Methods

        public void StartListeningContactInformationChanged()
        {
            _lyncIntegration.ContactInformationStatusChanged += LyncIntegration_ContactInformationStatusChanged;
        }

        public void StopListeningContactInformationChanged()
        {
            _lyncIntegration.ContactInformationStatusChanged -= LyncIntegration_ContactInformationStatusChanged;
        }

        #endregion

        #region Private Methods

        private async void LyncIntegration_ContactInformationStatusChanged(object sender, ContactInformationStatusChangedEventArgs e)
        {
            await _raspberryPiIntegration.SendLyncContactAvaliabilityAsync(e.ContactAvaliability);
        }

        #endregion
    }
}