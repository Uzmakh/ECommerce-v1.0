using QST.ECommerce.Domain.Catalogue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QST.ECommerce.Application.Interfaces
{
    public interface IBrandRepository  //contract to implement
    {
        //contract rules
        int AddBrand(Brand brand);

        //int UpdateBrand(Brand brand);
        //int DeleteBrand(int brandId);
        //Brand GetBrandById(int brandId);
        List<Brand> GetAllBrands();
    }
}
