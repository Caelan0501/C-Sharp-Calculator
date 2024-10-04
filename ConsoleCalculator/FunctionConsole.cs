using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Quic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class FunctionConsole
    {
        private const string info =
            "To use please input your Equation in the following format: {a} {operator} {b}" + "\n" +
            "ReadRecentHistory - Read the lastest History, Repeated use will backtrack further" + "\n" +
            "ReadAllHistory - Read All History from youngest to oldest" + "\n" +
            "Quit - End the program";

        public FunctionConsole()
        {
            Console.WriteLine("Functional Calculator Started");
            Console.WriteLine("For the List of Commands type Help");
            RunCalculator();
        }
        
        private void RunCalculator()
        {
            bool status = true;
            while (status)
            {
                string? input = Console.ReadLine();
                if (input == null) continue;
                input = input.ToUpper();
                switch (input)
                {
                    case "":
                        break;
                    case "HELP":
                        Console.WriteLine(info);
                        break;
                    case "GETALLHISTORY":
                        break;
                    case "GETRECENTHISTORY":
                        break;
                    case "RESUMEHISTORY":
                        Console.WriteLine("History Resumed");
                        break;
                    case "PAUSEHISTORY":
                        Console.WriteLine("History Paused");
                        break;
                    case "CLEARHISTORY":
                        Console.WriteLine("History Cleared");
                        break;
                    case "QUIT":
                        status = false;
                        break;
                    default:
                        double? result = Parse(input);
                        if (result != null) Console.WriteLine(result.ToString());
                        else Console.WriteLine("Failed Operation");
                        break;
                }
            }
        }

        private double? Parse(string input)
        {
            input = input.Replace(" ","");
            input = input.ToUpper();
            string[] targets = { "+", "-", "*", "/", "%", "^", "ROOT"};
            
            //Start of ineffiecent
            int opCount = 0;
            string op = "";
            foreach (string target in targets)
            {
                int index = 0;
                while ((index = input.IndexOf(target, index)) != -1)
                {
                    op = target;
                    opCount++;
                    index += target.Length;
                }
            }
            if (opCount != 1) return null;
            //End of ineffiecent

            string[] simple = input.Split(op);
            double a = double.Parse(simple[0]);
            double b = double.Parse(simple[1]);
            switch (op)
            {
                case "+":
                    return Function.Add(a, b);;
                case "-":
                    return Function.Subtract(a, b);
                case "*":
                    return Function.Multiply(a, b);
                case "/":
                    try
                    {
                        return Function.Divide(a, b);           
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine("Cannot Divide by zero");
                        return null;
                    }
                case "%":
                    try
                    {
                        return Function.Mod((int)a, (int)b);
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine("Cannot Divide by zero");
                        return null;
                    }
                case "^":
                    return Function.Power(a, b);
                case "ROOT":
                    return Function.Root(a, b);
                default:
                    return null;
            }
        }
    }
}
