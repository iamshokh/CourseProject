using CourseProject.DataLayer.EfClasses;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.DataLayer.EfCode
{
    public class EfCoreContext : DbContext
    {
        public EfCoreContext(DbContextOptions options)
            : base(options)
        {

        }

        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Collections> Collections { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
    }
}
