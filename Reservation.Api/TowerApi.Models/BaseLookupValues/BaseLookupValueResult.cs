using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerApi.Models.BaseLookupValues
{
    public sealed class BaseLookupValueResult<T>
    {
        public int ResultCode { get; init; }

        public string ResultMessage { get; init; } = string.Empty;

        public T? Data { get; init; }

        public bool IsSuccess => ResultCode == 200;
    }
}
