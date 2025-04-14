namespace lab27
{
    public class Sale
    {
        public required int SaleID { get; set; }
        public required int ProductID { get; set; }
        public required int SupplierID { get; set; }
        public required int CustomerID { get; set; }
        public required int QuantitySold { get; set; }
        public required decimal TotalAmount { get; set; }

        public required virtual Customer Customers { get; set; }
        public required virtual Product Products { get; set; }
        public required virtual Supplier Suppliers { get; set; }
    }
}
