using TowerApi.Models.EmployeeAssignments;

namespace TowerApi.Repositories.EmployeeAssignments
{

    public interface IEmployeeAssignmentRepository
    {
        Task<IEnumerable<EmployeeAssignmentItem>> GetAsync(
            EmployeeAssignmentQuery request);

        Task<EmployeeAssignmentItem?> GetByIdAsync(long id);

        Task<(int Code, long? Id)> AddAsync(
            EmployeeAssignmentCreateRequest request, int? userId);

        Task<int> EditAsync(
            long id, EmployeeAssignmentUpdateRequest request, int? userId);

        Task<int> DeleteAsync(long id, int? userId);

        Task<int> SetActiveAsync(long id, bool isActive, int? userId);
    }
}
