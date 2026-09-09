using TowerApi.Models.Auth;

namespace TowerApi.Services
{
    public interface IJwtService
    {
        string GenerateToken(UserSession user);
    }
}
