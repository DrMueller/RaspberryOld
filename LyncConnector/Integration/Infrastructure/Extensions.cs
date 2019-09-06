using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using ARGUSnet.LyncConnector.Model.Lync.Attributes;
using ARGUSnet.RaspberryPiFramework.Model.SenseHat.LedDisplay;
using Microsoft.Lync.Model;
using me=ARGUSnet.LyncConnector.Model.Lync.Enums;

namespace ARGUSnet.LyncConnector.Integration.Infrastructure
{
    internal static class Extensions
    {
        #region Public/Internal Methods

        internal static void ForEach<T>(this IEnumerable<T> e, Action<T> action)
        {
            foreach (var obj in e)
            {
                action(obj);
            }
        }

        internal static me.ContactAvailability ToContactAvaliability(this ContactAvailability ca)
        {
            var nativeIndex = (int)ca;

            var modelEnumType = typeof(me.ContactAvailability);

            foreach (Enum val in Enum.GetValues(modelEnumType))
            {
                var fi = modelEnumType.GetField(val.ToString());
                var custAttr = (NativeContactAvailabilityIdAttribute)fi.GetCustomAttributes(typeof(NativeContactAvailabilityIdAttribute), false).FirstOrDefault();
                if (custAttr != null && custAttr.NativeIndex == nativeIndex)
                {
                    return (me.ContactAvailability)val;
                }
            }

            throw new NotImplementedException(ca.ToString());
        }

        internal static byte[] ToUtf8ByteArray(this string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        internal static VisualColor ToVisualLedColor(this Color color)
        {
            return new VisualColor()
            {
                R = color.R,
                G = color.G,
                B = color.B
            };
        }

        #endregion
    }
}