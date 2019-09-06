using ARGUSnet.LyncConnector.Model.Lync.Attributes;

namespace ARGUSnet.LyncConnector.Model.Lync.Enums
{
    public enum ContactAvailability
    {
        [NativeContactAvailabilityId(-1)]
        Invalid,
        [NativeContactAvailabilityId(0)]
        None = 0,
        [NativeContactAvailabilityId(3500)]
        Free,
        [NativeContactAvailabilityId(5000)]
        FreeIdle,
        [NativeContactAvailabilityId(6500)]
        Busy,
        [NativeContactAvailabilityId(7500)]
        BusyIdle,
        [NativeContactAvailabilityId(9500)]
        DoNotDisturb,
        [NativeContactAvailabilityId(12500)]
        TemporarilyAway,
        [NativeContactAvailabilityId(15500)]
        Away,
        [NativeContactAvailabilityId(18500)]
        Offline
    }
}
