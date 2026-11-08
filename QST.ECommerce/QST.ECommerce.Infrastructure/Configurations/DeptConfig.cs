using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QST.ECommerce.Domain.Catalogue;

namespace QST.ECommerce.Infrastructure.Configurations
{
    public class DeptConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).HasColumnName("Description").HasMaxLength(500);

            // NOTE: IsRequired(false) allows NULL values in database columns for existing records
            // and newly created records where timestamps may not be populated yet.
            builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").IsRequired(false);
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(100);

            // NOTE: IsRequired(false) prevents InvalidCastException when UpdatedAt is NULL in MySQL.
            builder.Property(x => x.UpdatedAt).HasColumnName("UpdatedAt").IsRequired(false);
            builder.Property(x => x.UpdatedBy).HasColumnName("UpdatedBy").HasMaxLength(100);

            // NOTE: Maps status column with a default value of true (active).
            builder.Property(x => x.IsActive).HasColumnName("IsActive").IsRequired().HasDefaultValue(true);
        }
    }
}
