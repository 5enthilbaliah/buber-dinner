namespace BuberDinner.Infrastructure.Persistence.Specifications;

using Domain.Hosts;
using Domain.Hosts.ValueObjects;
using Domain.Users.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class HostSpecifications : IEntityTypeConfiguration<Host>
{
    public void Configure(EntityTypeBuilder<Host> builder)
    {
        ConfigureHostEntity(builder);
        ConfigureHostDinnerIdsEntity(builder);
        ConfigureHostMenuIdsEntity(builder);
    }
    
    private void ConfigureHostEntity(EntityTypeBuilder<Host> builder)
    {
        builder.ToTable("Hosts");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => HostId.SpawnWith(value));
        builder.Property(m => m.FirstName)
            .HasColumnType("nvarchar(100)")
            .HasMaxLength(100);
        builder.Property(m => m.LastName)
            .HasColumnType("nvarchar(100)")
            .HasMaxLength(100);
        builder.Property(m => m.ProfileImage)
            .HasColumnType("nvarchar(300)")
            .HasMaxLength(300);
        builder.OwnsOne(m => m.AverageRating, avgBuilder =>
        {
            avgBuilder.Property(p => p.NumOfRatings)
                .HasColumnType("int")
                .HasColumnName("NumOfRatings");
            
            avgBuilder.Property(p => p.Value)
                .HasColumnType("decimal(3,2)")
                .HasColumnName("AverageRating");
        });
        builder.Property(m => m.UserId)
            .HasConversion(
                id => id.Value,
                value => UserId.SpawnWith(value));
        builder.Property(m => m.CreatedOn)
            .HasColumnType("datetime2(7)");
        builder.Property(m => m.ModifiedOn)
            .HasColumnType("datetime2(7)");
    }

    private void ConfigureHostDinnerIdsEntity(EntityTypeBuilder<Host> builder)
    {
        builder.OwnsMany(m => m.DinnerIds, dinnerBuilder =>
        {
            dinnerBuilder.ToTable("HostDinners");
            dinnerBuilder.WithOwner().HasForeignKey("HostId");
            dinnerBuilder.HasKey("Id");
            dinnerBuilder.Property(d => d.Value)
                .HasColumnName("DinnerId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Host.DinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
    
    private void ConfigureHostMenuIdsEntity(EntityTypeBuilder<Host> builder)
    {
        builder.OwnsMany(m => m.MenuIds, dinnerBuilder =>
        {
            dinnerBuilder.ToTable("HostMenus");
            dinnerBuilder.WithOwner().HasForeignKey("HostId");
            dinnerBuilder.HasKey("Id");
            dinnerBuilder.Property(d => d.Value)
                .HasColumnName("MenuId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Host.MenuIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}