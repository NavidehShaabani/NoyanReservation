using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerApi.Models.Building;

namespace TowerApi.Services.Building
{
    public interface IBuildingService
    {
        Task<(int ResultCode, string ResultMessage, object? Data)>
            GetListAsync(BuildingQueryRequest request);

        Task<(int ResultCode, string ResultMessage, object? Data)>
            GetByIdAsync(
                long buildingId,
                bool includeDeleted);

        Task<(int ResultCode, string ResultMessage, object? Data)>
            AddAsync(
                BuildingCreateRequest request,
                int userId);

        Task<(int ResultCode, string ResultMessage, object? Data)>
            EditAsync(
                long buildingId,
                BuildingUpdateRequest request,
                int userId);

        Task<(int ResultCode, string ResultMessage)>
            DeleteAsync(
                long buildingId,
                int userId);
    }
}
