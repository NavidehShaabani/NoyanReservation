using TowerApi.Models.BaseLookupValues;

namespace TowerApi.Services.BaseLookupValues
{
    public interface IBaseLookupValueService
    {
        Task<BaseLookupValueResult<IEnumerable<dynamic>>>
            GetAsync(CancellationToken cancellationToken = default);

        Task<BaseLookupValueResult<dynamic>>
            GetByIdAsync(
                int lookupValueId,
                CancellationToken cancellationToken = default);
    }
}
