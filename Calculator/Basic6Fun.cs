using System;
using System.Collections.Generic;
namespace Calculator
{
    public class Basic6Fun : Basic4Fun
    {
        public Basic6Fun(bool enabledHistory = true) : base(enabledHistory: enabledHistory)
        {
        }
        public override string ToString()
        {
            return "6 Function Calculator";
        }
        public int Power(int a, int b)
        {
            AddToHistory(a, '^', b, (int)(Math.Pow((double)(a), (double)(b))));
            return (int)(Math.Pow((double)(a), (double)(b)));
        }
        public double Power(double a, double b)
        {
            AddToHistory(a, '^', b, Math.Pow(a, b));
            return Math.Pow(a, b);
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
            return Math.Pow(a, b);
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
            history.Pause();
            double result = Power(a, Divide(1, b));
            history.Resume();
            AddToHistory(a, '√', b, result);
            return result;
        }
    }

}
