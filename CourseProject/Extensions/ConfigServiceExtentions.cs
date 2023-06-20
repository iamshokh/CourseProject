using CourseProject.WebApi;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigServiceExtentions
    {
        public static void ConfigureConfigs(this IServiceCollection services)
        {
            services.AddSingleton(AppSettings.Instance.Database);
            services.AddSingleton(AppSettings.Instance.Jwt);
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
