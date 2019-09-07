using System.Collections.Generic;
using ARGUSnet.RasperryPi2.NativeAdapter.SenseHat.LedDisplay.Model;

namespace ARGUSnet.RasperryPi2.Extensions.LedDisplay.Mappings
{
    internal abstract class VisualLedPositionMapping
    {
        #region Internal Methods

        internal abstract List<VisualLedPosition> Map();

        #endregion Internal Methods
    }
}