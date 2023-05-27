namespace FarmCentralWeb.Models
{
    public class Farmer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<Product> Products { get; set; }
    }
}
