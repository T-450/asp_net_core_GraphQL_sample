namespace ConferencePlanner.GraphQL.Imports
{
    using Data;
    using HotChocolate.Execution.Configuration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ImportRequestExecutorBuilderExtensions
    {
        public static IRequestExecutorBuilder EnsureDatabaseIsCreated(
            this IRequestExecutorBuilder builder)
        {
            return builder.ConfigureSchemaAsync(async (services, _, ct) =>
            {
                IDbContextFactory<ApplicationDbContext> factory =
                    services.GetRequiredService<IDbContextFactory<ApplicationDbContext>>();
                await using ApplicationDbContext dbContext = factory.CreateDbContext();

                if (await dbContext.Database.EnsureCreatedAsync(ct))
                {
                    var importer = new DataImporter();
                    await importer.LoadDataAsync(dbContext);
                }
            });
        }
    }
}
