namespace App.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty ;
        public string Price { get; set; } = string.Empty;
    }
}
