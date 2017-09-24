
namespace Capstone
{
    public class Item
    {
        private string slot;
        private string name;
        private decimal price;
        private int quantity;
        private int salesCount;


        public string Slot { get => slot;  }
        public string Name { get => name; }
        public decimal Price { get => price; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int SalesCount { get => salesCount; set => salesCount = value; }

        public Item(string slot, string name, decimal price)
        {
            this.slot = slot;
            this.name = name;
            this.price = price;
            quantity = 5;
            salesCount = 0;
        }
    }
}
