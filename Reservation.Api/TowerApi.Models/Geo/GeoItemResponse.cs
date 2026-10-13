using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerApi.Models.Geo
{
    public class GeoItemResponse
    {
        public string GeoId { get; set; } = string.Empty;

        public string? GeoNameFr { get; set; }

        public string? GeoNameEn { get; set; }

        public Int16 GeoType { get; set; }

        public string? ParantId { get; set; }

        public string? PL1 { get; set; }

        public string? PL2 { get; set; }

        public string? PL3 { get; set; }

        public string? PL4 { get; set; }

        public string? PL5 { get; set; }

        public string? GeoPathFr { get; set; }

        public string? GeoPathEn { get; set; }
    }
}
