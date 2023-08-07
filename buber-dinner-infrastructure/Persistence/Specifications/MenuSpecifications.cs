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
        builder.HasKey(menu => menu.Id);
        builder.Property(menu => menu.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MenuId.SpawnWith(value));
        builder.Property(menu => menu.Name)
            .HasColumnType("nvarchar(100)")
            .HasMaxLength(100);
        builder.Property(menu => menu.Description)
            .HasColumnType("nvarchar(1000)")
            .HasMaxLength(1000);
        builder.OwnsOne(menu => menu.AverageRating, avgBuilder =>
        {
            avgBuilder.Property(rating => rating.NumOfRatings)
                .HasColumnType("int")
                .HasColumnName("NumOfRatings");
            
            avgBuilder.Property(rating => rating.Value)
                .HasColumnType("decimal(3,2)")
                .HasColumnName("AverageRating");
        });
        builder.Property(menu => menu.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.SpawnWith(value));
        builder.Property(menu => menu.CreatedOn)
            .HasColumnType("datetime2(7)");
        builder.Property(menu => menu.ModifiedOn)
            .HasColumnType("datetime2(7)");
    }

    private void ConfigureMenuSectionEntity(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(menu => menu.Sections, secBuilder =>
        {
            secBuilder.ToTable("MenuSections");
            secBuilder.WithOwner().HasForeignKey("MenuId");
            secBuilder.HasKey(nameof(MenuSection.Id), "MenuId");
            secBuilder.Property(menuSection => menuSection.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuSectionId.SpawnWith(value));
            secBuilder.Property(menuSection => menuSection.Name)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);
            secBuilder.Property(menuSection => menuSection.Description)
                .HasColumnType("nvarchar(1000)")
                .HasMaxLength(1000);

            ConfigureMenuItemEntity(secBuilder);
        });

        builder.Metadata.FindNavigation(nameof(Menu.Sections))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuItemEntity(OwnedNavigationBuilder<Menu, MenuSection> secBuilder)
    {
        secBuilder.OwnsMany(menuSection => menuSection.Items, itemBuilder =>
        {
            itemBuilder.ToTable("MenuItems");
            itemBuilder.WithOwner().HasForeignKey("MenuSectionId", "MenuId");
            itemBuilder.HasKey(nameof(MenuItem.Id), "MenuSectionId", "MenuId");
            itemBuilder.Property(menuItem => menuItem.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuItemId.SpawnWith(value));
            itemBuilder.Property(menuItem => menuItem.Name)
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
        builder.OwnsMany(menu => menu.DinnerIds, dinnerBuilder =>
        {
            dinnerBuilder.ToTable("MenuDinnerXrefs");
            dinnerBuilder.WithOwner().HasForeignKey("MenuId");
            dinnerBuilder.HasKey("Id");
            dinnerBuilder.Property(dinnerId => dinnerId.Value)
                .HasColumnName("DinnerId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuReviewEntity(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(menu => menu.MenuReviewIds, reviewBuilder =>
        {
            reviewBuilder.ToTable("MenuReviewXrefs");
            reviewBuilder.WithOwner().HasForeignKey("MenuId");
            reviewBuilder.HasKey("Id");
            reviewBuilder.Property(menuReviewId => menuReviewId.Value)
                .HasColumnName("MenuReviewId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}