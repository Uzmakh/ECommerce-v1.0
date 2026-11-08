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

        // NOTE: Made nullable (DateTime?) to allow DBNull values from database columns
        // and prevent InvalidCastException when records do not have timestamps set.
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;

        // NOTE: Made nullable (DateTime?) because newly created records have not been
        // updated yet, so UpdatedAt is NULL in the database until an update occurs.
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;

        // NOTE: Defaults to true so active status is preserved on creation.
        public bool IsActive { get; set; } = true;
    }
}
