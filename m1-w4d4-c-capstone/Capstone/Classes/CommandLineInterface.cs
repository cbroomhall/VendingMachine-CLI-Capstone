using System;
using System.IO;

namespace Capstone
{
    public class CommandLineInterface
    {
        VendingMachine myVendingMachine = new VendingMachine();

        public CommandLineInterface(VendingMachine myVendingMachine)
        {

        }

        public void Runner()
        {
            Console.WriteLine();
            Console.WriteLine("(1) Display Vending Items");
            Console.WriteLine();
            Console.WriteLine("(2) Purchase");
            Console.WriteLine();
            Console.WriteLine("(3) Exit Vending Machine");
            Console.WriteLine();
            Console.WriteLine("Please select 1, 2 or 3 and hit enter.");
            string mainSelection = Console.ReadLine();
            if (mainSelection != "1" && mainSelection != "2" && mainSelection != "3" && mainSelection != "4")
            {
                Console.WriteLine();
                Console.WriteLine("That's not a valid selection. Please hit enter and try again.");
                Console.ReadLine();
                Console.Clear();
                Runner();
            }
            Console.Clear();
            if (mainSelection == "1")
            {
                Console.WriteLine();
                Console.WriteLine("Item #" + "\t" + "  Item Name" + "\t\t" + "Price" + "\t" + "    Quantity");
                Console.WriteLine("-----------------------------------------------------------");
                foreach (Item product in myVendingMachine.ItemList)
                {
                    Console.Write(String.Format("{0, -10}", product.Slot) + (String.Format("{0, -22}", product.Name) + (String.Format("{0, -12}", product.Price.ToString("C2")))));
                    if (product.Quantity == 0)
                    {
                        Console.Write("SOLD OUT");
                    }
                    else
                    {
                        Console.Write(myVendingMachine.Quantity(product));
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine("Press enter to return to main menu.");
                Console.ReadLine();
                Console.Clear();
                Runner();
            }
            if (mainSelection == "2")
            {
                PurchaseMenu();
            }
            if (mainSelection == "3")
            {
                Environment.Exit(0);
            }
            if (mainSelection == "4")
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Sales_Report.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        Console.WriteLine(line);
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Enter (1) to return to main menu. To zero out the sales report, enter the reset password.");
                string reportInput = Console.ReadLine();
                if (reportInput == "1")
                {
                    Console.Clear();
                    Runner();
                }
                else if (reportInput == "javaisdead")
                {
                    Console.Clear();
                    Console.WriteLine();
                    File.Delete(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Sales_Report.txt");
                    using (StreamWriter sw = new StreamWriter(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d4-c-capstone\Capstone\bin\Debug\Sales_Report.txt"))
                    {
                        foreach (Item product in myVendingMachine.ItemList)
                        {
                            sw.WriteLine(product.Name + "|" + "0");
                        }
                        sw.WriteLine();
                        sw.WriteLine("**TOTAL SALES** " + "$0.00");
                    }
                    Console.WriteLine();
                    Console.WriteLine("The sales report has been successfully reset. Hit enter to return to the main menu.");
                    Console.ReadLine();
                    Console.Clear();
                    Runner();

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("That's not a valid selection. Hit enter to to return to the main menu.");
                    Console.ReadLine();
                    Console.Clear();
                    Runner();
                }
            }
        }
        public void PurchaseMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine();
            Console.WriteLine("(2) Select Product");
            Console.WriteLine();
            Console.WriteLine("(3) Finish Transaction");
            Console.WriteLine();
            Console.WriteLine("Current Money Provided: " + "$" + myVendingMachine.Balance);
            Console.WriteLine();
            Console.WriteLine("Please select 1, 2 or 3 and hit enter.");
            string purchaseSelection = Console.ReadLine();
            if (purchaseSelection != "1" && purchaseSelection != "2" && purchaseSelection != "3")
            {
                Console.WriteLine();
                Console.WriteLine("That's not a valid selection. Please hit enter and try again.");
                Console.ReadLine();
                Console.Clear();
                PurchaseMenu();
            }
            if (purchaseSelection == "1")
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("How much money would you like to feed the machine? Enter a whole dollar amount (e.g. $1, $2, $5, $10).");
                int amount;
                bool fedMoney = int.TryParse(Console.ReadLine(), out amount);
                if (fedMoney && amount > 0)
                {
                    myVendingMachine.AddMoney(amount);
                    Console.Clear();
                    PurchaseMenu();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("That's not a valid amount. Please hit enter and try again.");
                    Console.ReadLine();
                    PurchaseMenu();
                }
            }
            else if (purchaseSelection == "2")
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Which item would you like to purchase?");
                string itemNumber = Console.ReadLine().ToUpper();
                Console.WriteLine();
                Console.WriteLine(myVendingMachine.Purchase(itemNumber));
                Console.WriteLine();
                Console.WriteLine("Press enter to return to purchase menu.");
                Console.ReadLine();
                PurchaseMenu();
            }
            else if (purchaseSelection == "3")
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Your change is: " + myVendingMachine.Change().ToString("C2"));
                Console.WriteLine();
                Console.WriteLine("Change dispensed:");
                Console.WriteLine("Quarters: " + myVendingMachine.Quarters);
                Console.WriteLine("Dimes: " + myVendingMachine.Dimes);
                Console.WriteLine("Nickels: " + myVendingMachine.Nickels);
                Console.WriteLine();
                Console.WriteLine("Press enter to return to main menu.");
                Console.ReadLine();
                Console.Clear();
                Runner();
            }
            else
            {
                Console.Clear();
                PurchaseMenu();
            }
        }

    }
}





