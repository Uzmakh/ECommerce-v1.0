using System;
using System.Collections.Generic;
using System.Text;

namespace QST.ECommerce.Domain.Catalogue
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
       
       
    }
}
