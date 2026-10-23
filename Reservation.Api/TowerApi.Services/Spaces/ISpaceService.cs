using TowerApi.Models.Spaces;
namespace TowerApi.Services.Spaces
{
    public interface ISpaceService
    {
        Task<SpaceOperationResult<IReadOnlyList<SpaceQueryResult>>> GetAsync(
            SpaceQueryRequest filter, CancellationToken ct);

        Task<SpaceOperationResult<SpaceQueryResult>> GetByIdAsync(
            long spaceId, CancellationToken ct);

        Task<SpaceOperationResult<long>> InsertAsync(
            SpaceSave model, long? userId, CancellationToken ct);

        Task<SpaceOperationResult<bool>> UpdateAsync(
            long spaceId, SpaceSave model, long? userId, CancellationToken ct);

        Task<SpaceOperationResult<bool>> BulkSaveAsync(
            SpaceBulkSave model, long? userId, CancellationToken ct);

        Task<SpaceOperationResult<bool>> DeleteAsync(
            long spaceId, long? userId, CancellationToken ct);

        Task<SpaceOperationResult<bool>> SetActiveAsync(
            long spaceId, bool isActive, long? userId, CancellationToken ct);
    }
}
