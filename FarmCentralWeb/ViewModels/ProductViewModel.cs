using Microsoft.AspNetCore.Mvc.Rendering;

namespace FarmCentralWeb.ViewModels
{
    public class ProductViewModel
    {
        //display property to carry data to the create client view select (combo box)

        public List<SelectListItem> ProductTypeSelectList { set; get; } = null!;
        public string SelectedProductType { get; set; } = null!;

    }
}
