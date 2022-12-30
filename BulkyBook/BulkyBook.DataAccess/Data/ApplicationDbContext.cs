using BulkyBook.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; }

        public DbSet<Product> Products { get; set; }

    }
}
