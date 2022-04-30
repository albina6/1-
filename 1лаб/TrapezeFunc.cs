using System;
using System.Collections.Generic;
using System.Text;

namespace _1лаб
{
    public class TrapezeFunc:FunctionMembership //type 2
    {
        private double c, d;

        public TrapezeFunc(string name, double a, double b, double c, double d) : base(name,a,b)
        {
            this.c = c;
            this.d = d;
        }
        public TrapezeFunc()
        {
            this.Name = "трапецеидальная функция";
            A = 101;
            B = 102;
            c = 103;
            d = 104;
        }

        public TrapezeFunc(string name, double[] options) : base(name, options) { }

        public override void Options(double[] options)
        {
            base.Options(options);
            this.C = options[2];
            this.D = options[3];
        }
        public override double[] Options()
        {

            return new double[] { A, B, C , D};
        }
        public override int GetType()
        {
            return 2;
        }

        //public override string GetType()
        //{
        //    return "Трапецеидальная функция";
        //}
        public override double[] GetOptions()
        {
            double[] options = new double[] { 2, A, B, C, D };
            return options;
        }



        public override FunctionMembership CreateCopy()
        {
            return new TrapezeFunc(Name, A, B, C,D);
        }
        //public override double GetY(double x, double maxY)
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
                y = 1;
            }
            else if (c <= x && x <= d)
            {
                y = 1 - ((x - c) / (d - c));
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

        public double D
        {
            get => d;
            set => d = value;
        }
    }
}
