using System;
using System.IO;

namespace _1лаб
{
    class Program
    {
        
       
        static void Main(string[] args)
        {
            Criterion[] critArray;
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
            Criterion crit=new Criterion();

            for (int i = 0; i < count; i++)
            {
                crit.CritSet();
                critArray[i] = crit;
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
