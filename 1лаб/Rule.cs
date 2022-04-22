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

        /*
          flag = true;
            int countRule=0;
            while (flag == true)
            {
                string s = Console.ReadLine();
                if (!int.TryParse(s, out int answer))
                {

                    Console.WriteLine("введено не число");
                }
                else
                {
                    countRule = Convert.ToInt32(s);
                    flag = false;
                }
            }
         */

        private int readInt(int max)
        {
            bool flag = true;
            int value = 0;
            while (flag == true)
            {
                string s = Console.ReadLine();
                if (!int.TryParse(s, out int answer))
                {

                    Console.WriteLine("Bведено не число");
                }
                else if (Convert.ToInt32(s) >= max)
                {
                    Console.WriteLine("Вы ввели число превыщающее допустимое значение");
                }
                else
                {
                    value = Convert.ToInt32(s);
                    flag = false;
                }
            }
            return value;
        }

        private void PrintCrit(Criterion[] critArray)
        {
            for (int i = 0; i < critArray.Length; i++)
            {
                Console.WriteLine(i.ToString() + ".  " + critArray[i].Name);
            }
            
        }
        private void PrintAlt(Criterion crit)
        {
            for (int i = 0; i < crit.CountAlt(); i++)
            {
                Console.WriteLine(i.ToString() + ".  " + crit.getAltern(i).Name );
            }
        }
        private void RuleAdd(Criterion[] critArray)
        {
            Console.WriteLine("Выберите знак для данного правила");
            Console.WriteLine(critArray[ACriterion].Name + "( " + aAlt.Name + " )" + " +/* "
                                        + critArray[BCriterion].Name + "( " + bAlt.Name + " )");



            bool flag = true;
            while (flag == true)
            {
                char s = Console.ReadKey().KeyChar;
                if (s == '+')

                {
                    and = false;
                    flag = false;
                }
                else if (s == '*')
                {
                    and = true;
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Вы ввели неправильный знак.\nПовторите попытку.\n");
                    
                }
            }

        }
        private int SelectIndex(int max)
        {
            Console.WriteLine("Ведите номер выбранного элемента.");
            return readInt(max);
        }

        private (int, int) SetCrit(Criterion[] criterionArray)
        {
            int countCrit = criterionArray.Length;
            PrintCrit(criterionArray);
            int indexCrit = SelectIndex(countCrit);

            Console.WriteLine("Выберете необходимую альтернативу критерия " + criterionArray[indexCrit].Name + "\n");
            PrintAlt(criterionArray[indexCrit]);
            int indexAlt = SelectIndex(criterionArray[indexCrit].CountAlt());

            return (indexCrit, indexAlt);
        }
        private int SetCrit(Criterion yCrit)
        {
            
            Console.WriteLine("Выберете необходимую альтернативу критерия " + yCrit.Name + "\n");
            PrintAlt(yCrit);
            int indexAlt =SelectIndex(yCrit.CountAlt());
            return indexAlt;
        }
        //}
        public Rule SetRule(Criterion[] criterionArray, Criterion yCrit)
        {

            // int countCrit = criterionArray.Length;
            int al;
            Console.WriteLine("Выберете первый критерий.\n");
            (ACriterion, al) = SetCrit(criterionArray);
            aAlt = criterionArray[ACriterion].getAltern(al);

            Console.WriteLine("Выберете второй критерий.\n");
            (BCriterion, al) = SetCrit(criterionArray);
            bAlt = criterionArray[BCriterion].getAltern(al);

            RuleAdd(criterionArray);

            Console.WriteLine("Выберете альтернативу для у.\n");
            yAltIndex = SetCrit(yCrit);
            yAlt = yCrit.getAltern(yAltIndex);
            return this;

        }
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
        
        
        public Rule(Criterion[] criterionArray, Criterion yCrit)
        {
            SetRule( criterionArray,  yCrit);
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
