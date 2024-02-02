using Microsoft.EntityFrameworkCore;
using TestTest.Configurations;

namespace TestTest.Entities;

public class MyDbContext : DbContext
{
    public DbSet<Person> Person { get; set; }
    public DbSet<Connections> Connections { get; set; }
    public DbSet<MailPassword> MailPassword { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        optionsBuilder.UseSqlServer(PathHelper.PathHelper.DbPath);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PersonConfiguration());
    }
}