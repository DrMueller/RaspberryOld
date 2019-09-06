using System;
using Windows.Devices.I2c;

namespace ARGUSnet.RasperryPi2.NativeAdapter.Common.Logics.NativeAdapters
{
    internal class I2CDeviceNativeAdapter : IDisposable
    {
        #region Public Methods

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion Public Methods
        #region Protected Methods

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                return;
            }

            if (disposing)
            {
                _i2CDevice?.Dispose();
            }

            _isDisposed = true;
        }

        #endregion Protected Methods
        #region Fields

        private readonly I2cDevice _i2CDevice;

        private bool _isDisposed;

        #endregion Fields
        #region Constructors

        internal I2CDeviceNativeAdapter(I2cDevice i2CDevice)
        {
            _i2CDevice = i2CDevice;
        }

        ~I2CDeviceNativeAdapter()
        {
            Dispose(false);
        }

        #endregion Constructors
        #region Internal Methods

        internal byte ReadByte(byte address)
        {
            byte[] buffer = {address};
            var value = new byte[1];

            _i2CDevice.WriteRead(buffer, value);

            return value[0];
        }

        internal byte[] ReadBytes(byte address, int length)
        {
            var values = new byte[length];
            var buffer = new byte[1];
            buffer[0] = address;

            _i2CDevice.WriteRead(buffer, values);

            return values;
        }

        internal void WriteBytes(byte address, byte[] values)
        {
            var buffer = new byte[1 + values.Length];
            buffer[0] = address;
            Array.Copy(values, 0, buffer, 1, values.Length);

            _i2CDevice.Write(buffer);
        }

        #endregion Internal Methods
    }
}