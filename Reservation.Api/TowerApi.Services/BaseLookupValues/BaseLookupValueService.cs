using TowerApi.Models.BaseLookupValues;
using TowerApi.Repositories.BaseLookupValues;

namespace TowerApi.Services.BaseLookupValues
{
    public sealed class BaseLookupValueService
        : IBaseLookupValueService
    {
        private readonly IBaseLookupValueRepository _repository;

        public BaseLookupValueService(
            IBaseLookupValueRepository repository)
        {
            _repository = repository;
        }

        public Task<BaseLookupValueResult<IEnumerable<dynamic>>>
            GetAsync(CancellationToken cancellationToken = default)
        {
            return _repository.GetAsync(cancellationToken);
        }

        public Task<BaseLookupValueResult<dynamic>>
            GetByIdAsync(
                int lookupValueId,
                CancellationToken cancellationToken = default)
        {
            if (lookupValueId <= 0)
            {
                return Task.FromResult(
                    new BaseLookupValueResult<dynamic>
                    {
                        ResultCode = 400,
                        ResultMessage = "Common.InvalidRequest",
                        Data = null
                    });
            }

            return _repository.GetByIdAsync(
                lookupValueId,
                cancellationToken);
        }
        public Task<BaseLookupValueResult<dynamic>>
            GetByLookupIdAsync(
                int lookupId,
                CancellationToken cancellationToken = default)
        {
            if (lookupId <= 0)
            {
                return Task.FromResult(
                    new BaseLookupValueResult<dynamic>
                    {
                        ResultCode = 400,
                        ResultMessage = "Common.InvalidRequest",
                        Data = null
                    });
            }

            return _repository.GetByLookupIdAsync(
                lookupId,
                cancellationToken);
        }
    }
}
