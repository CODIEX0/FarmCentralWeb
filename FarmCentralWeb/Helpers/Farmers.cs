using FarmCentralWeb.Data;
using FarmCentralWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace FarmCentralWeb.Helpers
{
    //code attribution https://learn.microsoft.com/en-us/aspnet/web-api/overview/security/authentication-and-authorization-in-aspnet-web-api
    public class Farmers
    {
        private FarmCentralDBContext dbContext;

        public Farmers(FarmCentralDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Farmer> GetAll()
        {           

            return dbContext.Farmers.ToList();
        }
    }
}