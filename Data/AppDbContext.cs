// dotnet add package Microsoft.EntityFrameworkCore"lazem"
using Microsoft.EntityFrameworkCore;

using Models;

namespace Data;

public class AppdbContext: DbContext
{
    public AppdbContext(DbContextOptions<AppdbContext> options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
}
