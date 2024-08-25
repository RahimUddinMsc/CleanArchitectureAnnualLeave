using Domain.Entities;
using System;
namespace Domain.Common
{
    public class AuditableEntity : Entity
    {
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
