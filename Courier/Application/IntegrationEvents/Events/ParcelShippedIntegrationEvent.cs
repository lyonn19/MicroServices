namespace Courier.Application.IntegrationEvents.Events;

public class ParcelShippedIntegrationEvent
{
    public Guid ParcelId { get; }
    public string TrackingNumber { get; }
    public DateTime ShippedDate { get; }
    public string Carrier { get; }
    public string ServiceLevel { get; }

    public ParcelShippedIntegrationEvent(
        Guid parcelId, 
        string trackingNumber,
        DateTime shippedDate,
        string carrier,
        string serviceLevel)
    {
        ParcelId = parcelId;
        TrackingNumber = trackingNumber;
        ShippedDate = shippedDate;
        Carrier = carrier;
        ServiceLevel = serviceLevel;
    }
}