
using System.ComponentModel.DataAnnotations;

namespace TowerApi.Models.BuildingStaircase
{
    public class BuildingStaircaseBulkSaveRequest
    {
        [Required]
        [MinLength(1)]
        public List<BuildingStaircaseBulkItem> Items { get; set; }
            = new();
    }
}
