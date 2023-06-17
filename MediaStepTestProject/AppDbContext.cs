using MediaStepTestProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediaStepTestProject;

public class AppDbContext : DbContext
{
    public DbSet<CustomerProduct> CustomerProducts { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Shop> Shops { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasIndex(c => c.Email).IsUnique();
        modelBuilder.Entity<CustomerProduct>().HasKey(p => new { p.CustomerId, p.ProductId} );
        base.OnModelCreating(modelBuilder);
    }
}