namespace BuberDinner.Infrastructure.Persistence.Specifications;

using Domain.Users;
using Domain.Users.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserSpecifications  : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => UserId.SpawnWith(value));
        builder.Property(m => m.FirstName)
            .HasColumnType("nvarchar(100)")
            .HasMaxLength(100);
        builder.Property(m => m.LastName)
            .HasColumnType("nvarchar(100)")
            .HasMaxLength(100);
        builder.Property(m => m.Email)
            .HasColumnType("nvarchar(150)")
            .HasMaxLength(100);
        builder.Property(m => m.Password)
            .HasColumnType("nvarchar(200)")
            .HasMaxLength(100);
        builder.Property(m => m.CreatedOn)
            .HasColumnType("datetime2(7)");
        builder.Property(m => m.ModifiedOn)
            .HasColumnType("datetime2(7)");
    }
}