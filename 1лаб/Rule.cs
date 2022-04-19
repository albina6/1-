using System;
using System.Collections.Generic;
using System.Text;

namespace _1лаб
{
    public class Rule
    {
        private bool and;//true=>and; false=>or
        private FunctionMembership aAltern, bAltern, yAltern;
        private double result;
        public Rule(bool sign, FunctionMembership aAltern,FunctionMembership bAltern,FunctionMembership yAltern)
        {
            this.and = sign;
            this.aAltern = aAltern;
            this.bAltern = bAltern;
            this.yAltern = yAltern;

        }
        public double GetResult(double aX,double bX)
        {
            double a, b;
            a = aAltern.GetY(aX);
            b = bAltern.GetY(bX);
            if (and)
            {
                return result= Math.Min(a, b);
            }
            else
                return result = Math.Max(a, b);
        }
        public double GetYRule(double x)
        {
            double y = yAltern.GetY(x);
            if (y < result)
                return y;
            else
                return result;
        }
    }
}
