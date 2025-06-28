using Courier.Application.Commands.DTO;
using MediatR;

namespace Courier.Application.Commands;

public record CreateParcelCommand(
    string TrackingNumber,
    AddressDto Sender, 
    AddressDto Recipient, 
    DimensionsDto Dimensions,
    decimal Weight) : IRequest<int>;
    
    
    