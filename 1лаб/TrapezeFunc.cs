using System;
using System.Collections.Generic;
using System.Text;

namespace _1лаб
{
    public class TrapezeFunc:FunctionMembership
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
