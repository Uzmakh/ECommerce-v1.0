using QST.ECommerce.Domain.Catalogue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QST.ECommerce.Application.Interfaces
{
public interface IBrandService
    {
        //Rules of Contract
        //Save means 1-Add, 2-Update, 3-Delete
        int SaveBrand(Brand brand);
        List<Brand> GetAllBrands();
    }
}
