using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerApi.Models.Unit;

namespace TowerApi.Services.Unit
{
    public interface IUnitService
    {
        Task<(int ResultCode, string ResultMessage, object? Data)>
            GetListAsync(UnitQueryRequest request);

        Task<(int ResultCode, string ResultMessage, object? Data)>
            GetByIdAsync(
                long unitId,
                bool includeDeleted);

        Task<(int ResultCode, string ResultMessage, object? Data)>
            AddAsync(
                UnitCreateRequest request,
                int userId);

        Task<(int ResultCode, string ResultMessage, object? Data)>
            EditAsync(
                long unitId,
                UnitUpdateRequest request,
                int userId);

        Task<(int ResultCode, string ResultMessage)>
            DeleteAsync(
                long unitId,
                int userId);
    }
}
