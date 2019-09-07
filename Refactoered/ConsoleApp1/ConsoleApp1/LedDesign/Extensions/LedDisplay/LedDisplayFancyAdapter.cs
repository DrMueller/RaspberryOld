using System.Collections.Generic;
using ARGUSnet.RasperryPi2.Extensions.LedDisplay.Mappings;
using ARGUSnet.RasperryPi2.NativeAdapter.SenseHat.LedDisplay;
using ARGUSnet.RasperryPi2.NativeAdapter.SenseHat.LedDisplay.Model;
using Windows.UI;

namespace ARGUSnet.RasperryPi2.Extensions.LedDisplay
{
    public class LedDisplayFancyAdapter
    {
        #region Constructors

        public LedDisplayFancyAdapter(LedDisplayAdapter ledDisplayAdapter, MappingDispatcher mappingDispatcher)
        {
            _ledDisplayAdapter = ledDisplayAdapter;
            _mappingDispatcher = mappingDispatcher;
        }

        #endregion Constructors

        #region Public Methods

        public void SetSpecialLeds(string name, Color color)
        {
            List<VisualLedPosition> positions;
            if (_mappingDispatcher.TryMappingPointsFromName(name, out positions))
            {
                _ledDisplayAdapter.SetLedsByPosition(color, positions);
            }
        }

        #endregion Public Methods

        #region Fields

        private readonly LedDisplayAdapter _ledDisplayAdapter;
        private readonly MappingDispatcher _mappingDispatcher;

        #endregion Fields
    }
}