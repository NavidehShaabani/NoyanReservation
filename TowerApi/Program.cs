
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

using TowerApi.DataBase;
using TowerApi.Middleware;
using TowerApi.Repositories;
using TowerApi.Services;

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


// ======================================================
// Swagger
// ======================================================

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// ======================================================
// Database
// ======================================================

builder.Services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();


// ======================================================
// Repositories
// ======================================================

builder.Services.AddScoped<IAuthRepository, AuthRepository>();


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
// Authorization
// ======================================================

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
// Build
// ======================================================

var app = builder.Build();


// ======================================================
// Swagger
// ======================================================

if (app.Environment.IsDevelopment())
{
    app.UseMiddleware<SwaggerBasicAuthMiddleware>();
    app.UseSwagger();
    app.UseSwaggerUI();
}


// ======================================================
// Middleware
// ======================================================

app.UseHttpsRedirection();

app.UseSession();

app.UseAuthorization();


// ======================================================
// Controllers
// ======================================================

app.MapControllers();


// ======================================================
// Run
// ======================================================

app.Run();