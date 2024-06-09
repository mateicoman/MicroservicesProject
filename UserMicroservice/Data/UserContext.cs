using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using ProductMicroservice.Models;
using UserMicroservice.Models;

namespace UserMicroservice.Data;

public class UserContext: DbContext
{
    private readonly IConfiguration Configuration;
    public DbSet<User> Users { get; set; }
    public UserContext(IConfiguration configuration)
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
        modelBuilder.Entity<User>().ToCollection("users");
    }
}