namespace GerandoRelactorioComFastReport.Models
{
    public class Product
    {
        public int ProductId { get; set; } // não nulo
        public string? ProductName { get; set; } // não nulo
        public int SupplierId { get; set; }
        public int CategoryID { get; set; }
        public Int16 QuantitityPerUbit { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16 UnitsInStoque { get; set; }
        public Int16 UnitsOnOrder { get; set; }
        public Int16 ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public Category? Category { get; set; }
    }
}
