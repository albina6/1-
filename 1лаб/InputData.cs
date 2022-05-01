using System;
using System.Collections.Generic;
using System.Text;

namespace _1лаб
{
    public class InputData
    {
        private int InCheckData() 
        {
            int value = 1;
            bool flag = true;
            while (flag == true)
            {
                string s = Console.ReadLine();
                if (!int.TryParse(s, out int answer))
                {

                    Console.WriteLine("введено не число");
                }
                else
                {
                    value = Convert.ToInt32(s);
                    flag = false;
                }

                
            }
            return value;
        }
        private Criterion []InputCrit( )
        {
            Console.WriteLine("Введите количество критериев");

            int count = InCheckData();
           

            Criterion[] critArray = new Criterion[count];
            Criterion crit;

            for (int i = 0; i < count; i++)
            {
                Console.Clear();
                crit = new Criterion();
                crit.CritSet();
                critArray[i] = crit;
            }
            return critArray;
        }
        private Rule [] InputRule(Criterion yCrit,Criterion [] critArray)
        {
            Console.Clear();
            Console.WriteLine("Введите количество правил.\n");


            int countRule = InCheckData();
           

            Rule[] ruleArray = new Rule[countRule];
            for (int i = 0; i < countRule; i++)
            {
                Console.Clear();
                ruleArray[i] = new Rule(critArray, yCrit);
            }
            return ruleArray;
        }
        public InputData(Criterion yCrit,Criterion[] critArray, Rule[] ruleArray)
        {
            critArray = InputCrit();

            //critArray[1].getAltern(0).GetY()
            Console.Clear();
            Console.WriteLine("Вы заполнили критерии.\n");
            Console.WriteLine("Теперь необходимо заполнить результирующую переменную");

            //yCrit = new Criterion();
            yCrit.CritSet();

            Console.WriteLine("Вы заполнили критерии.\n");
                        
            ruleArray = InputRule(yCrit,critArray);
            

           // double[] op = yCriterion.GetAltern(0).Options();
        }
    }
}
