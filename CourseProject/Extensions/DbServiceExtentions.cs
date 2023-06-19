using CourseProject.DataLayer.EfCode;
using CourseProject.DataLayer.PgSql.EfCode;
using CourseProject.WebApi;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DbServiceExtentions
    {
        public static void ConfigureDbServices(this IServiceCollection services)
        {
            services.AddDbContext<EfCoreContext, PgSqlContext>(options =>
                options.UseNpgsql(AppSettings.Instance.Database.PgSql.ConnectionString));
            //.AddInterceptors(new HintInterceptor()));
            services.AddScoped<DbContext>(x => x.GetService<EfCoreContext>());
        }
    }
}
