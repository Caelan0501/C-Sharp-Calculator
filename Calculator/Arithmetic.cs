using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
namespace Calculator
{
    public class Arithmetic
    {
        public double Solve(string equation)
        {
            List<Token> RPN = InfixToRPN(Token.ParseEquation(equation));
            Stack<Token> stack = new Stack<Token>();
            foreach (Token token in RPN)
            {
                if (token.GetType() == typeof(Operand))
                {
                    stack.Push(token);
                    continue;
                }
                Operator op = (Operator)token;
                Operand b = (Operand)stack.Pop();
                Operand a = (Operand)stack.Pop();
                if (a.Value == null || b.Value == null) throw new SolveException("Variables not suported");
                double aVal = (double)a.Value;
                double bVal = (double)b.Value;
                switch (op.Name)
                {
                    case "ADD":
                        stack.Push(new Operand(Function.Add(aVal, bVal)));
                        break;
                    case "SUBTRACT":
                        stack.Push(new Operand(Function.Subtract(aVal, bVal)));
                        break;
                    case "MULTIPLY":
                        stack.Push(new Operand(Function.Multiply(aVal, bVal)));
                        break;
                    case "DIVIDE":
                        stack.Push(new Operand(Function.Divide(aVal, bVal)));
                        break;
                    case "MODULUS":
                        stack.Push(new Operand(Function.Mod((int)aVal, (int)bVal)));
                        break;
                    case "POWER":
                        stack.Push(new Operand(Function.Power(aVal, bVal)));
                        break;
                    case "ROOT":
                        stack.Push(new Operand(Function.Root(aVal, bVal)));
                        break;
                    default:
                        throw new SolveException("UNKNOWN TOKEN");
                }
            }
            Operand result = (Operand)stack.Pop();
            if (result.Value == null) throw new SolveException("UNKNOWN ERROR");
            return (double)result.Value;
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
    }

    class ParserException : Exception
    {
        public ParserException(string message) : base(message) { }
    }
    class SolveException : Exception
    {
        public SolveException(string message) : base(message) { }
    }
}
