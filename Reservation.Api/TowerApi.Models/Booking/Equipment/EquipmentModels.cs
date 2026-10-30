namespace TowerApi.Models.Booking.Equipment
{
    public class EquipmentSaveRequest
    {
        public long? EquipmentId { get; set; }
        public long OrgId { get; set; }
        public long BuildingId { get; set; }
        public long? DefaultSpaceId { get; set; }

        public string EquipmentName { get; set; } = string.Empty;
        public string? EquipmentNameEn { get; set; }
        public string? EquipmentCode { get; set; }

        public string? EquipmentDescription { get; set; }
        public string? EquipmentDescriptionEn { get; set; }

        public int Quantity { get; set; } = 1;
        public int AvailableQuantity { get; set; } = 1;

        public long? OperatorEmployeeId { get; set; }
        public byte EquipmentStatus { get; set; } = 1;
        public bool IsActive { get; set; } = true;
    }

    public class EquipmentQueryRequest
    {
        public long? OrgId { get; set; }
        public long? BuildingId { get; set; }
        public long? DefaultSpaceId { get; set; }
        public bool OnlyAvailable { get; set; }
    }

    public class EquipmentViewModel
    {
        public long EquipmentId { get; set; }
        public long OrgId { get; set; }
        public long BuildingId { get; set; }
        public long? DefaultSpaceId { get; set; }

        public string EquipmentName { get; set; } = string.Empty;
        public string? EquipmentNameEn { get; set; }
        public string? EquipmentCode { get; set; }

        public string? EquipmentDescription { get; set; }
        public string? EquipmentDescriptionEn { get; set; }

        public int Quantity { get; set; }
        public int AvailableQuantity { get; set; }

        public long? OperatorEmployeeId { get; set; }
        public byte EquipmentStatus { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }
        public int? UserCreater { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UserUpdater { get; set; }
    }
}
