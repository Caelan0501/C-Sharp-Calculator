package calculator;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.lang.String;
import java.lang.reflect.Array;

class Formula 
{
	private static double StringToDouble(String s)
	{
		try
		{
			return Double.parseDouble(s);
		}
		catch (Exception e) 
		{
			return Double.NaN;
		}
	}
	
	public static double Pythagorean(double a, double b, double c)
	{
		if (a == Double.NaN && b == Double.NaN || b == Double.NaN && c == Double.NaN || a == Double.NaN && c == Double.NaN) 
			throw new IllegalArgumentException("Both Parameters must be a number");
	    
		Token[] equation = 
		{
			new Operator("ROOT"), new Operator('('), 
			null, new Operator('^'), new Operand(2), 
			null, 
			null, new Operator('^'), new Operand(2), 
			new Operator(')'), new Operand(2)
		};
		if (c == Double.NaN)
	    {
			equation[2] = new Operand(a);
			equation[5] = new Operator('+');
			equation[6] = new Operand(b);
	    }
		else if (a == Double.NaN || b == Double.NaN)
	    {
			equation[2] = new Operand(c);
			equation[5] = new Operator('-');
	        if (a == Double.NaN) equation[6] = new Operand(b);
	        else if (b == Double.NaN) equation[6] = new Operand(a);
	    }
		return Arithmetic.Solve(Arrays.asList(equation)).Value;
	}
	public static String Pythagorean(String aS, String bS, String cS)
	{
		double a, b, c;
	    a = StringToDouble(aS);
	    b = StringToDouble(bS);
	    c = StringToDouble(cS);
	    return Double.toString(Pythagorean(a, b, c));
	}
	static Operand Pythagorean (Operand a, Operand b, Operand c)
	{
	    return new Operand(Pythagorean(a.Value, b.Value, c.Value));
	}
	
    public static double Sum(double[] nums)
    {
        double sum = 0;
        for (double i : nums)
        {
            sum += i;
        }
        return sum;
    }
    static Operand Sum(Operand[] nums)
    {
        Operand sum = new Operand(0);
        for (Operand i : nums)
        {
            sum = new Operand(Function.Add(sum, i));
        }
        return sum;
    }
    public static double Sum(List<Object> nums)
    {
    	double sum = 0;
        for (Object i : nums)
        {
        	double x;
        	if (i instanceof Operand) x = ((Operand) i).Value;
        	else if (i instanceof Double) x = (double) i;
        	else throw new UnsupportedOperationException();
            sum += x;
        }
        return sum;
    }
    
    public static double Mean(double[] nums)
    {
        double sum = 0;
        for(double i : nums)
        {
            sum += i;
        }
        return sum / nums.length;
    }
    static Operand Mean(Operand[] nums)
    {
        Operand sum = new Operand(0);
        for(Operand i : nums)
        {
            sum = new Operand(Function.Add(sum, i));
        }
        return new Operand(Function.Divide(sum, new Operand(nums.length)));
    }
    public static double Mean(List<Object> nums)
    {
        double sum = 0;
        for(Object i : nums)
        {
        	double x;
        	if (i instanceof Operand) x = ((Operand) i).Value;
        	else if (i instanceof Double) x = (double) i;
        	else throw new UnsupportedOperationException();
            sum += x;
        }
        return sum / nums.size();
    }
}
