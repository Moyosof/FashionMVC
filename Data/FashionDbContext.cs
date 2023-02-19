using FashionMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FashionMVC.Data
{
    public class FashionDbContext : DbContext
    {
        public FashionDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Fashion> Fashions { get; set; }
    }
}
