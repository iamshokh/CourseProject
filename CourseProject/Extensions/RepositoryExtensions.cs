using CourseProject.DataLayer.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RepositoryExtensions
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
