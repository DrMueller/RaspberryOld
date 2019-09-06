using System.Collections.Generic;
using System.Linq;
using Windows.UI;

namespace ARGUSnet.RasperryPi2.NativeAdapter.SenseHat.LedDisplay.Model
{
    internal class VisualLedPanel
    {
        #region Fields

        private readonly List<VisualLed> _leds;

        #endregion Fields

        #region Constructors

        public VisualLedPanel()
        {
            _leds = new List<VisualLed>();
            for (var x = 0; x <= 7; x++)
            {
                for (var y = 0; y <= 7; y++)
                {
                    _leds.Add(new VisualLed(new VisualLedPosition(x, y), Colors.White));
                }
            }
        }

        #endregion Constructors

        #region Internal Methods

        internal byte[] CreateBuffer()
        {
            var result = new byte[8 * 8 * 3];

            // 1 2 X X X X X X
            // X X X X X X X X
            // X X X X X X X X
            // X X X X X X X X
            // X X X X X X X X
            // X X X X X X X X
            // X X X X X X X X
            // X X X X X X X X

            // The layout of the LED buffer:
            // Row 1: R R R R R R R R G G G G G G G G B B B B B B B B
            // Row 2: R R R R R R R R G G G G G G G G B B B B B B B B
            // ...
            // Row 8: R R R R R R R R G G G G G G G G B B B B B B B B

            // So LED1 has the Bytes 0R, 8G, 16B
            var index = 0;
            for (var y = 0; y < 8; y++)
            {
                for (var x = 0; x < 8; x++)
                {
                    var ledDisplay = this[x, y];
                    result[index] = ScaleTo5Bit(ledDisplay.Color.R);
                    result[index + 8] = ScaleTo5Bit(ledDisplay.Color.G);
                    result[index + 16] = ScaleTo5Bit(ledDisplay.Color.B);

                    index++;
                }

                index += 16; // Step to the next row.
            }

            return result;
        }

        #endregion Internal Methods

        #region Private Methods

        private static byte ScaleTo5Bit(byte byteValue)
        {
            var fiveBit = byteValue >> 3;

            if ((fiveBit < 0x1b) && ((byteValue & 0x04) == 0x04))
            {
                fiveBit++; // Round up.
            }

            return (byte)fiveBit;
        }

        #endregion Private Methods

        #region Indexers

        internal VisualLed this[int x, int y]
        {
            get { return _leds.First(f => f.Position.X == x && f.Position.Y == y); }
        }

        internal VisualLed this[VisualLedPosition position]
        {
            get { return _leds.First(f => f.Position == position); }
        }

        #endregion Indexers
    }
}