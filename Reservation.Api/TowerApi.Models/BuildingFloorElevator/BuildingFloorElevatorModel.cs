using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerApi.Models.BuildingFloorElevator
{
    public class BuildingFloorElevatorCreateRequest
    {
        public long BuildingId { get; set; }

        public long BuildingFloorId { get; set; }

        public long BuildingElevatorId { get; set; }

        public bool IsActive { get; set; } = true;
    }
    public class BuildingFloorElevatorUpdateRequest
    {
        public bool IsActive { get; set; } = true;
    }
    public class BuildingFloorElevatorQueryRequest
    {
        public long BuildingId { get; set; }

        public long? BuildingFloorId { get; set; }

        public long? BuildingElevatorId { get; set; }

        public bool? IsActive { get; set; }

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 50;
    }
    public class BuildingFloorElevatorViewModel
    {
        public long BuildingFloorElevatorId { get; set; }

        public long BuildingId { get; set; }

        public long BuildingFloorId { get; set; }

        public long BuildingElevatorId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? UserCreater { get; set; }

        public int? FloorNumber { get; set; }

        public string? FloorCode { get; set; }

        public string? FloorName { get; set; }

        public string? FloorNameEn { get; set; }

        public string? ElevatorCode { get; set; }

        public string? ElevatorName { get; set; }

        public string? ElevatorNameEn { get; set; }

        public byte? ElevatorType { get; set; }
    }
    public class BuildingFloorElevatorBulkItem
    {
        public long? BuildingFloorElevatorId { get; set; }

        public long BuildingId { get; set; }

        public long BuildingFloorId { get; set; }

        public long BuildingElevatorId { get; set; }

        public bool IsActive { get; set; } = true;
    }
    public class BuildingFloorElevatorBulkSaveRequest
    {
        public List<BuildingFloorElevatorBulkItem> Items { get; set; } = new();
    }
    public class BuildingFloorElevatorActiveRequest
    {
        public bool IsActive { get; set; }
    }
}

