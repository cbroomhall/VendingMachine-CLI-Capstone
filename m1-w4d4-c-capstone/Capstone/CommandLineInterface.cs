using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone
{
    public class CommandLineInterface : VendingMachine
    {
        public VendingMachine myVendingMachine = new VendingMachine();
        string mainSelection;
        private bool purchaseMade = false;

        public bool PurchaseMade { get => purchaseMade; set => purchaseMade = value; }

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
            mainSelection = Console.ReadLine();      
            if(mainSelection!="1" && mainSelection !="2" && mainSelection != "3")
            {
                Console.WriteLine("That's not a valid selection. Please hit enter and try again.");
                Console.ReadLine();
                Console.Clear();
                Runner();
            }

            Console.Clear();
            Console.WriteLine();
            if (mainSelection == "1")
            {
                myVendingMachine.Display();
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
            if(mainSelection == "3")
            {
                Environment.Exit(0);
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
            string purchaseSelection = Console.ReadLine();
            if (purchaseSelection != "1" && purchaseSelection != "2" && purchaseSelection != "3")
            {
                Console.WriteLine("That's not a valid selection. Please hit enter and try again.");
                Console.ReadLine();
                Console.Clear();
                PurchaseMenu();
            }
            if (purchaseSelection == "1")
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("How much money would you like to feed the machine?");
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
                    Console.WriteLine("That's not a valid amount. Please hit enter and try again.");
                    Console.ReadLine();
                    PurchaseMenu();
                }


            }
            else if (purchaseSelection == "2")
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Which product would you like to purchase?");
                string itemNumber = Console.ReadLine();
                Console.WriteLine(myVendingMachine.Purchase(itemNumber));


                Console.WriteLine();
                Console.WriteLine( "Press enter to return to purchase menu.");
                Console.ReadLine();
                PurchaseMenu();
            }
            else if (purchaseSelection == "3")
            {
               
                Console.Clear();
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
        public CommandLineInterface(VendingMachine myVendingMachine)
        {

        }

    }
}




