using TowerApi.Models.EmployeeAssignments;

namespace TowerApi.Services.EmployeeAssignments
{

    public interface IEmployeeAssignmentService
    {
        Task<IEnumerable<EmployeeAssignmentItem>> GetAsync(
            EmployeeAssignmentQuery request);

        Task<EmployeeAssignmentItem?> GetByIdAsync(long id);

        Task<(int Code, string MessageKey, object? Data)> AddAsync(
            EmployeeAssignmentCreateRequest request, long? userId);

        Task<(int Code, string MessageKey)> EditAsync(
            long id, EmployeeAssignmentUpdateRequest request, long? userId);

        Task<(int Code, string MessageKey)> DeleteAsync(long id, long? userId);

        Task<(int Code, string MessageKey)> SetActiveAsync(
            long id, bool isActive, long? userId);
    }
}
