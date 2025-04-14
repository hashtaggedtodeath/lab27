namespace lab27
{
    public class Product
    {
        public required int ProductID { get; set; }
        public required string Name { get; set; }
        public required string Unit { get; set; }
        public required int Quantity { get; set; }
        public required decimal PurchasePrice { get; set; }
        public required decimal SellingPrice { get; set; }
    }
}
