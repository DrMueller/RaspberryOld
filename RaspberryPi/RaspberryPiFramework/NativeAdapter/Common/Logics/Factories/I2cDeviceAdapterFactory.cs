using System;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.I2c;
using ARGUSnet.RaspberryPiFramework.NativeAdapter.Common.Logics.Adapters;

namespace ARGUSnet.RaspberryPiFramework.NativeAdapter.Common.Logics.Factories
{
    internal class I2cDeviceAdapterFactory
    {
        private const byte DeviceAddress = 0x46;

        internal async Task<I2cDeviceAdapter> CreateAsync()
        {
            var aqsFilter = I2cDevice.GetDeviceSelector();
            var deviceInformationCollection = await DeviceInformation.FindAllAsync(aqsFilter);

            var settings = new I2cConnectionSettings(DeviceAddress)
            {
                BusSpeed = I2cBusSpeed.StandardMode
            };

            var i2cDevice = await I2cDevice.FromIdAsync(deviceInformationCollection[0].Id, settings);
            return new I2cDeviceAdapter(i2cDevice);
        }
    }
}