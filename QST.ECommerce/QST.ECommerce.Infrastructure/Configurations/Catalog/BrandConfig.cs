using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QST.ECommerce.Domain.Catalogue;


namespace QST.ECommerce.Infrastructure.Configurations.Catalog
{
    public class BrandConfig : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.BrandName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.BrandDescription).IsRequired().HasMaxLength(500);
            builder.Property(x => x.DepartmentId).IsRequired();
            builder.Property(x => x.CategoryId).IsRequired();
        }

        
    }
}
