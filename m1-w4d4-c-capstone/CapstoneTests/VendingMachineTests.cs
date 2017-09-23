using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestMethod]
        public void AddMoneyTest()
        {
            VendingMachine testObject = new VendingMachine();
            testObject.AddMoney(5);
            Assert.AreEqual(5.00M, testObject.Balance);
            testObject.AddMoney(5);
            Assert.AreEqual(10.00M, testObject.Balance);
        }

        [TestMethod]
        public void PurchaseTest()
        {
            VendingMachine testObject = new VendingMachine();

            testObject.AddMoney(5);
            testObject.Purchase("A1");
            Item itemtest = testObject.ItemList.Find(x => x.Slot.Contains("A1"));
            Assert.AreEqual(4, itemtest.Quantity);
            Assert.AreEqual(1.95M, testObject.Balance);
            Assert.AreEqual(3.05M, itemtest.Price);
            testObject.AddMoney(5);
            Assert.AreEqual("Crunch Crunch Yum!", testObject.Purchase("A1"));

            testObject.AddMoney(5);
            testObject.Purchase("C1");
            Item itemtest2 = testObject.ItemList.Find(x => x.Slot.Contains("C1"));
            Assert.AreEqual(4, itemtest2.Quantity);
            Assert.AreEqual(7.65M, testObject.Balance);
            Assert.AreEqual(1.25M, itemtest2.Price);
            Assert.AreEqual("Glug Glug, Yum!", testObject.Purchase("C1"));

            Assert.AreEqual("Sorry, no item with that number exists.", testObject.Purchase("A8"));

            testObject.Change();
            Assert.AreEqual("Sorry, your balance is too low to purchase that item.", testObject.Purchase("A1"));

            testObject.AddMoney(50);
            testObject.Purchase("A1");
            testObject.Purchase("A1");
            testObject.Purchase("A1");
            testObject.Purchase("A1");
            testObject.Purchase("A1");
            Assert.AreEqual("Sorry, that item is sold out.", testObject.Purchase("A1"));
        }

        [TestMethod]
        public void MakeChangeTest()
        {
            VendingMachine testObject = new VendingMachine();

            testObject.AddMoney(20);
            testObject.Purchase("A1");
            Assert.AreEqual(16.95M, testObject.Change());
            Assert.AreEqual(67, testObject.Quarters);
            Assert.AreEqual(2, testObject.Dimes);
            Assert.AreEqual(0, testObject.Nickels);

        }

        [TestMethod]
        public void QuantityTest()
        {
            VendingMachine testObject = new VendingMachine();
            testObject.AddMoney(20);
            testObject.Purchase("A1");
            testObject.Purchase("B2");
            testObject.Purchase("C1");
            testObject.Purchase("C1");
            foreach (Item product in testObject.ItemList)
            {
                if (product.Slot == "A2")
                {
                    Assert.AreEqual("5", testObject.Quantity(product));
                }
                if (product.Slot == "A1")
                {
                    Assert.AreEqual("4", testObject.Quantity(product));
                }
                if (product.Slot == "B2")
                {
                    Assert.AreEqual("4", testObject.Quantity(product));
                }
                if (product.Slot == "C1")
                {
                    Assert.AreEqual("3", testObject.Quantity(product));
                }
            }

        }

    }
}
