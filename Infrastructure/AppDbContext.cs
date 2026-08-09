using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace AspNetCoreWebApiSandbox;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<Product> Products { get; set; }
}