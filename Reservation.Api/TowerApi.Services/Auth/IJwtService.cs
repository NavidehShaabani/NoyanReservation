using TowerApi.Models.Auth;

namespace TowerApi.Services.Auth
{
    public interface IJwtService
    {
        string GenerateToken(UserSession user);
    }
}
