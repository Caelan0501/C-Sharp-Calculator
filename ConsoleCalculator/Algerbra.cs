using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;


public class Algerbra : Arithmetic
{
    public Algerbra(bool enabledHistory = true) { }

    public override string ToString()
    {
        return "Algerbra Calculator";
    }

    private List<Token> ParseTokens(string equation)
    {
        List<Token> tokens = new List<Token>();
        int openParen = 0;
        Token token;
        for (int i = 0; i < equation.Length; i++)
        {
            switch (equation[i])
            {
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
                default:
                    string s = "";
                    int x = 0;
                    while (char.IsLetter(equation[i + x]))
                    {
                        s += equation[i + x];
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
                    i = i + s.Length;
                    break;
            }
        }
        if (openParen != 0) throw new ParserException("PARENTHESIS NOT CLOSED");
        return tokens;
    }

    public string Simplify(string equation)
    {
        //ParseTokens and convert to RPN
        List<Token> RPN = InfixToRPN(ParseTokens(equation));
        //Solve what we can
        Stack<Token> stack = new Stack<Token>();
        foreach (Token token in RPN)
        {
            if (token.GetType() != typeof(Operator))
            {
                stack.Push(token);
                continue;
            }
            Operator op = (Operator)token;
            Token b = stack.Pop();
            Token a = stack.Pop();
            if (a.GetType() == typeof(Operand) && b.GetType() == typeof(Operand))
            {
                Operand aO = (Operand)a;
                Operand bO = (Operand)b;
                if(aO.Value != null && bO.Value != null)
                {
                    double aVal = (double) aO.Value;
                    double bVal = (double) bO.Value;
                    switch (op.Name)
                    {
                        case "ADD":
                            stack.Push(new Operand(Add(aVal, bVal)));
                            break;
                        case "SUBTRACT":
                            stack.Push(new Operand(Subtract(aVal, bVal)));
                            break;
                        case "MULTIPLY":
                            stack.Push(new Operand(Multiply(aVal, bVal)));
                            break;
                        case "DIVIDE":
                            stack.Push(new Operand(Divide(aVal, bVal)));
                            break;
                        case "MODULUS":
                            stack.Push(new Operand(Mod((int)aVal, (int)bVal)));
                            break;
                        case "POWER":
                            stack.Push(new Operand(Power(aVal, bVal)));
                            break;
                        case "ROOT":
                            stack.Push(new Operand(Root(aVal, bVal)));
                            break;
                        default:
                            throw new SolveException("UNKNOWN TOKEN");
                    }
                    continue;
                }
            }
            stack.Push(new Term(a, b, op));
        }
        Token result = stack.Pop();
        if (result.GetType() == typeof(Operand))
        {
            return result.Name;
        }
        Term term = (Term)result;

        List<Token> Infix = term.GetTokenizedList();

        string simplified = "";
        foreach (Token token in Infix)
        {
            switch(token.Name)
            {
                case "LPAREN":
                    simplified += "(";
                    break;
                case "RPAREN":
                    simplified += ")";
                    break;
                case "ADD":
                    simplified += "+";
                    break;
                case "SUBTRACT":
                    simplified += "-";
                    break;
                case "MULTIPLY":
                    simplified += "*";
                    break;
                case "DIVIDE":
                    simplified += "/";
                    break;
                case "MODULUS":
                    simplified += "%";
                    break;
                case "POWER":
                    simplified += "^";
                    break;
                case "ROOT":
                    simplified += "√";
                    break;
                default:
                    simplified += token.Name;
                    break;
            }
        }
        //Convert to String
        
        return simplified; //Placeholder
    }

    public override double Solve(string equation) 
    {
        return 0; //Placeholder
    }

    protected List<Token> RPNToInfix(List<Token> RPN)
    {
        for(int i = RPN.Count - 1; i >= 0; i--)
        {
            if (i >= RPN.Count) continue; //Prevents falling out of bounds
            Token op = RPN[i];
            if (op.GetType() != typeof(Operator)) continue;
            Token a = RPN[i-2];
            if (a.GetType() == typeof(Operator)) continue;
            Token b = RPN[i-1];
            if (b.GetType() == typeof (Operator)) continue;

            Token term = new Term(a, b, (Operator)op);

            RPN.RemoveAt(i);
            RPN.RemoveAt(i - 1);
            RPN[i - 2] = term;
        }

        if (RPN[0].GetType() == typeof(Operand)) return RPN;
        Term finalTerm = (Term)RPN[0];
        return finalTerm.GetTokenizedList();
    }
}