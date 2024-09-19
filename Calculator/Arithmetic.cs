using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
namespace Calculator
{
    public class Arithmetic : Basic6Fun
    {
        public Arithmetic(bool enabledHistory = true) : base(enabledHistory: enabledHistory) { }
        public override string ToString()
        {
            return "Arithmetic Calculator";
        }

        public double Solve(string equation)
        {
            List<Token> RPN = InfixToRPN(Token.ParseEquation(equation));
            Stack<Token> stack = new Stack<Token>();
            history.Pause();
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
            }
            history.Resume();
            Operand result = (Operand)stack.Pop();
            history.AddEntry(equation + " = " + result.Value.ToString());
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
