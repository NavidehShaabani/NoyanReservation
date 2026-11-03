
namespace TowerApi.Models.BuildingFloorStaircase
{
    public class BuildingFloorStaircaseViewModel
    {
        public long BuildingFloorStaircaseId { get; set; }

        public long BuildingId { get; set; }

        public long BuildingFloorId { get; set; }

        public long BuildingStaircaseId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? UserCreater { get; set; }
    }
}
