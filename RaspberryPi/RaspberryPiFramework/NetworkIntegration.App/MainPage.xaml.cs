using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ARGUSnet.RaspberryPiFramework.NetworkIntegration.Services;
using Microsoft.Practices.Unity;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ARGUSnet.RaspberryPiFramework.NetworkIntegration.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private HttpService _httpService;

        public MainPage()
        {
            this.InitializeComponent();
            InitializeHttpService();
        }

        private void InitializeHttpService()
        {
            Task.Run(async () =>
            {
                var uc = new UnityContainer();
                _httpService = uc.Resolve<HttpService>();
                await _httpService.InitializeAsync();
            });

        }
    }
}
