using System;
using System.Collections.Generic;
using System.Text;

namespace _1лаб
{
    public class TriangleFunc:FunctionMembership//type 1
    {
        private double c;

        public TriangleFunc(string name, double a, double b, double c) : base(name,a,b)
        {
            this.c = c;
        }
        public TriangleFunc():base ()
        {
            this.Name = "треугольная функция";
            C = 103;
        }

        public TriangleFunc( string name,double[] options) : base(name, options) { }

        public override FunctionMembership CreateCopy()
        {
            return new TriangleFunc(Name, A, B, C);
        }

        //public override double GetY(double x,double maxY)
        //{
        //    return Math.Min(this.GetY(x), maxY);
        //}



        public override void Options(double[] options)
        {
            base.Options(options);
            this.C = options[2];
        }
        public override double[] Options()
        {

            return new double[] { A, B, C };
        }

        public override int GetType()
        {
            return 1;
        }

        public override string GetTypeSTR
        {
            get => "Треугольная функция";
        }
        public override double[] GetOptions()
        {
            double[] options = new double[] { 1, A, B, C };
            return options;
        }

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
