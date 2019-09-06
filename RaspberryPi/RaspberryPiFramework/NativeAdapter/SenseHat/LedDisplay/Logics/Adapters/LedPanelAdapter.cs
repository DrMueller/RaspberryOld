using System;
using ARGUSnet.RaspberryPiFramework.Model.SenseHat.LedDisplay;
using ARGUSnet.RaspberryPiFramework.NativeAdapter.Common.Logics.Adapters;

namespace ARGUSnet.RaspberryPiFramework.NativeAdapter.SenseHat.LedDisplay.Logics.Adapters
{
    public class LedPanelAdapter : IDisposable
    {
        private readonly I2cDeviceAdapter _i2CDeviceAdapter;

        private bool _isDisposed;

        internal LedPanelAdapter(I2cDeviceAdapter i2CDeviceAdapter)
        {
            _i2CDeviceAdapter = i2CDeviceAdapter;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                return;
            }

            if (disposing)
            {
                _i2CDeviceAdapter?.Dispose();
            }

            _isDisposed = true;
        }

        ~LedPanelAdapter()
        {
            Dispose(false);
        }

        public void ShowLedPanel(VisualLedPanel visualLedPanel)
        {
            var buffer = CreateBuffer(visualLedPanel);
            _i2CDeviceAdapter.WriteBytes(0, buffer);
        }

        private static byte[] CreateBuffer(VisualLedPanel visualLedPanel)
        {
            var result = new byte[8*8*3];

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
                    var ledDisplay = visualLedPanel[x, y];
                    result[index] = ScaleTo5Bit(ledDisplay.VisualColor.R);
                    result[index + 8] = ScaleTo5Bit(ledDisplay.VisualColor.G);
                    result[index + 16] = ScaleTo5Bit(ledDisplay.VisualColor.B);

                    index++;
                }

                index += 16; // Step to the next row.
            }

            return result;
        }

        private static byte ScaleTo5Bit(byte byteValue)
        {
            var fiveBit = byteValue >> 3;

            if ((fiveBit < 0x1b) && ((byteValue & 0x04) == 0x04))
            {
                fiveBit++; // Round up.
            }

            return (byte)fiveBit;
        }
    }
}