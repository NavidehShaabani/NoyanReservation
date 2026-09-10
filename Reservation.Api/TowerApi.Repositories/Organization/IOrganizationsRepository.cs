using TowerApi.Models.Organization;

namespace TowerApi.Repositories.Organization
{
    public interface IOrganizationRepository
    {
        Task<(int ResultCode, string ResultMessage, OrganizationViewModel? Data)>
            AddAsync(
                OrganizationCreateRequest request,
                int? userCreater);

        Task<(int ResultCode, string ResultMessage, OrganizationViewModel? Data)>
            EditAsync(
                long orgId,
                OrganizationUpdateRequest request,
                int? userUpdater);

        Task<(int ResultCode, string ResultMessage)>
            DeleteAsync(
                long orgId,
                int? userUpdater);

        Task<(int ResultCode, string ResultMessage, OrganizationViewModel? Data)>
            GetByIdAsync(
                long orgId,
                bool includeDeleted);

        Task<(int ResultCode, string ResultMessage, List<OrganizationViewModel> Data)>
            GetListAsync(
                OrganizationQueryRequest request);
    }
}