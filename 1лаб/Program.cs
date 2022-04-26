using System;
using System.IO;
using System.Windows.Forms;
namespace _1лаб
{
    class Program
    {
        
       
        static void Main(string[] args)
        {
            
            //FunctionMembership alt = new TriangleFunc("god", 1, 3, 7);
            //double q, w, d, r, t, y;
            //q = alt.GetY(0);
            //w = alt.GetY(1);
            //d = alt.GetY(2);
            // r= alt.GetY(3);
            // t= alt.GetY(5);
            //y = alt.GetY(7);

            Criterion[] critArray;
            Criterion yCriterion;
            Rule[] ruleArray;

            //critArray = new Criterion[2];
            //critArray[0] = new Criterion("Температура", 3);
            //FunctionMembership alt1 = new TrapezeFunc("Низкая", 0, 0, 50, 100);
            //FunctionMembership alt2 = new TrapezeFunc("Средняя", 0, 50, 100,150);
            //FunctionMembership alt3 = new TrapezeFunc("Высокая", 50, 100,150,150);

            //critArray[0].AddAltern(alt1, 0);
            //critArray[0].AddAltern(alt2, 1);
            //critArray[0].AddAltern(alt3, 2);


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
            //FunctionMembership alty3 = new TriangleFunc("Высокая", 0, 100,100);

            //yCriterion.AddAltern(alty1, 0);
            //yCriterion.AddAltern(alty2, 1);
            //yCriterion.AddAltern(alty3, 2);




            //ruleArray = new Rule[3];

            //ruleArray[0] = new Rule(true, 0, alt1, 1, alt21, 0, alty1);
            //ruleArray[1] = new Rule(true, 0, alt2, 0, alt2, 1, alty2);
            //ruleArray[2] = new Rule(false, 0, alt3, 1, alt23, 2, alty3);

            //OutputVariable re = new OutputVariable(yCriterion, ruleArray, critArray);
            //double y =re.Course();

            Console.WriteLine("Введите количество критериев");
            int count=1;
            bool flag = true;
            while ( flag == true)
            {
                string s = Console.ReadLine();
                if (!int.TryParse(s, out int answer))
                {

                    Console.WriteLine("введено не число");
                }
                else
                {
                    count = Convert.ToInt32(s);
                    flag = false;
                } 
                        
                //if (Convert.ToInt32(s))
                //{
                //    count = Convert.ToInt32(Console.ReadLine());
                //}

                //catch (IOException e)

                //{
                //    Console.WriteLine("введено не число");
                //    count = 1;
                //    //TextWriter errorWriter = Console.Error;
                //    //errorWriter.WriteLine(e.Message);
                //    //errorWriter.WriteLine("введено не число");
                //}
            }
            
            critArray = new Criterion[count];
            Criterion crit;

            for (int i = 0; i < count; i++)
            {
                Console.Clear();
                crit = new Criterion();
                crit.CritSet();
                critArray[i] = crit;
            }

            //critArray[1].getAltern(0).GetY()
            Console.Clear();
            Console.WriteLine("Вы заполнили критерии.\n");
            Console.WriteLine("Теперь необходимо заполнить результирующую переменную");
            yCriterion = new Criterion();
            yCriterion.CritSet();

            Console.WriteLine("Вы заполнили критерии.\n");


            Console.WriteLine("Введите количество правил.\n");

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

            ruleArray = new Rule[countRule];
            for (int i = 0; i < countRule; i++)
            {
                Console.Clear();
                ruleArray[i] = new Rule(critArray, yCriterion);
            }

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
            








                TriangleFunc tri;
            Console.WriteLine("Hello World!");
            string name = Console.ReadLine();

            Console.WriteLine("A");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("B");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("C");
            double c = Convert.ToDouble(Console.ReadLine());
            tri = new TriangleFunc(name, a, b, c);
        }
    }
}
