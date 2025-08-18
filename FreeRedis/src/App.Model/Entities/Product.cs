namespace App.Model.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty ;
        public string Price { get; set; } = string.Empty;

    }
}
