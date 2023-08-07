namespace BuberDinner.Infrastructure.Persistence.Specifications;

using Domain.Bills.ValueObjects;
using Domain.Dinners;
using Domain.Dinners.Entities;
using Domain.Dinners.ValueObjects;
using Domain.Guests.ValueObjects;
using Domain.Hosts.ValueObjects;
using Domain.Menus.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DinnerSpecifications : IEntityTypeConfiguration<Dinner>
{
    public void Configure(EntityTypeBuilder<Dinner> builder)
    {
        ConfigureDinnerEntity(builder);
        ConfigureReservationEntity(builder);
    }

    private void ConfigureDinnerEntity(EntityTypeBuilder<Dinner> builder)
    {
        builder.ToTable("Dinners");
        builder.HasKey(dinner => dinner.Id);
        builder.Property(dinner => dinner.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => DinnerId.SpawnWith(value));
        builder.Property(dinner => dinner.Name)
            .HasColumnType("nvarchar(100)")
            .HasMaxLength(100);
        builder.Property(dinner => dinner.Description)
            .HasColumnType("nvarchar(1000)")
            .HasMaxLength(1000);
        builder.Property(dinner => dinner.StartOn)
            .HasColumnType("datetime2(7)");
        builder.Property(dinner => dinner.EndOn)
            .HasColumnType("datetime2(7)");
        builder.Property(dinner => dinner.StartedOn)
            .HasColumnType("datetime2(7)");
        builder.Property(dinner => dinner.Status)
            .HasColumnType("int")
            .HasConversion<int>();
        builder.Property(dinner => dinner.EndedOn)
            .HasColumnType("datetime2(7)");
        builder.Property(dinner => dinner.IsPublic)
            .HasColumnType("bit");
        builder.Property(dinner => dinner.MaxGuests)
            .HasColumnType("int");

        builder.OwnsOne(dinner => dinner.Price, priceBuilder =>
        {
            priceBuilder.Property(price => price.Currency)
                .HasColumnType("varchar(10)")
                .HasColumnName("Currency")
                .HasMaxLength(10);

            priceBuilder.Property(price => price.Amount)
                .HasColumnType("money")
                .HasColumnName("Amount");
        });

        builder.Property(dinner => dinner.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.SpawnWith(value));

        builder.Property(dinner => dinner.MenuId)
            .HasConversion(
                id => id.Value,
                value => MenuId.SpawnWith(value));

        builder.Property(dinner => dinner.ImageUrl)
            .HasColumnType("nvarchar(300)")
            .HasMaxLength(300);

        builder.OwnsOne(dinner => dinner.Location, locBuilder =>
        {
            locBuilder.Property(location => location.Name)
                .HasColumnType("nvarchar(100)")
                .HasColumnName("LocationName")
                .HasMaxLength(100);

            locBuilder.Property(location => location.Address)
                .HasColumnType("nvarchar(500)")
                .HasColumnName("Address")
                .HasMaxLength(500);

            locBuilder.Property(location => location.Latitude)
                .HasColumnType("decimal(8,6)")
                .HasColumnName("Latitude");

            locBuilder.Property(location => location.Longitude)
                .HasColumnType("decimal(9,6)")
                .HasColumnName("Longitude");
        });

        builder.Property(dinner => dinner.CreatedOn)
            .HasColumnType("datetime2(7)");
        builder.Property(dinner => dinner.ModifiedOn)
            .HasColumnType("datetime2(7)");
    }

    private void ConfigureReservationEntity(EntityTypeBuilder<Dinner> builder)
    {
        builder.OwnsMany(dinner => dinner.Reservations, reserveBuilder =>
        {
            reserveBuilder.ToTable("Reservations");
            reserveBuilder.WithOwner().HasForeignKey("DinnerId");
            reserveBuilder.HasKey(nameof(Reservation.Id), "DinnerId");
            reserveBuilder.Property(reservation => reservation.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => ReservationId.SpawnWith(value));
            reserveBuilder.Property(reservation => reservation.ReservationStatus)
                .HasColumnType("int")
                .HasConversion<int>();
            reserveBuilder.Property(reservation => reservation.GuestCount)
                .HasColumnType("int");
            reserveBuilder.Property(reservation => reservation.GuestId)
                .HasConversion(
                    id => id.Value,
                    value => GuestId.SpawnWith(value));
            reserveBuilder.Property(reservation => reservation.BillId)
                .HasConversion(
                    id => id.Value,
                    value => BillId.SpawnWith(value));

            reserveBuilder.Property(reservation => reservation.ArrivalOn)
                .HasColumnType("datetime2(7)");
            reserveBuilder.Property(reservation => reservation.CreatedOn)
                .HasColumnType("datetime2(7)");
            reserveBuilder.Property(reservation => reservation.ModifiedOn)
                .HasColumnType("datetime2(7)");
        });

        builder.Metadata.FindNavigation(nameof(Dinner.Reservations))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}