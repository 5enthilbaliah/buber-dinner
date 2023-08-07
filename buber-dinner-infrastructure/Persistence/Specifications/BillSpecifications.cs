namespace BuberDinner.Infrastructure.Persistence.Specifications;

using Domain.Bills;
using Domain.Bills.ValueObjects;
using Domain.Dinners.ValueObjects;
using Domain.Guests.ValueObjects;
using Domain.Hosts.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BillSpecifications : IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        ConfigureBillEntity(builder);
    }

    private void ConfigureBillEntity(EntityTypeBuilder<Bill> builder)
    {
        builder.ToTable("Bills");
        builder.HasKey(bill => bill.Id);
        builder.Property(bill => bill.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => BillId.SpawnWith(value));

        builder.Property(bill => bill.DinnerId)
            .HasConversion(
                id => id.Value,
                value => DinnerId.SpawnWith(value));
        builder.Property(bill => bill.GuestId)
            .HasConversion(
                id => id.Value,
                value => GuestId.SpawnWith(value));
        builder.Property(bill => bill.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.SpawnWith(value));

        builder.OwnsOne(bill => bill.Price, priceBuilder =>
        {
            priceBuilder.Property(price => price.Currency)
                .HasColumnType("varchar(10)")
                .HasColumnName("Currency")
                .HasMaxLength(10);
            
            priceBuilder.Property(price => price.Amount)
                .HasColumnType("money")
                .HasColumnName("Amount");
        });

        builder.Property(bill => bill.CreatedOn)
            .HasColumnType("datetime2(7)");
        builder.Property(bill => bill.ModifiedOn)
            .HasColumnType("datetime2(7)");
    }
}