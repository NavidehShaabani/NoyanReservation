
namespace TowerApi.Models.LoginAttempt
{
    public class LoginAttemptStatus
    {
        public bool CanAttempt { get; set; }

        public int FailedCount { get; set; }

        public DateTime? LockedUntil { get; set; }
    }
}
