using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerApi.Models.Spaces
{
    public class SpaceQueryRequest
    {
        public long? OrgId { get; set; }
        public long? BuildingId { get; set; }
        public int? SpaceType { get; set; }
        public bool? IsActive { get; set; }
    }
}
