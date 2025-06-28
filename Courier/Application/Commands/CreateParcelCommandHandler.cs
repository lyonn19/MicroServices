using Courier.Application.Common.Interfaces;
using Courier.Domain.ParcelAggregate;
using MediatR;

namespace Courier.Application.Commands;

public class CreateParcelCommandHandler : IRequestHandler<CreateParcelCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<CreateParcelCommandHandler> _logger;

    public CreateParcelCommandHandler(
        IApplicationDbContext context,
        ILogger<CreateParcelCommandHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<int> Handle(CreateParcelCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var sender = new Address(request.Sender.Street, request.Sender.City, request.Sender.State, request.Sender.ZipCode, request.Sender.Country);
            var recipient = new Address(request.Recipient.Street, request.Recipient.City, request.Recipient.State, request.Recipient.ZipCode, request.Recipient.Country);
            var dimensions = new Dimensions(request.Dimensions.Height, request.Dimensions.Width, request.Dimensions.Length);
            
            var parcel = Parcel.Create(request.TrackingNumber, sender, recipient, dimensions, request.Weight);

            await _context.Parcels.AddAsync(parcel, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return parcel.Id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating parcel");
        }
        
        return 0;
    }
}