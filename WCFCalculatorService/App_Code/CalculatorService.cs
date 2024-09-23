using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Runtime;
using Calculator;
using System.Activities.Expressions;

public class CalculatorService : ICalculatorService
{
    private Arithmetic calc = new Arithmetic();

    public double Add(string a, string b)
    {
        return calc.Add(a, b);
    }
    public double Subtract(string a, string b)
    {
        return calc.Subtract(a, b);
    }
    public double Multiply(string a, string b)
    {
        return calc.Multiply(a, b);
    }
    public double Divide(string a, string b)
    {
        return calc.Divide(a, b);
    }
    public int Mod(string a, string b)
    {
        return (int)calc.Mod(a, b);
    }
    public double Power(string a, string b)
    {
        return calc.Power(a, b);
    }
    public double Root(string a, string b)
    {
        return calc.Root(a, b);
    }
    public double SolveArithmetic(string equation)
    {
        return calc.Solve(equation);
    }

    public int intergerAdd(int a, int b)
    {
        return calc.Add(a, b);
    }
    public int integerSubtract(int a, int b)
    {
        return calc.Subtract(a, b);
    }
    public int intergerMultiply(int a, int b)
    {
        return calc.Subtract(a, b);
    }
    public int intergerDivide(int a, int b)
    {
        return calc.Divide(a, b);
    }
    public int integerMod(int a, int b)
    {
        return calc.Mod(a, b);
    }
    public int integerPower(int a, int b)
    {
        return calc.Power(a, b);
    }
    public int integerRoot(int a, int b)
    {
        return calc.Root(a, b);
    }

    public double doubleAdd(double a, double b)
    {
        return calc.Add(a, b);
    }
    public double doubleSubtract(double a, double b)
    {
        return calc.Subtract(a, b);
    }
    public double doubleMultiply(double a, double b)
    {
        return calc.Subtract(a, b);
    }
    public double doubleDivide(double a, double b)
    {
        return calc.Divide(a, b);
    }
    public double doublePower(double a, double b)
    {
        return calc.Power(a, b);
    }
    public double doubleRoot(double a, double b)
    {
        return calc.Root(a, b);
    }

    public float floatAdd(float a, float b)
    {
        return calc.Add(a, b);
    }
    public float floatSubtract(float a, float b)
    {
        return calc.Subtract(a, b);
    }
    public float floatMultiply(float a, float b)
    {
        return calc.Subtract(a, b);
    }
    public float floatDivide(float a, float b)
    {
        return calc.Divide(a, b);
    }
    public float floatPower(float a, float b)
    {
        return calc.Power(a, b);
    }
    public float floatRoot(float a, float b)
    {
        return calc.Root(a, b);
    }
}
