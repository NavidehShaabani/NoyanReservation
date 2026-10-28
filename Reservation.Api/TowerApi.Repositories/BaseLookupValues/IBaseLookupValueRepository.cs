using TowerApi.Models.BaseLookupValues;

namespace TowerApi.Repositories.BaseLookupValues
{
    public interface IBaseLookupValueRepository
    {
        Task<BaseLookupValueResult<IEnumerable<dynamic>>>
            GetAsync(CancellationToken cancellationToken = default);

        Task<BaseLookupValueResult<dynamic>>
            GetByIdAsync(
                int lookupValueId,
                CancellationToken cancellationToken = default);
    }
}
