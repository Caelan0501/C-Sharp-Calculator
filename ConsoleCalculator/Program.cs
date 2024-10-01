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
        } while (!(status && (option > 0 && option <= 3)));
        Console.WriteLine("Starting Calculator");
        dynamic Calculator = "Not Assigned to a calculator";
        bool repeat = false;
        do
        {
            repeat = false;
            switch (option)
            {
                case 1:
                    //Calls Constructor but does not store the object
                    Console.WriteLine("--------------------------------------------------------------------------");
                    new FunctionCalculatorConsole();
                    break;
                case 2:
                    Calculator = new Arithmetic();
                    break;
                case 3:
                    Calculator = new Algerbra();
                    break;
                default:
                    Console.WriteLine("ERROR");
                    repeat = true;
                    break;
            }
        } while (repeat);
    }
}