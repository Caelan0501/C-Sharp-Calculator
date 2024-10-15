package calculator;

import java.lang.String;
import java.util.ArrayList;
import java.util.List;

abstract class Token 
{
	String Name;
	
	Token()
	{
		Name = "UNDEFINED";
	}
	
	static List<Token> ParseEquation(String equation) throws ParserException
	{
		List<Token> tokens = new ArrayList<Token>();
		int openParen = 0;
		Token token;
		for (int i = 0; i < equation.length(); i++)
		{
			switch (equation.charAt(i))
			{
			case ' ':
			case '\t':
			case '\r':
			case '\f':
				break;
			case '(':
			    token = new Operator('(');
			    tokens.add(token);
			    openParen++;
			    break;
			case ')':
			    token = new Operator(')');
			    tokens.add(token);
			    openParen--;
			    break;
			case '+':
			case '-':
			case '*':
			case '×':
			case '/':
			case '%':
			case '√':
			case '÷':
			case '^':
			    token = new Operator(equation.charAt(i));
			    tokens.add(token);
			    break;
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
			case '.':
			    String number = Character.toString(equation.charAt(i));
			    boolean decimalUsed = equation.charAt(i) == '.';
			    while (i + 1 < equation.length())
			    {
			        if (!(equation.charAt(i + 1) == '.' || Character.isDigit(equation.charAt(i + 1)))) break;
			        if (decimalUsed && equation.charAt(i + 1) == '.') throw new ParserException("Multiple Decimals where used");
			        i++;
			        number += equation.charAt(i);
			    }
			    token = new Operand(Double.parseDouble(number));
			    tokens.add(token);
			    break;
			default:
			    String s = "";
			    int x = 0;
			    while (Character.isLetter(equation.charAt(i + x)))
			    {
			        s += equation.charAt(i + x);
			        if (i + x + 1 >= equation.length()) break;
			        x++;
			    }
			    switch (s)
			    {
			        case "Root":
			            token = new Operator("Root");
			            tokens.add(token);
			            break;
			        default:
			            token = new Operand(s);
			            tokens.add(token);
			            break;
			    }
			    i = i + s.length() - 1;
			    break;
				
			
			}
		}
		if (openParen != 0) throw new ParserException("PARENTHESIS NOT CLOSED");
		return tokens;
	}
	static List<Token> InfixToRPN(List<Token> tokens)
	{
		return new ArrayList<Token>();
	}
	static List<Token> RPNToInfix(List<Token> RPN)
	{
		return new ArrayList<Token>();
	}
	
	static class ParserException extends Exception
	{
		private static final long serialVersionUID = 1L;
		ParserException() { super(); }
		ParserException(String message) { super(message); }
	}
}

class Operand extends Token
{
	double Value;
	Operand(double num)
	{
	    Name = Double.toString(num);
	    Value = num;
	}
	Operand(String variable)
	{
	    Name = variable;
	    Value = Double.NaN;
	}
	Operand(Operand operand)
	{
	    this.Name = operand.Name;
	    this.Value = operand.Value;
	}
}

class Operator extends Token
{
	int Precedence = -1;
    char Associativity = 'N';
    char ShortName;
    
    Operator(char symbol)
    {
        switch (symbol)
        {
            case '+':
                Name = "ADD";
                ShortName = '+';
                Precedence = 2;
                Associativity = 'L';
                break;
            case '-':
                Name = "SUBTRACT";
                ShortName = '-';
                Precedence = 2;
                Associativity = 'L';
                break;
            case '*':
            case '×':
                Name = "MULTIPLY";
                ShortName = '*';
                Precedence = 3;
                Associativity = 'L';
                break;
            case '/':
            case '÷':
                Name = "DIVIDE";
                ShortName = '/';
                Precedence = 3;
                Associativity = 'L';
                break;
            case '%':
                Name = "MODULUS";
                ShortName = '%';
                Precedence = 3;
                Associativity = 'L';
                break;
            case '^':
                Name = "POWER";
                ShortName = '^';
                Precedence = 4;
                Associativity = 'R';
                break;
            case '√':
                Name = "ROOT";
                ShortName = '√';
                Precedence = 4;
                Associativity = 'L';
                break;
            case '(':
                Name = "LPAREN";
                ShortName = '(';
                break;
            case ')':
                Name = "RPAREN";
                ShortName = ')';
                break;
            case '=':
                Name = "EQUAL";
                ShortName = '=';
                break;
            default:
                Name = "ERROR";
                ShortName = 'E';
                break;
        }
    }

    Operator(String function)
    {
        function = function.toUpperCase();
        switch (function)
        {
            case "ROOT":
                Name = "ROOT";
                ShortName = '√';
                Precedence = 4;
                Associativity = 'L';
                break;
            default:
                Name = "ERROR";
                ShortName = 'E';
                break;
        }
    }
}

class Term extends Token
{
	Token Left;
    Token Right;
    Operator Op;
    
    Term(Token Left, Token Right, Operator Op)
    {
        if (Left instanceof Term) Name = "(" + Left.Name + ")";
        else Name = Left.Name;
        Name += Op.Name;
        if (Right instanceof Term) Name = "(" + Right.Name + ")";
        else Name = Right.Name;

        this.Left = Left;
        this.Right = Right;
        this.Op = Op;
    }
    
    List<Token> TermToList() throws TermException
    {
        List<Token> tokens = new ArrayList<Token>();
        if (Left instanceof Operand) tokens.add(Left);
        else if (Left instanceof Term)
        {
            tokens.add(new Operator('('));
            tokens.addAll(TermToList((Term)Left));
            tokens.add(new Operator(')'));
        }
        else throw new TermException("MISPLACED OPERATOR");

        tokens.add(Op);

        if (Right instanceof Operand) tokens.add(Right);
        else if (Right instanceof Term)
        {
            tokens.add(new Operator('('));
            tokens.addAll(TermToList((Term)Right));
            tokens.add(new Operator(')'));
        }
        else throw new TermException("MISPLACED OPERATOR");

        return tokens;
    }
    private List<Token> TermToList(Term curr) throws TermException
    {
        List<Token> tokens = new ArrayList<Token>();

        if (curr.Left instanceof Operand) tokens.add(curr.Left);
        else if (curr.Left instanceof Term)
        {
            tokens.add(new Operator('('));
            tokens.addAll(TermToList((Term)curr.Left));
            tokens.add(new Operator(')'));
        }
        else throw new TermException("MISPLACED OPERATOR");

        tokens.add(curr.Op);

        if (curr.Right instanceof Operand) tokens.add(curr.Right);
        else if (curr.Right instanceof Term)
        {
            tokens.add(new Operator('('));
            tokens.addAll(TermToList((Term)curr.Right));
            tokens.add(new Operator(')'));
        }
        else throw new TermException("MISPLACED OPERATOR");

        return tokens;
    }
    
    class TermException extends Exception
    {
		private static final long serialVersionUID = 1L;

		TermException() { super(); }
    	
        TermException(String message) { super(message); }
    }
}