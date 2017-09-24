using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace Capstone
{
    public class VendingMachine
    {
        private decimal balance = 0;
        private int quarters = 0;
        private int dimes = 0;
        private int nickels = 0;
        private decimal total = 0;
        private decimal salesReportTotal = 0;
        private List<Item> itemList = new List<Item>();

        public decimal Balance { get => balance; }
        public List<Item> ItemList { get => itemList; }
        public int Quarters { get => quarters; }
        public int Dimes { get => dimes; }
        public int Nickels { get => nickels; }

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
            if (itemNumber == "A1" | itemNumber == "A2" | itemNumber == "A3" | itemNumber == "A4" | itemNumber == "B1" | itemNumber == "B2" | itemNumber == "B3" | itemNumber == "B4" |
                itemNumber == "C1" | itemNumber == "C2" | itemNumber == "C3" | itemNumber == "C4" | itemNumber == "D1" | itemNumber == "D2" | itemNumber == "D3" | itemNumber == "D4")
            {
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
                                    myItem.SalesCount++;
                                    salesReportTotal += myItem.Price;
                                    int previousCountTotal = 0;
                                    decimal previousSalesTotal = 0;
                                    using (StreamWriter sw = new StreamWriter(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Log.txt", true))
                                    {
                                        sw.WriteLine(String.Format("{0,-20}", DateTime.UtcNow) + (String.Format("{0,-25}", " " + myItem.Name + " " + myItem.Slot) + (String.Format("{0,-14}", (balance + myItem.Price).ToString("C2")) + balance.ToString("C2"))));
                                    }
                                    using (StreamReader sr = new StreamReader(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Sales_Report.txt"))
                                    {
                                        using (StreamWriter sw = new StreamWriter(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Sales_Report_Swap.txt"))
                                        {
                                            while (!sr.EndOfStream)
                                            {
                                                string line = sr.ReadLine();
                                                if (line.Contains(myItem.Name))
                                                {
                                                    string[] items = line.Split('|');
                                                    previousCountTotal = Convert.ToInt32(items[1]);
                                                    sw.WriteLine(myItem.Name + "|" + (previousCountTotal+=1).ToString());
                                                }
                                                else if (line.Contains("**TOTAL SALES**"))
                                                {
                                                    string[] items = line.Split(' ');
                                                    previousSalesTotal = Decimal.Parse(items[2], NumberStyles.AllowCurrencySymbol | NumberStyles.Number);
                                                    sw.WriteLine("**TOTAL SALES** " + (previousSalesTotal + myItem.Price).ToString("C2"));
                                                }
                                                else
                                                {
                                                    sw.WriteLine(line);
                                                }
                                            }
                                        }
                                    }
                                    File.Delete(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Sales_Report.txt");
                                    File.Copy(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Sales_Report_Swap.txt", @"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Sales_Report.txt");
                                    Console.Clear();
                                    Console.WriteLine();
                                    return "Crunch Crunch Yum!";
                                }
                                else if (myItem.Slot.Contains("B"))
                                {
                                    balance -= myItem.Price;
                                    myItem.Quantity -= 1;
                                    myItem.SalesCount++;
                                    salesReportTotal += myItem.Price;
                                    int previousCountTotal = 0;
                                    decimal previousSalesTotal = 0;
                                    using (StreamWriter sw = new StreamWriter(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Log.txt", true))
                                    {
                                        sw.WriteLine(String.Format("{0,-20}", DateTime.UtcNow) + (String.Format("{0,-25}", " " + myItem.Name + " " + myItem.Slot) + (String.Format("{0,-14}", (balance + myItem.Price).ToString("C2")) + balance.ToString("C2"))));
                                    }
                                    using (StreamReader sr = new StreamReader(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Sales_Report.txt"))
                                    {
                                        using (StreamWriter sw = new StreamWriter(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Sales_Report_Swap.txt"))
                                        {
                                            while (!sr.EndOfStream)
                                            {
                                                string line = sr.ReadLine();
                                                if (line.Contains(myItem.Name))
                                                {
                                                    string[] items = line.Split('|');
                                                    previousCountTotal = Convert.ToInt32(items[1]);
                                                    sw.WriteLine(myItem.Name + "|" + (previousCountTotal += 1).ToString());
                                                }
                                                else if (line.Contains("**TOTAL SALES**"))
                                                {
                                                    string[] items = line.Split(' ');
                                                    previousSalesTotal = Decimal.Parse(items[2], NumberStyles.AllowCurrencySymbol | NumberStyles.Number);
                                                    sw.WriteLine("**TOTAL SALES** " + (previousSalesTotal + myItem.Price).ToString("C2"));
                                                }
                                                else
                                                {
                                                    sw.WriteLine(line);
                                                }
                                            }
                                        }
                                    }
                                    File.Delete(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Sales_Report.txt");
                                    File.Copy(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Sales_Report_Swap.txt", @"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Sales_Report.txt");
                                    Console.Clear();
                                    Console.WriteLine();
                                    return "Munch Munch, Yum!";
                                }
                                else if (myItem.Slot.Contains("C"))
                                {
                                    balance -= myItem.Price;
                                    myItem.Quantity -= 1;
                                    myItem.SalesCount++;
                                    salesReportTotal += myItem.Price;
                                    int previousCountTotal = 0;
                                    decimal previousSalesTotal = 0;
                                    using (StreamWriter sw = new StreamWriter(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Log.txt", true))
                                    {
                                        sw.WriteLine(String.Format("{0,-20}", DateTime.UtcNow) + (String.Format("{0,-25}", " " + myItem.Name + " " + myItem.Slot) + (String.Format("{0,-14}", (balance + myItem.Price).ToString("C2")) + balance.ToString("C2"))));
                                    }
                                    using (StreamReader sr = new StreamReader(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Sales_Report.txt"))
                                    {
                                        using (StreamWriter sw = new StreamWriter(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Sales_Report_Swap.txt"))
                                        {
                                            while (!sr.EndOfStream)
                                            {
                                                string line = sr.ReadLine();
                                                if (line.Contains(myItem.Name))
                                                {
                                                    string[] items = line.Split('|');
                                                    previousCountTotal = Convert.ToInt32(items[1]);
                                                    sw.WriteLine(myItem.Name + "|" + (previousCountTotal += 1).ToString());
                                                }
                                                else if (line.Contains("**TOTAL SALES**"))
                                                {
                                                    string[] items = line.Split(' ');
                                                    previousSalesTotal = Decimal.Parse(items[2], NumberStyles.AllowCurrencySymbol | NumberStyles.Number);
                                                    sw.WriteLine("**TOTAL SALES** " + (previousSalesTotal + myItem.Price).ToString("C2"));
                                                }
                                                else
                                                {
                                                    sw.WriteLine(line);
                                                }
                                            }
                                        }
                                    }
                                    File.Delete(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Sales_Report.txt");
                                    File.Copy(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Sales_Report_Swap.txt", @"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Sales_Report.txt");
                                    Console.Clear();
                                    Console.WriteLine();
                                    return "Glug Glug, Yum!";
                                }
                                else
                                {
                                    balance -= myItem.Price;
                                    myItem.Quantity -= 1;
                                    myItem.SalesCount++;
                                    salesReportTotal += myItem.Price;
                                    int previousCountTotal = 0;
                                    decimal previousSalesTotal = 0;
                                    using (StreamWriter sw = new StreamWriter(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Log.txt", true))
                                    {
                                        sw.WriteLine(String.Format("{0,-20}", DateTime.UtcNow) + (String.Format("{0,-25}", " " + myItem.Name + " " + myItem.Slot) + (String.Format("{0,-14}", (balance + myItem.Price).ToString("C2")) + balance.ToString("C2"))));
                                    }
                                    using (StreamReader sr = new StreamReader(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Sales_Report.txt"))
                                    {
                                        using (StreamWriter sw = new StreamWriter(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Sales_Report_Swap.txt"))
                                        {
                                            while (!sr.EndOfStream)
                                            {
                                                string line = sr.ReadLine();
                                                if (line.Contains(myItem.Name))
                                                {
                                                    string[] items = line.Split('|');
                                                    previousCountTotal = Convert.ToInt32(items[1]);
                                                    sw.WriteLine(myItem.Name + "|" + (previousCountTotal += 1).ToString());
                                                }
                                                else if (line.Contains("**TOTAL SALES**"))
                                                {
                                                    string[] items = line.Split(' ');
                                                    previousSalesTotal = Decimal.Parse(items[2], NumberStyles.AllowCurrencySymbol | NumberStyles.Number);
                                                    sw.WriteLine("**TOTAL SALES** " + (previousSalesTotal + myItem.Price).ToString("C2"));
                                                }
                                                else
                                                {
                                                    sw.WriteLine(line);
                                                }
                                            }
                                        }
                                    }
                                    File.Delete(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Sales_Report.txt");
                                    File.Copy(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Sales_Report_Swap.txt", @"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Sales_Report.txt");
                                    Console.Clear();
                                    Console.WriteLine();
                                    return "Chew Chew, Yum!";
                                }
                            }
                            else
                            {
                                return "Sorry, that item is sold out.";
                            }
                        }
                        else
                        {
                            return "Sorry, your balance is too low to purchase that item.";
                        }
                    }
                }
                return null;
            }
            else
            {
                return "Sorry, no item with that number exists.";
            }
        }
        public decimal Change()
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
        public string Quantity(Item product)
        {
            return product.Quantity.ToString();
        }      
    }
}





