using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ARGUSnet.RasperryPi2.Extensions.LedDisplay.Mappings;
using ARGUSnet.RasperryPi2.Extensions.LedDisplay.Model;
using ARGUSnet.RasperryPi2.NativeAdapter.SenseHat.LedDisplay;
using Windows.UI;

namespace ARGUSnet.RasperryPi2.Extensions.LedDisplay
{
    public class LedDisplayHeartAdapter
    {
        #region Constructors

        public LedDisplayHeartAdapter(LedDisplayAdapter ledDisplayAdapter)
        {
            _random = new Random();
            _mappingDispatcher = new MappingDispatcher();
            _ledDisplayAdapter = ledDisplayAdapter;
            SetHueChunks();
        }

        #endregion Constructors

        #region Public Methods

        public void StartBlinkingHeart()
        {
            _blinkingTimer = new Timer(BlinkingTimer_Callback, null, 1000, 1000);
        }

        #endregion Public Methods

        #region Fields

        private readonly LedDisplayAdapter _ledDisplayAdapter;
        private readonly MappingDispatcher _mappingDispatcher;
        private readonly Random _random;

        private Timer _blinkingTimer;
        private List<HueChunk> _hueChunks;

        #endregion Fields

        #region Private Methods

        private void BlinkingTimer_Callback(object state)
        {
            Color backGround;
            Color foreGround;
            CalculateColors(out backGround, out foreGround);

            _ledDisplayAdapter.SetAllLeds(backGround);

            var positions = _mappingDispatcher.MapFromName("Heart");
            _ledDisplayAdapter.SetLedsByPosition(foreGround, positions);
            _ledDisplayAdapter.UpdateVisual();
        }

        private void CalculateColors(out Color backGround, out Color foreGround)
        {
            var rndChunkIndex = _random.Next(_hueChunks.Count);
            var backGroundChunk = _hueChunks[rndChunkIndex];

            ////6 % 6 = 0
            ////5 % 6 = 1
            ////4 % 6 = 2
            ////3 % 6 = 3
            ////2 % 6 = 4
            ////1 % 6 = 5

            var chunksWithOherMaxValue = _hueChunks.Where(f => f.MaxValueType == backGroundChunk.MinValueType);
            var foreGroundChunk = chunksWithOherMaxValue.ElementAt(_random.Next(chunksWithOherMaxValue.Count()));

            var rndForeGroundRgb = (byte)_random.Next(214);
            var rndBackGroundRgb = (byte)_random.Next(214);

            backGround = backGroundChunk.ToColor(rndBackGroundRgb);
            foreGround = foreGroundChunk.ToColor(rndForeGroundRgb);
        }

        private void SetHueChunks()
        {
            // We have 240 / 40 Chunks
            _hueChunks = new List<HueChunk>();
            for (var i = 40; i <= 240; i += 40)
            {
                _hueChunks.Add(new HueChunk(i));
            }
        }

        #endregion Private Methods
    }
}