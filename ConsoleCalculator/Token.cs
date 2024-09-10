using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Token
{
    public string Name;
    public Token()
    {
        Name = "ERROR";
    }
}

public class Operand : Token
{
    public double? Value;
    public Operand(double num)
    {
        Name = num.ToString();
        Value = num;
    }
    
    public Operand(string variable)
    {
        Name = variable;
        Value = null;
    }
}

public class Operator : Token
{
    public int Precedence = -1;
    public char Associativity = 'N';

    public Operator(char symbol)
    {
        switch (symbol)
        {
            case '+':
                Name = "ADD";
                Precedence = 2;
                Associativity = 'L';
                break;
            case '-':
                Name = "SUBTRACT";
                Precedence = 2;
                Associativity = 'L';
                break;
            case '*':
                Name = "MULTIPLY";
                Precedence = 3;
                Associativity = 'L';
                break;
            case '/':
                Name = "DIVIDE";
                Precedence = 3;
                Associativity = 'L';
                break;
            case '%':
                Name = "MODULUS";
                Precedence = 3;
                Associativity = 'L';
                break;
            case '^':
                Name = "POWER";
                Precedence = 4;
                Associativity = 'R';
                break;
            case '(':
                Name = "LPAREN";
                break;
            case ')':
                Name = "RPAREN";
                break;
            default:
                Name = "ERROR";
                break;
        }
    }

    public Operator(string function)
    {
        function = function.ToUpper();
        switch (function)
        {
            case "ROOT":
                Name = "ROOT";
                Precedence = 4;
                Associativity = 'L';
                break;
            default:
                Name = "ERROR";
                break;
        }
    }
}
