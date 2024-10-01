using System.Diagnostics;
namespace Calculator
{
    public static class Formula
    {
        public static double Pythagorean(double? a = null, double? b = null, double? c = null)
        {
            if (a == null && b == null || b == null && c == null || a == null && c == null) throw new ArgumentException();
            if (a == null)
            {
                Debug.Assert(b != null && c != null);
                return Function.Root(Function.Subtract(Function.Power((double)c, 2), Function.Power((double)b, 2)), 2);
            }
            else if (b == null)
            {
                Debug.Assert(a != null && c != null);
                return Function.Root(Function.Subtract(Function.Power((double)c, 2), Function.Power((double)a, 2)), 2);
            }
            else if (c == null)
            {
                Debug.Assert(a != null && b != null);
                return Function.Root(Function.Add(Function.Power((double)a, 2), Function.Power((double)b, 2)), 2);
            }
            else throw new ArgumentException();
        }
        public static float Pythagorean(float? a = null, float? b = null, float? c = null)
        {
            if (a == null && b == null || b == null && c == null || a == null && c == null) throw new ArgumentException();
            if (a == null)
            {
                Debug.Assert(b != null && c != null);
                return (float)Function.Root(Function.Subtract(Function.Power((float)c, 2), Function.Power((float)b, 2)), 2);
            }
            else if (b == null)
            {
                Debug.Assert(a != null && c != null);
                return (float)Function.Root(Function.Subtract(Function.Power((float)c, 2), Function.Power((float)a, 2)), 2);
            }
            else if (c == null)
            {
                Debug.Assert(a != null && b != null);
                return (float)Function.Root(Function.Add(Function.Power((float)a, 2), Function.Power((float)b, 2)), 2);
            }
            else throw new ArgumentException();
        }
        public static string Pythagorean(string? a = null, string? b = null, string? c = null)
        {
            if (a == null && b == null || b == null && c == null || a == null && c == null) throw new ArgumentException();
            if (a == null)
            {
                Debug.Assert(b != null && c != null);
                return Function.Root(Function.Subtract(Function.Power(c, "2"), Function.Power(b, "2")), "2");
            }
            else if (b == null)
            {
                Debug.Assert(a != null && c != null);
                return Function.Root(Function.Subtract(Function.Power(c, "2"), Function.Power(a, "2")), "2");
            }
            else if (c == null)
            {
                Debug.Assert(a != null && b != null);
                return Function.Root(Function.Add(Function.Power(a, "2"), Function.Power(b, "2")), "2");
            }
            else throw new ArgumentException();
        }
    }
}
