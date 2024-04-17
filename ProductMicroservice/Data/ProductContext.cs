using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Models;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;
namespace ProductMicroservice.Data;

public class ProductContext: DbContext
{
    private readonly IConfiguration Configuration;
    public DbSet<Product> Products { get; set; }
    public ProductContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMongoDB(Configuration["MongoConnection:ConnectionString"] ?? string.Empty,
            Configuration["MongoConnection:Database"] ?? string.Empty);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().ToCollection("products");
    }
}