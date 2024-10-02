using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Diagnostics;
namespace Calculator
{
    public static class Arithmetic
    {
        public static double Solve(string equation) { return BaseSolve(equation, false, out List<string> steps); }
        public static double Solve(string equation, out List<string> steps) { return BaseSolve(equation, true, out steps); }
        private static double BaseSolve(string equation, bool stepbystep, out List<string> steps)
        {
            List<Token> RPN = InfixToRPN(Token.ParseEquation(equation));
            Stack<Token> stack = new Stack<Token>();
            steps = new List<string>();
            if (stepbystep) steps.Add(WriteStep(stack, RPN));
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
                if (stepbystep) steps.Add(WriteStep(stack, RPN));
            }
            Operand result = (Operand)stack.Pop();
            if (result.Value == null) throw new SolveException("UNKNOWN ERROR");
            return (double)result.Value;
        }
        //Shunting yard Algorithm
        //Prase Dijstra
        private static List<Token> InfixToRPN(List<Token> tokens)
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
        private static List<Token> RPNToInfix(List<Token> RPN)
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
        private static string WriteStep(Stack<Token> ogStack, List<Token> ogRPN)
        {
            Stack<Token> stack = new Stack<Token>(ogStack);
            List<Token> RPN = new List<Token>(ogRPN);
            while (stack.Count > 0) RPN.Insert(0, stack.Pop());
            List<Token> Infix = RPNToInfix(RPN);
            string result = "";
            foreach (Token token in Infix)
            {
                if (token.GetType() == typeof(Operator)) result += ((Operator)token).ShortName;
                else result += token.Name;
            }
            return result;
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
