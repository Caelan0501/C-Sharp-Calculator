using System;
using System.Collections.Generic;
using System.Drawing;


namespace Calculator
{
    public abstract class Shapes
    {

    }
    public class Polygon : Shapes
    {
        protected int? sides = null;
        protected double? perimeter = null;
        protected double? area = null;

        protected double[]? sidesLength = null;
        protected double[]? interiorAngles = null;
        protected double[]? exteriorAngles = null;

        public Polygon()
        {
        }
        public Polygon(int sides = -1, double perimeter = double.NaN, double area = double.NaN,
            double[]? sidesLength = null, double[]? interiorAngles = null, double[]? exteriorAngles = null)
        {
            if (sides > 2)
            {
                this.sides = sides;
            }
            if (perimeter != double.NaN && perimeter > 0)
            {
                this.perimeter = perimeter;
            }
            if (area != double.NaN && area > 0)
            {
                this.area = area;
            }

            if (sidesLength != null)
            {
                List<double> lengths = new List<double>();
                foreach (double side in sidesLength)
                {
                    if (side > 0)
                    {
                        lengths.Add(side);
                    }
                }
                this.sidesLength = lengths.ToArray();
            }
            if (interiorAngles != null)
            {
                List<double> angles = new List<double>();
                foreach (double angle in interiorAngles)
                {
                    if (angle > 0)
                    {
                        angles.Add(angle);
                    }
                }
                this.interiorAngles = angles.ToArray();
            }
            if (exteriorAngles != null)
            {
                List<double> angles = new List<double>();
                foreach (double angle in exteriorAngles)
                {
                    if (angle > 0)
                    {
                        angles.Add(angle);
                    }
                }
                this.exteriorAngles = angles.ToArray();
            }
            if (Verified()) FillInfo();
        }

        public Polygon(int sides = -1, double perimeter = double.NaN, double area = double.NaN,
            List<double>? sidesLength = null, List<double>? interiorAngles = null, List<double>? exteriorAngles = null)
        {
            if (sides > 2)
            {
                this.sides = sides;
            }
            if (perimeter != double.NaN && perimeter > 0)
            {
                this.perimeter = perimeter;
            }
            if (area != double.NaN && area > 0)
            {
                this.area = area;
            }

            if (sidesLength != null)
            {
                List<double> lengths = new List<double>();
                foreach (double side in sidesLength)
                {
                    if (side > 0)
                    {
                        lengths.Add(side);
                    }
                }
                this.sidesLength = lengths.ToArray();
            }
            if (interiorAngles != null)
            {
                List<double> angles = new List<double>();
                foreach (double angle in interiorAngles)
                {
                    if (angle > 0)
                    {
                        angles.Add(angle);
                    }
                }
                this.interiorAngles = angles.ToArray();
            }
            if (exteriorAngles != null)
            {
                List<double> angles = new List<double>();
                foreach (double angle in exteriorAngles)
                {
                    if (angle > 0)
                    {
                        angles.Add(angle);
                    }
                }
                this.exteriorAngles = angles.ToArray();
            }
            if (Verified()) FillInfo();
        }
        public Polygon(Point[] points)
        {

        }
        public Polygon(PointF[] points)
        {

        }
        protected bool Verified()
        {
            return true;
        }
        protected void FillInfo()
        {
            if (sides == null && sidesLength != null)
            {
                sides = sidesLength.Length;
            }
            if (perimeter == null && sidesLength != null)
            {
                double sum = 0;
                foreach(double length in sidesLength)
                {
                    sum += length;
                }
                perimeter = sum;
            }
            if (interiorAngles == null && exteriorAngles != null)
            {
                interiorAngles = new double[exteriorAngles.Length];
                for(int i = 0; i < exteriorAngles.Length; i++)
                {
                    interiorAngles[i] = 360 - exteriorAngles[i];
                }
            }
            if (exteriorAngles == null && interiorAngles != null)
            {
                exteriorAngles = new double[interiorAngles.Length];
                for (int i = 0; i < interiorAngles.Length; i++)
                {
                    exteriorAngles[i] = 360 - interiorAngles[i];
                }
            }
        }

        public string Classify()
        {
            return "";
        }
    }
    public class Polyhedron : Shapes
    {

    }
    public class Triangle : Polygon
    {

    }
    public class Quadrilateral : Polygon
    {
        
    }
    public class Trapizoid : Quadrilateral
    {

    }
    public class Parallelogram : Trapizoid
    {

    }
    public class Rectangle : Parallelogram
    {
        public Rectangle(System.Drawing.Rectangle rectangle)
        {
            sides = 4;
            sidesLength = new double[4] { ((double)rectangle.Height), ((double)rectangle.Width), ((double)rectangle.Height), ((double)rectangle.Width) };
        }
    }
    public class Square : Rectangle
    {
        public Square(System.Drawing.Rectangle rectangle) : base(rectangle)
        {
            sides = 4;
            sidesLength = new double[4] { ((double)rectangle.Width), ((double)rectangle.Width), ((double)rectangle.Width), ((double)rectangle.Width) };

            throw new Exception("Not Implemented");
        }
    }
    public class Rhombus : Parallelogram
    {

    }
    public class Kite
    {

    }
    public class Pentagon : Polygon
    {

    }
    public class Hexagon : Polygon
    {

    }
    public class Heptagon
    {

    }
    public class Octagon
    {

    }
    public class Nonagon
    {

    }
    public class Decagon : Polygon
    {

    }
}
