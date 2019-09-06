using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ARGUSnet.RaspberryPiFramework.Model.SenseHat.LedDisplay;
using ARGUSnet.RaspberryPiFramework.NetworkIntegration.Services.Workers.Shell;

namespace ARGUSnet.RaspberryPiFramework.NetworkIntegration.Services.Workers
{
    public class LedDisplayWorker : AbstractWorker
    {
        private NativeAdapter.SenseHat.LedDisplay.Logics.Adapters.LedPanelAdapter _ledPanelAdapter;

        public void ShowLedPanel(object o)
        {
            var visualLedPanel = o as VisualLedPanel;
            if (visualLedPanel == null)
            {
                throw new ArgumentException(o.ToString());
            }

            _ledPanelAdapter.ShowLedPanel(visualLedPanel);
        }

        public LedDisplayWorker()
        {
            var task = Task.Run(async () => { _ledPanelAdapter = await NativeAdapter.SenseHat.LedDisplay.Logics.Factories.LedDisplayAdapterFactory.CreateAsync(); });
            Task.WaitAll(task);
        }
    }
}