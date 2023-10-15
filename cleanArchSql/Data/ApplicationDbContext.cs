using cleanArchSql.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace cleanArchSql.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<FormData> FormDatas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
/*using cleanArchSql.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace cleanArchSql.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<FormData> FormDatas { get; set; }
        public DbSet<AssignedUser> AssignedUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

    }
}*/
