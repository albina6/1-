using System;
using System.IO;

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
            Console.WriteLine("Введите количество критериев");
            int count;
            try
            {
                count = Convert.ToInt32(Console.ReadLine());
            }

            catch (IOException e)
            {
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine(e.Message);
                errorWriter.WriteLine("введено не число");
                return;
            }
            critArray = new Criterion[count];
            Criterion crit;

            for (int i = 0; i < count; i++)
            {
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
