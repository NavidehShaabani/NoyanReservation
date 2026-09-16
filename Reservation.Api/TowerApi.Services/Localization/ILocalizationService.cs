using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerApi.Services.Localization
{
    public interface ILocalizationService
    {
        string Get(string key);
    }
}
