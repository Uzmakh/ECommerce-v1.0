using QST.ECommerce.Application.Interfaces;
using QST.ECommerce.Domain.Catalogue;
using QST.ECommerce.Infrastructure.DbContexts;
using System.Collections.Generic;
using System.Linq;

namespace QST.ECommerce.Infrastructure.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly CatalogDbContext _dbContext;
 
        public BrandRepository(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddBrand(Brand brand)
        {
            _dbContext.Brands.Add(brand);
            int result = _dbContext.SaveChanges();
            return result;
        }

        public List<Brand> GetAllBrands()
        {
            var list = _dbContext.Brands.ToList();
            return list;
        }
    }
}
