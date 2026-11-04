using Microsoft.EntityFrameworkCore;
using QST.ECommerce.Domain.Catalogue;

namespace QST.ECommerce.Infrastructure.DbContexts;

//A class used to connect Application with the underlying database using Dbset Objects
//For Configurations, there is another config class for each Entity/Table
public class CatalogDbContext : DbContext
{
    // 1. Parameterless constructor (optional, but helpful for EF tooling)
    protected CatalogDbContext()
    {
    }

    // 2. Constructor for Dependency Injection (passes options to base DbContext)
    public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
    {
        //Catalogue,Ordering,Payment,Shipping,Customer,Inventory,Notification,Analytics,Reporting, etc. - Each bounded context will have its own DbContext
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Department> Departments => Set<Department>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogDbContext).Assembly);
    }
}
