using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FarmCentralWeb.Areas.Identity.Data;

// Add profile data for application users by adding properties to the FarmCentralWebUser class

//code attribution https://learn.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application
public class FarmCentralWebUser : IdentityUser
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}



