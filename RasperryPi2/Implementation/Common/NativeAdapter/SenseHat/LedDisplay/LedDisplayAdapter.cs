using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI;
using ARGUSnet.RasperryPi2.NativeAdapter.Common.Logics.Factories;
using ARGUSnet.RasperryPi2.NativeAdapter.Common.Logics.NativeAdapters;
using ARGUSnet.RasperryPi2.NativeAdapter.SenseHat.LedDisplay.Model;
using Microsoft.Practices.Unity;

namespace ARGUSnet.RasperryPi2.NativeAdapter.SenseHat.LedDisplay
{
    public class LedDisplayAdapter : IDisposable
    {
        #region Properties

        public bool UpdateVisualsAutomatically { get; set; }

        #endregion Properties

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #region Private Methods

        private void OnLedsChanged()
        {
            if (UpdateVisualsAutomatically)
            {
                UpdateVisual();
            }
        }

        #endregion Private Methods

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

        ~LedDisplayAdapter()
        {
            Dispose(false);
        }

        #region Constructors

        private bool _isDisposed;

        internal LedDisplayAdapter(I2CDeviceNativeAdapter i2CDeviceAdapter, VisualLedPanel visualLedPanel)
        {
            _i2CDeviceAdapter = i2CDeviceAdapter;
            _visualLedPanel = visualLedPanel;
        }

        #endregion Constructors

        #region Fields

        private readonly I2CDeviceNativeAdapter _i2CDeviceAdapter;
        private readonly VisualLedPanel _visualLedPanel;

        #endregion Fields

        #region Public Methods

        public static async Task<LedDisplayAdapter> CreateAsync()
        {
            var i2CDeviceAdapterfactory = Common.Containers.UnityContainer.ContainerInstance.Resolve<I2CDeviceNativeAdapterFactory>();
            var visualDisplayCollection = Common.Containers.UnityContainer.ContainerInstance.Resolve<VisualLedPanel>();
            var ic2DeviceAdapter = await i2CDeviceAdapterfactory.CreateAsync();

            var result = new LedDisplayAdapter(ic2DeviceAdapter, visualDisplayCollection);
            return result;
        }

        public Color GetSingleLedColor(int x, int y)
        {
            return _visualLedPanel[x, y].Color;
        }

        public void SetAllLeds(Color color)
        {
            for (var x = 0; x < 8; x++)
            {
                for (var y = 0; y < 8; y++)
                {
                    _visualLedPanel[x, y].Color = color;
                }
            }

            OnLedsChanged();
        }

        public void SetLedsByPosition(Color color, IEnumerable<VisualLedPosition> positions)
        {
            foreach(var position in positions)
            {
                _visualLedPanel[position].Color = color;
            }

            OnLedsChanged();
        }

        public void UpdateVisual()
        {
            var buffer = _visualLedPanel.CreateBuffer();
            _i2CDeviceAdapter.WriteBytes(0, buffer);
        }

        #endregion Public Methods
    }
}