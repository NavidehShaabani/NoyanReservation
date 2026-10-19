using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerApi.Models.Signup
{
    public class SignupServiceResult<T>
    {
        public int Code { get; set; }
        public string MessageKey { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}
