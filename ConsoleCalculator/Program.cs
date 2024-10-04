using Calculator;
namespace ConsoleCalculator;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the ConsoleCalculator interface");
        Console.WriteLine("--------------------------------------------------------------------------");
        Console.WriteLine("Which Calculator would you like to use");
        Console.WriteLine("     (1) Functional calcuator");
        Console.WriteLine("     (2) Arithmetic calculator");
        Console.WriteLine("     (3) Algerbra Calculator");
        Console.WriteLine("     (4) WCF Service Calculator");
        Console.WriteLine("     (5) Grpc Service Calculator");
        bool status = false;
        int option;
        do
        {
            status = int.TryParse(Console.ReadLine(), out option);
            if (!status)
            {
                Console.WriteLine("Please Try Again");
            }
        } while (!(status && (option > 0 && option <= 5)));
        Console.WriteLine("Starting Calculator");
        dynamic Calculator = "Not Assigned to a calculator";
        bool repeat;
        do
        {
            repeat = false;
            switch (option)
            {
                case 1:
                    //Calls Constructor but does not store the object
                    Console.WriteLine("--------------------------------------------------------------------------");
                    new FunctionConsole();
                    break;
                case 2:
                    new ArithmeticConsole();
                    break;
                case 3:
                    new AlgerbraConsole();
                    break;
                case 4:
                    new WCFCalculatorClientConsole();
                    break;
                case 5:
                    new GrpcCalculatorClientConsole();
                    break;
                default:
                    Console.WriteLine("ERROR");
                    repeat = true;
                    break;
            }
        } while (repeat);
    }
}