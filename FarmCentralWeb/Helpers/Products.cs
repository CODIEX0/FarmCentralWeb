using FarmCentralWeb.Data;
using FarmCentralWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FarmCentralWeb.Helpers
{
    //code attribution https://learn.microsoft.com/en-us/aspnet/web-api/overview/security/authentication-and-authorization-in-aspnet-web-api
    public class Products
    {
        public static FarmCentralDBContext dbContext;

        public Products(FarmCentralDBContext dbContext)
        {
            Products.dbContext = dbContext;
        }

        public List<Product> GetAll()
        {
            return dbContext.Set<Product>().ToList();
        }
    }
}
