using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using ARGUSnet.RaspberryPiFramework.Model.Common;

namespace ARGUSnet.RaspberryPiFramework.NetworkIntegration.Services.Adapters
{
    public class StreamSocketAdapter
    {
        private StreamSocket _streamSocket;

        internal void Initialize(StreamSocket streamSocket)
        {
            _streamSocket = streamSocket;
        }

        internal async Task<ActionCommand> ReadInputAsync()
        {
            var str = await ReadInputJsonStringAsync();
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ActionCommand>(str);

            var parameterString = result.WorkerMethodParameterValue.ToString();
            var parameterType = typeof(ActionCommand).GetTypeInfo().Assembly.GetTypes().FirstOrDefault(f => f.Name == result.WorkerMethodParameterTypeName);
            result.WorkerMethodParameterValue = Newtonsoft.Json.JsonConvert.DeserializeObject(parameterString, parameterType);
            return result;
        }

        private DataReader CreateInputReader()
        {
            DataReader result = new DataReader(_streamSocket.InputStream);
            result.InputStreamOptions = InputStreamOptions.Partial;
            return result;
        }

        private async Task<string> ReadInputJsonStringAsync()
        {
            var reader = CreateInputReader();

            var str = await ReadStringAsync(reader);
            str = StripDownHeading(str);
            return str;
        }

        private async Task<string> ReadStringAsync(DataReader reader)
        {
            // Seems like the Reader or the Socket need some Milliseconds, otherwise only the Header gets received

            bool foundJson;
            string result;
            do
            {
                var actualStringLength = await reader.LoadAsync(Model.Constants.RaspberryPi.MAX_SOCKET_BUFFER_SIZE);
                result = reader.ReadString(actualStringLength);
                foundJson = result.Contains("{");
            } while (!foundJson);

            return result;
        }

        private string StripDownHeading(string str)
        {
            var jsonStart = str.IndexOf("{", StringComparison.OrdinalIgnoreCase);
            var result = str.Substring(jsonStart);
            return result;
        }
    }
}