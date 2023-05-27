using FarmCentralWeb.Data;
using FarmCentralWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FarmCentralWeb.Helpers
{
    public class Products
    {
        public static List<Product> listProducts = new();
        static FarmCentralDBContext context = new();

        public static List<Product> GetAll()
        {
            return listProducts = context.Products.ToList();
        }
    }
}
