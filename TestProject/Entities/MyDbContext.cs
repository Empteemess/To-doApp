using Microsoft.EntityFrameworkCore;
using TestProject.Configurations;
namespace TestProject.Entities;

public class MyDbContext : DbContext
{
    public DbSet<Person> Person { get; set; }
    public DbSet<Number> Number { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Path);
        optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PersonConfiguration());
    }

    private string Path =
        @"Data Source=RAZER\SQLEXPRESS;Initial Catalog = RiderTest;Integrated Security = True;MultipleActiveResultSets=True;Encrypt=false";
}