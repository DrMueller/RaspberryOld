using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Sockets;

namespace ARGUSnet.RaspberryPiFramework.NetworkIntegration.Services.Listeners
{
    public class HttpListener
    {
        internal event Action<StreamSocketListener, StreamSocketListenerConnectionReceivedEventArgs> OnConnectionReceived;

        private StreamSocketListener _listener;

        internal async Task StartListeningAsync()
        {
            _listener = new StreamSocketListener();
            _listener.ConnectionReceived += Listener_ConnectionReceived;
            await _listener.BindServiceNameAsync(Model.Constants.Network.PORT.ToString());
        }

        private void Listener_ConnectionReceived(StreamSocketListener sender, StreamSocketListenerConnectionReceivedEventArgs args)
        {
            OnConnectionReceived?.Invoke(sender, args);
        }
    }
}
