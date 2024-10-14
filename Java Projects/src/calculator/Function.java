package calculator;

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
}
