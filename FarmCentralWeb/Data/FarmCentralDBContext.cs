
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using FarmCentralWeb.Areas.Identity.Data;
using FarmCentralWeb.Models;

namespace FarmCentralWeb.Data
{
    //code attribution  https://learn.microsoft.com/en-us/training/modules/persist-data-ef-core/2-understanding-ef-core?0=1
    public class FarmCentralDBContext : DbContext
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FCDB;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public FarmCentralDBContext() : base(connectionString)
        {

        }

        public DbSet<Product> Products { get; set; } 
        public DbSet<Farmer> Farmers { get; set; } 
        public DbSet<Employee> Employees { get; set; }
        public DbSet<FarmCentralWebUser> FarmCentralWebUsers { get; set; }
        
    }
}
