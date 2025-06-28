using Courier.Domain.Common;
using Courier.Domain.ParcelAggregate;

namespace Courier.Domain.Events;

public abstract class ParcelEvent : DomainEvent
{
    protected ParcelEvent(Parcel parcel)
    {
        Parcel = parcel;
    }

    public Parcel Parcel { get; }
}

public class ParcelCreatedEvent : ParcelEvent
{
    public ParcelCreatedEvent(Parcel parcel) : base(parcel) { }
}

public class ParcelStatusChangedEvent : ParcelEvent
{
    public ParcelStatusChangedEvent(Parcel parcel, string oldStatus, string newStatus) 
        : base(parcel)
    {
        OldStatus = oldStatus;
        NewStatus = newStatus;
    }

    public string OldStatus { get; }
    public string NewStatus { get; }
}

public class ParcelDeliveredEvent : ParcelEvent
{
    public ParcelDeliveredEvent(Parcel parcel, DateTime deliveredAt) 
        : base(parcel)
    {
        DeliveredAt = deliveredAt;
    }

    public DateTime DeliveredAt { get; }
}