using Grpc.Net.Client;
using GrpcCalculatorServiceLocal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    internal class GrpcCalculatorClientConsole
    {
        public GrpcCalculatorClientConsole() 
        {
            Dothings();
            Console.ReadLine();
        }

        static async void Dothings()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7271/");
            var calculatorClient = new GrpcCalculatorServiceLocal.Calculator.CalculatorClient(channel);
            var clientRequested = new Nums { N1 = 1, N2 = 2 };
            calculatorClient.Add(clientRequested);
            var result = calculatorClient.Add(clientRequested);

            Console.WriteLine("1 + 2 = " + result.Result.ToString());
        }
    }
}