using System;
using System.Threading.Tasks;
using ARGUSnet.LyncConnector.Integration.Infrastructure;
using ARGUSnet.LyncConnector.Integration.Lync.Helper;
using ARGUSnet.LyncConnector.Model.Lync.EventArgs;
using Microsoft.Lync.Model;
using d=ARGUSnet.LyncConnector.Model.Lync.Delegates;
using model=ARGUSnet.LyncConnector.Model.Lync.Enums;

namespace ARGUSnet.LyncConnector.Integration.Lync
{
    public class LyncIntegration
    {
        private readonly object _lockLyncClient = new object();
        private readonly LyncClientInitializer _lyncClientInitializer;
        private LyncClient _lyncClient;

        public LyncIntegration(LyncClientInitializer lyncClientInitializer)
        {
            _lyncClientInitializer = lyncClientInitializer;
            Task.Run(() => Initialize());
        }

        #region Public/Internal Methods

        public event d.ContactInformationStatusChangedHandler ContactInformationStatusChanged
        {
            add
            {
                lock (_lockLyncClient)
                {
                    OnContactInformationStatusChanged = (d.ContactInformationStatusChangedHandler)Delegate.Combine(OnContactInformationStatusChanged, value);
                }
            }
            remove
            {
                OnContactInformationStatusChanged = (d.ContactInformationStatusChangedHandler)Delegate.Remove(OnContactInformationStatusChanged, value);
            }
        }

        #endregion

        #region Private Methods

        // https://rcosic.wordpress.com/2011/11/17/availability-presence-in-lync-client/
        private void Contact_ContactInformationChanged(object sender, ContactInformationChangedEventArgs e)
        {
            if (e.ChangedContactInformation.Contains(ContactInformationType.Availability))
            {
                var caObj = _lyncClient?.Self?.Contact?.GetContactInformation(ContactInformationType.Availability);
                var ca = ContactAvailability.None;
                if (caObj != null)
                {
                    ca = (ContactAvailability)caObj;
                }

                var modelContactAvaliability = ca.ToContactAvaliability();
                InvokeConactInformstionStatusChanged(modelContactAvaliability);
            }
        }

        private void Initialize()
        {
            lock (_lockLyncClient)
            {
                _lyncClient = _lyncClientInitializer.TryGettingLyncClient();
                _lyncClient.Self.Contact.ContactInformationChanged += Contact_ContactInformationChanged;
            }
        }

        private void InvokeConactInformstionStatusChanged(model.ContactAvailability modelContactAvaliability)
        {
            OnContactInformationStatusChanged?.Invoke(this, new ContactInformationStatusChangedEventArgs(modelContactAvaliability));
        }

        private event d.ContactInformationStatusChangedHandler OnContactInformationStatusChanged;

        #endregion
    }
}