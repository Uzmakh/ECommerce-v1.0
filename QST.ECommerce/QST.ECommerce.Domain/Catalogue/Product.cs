using System;
using System.Collections.Generic;
using System.Text;

namespace QST.ECommerce.Domain.Catalogue
{
    //Entity - uniqueness
    public class Product
    {
        public int DepartmentId { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int Id { get; set; }
        public string ProductCode { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public List<string> ImageURLs { get; set; } = new List<string>();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
