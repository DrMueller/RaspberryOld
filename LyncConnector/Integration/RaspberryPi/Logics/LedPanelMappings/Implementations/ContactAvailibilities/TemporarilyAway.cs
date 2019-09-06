using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using ARGUSnet.LyncConnector.Integration.Infrastructure;
using ARGUSnet.RaspberryPiFramework.Model.SenseHat.LedDisplay;

namespace ARGUSnet.LyncConnector.Integration.RaspberryPi.Logics.LedPanelMappings.Implementations.ContactAvailibilities
{
    internal class TemporarilyAway : LedPanelMapper
    {
        internal override VisualLedPanel CreateLedPanel()
        {
            var result = new VisualLedPanel();

            result[0, 0].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[1, 0].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[2, 0].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[3, 0].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[4, 0].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[5, 0].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[6, 0].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[7, 0].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[0, 1].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[1, 1].VisualColor = Colors.White.ToVisualLedColor();
            result[2, 1].VisualColor = Colors.White.ToVisualLedColor();
            result[3, 1].VisualColor = Colors.White.ToVisualLedColor();
            result[4, 1].VisualColor = Colors.White.ToVisualLedColor();
            result[5, 1].VisualColor = Colors.White.ToVisualLedColor();
            result[6, 1].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[7, 1].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[0, 2].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[1, 2].VisualColor = Colors.White.ToVisualLedColor();
            result[2, 2].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[3, 2].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[4, 2].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[5, 2].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[6, 2].VisualColor = Colors.White.ToVisualLedColor();
            result[7, 2].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[0, 3].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[1, 3].VisualColor = Colors.White.ToVisualLedColor();
            result[2, 3].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[3, 3].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[4, 3].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[5, 3].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[6, 3].VisualColor = Colors.White.ToVisualLedColor();
            result[7, 3].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[0, 4].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[1, 4].VisualColor = Colors.White.ToVisualLedColor();
            result[2, 4].VisualColor = Colors.White.ToVisualLedColor();
            result[3, 4].VisualColor = Colors.White.ToVisualLedColor();
            result[4, 4].VisualColor = Colors.White.ToVisualLedColor();
            result[5, 4].VisualColor = Colors.White.ToVisualLedColor();
            result[6, 4].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[7, 4].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[0, 5].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[1, 5].VisualColor = Colors.White.ToVisualLedColor();
            result[2, 5].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[3, 5].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[4, 5].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[5, 5].VisualColor = Colors.White.ToVisualLedColor();
            result[6, 5].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[7, 5].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[0, 6].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[1, 6].VisualColor = Colors.White.ToVisualLedColor();
            result[2, 6].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[3, 6].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[4, 6].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[5, 6].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[6, 6].VisualColor = Colors.White.ToVisualLedColor();
            result[7, 6].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[0, 7].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[1, 7].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[2, 7].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[3, 7].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[4, 7].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[5, 7].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[6, 7].VisualColor = Colors.Yellow.ToVisualLedColor();
            result[7, 7].VisualColor = Colors.Yellow.ToVisualLedColor();

            return result;
        }
    }
}
