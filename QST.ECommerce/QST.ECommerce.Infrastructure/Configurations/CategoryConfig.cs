using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QST.ECommerce.Domain.Catalogue;

namespace QST.ECommerce.Infrastructure.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>

    {
        //class used to map the Entity with the underlying DB Table as well as applies validation
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasColumnName("Name").IsRequired().HasMaxLength(100);
            builder.Property(c => c.Description).HasColumnName("Description").HasMaxLength(500);
            builder.Property(c => c.DepartmentId).HasColumnName("DepartmentId").IsRequired();
            builder.Property(c=> c.IsActive).HasColumnName("IsActive").IsRequired().HasDefaultValue(true);
            // Add any additional configurations as needed
        }

       
       
    }
}
