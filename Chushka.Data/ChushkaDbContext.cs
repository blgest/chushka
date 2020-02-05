using Chushka.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Chushka.Data
{
    public class ChushkaDbContext : IdentityDbContext<ChushkaUser, IdentityRole, string>
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public ChushkaDbContext(DbContextOptions<ChushkaDbContext> options)
            : base(options)
        {
        }
    }
}
