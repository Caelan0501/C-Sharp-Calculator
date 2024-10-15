package calculator;

import java.util.List;
import java.lang.String;

class Formula 
{
	public static double Pythagorean(double a, double b, double c) throws Exception
	{
	    return BasePythagorean(a, b, c);
	}
	public static String Pythagorean(String aS, String bS, String cS) throws Exception
	{
		double a, b, c;
	    a = Double.parseDouble(aS);
	    b = Double.parseDouble(bS);
	    c = Double.parseDouble(cS);
	    return Double.toString(BasePythagorean(a, b, c));
	}
	static Operand Pythagorean (Operand a, Operand b, Operand c) throws Exception
	{
	    return new Operand (BasePythagorean(a.Value, b.Value, c.Value));
	}
	private static double BasePythagorean(double a, double b, double c) throws Exception
	{
	    if (a == Double.NaN && b == Double.NaN || b == Double.NaN && c == Double.NaN || a == Double.NaN && c == Double.NaN) throw new Exception();
	    if (a == Double.NaN)
	    {
	        String equation = "ROOT " + Double.toString(c) + "^2-" + Double.toString(b) + "^2";
	        return Arithmetic.Solve(equation);
	    }
	    else if (b == Double.NaN)
	    {
	        String equation = "ROOT " + Double.toString(c) + "^2-" + Double.toString(a) + "^2";
	        return Arithmetic.Solve(equation);
	    }
	    else if (c == Double.NaN)
	    {
	        String equation = "ROOT " + Double.toString(a) + "^2+" + Double.toString(b) + "^2";
	        return Arithmetic.Solve(equation);
	    }
	    else throw new Exception();
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
    static Operand Sum(Operand[] nums) throws Exception
    {
        Operand sum = new Operand(0);
        for (Operand i : nums)
        {
            sum = new Operand(Function.Add(sum, i));
        }
        return sum;
    }
    public static double Sum(List<Object> nums) throws Exception
    {
    	double sum = 0;
        for (Object i : nums)
        {
        	double x;
        	if (i instanceof Operand) x = ((Operand) i).Value;
        	else if (i instanceof Double) x = (double) i;
        	else throw new Exception();
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
    static Operand Mean(Operand[] nums) throws Exception
    {
        Operand sum = new Operand(0);
        for(Operand i : nums)
        {
            sum = new Operand(Function.Add(sum, i));
        }
        return new Operand(Function.Divide(sum, new Operand(nums.length)));
    }
    public static double Mean(List<Object> nums) throws Exception
    {
        double sum = 0;
        for(Object i : nums)
        {
        	double x;
        	if (i instanceof Operand) x = ((Operand) i).Value;
        	else if (i instanceof Double) x = (double) i;
        	else throw new Exception();
            sum += x;
        }
        return sum / nums.size();
    }
    
    public static double DegreesToRadians(double a)
    {
    	return Function.Multiply(a, Function.Divide(Math.PI, 180));
    }
    public static double RadiansToDegrees(double a)
    {
    	return Function.Multiply(a, Function.Divide(180, Math.PI));
    }
}
