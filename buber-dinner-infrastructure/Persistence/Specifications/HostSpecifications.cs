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
        ConfigureHostDinnerEntity(builder);
        ConfigureHostMenuEntity(builder);
    }
    
    private void ConfigureHostEntity(EntityTypeBuilder<Host> builder)
    {
        builder.ToTable("Hosts");
        builder.HasKey(host => host.Id);
        builder.Property(host => host.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => HostId.SpawnWith(value));
        builder.Property(host => host.FirstName)
            .HasColumnType("nvarchar(100)")
            .HasMaxLength(100);
        builder.Property(host => host.LastName)
            .HasColumnType("nvarchar(100)")
            .HasMaxLength(100);
        builder.Property(host => host.ProfileImage)
            .HasColumnType("nvarchar(300)")
            .HasMaxLength(300);
        builder.OwnsOne(host => host.AverageRating, avgBuilder =>
        {
            avgBuilder.Property(averageRating => averageRating.NumOfRatings)
                .HasColumnType("int")
                .HasColumnName("NumOfRatings");
            
            avgBuilder.Property(averageRating => averageRating.Value)
                .HasColumnType("decimal(3,2)")
                .HasColumnName("AverageRating");
        });
        builder.Property(host => host.UserId)
            .HasConversion(
                id => id.Value,
                value => UserId.SpawnWith(value));
        builder.Property(host => host.CreatedOn)
            .HasColumnType("datetime2(7)");
        builder.Property(host => host.ModifiedOn)
            .HasColumnType("datetime2(7)");
    }

    private void ConfigureHostDinnerEntity(EntityTypeBuilder<Host> builder)
    {
        builder.OwnsMany(host => host.DinnerIds, dinnerBuilder =>
        {
            dinnerBuilder.ToTable("HostDinnerXrefs");
            dinnerBuilder.WithOwner().HasForeignKey("HostId");
            dinnerBuilder.HasKey("Id");
            dinnerBuilder.Property(dinnerId => dinnerId.Value)
                .HasColumnName("DinnerId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Host.DinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
    
    private void ConfigureHostMenuEntity(EntityTypeBuilder<Host> builder)
    {
        builder.OwnsMany(host => host.MenuIds, dinnerBuilder =>
        {
            dinnerBuilder.ToTable("HostMenuXrefs");
            dinnerBuilder.WithOwner().HasForeignKey("HostId");
            dinnerBuilder.HasKey("Id");
            dinnerBuilder.Property(menuId => menuId.Value)
                .HasColumnName("MenuId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Host.MenuIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}