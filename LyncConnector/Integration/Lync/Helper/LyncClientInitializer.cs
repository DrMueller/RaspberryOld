using System;
using System.Threading;
using Microsoft.Lync.Model;

namespace ARGUSnet.LyncConnector.Integration.Lync.Helper
{
    public class LyncClientInitializer
    {
        #region Public/Internal Methods

        internal LyncClient TryGettingLyncClient()
        {
            LyncClient result = null;
            var found = false;

            do
            {
                try
                {
                    result = LyncClient.GetClient();
                    found = true;
                }
                catch (Exception)
                {
                    Thread.Sleep(500);
                }
            } while (!found);

            return result;
        }

        #endregion
    }
}