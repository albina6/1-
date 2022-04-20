using System;
using System.Collections.Generic;
using System.Text;

namespace _1лаб
{
    public class Rule
    {
        private bool and;//true=>and; false=>or
        // private FunctionMembership aAltern, bAltern, yAltern;
        //private Criterion aCriterion, bCriterion, yCriterion;
        //private int aIndexAlt, bIndexAlt, yIndexAlt;// сделано чтобы всегда можно было добраться до критерия 

        private int aCriterion, bCriterion, yAltIndex;
        private FunctionMembership aAlt, bAlt, yAlt;// сделано чтобы всегда можно было добраться до критерия 
        private double result;
        //public Rule(bool sign, FunctionMembership aAltern,FunctionMembership bAltern,FunctionMembership yAltern)
        //{
        //    this.and = sign;
        //    this.aAltern = aAltern;
        //    this.bAltern = bAltern;
        //    this.yAltern = yAltern;

        //}
        public int ACriterion
        {
            get => aCriterion;
            set => aCriterion = value;
        }
        public int BCriterion
        {
            get => bCriterion;
            set => bCriterion = value;
        }
        public int YAltIndex
        {
            get => yAltIndex;
            set => yAltIndex = value;
        }
        public Rule(bool and, int aCriterion, FunctionMembership aAlt,int bCriterion, FunctionMembership bAlt, int yAltIndex, FunctionMembership yAlt)
        {
            this.aCriterion = aCriterion;
            this.aAlt = aAlt;

            this.bCriterion = bCriterion;
            this.bAlt = bAlt;

            this.yAltIndex = yAltIndex;
            this.yAlt = yAlt;
        }

        public double GetResult(double aX, double bX)//определяем степень принадлежности посылок правил(второй этап)
        {
            double a, b;
            a = aAlt.GetY(aX);
            b = bAlt.GetY(bX);
            if (and)
            {
                return result = Math.Min(a, b);
            }
            else
                return result = Math.Max(a, b);
        }
        public double GetYRule(double x)
        {
            double y = yAlt.GetY(x);
            if (y < result)
                return y;
            else
                return result;
        }


        //public double GetResult(double aX,double bX)
        //{
        //    double a, b;
        //    a = aCriterion.getAltern(aIndexAlt).GetY(aX);
        //    b = bCriterion.getAltern(bIndexAlt).GetY(bX);
        //    if (and)
        //    {
        //        return result= Math.Min(a, b);
        //    }
        //    else
        //        return result = Math.Max(a, b);
        //}
        //public double GetYRule(double x)
        //{
        //    double y = yCriterion.getAltern(yIndexAlt).GetY(x);
        //    if (y < result)
        //        return y;
        //    else
        //        return result;
        //}
    }
}
