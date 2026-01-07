using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSchool.Domain.Entities
{
    // Base entity class that other entities can inherit from
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;  // Soft delete

        // You can add common properties all entities should have
    }
}
