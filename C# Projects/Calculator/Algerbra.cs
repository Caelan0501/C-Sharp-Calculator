using System;
using System.Collections;
using System.Collections.Generic;

namespace Calculator
{
    /// <summary>
    /// Still in Development
    /// </summary>
    public static class Algerbra
    {
        public static string Simplify(string equation)
        {
            Token result = SimplifyExpression(Token.InfixToRPN(Token.ParseEquation(equation)));
            if (result.GetType() == typeof(Operand)) return result.Name;
            List<Token> Infix = ((Term)result).TermToList();

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
        public static string Solve(string equation)
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

            Token left = SimplifyExpression(Token.InfixToRPN(leftTokens));
            Token right = SimplifyExpression(Token.InfixToRPN(rightTokens));

            string result = "";
            foreach (string variable in variables)
            {
                result += SolveVariable(variable, left, right);
            }
            return result;
        }
        

        private static Token SimplifyExpression(List<Token> RPN)
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
                        stack.Push(Function.SmartSolve((Operand)a, (Operand)b, op));
                        continue;
                    }
                }
                stack.Push(new Term(a, b, op));
            }
            return stack.Pop();
        }
        private static List<Token> RemoveParens(List<Token> tokens)
        {
            return tokens;
        }
        private static string SolveVariable(string variable, Token left, Token right)
        {
            left = ZeroRightSide(left, right);
            if (left.GetType() == typeof(Operand) && left.Name == variable) return variable + " = 0\n"; //removes x=0 case
            Term term = (Term)left;
            if (term.Left.GetType() == typeof(Operand))
            {
                right = (Term)term.Left;//Continue working here
            }
            else if (term.Right.GetType() == typeof(Operand))
            {

            }

            return variable + " = " + "" + "\n";
        }
        private static char GetOppositeOp(char op)
        {
            switch (op)
            {
                case '+':
                    return '-';
                case '-':
                    return '+';
                case '*':
                    return '/';
                case '/':
                    return '*';
                default:
                    throw new NotImplementedException();
            }
        }
        private static Token ZeroRightSide(Token left, Token right)
        {
            if (right.GetType() == typeof(Term))
            {
                Term term = (Term)right;
                Operator op = term.Op;
                left = new Term(left, term.Right, new Operator(GetOppositeOp(op.ShortName)));
                return ZeroRightSide(left, term.Right);
            }
            left = new Term(left, right, new Operator('-'));
            return left;
        }
    }
}
