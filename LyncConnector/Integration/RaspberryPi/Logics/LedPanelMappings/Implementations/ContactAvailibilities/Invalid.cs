using System.Windows.Media;
using ARGUSnet.LyncConnector.Integration.Infrastructure;
using ARGUSnet.RaspberryPiFramework.Model.SenseHat.LedDisplay;

namespace ARGUSnet.LyncConnector.Integration.RaspberryPi.Logics.LedPanelMappings.Implementations.ContactAvailibilities
{
    internal class Invalid : LedPanelMapper
    {
        #region Public/Internal Methods

        internal override VisualLedPanel CreateLedPanel()
        {
            var result = new VisualLedPanel();
            result.VisualLeds.ForEach(f => f.VisualColor = Colors.Black.ToVisualLedColor());
            return result;
        }

        #endregion
    }
}