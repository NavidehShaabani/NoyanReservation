using TowerApi.Models.Auth;

namespace TowerApi.Services
{
    public interface ICurrentUser
    {
        bool IsAuthenticated { get; }

        long? UserId { get; }

        string Username { get; }

        string FirstName { get; }

        string LastName { get; }

        string FullName { get; }

        List<string> RoleCodes { get; }

        UserSession? User { get; }

        bool IsInRole(string roleCode);
    }
}
