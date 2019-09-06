using System.Threading.Tasks;
using Windows.Networking.Sockets;
using ARGUSnet.RaspberryPiFramework.NetworkIntegration.Services.Adapters;
using ARGUSnet.RaspberryPiFramework.NetworkIntegration.Services.Listeners;
using ARGUSnet.RaspberryPiFramework.NetworkIntegration.Services.Workers.Shell;

namespace ARGUSnet.RaspberryPiFramework.NetworkIntegration.Services
{
    public class HttpService
    {
        private readonly HttpListener _listener;
        private readonly StreamSocketAdapter _streamSocketAdapter;
        private readonly WorkerDispatcher _workerDispatcher;

        public async Task InitializeAsync()
        {
            _listener.OnConnectionReceived += HttpListener_OnConnectionReceived;
            await _listener.StartListeningAsync();
        }

        private async void HttpListener_OnConnectionReceived(StreamSocketListener arg1, StreamSocketListenerConnectionReceivedEventArgs arg2)
        {
            _streamSocketAdapter.Initialize(arg2.Socket);
            var actionCommand = await _streamSocketAdapter.ReadInputAsync();
            _workerDispatcher.Dispatch(actionCommand);
        }

        public HttpService(HttpListener listener, StreamSocketAdapter streamSocketAdapter, WorkerDispatcher workerDispatcher)
        {
            _listener = listener;
            _streamSocketAdapter = streamSocketAdapter;
            _workerDispatcher = workerDispatcher;
        }
    }
}