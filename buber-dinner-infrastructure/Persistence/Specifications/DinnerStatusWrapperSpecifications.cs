namespace BuberDinner.Infrastructure.Persistence.Specifications;

using Domain.Dinners.Entities;
using Domain.Dinners.Enums;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DinnerStatusWrapperSpecifications: IEntityTypeConfiguration<DinnerStatusWrapper>
{
    public void Configure(EntityTypeBuilder<DinnerStatusWrapper> builder)
    {
        builder.ToTable("DinnerStatuses");
        builder.HasKey(dinnerStatus => dinnerStatus.Id);
        builder.Property(dinnerStatus => dinnerStatus.Id)
            .ValueGeneratedNever()
            .HasConversion<int>();
        builder.Property(dinnerStatus => dinnerStatus.Name)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);
        builder.Property(dinnerStatus => dinnerStatus.CreatedOn)
            .HasColumnType("datetime2(7)");
        builder.Property(dinnerStatus => dinnerStatus.ModifiedOn)
            .HasColumnType("datetime2(7)");
        
        builder.HasData(
            Enum.GetValues(typeof(DinnerStatus))
                .Cast<DinnerStatus>()
                .Select(dinnerStatus => DinnerStatusWrapper.SpawnOne(
                    dinnerStatus,
                    dinnerStatus.ToString(),
                    DateTime.UtcNow,
                    DateTime.UtcNow
                ))
        );
    }
}