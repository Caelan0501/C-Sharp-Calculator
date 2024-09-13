using System;
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
                        s += equation[i + x];
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
        for(int i = RPN.Count -1; i >= 0; i--)
        {
            if (i >= RPN.Count) continue;
            Token curr = RPN[i];
            if (curr.GetType() != typeof(Operator)) continue;
            Operator token = (Operator)curr;
            Token a = RPN[i - 2];
            Token b = RPN[i - 1];
            if (a.GetType() == typeof(Operand) && b.GetType() == typeof(Operand))
            {
                Operand OperandA = (Operand)a;
                Operand OperandB = (Operand)b;
                if (OperandA.Value != null && OperandB.Value != null)
                {
                    double aVal = (double) OperandA.Value;
                    double bVal = (double)OperandA.Value;
                    Operand operand;
                    switch (token.Name)
                    {
                        case "ADD":
                            operand = new Operand(Add(aVal, bVal));
                            break;
                        case "SUBTRACT":
                            operand = new Operand(Subtract(aVal, bVal));
                            break;
                        case "MULTIPLY":
                            operand = new Operand(Multiply(aVal, bVal));
                            break;
                        case "DIVIDE":
                            operand = new Operand(Divide(aVal, bVal));
                            break;
                        case "MODULUS":
                            operand = new Operand(Mod((int)aVal, (int)bVal));
                            break;
                        case "POWER":
                            operand = new Operand(Power(aVal, bVal));
                            break;
                        case "ROOT":
                            operand = new Operand(Root(aVal, bVal));
                            break;
                        default:
                            throw new SolveException("UNKNOWN TOKEN");
                    }
                    RPN.RemoveAt(i);
                    RPN.RemoveAt(i - 1);
                    RPN[i - 2] = operand;
                    continue;
                }
            }
            Term term = new Term(a, b, token);
            RPN.RemoveAt(i);
            RPN.RemoveAt(i - 1);
            RPN[i-2] = term;
        }
        //Convert back to Infix
        List<Token> Infix = RPNToInfix(RPN);
        //Convert to String

        return ""; //Placeholder
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