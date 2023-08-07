namespace BuberDinner.Infrastructure.Persistence.Specifications;

using Domain.Dinners.ValueObjects;
using Domain.Guests.ValueObjects;
using Domain.Hosts.ValueObjects;
using Domain.MenuReview;
using Domain.MenuReview.ValueObjects;
using Domain.Menus.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MenuReviewSpecifications : IEntityTypeConfiguration<MenuReview>
{
    public void Configure(EntityTypeBuilder<MenuReview> builder)
    {
        builder.ToTable("MenuReviews");
        builder.HasKey(menuReview => menuReview.Id);
        builder.Property(menuReview => menuReview.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MenuReviewId.SpawnWith(value));
        builder.OwnsOne(menuReview => menuReview.Rating, ratingBuilder =>
        {
            ratingBuilder.Property(rating => rating.Value)
                .HasColumnType("decimal(3,2)")
                .HasColumnName("Rating");
        });
        builder.Property(menuReview => menuReview.Comment)
            .HasColumnType("nvarchar(1000)")
            .HasMaxLength(1000);
        builder.Property(menuReview => menuReview.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.SpawnWith(value));
        builder.Property(menuReview => menuReview.MenuId)
            .HasConversion(
                id => id.Value,
                value => MenuId.SpawnWith(value));
        builder.Property(menuReview => menuReview.GuestId)
            .HasConversion(
                id => id.Value,
                value => GuestId.SpawnWith(value));
        builder.Property(menuReview => menuReview.DinnerId)
            .HasConversion(
                id => id.Value,
                value => DinnerId.SpawnWith(value));
        builder.Property(menuReview => menuReview.CreatedOn)
            .HasColumnType("datetime2(7)");
        builder.Property(menuReview => menuReview.ModifiedOn)
            .HasColumnType("datetime2(7)");
    }
}