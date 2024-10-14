using System;
namespace Calculator
{
    public static class Function
    {
        internal static Operand SmartSolve(Operand a, Operand b, Operator op)
        {
            switch (op.Name)
            {
                case "ADD":
                    return Function.Add(a, b);
                case "SUBTRACT":
                    return Function.Subtract(a, b);
                case "MULTIPLY":
                    return Function.Multiply(a, b);
                case "DIVIDE":
                    return Function.Divide(a, b);
                case "MODULUS":
                    return Function.Mod(a, b);
                case "POWER":
                    return Function.Power(a, b);
                case "ROOT":
                    return Function.Root(a, b);
                default:
                    throw new NotImplementedException();
            }
        }
        
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
        public static string Add(string aS, string bS)
        {
            double a = Double.Parse(aS);
            double b = Double.Parse(bS);
            return (a + b).ToString();
        }
        internal static Operand Add(Operand a, Operand b)
        {
            if (a.Value == null || b.Value == null) throw new ArgumentException();
            return new Operand((double)a.Value + (double)b.Value);
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
        public static string Subtract(string aS, string bS)
        {
            double a = Double.Parse(aS);
            double b = Double.Parse(bS);
            return (a - b).ToString();
        }
        internal static Operand Subtract(Operand a, Operand b)
        {
            if (a.Value == null || b.Value == null) throw new ArgumentException();
            return new Operand((double)a.Value - (double)b.Value);
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
        public static string Multiply(string aS, string bS)
        {
            double a = Double.Parse(aS);
            double b = Double.Parse(bS);
            return (a * b).ToString();
        }
        internal static Operand Multiply(Operand a, Operand b)
        {
            if (a.Value == null || b.Value == null) throw new ArgumentException();
            return new Operand((double)a.Value * (double)b.Value);
        }

        public static int Divide(int a, int b)
        {
            if (b == 0) throw new DivideByZeroException();
            return a / b;
        }
        public static double Divide(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException();
            return a / b;
        }
        public static float Divide(float a, float b)
        {
            if (b == 0) throw new DivideByZeroException();
            return a / b;
        }
        public static string Divide(string aS, string bS)
        {
            double a = Double.Parse(aS);
            double b = Double.Parse(bS);
            if (b == 0) throw new DivideByZeroException();
            return (a / b).ToString();
        }
        internal static Operand Divide(Operand a, Operand b)
        {
            if (a.Value == null || b.Value == null) throw new ArgumentException();
            if (b.Value == 0) throw new DivideByZeroException();
            return new Operand((double)a.Value / (double)b.Value);
        }

        public static int Mod(int a, int b)
        {
            if (b == 0) throw new DivideByZeroException();
            return a % b;
        }
        public static string Mod(string aS, string bS)
        {
            int a;
            int b;
            bool status = int.TryParse(aS, out a);
            if (status)
            {
                status = int.TryParse(bS, out b);
                if (b == 0) throw new DivideByZeroException();
            }
            else throw new DivideByZeroException();
            if (status) return (a % b).ToString();
            else throw new DivideByZeroException();
        }
        internal static Operand Mod(Operand a, Operand b)
        {
            if (a.Value == null || b.Value == null) throw new ArgumentException();
            if (b.Value == 0) throw new DivideByZeroException();
            return new Operand((double)a.Value % (double)b.Value);
        }

        public static int Power(int a, int b)
        {
            return (int)(Math.Pow((double)(a), (double)(b)));
        }
        public static double Power(double a, double b)
        {
            return Math.Pow(a, b);
        }
        public static float Power(float a, float b)
        {
            return (float)Math.Pow(a, b);
        }
        public static string Power(string aS, string bS)
        {
            double a = Double.Parse(aS);
            double b = Double.Parse(bS);
            return (Math.Pow(a, b)).ToString();
        }
        internal static Operand Power(Operand a, Operand b)
        {
            if (a.Value == null || b.Value == null) throw new ArgumentException();
            return new Operand(Math.Pow((double)a.Value, (double)b.Value));
        }

        public static int Root(int a, int b)
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
        public static string Root(string aS, string bS)
        {
            double a = Double.Parse(aS);
            double b = Double.Parse(bS);
            return Power(a, Divide(1, b)).ToString();
        }
        internal static Operand Root(Operand a, Operand b)
        {
            if (a.Value == null || b.Value == null) throw new ArgumentException();
            return Power(a, new Operand (Divide(1,(double)b.Value)));
        }

        public static int Abs(int a)
        {
            return Math.Abs(a);
        }
        public static double Abs(double a)
        {
            return Math.Abs(a);
        }
        public static float Abs(float a)
        {
            return Math.Abs(a);
        }
        public static string Abs(string a)
        {
            return (Math.Abs(Double.Parse(a))).ToString();
        }

        public static double Sin(double a, bool degrees = false)
        {
            if (degrees) a = Multiply(a, Divide(Math.PI, 180));
            a = Math.Sin(a);
            if (degrees) a = Multiply(a, Divide(180, Math.PI));
            return a;
        }
        public static float Sin(float a, bool degrees = false)
        {
            if (degrees) a = Multiply(a, Divide((float)Math.PI, 180));
            a = Math.Sin(a);
            if (degrees) a = Multiply(a, Divide(180, (float)Math.PI));
            return a;
        }
        public static string Sin(string s, bool degrees = false)
        {
            double a = Double.Parse(s);
            if (degrees) a = Multiply(a, Divide(Math.PI, 180));
            a = Math.Sin(a);
            if (degrees) a = Multiply(a, Divide(180, Math.PI));
            return a.ToString();
        }

        public static double Cos(double a, bool degrees = false)
        {
            if (degrees) a = Multiply(a, Divide(Math.PI, 180));
            a = Math.Cos(a);
            if (degrees) a = Multiply(a, Divide(180, Math.PI));
            return a;
        }
        public static float Cos(float a, bool degrees = false)
        {
            if (degrees) a = Multiply(a, Divide((float)Math.PI, 180));
            a = Math.Cos(a);
            if (degrees) a = Multiply(a, Divide(180, (float)Math.PI));
            return a;
        }
        public static string Cos(string s, bool degrees = false)
        {
            double a = Double.Parse(s);
            if (degrees) a = Multiply(a, Divide(Math.PI, 180));
            a = Math.Cos(a);
            if (degrees) a = Multiply(a, Divide(180, Math.PI));
            return a.ToString();
        }

        public static double Tan(double a, bool degrees = false)
        {
            if (degrees) a = Multiply(a, Divide(Math.PI, 180));
            a = Math.Tan(a);
            if (degrees) a = Multiply(a, Divide(180, Math.PI));
            return a;
        }
        public static float Tan(float a, bool degrees = false)
        {
            if (degrees) a = Multiply(a, Divide((float)Math.PI, 180));
            a = Math.Tan(a);
            if (degrees) a = Multiply(a, Divide(180, (float)Math.PI));
            return a;
        }
        public static string Tan(string s, bool degrees = false)
        {
            double a = Double.Parse(s);
            if (degrees) a = Multiply(a, Divide(Math.PI, 180));
            Math.Tan(a);
            if (degrees) a = Multiply(a, Divide(180, Math.PI));
            return a.ToString();
        }

        public static double Sinh(double a, bool degrees = false)
        {
            if (degrees) a = Multiply(a, Divide(Math.PI, 180));
            a = Math.Sinh(a);
            if (degrees) a = Multiply(a, Divide(180, Math.PI));
            return a;
        }
        public static float Sinh(float a, bool degrees = false)
        {
            if (degrees) a = Multiply(a, Divide((float)Math.PI, 180));
            a = Math.Sinh(a);
            if (degrees) a = Multiply(a, Divide(180, (float)Math.PI));
            return a;
        }
        public static string Sinh(string s, bool degrees = false)
        {
            double a = Double.Parse(s);
            if (degrees) a = Multiply(a, Divide(Math.PI, 180));
            a = Math.Sinh(a);
            if (degrees) a = Multiply(a, Divide(180, Math.PI));
            return a.ToString();
        }

        public static double Cosh(double a, bool degrees = false)
        {
            if (degrees) a = Multiply(a, Divide(Math.PI, 180));
            a = Math.Cosh(a);
            if (degrees) a = Multiply(a, Divide(180, Math.PI));
            return a;
        }
        public static float Cosh(float a, bool degrees = false)
        {
            if (degrees) a = Multiply(a, Divide((float)Math.PI, 180));
            a = Math.Cosh(a);
            if (degrees) a = Multiply(a, Divide(180, (float)Math.PI));
            return a;
        }
        public static string Cosh(string s, bool degrees = false)
        {
            double a = Double.Parse(s);
            if (degrees) a = Multiply(a, Divide(Math.PI, 180));
            a = Math.Cosh(a);
            if (degrees) a = Multiply(a, Divide(180, Math.PI));
            return a.ToString();
        }

        public static double Tanh(double a, bool degrees = false)
        {
            if (degrees) a = Multiply(a, Divide(Math.PI, 180));
            a = Math.Tanh(a);
            if (degrees) a = Multiply(a, Divide(180, Math.PI));
            return a;
        }
        public static float Tanh(float a, bool degrees = false)
        {
            if (degrees) a = Multiply(a, Divide((float)Math.PI, 180));
            a = Math.Tanh(a);
            if (degrees) a = Multiply(a, Divide(180, (float)Math.PI));
            return a;
        }
        public static string Tanh(string s, bool degrees = false)
        {
            double a = Double.Parse(s);
            if (degrees) a = Multiply(a, Divide(Math.PI, 180));
            a = Math.Tanh(a);
            if (degrees) a = Multiply(a, Divide(180, Math.PI));
            return a.ToString();
        }

        public static double Asin(double a, bool degrees = false)
        {
            if (degrees) a = Multiply(a, Divide(Math.PI, 180));
            a = Math.Asin(a);
            if (degrees) a = Multiply(a, Divide(180, Math.PI));
            return a;
        }
        public static float Asin(float a, bool degrees = false)
        {
            if (degrees) a = Multiply(a, Divide((float)Math.PI, 180));
            a = Math.Asin(a);
            if (degrees) a = Multiply(a, Divide(180, (float)Math.PI));
            return a;
        }
        public static string Asin(string s, bool degrees = false)
        {
            double a = Double.Parse(s);
            if (degrees) a = Multiply(a, Divide(Math.PI, 180));
            a = Math.Asin(a);
            if (degrees) a = Multiply(a, Divide(180, Math.PI));
            return a.ToString();
        }

        public static double Acos(double a, bool degrees = false)
        {
            if (degrees) a = Multiply(a, Divide(Math.PI, 180));
            a = Math.Acos(a);
            if (degrees) a = Multiply(a, Divide(180, Math.PI));
            return a;
        }
        public static float Acos(float a, bool degrees = false)
        {
            if (degrees) a = Multiply(a, Divide((float)Math.PI, 180));
            a = Math.Acos(a);
            if (degrees) a = Multiply(a, Divide(180, (float)Math.PI));
            return a;
        }
        public static string Acos(string s, bool degrees = false)
        {
            double a = Double.Parse(s);
            if (degrees) a = Multiply(a, Divide(Math.PI, 180));
            a = Math.Acos(a);
            if (degrees) a = Multiply(a, Divide(180, Math.PI));
            return a.ToString();
        }

        public static double Atan(double a, bool degrees = false)
        {
            if (degrees) a = Multiply(a, Divide(Math.PI, 180));
            a = Math.Atan(a);
            if (degrees) a = Multiply(a, Divide(180, Math.PI));
            return a;
        }
        public static float Atan(float a, bool degrees = false)
        {
            if (degrees) a = Multiply(a, Divide((float)Math.PI, 180));
            a = Math.Atan(a);
            if (degrees) a = Multiply(a, Divide(180, (float)Math.PI));
            return a;
        }
        public static string Atan(string s, bool degrees = false)
        {
            double a = Double.Parse(s);
            if (degrees) a = Multiply(a, Divide(Math.PI, 180));
            a = Math.Atan(a);
            if (degrees) a = Multiply(a, Divide(180, Math.PI));
            return a.ToString();
        }

        public static double Asinh(double a, bool degrees = false)
        {
            if (degrees) a = Multiply(a, Divide(Math.PI, 180));
            a = Math.Asinh(a);
            if (degrees) a = Multiply(a, Divide(180, Math.PI));
            return a;
        }
        public static float Asinh(float a, bool degrees = false)
        {
            if (degrees) a = Multiply(a, Divide((float)Math.PI, 180));
            a = Math.Asinh(a);
            if (degrees) a = Multiply(a, Divide(180, (float)Math.PI));
            return a;
        }
        public static string Asinh(string s, bool degrees = false)
        {
            double a = Double.Parse(s);
            if (degrees) a = Multiply(a, Divide(Math.PI, 180));
            a = Math.Asinh(a);
            if (degrees) a = Multiply(a, Divide(180, Math.PI));
            return a.ToString();
        }

        public static double Acosh(double a, bool degrees = false)
        {
            if (degrees) a = Multiply(a, Divide(Math.PI, 180));
            a = Math.Acosh(a);
            if (degrees) a = Multiply(a, Divide(180, Math.PI));
            return a;
        }
        public static float Acosh(float a, bool degrees = false)
        {
            if (degrees) a = Multiply(a, Divide((float)Math.PI, 180));
            a = Math.Acosh(a);
            if (degrees) a = Multiply(a, Divide(180, (float)Math.PI));
            return a;
        }
        public static string Acosh(string s, bool degrees = false)
        {
            double a = Double.Parse(s);
            if (degrees) a = Multiply(a, Divide(Math.PI, 180));
            a = Math.Acosh(a);
            if (degrees) a = Multiply(a, Divide(180, Math.PI));
            return a.ToString();
        }

        public static double Atanh(double a, bool degrees = false)
        {
            if (degrees) a = Multiply(a, Divide(Math.PI, 180));
            a = Math.Atanh(a);
            if (degrees) a = Multiply(a, Divide(180, Math.PI));
            return a;
        }
        public static float Atanh(float a, bool degrees = false)
        {
            if (degrees) a = Multiply(a, Divide((float)Math.PI, 180));
            a = Math.Atanh(a);
            if (degrees) a = Multiply(a, Divide(180, (float)Math.PI));
            return a;
        }
        public static string Atanh(string s, bool degrees = false)
        {
            double a = Double.Parse(s);
            if (degrees) a = Multiply(a, Divide(Math.PI, 180));
            a = Math.Atanh(a);
            if (degrees) a = Multiply(a, Divide(180, Math.PI));
            return a.ToString();
        }

        public static double Ln(double a)
        {
            return Math.Log(a);
        }
        public static float Ln(float a)
        {
            return (float)Math.Log(a);
        }
        public static string Ln(string s)
        {
            double a = Double.Parse(s);
            return Math.Log(a).ToString();
        }

        public static double Log(double a, double b)
        {
            return Math.Log(a, b);
        }
        public static float Log(float a, float b)
        {
            return (float)Math.Log(a, b);
        }
        public static string Log(string sa, string sb)
        {
            double a = Double.Parse(sa);
            double b = Double.Parse(sb);
            return Math.Log(a).ToString();
        }
    }
}
