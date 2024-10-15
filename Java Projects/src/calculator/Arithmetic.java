package calculator;

import java.lang.String;
import java.util.List;
import java.util.Stack;

public class Arithmetic 
{
	public static double Solve(String equation) throws Token.ParserException
	{
		return BaseSolve(Token.ParseEquation(equation)); 
	}
	static Operand Solve(List<Token> equation)
    {
        return new Operand(BaseSolve(equation));
    }
	private static double BaseSolve(List<Token> equation)
	{
		List<Token> RPN = Token.InfixToRPN(equation);
		Stack<Token> stack = new Stack<Token>();
		for (Token token : RPN)
		{
		    if (token instanceof Operand)
		    {
		        stack.push(token);
		        continue;
		    }
		    Operator op = (Operator)token;
		    Operand b = (Operand)stack.pop();
		    Operand a = (Operand)stack.pop();
		    stack.push(Function.SmartSolve(a, b, op));
		}
		Operand result = (Operand)stack.pop();
		return (double)result.Value;
	}
}
