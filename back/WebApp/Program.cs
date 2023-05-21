using System.Text;
using BLL.App;
using BLL.Interfaces.App;
using DAL.App;
using DAL.App.Seeding;
using DAL.Interfaces.App;
using Domain.App;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using WebApp;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container
string connectionStringName = "DefaultConnection";

string connectionString =
    builder.Configuration.GetConnectionString(connectionStringName)
    ?? throw new InvalidOperationException($"'{connectionStringName}' not found");

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<IAppUOW, AppUOW>();
builder.Services.AddScoped<IAppBLL, AppBLL>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services
    .AddIdentity<User, IdentityRole<Guid>>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.SaveToken = false;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new()
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
            ValidIssuer = builder.Configuration["Jwt:Issuer"]!,
            ValidAudience = builder.Configuration["Jwt:Audience"]!,
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddControllers();

builder.Services.AddCors(options => options.AddPolicy("CorsAllowAny", policy =>
{
    policy.AllowAnyHeader();
    policy.AllowAnyMethod();
    policy.AllowAnyOrigin();
}));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerOptions>();
builder.Services.AddSwaggerGen();


WebApplication app = builder.Build();

SetupAppData(app, app.Configuration, app.Environment);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days
    // You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors("CorsAllowAny");

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}"
);

app.Run();


static void SetupAppData(IApplicationBuilder app, IConfiguration config, IWebHostEnvironment env)
{
    using IServiceScope serviceScope = app.ApplicationServices
        .GetRequiredService<IServiceScopeFactory>()
        .CreateScope();
    
    using AppDbContext? ctx = serviceScope.ServiceProvider.GetService<AppDbContext>();
    if (ctx == null)
    {
        throw new ApplicationException("Problem in services. Can't initialize AppDbContext");
    }

    using UserManager<User>? userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
    if (userManager == null)
    {
        throw new ApplicationException("Problem in services. Can't initialize UserManager");
    }
    
    ILogger? logger = serviceScope.ServiceProvider.GetService<ILogger<IApplicationBuilder>>();
    if (logger == null)
    {
        throw new ApplicationException("Problem in services. Can't initialize Logger");
    }

    if (ctx.Database.ProviderName!.Contains("InMemory"))
    {
        return;
    }

    // TODO: wait for db connection

    if (config.GetValue<bool>("DataInit:DropDatabase"))
    {
        logger.LogWarning("Dropping database");
        DataSeeder.DropDatabase(ctx);
    }

    if (config.GetValue<bool>("DataInit:MigrateDatabase"))
    {
        logger.LogInformation("Migrating database");
        DataSeeder.MigrateDatabase(ctx);
    }

    if (config.GetValue<bool>("DataInit:SeedAppData"))
    {
        logger.LogInformation("Seeding app data");
        DataSeeder.SeedAppData(ctx);
    }

    if (config.GetValue<bool>("DataInit:SeedTestData"))
    {
        logger.LogInformation("Seeding test data");
        DataSeeder.SeedTestData(ctx, userManager);
    }
}
