using ARGUSnet.RaspberryPiFramework.Model.SenseHat.LedDisplay;

namespace ARGUSnet.LyncConnector.Integration.RaspberryPi.Logics.LedPanelMappings
{
    public abstract class LedPanelMapper
    {
        #region Public/Internal Methods

        internal abstract VisualLedPanel CreateLedPanel();

        #endregion
    }
}