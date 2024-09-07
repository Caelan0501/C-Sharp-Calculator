using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class Arithmetic : Basic6Fun
{
    protected class Token
    {
        public string Name;
        public double Value;

        public int Precedence = -1;
        public char Associativity = 'N';
        
        public OP Type;
        public enum OP { ADD, SUB, MULT, DIV, MOD, POWER, ROOT, LPAREN, RPAREN, NUMBER, ERROR };

        public Token(string name)
        {
            Name = name;
            bool isNumber = Double.TryParse(Name, out Value);
            if (isNumber) Type = OP.NUMBER;
            else
            {
                switch (name)
                {
                    case "+":
                        Type = OP.ADD;
                        Precedence = 2;
                        Associativity = 'L';
                        break;
                    case "-":
                        Type = OP.SUB;
                        Precedence = 2;
                        Associativity = 'L';
                        break;
                    case "*":
                        Type = OP.MULT;
                        Precedence = 3;
                        Associativity = 'L';
                        break;
                    case "/":
                        Type = OP.DIV;
                        Precedence = 3;
                        Associativity = 'L';
                        break;
                    case "%":
                        Type = OP.MOD;
                        Precedence = 3;
                        Associativity = 'L';
                        break;
                    case "^":
                        Type = OP.POWER;
                        Precedence = 4;
                        Associativity = 'R';
                        break;
                    case "Root":
                        Type = OP.ROOT;
                        Associativity = 'L';
                        Precedence = 4;
                        break;
                    case "(":
                        Type = OP.LPAREN;
                        break;
                    case ")":
                        Type = OP.RPAREN;
                        break;
                    default:
                        Type = OP.ERROR;
                        break;
                }
            }
        }
        public Token(double num)
        {
            Name = num.ToString();
            Value = num;
            Precedence = -1;
            Type = OP.NUMBER;
            Associativity = 'N';
        }
        public bool IsOperator()
        {
            if (Type == OP.NUMBER || Type == OP.ERROR) return false;
            else return true;
        }
    }
    public Arithmetic(bool enabledHistory = true) :base(enabledHistory: enabledHistory)
    {
    }
    public override string ToString()
    {
        return "Arithmetic Calculator";
    }

    public double? Solve(string equation)
    {
        List<Token>? tokens = ParseTokens(equation);
        if (tokens == null) return null;
        List<Token> RPN = InfixToRNC(tokens);
        while (RPN.Count > 1)
        {
            for (int i = 0; i < RPN.Count; i++)
            {
                Token token = RPN[i];
                if (!token.IsOperator()) continue;
                Token newToken;
                double a = RPN[i - 2].Value;
                double b = RPN[i - 1].Value;
                switch (token.Type)
                {
                    case Token.OP.ADD:
                        newToken = new Token(Add(a, b));
                        break;
                    case Token.OP.SUB:
                        newToken = new Token(Subtract(a, b));
                        break;
                    case Token.OP.MULT:
                        newToken = new Token(Multiply(a, b));
                        break;
                    case Token.OP.DIV:
                        newToken = new Token(Divide(a, b));
                        break;
                    case Token.OP.MOD:
                        newToken = new Token(Mod((int)a, (int)b));
                        break;
                    case Token.OP.POWER:
                        newToken = new Token(Power(a, b));
                        break;
                    case Token.OP.ROOT:
                        newToken = new Token(Power(a, b));
                        break;
                    default:
                        return null;
                }
                RPN.RemoveAt(i);
                RPN.RemoveAt(i - 1);
                i = i - 2;
                RPN[i]= newToken;
            }
        }
        return RPN[0].Value;
    }
    protected List<Token>? ParseTokens(string equation)
    {
        List<Token> tokens = new List<Token>();
        bool status = true;
        int openParen = 0;
        Token token;
        for (int i = 0; i < equation.Length; i++)
        {
            switch (equation[i])
            {
                case char c when Char.IsDigit(c):
                case '.':
                    string number = equation[i].ToString();
                    while ((i + 1 < equation.Length) && (Char.IsDigit(equation[i + 1])) || (equation[i + 1] == '.'))
                    {
                        i++;
                        number += equation[i];
                    }
                    token = new Token(number);
                    tokens.Add(token);
                    break;
                case '+':
                    token = new Token("+");
                    tokens.Add(token);
                    break;
                case '-':
                    token = new Token("-");
                    tokens.Add(token);
                    break;
                case '*':
                    token = new Token("*");
                    tokens.Add(token);
                    break;
                case '/':
                    token = new Token("/");
                    tokens.Add(token);
                    break;
                case '%':
                    token = new Token("%");
                    tokens.Add(token);
                    break;
                case '^':
                    token = new Token("^");
                    tokens.Add(token);
                    break;
                case '(':
                    token = new Token("(");
                    tokens.Add(token);
                    openParen++;
                    break;
                case ')':
                    token = new Token(")");
                    tokens.Add(token);
                    openParen--;
                    break;
                case 'R':
                    if (i + 3 < equation.Length)
                    {
                        if (equation[i + 1] == 'o' && equation[i + 2] == 'o' && equation[i + 3] == 't')
                        {
                            token = new Token("Root");
                            tokens.Add(token);
                        }
                        else status = false;
                    }
                    else status = false;
                    break;
                default:
                    break;
            }
            if (!status) return null;
        }
        if (openParen != 0) return null;
        return tokens;
    }

    //Shunting yard Algorithm
    //Prase Dijstra
    protected List<Token> InfixToRNC(List<Token> tokens)
    {   
        Stack<Token> operatorStack = new Stack<Token>();
        List<Token> RPN = new List<Token>();
        foreach (Token token in tokens)
        {
            if (!token.IsOperator())
            {
                RPN.Add(token);
                continue;
            }
            else if (token.Type == Token.OP.LPAREN) 
            {
                operatorStack.Push(token);
                continue;
            }
            else if (token.Type == Token.OP.RPAREN)
            {
                Token top = operatorStack.Peek();
                while (top.Type != Token.OP.LPAREN)
                {
                    RPN.Add(operatorStack.Pop());
                    top = operatorStack.Peek();
                }
                operatorStack.Pop();// Remove the LPAREN
            }
            else
            {
                Token top;
                if (operatorStack.Count == 0) operatorStack.Push(token);
                else
                {
                    top = operatorStack.Peek();
                    while (top.Type != Token.OP.LPAREN && ((token.Precedence < top.Precedence) || ((token.Precedence == top.Precedence) && token.Associativity == 'L')))
                    {
                        RPN.Add(operatorStack.Pop());
                        top = operatorStack.Peek();
                    }
                    operatorStack.Push(token);
                }
            }
        }
        while (operatorStack.Count > 0) RPN.Add(operatorStack.Pop());
        return RPN;
    }
}
