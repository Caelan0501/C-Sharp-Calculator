package calculator;

import java.lang.Math;
import java.lang.String;

public class Function 
{
	static Operand SmartSolve(Operand a, Operand b, Operator op) throws Exception
	{
		switch (op.Name)
		{
		    case "ADD":
		        return Add(a, b);
		    case "SUBTRACT":
		        return Subtract(a, b);
		    case "MULTIPLY":
		        return Multiply(a, b);
		    case "DIVIDE":
		        return Divide(a, b);
		    case "MODULUS":
		        return Mod(a, b);
		    case "POWER":
		        return Power(a, b);
		    case "ROOT":
		        return Root(a, b);
		    default:
		        throw new UnsupportedOperationException();
		}
	}
	
	public static double Add(double a, double b)
	{
	    return a + b;
	}
	public static String Add(String aS, String bS)
	{
		double a = Double.parseDouble(aS);
		double b = Double.parseDouble(bS);
		return Double.toString(a + b);
	}
	static Operand Add(Operand a, Operand b) throws Exception
	{
	    if (a.Value == Double.NaN || b.Value == Double.NaN) throw new Exception();
	    return new Operand((double)a.Value + (double)b.Value);
	}

	public static double Subtract(double a, double b)
	{
	    return a - b; 
	}
	public static String Subtract(String aS, String bS)
	{
		double a = Double.parseDouble(aS);
		double b = Double.parseDouble(bS);
		return Double.toString(a - b);
		
	}
	static Operand Subtract(Operand a, Operand b) throws Exception
    {
        if (a.Value == Double.NaN || b.Value == Double.NaN) throw new Exception();
        return new Operand((double)a.Value - (double)b.Value);
    }
	
	public static double Multiply(double a, double b)
	{
	    return a * b;
	}
	public static String Muliply(String aS, String bS)
	{
		double a = Double.parseDouble(aS);
		double b = Double.parseDouble(bS);
		return Double.toString(a * b);
	}
	static Operand Multiply(Operand a, Operand b) throws Exception
    {
        if (a.Value == Double.NaN || b.Value == Double.NaN) throw new Exception();
        return new Operand((double)a.Value * (double)b.Value);
    }
	
	public static double Divide(double a, double b)
	{
	    if (b == 0) return Double.NaN;
	    return a / b;
	}
	public static String Divide(String aS, String bS)
	{
		double a = Double.parseDouble(aS);
		double b = Double.parseDouble(bS);
		return Double.toString(a / b);
	}
	static Operand Divide(Operand a, Operand b) throws Exception
    {
        if (a.Value == Double.NaN || b.Value == Double.NaN) throw new Exception();
        if (b.Value == 0) throw new Exception();
        return new Operand((double)a.Value / (double)b.Value);
    }
	
	public static int Mod(int a, int b) throws Exception
	{
	    if (b == 0) throw new Exception("Cannot Divide by Zero");
	    return a % b;
	}
	public static String Mod(String aS, String bS) throws Exception
	{
		int a = Integer.parseInt(aS);
		int b = Integer.parseInt(bS);
		if (b == 0) throw new Exception("Cannot Divide by Zero");
		return Integer.toString(a + b);
	}
	static Operand Mod(Operand a, Operand b) throws Exception
    {
        if (a.Value == Double.NaN || b.Value == Double.NaN) throw new Exception();
        if (b.Value == 0) throw new Exception();
        return new Operand((double)a.Value % (double)b.Value);
    }
	
	public static double Power(double a, double b)
	{
	    return Math.pow(a, b);
	}
	public static String Power(String aS, String bS)
	{
		double a = Double.parseDouble(aS);
		double b = Double.parseDouble(bS);
		return Double.toString(Math.pow(a, b));
	}
	static Operand Power(Operand a, Operand b) throws Exception
    {
        if (a.Value == Double.NaN || b.Value == Double.NaN) throw new Exception();
        return new Operand(Math.pow((double)a.Value, (double)b.Value));
    }
	
	public static double Root(double a, double b)
	{
	    return Power(a, Divide(1, b));
	}
	public static String Root(String aS, String bS)
	{
		double a = Double.parseDouble(aS);
		double b = Double.parseDouble(bS);
		return Double.toString(Math.pow(a, Divide(1, b)));
	}
	static Operand Root(Operand a, Operand b) throws Exception
    {
        if (a.Value == Double.NaN || b.Value == Double.NaN) throw new Exception();
        return Power(a, new Operand (Divide(1,(double)b.Value)));
    }
	
	public static double Abs(double a)
	{
	    return Math.abs(a);
	}
	public static String Abs(String a)
	{
		return Double.toString(Math.abs(Double.parseDouble(a)));
	}
	static Operand Abs(Operand a) throws Exception
	{
		if (a.Value == Double.NaN) throw new Exception();
		return new Operand (Math.abs(a.Value));
	}
	
	public static double Sin(double a)
	{
	    return Math.sin(a);
	}
	public static double Sin(double a, boolean degrees)
	{
	    if (degrees) a = Multiply(a, Divide(Math.PI, 180));
	    a = Math.sin(a);
	    if (degrees) a = Multiply(a, Divide(180, Math.PI));
	    return a;
	}
	public static String Sin(String aS)
	{
		return Double.toString(Math.sin(Double.parseDouble(aS)));
	}
	public static String Sin(String aS, boolean degrees)
	{
		double a = Double.parseDouble(aS);	
		if (degrees) a = Multiply(a, Divide(Math.PI, 180));
	    a = Math.sin(a);
	    if (degrees) a = Multiply(a, Divide(180, Math.PI));
		return Double.toString(a);
	}
	static Operand Sin(Operand a) throws Exception
	{
		if (a.Value == Double.NaN) throw new Exception();
		return new Operand (Math.sin(a.Value));
	}
	static Operand Sin(Operand a, boolean degrees) throws Exception
	{
		double x = a.Value;
		if (degrees) x = Multiply(x, Divide(Math.PI, 180));
		if (a.Value == Double.NaN) throw new Exception();
		x = Math.sin(x);
		if (degrees) x = Multiply(x, Divide(180, Math.PI));
		return new Operand(x);
	}
	
	public static double Cos(double a)
    {
    	return Math.cos(a);
    }
    public static double Cos(double a, boolean degrees)
    {
        if (degrees) a = Multiply(a, Divide(Math.PI, 180));
        a = Math.cos(a);
        if (degrees) a = Multiply(a, Divide(180, Math.PI));
        return a;
    }
    public static String Cos(String aS)
	{
		return Double.toString(Math.cos(Double.parseDouble(aS)));
	}
	public static String Cos(String aS, boolean degrees)
	{
		double a = Double.parseDouble(aS);	
		if (degrees) a = Multiply(a, Divide(Math.PI, 180));
	    a = Math.cos(a);
	    if (degrees) a = Multiply(a, Divide(180, Math.PI));
		return Double.toString(a);
	}
	static Operand Cos(Operand a) throws Exception
	{
		if (a.Value == Double.NaN) throw new Exception();
		return new Operand (Math.cos(a.Value));
	}
	static Operand Cos(Operand a, boolean degrees) throws Exception
	{
		double x = a.Value;
		if (degrees) x = Multiply(x, Divide(Math.PI, 180));
		if (a.Value == Double.NaN) throw new Exception();
		x = Math.cos(x);
		if (degrees) x = Multiply(x, Divide(180, Math.PI));
		return new Operand(x);
	}
	
    public static double Tan(double a)
    {
        return Math.tan(a);
    }
    public static double Tan(double a, boolean degrees)
    {
        if (degrees) a = Multiply(a, Divide(Math.PI, 180));
        a = Math.tan(a);
        if (degrees) a = Multiply(a, Divide(180, Math.PI));
        return a;
    }
    public static String Tan(String aS)
	{
		return Double.toString(Math.tan(Double.parseDouble(aS)));
	}
	public static String Tan(String aS, boolean degrees)
	{
		double a = Double.parseDouble(aS);	
		if (degrees) a = Multiply(a, Divide(Math.PI, 180));
	    a = Math.tan(a);
	    if (degrees) a = Multiply(a, Divide(180, Math.PI));
		return Double.toString(a);
	}
	static Operand Tan(Operand a) throws Exception
	{
		if (a.Value == Double.NaN) throw new Exception();
		return new Operand (Math.tan(a.Value));
	}
	static Operand Tan(Operand a, boolean degrees) throws Exception
	{
		double x = a.Value;
		if (degrees) x = Multiply(x, Divide(Math.PI, 180));
		if (a.Value == Double.NaN) throw new Exception();
		x = Math.tan(x);
		if (degrees) x = Multiply(x, Divide(180, Math.PI));
		return new Operand(x);
	}

    public static double Sinh(double a)
    {
        return Math.sinh(a);
    }
    public static double Sinh(double a, boolean degrees)
    {
    	if (degrees) a = Multiply(a, Divide((float)Math.PI, 180));
        a = Math.sinh(a);
        if (degrees) a = Multiply(a, Divide(180, (float)Math.PI));
        return a;
    }
    public static String Sinh(String aS)
	{
		return Double.toString(Math.sinh(Double.parseDouble(aS)));
	}
	public static String Sinh(String aS, boolean degrees)
	{
		double a = Double.parseDouble(aS);	
		if (degrees) a = Multiply(a, Divide(Math.PI, 180));
	    a = Math.sinh(a);
	    if (degrees) a = Multiply(a, Divide(180, Math.PI));
		return Double.toString(a);
	}
	static Operand Sinh(Operand a) throws Exception
	{
		if (a.Value == Double.NaN) throw new Exception();
		return new Operand (Math.sinh(a.Value));
	}
	static Operand Sinh(Operand a, boolean degrees) throws Exception
	{
		double x = a.Value;
		if (degrees) x = Multiply(x, Divide(Math.PI, 180));
		if (a.Value == Double.NaN) throw new Exception();
		x = Math.sinh(x);
		if (degrees) x = Multiply(x, Divide(180, Math.PI));
		return new Operand(x);
	}
	
    public static double Cosh(double a)
    {
        return Math.cosh(a);
    }
    public static double Cosh(double a, boolean degrees)
    {
        if (degrees) a = Multiply(a, Divide(Math.PI, 180));
        a = Math.cosh(a);
        if (degrees) a = Multiply(a, Divide(180, Math.PI));
        return a;
    }
    public static String Cosh(String aS)
	{
		return Double.toString(Math.cosh(Double.parseDouble(aS)));
	}
	public static String Cosh(String aS, boolean degrees)
	{
		double a = Double.parseDouble(aS);	
		if (degrees) a = Multiply(a, Divide(Math.PI, 180));
	    a = Math.cosh(a);
	    if (degrees) a = Multiply(a, Divide(180, Math.PI));
		return Double.toString(a);
	}
	static Operand Cosh(Operand a) throws Exception
	{
		if (a.Value == Double.NaN) throw new Exception();
		return new Operand (Math.cosh(a.Value));
	}
	static Operand Cosh(Operand a, boolean degrees) throws Exception
	{
		double x = a.Value;
		if (degrees) x = Multiply(x, Divide(Math.PI, 180));
		if (a.Value == Double.NaN) throw new Exception();
		x = Math.cosh(x);
		if (degrees) x = Multiply(x, Divide(180, Math.PI));
		return new Operand(x);
	}
	
    public static double Tanh(double a)
    {
        return Math.tanh(a);
    }
    public static double Tanh(double a, boolean degrees)
    {
        if (degrees) a = Multiply(a, Divide(Math.PI, 180));
        a = Math.tanh(a);
        if (degrees) a = Multiply(a, Divide(180, Math.PI));
        return a;
    }
    public static String Tanh(String aS)
	{
		return Double.toString(Math.tanh(Double.parseDouble(aS)));
	}
	public static String Tanh(String aS, boolean degrees)
	{
		double a = Double.parseDouble(aS);	
		if (degrees) a = Multiply(a, Divide(Math.PI, 180));
	    a = Math.tanh(a);
	    if (degrees) a = Multiply(a, Divide(180, Math.PI));
		return Double.toString(a);
	}
	static Operand Tanh(Operand a) throws Exception
	{
		if (a.Value == Double.NaN) throw new Exception();
		return new Operand (Math.tanh(a.Value));
	}
	static Operand Tanh(Operand a, boolean degrees) throws Exception
	{
		double x = a.Value;
		if (degrees) x = Multiply(x, Divide(Math.PI, 180));
		if (a.Value == Double.NaN) throw new Exception();
		x = Math.tanh(x);
		if (degrees) x = Multiply(x, Divide(180, Math.PI));
		return new Operand(x);
	}
	
    public static double Asin(double a)
    {
        return Math.asin(a);
    }
    public static double Asin(double a, boolean degrees)
    {
        if (degrees) a = Multiply(a, Divide(Math.PI, 180));
        a = Math.asin(a);
        if (degrees) a = Multiply(a, Divide(180, Math.PI));
        return a;
    }
    public static String Asin(String aS)
	{
		return Double.toString(Math.asin(Double.parseDouble(aS)));
	}
	public static String Asin(String aS, boolean degrees)
	{
		double a = Double.parseDouble(aS);	
		if (degrees) a = Multiply(a, Divide(Math.PI, 180));
	    a = Math.asin(a);
	    if (degrees) a = Multiply(a, Divide(180, Math.PI));
		return Double.toString(a);
	}
	static Operand Asin(Operand a) throws Exception
	{
		if (a.Value == Double.NaN) throw new Exception();
		return new Operand (Math.asin(a.Value));
	}
	static Operand Asin(Operand a, boolean degrees) throws Exception
	{
		double x = a.Value;
		if (degrees) x = Multiply(x, Divide(Math.PI, 180));
		if (a.Value == Double.NaN) throw new Exception();
		x = Math.asin(x);
		if (degrees) x = Multiply(x, Divide(180, Math.PI));
		return new Operand(x);
	}
	
    public static double Acos(double a)
    {
        return Math.acos(a);
    }
    public static double Acos(double a, boolean degrees)
    {
        if (degrees) a = Multiply(a, Divide(Math.PI, 180));
        a = Math.acos(a);
        if (degrees) a = Multiply(a, Divide(180, Math.PI));
        return a;
    }
    public static String Acos(String aS)
	{
		return Double.toString(Math.acos(Double.parseDouble(aS)));
	}
	public static String Acos(String aS, boolean degrees)
	{
		double a = Double.parseDouble(aS);	
		if (degrees) a = Multiply(a, Divide(Math.PI, 180));
	    a = Math.acos(a);
	    if (degrees) a = Multiply(a, Divide(180, Math.PI));
		return Double.toString(a);
	}
	static Operand Acos(Operand a) throws Exception
	{
		if (a.Value == Double.NaN) throw new Exception();
		return new Operand (Math.acos(a.Value));
	}
	static Operand Acos(Operand a, boolean degrees) throws Exception
	{
		double x = a.Value;
		if (degrees) x = Multiply(x, Divide(Math.PI, 180));
		if (a.Value == Double.NaN) throw new Exception();
		x = Math.acos(x);
		if (degrees) x = Multiply(x, Divide(180, Math.PI));
		return new Operand(x);
	}
	
	public static double Atan(double a)
	{
		return Math.atan(a);
	}
	public static double Atan(double a, boolean degrees)
    {
        if (degrees) a = Multiply(a, Divide(Math.PI, 180));
        a = Math.atan(a);
        if (degrees) a = Multiply(a, Divide(180, Math.PI));
        return a;
    }
    public static String Atan(String aS)
	{
		return Double.toString(Math.atan(Double.parseDouble(aS)));
	}
	public static String Atan(String aS, boolean degrees)
	{
		double a = Double.parseDouble(aS);	
		if (degrees) a = Multiply(a, Divide(Math.PI, 180));
	    a = Math.atan(a);
	    if (degrees) a = Multiply(a, Divide(180, Math.PI));
		return Double.toString(a);
	}
	static Operand Atan(Operand a) throws Exception
	{
		if (a.Value == Double.NaN) throw new Exception();
		return new Operand (Math.atan(a.Value));
	}
	static Operand Atan(Operand a, boolean degrees) throws Exception
	{
		double x = a.Value;
		if (degrees) x = Multiply(x, Divide(Math.PI, 180));
		if (a.Value == Double.NaN) throw new Exception();
		x = Math.atan(x);
		if (degrees) x = Multiply(x, Divide(180, Math.PI));
		return new Operand(x);
	}
	
	public static double Asinh(double a)
	{
		return Math.log(a + Math.sqrt(a * a + 1));
	}
	public static String Asinh(String aS)
	{
		double a = Double.parseDouble(aS);
		return Double.toString( Math.log(a + Math.sqrt(a * a + 1)));
	}
	public static double Asinh(double a, boolean degrees)
	{
		if (degrees) a = Multiply(a, Divide(Math.PI, 180));
        a = Math.log(a + Math.sqrt(a * a + 1));
        if (degrees) a = Multiply(a, Divide(180, Math.PI));
        return a;
	}
	public static String Asinh(String aS, boolean degrees)
	{
		double a = Double.parseDouble(aS);
		if (degrees) a = Multiply(a, Divide(Math.PI, 180));
        a = Math.log(a + Math.sqrt(a * a + 1));
        if (degrees) a = Multiply(a, Divide(180, Math.PI));
        return Double.toString(a);
	}
	static Operand Asinh(Operand a) throws Exception
	{
		if (a.Value == Double.NaN) throw new Exception();
		return new Operand(Math.log(a.Value + Math.sqrt(a.Value * a.Value + 1)));
	}
	static Operand Asinh(Operand a, boolean degrees) throws Exception
	{
		double x = a.Value;
		if (degrees) x = Multiply(x, Divide(Math.PI, 180));
		if (a.Value == Double.NaN) throw new Exception();
		x = Math.log(x + Math.sqrt(x * x + 1));
		if (degrees) x = Multiply(x, Divide(180, Math.PI));
		return new Operand(x);
	}
	
	public static double Acosh(double a)
	{
		if (a < 1) return Double.NaN;
		return Math.log(a + Math.sqrt(a * a - 1));
	}
	public static String Acosh(String aS)
	{
		double a = Double.parseDouble(aS);
		if (a < 1) return Double.toString(Double.NaN);
		return Double.toString(Math.log(a + Math.sqrt(a * a - 1)));
	}
	public static double Acosh(double a, boolean degrees)
	{
		if (degrees) a = Multiply(a, Divide(Math.PI, 180));
		if (a < 1) return Double.NaN;
        a = Math.log(a + Math.sqrt(a * a - 1));
        if (degrees) a = Multiply(a, Divide(180, Math.PI));
        return a;
	}
	public static String Acosh(String aS, boolean degrees)
	{
		double a = Double.parseDouble(aS);
		if (degrees) a = Multiply(a, Divide(Math.PI, 180));
		if (a < 1) return Double.toString(Double.NaN);
        a = Math.log(a + Math.sqrt(a * a - 1));
        if (degrees) a = Multiply(a, Divide(180, Math.PI));
        return Double.toString(a);
	}
	static Operand Acosh(Operand a) throws Exception
	{
		if (a.Value == Double.NaN) throw new Exception();
		return new Operand(Math.log(a.Value + Math.sqrt(a.Value * a.Value - 1)));
	}
	static Operand Acosh(Operand a, boolean degrees) throws Exception
	{
		double x = a.Value;
		if (degrees) x = Multiply(x, Divide(Math.PI, 180));
		if (a.Value == Double.NaN || a.Value < 1) throw new Exception();
		x = Math.log(x + Math.sqrt(x * x - 1));
		if (degrees) x = Multiply(x, Divide(180, Math.PI));
		return new Operand(x);
	}
	
	public static double Atanh(double a) 
	{
	    return 0.5 * Math.log((1 + a) / (1 - a));
	}
	public static String Atanh(String aS)
	{
		double a = Double.parseDouble(aS);
		return Double.toString( 0.5 * Math.log((1 + a) / (1 - a)));
	}
	public static double Atanh(double a, boolean degrees)
	{
		if (degrees) a = Multiply(a, Divide(Math.PI, 180));
        a = 0.5 * Math.log((1 + a) / (1 - a));
        if (degrees) a = Multiply(a, Divide(180, Math.PI));
        return a;
	}
	public static String Atanh(String aS, boolean degrees)
	{
		double a = Double.parseDouble(aS);
		if (degrees) a = Multiply(a, Divide(Math.PI, 180));
        a = 0.5 * Math.log((1 + a) / (1 - a));
        if (degrees) a = Multiply(a, Divide(180, Math.PI));
        return Double.toString(a);
	}
	static Operand Atanh(Operand a) throws Exception
	{
		if (a.Value == Double.NaN) throw new Exception();
		return new Operand(0.5 * Math.log((1 + a.Value) / (1 - a.Value)));
	}
	static Operand Atanh(Operand a, boolean degrees) throws Exception
	{
		double x = a.Value;
		if (degrees) x = Multiply(x, Divide(Math.PI, 180));
		if (a.Value == Double.NaN) throw new Exception();
		x = 0.5 * Math.log((1 + x) / (1 - x));
		if (degrees) x = Multiply(x, Divide(180, Math.PI));
		return new Operand(x);
	}
	
    public static double Ln(double a)
    {
        return Math.log(a);
    }
    public static String Ln(String aS)
    {
    	double a = Double.parseDouble(aS);
    	return Double.toString(Math.log(a));
    }
    static Operand Ln(Operand a)
    {
    	return new Operand(Math.log(a.Value));
    }
    public static double Log(double a)
    {
    	return Math.log(a);
    }
    public static String Log(String a)
    {
    	return Double.toString(Math.log(Double.parseDouble(a)));
    }
    static Operand Log(Operand a) throws Exception
    {
    	if (a.Value == Double.NaN) throw new Exception();
    	return new Operand(Math.log(a.Value));
    }
    public static double Log(double a, double b)
    {
    	return Ln(a) / Ln(b);
    }
    public static String Log(String a, String b)
    {
    	return Divide(Ln(a), Ln(b));
    }
    static Operand Log(Operand a, Operand b) throws Exception
    {
    	return Divide(Ln(a), Ln(b));
    }
}
