using FarmCentralWeb.BackEnd;
using FarmCentralWeb.Data;
using FarmCentralWeb.Helpers;
using FarmCentralWeb.Models;
using FarmCentralWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.LibraryModel;

namespace FarmCentralWeb.Pages.Inventory
{
    public class CreateModel : PageModel
    {
        //product object
        public Product product = new();
        //store error and success messages
        public string errorMessage = "";
        public string successMessage = "";
        //creating view model object
        public FarmerViewModel model = new();
        //db context object
        FarmCentralDBContext context = new();

        public void OnGet()
        {
            Helpers.Farmers farmers = new(context);
            //retrieving data from the farmer table
            var farmerData = farmers.GetAll();
            //list to store farmer name's
            model.FarmerNameSelectList = new();

            //displaying data to the select list
            foreach (var farmer in farmerData)
            {
                model.FarmerNameSelectList.Add(new SelectListItem { Text = "FARMER NAME: ", Value = farmer.Name });
            }
        }

        public void OnSet()
        {
            //if any text box is empty, than populate the error message with the error
            if (product.Name.Length == 0 || product.DateSupplied.Equals("01/01/0001") || product.Quantity == 0 ||
                product.Type.Length == 0 || product.FarmerName.Equals("Select A Name"))
            {
                errorMessage = "All the fields are required!";
                return;
            }
            //retrieve values from the form and store to the properties
            product.Name = Request.Form["product_name"];
            product.DateSupplied = DateTime.Parse(Request.Form["date_supplied"]);
            product.Quantity = int.Parse(Request.Form["quantity"]);
            product.Type = Request.Form["product_type"];
            product.FarmerName = Request.Form["farmer_name"];

            try
            {
                var service = new FCServices();
                service.AddProduct(product.Name, product.DateSupplied, product.Quantity, product.Type, product.FarmerName);

                //emptying the textboxes and populating the success message
                product.Name = ""; product.DateSupplied = DateTime.MinValue; product.Quantity = 0; product.Type = ""; product.FarmerName = "";
                successMessage = "New Product Successfully Added!";
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
        }
    }
}
