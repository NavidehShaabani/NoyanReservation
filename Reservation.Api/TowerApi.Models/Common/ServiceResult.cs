using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerApi.Models.Common
{
    public class ServiceResult<T>
    {
        public int ResultCode { get; set; }

        public string ResultMessageKey { get; set; } = string.Empty;

        public T? Data { get; set; }
    }
}
