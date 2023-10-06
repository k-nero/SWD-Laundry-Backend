using System.Text;
using System.Text.RegularExpressions;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Invedia.DI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Serilog;
using SWD_Laundry_Backend.Contract.Repository.Entity.IdentityModels;
using SWD_Laundry_Backend.Core.Config;
using SWD_Laundry_Backend.Extensions;
using SWD_Laundry_Backend.Repository.Infrastructure;


namespace SWD_Laundry_Backend;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Environment.EnvironmentName = Environments.Development;

        //builder.Environment.EnvironmentName = Environments.Production;

        // Add services to the container.

        SystemSettingModel.Configs = builder.Configuration.AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", false, true)
                .AddUserSecrets<Program>(true, false)
                .Build();

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


        builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                   .ReadFrom.Configuration(hostingContext.Configuration)
                              .Enrich.FromLogContext()
                                         .WriteTo.Console());
        builder.Services.AddControllers(options =>
        {
            options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
        }).AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "SWD-Laundry-Backend", Version = "v1" });
            var jwtSecurityScheme = new OpenApiSecurityScheme
            {
                BearerFormat = "JWT",
                Name = "JWT Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            options.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { jwtSecurityScheme, Array.Empty<string>() }
            });
        });
        builder.Services.AddCors();
        builder.Services.AddSingleton(FirebaseApp.Create(new AppOptions()
        {
            Credential = await GoogleCredential.FromFileAsync(builder.Configuration["Firebase:Credential"], cancellationToken: default),
            ServiceAccountId = builder.Configuration["Firebase:ServiceAccountId"],
        }));
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(
                connectionString,
                x => x.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
                );
        });
        builder.Services.AddMemoryCache();
        builder.Services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = builder.Configuration.GetConnectionString("RedisConnection");
        });
        builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
        }).AddRoleManager<RoleManager<IdentityRole>>()
     .AddRoles<IdentityRole>()
     .AddEntityFrameworkStores<AppDbContext>()
     .AddDefaultTokenProviders();
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidAudience = builder.Configuration["Jwt:ValidAudience"],
                ValidIssuer = builder.Configuration["Jwt:ValidIssuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecrectKey"]))
            };

        });
        builder.Services.AddAuthorization(options =>
        {
            options.DefaultPolicy = new AuthorizationPolicyBuilder()
                 .RequireAuthenticatedUser()
                 .Build();

            options.AddPolicy("Admin", policy => policy
                .Combine(options.DefaultPolicy)
                .RequireRole("Admin")
                .Build());
            options.AddPolicy("Staff", policy => policy
                .Combine(options.DefaultPolicy)
                .RequireRole("Staff")
                .Build());
            options.AddPolicy("Customer", policy => policy
               .Combine(options.DefaultPolicy)
               .RequireRole("Customer")
               .Build());
            options.AddPolicy("LaundryStore", policy => policy
              .Combine(options.DefaultPolicy)
              .RequireRole("LaundryStore")
              .Build());
        });

        builder.Services.AddAutoMapperServices();

        builder.Services.AddRouting(options =>
        {
            options.AppendTrailingSlash = false;
        });
        _ = builder.Services.AddSystemSetting(builder.Configuration.GetSection("SystemSetting").Get<SystemSettingModel>());
        builder.Services.Configure<DataProtectionTokenProviderOptions>(opt => opt.TokenLifespan = TimeSpan.FromMinutes(30));
        builder.Services.AddDI();
        builder.Services.PrintServiceAddedToConsole();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "SWD-Laundry-Backend v1");
                    options.RoutePrefix = "swagger/api/v1";
                });
            IdentityModelEventSource.ShowPII = true;
        }

        app.UseHttpsRedirection();
        app.UseSerilogRequestLogging();
        app.UseAuthentication();
        app.MapControllers();
        app.UseRouting();
        //app.UseIdentityServer();
        app.UseAuthorization();
        app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

        app.Run();
    }
}

public class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object value)
    {
        // Slugify value
        return value == null ? null : Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1-$2").ToLower();
    }
}

public static class StartupSystemSetting
{
    public static IServiceCollection AddSystemSetting(this IServiceCollection services, SystemSettingModel? systemSettingModel)
    {
        SystemSettingModel.Instance = systemSettingModel ?? new SystemSettingModel();

        return services;
    }
}
