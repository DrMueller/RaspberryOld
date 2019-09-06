using ARGUSnet.LyncConnector.Integration.RaspberryPi;

namespace ARGUSnet.LyncConnector.Services
{
    public class RaspberryPiService
    {
        private readonly RaspberryPiIntegration _raspberryPiIntegrtion;

        public RaspberryPiService(RaspberryPiIntegration raspberryPiIntegrtion)
        {
            _raspberryPiIntegrtion = raspberryPiIntegrtion;
        }
    }
}