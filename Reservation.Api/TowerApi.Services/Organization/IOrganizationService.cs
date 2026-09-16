

using TowerApi.Models.Organization;

namespace TowerApi.Services.Organization
{
    public interface IOrganizationService
    {
        Task<(int ResultCode, string ResultMessage, object? Data)>
            GetListAsync(OrganizationQueryRequest request);

        Task<(int ResultCode, string ResultMessage, object? Data)>
            GetByIdAsync(long orgId, bool includeDeleted);

        Task<(int ResultCode, string ResultMessage, object? Data)>
            AddAsync(OrganizationCreateRequest request, int userId);

        Task<(int ResultCode, string ResultMessage, object? Data)>
            EditAsync(
                long orgId,
                OrganizationUpdateRequest request,
                int userId);

        Task<(int ResultCode, string ResultMessage)>
            DeleteAsync(long orgId, int userId);
    }
}
