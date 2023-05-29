using FarmCentralWeb.BackEnd;
using FarmCentralWeb.Data;
using FarmCentralWeb.Helpers;
using FarmCentralWeb.Models;
using FarmCentralWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Cryptography;

namespace FarmCentralWeb.Pages.Products
{
    public class IndexModel : PageModel
    {
        //list of Products and their farmers
        public List<Product> products = new();
        //store error and success messages
        public string errorMessage = "";
        public string successMessage = "";        
        public string farmer_name = "";
        public string product_type = "";
        //creating a product view model object
        public ProductViewModel product_model = new();
        //db context object
        FarmCentralDBContext context = new();

        public void OnGet()
        {
            try
            {
                Helpers.Farmers farmers_helper = new(context);
                //retrieving data from the farmer table
                var farmerData = farmers_helper.GetAll();

                Helpers.Products products_helper = new(context);
                //retrieving data from the farmer table
                var productData = products_helper.GetAll();

                //products list
                var products = new List<Product>();

                //list to store product type's
                product_model.ProductTypeSelectList = new();


                List<string> types = new();
                foreach (Models.Product product in productData)
                {
                    product_model.ProductTypeSelectList.Add(new SelectListItem { Text = "PRODUCT TYPE: ", Value = product.Type });
                    types.Add(product.Type);
                }                

                if (types.Count == 0 || types.Equals("Select A Product Type"))
                {
                    errorMessage = "Select The Product Type To Filter Search!";
                    return;
                }
                else
                {
                    product_type = Request.Form["product_type"];
                }

                try
                {
                    var service = new FCServices();                    
                    var prods = service.GetProductsForAFarmer(farmer_name);

                    foreach (var product in prods)
                    {
                        Product Product = new ();

                        Product.Id = product.Id;
                        Product.Name = product.Name;
                        Product.DateSupplied = product.DateSupplied;
                        Product.Quantity = product.Quantity;
                        Product.Type = product.Type;
                        Product.FarmerName = product.Name.ToUpper();

                        //adding the object to the products list
                        products.Add(Product);
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
