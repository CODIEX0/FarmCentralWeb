using FarmCentralWeb.BackEnd;
using FarmCentralWeb.Data;
using FarmCentralWeb.Helpers;
using FarmCentralWeb.Models;
using FarmCentralWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography;

namespace FarmCentralWeb.Pages.Inventory
{
    public class IndexModel : PageModel
    {
        //list of Products and their farmers
        public List<Product> products = new();
        //store error and success messages
        public string errorMessage = "";
        public string successMessage = "";
        public Product Products;
        public string farmer_name = "";
        //creating view model object
        public FarmerViewModel model = new();
        //db context object
        FarmCentralDBContext context = new();

        public void OnGet()
        {
            try
            {
                Helpers.Farmers farmers = new(context);
                //retrieving data from the farmer table
                var farmerData = farmers.GetAll();

                //list to store farmer name's
                model.FarmerNameSelectList = new();
                List<string> names = new();
                //displaying data to the select list
                foreach (Farmer farmer in farmerData)
                {
                    model.FarmerNameSelectList.Add(new SelectListItem { Text = "FARMER NAME: ", Value = farmer.Name });
                    names.Add(farmer.Name);
                } 

                //if any text box is empty, than populate the error message with the error
                if (names.Count == 0 )
                {
                    errorMessage = "Enter The Farmer's Name To Search!";
                    return;
                }
                else
                {
                    farmer_name = Request.Form["farmer_name"];
                }

                try
                {
                    var service = new FCServices();                    
                    var prods = service.GetProductsForAFarmer(farmer_name);

                    foreach (var product in prods)
                    {
                        Products = new();

                        Products.Id = product.Id;
                        Products.Name = product.Name;
                        Products.DateSupplied = product.DateSupplied;
                        Products.Quantity = product.Quantity;
                        Products.Type = product.Type;
                        Products.FarmerName = product.Name.ToUpper();

                        //adding the object to  list
                        products.Add(Products);
                    }
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                    return;
                }   
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateSupplied { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public string FarmerName { get; set; }
    }
}
