using FarmCentralWeb.BackEnd;
using FarmCentralWeb.Models;
using FarmCentralWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmCentralWeb.Pages.Employee
{
    public class CreateModel : PageModel
    {
        //farmer object
        public Models.Employee employee = new();
        //store error and success messages
        public string errorMessage = "";
        public string successMessage = "";
        public void OnSet()
        {
            //if any text box is empty, than populate the error message with the error
            if (employee.UserName.Length == 0 || employee.Password.Length == 0)
            {
                errorMessage = "All the fields are required!";
                return;
            }
            //retrieve values from the form and store to the properties
            employee.UserName = Request.Form["employee_name"];
            employee.Password = Request.Form["password"];

            try
            {
                var service = new FCServices();
                service.AddEmployee(employee.UserName, employee.Password);

                //emptying the textboxes and populating the success message
                employee.UserName = ""; employee.Password = "";
                successMessage = "New Employee Successfully Added!";
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
        }
    }
}
