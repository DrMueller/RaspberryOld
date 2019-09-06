using System.Threading.Tasks;
using ARGUSnet.LyncConnector.Integration.RaspberryPi.Logics;
using ARGUSnet.LyncConnector.Integration.RaspberryPi.Logics.LedPanelMappings;
using ARGUSnet.LyncConnector.Model.Lync.Enums;
using ARGUSnet.RaspberryPiFramework.Model.Common;
using ARGUSnet.RaspberryPiFramework.Model.Constants;
using ARGUSnet.RaspberryPiFramework.Model.SenseHat.LedDisplay;

namespace ARGUSnet.LyncConnector.Integration.RaspberryPi
{
    public class RaspberryPiIntegration
    {
        private readonly LedPanelMapperFactory _ledPanelMapperFactory;
        private readonly RaspberryPiWebSender _raspberryPiWebSender;

        public RaspberryPiIntegration(RaspberryPiWebSender raspberryPiWebSender, LedPanelMapperFactory ledPanelMapperFactory)
        {
            _raspberryPiWebSender = raspberryPiWebSender;
            _ledPanelMapperFactory = ledPanelMapperFactory;
        }

        #region Public/Internal Methods

        public async Task SendLyncContactAvaliabilityAsync(ContactAvailability av)
        {
            var actionCommand = CreateShowLedPanelActionCommand(av);
            await _raspberryPiWebSender.SendActionCommandAsync(actionCommand);
        }

        #endregion

        #region Private Methods

        private ActionCommand CreateShowLedPanelActionCommand(ContactAvailability av)
        {
            var mapper = _ledPanelMapperFactory.Create(av);
            var ledPanel = mapper.CreateLedPanel();

            return new ActionCommand()
            {
                WorkerMethodParameterValue = ledPanel,
                WorkerMethod = LedDisplayWorkerConstants.METHOD_SHOWLEDPANEL,
                WorkerName = LedDisplayWorkerConstants.NAME,
                WorkerMethodParameterTypeName = nameof(VisualLedPanel)
            };
        }

        #endregion
    }
}