
using System.ComponentModel.DataAnnotations;

namespace TowerApi.Models.UnitStaircase
{
    public class UnitStaircaseBulkSaveRequest
    {
        [Required]
        [MinLength(1)]
        public List<UnitStaircaseBulkItem> Items { get; set; } = new();
    }
}
