using System;
using Calculator;

public class WCFCalculatorServiceLocal : IWCFCalculatorServiceLocal
{
    public double Add(string a, string b)
    {
        return Double.Parse(Function.Add(a, b));
    }
    public double Subtract(string a, string b)
    {
        return Double.Parse(Function.Subtract(a, b));
    }
    public double Multiply(string a, string b)
    {
        return Double.Parse(Function.Multiply(a, b));
    }
    public double Divide(string a, string b)
    {
        return Double.Parse(Function.Divide(a, b));
    }
    public double Mod(string a, string b)
    {
        return Double.Parse(Function.Mod(a, b));
    }
    public double Power(string a, string b)
    {
        return Double.Parse(Function.Power(a, b));
    }
    public double Root(string a, string b)
    {
        return Double.Parse(Function.Root(a, b));
    }
    public double SolveArithmetic(string equation)
    {
        return Arithmetic.Solve(equation);
    }
}
