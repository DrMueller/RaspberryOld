using System;
using System.Threading.Tasks;
using ARGUSnet.RasperryPi2.NativeAdapter.Common.Logics.NativeAdapters;
using Windows.Devices.Enumeration;
using Windows.Devices.I2c;

namespace ARGUSnet.RasperryPi2.NativeAdapter.Common.Logics.Factories
{
    internal class I2CDeviceNativeAdapterFactory
    {
        #region Fields

        private const byte DEVICE_ADDRESS = 0x46;

        #endregion Fields

        #region Internal Methods

        internal async Task<I2CDeviceNativeAdapter> CreateAsync()
        {
            var aqsFilter = I2cDevice.GetDeviceSelector();
            var deviceInformationCollection = await DeviceInformation.FindAllAsync(aqsFilter);

            var settings = new I2cConnectionSettings(DEVICE_ADDRESS)
            {
                BusSpeed = I2cBusSpeed.StandardMode
            };

            var i2CDevice = await I2cDevice.FromIdAsync(deviceInformationCollection[0].Id, settings);
            return new I2CDeviceNativeAdapter(i2CDevice);
        }

        #endregion Internal Methods
    }
}