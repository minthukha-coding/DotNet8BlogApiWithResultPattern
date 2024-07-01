namespace DotNet8.BlogApiWithResultPattern;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<BlogModel> Blogs { get; set; }
}
