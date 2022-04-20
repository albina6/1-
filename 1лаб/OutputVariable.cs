using System;
using System.Collections.Generic;
using System.Text;

namespace _1лаб
{
    public class OutputVariable
    {
        private Criterion yCrit;
        private Rule[] ruleArray;//ссылкой общаюсь
        private double[] yAltMax;
        private double[] valueCrit;
        //y output;
        public OutputVariable()
        {

        }
        public OutputVariable(Criterion yCrit, Rule[]ruleArray)
        {
            this.yCrit = yCrit.CreateCopy();
            this.ruleArray = ruleArray;
        }

        public double [] Stage2(Rule [] rule,double[] valueCrit)//определяем степень принадлежности посылок правил(второй этап)
        {
            double a, b;
            double[] output = new double[rule.Length];

            for(int i = 0; i< output.Length; i++)
            {
                a = valueCrit[rule[i].ACriterion];
                b = valueCrit[rule[i].BCriterion];
                output[i] = rule[i].GetResult(a, b);
            }
            return output;
        }
        public double [] Stage3(Rule[]rule,double [] result2,Criterion yCrit)//Stage3
        {
            double[] yAltMin = new double[yCrit.CountAlt()];
            for(int i = 0; i < yCrit.CountAlt(); i++)
            {
                yAltMin[i] = 1;
            }

            for (int i = 0; i < rule.Length; i++)
            {

                int index = rule[i].YAltIndex;

                if ( (yAltMin[index]) > result2[i])
                {
                    yAltMin[index] = result2[i];
                }

            }
            return yAltMin;//возвращаем пороговые значения 
        }
        //public double GetY(double yAltMax)
        public double GetNewY(Criterion yCriterion, double[] yAltMax,double x)//yAltMax-этообрезаное значение для каждой альтернативы, получаем из Stage3 (yAltMin)
        {
            double max = 0.0;
            for (int i = 0; i < yAltMax.Length; i++)
            {
                max = Math.Max(Math.Min(yCriterion.getAltern(i).GetY(x), yAltMax[i]), max);//минимальное значение из GetY и обрезанной альтернативы, 
                                                                                                    //потом берем максимальное по всем альтернативам
            }
            return max;
        }

        public double YOutput(Rule[] ruleArray,Criterion yCriterion,Criterion[] critArray)
        {
            Criterion yNew = yCriterion.CreateCopy();
            double[] valueCrit = new double[critArray.Length];//хранит оценку по критериям (х)
            Console.WriteLine("Введите входные данные по каждому критерию.");
            for(int i=0; i < critArray.Length; i++)
            {
                Console.WriteLine("Введите оценку по критерию " + critArray[i].Name);
                try
                {
                    valueCrit[i] = Convert.ToDouble(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Введены некорректные данные. Повторите попытку.");
                    i--;
                }

            }
            Console.WriteLine("Данные введены, ожидайте вывода");

            double[] stage2 = Stage2(ruleArray, valueCrit);//определяем степень принадлежности посылок правил(второй этап)




            int count = ruleArray.Length;


        }
    }
}
