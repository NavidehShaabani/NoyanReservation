using System.Text;

namespace TowerApi.Middleware
{
    public class SwaggerBasicAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public SwaggerBasicAuthMiddleware(
            RequestDelegate next,
            IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Path.StartsWithSegments("/swagger"))
            {
                await _next(context);
                return;
            }

            var username = _configuration["SwaggerAuth:Username"];
            var password = _configuration["SwaggerAuth:Password"];

            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                Challenge(context);
                return;
            }

            var authHeader = context.Request.Headers["Authorization"]
                .ToString();

            if (!authHeader.StartsWith("Basic ",
                StringComparison.OrdinalIgnoreCase))
            {
                Challenge(context);
                return;
            }

            try
            {
                var encodedCredentials = authHeader.Substring("Basic ".Length);

                var decodedCredentials = Encoding.UTF8.GetString(
                    Convert.FromBase64String(encodedCredentials));

                var parts = decodedCredentials.Split(':', 2);

                if (parts.Length != 2)
                {
                    Challenge(context);
                    return;
                }

                var inputUsername = parts[0];
                var inputPassword = parts[1];

                if (inputUsername != username ||
                    inputPassword != password)
                {
                    Challenge(context);
                    return;
                }
            }
            catch
            {
                Challenge(context);
                return;
            }

            await _next(context);
        }

        private static void Challenge(HttpContext context)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.Headers["WWW-Authenticate"] =
                "Basic realm=\"Swagger\"";
        }
    }
}