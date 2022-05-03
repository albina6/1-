using System;
using System.Collections.Generic;
using System.Text;

namespace _1лаб
{
    public class ZFunc : FunctionMembership//type 3
    {
        
        private const double Pi = 3.14;

        public ZFunc(string name, double a, double b): base(name, a, b) { }
        
        public ZFunc() : base()
        {
            this.Name = "Z-образная функция";
        }

        public ZFunc(string name, double[] options) : base(name, options) { }

        public override FunctionMembership CreateCopy()
        {
            return new ZFunc(Name, A, B);
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

            return new double[] { A, B};
        }

        public override int GetType()
        {
            return 3;
        }

        public override string GetTypeSTR
        {
            get => "Z-образная функция";
        }
        public override double[] GetOptions()
        {
            double[] options = new double[] { 3, A, B };
            return options;
        }

        public override double GetY(double x)
        {
            double y;
            if (x < A)
            {
                y = 1.0;
            }
            else if (A <= x && x <= B)
            {
                y = 0.5 + 0.5 * (Math.Cos(((x - A) / (B - A)) * Pi));
            }
            else
                y = 0.0;
            return y;
        }

    }
}
