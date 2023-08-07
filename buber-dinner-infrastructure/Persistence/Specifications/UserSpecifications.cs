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
        builder.HasKey(user => user.Id);
        builder.Property(user => user.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => UserId.SpawnWith(value));
        builder.Property(user => user.FirstName)
            .HasColumnType("nvarchar(100)")
            .HasMaxLength(100);
        builder.Property(user => user.LastName)
            .HasColumnType("nvarchar(100)")
            .HasMaxLength(100);
        builder.Property(user => user.Email)
            .HasColumnType("nvarchar(150)")
            .HasMaxLength(100);
        builder.Property(user => user.Password)
            .HasColumnType("nvarchar(200)")
            .HasMaxLength(100);
        builder.Property(user => user.CreatedOn)
            .HasColumnType("datetime2(7)");
        builder.Property(user => user.ModifiedOn)
            .HasColumnType("datetime2(7)");
    }
}