using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ARGUSnet.RasperryPi2.Extensions.LedDisplay;
using ARGUSnet.RasperryPi2.NativeAdapter.SenseHat.LedDisplay;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ARGUSnet.RasperryPi2.TestClient
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private LedDisplayHeartAdapter _heartAdapter;

        public MainPage()
        {
            InitializeComponent();
            CreateHeartAdapter();
        }

        private void CreateHeartAdapter()
        {
            Task.Run(
                async () =>
                {
                    var nativeAdapter = await LedDisplayAdapter.CreateAsync();
                    _heartAdapter = new LedDisplayHeartAdapter(nativeAdapter);
                });
        }

        private void btnHeartTimer_Click(object sender, RoutedEventArgs e)
        {
            _heartAdapter.StartBlinkingHeart();
        }
    }
}