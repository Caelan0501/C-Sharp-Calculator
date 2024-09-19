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
        Name = "UNDEFINED";
    }
    public static List<Token> ParseEquation(string equation)
    {
        List<Token> tokens = new List<Token>();
        int openParen = 0;
        Token token;
        for (int i = 0; i < equation.Length; i++)
        {
            switch (equation[i])
            {
                case char c when Char.IsWhiteSpace(c):
                    break;
                case '(':
                    token = new Operator('(');
                    tokens.Add(token);
                    openParen++;
                    break;
                case ')':
                    token = new Operator(')');
                    tokens.Add(token);
                    openParen--;
                    break;
                case '+':
                case '-':
                case '*':
                case '×':
                case '/':
                case '%':
                case '√':
                case '÷':
                case '^':
                    token = new Operator(equation[i]);
                    tokens.Add(token);
                    break;
                case char c when Char.IsDigit(c):
                case '.':
                    string number = equation[i].ToString();
                    bool decimalUsed = equation[i] == '.';
                    while (i + 1 < equation.Length)
                    {
                        if (!(equation[i + 1] == '.' || Char.IsDigit(equation[i + 1]))) break;
                        if (decimalUsed && equation[i + 1] == '.') throw new ParserException("Multiple Decimals where used");
                        i++;
                        number += equation[i];
                    }
                    token = new Operand(double.Parse(number));
                    tokens.Add(token);
                    break;
                default:
                    string s = "";
                    int x = 0;
                    while (char.IsLetter(equation[i + x]))
                    {
                        s += equation[i + x];
                        if (i + x + 1 >= equation.Length) break;
                        x++;
                    }
                    switch (s)
                    {
                        case "Root":
                            token = new Operator("Root");
                            tokens.Add(token);
                            break;
                        default:
                            token = new Operand(s);
                            tokens.Add(token);
                            break;
                    }
                    i = i + s.Length - 1;
                    break;
            }
        }
        if (openParen != 0) throw new ParserException("PARENTHESIS NOT CLOSED");
        return tokens;
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
    public char ShortName;

    public Operator(char symbol)
    {
        switch (symbol)
        {
            case '+':
                Name = "ADD";
                ShortName = '+';
                Precedence = 2;
                Associativity = 'L';
                break;
            case '-':
                Name = "SUBTRACT";
                ShortName = '-';
                Precedence = 2;
                Associativity = 'L';
                break;
            case '*':
            case '×':
                Name = "MULTIPLY";
                ShortName = '*';
                Precedence = 3;
                Associativity = 'L';
                break;
            case '/':
            case '÷':
                Name = "DIVIDE";
                ShortName = '/';
                Precedence = 3;
                Associativity = 'L';
                break;
            case '%':
                Name = "MODULUS";
                ShortName = '%';
                Precedence = 3;
                Associativity = 'L';
                break;
            case '^':
                Name = "POWER";
                ShortName = '^';
                Precedence = 4;
                Associativity = 'R';
                break;
            case '√':
                Name = "ROOT";
                ShortName = '√';
                Precedence = 4;
                Associativity = 'L';
                break;
            case '(':
                Name = "LPAREN";
                ShortName = '(';
                break;
            case ')':
                Name = "RPAREN";
                ShortName = ')';
                break;
            default:
                Name = "ERROR";
                ShortName = 'E';
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
                ShortName = '√';
                Precedence = 4;
                Associativity = 'L';
                break;
            default:
                Name = "ERROR";
                ShortName = 'E';
                break;
        }
    }
}

public class Term : Token
{
    public Token Left;
    public Token Right;
    public Operator Op;
    public Term(Token Left, Token Right, Operator Op)
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

    public List<Token> GetTokenizedList()
    {
        
        List<Token> tokens = new List<Token>();
        if (Left.GetType() == typeof(Operand)) tokens.Add(Left);
        else if (Left.GetType() == typeof(Term))
        {
            tokens.Add(new Operator('('));
            tokens.AddRange(GetTokenizedList((Term)Left));
            tokens.Add(new Operator(')'));
        }
        else throw new TermException("MISPLACED OPERATOR");

        tokens.Add(Op);

        if (Right.GetType() == typeof(Operand)) tokens.Add(Right);
        else if (Right.GetType() == typeof(Term))
        {
            tokens.Add(new Operator('('));
            tokens.AddRange(GetTokenizedList((Term)Right));
            tokens.Add(new Operator(')'));
        }
        else throw new TermException("MISPLACED OPERATOR");

        return tokens;
    }
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