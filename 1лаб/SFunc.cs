using System;
using System.Collections.Generic;
using System.Text;

namespace _1лаб
{
    public class SFunc : FunctionMembership//type 3
    {

        private const double Pi = 3.14;

        public SFunc(string name, double a, double b) : base(name, a, b) { }

        public SFunc() : base()
        {
            this.Name = "S-образная функция";
        }

        public SFunc(string name, double[] options) : base(name, options) { }

        public override FunctionMembership CreateCopy()
        {
            return new SFunc(Name, A, B);
        }

        //public override double GetY(double x,double maxY)
        //{
        //    return Math.Min(this.GetY(x), maxY);
        //}



        public override void Options(double[] options)
        {
            base.Options(options);
        }
        public override double[] Options()
        {

            return new double[] { A, B };
        }

        public override int GetType()
        {
            return 4;
        }

        public override string GetTypeSTR
        {
            get => "S-образная функция";
        }
        public override double[] GetOptions()
        {
            double[] options = new double[] { 4, A, B };
            return options;
        }

        public override double GetY(double x)
        {
            double y;
            if (x < A)
            {
                y = 0.0;
            }
            else if (A <= x && x <= B)
            {
                y = 0.5 + 0.5 * (Math.Cos(((x - B) / (B - A)) * Pi));
            }
            else
                y = 1.0;
            return y;
        }

    }
}
