using TowerApi.Models.Unit;

namespace TowerApi.Repositories.Unit
{
    public interface IUnitRepository
    {
        Task<(int ResultCode, string ResultMessage, UnitViewModel? Data)>
            AddAsync(
                UnitCreateRequest request,
                int? userCreater);

        Task<(int ResultCode, string ResultMessage, UnitViewModel? Data)>
            EditAsync(
                long unitId,
                UnitUpdateRequest request,
                int? userUpdater);

        Task<(int ResultCode, string ResultMessage)>
            DeleteAsync(
                long unitId,
                int? userUpdater);

        Task<(int ResultCode, string ResultMessage, UnitViewModel? Data)>
            GetByIdAsync(
                long unitId,
                bool includeDeleted);

        Task<(int ResultCode, string ResultMessage, List<UnitViewModel> Data)>
            GetListAsync(
                UnitQueryRequest request);
    }
}