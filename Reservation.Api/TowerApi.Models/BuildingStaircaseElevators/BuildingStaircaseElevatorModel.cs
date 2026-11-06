using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerApi.Models.BuildingStaircaseElevators
{
    public class BuildingStaircaseElevatorCreateRequest
    {
        public long BuildingId { get; set; }

        public long BuildingStaircaseId { get; set; }

        public long BuildingElevatorId { get; set; }

        public bool IsActive { get; set; } = true;
    }
    public class BuildingStaircaseElevatorUpdateRequest
    {
        public bool IsActive { get; set; } = true;
    }
    public class BuildingStaircaseElevatorQueryRequest
    {
        public long BuildingId { get; set; }

        public long? BuildingStaircaseId { get; set; }

        public long? BuildingElevatorId { get; set; }

        public bool? IsActive { get; set; }

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 50;
    }
    public class BuildingStaircaseElevatorViewModel
    {
        public long BuildingStaircaseElevatorId { get; set; }

        public long BuildingId { get; set; }

        public long BuildingStaircaseId { get; set; }

        public long BuildingElevatorId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? UserCreater { get; set; }

        public string? StaircaseCode { get; set; }

        public string? StaircaseName { get; set; }

        public string? StaircaseNameEn { get; set; }

        public byte? StaircaseType { get; set; }

        public bool? IsEmergency { get; set; }

        // اطلاعات نمایشی آسانسور
        public string? ElevatorCode { get; set; }

        public string? ElevatorName { get; set; }

        public string? ElevatorNameEn { get; set; }

        public int? ElevatorType { get; set; }
    }
    public class BuildingStaircaseElevatorBulkItem
    {
        public long? BuildingStaircaseElevatorId { get; set; }

        public long BuildingId { get; set; }

        public long BuildingStaircaseId { get; set; }

        public long BuildingElevatorId { get; set; }

        public bool IsActive { get; set; } = true;
    }
    public class BuildingStaircaseElevatorBulkSaveRequest
    {
        public List<BuildingStaircaseElevatorBulkItem> Items { get; set; } = new();
    }
    public class BuildingStaircaseElevatorActiveRequest
    {
        public bool IsActive { get; set; }
    }
}
