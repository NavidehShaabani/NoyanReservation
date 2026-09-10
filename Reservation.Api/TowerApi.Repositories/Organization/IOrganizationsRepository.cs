using TowerApi.Models.Organization;

namespace TowerApi.Repositories.Organization
{
    public interface IOrganizationsRepository
    {
        Task<OrganizationResult> AddAsync(
            OrganizationCreateRequest request,
            int userCreater);

        Task<OrganizationResult> EditAsync(
            long orgId,
            OrganizationUpdateRequest request,
            int userUpdater);

        Task<OrganizationResult> DeleteAsync(
            long orgId,
            int userUpdater);

        Task<OrganizationResult> GetAsync(
            long? orgId,
            OrganizationQueryRequest request);
    }
}
