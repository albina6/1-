using System;
using System.IO;

namespace _1лаб
{
    class Program
    {
        static void Restre()
        {
            bool fl = true;
            while (fl)
            {
                Console.WriteLine("Введите название документа с которого хотите загрузить данные" +
                                 " или нажмите Enter, если хотите загрузить данные из документа по умолчанию ");
                try
                {
                    string nameFile = Console.ReadLine();
                    if (save.Restore(nameFile) != (null, null, null))
                    {
                        (yCrit, critArray, ruleArray) = save.Restore(nameFile);
                        /*1*/
                        fl = false;
                    }
                    else
                        Console.WriteLine("Введены некорректные данные. Повторите попытку");
                }
                catch
                {
                    Console.WriteLine("Введены некорректные данные. Повторите попытку");
                }

            }
        }
        static void Question(Criterion yCrit, Criterion[] critArray, Rule[] ruleArray) 
        {
            Console.Clear();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Нажмите 1, если хотите загрузить данные с диска. ");
                Console.WriteLine("Нажмите 2, если хотите ввести данные с использованием консоли. ");

               
                if ((yCrit != null) && (critArray != null) && (ruleArray != null))
                {
                    Console.WriteLine("Нажмите 3, если хотите отредактировать введенные данные. ");
                    Console.WriteLine("Нажмите 4, если хотите сохранить введенные данные на диск. ");
                    Console.WriteLine("Нажмите 5, если хотите продолжить и произвести расчет. ");
                }
                int value = 0;
                string s = Console.ReadLine();


                if (!int.TryParse(s, out int answer))
                {

                    Console.WriteLine("Введены некорректные данные. Повторите попытку");
                }
                else
                {
                    Save save = new Save();
                    value = Convert.ToInt32(s);
                    if (value == 1)
                    {
                        
                    }

                    if (value == 2)
                    {
                    
                    }



                        flag = false;
                }




                outputI = new OutputVariable(yCriterion, ruleArray, critArray);
                Console.WriteLine(outputI.Course());

                Console.WriteLine("Хотите ввести другие данные?\n(+/-)");

                char s = Console.ReadKey().KeyChar;
                if (s == '+')
                {

                }
                else if (s == '-')
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Вы ввели неправильный знак.\nПовторите попытку.\n");
                }
            }
        }
        static void Main(string[] args)
        {
            //Criterion[] critArray;
            //Criterion yCriterion;
            //Rule[] ruleArray;






            //critArray = new Criterion[2];
            //critArray[0] = new Criterion("Температура", 3);
            //FunctionMembership alt1 = new TrapezeFunc("Низкая", 0, 0, 50, 100);
            //double[] op2 = alt1.Options();
            //FunctionMembership alt2 = new TrapezeFunc("Средняя", 0, 50, 100, 150);
            //FunctionMembership alt3 = new TrapezeFunc("Высокая", 50, 100, 150, 150);

            //critArray[0].AddAltern(alt1, 0);
            //critArray[0].AddAltern(alt2, 1);
            //critArray[0].AddAltern(alt3, 2);




            //double[] op1 = critArray[0].GetAltern(0).Options();

            //critArray[1] = new Criterion("Расход", 3);
            //FunctionMembership alt21 = new TriangleFunc("Малый", 0, 2, 4);
            //FunctionMembership alt22 = new TriangleFunc("Средний", 2, 4, 6);
            //FunctionMembership alt23 = new TriangleFunc("Большой", 4, 6, 8);

            //critArray[1].AddAltern(alt21, 0);
            //critArray[1].AddAltern(alt22, 1);
            //critArray[1].AddAltern(alt23, 2);


            //yCriterion = new Criterion("Давление", 3);
            //FunctionMembership alty1 = new TriangleFunc("Низкая", 0, 0, 100);
            //FunctionMembership alty2 = new TriangleFunc("Средняя", 0, 50, 100);
            //FunctionMembership alty3 = new TriangleFunc("Высокая", 0, 100, 100);

            //yCriterion.AddAltern(alty1, 0);
            //yCriterion.AddAltern(alty2, 1);
            //yCriterion.AddAltern(alty3, 2);


            //ruleArray = new Rule[3];

            //ruleArray[0] = new Rule(true, 0, 0, 1, 0, 0);
            //ruleArray[1] = new Rule(true, 0, 1, 0, 1, 1);
            //ruleArray[2] = new Rule(false, 0, 2, 1, 2, 2);

            //double[] op = yCriterion.GetAltern(0).Options();

            //Save save = new Save(yCriterion, critArray, ruleArray);
            //int g = 0;

            //critArray = new Criterion[1];
            //yCriterion = new Criterion();
            //ruleArray = new Rule[1];


            //(yCriterion, critArray, ruleArray) = save.Restore();



            







            Criterion[] critArray;
            Criterion yCriterion;
            Rule[] ruleArray;



            //// Save save = new Save(yCriterion, critArray, ruleArray);

            Save save = new Save();
            int g = 0;

            critArray = new Criterion[1];
            yCriterion = new Criterion();
            ruleArray = new Rule[1];


            (yCriterion, critArray, ruleArray) = save.Restore();

            // save.Restore(yCriterion, critArray, ruleArray);

            OutputVariable outputI;
            flag = true;
            while (flag)
            {
                outputI = new OutputVariable(yCriterion, ruleArray, critArray);
                Console.WriteLine(outputI.Course());

                Console.WriteLine("Хотите ввести другие данные?\n(+/-)");

                char s = Console.ReadKey().KeyChar;
                if (s == '+')
                {

                }
                else if (s == '-')
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Вы ввели неправильный знак.\nПовторите попытку.\n");
                }
            }









            //    TriangleFunc tri;
            //Console.WriteLine("Hello World!");
            //string name = Console.ReadLine();

            //Console.WriteLine("A");
            //double a = Convert.ToDouble(Console.ReadLine());

            //Console.WriteLine("B");
            //double b = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("C");
            //double c = Convert.ToDouble(Console.ReadLine());
            //tri = new TriangleFunc(name, a, b, c);
        }
    }
}
