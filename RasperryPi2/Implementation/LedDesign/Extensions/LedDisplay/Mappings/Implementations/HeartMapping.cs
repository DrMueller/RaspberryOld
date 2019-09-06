using System.Collections.Generic;
using ARGUSnet.RasperryPi2.NativeAdapter.SenseHat.LedDisplay.Model;

namespace ARGUSnet.RasperryPi2.Extensions.LedDisplay.Mappings.Implementations
{
    internal class HeartMapping : VisualLedPositionMapping
    {
        #region Internal Methods

        internal override List<VisualLedPosition> Map()
        {
            var result = new List<VisualLedPosition>
            {
                new VisualLedPosition(0, 2),
                new VisualLedPosition(0, 3),
                new VisualLedPosition(1, 1),
                new VisualLedPosition(1, 2),
                new VisualLedPosition(1, 3),
                new VisualLedPosition(1, 4),
                new VisualLedPosition(2, 1),
                new VisualLedPosition(2, 2),
                new VisualLedPosition(2, 3),
                new VisualLedPosition(2, 4),
                new VisualLedPosition(2, 5),
                new VisualLedPosition(3, 2),
                new VisualLedPosition(3, 3),
                new VisualLedPosition(3, 4),
                new VisualLedPosition(3, 5),
                new VisualLedPosition(3, 6),
                new VisualLedPosition(4, 2),
                new VisualLedPosition(4, 3),
                new VisualLedPosition(4, 4),
                new VisualLedPosition(4, 5),
                new VisualLedPosition(4, 6),
                new VisualLedPosition(5, 1),
                new VisualLedPosition(5, 2),
                new VisualLedPosition(5, 3),
                new VisualLedPosition(5, 4),
                new VisualLedPosition(5, 5),
                new VisualLedPosition(6, 1),
                new VisualLedPosition(6, 2),
                new VisualLedPosition(6, 3),
                new VisualLedPosition(6, 4),
                new VisualLedPosition(7, 2),
                new VisualLedPosition(7, 3)
            };

            return result;
        }

        #endregion Internal Methods
    }
}