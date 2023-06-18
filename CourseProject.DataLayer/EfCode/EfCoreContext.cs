using Microsoft.EntityFrameworkCore;

namespace CourseProject.DataLayer.EfCode
{
    public class EfCoreContext : DbContext
    {
        public EfCoreContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}
