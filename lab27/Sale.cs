namespace lab27
{
    public class Sale
    {
        public int SaleID { get; set; }
        public int ProductID { get; set; }
        public int SupplierID { get; set; }
        public int CustomerID { get; set; }
        public int QuantitySold { get; set; }
        public decimal TotalAmount { get; set; }


        public virtual Customer Customers { get; set; }
        public virtual Product Products { get; set; }
        public virtual Supplier Suppliers { get; set; }
    }
}
