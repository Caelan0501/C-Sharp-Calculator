using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Diagnostics;
namespace Calculator
{
    public static class Arithmetic
    {
        public static double Solve(string equation) 
        { 
            return BaseSolve(Token.ParseEquation(equation), false, out List<string> steps); 
        }
        public static double Solve(string equation, out List<string> steps) 
        { 
            return BaseSolve(Token.ParseEquation(equation), true, out steps); 
        }
        internal static Operand Solve(List<Token> equation)
        {
            return new Operand(BaseSolve(equation, false, out List<string> steps));
        }

        private static double BaseSolve(List<Token> equation, bool stepbystep, out List<string> steps)
        {
            List<Token> RPN = Token.InfixToRPN(equation);
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
                stack.Push(Function.SmartSolve(a, b, op));
                if (stepbystep) steps.Add(WriteStep(stack, RPN));
            }
            Operand result = (Operand)stack.Pop();
            Debug.Assert(result.Value != null);
            return (double)result.Value;
        }
        private static string WriteStep(Stack<Token> ogStack, List<Token> ogRPN)
        {
            Stack<Token> stack = new Stack<Token>(ogStack);
            List<Token> RPN = new List<Token>(ogRPN);
            while (stack.Count > 0) RPN.Insert(0, stack.Pop());
            List<Token> Infix = Token.RPNToInfix(RPN);
            string result = "";
            foreach (Token token in Infix)
            {
                if (token.GetType() == typeof(Operator)) result += ((Operator)token).ShortName;
                else result += token.Name;
            }
            return result;
        }
    }
}
