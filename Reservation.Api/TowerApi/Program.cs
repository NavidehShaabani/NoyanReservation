using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.RateLimiting;
using TowerApi.Repositories.Extensions;
using TowerApi.Services;
using TowerApi.Services.Auth;
using TowerApi.Services.Extensions;
using TowerApi.Services.RefreshTokenCleanup;

var builder = WebApplication.CreateBuilder(args);

// ======================================================
// Configuration
// ======================================================

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException(
        "Connection String 'DefaultConnection' پیدا نشد.");
}


// ======================================================
// Controllers
// ======================================================

builder.Services.AddControllers();
//________nsh
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", policy =>
    {
        policy
            //------nsh----برای تست موبایل فعلا این رو لازم دارم بعدا پاک می کنیم
            // .WithOrigins("http://10.208.8.91:3000")
            .WithOrigins("http://10.208.8.91:3000",
                        "http://10.208.8.91:5295")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});



//________
// ======================================================
// Swagger
// ======================================================

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(
        "JWT Token",
        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            Description = "Please enter JWT token into below box. Exmple:Otg35Ftj...."
        });

    options.AddSecurityRequirement(
        new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
        {
            {
                new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Reference =
                        new Microsoft.OpenApi.Models.OpenApiReference
                        {
                            Type =
                                Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                            Id = "JWT Token"
                        }
                },
                Array.Empty<string>()
            }
        });
});
//===============switch to FA and EN
//builder.Services.AddSwaggerGen(options =>
//{
//    options.AddSecurityDefinition(
//        "Accept-Language",
//        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
//        {
//            Name = "Accept-Language",
//            Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
//            In = Microsoft.OpenApi.Models.ParameterLocation.Header,
//            Description = "Language: fa or en"
//        });

//    options.AddSecurityRequirement(
//        new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
//        {
//            {
//                new Microsoft.OpenApi.Models.OpenApiSecurityScheme
//                {
//                    Reference = new Microsoft.OpenApi.Models.OpenApiReference
//                    {
//                        Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
//                        Id = "Accept-Language"
//                    }
//                },
//                Array.Empty<string>()
//            }
//        });
//});

// ======================================================
// Database
// ======================================================

//builder.Services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
// ======================================================
// Services
// ======================================================
builder.Services.AddHostedService<RefreshTokenCleanupService>();


// ======================================================
// Repositories Extention
// ======================================================

builder.Services.RepositoriesExtention();

// ======================================================
// Services Extention
// ======================================================

builder.Services.ServiceExtention();

// ======================================================
// HttpContext
// ======================================================

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ICurrentUser, CurrentUser>();


// ======================================================
// JWT Authentication
// ======================================================

builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtKey = builder.Configuration["Jwt:Key"];

        if (string.IsNullOrWhiteSpace(jwtKey))
        {
            throw new InvalidOperationException(
                "Jwt:Key پیدا نشد.");
        }

        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,

                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtKey)),

                ValidateIssuer = true,
                ValidIssuer =
                    builder.Configuration["Jwt:Issuer"],

                ValidateAudience = true,
                ValidAudience =
                    builder.Configuration["Jwt:Audience"],

                ValidateLifetime = true,

                ClockSkew = TimeSpan.FromMinutes(1)
            };
    });

builder.Services.AddAuthorization();


// ======================================================
// Session
// ======================================================

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);

    options.Cookie.HttpOnly = true;

    options.Cookie.IsEssential = true;

    options.Cookie.SecurePolicy =
        CookieSecurePolicy.Always;

    options.Cookie.SameSite =
        SameSiteMode.Lax;
});

// ======================================================
// JWT
// ======================================================

builder.Services.AddScoped<IJwtService, JwtService>();

// ======================================================
// Simple Rate Limiter for .NET 6
// ======================================================

var rateLimitStore = new System.Collections.Concurrent.ConcurrentDictionary<string, RateLimitInfo>();

const int ipPermitLimit = 10;
const int usernamePermitLimit = 5;

var rateLimitWindow = TimeSpan.FromMinutes(1);

// ======================================================
// Build
// ======================================================

var app = builder.Build();

// ======================================================
// Rate Limiting - .NET 6
// ======================================================

app.Use(async (context, next) =>
{
    // فقط Login را Rate Limit می‌کنیم
    //
    // این مسیر را با مسیر واقعی Login خودت عوض کن.
    // مثال:
    // /api/auth/login
    // /api/account/login
    // /api/users/login

    if (context.Request.Path.StartsWithSegments("/api/Auth/login"))
    {
        var ip =
            context.Connection.RemoteIpAddress?.ToString()
            ?? "unknown";

        var username =
            context.Request.Headers["X-Login-Username"]
            .ToString()
            .Trim()
            .ToLowerInvariant();

        if (string.IsNullOrWhiteSpace(username))
        {
            username = "unknown";
        }


        // ------------------------------------------
        // IP Rate Limit
        // حداکثر 10 درخواست در یک دقیقه
        // ------------------------------------------

        var ipKey = $"IP:{ip}";

        if (!CheckRateLimit(
                rateLimitStore,
                ipKey,
                ipPermitLimit,
                rateLimitWindow))
        {
            context.Response.StatusCode =
                StatusCodes.Status429TooManyRequests;

            await context.Response.WriteAsJsonAsync(new
            {
                message = "تعداد درخواست‌های شما بیش از حد مجاز است. لطفاً یک دقیقه بعد دوباره تلاش کنید."
            });

            return;
        }


        // ------------------------------------------
        // Username Rate Limit
        // حداکثر 5 درخواست در یک دقیقه
        // ------------------------------------------

        var usernameKey = $"USERNAME:{username}";

        if (!CheckRateLimit(
                rateLimitStore,
                usernameKey,
                usernamePermitLimit,
                rateLimitWindow))
        {
            context.Response.StatusCode =
                StatusCodes.Status429TooManyRequests;

            await context.Response.WriteAsJsonAsync(new
            {
                message = "تعداد تلاش برای این نام کاربری بیش از حد مجاز است. لطفاً یک دقیقه بعد دوباره تلاش کنید."
            });

            return;
        }
    }

    await next();
});


//________nsh
app.UseCors("AllowReact");

// ======================================================
// Swagger
// ======================================================

if (app.Environment.IsDevelopment())
{
    // ======================================================
    // If we will used from User and password for Swagger
    // ======================================================
    //app.UseMiddleware<SwaggerBasicAuthMiddleware>();
    app.UseSwagger();
    app.UseSwaggerUI();
}


// ======================================================
// Middleware
// ======================================================
//-------nsh
//app.UseHttpsRedirection();

//app.UseSession();
app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

// ======================================================
// Controllers
// ======================================================

app.MapControllers();


// ======================================================
// Run
// ======================================================

app.Run();

// ======================================================
// Rate Limit Helper
// ======================================================

static bool CheckRateLimit(
    System.Collections.Concurrent.ConcurrentDictionary<string, RateLimitInfo> store,
    string key,
    int permitLimit,
    TimeSpan window)
{
    var now = DateTime.UtcNow;

    var info = store.GetOrAdd(
        key,
        _ => new RateLimitInfo
        {
            Count = 0,
            WindowStart = now
        });

    lock (info)
    {
        // اگر پنجره زمانی تمام شده، شمارنده را Reset کن
        if (now - info.WindowStart >= window)
        {
            info.Count = 0;
            info.WindowStart = now;
        }

        // اگر به سقف رسیده‌ایم
        if (info.Count >= permitLimit)
        {
            return false;
        }

        info.Count++;

        return true;
    }
}


public class RateLimitInfo
{
    public int Count { get; set; }

    public DateTime WindowStart { get; set; }
}