using System;
using System.Diagnostics;
namespace Calculator
{
    public static class Formula
    {
        public static double Pythagorean(double? a = null, double? b = null, double? c = null)
        {
            return BasePythagorean(a, b, c);
        }
        public static string Pythagorean(string? aS = null, string? bS = null, string? cS = null)
        {
            double? a = null;
            double? b = null;
            double? c = null;
            if (aS != null) a = Double.Parse(aS);
            if (bS != null) b = Double.Parse(bS);
            if (cS != null) c = Double.Parse(cS);
            return BasePythagorean(a, b, c).ToString();
        }
        internal static Operand Pythagorean (Operand a, Operand b, Operand c)
        {
            return new Operand (BasePythagorean(a.Value, b.Value, c.Value));
        }
        private static double BasePythagorean(double? a = null, double? b = null, double? c = null)
        {
            if (a == null && b == null || b == null && c == null || a == null && c == null) throw new ArgumentException();
            if (a == null)
            {
                Debug.Assert(b != null && c != null);
                string equation = "ROOT " + c.ToString() + "^2-" + b.ToString() + "^2";
                return Arithmetic.Solve(equation);
            }
            else if (b == null)
            {
                Debug.Assert(a != null && c != null);
                string equation = "ROOT " + c.ToString() + "^2-" + a.ToString() + "^2";
                return Arithmetic.Solve(equation);
            }
            else if (c == null)
            {
                Debug.Assert(a != null && b != null);
                string equation = "ROOT " + a.ToString() + "^2+" + b.ToString() + "^2";
                return Arithmetic.Solve(equation);
            }
            else throw new ArgumentException();
        }

        public static double Sum(double[] nums)
        {
            double sum = 0;
            foreach (double i in nums)
            {
                sum += i;
            }
            return sum;
        }
        public static double Sum(List<double> nums)
        {
            double sum = 0;
            foreach (double i in nums)
            {
                sum += i;
            }
            return sum;
        }
        internal static Operand Sum(Operand[] nums)
        {
            Operand sum = new Operand(0);
            foreach (Operand i in nums)
            {
                sum = new Operand(Function.Add(sum, i));
            }
            return sum;
        }
        internal static Operand Sum(List<Operand> nums)
        {
            Operand sum = new Operand(0);
            foreach (Operand i in nums)
            {
                sum = new Operand(Function.Add(sum, i));
            }
            return sum;
        }

        public static double Mean(double[] nums)
        {
            double sum = 0;
            foreach (double i in nums)
            {
                sum += i;
            }
            return sum / nums.Length;
        }
        public static double Mean(List<double> nums)
        {
            double sum = 0;
            foreach (double i in nums)
            {
                sum += i;
            }
            return sum / nums.Count;
        }
        internal static Operand Mean(Operand[] nums)
        {
            Operand sum = new Operand(0);
            foreach (Operand i in nums)
            {
                sum = new Operand(Function.Add(sum, i));
            }
            return new Operand(Function.Divide(sum, new Operand(nums.Length)));
        }
        internal static Operand Mean(List<Operand> nums)
        {
            Operand sum = new Operand(0);
            foreach (Operand i in nums)
            {
                sum = new Operand(Function.Add(sum, i));
            }
            return new Operand(Function.Divide(sum, new Operand(nums.Count)));
        }
    }
}
