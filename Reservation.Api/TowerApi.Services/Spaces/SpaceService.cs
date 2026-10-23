using TowerApi.Models.Spaces;
using TowerApi.Repositories.Spaces;

namespace TowerApi.Services.Spaces
{
    public sealed class SpaceService : ISpaceService
    {
        private readonly ISpaceRepository _repository;

        public SpaceService(ISpaceRepository repository)
        {
            _repository = repository;
        }

        public Task<SpaceOperationResult<IReadOnlyList<SpaceQueryResult>>> GetAsync(
            SpaceQueryRequest filter, CancellationToken ct)
        {
            return _repository.GetAsync(filter, ct);
        }

        public Task<SpaceOperationResult<SpaceQueryResult>> GetByIdAsync(
            long spaceId, CancellationToken ct)
        {
            if (spaceId <= 0)
            {
                return Task.FromResult(new SpaceOperationResult<SpaceQueryResult>
                {
                    ResultCode = 400,
                    ResultMessage = "شناسه فضا معتبر نیست."
                });
            }

            return _repository.GetByIdAsync(spaceId, ct);
        }

        public Task<SpaceOperationResult<long>> InsertAsync(
            SpaceSave model, long? userId, CancellationToken ct)
        {
            return _repository.InsertAsync(model, userId, ct);
        }

        public Task<SpaceOperationResult<bool>> UpdateAsync(
            long spaceId, SpaceSave model, long? userId, CancellationToken ct)
        {
            if (spaceId <= 0)
            {
                return Task.FromResult(new SpaceOperationResult<bool>
                {
                    ResultCode = 400,
                    ResultMessage = "شناسه فضا معتبر نیست.",
                    Data = false
                });
            }

            return _repository.UpdateAsync(spaceId, model, userId, ct);
        }

        public Task<SpaceOperationResult<bool>> BulkSaveAsync(
            SpaceBulkSave model, long? userId, CancellationToken ct)
        {
            if (model.Spaces is null || model.Spaces.Count == 0)
            {
                return Task.FromResult(new SpaceOperationResult<bool>
                {
                    ResultCode = 400,
                    ResultMessage = "حداقل یک فضا باید ارسال شود.",
                    Data = false
                });
            }

            return _repository.BulkSaveAsync(model, userId, ct);
        }

        public Task<SpaceOperationResult<bool>> DeleteAsync(
            long spaceId, long? userId, CancellationToken ct)
        {
            if (spaceId <= 0)
            {
                return Task.FromResult(new SpaceOperationResult<bool>
                {
                    ResultCode = 400,
                    ResultMessage = "شناسه فضا معتبر نیست.",
                    Data = false
                });
            }

            return _repository.DeleteAsync(spaceId, userId, ct);
        }

        public Task<SpaceOperationResult<bool>> SetActiveAsync(
            long spaceId, bool isActive, long? userId, CancellationToken ct)
        {
            if (spaceId <= 0)
            {
                return Task.FromResult(new SpaceOperationResult<bool>
                {
                    ResultCode = 400,
                    ResultMessage = "شناسه فضا معتبر نیست.",
                    Data = false
                });
            }

            return _repository.SetActiveAsync(spaceId, isActive, userId, ct);
        }
    }
}
