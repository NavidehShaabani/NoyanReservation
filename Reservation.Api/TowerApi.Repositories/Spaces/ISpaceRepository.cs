using TowerApi.Models.Spaces;

namespace TowerApi.Repositories.Spaces
{
    public interface ISpaceRepository
    {
        Task<SpaceOperationResult<IReadOnlyList<SpaceQueryResult>>> GetAsync(
        SpaceQueryRequest filter,
        CancellationToken cancellationToken);

        Task<SpaceOperationResult<SpaceQueryResult>> GetByIdAsync(
            long spaceId,
            CancellationToken cancellationToken);

        Task<SpaceOperationResult<long>> InsertAsync(
            SpaceSave model,
            long? currentUserId,
            CancellationToken cancellationToken);

        Task<SpaceOperationResult<bool>> UpdateAsync(
            long spaceId,
            SpaceSave model,
            long? currentUserId,
            CancellationToken cancellationToken);

        Task<SpaceOperationResult<bool>> BulkSaveAsync(
            SpaceBulkSave model,
            long? currentUserId,
            CancellationToken cancellationToken);

        Task<SpaceOperationResult<bool>> DeleteAsync(
            long spaceId,
            long? currentUserId,
            CancellationToken cancellationToken);

        Task<SpaceOperationResult<bool>> SetActiveAsync(
            long spaceId,
            bool isActive,
            long? currentUserId,
            CancellationToken cancellationToken);
    }
}
