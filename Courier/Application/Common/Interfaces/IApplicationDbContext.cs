
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Courier.Domain.Common;
using Courier.Domain.ParcelAggregate;

namespace Courier.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Parcel> Parcels { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}