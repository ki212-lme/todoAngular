using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data;

public class DBContext : DbContext
{
    public DBContext() : base()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-K5E1FHP;Database=Tododb;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }

    public DbSet<Todo> Todos { get; set; }
}