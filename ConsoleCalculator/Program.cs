using Microsoft.VisualBasic.FileIO;
using System.Data.SqlTypes;
using System;

Console.WriteLine("Welcome to the ConsoleCalculator interface");
Console.WriteLine("--------------------------------------------------------------------------");
Console.WriteLine("Which Calculator would you like to use");
Console.WriteLine("     (1) Basic 4 Function calcuator");
Console.WriteLine("     (2) Basic 6 Function calcuator");
Console.WriteLine("     (3) Arithmetic Calculator");
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
bool end = false;
do
{
    string? input = Console.ReadLine();
    if (input == null) continue;
    string s = input;
    s = s.ToUpper();
    if (s.Any(Char.IsDigit))
    {
        string[] targets = { "+", "-", "*", "/", "%", "^", "ROOT" };
        int[] targetsCount = new int[targets.Length];
        foreach(string target in targets)
        {
            int index = 0;
            int count = 0;
            while ((index = input.IndexOf(target, index)) != -1)
            {
                count++;
                index += target.Length;
            }
        }
        //Work in Progress
        /*
        bool OneOpFound = false;
        string op = "";
        foreach(int count in targetsCount)
        {
            if(count == 1)
            {
                OneOpFound = true;
                op = 
            }
        }
        */
    }
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
            break;
    }
} while (!end);