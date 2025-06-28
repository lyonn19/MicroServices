using Courier.Domain.ParcelAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Courier.Infrastructure.Persistence.Configuration;

public class ParcelConfiguration : IEntityTypeConfiguration<Parcel>
    {
        public void Configure(EntityTypeBuilder<Parcel> builder)
        {
            builder.ToTable("Parcels");
            
            builder.HasKey(p => p.Id);
            
            builder.Property(p => p.TrackingNumber)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            // Owned Entity: Sender Address
            builder.OwnsOne(p => p.Sender, a =>
            {
                a.Property(p => p.Street).HasColumnName("SenderStreet").HasMaxLength(200);
                a.Property(p => p.City).HasColumnName("SenderCity").HasMaxLength(100);
                a.Property(p => p.State).HasColumnName("SenderState").HasMaxLength(100);
                a.Property(p => p.Country).HasColumnName("SenderCountry").HasMaxLength(100);
                a.Property(p => p.ZipCode).HasColumnName("SenderZipCode").HasMaxLength(20);
            });

            // Owned Entity: Recipient Address
            builder.OwnsOne(p => p.Recipient, a =>
            {
                a.Property(p => p.Street).HasColumnName("RecipientStreet").HasMaxLength(200);
                a.Property(p => p.City).HasColumnName("RecipientCity").HasMaxLength(100);
                a.Property(p => p.State).HasColumnName("RecipientState").HasMaxLength(100);
                a.Property(p => p.Country).HasColumnName("RecipientCountry").HasMaxLength(100);
                a.Property(p => p.ZipCode).HasColumnName("RecipientZipCode").HasMaxLength(20);
            });

            // Owned Entity: Dimensions
            builder.OwnsOne(p => p.Dimensions, d =>
            {
                d.Property(p => p.Length).HasColumnName("Length").HasColumnType("decimal(18,2)");
                d.Property(p => p.Width).HasColumnName("Width").HasColumnType("decimal(18,2)");
                d.Property(p => p.Height).HasColumnName("Height").HasColumnType("decimal(18,2)");
            });

            builder.Property(p => p.Weight)
                .HasColumnType("decimal(18,3)");

            builder.Property(p => p.Status)
                .HasConversion<string>()
                .HasMaxLength(50);

            builder.Property(p => p.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasIndex(p => p.TrackingNumber)
                .IsUnique();

            // Configure concurrency token
            builder.Property<byte[]>("RowVersion")
                .IsRowVersion();

            // Configure domain events (not stored in DB)
            builder.Ignore(p => p.DomainEvents);
        }
    }