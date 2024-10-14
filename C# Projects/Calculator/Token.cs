using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal abstract class Token
    {
        internal string Name;
        internal Token()
        {
            Name = "UNDEFINED";
        }
        internal static List<Token> ParseEquation(string equation)
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
        internal static List<Token> InfixToRPN(List<Token> tokens)
        {
            //Shunting yard Algorithm
            //Prase Dijstra
            Stack<Operator> operatorStack = new Stack<Operator>();
            List<Token> RPN = new List<Token>();
            foreach (Token token in tokens)
            {
                if (token.GetType() == typeof(Operand))
                {
                    RPN.Add(token);
                    continue;
                }
                else if (token.Name == "LPAREN")
                {
                    operatorStack.Push((Operator)token);
                    continue;
                }
                else if (token.Name == "RPAREN")
                {
                    Operator top = operatorStack.Peek();
                    while (!(top.Name == "LPAREN"))
                    {
                        RPN.Add(operatorStack.Pop());
                        top = operatorStack.Peek();
                    }
                    operatorStack.Pop();// Remove the LPAREN
                }
                else
                {
                    Operator top;
                    Operator curr = (Operator)token;
                    if (operatorStack.Count == 0) operatorStack.Push(curr);
                    else
                    {
                        top = operatorStack.Peek();
                        while (!(top.Name == "LPAREN") && ((curr.Precedence <= top.Precedence) && curr.Associativity == 'L'))
                        {
                            RPN.Add(operatorStack.Pop());
                            if (operatorStack.Count == 0) break;
                            top = operatorStack.Peek();
                        }
                        operatorStack.Push(curr);
                    }
                }
            }
            while (operatorStack.Count > 0) RPN.Add(operatorStack.Pop());
            return RPN;
        }
        internal static List<Token> RPNToInfix(List<Token> RPN)
        {
            for (int i = RPN.Count - 1; i >= 0; i--)
            {
                if (i >= RPN.Count) continue; //Prevents falling out of bounds
                Token op = RPN[i];
                if (op.GetType() != typeof(Operator)) continue;
                Token a = RPN[i - 2];
                if (a.GetType() == typeof(Operator)) continue;
                Token b = RPN[i - 1];
                if (b.GetType() == typeof(Operator)) continue;

                Token term = new Term(a, b, (Operator)op);

                RPN.RemoveAt(i);
                RPN.RemoveAt(i - 1);
                RPN[i - 2] = term;
            }

            if (RPN[0].GetType() == typeof(Operand)) return RPN;
            return ((Term)RPN[0]).TermToList();
        }

        internal class ParserException : Exception
        {
            public ParserException(string message) : base(message) { }
        }
    }
    internal class Operand : Token
    {
        internal double? Value;
        internal Operand(double num)
        {
            Name = num.ToString();
            Value = num;
        }
        internal Operand(string variable)
        {
            Name = variable;
            Value = null;
        }
        internal Operand(Operand operand)
        {
            this.Name = operand.Name;
            this.Value = operand.Value;
        }
    }
    internal class Operator : Token
    {
        internal int Precedence = -1;
        internal char Associativity = 'N';
        internal char ShortName;

        internal Operator(char symbol)
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
                case '=':
                    Name = "EQUAL";
                    ShortName = '=';
                    break;
                default:
                    Name = "ERROR";
                    ShortName = 'E';
                    break;
            }
        }

        internal Operator(string function)
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
    internal class Term : Token
    {
        internal Token Left;
        internal Token Right;
        internal Operator Op;
        internal Term(Token Left, Token Right, Operator Op)
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
        internal List<Token> TermToList()
        {
            List<Token> tokens = new List<Token>();
            if (Left.GetType() == typeof(Operand)) tokens.Add(Left);
            else if (Left.GetType() == typeof(Term))
            {
                tokens.Add(new Operator('('));
                tokens.AddRange(TermToList((Term)Left));
                tokens.Add(new Operator(')'));
            }
            else throw new TermException("MISPLACED OPERATOR");

            tokens.Add(Op);

            if (Right.GetType() == typeof(Operand)) tokens.Add(Right);
            else if (Right.GetType() == typeof(Term))
            {
                tokens.Add(new Operator('('));
                tokens.AddRange(TermToList((Term)Right));
                tokens.Add(new Operator(')'));
            }
            else throw new TermException("MISPLACED OPERATOR");

            return tokens;
        }
        private IEnumerable<Token> TermToList(Term curr)
        {
            List<Token> tokens = new List<Token>();

            if (curr.Left.GetType() == typeof(Operand)) tokens.Add(curr.Left);
            else if (curr.Left.GetType() == typeof(Term))
            {
                tokens.Add(new Operator('('));
                tokens.AddRange(TermToList((Term)curr.Left));
                tokens.Add(new Operator(')'));
            }
            else throw new TermException("MISPLACED OPERATOR");

            tokens.Add(curr.Op);

            if (curr.Right.GetType() == typeof(Operand)) tokens.Add(curr.Right);
            else if (curr.Right.GetType() == typeof(Term))
            {
                tokens.Add(new Operator('('));
                tokens.AddRange(TermToList((Term)curr.Right));
                tokens.Add(new Operator(')'));
            }
            else throw new TermException("MISPLACED OPERATOR");

            return tokens;
        }
        internal class TermException : Exception
        {
            public TermException(string message) : base(message) { }
        }
    }
}
