using Windows.UI;

namespace ARGUSnet.RasperryPi2.NativeAdapter.SenseHat.LedDisplay.Model
{
    public class VisualLed
    {
        #region Constructors

        internal VisualLed(VisualLedPosition position, Color color)
        {
            Position = position;
            Color = color;
        }

        #endregion Constructors

        #region Properties

        public Color Color { get; internal set; }

        public VisualLedPosition Position { get; private set; }

        #endregion Properties
    }
}