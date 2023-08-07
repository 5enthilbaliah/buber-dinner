namespace BuberDinner.Infrastructure.Persistence.Specifications;

using Domain.Hosts.ValueObjects;
using Domain.Menus;
using Domain.Menus.Entities;
using Domain.Menus.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MenuSpecifications : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenuEntity(builder);
        ConfigureMenuSectionEntity(builder);
        ConfigureMenuDinnerEntity(builder);
        ConfigureMenuReviewEntity(builder);
    }

    private void ConfigureMenuEntity(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MenuId.SpawnWith(value));
        builder.Property(m => m.Name)
            .HasColumnType("nvarchar(100)")
            .HasMaxLength(100);
        builder.Property(m => m.Description)
            .HasColumnType("nvarchar(1000)")
            .HasMaxLength(1000);
        builder.OwnsOne(m => m.AverageRating, avgBuilder =>
        {
            avgBuilder.Property(p => p.NumOfRatings)
                .HasColumnType("int")
                .HasColumnName("NumOfRatings");
            
            avgBuilder.Property(p => p.Value)
                .HasColumnType("decimal(3,2)")
                .HasColumnName("AverageRating");
        });
        builder.Property(m => m.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.SpawnWith(value));
        builder.Property(m => m.CreatedOn)
            .HasColumnType("datetime2(7)");
        builder.Property(m => m.ModifiedOn)
            .HasColumnType("datetime2(7)");
    }

    private void ConfigureMenuSectionEntity(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.Sections, secBuilder =>
        {
            secBuilder.ToTable("MenuSections");
            secBuilder.WithOwner().HasForeignKey("MenuId");
            secBuilder.HasKey(nameof(MenuSection.Id), "MenuId");
            secBuilder.Property(m => m.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuSectionId.SpawnWith(value));
            secBuilder.Property(ms => ms.Name)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);
            secBuilder.Property(ms => ms.Description)
                .HasColumnType("nvarchar(1000)")
                .HasMaxLength(1000);

            ConfigureMenuItemEntity(secBuilder);
        });

        builder.Metadata.FindNavigation(nameof(Menu.Sections))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuItemEntity(OwnedNavigationBuilder<Menu, MenuSection> secBuilder)
    {
        secBuilder.OwnsMany(ms => ms.Items, itemBuilder =>
        {
            itemBuilder.ToTable("MenuItems");
            itemBuilder.WithOwner().HasForeignKey("MenuSectionId", "MenuId");
            itemBuilder.HasKey(nameof(MenuItem.Id), "MenuSectionId", "MenuId");
            itemBuilder.Property(mi => mi.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuItemId.SpawnWith(value));
            itemBuilder.Property(mi => mi.Name)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);
            itemBuilder.Property(mi => mi.Description)
                .HasColumnType("nvarchar(1000)")
                .HasMaxLength(1000);
        });

        secBuilder.Navigation(ms => ms.Items).Metadata.SetField("_items");
        secBuilder.Navigation(ms => ms.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuDinnerEntity(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.DinnerIds, dinnerBuilder =>
        {
            dinnerBuilder.ToTable("MenuDinners");
            dinnerBuilder.WithOwner().HasForeignKey("MenuId");
            dinnerBuilder.HasKey("Id");
            dinnerBuilder.Property(d => d.Value)
                .HasColumnName("DinnerId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuReviewEntity(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.MenuReviewIds, reviewBuilder =>
        {
            reviewBuilder.ToTable("MenuReviews");
            reviewBuilder.WithOwner().HasForeignKey("MenuId");
            reviewBuilder.HasKey("Id");
            reviewBuilder.Property(d => d.Value)
                .HasColumnName("MenuReviewId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}