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
            case '×':
                Name = "MULTIPLY";
                Precedence = 3;
                Associativity = 'L';
                break;
            case '/':
            case '÷':
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
            case '√':
                Name = "ROOT";
                Precedence = 4;
                Associativity = 'L';
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

public class Term : Token
{
    public Token Left;
    public Token Right;
    public Operator Op;
    public Term(Token Left, Token Right, Operator Op)//Requires testing
    {
        if (Left.GetType() == typeof(Term)) Name = "(" + Left.Name + ")";
        else Name = Left.Name;
        Name += Op.Name;
        if (Right.GetType() == typeof(Term)) Name = "(" + Right.Name + ")";
        else Name = Right.Name;

        this.Left = Left;
        this.Right = Right;
        this.Op = Op;
    }

    //Base Function
    public List<Token> GetTokenizedList()
    {
        
        List<Token> tokens = new List<Token>();
        if (Left.GetType() == typeof(Operand))
        {
            tokens.Add(Left);
        }
        else if (Left.GetType() == typeof(Term))
        {
            tokens.Add(new Operator('('));
            tokens.AddRange(GetTokenizedList((Term)Left));
            tokens.Add(new Operator(')'));
        }
        else throw new TermException("MISPLACED OPERATOR");

        tokens.Add(Op);

        if (Right.GetType() == typeof(Operand))
        {
            tokens.Add(Right);
        }
        else if (Right.GetType() == typeof(Term))
        {
            tokens.Add(new Operator('('));
            tokens.AddRange(GetTokenizedList((Term)Right));
            tokens.Add(new Operator(')'));
        }
        else throw new TermException("MISPLACED OPERATOR");

        return tokens;
    }
    //Recursive Function
    private IEnumerable<Token> GetTokenizedList(Term curr)
    {
        List<Token> tokens = new List<Token> ();

        if (curr.Left.GetType() == typeof(Operand)) tokens.Add(curr.Left);
        else if (curr.Left.GetType() == typeof(Term))
        {
            tokens.Add(new Operator('('));
            tokens.AddRange(GetTokenizedList((Term)curr.Left));
            tokens.Add(new Operator(')'));
        }
        else throw new TermException("MISPLACED OPERATOR");

        tokens.Add(curr.Op);

        if (curr.Right.GetType() == typeof(Operand)) tokens.Add(curr.Right);
        else if (curr.Right.GetType() == typeof(Term))
        {
            tokens.Add(new Operator('('));
            tokens.AddRange(GetTokenizedList((Term)curr.Right));
            tokens.Add(new Operator(')'));
        }

        else throw new TermException("MISPLACED OPERATOR");

        return tokens;
    }
}

public class TermException : Exception
{
    public TermException(string message) : base(message) { }
}