using TowerApi.Models.LoginAttempt;

namespace TowerApi.Repositories.LoginAttempt
{

    public interface ILoginAttemptRepository
    {
        Task<LoginAttemptStatus> CheckAsync(string usernameKey);

        Task FailAsync(string usernameKey);

        Task ResetAsync(string usernameKey);
    }
}
