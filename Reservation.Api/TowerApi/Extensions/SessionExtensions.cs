using System.Text.Json;
using TowerApi.Models.Auth;
using Microsoft.AspNetCore.Http;

namespace TowerApi.Extensions
{
    public static class SessionExtensions
    {
        private const string UserSessionKey = "UserSession";

        public static void SetUserSession(
            this ISession session,
            UserSession user)
        {
            var json = JsonSerializer.Serialize(user);

            session.SetString(UserSessionKey, json);
        }

        public static UserSession? GetUserSession(
            this ISession session)
        {
            var json = session.GetString(UserSessionKey);

            if (string.IsNullOrEmpty(json))
                return null;

            return JsonSerializer.Deserialize<UserSession>(json);
        }

        public static void ClearUserSession(
            this ISession session)
        {
            session.Remove(UserSessionKey);
        }
    }
}
