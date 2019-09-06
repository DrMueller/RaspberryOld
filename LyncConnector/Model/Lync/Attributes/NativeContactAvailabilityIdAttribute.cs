using System;

namespace ARGUSnet.LyncConnector.Model.Lync.Attributes
{
    public class NativeContactAvailabilityIdAttribute : Attribute
    {
        public NativeContactAvailabilityIdAttribute(int nativeIndex)
        {
            NativeIndex = nativeIndex;
        }

        #region Properties

        public int NativeIndex { get; }

        #endregion
    }
}