
namespace TowerApi.Models.Booking.ReservationEquipment
{
    public class ReservationEquipmentSaveRequest
    {
        public long? ReservationEquipmentId { get; set; }
        public long BookingId { get; set; }
        public long EquipmentId { get; set; }
        public int Quantity { get; set; }
        public string? Notes { get; set; }
        public string? NotesEn { get; set; }
    }

    public class ReservationEquipmentQueryRequest
    {
        public long? BookingId { get; set; }
        public long? EquipmentId { get; set; }
    }

    public class ReservationEquipmentViewModel
    {
        public long ReservationEquipmentId { get; set; }
        public long BookingId { get; set; }
        public long EquipmentId { get; set; }
        public int Quantity { get; set; }

        public string? Notes { get; set; }
        public string? NotesEn { get; set; }

        public DateTime CreatedAt { get; set; }
        public int? UserCreater { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UserUpdater { get; set; }

        public string? EquipmentName { get; set; }
        public string? EquipmentNameEn { get; set; }
        public string? EquipmentCode { get; set; }
    }
}
