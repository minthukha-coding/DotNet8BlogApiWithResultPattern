using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace DotNet8BlogApiWithResultPattern
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<BlogModel> Blogs { get; set; }
    }
}
