using QST.ECommerce.Application.Interfaces;
using QST.ECommerce.Domain.Catalogue;
using System.Collections.Generic;

namespace QST.ECommerce.Application.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public int SaveBrand(Brand brand)
        {
            // Business Rules can be applied here
            int result = _brandRepository.AddBrand(brand);
            return result;
        }

        public List<Brand> GetAllBrands()
        {
            return _brandRepository.GetAllBrands();
        }
    }
}
