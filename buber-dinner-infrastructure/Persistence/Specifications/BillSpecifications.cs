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
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => BillId.SpawnWith(value));

        builder.Property(m => m.DinnerId)
            .HasConversion(
                id => id.Value,
                value => DinnerId.SpawnWith(value));
        builder.Property(m => m.GuestId)
            .HasConversion(
                id => id.Value,
                value => GuestId.SpawnWith(value));
        builder.Property(m => m.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.SpawnWith(value));

        builder.OwnsOne(m => m.Price, priceBuilder =>
        {
            priceBuilder.Property(p => p.Currency)
                .HasColumnType("varchar(100)")
                .HasColumnName("Currency");
            
            priceBuilder.Property(p => p.Amount)
                .HasColumnType("money")
                .HasColumnName("Amount");
        });

        builder.Property(m => m.CreatedOn)
            .HasColumnType("datetime2(7)");
        builder.Property(m => m.ModifiedOn)
            .HasColumnType("datetime2(7)");
    }
}