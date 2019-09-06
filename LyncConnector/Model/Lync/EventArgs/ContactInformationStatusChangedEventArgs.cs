using ARGUSnet.LyncConnector.Model.Lync.Enums;

namespace ARGUSnet.LyncConnector.Model.Lync.EventArgs
{
    public class ContactInformationStatusChangedEventArgs : System.EventArgs
    {
        public ContactInformationStatusChangedEventArgs(ContactAvailability contactAvaliability)
        {
            ContactAvaliability = contactAvaliability;
        }

        #region Properties

        public ContactAvailability ContactAvaliability { get; }

        #endregion
    }
}