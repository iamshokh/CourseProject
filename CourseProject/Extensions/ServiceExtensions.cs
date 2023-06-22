using CourseProject.BizLogicLayer.AccountServices;
using CourseProject.BizLogicLayer.CollectionServices;
using CourseProject.DataLayer.EfCode;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICollectionsService, CollectionsService>();
        }
    }
}
