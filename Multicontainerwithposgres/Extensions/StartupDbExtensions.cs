using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Multicontainerwithposgres.Data;

namespace Multicontainerwithposgres.Extensions
{
    public static class StartupDbExtensions
    {
        public static async void CreateDbIfNotExists(this IHost host)
        {

            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<Program>>();
            var teacherContext = services.GetRequiredService<TeacherDbcontext>();

            try
            {
                logger.LogInformation("enter CreateDbIfNotExists");
                var databsecrate = teacherContext.Database.GetService<IDatabaseCreator>() 
                    as RelationalDatabaseCreator;
                if (databsecrate != null)
                {
                    logger.LogInformation("enter databsecrate");
                    if (!databsecrate.CanConnect())
                    {

                        databsecrate.Create();
                        logger.LogInformation("enter databsecrate Create");
                    }
                    if (!databsecrate.HasTables())
                    {
                        databsecrate.CreateTables();
                        logger.LogInformation("enter databsecrate CreateTables");
                    }

                    DBInitializerSeedData.InitializeDatabase(teacherContext);
                    logger.LogInformation("enter databsecrate InitializeDatabase");
                }

                }
            catch (Exception ex)
            {

                logger.LogError($"migration issue {ex.Message}");
            }
        }
    }
}
