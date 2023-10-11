namespace PizzaGroup.Models
{
    public class Size
    {
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public int SizeInches { get; set; }
        public Decimal SizePriceMultiplier { get; set; }
    }
}
