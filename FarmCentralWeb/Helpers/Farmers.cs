using FarmCentralWeb.Data;
using FarmCentralWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace FarmCentralWeb.Helpers
{
    public class Farmers
    {
        private FarmCentralDBContext dbContext;

        public Farmers(FarmCentralDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Farmer> GetAll()
        {           

            return dbContext.Set<Farmer>().ToList();
        }
    }
}