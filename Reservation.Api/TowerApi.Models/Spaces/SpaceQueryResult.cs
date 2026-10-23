using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerApi.Models.Spaces
{
    public class SpaceQueryResult
    {
        public long SpaceId { get; set; }
        public long OrgId { get; set; }
        public long? BuildingId { get; set; }
        public long? ParentSpaceId { get; set; }

        public string SpaceName { get; set; } = string.Empty;
        public string? SpaceNameEn { get; set; }

        public int SpaceType { get; set; }
        public int? Capacity { get; set; }
        public decimal? Area { get; set; }

        public string? SpaceDesc { get; set; }
        public string? SpaceDescEn { get; set; }

        public bool IsReservable { get; set; }
        public bool IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public DateTime? CreatedAt { get; set; }
        public int? UserCreater { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UserUpdater { get; set; }
    }
}
