using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Context : IdentityDbContext<IdentityUser>
    {
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> Details { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

    }
}
