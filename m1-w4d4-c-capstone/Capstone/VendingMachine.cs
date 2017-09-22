using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone
{
    public class VendingMachine
    {
        protected decimal balance = 0;
        int quarters = 0;
        int dimes = 0;
        int nickels = 0;
        decimal total = 0;
        private List<Item> itemList = new List<Item>();

        public decimal Balance { get => balance; set => balance = value; }
        public List<Item> ItemList { get => itemList; }
        public int Quarters { get => quarters; }
        public int Dimes { get => dimes; }
        public int Nickels { get => nickels; }
        public decimal Total { get => total; }

        public VendingMachine()
        {
            using (StreamReader sr = new StreamReader(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\etc\vendingmachine.csv"))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] items = line.Split('|');
                    ItemList.Add(new Item(items[0], items[1], Convert.ToDecimal(items[2])));
                }


            }
        }
        public void AddMoney(int feedmoney)
        {

            balance += feedmoney;
            using (StreamWriter sw = new StreamWriter(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Log.txt", true))
            {
                sw.WriteLine(String.Format("{0,-20}", DateTime.UtcNow) + (String.Format("{0,-25}", " FEED MONEY:") + (String.Format("{0,-14}", feedmoney.ToString("C2")) + balance.ToString("C2"))));
            }
        }
        public string Purchase(string itemNumber)
        {
            if (itemNumber != "A1" && itemNumber != "A2" && itemNumber != "A3" && itemNumber != "A4" && itemNumber != "B1" && itemNumber != "B2" && itemNumber != "B3" && itemNumber != "B4" &&
                itemNumber != "C1" && itemNumber != "C2" && itemNumber != "C3" && itemNumber != "C4" && itemNumber != "D1" && itemNumber != "D2" && itemNumber != "D3" && itemNumber != "D4")
            {          
                return "Sorry, no item with that number exists. Please hit enter to try again.";           
            }

            foreach (Item myItem in ItemList)
            {
                if (myItem.Slot == itemNumber)
                {
                    if (balance > myItem.Price)
                    {
                        if (myItem.Quantity > 0)
                        {
                            if (myItem.Slot.Contains("A"))
                            {
                                balance -= myItem.Price;
                                myItem.Quantity -= 1;
                                using (StreamWriter sw = new StreamWriter(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Log.txt", true))
                                {
                                    sw.WriteLine(String.Format("{0,-20}", DateTime.UtcNow) + (String.Format("{0,-25}", " " + myItem.Name + " " + myItem.Slot) + (String.Format("{0,-14}", (balance + myItem.Price).ToString("C2")) + balance.ToString("C2"))));
                                }
                                return "Crunch Crunch Yum!";

                            }
                            else if (myItem.Slot.Contains("B"))
                            {
                                balance -= myItem.Price;
                                myItem.Quantity -= 1;
                                using (StreamWriter sw = new StreamWriter(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Log.txt", true))
                                {
                                    sw.WriteLine(String.Format("{0,-20}", DateTime.UtcNow) + (String.Format("{0,-25}", " " + myItem.Name + " " + myItem.Slot) + (String.Format("{0,-14}", (balance + myItem.Price).ToString("C2")) + balance.ToString("C2"))));
                                }
                                return "Munch Munch, Yum!";

                            }
                            else if (myItem.Slot.Contains("C"))
                            {
                                balance -= myItem.Price;
                                myItem.Quantity -= 1;
                                using (StreamWriter sw = new StreamWriter(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Log.txt", true))
                                {
                                    sw.WriteLine(String.Format("{0,-20}", DateTime.UtcNow) + (String.Format("{0,-25}", " " + myItem.Name + " " + myItem.Slot) + (String.Format("{0,-14}", (balance + myItem.Price).ToString("C2")) + balance.ToString("C2"))));
                                }
                                return "Glug Glug, Yum!";

                            }
                            else
                            {
                                balance -= myItem.Price;
                                myItem.Quantity -= 1;
                                using (StreamWriter sw = new StreamWriter(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Log.txt", true))
                                {
                                    sw.WriteLine(String.Format("{0,-20}", DateTime.UtcNow) + (String.Format("{0,-25}", " " + myItem.Name + " " + myItem.Slot) + (String.Format("{0,-14}", (balance + myItem.Price).ToString("C2")) + balance.ToString("C2"))));
                                }
                                return "Chew Chew, Yum!";
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine();
                            return "Sorry, that item is sold out. Please hit enter and select another item.";
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine();
                        return "Sorry, your balance is too low to purchase that item. Please hit enter and select another item.";
                    }
                }
            }
            return "";
        }
        public virtual decimal Change()
        {
            while (balance > 0)
            {
                while (balance >= .25M)
                {
                    quarters++;
                    balance -= .25M;
                    total += .25M;
                }
                while (balance >= .10M)
                {
                    dimes++;
                    balance -= .10M;
                    total += .10M;
                }
                while (balance >= .05M)
                {
                    nickels++;
                    balance -= .05M;
                    total += .05M;
                }
                
            }
            using (StreamWriter sw = new StreamWriter(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Log.txt", true))
            {
                sw.WriteLine(String.Format("{0,-20}", DateTime.UtcNow) + (String.Format("{0,-25}", " GIVE CHANGE:") + (String.Format("{0,-14}", total.ToString("C2")) + balance.ToString("C2"))));
            }
            return total;
        }

        public void Display()
        {
            Console.WriteLine();
            Console.WriteLine("Product #" + "\t" + "Name" + "\t\t\t" + "Price" + "\t" + "  Quantity");
            Console.WriteLine("-----------------------------------------------------------");
            foreach (Item product in itemList)
            {
                Console.Write(String.Format("{0, -16}", product.Slot) + (String.Format("{0, -24}", product.Name) + (String.Format("{0, -10}", product.Price))));

                if (product.Quantity == 0)
                {
                    Console.Write("SOLD OUT");
                }
                else
                {
                    Console.Write(product.Quantity);
                }
                Console.WriteLine();
            }
        }
    }

}








