using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QST.ECommerce.Domain.Catalogue;

namespace QST.ECommerce.Infrastructure.Configurations;

public class ProductConfig : IEntityTypeConfiguration<Product>

{
    //class used to map the Entity with the underlying DB Table as well as applies validation
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).HasColumnName("Name").IsRequired().HasMaxLength(300);
        builder.Property(p => p.Description).HasMaxLength(500);
        builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(p => p.StockQuantity).IsRequired();
        builder.Property(p => p.CreatedAt).IsRequired();
        builder.Property(p => p.UpdatedAt).IsRequired();
        // Add any additional configurations as needed
    }
}
//public class DepartmentConfig
//{
//}

