using Microsoft.EntityFrameworkCore;

namespace LibraryInventory.EntityDB
{
    public static class MigrationManager
    {
        public static WebApplication MigrateDatabase(this WebApplication webApp)
        {
            using (var scope = webApp.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                    }
                    catch (Exception)
                    {
                        //Log errors TODO
                        throw;
                    }
                }
            }
            return webApp;
        }
    }
}
