using System;
using System.Collections.Generic;
using System.Text;

namespace _1лаб
{
    public class FunctionMembership
    {
        private string name;
        private double a, b;
        public FunctionMembership()
        {
            name = "null";
            A = B = 100;
        }
        public FunctionMembership(string name,double a,double b)
        {
            this.name = name;
            this.A = a;
            this.B = b;
        }
        public virtual double GetY(double x)
        {
            // fun.GetY(x);
            return 100.0;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public double A
        {
            get => a;
            set => a= value;
        }
        public double B
        {
            get => b;
            set => b = value;
        }



    }
}
