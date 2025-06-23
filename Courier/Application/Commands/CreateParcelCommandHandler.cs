using Courier.Application.Common.Interfaces;
using Courier.Domain;
using Courier.Domain.ParcelAggregate;
using GreenDonut;
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
            /*
            var parcel = Parcel.Create(
                request.TrackingNumber,
                //request.Sender.ToAddress(),
                //request.Recipient.ToAddress(),
                //request.Dimensions.ToDimensions(),
                request.Weight);*/
            
            var parcel = Parcel.Create(request.TrackingNumber, new Address(), new Address(), new Dimensions(), request.Weight);

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