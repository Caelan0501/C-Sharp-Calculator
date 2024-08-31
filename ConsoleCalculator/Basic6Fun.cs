using System;
using System.Collections.Generic;
public class Basic6Fun : Basic4Fun
{
    private List<string>? History;
	private int? Ihistory;
    private bool enableHistory;
    public Basic6Fun(bool enableHistory = false)
	{
        this.enableHistory = enableHistory;
        History = new List<String>();
        Ihistory = 0;
    }
	public int Power(int a, int b)
    {
        AddToHistory(a, '^', b, (int)(Math.Pow((double)(a), (double)(b))));
        return (int)(Math.Pow((double)(a), (double)(b)));
    }
    public double Power(double a, double b)
    {
        AddToHistory(a, '^', b, Math.Pow(a, b));
        return Math.Pow(a,b);
    }
    public float Power(float a, float b)
    {
        AddToHistory(a, '^', b, (float)Math.Pow(a, b));
        return (float)Math.Pow(a, b);
    }
    public double Power(string aS, string bS)
    {
        double a = Double.Parse(aS);
        double b = Double.Parse(bS);
        AddToHistory(a, '^', b, Math.Pow(a, b));
        return Math.Pow(a,b);
    }

    public double Root(double a, double b)
    {
        AddToHistory(a, '√', b, Power(a, Divide(1, b)));
        return Power(a, Divide(1, b));
    }
    public int Root(int a, int b)
    {
        AddToHistory(a, '√', b, Power(a, Divide(1, b)));
        return Power(a, Divide(1, b));
    }
    public float Root(float a, float b)
    {
        AddToHistory(a, '√', b, Power(a, Divide(1, b)));
        return Power(a, Divide(1, b));
    }
    public double Root(string aS, string bS)
    {
        double a = Double.Parse(aS);
        double b = Double.Parse(bS);
        AddToHistory(a, '√', b, Power(a, Divide(1, b)));
        return Power(a, Divide(1, b));
    }
}
