namespace BuberDinner.Infrastructure.Persistence.Specifications;

using Domain.Dinners.Entities;
using Domain.Dinners.Enums;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ReservationStatusWrapperSpecifications : IEntityTypeConfiguration<ReservationStatusWrapper>
{
    public void Configure(EntityTypeBuilder<ReservationStatusWrapper> builder)
    {
        builder.ToTable("ReservationStatuses");
        builder.HasKey(reservationStatus => reservationStatus.Id);
        builder.Property(reservationStatus => reservationStatus.Id)
            .ValueGeneratedNever()
            .HasConversion<int>();
        builder.Property(reservationStatus => reservationStatus.Name)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);
        builder.Property(reservationStatus => reservationStatus.CreatedOn)
            .HasColumnType("datetime2(7)");
        builder.Property(reservationStatus => reservationStatus.ModifiedOn)
            .HasColumnType("datetime2(7)");
        
        builder.HasData(
            Enum.GetValues(typeof(ReservationStatus))
                .Cast<ReservationStatus>()
                .Select(reservationStatus => ReservationStatusWrapper.SpawnOne(
                    reservationStatus,
                    reservationStatus.ToString(),
                    DateTime.UtcNow,
                    DateTime.UtcNow
                ))
        );
    }
}