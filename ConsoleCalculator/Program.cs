public class Program
{
    public static void Main(string[] args)
    {
        dynamic Calculator = Init_Calculator();
        bool end = false;
        do
        {
            string? input = Console.ReadLine();
            if (input == null) continue;
            string s = input;
            s = s.ToUpper();
            switch (s)
            {
                case "":
                    break;
                case "HELP":
                    Console.WriteLine("To use please input your Equation in the following format: {a} {operator} {b}");
                    Console.WriteLine("ReadRecentHistory - Read the lastest History, Repeated use will backtrack further");
                    Console.WriteLine("ReadAllHistory - Read All History from youngest to oldest");
                    Console.WriteLine("Quit - End the program");
                    break;
                case "QUIT":
                    end = true;
                    break;
                case "GETALLHISTORY":
                    Console.WriteLine(Calculator.GetAllHistory());
                    break;
                case "GETRECENTHISTORY":
                    Console.WriteLine(Calculator.GetRecentHistory());
                    break;
                case "RESUMEHISTORY":
                    Calculator.ResumeHistory();
                    Console.WriteLine("History Resumed");
                    break;
                case "PAUSEHISTORY":
                    Calculator.PauseHistory();
                    Console.WriteLine("History Paused");
                    break;
                case "CLEARHISTORY":
                    Calculator.ClearHistory();
                    Console.WriteLine("History Cleared");
                    break;
                default:
                    UseCalculator(Calculator, s);
                    break;
            }
        } while (!end);
    }
    private static dynamic Init_Calculator()
    {
        Console.WriteLine("Welcome to the ConsoleCalculator interface");
        Console.WriteLine("--------------------------------------------------------------------------");
        Console.WriteLine("Which Calculator would you like to use");
        Console.WriteLine("     (1) Basic 4 Function calcuator");
        Console.WriteLine("     (2) Basic 6 Function calcuator");
        Console.WriteLine("     (3) Arithmetic Calculator");
        Console.WriteLine("     (4) Algerbra Calculator");

        bool status = false;
        int option;
        do
        {
            status = int.TryParse(Console.ReadLine(), out option);
            if (!status)
            {
                Console.WriteLine("Please Try Again");
            }
        } while (!(status && (option > 0 && option <= 4)));
        Console.WriteLine("Starting Calculator");
        dynamic Calculator = "Not Assigned to a calculator";
        bool repeat = false;
        do
        {
            repeat = false;
            switch (option)
            {
                case 1:
                    Calculator = new Basic4Fun();
                    break;
                case 2:
                    Calculator = new Basic6Fun();
                    break;
                case 3:
                    Calculator = new Arithmetic();
                    break;
                case 4:
                    Calculator = new Algerbra();
                    break;
                default:
                    Console.WriteLine("ERROR");
                    repeat = true;
                    break;
            }
        } while (repeat);
        Console.WriteLine("--------------------------------------------------------------------------");
        return Calculator;
    }
    private static void UseCalculator(dynamic Calculator, string s)
    {
        string[] targets = { "+", "-", "*", "/", "%", "^", "ROOT" };
        int opCount = 0;
        string op = "";
        foreach (string target in targets)
        {
            int index = 0;
            while ((index = s.IndexOf(target, index)) != -1)
            {
                op = target;
                opCount++;
                index += target.Length;
            }
        }
        if (opCount == 1)
        {
            string[] simple = s.Split(op);
            double a = double.Parse(simple[0]);
            double b = double.Parse(simple[1]);
            singleOperationSolver(Calculator, a, b, op);
        }
        else if (Calculator.GetType() == typeof(Arithmetic))
        {
            Console.WriteLine(Calculator.Solve(s).ToString());
        }
        else if (Calculator.GetType() == typeof(Algerbra))
        {
            Console.WriteLine(Calculator.Simplify(s).ToString());
        }
        else
        {
            throw new Exception("OPERATION NOT SUPPORTED");
        }
    }
    private static void singleOperationSolver(dynamic Calculator, double a, double b, string op)
    {
        try
        {
            switch (op)
            {
                case "+":
                    Console.WriteLine(Calculator.Add(a, b).ToString());
                    break;
                case "-":
                    Console.WriteLine(Calculator.Subtract(a, b).ToString());
                    break;
                case "*":
                    Console.WriteLine(Calculator.Multiply(a, b).ToString());
                    break;
                case "/":
                    try
                    {
                        Console.WriteLine(Calculator.Divide(a, b).ToString());
                    }
                    catch (DivideException ex)
                    {
                        Console.WriteLine($"{ex.Message}");
                    }
                    break;
                case "%":
                    Console.WriteLine(Calculator.Mod((int)a, (int)b).ToString());
                    break;
                case "^":
                    Console.WriteLine(Calculator.Power(a, b).ToString());
                    break;
                case "ROOT":
                    Console.WriteLine(Calculator.Root(a, b).ToString());
                    break;
                default:
                    break;
            }
        }
        catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
        {
            Console.WriteLine("OPERATION NOT SUPPORTED");
        }
        
    }
}


