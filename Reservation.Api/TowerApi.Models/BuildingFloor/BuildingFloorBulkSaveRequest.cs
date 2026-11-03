
using System.ComponentModel.DataAnnotations;

namespace TowerApi.Models.BuildingFloor
{
    public class BuildingFloorBulkSaveRequest
    {
        [Required]
        [MinLength(1)]
        public List<BuildingFloorBulkItem> Items { get; set; }
            = new();
    }
}
