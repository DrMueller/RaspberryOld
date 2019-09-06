using System;
using Windows.Devices.I2c;

namespace ARGUSnet.RaspberryPiFramework.NativeAdapter.Common.Logics.Adapters
{
    internal class I2cDeviceAdapter
    {
        private readonly I2cDevice _i2cDevice;

        private bool _isDisposed;

        internal I2cDeviceAdapter(I2cDevice i2cDevice)
        {
            _i2cDevice = i2cDevice;
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
                _i2cDevice?.Dispose();
            }

            _isDisposed = true;
        }

        ~I2cDeviceAdapter()
        {
            Dispose(false);
        }

        internal byte ReadByte(byte address)
        {
            byte[] buffer = { address };
            var value = new byte[1];

            _i2cDevice.WriteRead(buffer, value);

            return value[0];
        }

        internal byte[] ReadBytes(byte address, int length)
        {
            var values = new byte[length];
            var buffer = new byte[1];
            buffer[0] = address;

            _i2cDevice.WriteRead(buffer, values);

            return values;
        }

        internal void WriteBytes(byte address, byte[] values)
        {
            var buffer = new byte[1 + values.Length];
            buffer[0] = address;
            Array.Copy(values, 0, buffer, 1, values.Length);

            _i2cDevice.Write(buffer);
        }
    }
}
