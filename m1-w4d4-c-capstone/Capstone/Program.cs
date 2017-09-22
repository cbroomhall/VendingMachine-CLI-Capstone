using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
