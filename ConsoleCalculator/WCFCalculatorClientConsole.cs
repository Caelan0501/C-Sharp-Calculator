using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    internal class WCFCalculatorClientConsole
    {
        public WCFCalculatorClientConsole() 
        {
            WCFCalculatorServiceLocal.WCFCalculatorServiceLocalClient client = new WCFCalculatorServiceLocal.WCFCalculatorServiceLocalClient();
            var result = client.AddAsync("1", "2");
            Console.WriteLine(result.AsyncState);
        }
    }
}
