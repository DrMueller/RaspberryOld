using System.Threading.Tasks;
using ARGUSnet.RaspberryPiFramework.NativeAdapter.Common.Containers;
using ARGUSnet.RaspberryPiFramework.NativeAdapter.Common.Logics.Factories;
using ARGUSnet.RaspberryPiFramework.NativeAdapter.SenseHat.LedDisplay.Logics.Adapters;
using Microsoft.Practices.Unity;

namespace ARGUSnet.RaspberryPiFramework.NativeAdapter.SenseHat.LedDisplay.Logics.Factories
{
    public static class LedDisplayAdapterFactory
    {
        // We can't recreate it, since the i2c Stuff doesn't work with multiple Instances (EEE!)
        // Singletons are never bad...
        private static LedPanelAdapter _instance;

        public static async Task<LedPanelAdapter> CreateAsync()
        {
            if (_instance == null)
            {
                await CreateLedPaneladapterAsync();
            }

            return _instance;
        }

        private static async Task CreateLedPaneladapterAsync()
        {
            var i2cDeviceAdapterfactory = UnityContainerSingleton.Instance.Resolve<I2cDeviceAdapterFactory>();
            var ic2DeviceAdapter = await i2cDeviceAdapterfactory.CreateAsync();

            var ledPanelAdapter = new LedPanelAdapter(ic2DeviceAdapter);
            _instance = ledPanelAdapter;
        }
    }
}