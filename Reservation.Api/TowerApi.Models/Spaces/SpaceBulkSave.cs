
using System.ComponentModel.DataAnnotations;

namespace TowerApi.Models.Spaces
{
    public class SpaceBulkSave
    {
        [Required]
        [MinLength(1)]
        public List<SpaceBulkItem> Spaces { get; set; } = new();
    }
}
