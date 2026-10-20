using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TowerApi.Models.Building
{
    public class BuildingBulkSaveRequest
    {
        [Required]
        [MinLength(1)]
        public List<BuildingBulkItem> Buildings { get; set; }
            = new List<BuildingBulkItem>();
    }

    public class BuildingBulkItem
    {
        public long? BuildingId { get; set; }

        [Required]
        [StringLength(150)]
        public string BuildingName { get; set; } = string.Empty;

        [StringLength(500)]
        public string? BuildingAddress { get; set; }

        [StringLength(1000)]
        public string? BuildingDescription { get; set; }

        public bool? IsActive { get; set; }

        public long? OrgId { get; set; }
    }

    public class BuildingByOrgResponse
    {
        public long BuildingId { get; set; }
        public string BuildingName { get; set; } = string.Empty;
        public string? BuildingAddress { get; set; }
        public string? BuildingDescription { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UserCreater { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UserUpdater { get; set; }
        public long? OrgId { get; set; }
    }
}
