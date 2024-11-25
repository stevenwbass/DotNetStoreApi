using StoreData.Managers;
using StoreData.Repositories.Db;
using StoreData;
using Microsoft.EntityFrameworkCore;
using StoreData.Models;

public static class ServiceCollectionExtensions {
    public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration) {
        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
        // managers
        services.AddScoped<IProductsManager, ProductsManager>();

        var storeConnectionString = configuration.GetConnectionString("store") ?? throw new ArgumentNullException("Configuration.ConnectionStrings.store");
        var debugDbContext = configuration.GetValue<bool>("DebugDbContext");
        services.AddDbContext<StoreDbContext>(
            dbContextOptionsBuilder => {
                dbContextOptionsBuilder.UseMySql(storeConnectionString, ServerVersion.AutoDetect(storeConnectionString));
                if (debugDbContext) {
                    dbContextOptionsBuilder.LogTo(Console.WriteLine, LogLevel.Information)
                        .EnableSensitiveDataLogging()
                        .EnableDetailedErrors();
                }
            });
    }
}