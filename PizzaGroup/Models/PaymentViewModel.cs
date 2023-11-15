namespace PizzaGroup.Models
{
    public class PaymentViewModel
    {
        public decimal TotalPrice { get; set; }
        public decimal SalesTax { get; set; }
        public decimal ServiceIndustryTax { get; set; }
        public decimal TotalDue { get; set; } = 0;
    }
}
