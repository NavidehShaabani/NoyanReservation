
namespace TowerApi.Models.UnitStaircase
{
    public class UnitStaircaseViewModel
    {
        public long UnitStaircaseId { get; set; }

        public long UnitId { get; set; }

        public long BuildingFloorId { get; set; }

        public long BuildingStaircaseId { get; set; }

        public bool IsPrimary { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? UserCreater { get; set; }
    }
}
