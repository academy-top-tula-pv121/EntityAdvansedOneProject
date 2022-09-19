using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAdvansedOneProject
{
    internal class AppContext : DbContext
    {
        public DbSet<User> Users { set; get; } = null!;
        public DbSet<UserProfile> UserProfiles { set; get; } = null!;
        public DbSet<Company> Companies { set; get; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=UsersDb;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasOne(u => u.Profile)
                            .WithOne(p => p.User)
                            .HasForeignKey<UserProfile>(p => p.UserId);

            //modelBuilder.Entity<User>().ToTable("UsersInfo");
            //modelBuilder.Entity<UserProfile>().ToTable("UsersInfo");

        }
    }
}
