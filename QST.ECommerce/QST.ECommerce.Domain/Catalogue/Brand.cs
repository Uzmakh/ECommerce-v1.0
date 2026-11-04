using System;
using System.Collections.Generic;
using System.Text;

namespace QST.ECommerce.Domain.Catalogue
{
    public class Brand
    {
        public int Id { get; set; }                           // primary key
        public required string BrandName { get; set; }
        public required string BrandDescription { get; set; }
        public int DepartmentId { get; set; }
        public int CategoryId { get; set; }
    }
}
