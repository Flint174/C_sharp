using System;
using System.Linq;

namespace NSAreaCalc
{
    abstract class Figure
    {
        protected Figure(double[] args)
        {
            Sides = args;
        }
        public double[] Sides { get; set; }
        public string Name { get; set; }
        public abstract double area();
        public abstract void validate();
    }

    class Circle : Figure
    {
        public Circle(double[] args) : base(args) 
        {
            Name = "Circle";
        }
        public override double area()
        {
            return Math.PI * Math.Pow(Sides[0], 2);
        }
        public override void validate()
        {
            throw new NotImplementedException();
        }
    }

    class Triangle : Figure
    {
        public Triangle(double[] args) : base(args) 
        {
            Name = "Triangle";
        }
        public override double area()
        {
            validate();
            if (2 * Sides.Max() >= Sides.Sum()) throw new ArgumentException("Not a figure");
            if (Math.Pow(Sides.Max(), 2) * 2 == Math.Pow(Sides[0], 2) + Math.Pow(Sides[1], 2) + Math.Pow(Sides[2], 2))
                return Sides[0] * Sides[1] * Sides[2] / Sides.Max() / 2;
            double hper = Sides.Sum() / 2;
            return Math.Sqrt(hper * (hper - Sides[0]) * (hper - Sides[1]) * (hper - Sides[2]));
        }
        public override void validate()
        {
            if (2 * Sides.Max() >= Sides.Sum()) throw new ArgumentException("Not a figure");
        }
    }

    public class AreaCalc
    {
        public static double area(double[] args)
        {
            return getFigure(args).area();
        }

        private static Figure getFigure(double[] args)
        {
            foreach (double arg in args)
            {
                if (arg <= 0) throw new ArgumentException("All argumets must be more then 0");
            }

            Figure figure;
            switch (args.Length)
            {
                case 1:
                    figure = new Circle(args);
                    break;
                case 3:
                    figure = new Triangle(args);
                    break;
                default:
                    throw new ArgumentException("Unknown figure");
            }
            return figure;
        }
    }
}
