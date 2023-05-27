using FarmCentralWeb.Data;
using FarmCentralWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace FarmCentralWeb.Helpers
{
    public class Farmers
    {
        private FarmCentralDBContext context;

        public Farmers(FarmCentralDBContext dbContext)
        {
            context = dbContext;
        }

        public List<Farmer> GetAll()
        {
            return context.Farmers.ToList();
        }
    }
}