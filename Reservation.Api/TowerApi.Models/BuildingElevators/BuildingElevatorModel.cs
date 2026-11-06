
namespace TowerApi.Models.BuildingElevators
{
    public class BuildingElevatorCreateRequest
    {
        public long BuildingId { get; set; }

        public string ElevatorCode { get; set; } = string.Empty;

        public string ElevatorName { get; set; } = string.Empty;

        public string? ElevatorNameEn { get; set; }

        /// <summary>
        /// 1: Passenger
        /// 2: Freight
        /// 3: Car
        /// 4: Service
        /// 5: Stretcher
        /// 6: Firefighter
        /// 7: Other
        /// </summary>
        public int ElevatorType { get; set; };

        public int? Capacity { get; set; }

        public decimal? MaxWeight { get; set; }

        public bool IsService { get; set; }

        public bool IsEmergency { get; set; }

        public string? Description { get; set; }

        public int DisplayOrder { get; set; } = 1;

        public bool IsActive { get; set; } = true;
    }
    public class BuildingElevatorUpdateRequest : BuildingElevatorCreateRequest
    {
    }
    public class BuildingElevatorQueryRequest
    {
        public long BuildingId { get; set; }

        public string? Search { get; set; }

        public int? ElevatorType { get; set; }

        public bool? IsService { get; set; }

        public bool? IsEmergency { get; set; }

        public bool? IsActive { get; set; }

        public bool IncludeDeleted { get; set; }

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 50;
    }
    public class BuildingElevatorViewModel
    {
        public long BuildingElevatorId { get; set; }

        public long BuildingId { get; set; }

        public string ElevatorCode { get; set; } = string.Empty;

        public string ElevatorName { get; set; } = string.Empty;

        public string? ElevatorNameEn { get; set; }

        public int ElevatorType { get; set; }

        public int? Capacity { get; set; }

        public decimal? MaxWeight { get; set; }

        public bool IsService { get; set; }

        public bool IsEmergency { get; set; }

        public string? Description { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? UserCreater { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? UserUpdater { get; set; }
    }
    public class BuildingElevatorBulkItem
    {
        public long? BuildingElevatorId { get; set; }

        public long BuildingId { get; set; }

        public string ElevatorCode { get; set; } = string.Empty;

        public string ElevatorName { get; set; } = string.Empty;

        public string? ElevatorNameEn { get; set; }

        public int ElevatorType { get; set; };

        public int? Capacity { get; set; }

        public decimal? MaxWeight { get; set; }

        public bool IsService { get; set; }

        public bool IsEmergency { get; set; }

        public string? Description { get; set; }

        public int DisplayOrder { get; set; } = 1;

        public bool IsActive { get; set; } = true;
    }
    public class BuildingElevatorBulkSaveRequest
    {
        public List<BuildingElevatorBulkItem> Items { get; set; } = new();
    }
    public class BuildingElevatorActiveRequest
    {
        public bool IsActive { get; set; }
    }
}
