package calculator;

import java.lang.Math;
import java.lang.String;

public class Function 
{
	public static int Add(int a, int b)
	{
		return a + b;
	}
	public static double Add(double a, double b)
	{
	    return a + b;
	}
	public static float Add(float a, float b)
	{
	    return a + b;
	}
	public static String Add(String aS, String bS)
	{
		double a = Double.parseDouble(aS);
		double b = Double.parseDouble(bS);
		return Double.toString(a + b);
	}
	

	public static int Subtract(int a, int b)
	{
	    return a - b;
	}
	public static double Subtract(double a, double b)
	{
	    return a - b; 
	}
	public static float Subtract(float a, float b)
	{
	    return a - b;
	}
	public static String Subtract(String aS, String bS)
	{
		double a = Double.parseDouble(aS);
		double b = Double.parseDouble(bS);
		return Double.toString(a - b);
		
	}
	
	
	public static int Multiply(int a, int b)
	{
	    return a * b;
	}
	public static double Multiply(double a, double b)
	{
	    return a * b;
	}
	public static float Multiply(float a, float b)
	{
	    return a * b;
	}
	public static String Muliply(String aS, String bS)
	{
		double a = Double.parseDouble(aS);
		double b = Double.parseDouble(bS);
		return Double.toString(a * b);
	}
	
	public static int Divide(int a, int b) throws Exception
	{
	    if (b == 0) throw new Exception("Cannot Divide by Zero");
	    return a / b;
	}
	public static double Divide(double a, double b)
	{
	    if (b == 0) return Double.NaN;
	    return a / b;
	}
	public static float Divide(float a, float b)
	{
	    if (b == 0) return Float.NaN;
	    return a / b;
	}
	public static String Divide(String aS, String bS)
	{
		double a = Double.parseDouble(aS);
		double b = Double.parseDouble(bS);
		return Double.toString(a / b);
		
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
	
	public static int Power(int a, int b)
	{
		return (int) Math.pow( a, b );
	}
	public static double Power(double a, double b)
	{
	    return Math.pow(a, b);
	}
	public static float Power(float a, float b)
	{
	    return (float)Math.pow(a, b);
	}
	public static String Power(String aS, String bS)
	{
		double a = Double.parseDouble(aS);
		double b = Double.parseDouble(bS);
		return Double.toString(Math.pow(a, b));
	}
	
	public static int Root(int a, int b) throws Exception
	{
	    return Power(a, Divide(1, b));
	}
	public static double Root(double a, double b)
	{
	    return Power(a, Divide(1, b));
	}
	public static float Root(float a, float b)
	{
	    return Power(a, Divide(1, b));
	}
	public static String Root(String aS, String bS)
	{
		double a = Double.parseDouble(aS);
		double b = Double.parseDouble(bS);
		return Double.toString(Math.pow(a, Divide(1, b)));
	}
	
	public static int Abs(int a)
	{
	    return Math.abs(a);
	}
	public static double Abs(double a)
	{
	    return Math.abs(a);
	}
	public static float Abs(float a)
	{
	    return Math.abs(a);
	}
	public static String Abs(String a)
	{
		return Double.toString(Math.abs(Double.parseDouble(a)));
	}
	
	public static double Sin(double a)
	{
	    return Math.sin(a);
	}
	public static float Sin(float a)
	{
	    return (float )Math.sin(a);
	}
	public static double Sin(double a, boolean degrees)
	{
	    if (degrees) a = Multiply(a, Divide(Math.PI, 180));
	    a = Math.sin(a);
	    if (degrees) a = Multiply(a, Divide(180, Math.PI));
	    return a;
	}
	public static float Sin(float a, boolean degrees)
	{
	    if (degrees) a = Multiply(a, Divide((float)Math.PI, 180));
	    Math.sin(a);
	    if (degrees) a = Multiply(a, Divide(180, (float)Math.PI));
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
    
	public static double Cos(double a)
    {
    	return Math.cos(a);
    }
    public static float Cos(float a)
    {
    	return (float) Math.cos(a);
    }
    public static double Cos(double a, boolean degrees)
    {
        if (degrees) a = Multiply(a, Divide(Math.PI, 180));
        a = Math.cos(a);
        if (degrees) a = Multiply(a, Divide(180, Math.PI));
        return a;
    }
    public static float Cos(float a, boolean degrees)
    {
        if (degrees) a = Multiply(a, Divide((float)Math.PI, 180));
        a = (float) Math.cos(a);
        if (degrees) a = Multiply(a, Divide(180, (float)Math.PI));
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
    
    public static double Tan(double a)
    {
        return Math.tan(a);
    }
    public static float Tan(float a)
    {
        return (float)Math.tan(a);
    }
    public static double Tan(double a, boolean degrees)
    {
        if (degrees) a = Multiply(a, Divide(Math.PI, 180));
        a = Math.tan(a);
        if (degrees) a = Multiply(a, Divide(180, Math.PI));
        return a;
    }
    public static float Tan(float a, boolean degrees)
    {
        if (degrees) a = Multiply(a, Divide((float)Math.PI, 180));
        a = (float)Math.tan(a);
        if (degrees) a = Multiply(a, Divide(180, (float)Math.PI));
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
    
    public static double Sinh(double a)
    {
        return Math.sinh(a);
    }
    public static float Sinh(float a)
    {
    	return (float)Math.sinh(a);
    }
    public static double Sinh(double a, boolean degrees)
    {
    	if (degrees) a = Multiply(a, Divide((float)Math.PI, 180));
        a = Math.sinh(a);
        if (degrees) a = Multiply(a, Divide(180, (float)Math.PI));
        return a;
    }
    public static float Sinh(float a, boolean degrees)
    {
        if (degrees) a = Multiply(a, Divide((float)Math.PI, 180));
        a = (float) Math.sinh(a);
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
    
    public static double Cosh(double a)
    {
        return Math.cosh(a);
    }
    public static float Cosh(float a)
    {
        return (float) Math.cosh(a);
    }
    public static double Cosh(double a, boolean degrees)
    {
        if (degrees) a = Multiply(a, Divide(Math.PI, 180));
        a = Math.cosh(a);
        if (degrees) a = Multiply(a, Divide(180, Math.PI));
        return a;
    }
    public static float Cosh(float a, boolean degrees)
    {
        if (degrees) a = Multiply(a, Divide((float)Math.PI, 180));
        a = (float) Math.cosh(a);
        if (degrees) a = Multiply(a, Divide(180, (float)Math.PI));
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
    
    public static double Tanh(double a)
    {
        return Math.tanh(a);
    }
    public static float Tanh(float a)
    {
        return (float) Math.tanh(a);
    }
    public static double Tanh(double a, boolean degrees)
    {
        if (degrees) a = Multiply(a, Divide(Math.PI, 180));
        a = Math.tanh(a);
        if (degrees) a = Multiply(a, Divide(180, Math.PI));
        return a;
    }
    public static float Tanh(float a, boolean degrees)
    {
        if (degrees) a = Multiply(a, Divide((float)Math.PI, 180));
        a = (float) Math.tanh(a);
        if (degrees) a = Multiply(a, Divide(180, (float)Math.PI));
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
    
    public static double Asin(double a)
    {
        return Math.asin(a);
    }
    public static float Asin(float a)
    {
        return (float) Math.asin(a);
    }
    public static double Asin(double a, boolean degrees)
    {
        if (degrees) a = Multiply(a, Divide(Math.PI, 180));
        a = Math.asin(a);
        if (degrees) a = Multiply(a, Divide(180, Math.PI));
        return a;
    }
    public static float Asin(float a, boolean degrees)
    {
        if (degrees) a = Multiply(a, Divide((float)Math.PI, 180));
        a = (float) Math.asin(a);
        if (degrees) a = Multiply(a, Divide(180, (float)Math.PI));
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
    
    public static double Acos(double a)
    {
        return Math.acos(a);
    }
    public static float Acos(float a)
    {
        return (float) Math.acos(a);
    }
    public static double Acos(double a, boolean degrees)
    {
        if (degrees) a = Multiply(a, Divide(Math.PI, 180));
        a = Math.acos(a);
        if (degrees) a = Multiply(a, Divide(180, Math.PI));
        return a;
    }
    public static float Acos(float a, boolean degrees)
    {
        if (degrees) a = Multiply(a, Divide((float)Math.PI, 180));
        a = (float) Math.acos(a);
        if (degrees) a = Multiply(a, Divide(180, (float)Math.PI));
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
    
    public static double Atan(double a, boolean degrees)
    {
        if (degrees) a = Multiply(a, Divide(Math.PI, 180));
        a = Math.atan(a);
        if (degrees) a = Multiply(a, Divide(180, Math.PI));
        return a;
    }
    public static float Atan(float a, boolean degrees)
    {
        if (degrees) a = Multiply(a, Divide((float)Math.PI, 180));
        a = (float) Math.atan(a);
        if (degrees) a = Multiply(a, Divide(180, (float)Math.PI));
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
    
	public static double Asinh(double a)
	{
		return Math.log(a + Math.sqrt(a * a + 1));
	}
	public static float Asinh(float a)
	{
		return (float) Math.log(a + Math.sqrt(a * a + 1));
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
	public static float Asinh(float x, boolean degrees)
	{
		double a = x;
		if (degrees) a = Multiply(a, Divide(Math.PI, 180));
        a = Math.log(a + Math.sqrt(a * a + 1));
        if (degrees) a = Multiply(a, Divide(180, Math.PI));
        return (float) a;
	}
	public static String Asinh(String aS, boolean degrees)
	{
		double a = Double.parseDouble(aS);
		if (degrees) a = Multiply(a, Divide(Math.PI, 180));
        a = Math.log(a + Math.sqrt(a * a + 1));
        if (degrees) a = Multiply(a, Divide(180, Math.PI));
        return Double.toString(a);
	}
	
	public static double Acosh(double a)
	{
		if (a < 1) return Double.NaN;
		return Math.log(a + Math.sqrt(a * a - 1));
	}
	public static float Acosh(float a)
	{
		if (a < 1) return Float.NaN;
		return (float) Math.log(a + Math.sqrt(a * a - 1));
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
	public static float Acosh(float x, boolean degrees)
	{
		double a = x;
		if (degrees) a = Multiply(a, Divide(Math.PI, 180));
		if (a < 1) return Float.NaN;
        a = Math.log(a + Math.sqrt(a * a - 1));
        if (degrees) a = Multiply(a, Divide(180, Math.PI));
        return (float) a;
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
	
	public static double Atanh(double a) 
	{
	    return 0.5 * Math.log((1 + a) / (1 - a));
	}
	public static float Atanh(float a)
	{
		return (float) (0.5 * Math.log((1 + a) / (1 - a)));
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
	public static float Atanh(float x, boolean degrees)
	{
		double a = x;
		if (degrees) a = Multiply(a, Divide(Math.PI, 180));
        a = 0.5 * Math.log((1 + a) / (1 - a));
        if (degrees) a = Multiply(a, Divide(180, Math.PI));
        return (float) a;
	}
	public static String Atanh(String aS, boolean degrees)
	{
		double a = Double.parseDouble(aS);
		if (degrees) a = Multiply(a, Divide(Math.PI, 180));
        a = 0.5 * Math.log((1 + a) / (1 - a));
        if (degrees) a = Multiply(a, Divide(180, Math.PI));
        return Double.toString(a);
	}
	
    public static double Ln(double a)
    {
        return Math.log(a);
    }
    public static float Ln(float a)
    {
        return (float)Math.log(a);
    }
    public static String Ln(String aS)
    {
    	double a = Double.parseDouble(aS);
    	return Double.toString(Math.log(a));
    }

    public static double Log(double a, double b)
    {
    	return Ln(a) / Ln(b);
    }
    public static float Log(float a, float b)
    {
    	return Ln(a) / Ln(b);
    }
    public static String Log(String a, String b)
    {
    	return Divide(Ln(a), Ln(b));
    }
}
