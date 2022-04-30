using System;

namespace TariffComparison.Items.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public bool IsActive { get; set; }
    }
}
