using Microsoft.EntityFrameworkCore;

namespace ZooManager.Api.Extensions
{
    public static class ApplicationExtensions
    {

        /// <summary>
        /// Применить все существующие миграции
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static WebApplication ApplyMigrations(this WebApplication app)
        {
            var scopeFactory = app.Services.GetService<IServiceScopeFactory>();
            using var scope = scopeFactory!.CreateScope();
            using var context = scope.ServiceProvider.GetService<ZooManagetDbContext>();
            // Применить все миграции
            context!.Database.Migrate();
            return app;
        }

    }
}
