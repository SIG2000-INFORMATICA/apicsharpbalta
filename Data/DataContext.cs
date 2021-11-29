using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shop.Models;

namespace Shop.Data
{
    public class DataContext : DbContext
    {

    private readonly IConfigurationRoot _configurationFile;
    private readonly string _connectionString;    

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        _configurationFile = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json")
                                    .Build(); 
        _connectionString = _configurationFile.GetConnectionString("BaseConnection");
        }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
            optionsBuilder.UseNpgsql(_connectionString);
            base.OnConfiguring(optionsBuilder);
    }

        public DbSet<Product> Products { get; set; }  = null;
        public DbSet<Category> Categories { get; set; }  = null;
        public DbSet<User> Users { get; set; } = null;
       
    }
}