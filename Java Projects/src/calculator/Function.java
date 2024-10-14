package calculator;

import java.lang.Math;

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

	public static int Mod(int a, int b) throws Exception
	{
	    if (b == 0) throw new Exception("Cannot Divide by Zero");
	    return a % b;
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

    public static double Ln(double a)
    {
        return Math.log(a);
    }
    public static float Ln(float a)
    {
        return (float)Math.log(a);
    }
}
