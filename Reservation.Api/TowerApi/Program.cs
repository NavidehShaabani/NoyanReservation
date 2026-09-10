
//// Add services to the container.
//builder.Services.AddRazorPages();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapRazorPages();

//app.Run();

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TowerApi.Middleware;
using TowerApi.Repositories.Extensions;
using TowerApi.Services;
using TowerApi.Services.Auth;

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
            .WithOrigins("http://10.248.182.91:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
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
        "Bearer",
        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            Description =
                "توکن JWT را وارد کنید. مثال: Bearer eyJhbGciOi..."
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
                            Id = "Bearer"
                        }
                },
                Array.Empty<string>()
            }
        });
});


// ======================================================
// Database
// ======================================================

//builder.Services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();


// ======================================================
// Repositories
// ======================================================

builder.Services.RepositoriesExtention();

// ======================================================
// Services
// ======================================================

builder.Services.AddScoped<IAuthService, AuthService>();


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
// Build
// ======================================================

var app = builder.Build();
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

app.UseHttpsRedirection();

//app.UseSession();

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