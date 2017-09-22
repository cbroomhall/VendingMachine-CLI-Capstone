using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    public class Item
    {

        private string slot;
        private string name;
        private decimal price;
        private int quantity;

        public string Slot { get => slot;  }
        public string Name { get => name; }
        public decimal Price { get => price; }
        public int Quantity { get => quantity; set => quantity = value; }

        public Item(string slot, string name, decimal price)
        {
            this.slot = slot;
            this.name = name;
            this.price = price;
            quantity = 5;
        }
    }
}
