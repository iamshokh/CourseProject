using CourseProject.BizLogicLayer.AccountServices;
using CourseProject.BizLogicLayer.CollectionServices;
using CourseProject.BizLogicLayer.ItemServices;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICollectionsService, CollectionsService>();
            services.AddScoped<IItemService, ItemService>();
        }
    }
}
