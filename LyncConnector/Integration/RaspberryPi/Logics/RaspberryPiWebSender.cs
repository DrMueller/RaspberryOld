using System;
using System.Net.Http;
using System.Threading.Tasks;
using ARGUSnet.LyncConnector.Integration.Infrastructure;
using ARGUSnet.RaspberryPiFramework.Model.Common;
using ARGUSnet.RaspberryPiFramework.Model.Constants;
using Newtonsoft.Json;

namespace ARGUSnet.LyncConnector.Integration.RaspberryPi.Logics
{
    public class RaspberryPiWebSender
    {
        #region Public/Internal Methods

        internal Task SendActionCommandAsync(ActionCommand actionCommand)
        {
            var utf8ByteArray = SerializeToUtf8(actionCommand);

            return Task.Run(async () =>
            {
                using (var client = new HttpClient())
                {
                    var stringContent = new ByteArrayContent(utf8ByteArray);
                    var url = string.Concat(Network.IP, ":", Network.PORT);
                    try
                    {
                        await client.PostAsync(url, stringContent);
                    }
                    catch (Exception)
                    {
                        // Fire and forget
                    }
                }
            });
        }

        #endregion

        #region Private Methods

        private byte[] SerializeToUtf8(ActionCommand actionCommand)
        {
            var jsonString = JsonConvert.SerializeObject(actionCommand);
            var result = jsonString.ToUtf8ByteArray();
            return result;
        }

        #endregion
    }
}