using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

public class Arithmetic : Basic6Fun
{
    public Arithmetic(bool enabledHistory = true) :base(enabledHistory: enabledHistory) { }
    public override string ToString()
    {
        return "Arithmetic Calculator";
    }

    public virtual double Solve(string equation)
    {
        List<Token> tokens = ParseTokens(equation);
        List<Token> RPN = InfixToRPN(tokens);
        history.Pause();
        while (RPN.Count > 1)
        {
            for (int i = 0; i < RPN.Count; i++)
            {
                Token curr = RPN[i];
                if (curr.GetType() == typeof(Operand)) continue;
                Operator token = (Operator)curr;
                Token newToken;
                Operand aO = (Operand)RPN[i - 2];
                Operand bO = (Operand)RPN[i - 1];
                if (aO.Value == null || bO.Value == null) throw new SolveException("VARIABLES ARE NOT SUPPORTED");
                double a = (double) aO.Value;
                double b = (double) bO.Value;
                switch (token.Name)
                {
                    case "ADD":
                        newToken = new Operand(Add(a, b));
                        break;
                    case "SUBTRACT":
                        newToken = new Operand(Subtract(a, b));
                        break;
                    case "MULTIPLY":
                        newToken = new Operand(Multiply(a, b));
                        break;
                    case "DIVIDE":
                        newToken = new Operand(Divide(a, b));
                        break;
                    case "MODULUS":
                        newToken = new Operand(Mod((int)a, (int)b));
                        break;
                    case "POWER":
                        newToken = new Operand(Power(a, b));
                        break;
                    case "ROOT":
                        newToken = new Operand(Root(a, b));
                        break;
                    default:
                        throw new SolveException("UNKNOWN TOKEN");
                }
                RPN.RemoveAt(i);
                RPN.RemoveAt(i - 1);
                i = i - 2;
                RPN[i]= newToken;
            }
        }
        history.Resume();
        
        Operand result = (Operand)RPN[0];
        history.AddEntry(equation + " = " + result.Value.ToString());
        if (result.Value == null) throw new SolveException("UNKNOWN ERROR");
        return (double) result.Value;
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

    //Shunting yard Algorithm
    //Prase Dijstra
    protected List<Token> InfixToRPN(List<Token> tokens)
    {   
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
                Operator curr = (Operator) token;
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
}

class ParserException : Exception
{
    public ParserException(string message) : base(message) { }
}
class SolveException : Exception
{
    public SolveException(string message) : base(message) { }
}