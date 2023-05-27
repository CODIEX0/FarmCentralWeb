using System.Data.Entity;
using FarmCentralWeb.Models;

namespace FarmCentralWeb.Data
{
    public class FarmCentralDBContext : DbContext
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FCDB;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public FarmCentralDBContext() : base(connectionString)
        {

        }

        public DbSet<Product> Products { get; set; } 
        public DbSet<Farmer> Farmers { get; set; } 
        public DbSet<Employee> Employees { get; set; } 
    }
}
