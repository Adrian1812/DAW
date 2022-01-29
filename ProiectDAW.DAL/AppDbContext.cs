using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProiectDAW.DAL.Entities;

namespace ProiectDAW.DAL
{
    public class AppDbContext : IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {

        public AppDbContext(DbContextOptions options) : base(options){ }

        public DbSet<SessionToken> SessionTokens { get; set; }



        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Dealer> Dealers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to One
            modelBuilder.Entity<Dealer>()
                .HasOne(adr => adr.Address)
                .WithOne(a => a.Dealer);

            //One to Many
            modelBuilder.Entity<Dealer>()
                .HasMany(p => p.Products)
                .WithOne(a => a.Dealer);

            // Many to Many
            modelBuilder.Entity<Order>()
                .HasOne(ord => ord.Client)
                .WithMany(cl => cl.Orders)
                .HasForeignKey(ord => ord.ClientId);

            modelBuilder.Entity<Order>()
                .HasOne(ord => ord.Product)
                .WithMany(prd => prd.Orders)
                .HasForeignKey(ord => ord.ProductId);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId });

                ur.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId);
                ur.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);
            });
        } 
    }
}
