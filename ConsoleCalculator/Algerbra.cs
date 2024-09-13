using System;
using System.Collections.Generic;


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
                case '/':
                case '%':
                case '^':
                    token = new Operator(equation[i]);
                    tokens.Add(token);
                    break;
                case 'R':
                    if (i + 3 < equation.Length)
                    {
                        if (equation[i + 1] == 'o' && equation[i + 2] == 'o' && equation[i + 3] == 't')
                        {
                            token = new Operator("Root");
                            tokens.Add(token);
                        }
                        else throw new ParserException("INVALID Function");
                    }
                    else throw new ParserException("INVALID FUNCTION");
                    break;
                default:
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