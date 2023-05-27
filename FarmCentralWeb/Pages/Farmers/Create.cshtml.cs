using FarmCentralWeb.BackEnd;
using FarmCentralWeb.Models;
using FarmCentralWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmCentralWeb.Pages.Farmers
{
    public class CreateModel : PageModel
    {
        //farmer object
        public Farmer farmer = new();
        //store error and success messages
        public string errorMessage = "";
        public string successMessage = "";
        public void OnSet()
        {
            //if any text box is empty, than populate the error message with the error
            if (farmer.Name.Length == 0 || farmer.Password.Length == 0)
            {
                errorMessage = "All the fields are required!";
                return;
            }
            //retrieve values from the form and store to the properties
            farmer.Name = Request.Form["farmer_name"];
            farmer.Password = Request.Form["password"];

            try
            {
                var service = new FCServices();
                service.AddFarmer(farmer.Name, farmer.Password);

                //emptying the textboxes and populating the success message
                farmer.Name = ""; farmer.Password = "";
                successMessage = "New Farmer Successfully Added!";
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
        }
    }
}
