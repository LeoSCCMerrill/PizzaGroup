namespace PizzaGroup.Models
{
    public class Pizza
    {
        public int PizzaID { get; set; } //PK

        public string PizzaName { get; set; }

        public int PizzaPrice { get; set; }

        public string PizzaType { get; set; }

        public string PizzaSize { get; set; }

        public Pizza (int pizzaID, string pizzaName, int pizzaPrice, string pizzaType, string pizzaSize)
        {
            PizzaID = pizzaID;
            PizzaName = pizzaName;
            PizzaPrice = pizzaPrice;
            PizzaType = pizzaType;
            PizzaSize = pizzaSize;
        }

    }
}
