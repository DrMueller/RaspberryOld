using System;
using System.Linq;
using System.Reflection;
using ARGUSnet.LyncConnector.Model.Lync.Enums;

namespace ARGUSnet.LyncConnector.Integration.RaspberryPi.Logics.LedPanelMappings
{
    public class LedPanelMapperFactory
    {
        #region Public/Internal Methods

        internal LedPanelMapper Create(ContactAvailability ca)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(f => typeof(LedPanelMapper).IsAssignableFrom(f) && f.Name == ca.ToString());
            if (type == null)
            {
                throw new NotImplementedException(ca.ToString());
            }

            var result = (LedPanelMapper)Activator.CreateInstance(type);
            return result;
        }

        #endregion
    }
}