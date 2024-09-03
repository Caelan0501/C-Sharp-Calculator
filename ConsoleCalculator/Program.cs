using Microsoft.VisualBasic.FileIO;

Console.WriteLine("Welcome to the ConsoleCalculator interface");
Console.WriteLine("--------------------------------------------------------------------------");
Console.WriteLine("Which Calculator would you like to use");
Console.WriteLine("     (1) Basic 4 Function calcuator");
Console.WriteLine("     (2) Basic 6 Function calcuator");
bool status = false;
int option;
do
{
    status = int.TryParse(Console.ReadLine(), out option);
    Console.WriteLine(status);
    if (!status)
    {
        Console.WriteLine("Please Try Again");
    }
    Console.WriteLine((status && (option == 1 || option == 2)));
} while (!(status && (option == 1 || option == 2)));

Console.WriteLine("Starting Calculator");
Console.WriteLine("--------------------------------------------------------------------------");
bool end = false;
switch (option)
{
    case 1:
        Basic4Fun basic4fun = new Basic4Fun();
        do
        {
            string? input = Console.ReadLine();
            switch (input)
            {

                case "Help":
                case "help":
                case "HELP":
                    Console.WriteLine("To use please input your Equation in the following format: {a} {operator} {b}");
                    Console.WriteLine("ReadRecentHistory - Read the lastest History, Repeated use will backtrack further");
                    Console.WriteLine("ReadAllHistory - Read All History from youngest to oldest");
                    Console.WriteLine("Quit - End the program");
                    break;
                case "Quit":
                case "quit":
                case "QUIT":
                    end = true;
                    break;
                case string s when Char.IsDigit(s[0]):
                    string[] parts;
                    if (input.Contains(' '))
                    {
                        parts = input.Split(' ');
                    }
                    else if(input.Contains('+'))
                    {
                        parts = input.Split('+');
                        Array.Resize(ref parts, 3);
                        parts[2] = parts[1];
                        parts[1] = "+";
                    }
                    else if (input.Contains('-'))
                    {
                        parts = input.Split('-');
                        Array.Resize(ref parts, 3);
                        parts[2] = parts[1];
                        parts[1] = "-";
                    }
                    else if (input.Contains('*'))
                    {
                        parts = input.Split('*');
                        Array.Resize(ref parts, 3);
                        parts[2] = parts[1];
                        parts[1] = "*";
                    }
                    else if (input.Contains('/'))
                    {
                        parts = input.Split('/');
                        Array.Resize(ref parts, 3);
                        parts[2] = parts[1];
                        parts[1] = "/";
                    }
                    else if (input.Contains('%'))
                    {
                        parts = input.Split('%');
                        Array.Resize(ref parts, 3);
                        parts[2] = parts[1];
                        parts[1] = "%";
                        }
                    else
                    {
                        Console.WriteLine("Error: Improper Syntax");
                        break;
                    }
                    string a = parts[0];
                    string op = parts[1];
                    string b = parts[2];
                    switch (op)
                    {
                        case "+":
                            Console.WriteLine(basic4fun.Add(Double.Parse(a), Double.Parse(b)));
                            break;
                        case "-":
                            Console.WriteLine(basic4fun.Subtract(Double.Parse(a), Double.Parse(b)));
                            break;
                        case "*":
                            Console.WriteLine(basic4fun.Multiply(Double.Parse(a), Double.Parse(b)));
                            break;
                        case "/":
                            Console.WriteLine(basic4fun.Divide(Double.Parse(a), Double.Parse(b)));
                            break;
                        case "%":
                            Console.WriteLine(basic4fun.Mod(int.Parse(a), int.Parse(b)));
                            break;
                        default:
                            Console.WriteLine("Error: Improper Syntax");
                            break;
                    }
                    break;
                case "GetAllHistory":
                case "GETALLHISTORY":
                case "getallhistory":
                    Console.WriteLine(basic4fun.GetAllHistory());
                    break;
                case "GetRecentHistory":
                case "getrecenthistory":
                case "GETRECENTHISTORY":
                    Console.WriteLine(basic4fun.GetRecentHistory());
                    break;
                case "ResumeHistory":
                case "resumehistory":
                case "RESUMEHISTORY":
                    basic4fun.ResumeHistory();
                    Console.WriteLine("History Resumed");
                    break;
                case "PauseHistory":
                case "pausehistory":
                case "PAUSEHISTORY":
                    basic4fun.PauseHistory();
                    Console.WriteLine("History Paused");
                    break;
                case "ClearHistory":
                case "clearhistory":
                case "CLEARHISTORY":
                    basic4fun.ClearHistory();
                    Console.WriteLine("History Cleared");
                    break;
                default:
                    break;
            }
        } while (!end);
        break;
    case 2:
        Basic6Fun basic6fun = new Basic6Fun();
        do
        {
            string? input = Console.ReadLine();
            switch (input)
            {
                case "Help":
                case "help":
                case "HELP":
                    Console.WriteLine("To use please input your Equation in the following format: {a} {operator} {b}");
                    Console.WriteLine("ReadRecentHistory - Read the lastest History, Repeated use will backtrack further");
                    Console.WriteLine("ReadAllHistory - Read All History from youngest to oldest");
                    Console.WriteLine("Quit - End the program");
                    break;
                case "Quit":
                case "quit":
                case "QUIT":
                    end = true;
                    break;
                case string s when Char.IsDigit(s[0]):
                    string[] parts;
                    if (input.Contains(' '))
                    {
                        parts = input.Split(' ');
                    }
                    else if (input.Contains('+'))
                    {
                        parts = input.Split('+');
                        Array.Resize(ref parts, 3);
                        parts[2] = parts[1];
                        parts[1] = "+";
                    }
                    else if (input.Contains('-'))
                    {
                        parts = input.Split('-');
                        Array.Resize(ref parts, 3);
                        parts[2] = parts[1];
                        parts[1] = "-";
                    }
                    else if (input.Contains('*'))
                    {
                        parts = input.Split('*');
                        Array.Resize(ref parts, 3);
                        parts[2] = parts[1];
                        parts[1] = "*";
                    }
                    else if (input.Contains('/'))
                    {
                        parts = input.Split('/');
                        Array.Resize(ref parts, 3);
                        parts[2] = parts[1];
                        parts[1] = "/";
                    }
                    else if (input.Contains('%'))
                    {
                        parts = input.Split('%');
                        Array.Resize(ref parts, 3);
                        parts[2] = parts[1];
                        parts[1] = "%";
                    }
                    else if (input.Contains('^'))
                    {
                        parts = input.Split('^');
                        Array.Resize(ref parts, 3);
                        parts[2] = parts[1];
                        parts[1] = "^";
                    }
                    else if (input.Contains("Root"))
                    {
                        parts = input.Split("Root");
                        Array.Resize(ref parts, 3);
                        parts[2] = parts[1];
                        parts[1] = "Root";
                    }
                    else
                    {
                        Console.WriteLine("Error: Improper Syntax");
                        break;
                    }
                    string a = parts[0];
                    string op = parts[1];
                    string b = parts[2];
                    switch (op)
                    {
                        case "+":
                            Console.WriteLine(basic6fun.Add(a, b));
                            break;
                        case "-":
                            Console.WriteLine(basic6fun.Subtract(a, b));
                            break;
                        case "*":
                            Console.WriteLine(basic6fun.Multiply(a, b));
                            break;
                        case "/":
                            Console.WriteLine(basic6fun.Divide(a, b));
                            break;
                        case "%":
                            Console.WriteLine(basic6fun.Mod(a, b));
                            break;
                        case "^":
                            Console.WriteLine(basic6fun.Power(a, b));
                            break;
                        case "Root":
                            Console.WriteLine(basic6fun.Root(a, b));
                            break;
                        default:
                            Console.WriteLine("Error: Improper Syntax");
                            break;
                    }
                    break;
                case "GetAllHistory":
                case "GETALLHISTORY":
                case "getallhistory":
                    Console.WriteLine(basic6fun.GetAllHistory());
                    break;
                case "GetRecentHistory":
                case "getrecenthistory":
                case "GETRECENTHISTORY":
                    Console.WriteLine(basic6fun.GetRecentHistory());
                    break;
                case "ResumeHistory":
                case "resumehistory":
                case "RESUMEHISTORY":
                    basic6fun.ResumeHistory();
                    Console.WriteLine("History Resumed");
                    break;
                case "PauseHistory":
                case "pausehistory":
                case "PAUSEHISTORY":
                    basic6fun.PauseHistory();
                    Console.WriteLine("History Paused");
                    break;
                case "ClearHistory":
                case "clearhistory":
                case "CLEARHISTORY":
                    basic6fun.ClearHistory();
                    Console.WriteLine("History Cleared");
                    break;
                default:
                    break;
            }
        } while (!end);
        break;
    default:
        break;
}