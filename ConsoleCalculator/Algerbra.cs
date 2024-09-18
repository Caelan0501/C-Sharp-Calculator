using System;
using System.Collections;
using System.Collections.Generic;
using MathNet.Numerics;
using MathNet;


public class Algerbra : Arithmetic
{
    public Algerbra(bool enabledHistory = true) { }

    public override string ToString()
    {
        return "Algerbra Calculator";
    }

    protected List<Token> RPNToInfix(List<Token> RPN)
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
        return ((Term)RPN[0]).GetTokenizedList();
    }
    private Token SimplifyExpression(List<Token> RPN)
    {
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
                if (((Operand)a).Value != null && ((Operand)b).Value != null)
                {

                    double aVal = (double) (((Operand)a).Value.GetValueOrDefault());
                    double bVal = (double) (((Operand)a).Value.GetValueOrDefault());
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
        if (result.GetType() == typeof(Operand)) return result;
        return (Term) result;
    }
    public string Simplify(string equation)
    {
        Token result = SimplifyExpression(InfixToRPN(Token.ParseEquation(equation)));
        if (result.GetType() == typeof(Operand)) return result.Name;
        List<Token> Infix = ((Term) result).GetTokenizedList();

        string simplified = "";
        foreach (Token token in Infix)
        {
            if (token.GetType() == typeof(Operator))
            {
                simplified += ((Operator)token).ShortName;
            }
            else simplified += token.Name;
        }
        return simplified;
    }
    private double SolveVariable(string variable, Token left, Token right)
    {
        if (left.GetType() == typeof(Term))
        {
            Term leftTerm = (Term)left;
            if (leftTerm.Left.GetType() == typeof(Operand))
            {
                Operand a = (Operand)leftTerm.Left;
                if (a.Value == null && a.Name == variable)
                {
                    //a is the variable here
                    Token b = leftTerm.Right;
                    switch (leftTerm.Op.Name)
                    {
                        case "ADD":
                            left = a;
                            right = new Term(right, b, new Operator('-'));
                            break;
                        case "SUBTRACT":
                            left = a;
                            right = new Term(right, b, new Operator('+'));
                            break;
                        case "MULTIPLY":
                            left = a;
                            right = new Term(right, b, new Operator('/'));
                            break;
                        case "DIVIDE":
                            left = a;
                            right = new Term(right, b, new Operator('*'));
                            break;
                    }
                    Term newRight = (Term)right;
                    right = SimplifyExpression(InfixToRPN(newRight.GetTokenizedList()));
                }
            }
            /*
            else if(leftTerm.Right.GetType() == typeof(Operand))
            {
                Operand b = (Operand)leftTerm.Right;
                if(b.Value == null && b.Name == variable)
                {
                    //b is the variable here
                }
            }
            */
        }
        return 0;
    }
    public new string Solve(string equation) 
    {
        if (!equation.Contains("=")) throw new Exception("NO = USED");

        string[] sides = equation.Split('=');
        List<string> variables = new List<string>();
        List<Token> leftTokens = Token.ParseEquation(sides[0]);
        foreach (Token token in leftTokens)
        {
            if (token.GetType() == typeof(Operand))
            {
                Operand a = (Operand)token;
                if (a.Value == null && !variables.Contains(a.Name))
                {
                    variables.Add(a.Name);
                }
            }
        }
        List<Token> rightTokens = Token.ParseEquation(sides[1]);
        foreach (Token token in rightTokens)
        {
            if (token.GetType() == typeof(Operand))
            {
                Operand b = (Operand)token;
                if (b.Value == null && !variables.Contains(b.Name))
                {
                    variables.Add(b.Name);
                }
            }
        }

        Token left = SimplifyExpression(InfixToRPN(leftTokens));
        Token right = SimplifyExpression(InfixToRPN(rightTokens));

        string result = "";
        foreach (string variable in variables)
        {
            result += variable + " = " + SolveVariable(variable, left, right) + "\n";
        }
        return result; //Placeholder
    }
    
}