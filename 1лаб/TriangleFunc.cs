using System;
using System.Collections.Generic;
using System.Text;

namespace _1лаб
{
    public class TriangleFunc:FunctionMembership
    {
        private double c;

        public TriangleFunc(string name, double a, double b, double c) : base(name,a,b)
        {
            this.c = c;
        }
        public TriangleFunc()
        {
            this.Name = "треугольная функция";
            A = 101;
            B = 102;
            c = 103;
        }
        public override FunctionMembership CreateCopy()
        {
            return new TriangleFunc(Name, A, B, C);
        }

        //public override double GetY(double x,double maxY)
        //{
        //    return Math.Min(this.GetY(x), maxY);
        //}
        public override double GetY(double x)
        {
            double y;
            if (A <= x && x <= B)
            {
                y = 1 - ((B - x) / (B - A));
            }
            else if (B <= x && x <= c)
            {
                y = 1 - ((x - B) / (c - B));
            }
            else
                y = 0.0;
            return y;
        }
        public double C
        {
            get => c;
            set => c = value;
        }
    }
}
