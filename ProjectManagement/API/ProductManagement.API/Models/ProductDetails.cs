namespace ProductManagement.API.Models
{
    public class ProductDetails
    {
        public required string ProductName { get; set; }
        public decimal Price { get; set; }
        public double? Discount { get; set; }
        public required string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
