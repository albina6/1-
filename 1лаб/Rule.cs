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
        private int aAltIndex, bAltIndex, yAltIndex;
        
        private int aCriterion, bCriterion;//, yAltIndex;
        //private FunctionMembership aAlt, bAlt, yAlt;// сделано чтобы всегда можно было добраться до критерия 
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

        private int ReadInt(int max)
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
                else if (Convert.ToInt32(s) > max)
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
                Console.WriteLine((i+1).ToString() + ".  " + critArray[i].Name);
            }
            
        }
        private void PrintAlt(Criterion crit)
        {
            for (int i = 0; i < crit.CountAlt(); i++)
            {
                Console.WriteLine((i+1).ToString() + ".  " + crit.GetAltern(i).Name );
            }
        }
        private void RuleAdd(Criterion[] critArray)
        {
            Console.Clear();
            Console.WriteLine("Выберите знак для данного правила");
            Console.WriteLine(critArray[ACriterion].Name + "( " + critArray[ACriterion].GetAltern(aAltIndex).Name + " )" + " +/* "
                                        + critArray[BCriterion].Name + "( " + critArray[BCriterion].GetAltern(bAltIndex).Name + " )");



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
            Console.WriteLine();

        }
        private int SelectIndex(int max)
        {
            Console.WriteLine("Ведите номер выбранного элемента.");
            return ReadInt(max);
        }

        private (int, int) SetCrit(Criterion[] criterionArray)
        {
            int countCrit = criterionArray.Length;
            PrintCrit(criterionArray);
            int indexCrit = SelectIndex(countCrit)-1;

            Console.WriteLine("Выберете необходимую альтернативу критерия " + criterionArray[indexCrit].Name + "\n");
            PrintAlt(criterionArray[indexCrit]);
            int indexAlt = SelectIndex(criterionArray[indexCrit].CountAlt()) - 1;

            return (indexCrit, indexAlt);
        }
        private int SetCrit(Criterion crit)
        {
            
            Console.WriteLine("Выберете необходимую альтернативу критерия " + crit.Name + "\n");
            PrintAlt(crit);
            int indexAlt =SelectIndex(crit.CountAlt())-1;//как записываем так и читаем,(с консоли +1 индекс считываем 1-N, а в массиве 0-(N-1))
            return indexAlt;
        }
        //}
        public Rule SetRule(Criterion[] criterionArray, Criterion yCrit)
        {

            //// int countCrit = criterionArray.Length;
            int al;
            Console.WriteLine("Выберете первый критерий.\n");
            (ACriterion, AAltIndex) = SetCrit(criterionArray);
            //aAlt = criterionArray[ACriterion].GetAltern(al);

            Console.WriteLine("Выберете второй критерий.\n");
            (BCriterion, bAltIndex) = SetCrit(criterionArray);
            //bAlt = criterionArray[BCriterion].GetAltern(al);

            RuleAdd(criterionArray);

            Console.WriteLine("Выберете альтернативу для у.\n");
            yAltIndex = SetCrit(yCrit);
            //yAlt = yCrit.GetAltern(yAltIndex);
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
        


        public int AAltIndex
        {
            get => aAltIndex;
            set => aAltIndex = value;
        }

        public int BAltIndex
        {
            get => bAltIndex;
            set => bAltIndex = value;
        }
        public int YAltIndex
        {
            get => yAltIndex;
            set => yAltIndex = value;
        }

        public bool AndBool
        {
            get => and;
            set => and = value;
        }

        public Rule()
        {
            this.and = true;
            this.Options =new int[] { 0,0,0,0,0 };
        }

        public Rule(Criterion[] criterionArray, Criterion yCrit)
        {
            SetRule( criterionArray,  yCrit);
        }
        public Rule(bool and, int [] options)
        {
            this.and = and;
            this.Options=options;
        }

        public  int[] Options
        {
            get
            {
                return new int[] { aCriterion, aAltIndex, bCriterion, bAltIndex, yAltIndex };
            }
            set
            {
                this.aCriterion = value[0];
                this.aAltIndex = value[1];
                this.bCriterion = value[2];
                this.bAltIndex = value[3];
                this.yAltIndex = value[4];
            }
        }



        public Rule(bool and, int aCriterion,int aAltIndex, int bCriterion, int bAltIndex, int yAltIndex)
        {
            this.aCriterion = aCriterion;
            this.aAltIndex = aAltIndex;

            this.bCriterion = bCriterion;
            this.bAltIndex = bAltIndex;

            this.yAltIndex = yAltIndex;
        }
        //public Rule(bool and, int aCriterion, FunctionMembership aAlt,int bCriterion, FunctionMembership bAlt, int yAltIndex, FunctionMembership yAlt)
        //{
        //    this.aCriterion = aCriterion;
        //    this.aAlt = aAlt;

        //    this.bCriterion = bCriterion;
        //    this.bAlt = bAlt;

        //    this.yAltIndex = yAltIndex;
        //    this.yAlt = yAlt;
        //}

        public double GetResult(double aX, double bX,Criterion[] critArray)//определяем степень принадлежности посылок правил(второй этап)
        {
            double a, b;
            a = critArray[aCriterion].GetAltern( aAltIndex).GetY(aX);
            b = critArray[bCriterion].GetAltern(bAltIndex).GetY(bX);
            if (and)
            {
                return result = Math.Min(a, b);
            }
            else
                return result = Math.Max(a, b);
        }

        //public double GetResult(double aX, double bX)//определяем степень принадлежности посылок правил(второй этап)
        //{
        //    double a, b;
        //    a =  aAlt.GetY(aX);
        //    b = bAlt.GetY(bX);
        //    if (and)
        //    {
        //        return result = Math.Min(a, b);
        //    }
        //    else
        //        return result = Math.Max(a, b);
        //}
       
        
        
        
        //не видила вызовы
        
        
        //public double GetYRule(double x)
        //{
        //    double y = yAlt.GetY(x);
        //    if (y < result)
        //        return y;
        //    else
        //        return result;
        //}



        ////////////////

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
