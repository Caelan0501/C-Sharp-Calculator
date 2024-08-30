Basic4Fun basic4Fun = new Basic4Fun();
Console.WriteLine("Welcome to the Basic4fun interaction interface");
Console.WriteLine("To use please type a 2 operand equation or type Help for more options");
bool end = false;
do
{
    string input = Console.ReadLine();
    if (input == null || input == "")
    {
    }
    else if (input == "help")
    {
        Console.WriteLine("To use please input your Equation in the following format: {a} {operator} {b}");
        Console.WriteLine("ReadRecentHistory - Read the lastest History, Repeated use will backtrack further");
        Console.WriteLine("ReadAllHistory - Read All History from youngest to oldest");
        Console.WriteLine("Quit - End the program");
    }
    else if (input == "quit")
    {
        end = true;
    }
    else if (input == "ReadRecentHistory")
    {
        Console.WriteLine(basic4Fun.ReadRecentHistory());
    }
    else if (input == "ReadAllHistory")
    {
        Console.WriteLine(basic4Fun.ReadAllHistory());
    }
    else if (Char.IsDigit(input[0]))
    {
        string[] parts = input.Split(' ');
        if (parts.Length != 3 && parts.Length != 1)
        {
            Console.WriteLine("Error: Improper Syntax");
        }
        else if (parts.Length == 3)
        {
            string a = parts[0];
            string op = parts[1];
            string b = parts[2];
            switch (op)
            {
                case "+":
                    Console.WriteLine(basic4Fun.Add(Double.Parse(a), Double.Parse(b)));
                    break;
                case "-":
                    Console.WriteLine(basic4Fun.Subtract(Double.Parse(a), Double.Parse(b)));
                    break;
                case "*":
                    Console.WriteLine(basic4Fun.Multiply(Double.Parse(a), Double.Parse(b)));
                    break;
                case "/":
                    Console.WriteLine(basic4Fun.Divide(Double.Parse(a), Double.Parse(b)));
                    break;
                case "%":
                    Console.WriteLine(basic4Fun.Mod(int.Parse(a), int.Parse(b)));
                    break;
                default:
                    Console.WriteLine("Error: Improper Syntax");
                    break;
            }
        }
        else
        {
            if(input.Split('+').Length == 2)
            {
                parts = input.Split("+");
                Console.WriteLine(basic4Fun.Add(parts[0], parts[1]));
            }
            else if(input.Split("-").Length == 2)
            {
                parts = input.Split("-");
                Console.WriteLine(basic4Fun.Subtract(parts[0], parts[1]));
            }
            else if (input.Split("*").Length == 2)
            {
                parts = input.Split("*");
                Console.WriteLine(basic4Fun.Multiply(parts[0], parts[1]));
            }
            else if (input.Split("/").Length == 2)
            {
                parts = input.Split("/");
                Console.WriteLine(basic4Fun.Divide(parts[0], parts[1]));
            }
            else if (input.Split("%").Length == 2)
            {
                parts = input.Split("%");
                Console.WriteLine(basic4Fun.Mod(parts[0], parts[1]));
            }
            else
            {
                Console.WriteLine("Error: Improper Syntax");
            }
        }
    }
    else
    {
        Console.WriteLine("Error: Improper Syntax");
    }
}while (!end);
