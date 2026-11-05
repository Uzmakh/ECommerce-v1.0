using QST.ECommerce.Domain.Catalogue;
using System.Collections.Generic;

namespace QST.ECommerce.Application.Interfaces
{
    public interface IBrandRepository
    {
        int AddBrand(Brand brand);

        int UpdateBrand(Brand brand);

        List<Brand> GetAllBrands();

        Brand? GetBrandById(int brandId);
    }
}
