using Microsoft.AspNetCore.Mvc.Rendering;

namespace FarmCentralWeb.ViewModels
{
    public class ProductViewModel
    {
        //display property to carry data to the create client view select (combo box)

        public List<SelectListItem> ProductSelectList { set; get; } = null!;
        public string SelectedProduct { get; set; } = null!;
    }
}
