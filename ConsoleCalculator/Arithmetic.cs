using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class Arithmetic : Basic6Fun
{
    public Arithmetic(bool enabledHistory = true) :base(enabledHistory: enabledHistory)
    {
    }
    public override string ToString()
    {
        return "Arithmetic Calculator";
    }

    public double? Solve(string equation)
    {
        List<string>? tokens = ParseTokens(equation);
        if (tokens == null) return null;
        InfixToRNC(tokens);
        


        return 0;
    }
    private List<string>? ParseTokens(string equation)
    {
        List<string> tokens = new List<string>();
        bool status = true;
        int openParen = 0;
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
                    tokens.Add(number);
                    break;
                case '+':
                    tokens.Add("+");
                    break;
                case '-':
                    tokens.Add("-");
                    break;
                case '*':
                    tokens.Add("*");
                    break;
                case '/':
                    tokens.Add("/");
                    break;
                case '%':
                    tokens.Add("%");
                    break;
                case '^':
                    tokens.Add("^");
                    break;
                case '(':
                    tokens.Add("(");
                    openParen++;
                    break;
                case ')':
                    tokens.Add(")");
                    openParen--;
                    break;
                case 'R':
                    if (i + 3 < equation.Length)
                    {
                        if (equation[i + 1] == 'o' && equation[i + 2] == 'o' && equation[i + 3] == 't')
                        {
                            tokens.Add("Root");
                        }
                        else
                        {
                            status = false;
                        }
                    }
                    else
                    {
                        status = false;
                    }
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
    private void InfixToRNC(List<string> tokens)
    {   
        Stack<string> operatorStack = new Stack<string>();
        List<string> RNC = new List<string>();
        foreach (string token in tokens)
        {
            switch (token)
            {
                case "(":
                    operatorStack.Push(token);
                    break;
                case ")":
                    break;
                case "+":
                    string top = operatorStack.Peek();

                    int topPrecedence = -1;
                    if (top == "+" || top == "-") topPrecedence = 2;
                    else if (top == "*" || top == "/" || top == "%") topPrecedence = 3;
                    else if (top == "^" || top == "Root") topPrecedence = 4;
                    while (top != ")" && topPrecedence >= 2)
                    {
                        RNC.Add(operatorStack.Pop());
                    }
                    operatorStack.Push(token);
                    break;
                case "-":
                    operatorStack.Push(token);
                    break;
                case "*":
                    operatorStack.Push(token);
                    break;
                case "/":
                    operatorStack.Push(token);
                    break;
                case "%":
                    operatorStack.Push(token);
                    break;
                case "Root":
                    operatorStack.Push(token);
                    break;
                case "^":
                    operatorStack.Push(token);
                    break;
                default:
                    //Is number
                    RNC.Add(token);
                    break;
            }
        }
    }
}
