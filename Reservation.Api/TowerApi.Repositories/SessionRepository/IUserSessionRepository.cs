

using TowerApi.Models.Auth;

namespace TowerApi.Repositories.SessionRepository
{
    public interface IUserSessionRepository
    {
        Task<UserSessionEntity?> CreateAsync(
        UserSessionEntity session);

        Task<UserSessionEntity?> GetByIdAsync(
            Guid sessionId);

        Task<bool> SetActiveRoleAsync(
            Guid sessionId,
            long userId,
            long roleId);

        Task UpdateLastSeenAsync(
            Guid sessionId);

        Task RevokeAsync(
            Guid sessionId);

        Task RevokeAllAsync(
            long userId);

        Task<List<UserSessionEntity>> GetActiveAsync(
            long userId);
    }
}
