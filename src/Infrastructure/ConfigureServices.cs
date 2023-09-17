using SWD_Laundry_Backend.Application.Common.Interfaces;
using SWD_Laundry_Backend.Infrastructure.Files;
using SWD_Laundry_Backend.Infrastructure.Identity;
using SWD_Laundry_Backend.Infrastructure.Persistence;
using SWD_Laundry_Backend.Infrastructure.Persistence.Interceptors;
using SWD_Laundry_Backend.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using SWD_Laundry_Backend.Domain.IdentityModel;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("SWD_Laundry_BackendDb"));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        services
            .AddDefaultIdentity<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddIdentityServer()
            .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

        services.AddAuthentication()
            .AddIdentityServerJwt();

        //services.AddAuthorization(options =>
        //    options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator")));

        services.AddAuthorization(options =>
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
            options.AddPolicy("AdminOrStaff", policy => policy
        .Combine(options.DefaultPolicy)
        .RequireRole("Admin", "Staff")
        .Build());

        });

        return services;
    }
}
