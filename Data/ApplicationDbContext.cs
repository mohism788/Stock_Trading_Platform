using _1st_Project_Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace _1st_Project_Api.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {

        public ApplicationDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {



        }

        public DbSet<Stock> Stocks {get;set;}
        public DbSet <Comment> Comments {get;set;}
        public DbSet <Portfolio> Portfolios {get;set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Portfolio>(x => x.HasKey(p => new { p.AppUserId, p.StockId }));

            builder.Entity<Portfolio>()
                .HasOne(u => u.AppUser)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(u => u.AppUserId);
            
            
            builder.Entity<Portfolio>()
                .HasOne(u => u.Stock)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(u => u.StockId);



            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {

                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                
                new IdentityRole
                {

                    Name = "User",
                    NormalizedName = "User"
                },

            };
            builder.Entity<IdentityRole>().HasData(roles);
        }

    }
}
