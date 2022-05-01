using System;
using System.Collections.Generic;
using System.Text;

namespace _1лаб
{
    public class OutputVariable
    {
        private Criterion yCrit;
        private Rule[] ruleArray;//ссылкой общаюсь
        private Criterion[] critArray;
        private double[] yAltMax;
        private double[] valueCrit;
        //y output;
        public OutputVariable()
        {

        }
        public OutputVariable(Criterion yCrit, Rule[]ruleArray, Criterion[] critArray)
        {
            this.yCrit = yCrit.CreateCopy();
            this.ruleArray = ruleArray;
            this.critArray = critArray;
        }
        public double Course()
        {
            this.YOutput();
            double[] stege2 = Stage2();
            this.Stage3(stege2);
            return Stage4();
        }
        public double [] Stage2()//определяем степень принадлежности посылок правил(второй этап)
        {
            double a, b;
            double[] output = new double[ruleArray.Length];

            for(int i = 0; i< output.Length; i++)
            {
                a = valueCrit[ruleArray[i].ACriterion];
                b = valueCrit[ruleArray[i].BCriterion];
                output[i] = ruleArray[i].GetResult(a, b,critArray);
            }
            return output;
        }
        public void Stage3(double [] result2)//Stage3
        {
            yAltMax = new double[yCrit.CountAlt()];
            for(int i = 0; i < yCrit.CountAlt(); i++)
            {
                yAltMax[i] = 1;
            }

            for (int i = 0; i < ruleArray.Length; i++)
            {

                int index = ruleArray[i].YAltIndex;
                yAltMax[index] = Math.Min(yAltMax[index], result2[i]);

            }
            //возвращаем пороговые значения 
        }
        public double Stage4()//максимум функции
        {
            double max = 0.0;
            double indexMax=0;
           
            for (double i=0.0; i <= 100; i +=0.01)////////////////for (double i=0.0; i <= 10.0; i += 0.05)
            {
                if (GetNewY(i) > max)
                {
                    max = GetNewY(i);
                    indexMax = i;
                }
            }
            return Math.Round( indexMax, 3);
        }
        //public double GetY(double yAltMax)
        public double GetNewY(double x)//yAltMax-этообрезаное значение для каждой альтернативы, получаем из Stage3 (yAltMin)
        {
            double max = 0.0;
            for (int i = 0; i < yAltMax.Length; i++)
            {
                max = Math.Max(Math.Min(yCrit.GetAltern(i).GetY(x), yAltMax[i]), max);//минимальное значение из GetY и обрезанной альтернативы, 
                                                                                                    //потом берем максимальное по всем альтернативам
            }
            return max;
        }

        public void YOutput()
        {
            //Criterion yNew = yCriterion.CreateCopy();
            valueCrit = new double[critArray.Length];//хранит оценку по критериям (х)
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
            Console.WriteLine("Данные введены. Ожидайте.");

            


        }
    }
}
