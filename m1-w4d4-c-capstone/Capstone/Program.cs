
namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachine myVendingMachine = new VendingMachine();
            CommandLineInterface myCLI = new CommandLineInterface(myVendingMachine);
            myCLI.Runner();
        }
    }
}
