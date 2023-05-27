using Microsoft.AspNetCore.Mvc.Rendering;

namespace FarmCentralWeb.ViewModels
{
    public class FarmerViewModel
    {
        //display property to carry data to the create client view select (combo box)

        public List<SelectListItem> FarmerNameSelectList { set; get; } = null!;
        public string SelectedFarmerName { get; set; } = null!;
    }
}
