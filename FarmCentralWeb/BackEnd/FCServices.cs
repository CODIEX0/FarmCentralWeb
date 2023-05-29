using FarmCentralWeb.Data;
using FarmCentralWeb.Models;
using System;
using System.Collections.Generic;

namespace FarmCentralWeb.BackEnd
{
    public class FCServices
    {
        // Method to retrieve products for a specific farmer from the database
        public List<Product> GetProductsForAFarmer(string farmerName)
        {
            List<Product> products = new List<Product>();

            using (var context = new FarmCentralDBContext())
            {
                try
                {
                    products = context.Products
                        .Where(p => p.FarmerName == farmerName)
                        .ToList();
                }
                catch (Exception ex)
                {
                    string errorMessage = ex.Message;
                }
            }

            return products;
        }

        // Method to retrieve products with a specific product from the database
        public List<Product> GetProductsByType(string productType)
        {
            var filteredByProductType = new List<Product>();
            List<Product> products = new List<Product>();

            using (var context = new FarmCentralDBContext())
            {
                try
                {
                    // Filter by product type
                    filteredByProductType = products.Where(p => p.Type == productType).ToList();
                }
                catch (Exception ex)
                {
                    string errorMessage = ex.Message;
                }
            }
            return filteredByProductType;
        }

        public List<Product> GetProductsByDateRange(DateTime startDate, DateTime endDate)
        {
            var filteredByDateRange = new List<Product>();
            List<Product> products = new List<Product>();

            using (var context = new FarmCentralDBContext())
            {
                try
                {
                    // Filter by date range
                    filteredByDateRange = products.Where(p => p.DateSupplied >= startDate && p.DateSupplied <= endDate).ToList();
                }
                catch (Exception ex)
                {
                    string errorMessage = ex.Message;
                }
            }
            return filteredByDateRange;
        }

        // Method to add a farmer to the database
        public void AddFarmer(string name, string password)
        {
            using (var context = new FarmCentralDBContext())
            {
                var farmer = new Farmer
                {
                    Name = name,
                    Password = password,
                    Products = new List<Product>()
                };
               
                context.SaveChanges();
                context.Farmers.Add(farmer);
                context.SaveChanges();
            }
        }

        // Method to add a product to the database
        public void AddProduct(string name, DateTime dateSupplied, int quantity, string type, string farmerName)
        {
            using (var context = new FarmCentralDBContext())
            {
                var product = new Product
                {
                    Name = name,
                    DateSupplied = dateSupplied,
                    Quantity = quantity,
                    Type = type,
                    FarmerName = farmerName
                };

                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        // Method to add an employee to the database
        public void AddEmployee(string name, string password)
        {
            using (var context = new FarmCentralDBContext())
            {
                var employee = new Employee
                {
                    UserName = name,
                    Password = password
                };

                context.Employees.Add(employee);
                context.SaveChanges();
            }
        }
    }
}