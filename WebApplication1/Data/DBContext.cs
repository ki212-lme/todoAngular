using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data;

public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
    }

    public DbSet<Todo> Todos { get; set; }
}