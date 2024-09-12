namespace CS047_ASP.NET_CORE_4.Services
{
    public class ProductNames
    {
        private List<string> names {  get; set; }
        public ProductNames() { 
            names = new List<string>()
            {
                "Iphone 8",
                "Samsung A10",
                "Nokia Lumia"
            };
        }
        public List<string> GetNames() => names;
    }
}
