using FarmCentralWeb.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FarmCentralWeb.Data;

public class FarmCentralWebContext : DbContext
{
    //code attribution  https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/#dbcontextoptions
    private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FCDB;Integrated Security=True;Connect Timeout=30;Encrypt=False";
    public FarmCentralWebContext(DbContextOptions<FarmCentralWebContext> options)
        : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
