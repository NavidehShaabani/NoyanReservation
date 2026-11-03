
using System.ComponentModel.DataAnnotations;

namespace TowerApi.Models.BuildingFloorStaircase
{
    public class BuildingFloorStaircaseBulkSaveRequest
    {
        [Required]
        [MinLength(1)]
        public List<BuildingFloorStaircaseBulkItem> Items { get; set; }
            = new();
    }
}
