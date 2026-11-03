using TowerApi.Models.UnitStaircase;

namespace TowerApi.Repositories.UnitStaircase
{
    public interface IUnitStaircaseRepository
    {
        Task<(int ResultCode, string ResultMessage, UnitStaircaseViewModel? Data)>
            AddAsync(UnitStaircaseCreateRequest request, int? userCreater);

        Task<(int ResultCode, string ResultMessage, UnitStaircaseViewModel? Data)>
            EditAsync(long unitStaircaseId,
                UnitStaircaseUpdateRequest request);

        Task<(int ResultCode, string ResultMessage)>
            DeleteAsync(long unitStaircaseId);

        Task<(int ResultCode, string ResultMessage,
            UnitStaircaseViewModel? Data)>
            GetByIdAsync(long unitStaircaseId);

        Task<(int ResultCode, string ResultMessage,
            List<UnitStaircaseViewModel> Data)>
            GetListAsync(UnitStaircaseQueryRequest request);

        Task<(int ResultCode, string? ResultMessage)>
            BulkSaveAsync(IEnumerable<UnitStaircaseBulkItem> items,
                long currentUserId);
    }
}
