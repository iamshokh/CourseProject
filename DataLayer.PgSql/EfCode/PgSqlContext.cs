﻿using CourseProject.DataLayer.EfCode;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.DataLayer.PgSql.EfCode
{
    public partial class PgSqlContext : EfCoreContext
    {
        public PgSqlContext(DbContextOptions<PgSqlContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
