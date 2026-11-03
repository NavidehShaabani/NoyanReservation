
using System.ComponentModel.DataAnnotations;

namespace TowerApi.Models.Unit
{
    public class UnitBulkSaveRequest
    {
        [Required]
        [MinLength(1)]
        public List<UnitBulkItem> Units { get; set; } = new();
    }
}
