using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerApi.Models.Geo
{
    public class GeoResponseGetByIdResult
    {
        public int Code { get; set; }
        public string MessageKey { get; set; } = string.Empty;
        public GeoResponseGetById? Data { get; set; }
    }
}
