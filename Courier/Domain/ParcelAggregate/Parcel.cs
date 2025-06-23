using Courier.Domain.Events;
using Courier.Domain.SeedWork;

namespace Courier.Domain.ParcelAggregate;

// Domain/Parcel.cs
public class Parcel : Entity, IAggregateRoot
{
    public string TrackingNumber { get; private set; }
    public Address Sender { get; private set; }
    public Address Recipient { get; private set; }
    public Dimensions Dimensions { get; private set; }
    public decimal Weight { get; private set; }
    public ParcelStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? DeliveredAt { get; private set; }


    // Domain methods
    public void UpdateStatus(ParcelStatus newStatus)
    {
        Status = newStatus;
        AddDomainEvent(new ParcelStatusChangedEvent(this, "", newStatus.ToString()));
    }

    // Factory method
    public static Parcel Create(string trackingNumber, Address sender, Address recipient, 
        Dimensions dimensions, decimal weight)
    {
        var parcel = new Parcel
        {
            TrackingNumber = trackingNumber,
            Sender = sender,
            Recipient = recipient,
            Dimensions = dimensions,
            Weight = weight,
            Status = ParcelStatus.Registered,
            CreatedAt = DateTime.UtcNow
        };

        // Raise creation event
        //AddDomainEvent(new ParcelCreatedEvent(parcel));

        return parcel;
    }
}