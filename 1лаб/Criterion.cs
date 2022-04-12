using System;
using System.Collections.Generic;
using System.Text;

namespace _1лаб
{
    public class Criterion
    {
        private string nameCriterion;
        private FunctionMembership[] alternArray;

        public Criterion()
        {
            this.nameCriterion = "Критерий";
            //this.countAlt = 0;
            alternArray = new FunctionMembership[1];
        }
        public Criterion(string nameCriterion, int countAltern)
        {
            this.nameCriterion = nameCriterion;
            alternArray = new FunctionMembership[countAltern];

        }

        public void CritSet()
        {
            Console.WriteLine("Ведите название критерия." );
            string nameCrit = Console.ReadLine();

            Console.WriteLine("Ведите количество альтернатив критерии "+ nameCrit);
            int countAltern = Convert.ToInt32(Console.ReadLine());
            this.Name = nameCrit;
            this.alternArray = new FunctionMembership[countAltern];
            for(int i = 0; i < countAltern; i++)
            {
                alternArray[i]=SetAltern(i);
            }

        }
        public string Name
        {
            get => nameCriterion;
            set => nameCriterion = value;
        }
        public void NewAlternArray(int count)
        {
            alternArray = new FunctionMembership[count];
        }

        public void AddAltern(FunctionMembership altern, int index)
        {
            alternArray[index] = altern;
        }
        public FunctionMembership SetAltern( int i)
        {
            FunctionMembership altern;
            Console.WriteLine("Ведите название альтернативы №" + i.ToString());
            string nameAltern = Console.ReadLine();

            Console.WriteLine("Выберете тип функции принадлежности для альтернативы \"" + nameAltern + "\"");
            Console.WriteLine("Для этого введите номер необходимой Вам функции из списка ниже:");
            Console.WriteLine("1 Треугольная");
            Console.WriteLine("2 Трапецеидальная");
            Console.WriteLine("3 Z-образная");
            Console.WriteLine("4 S-образная");
            var typeKey = Console.ReadKey();

            
            Console.WriteLine("\nВведите параметр a");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите параметр b");
            double b = Convert.ToDouble(Console.ReadLine());

            //switch (typeKey.Key) //Switch on Key enum
            //{
            //    case ConsoleKey.D1:
            //        Console.WriteLine("Введите параметр c");
            //        double c = Convert.ToDouble(Console.ReadLine());
            //        altern = new TriangleFunc(nameAltern, a, b, c);
            //        break;

            //    case ConsoleKey.D2:
            //        Console.WriteLine("Введите параметр c");
            //        double c = Convert.ToDouble(Console.ReadLine());
            //        Console.WriteLine("Введите параметр d");
            //        double d = Convert.ToDouble(Console.ReadLine());
            //        altern = new TrapezeFunc(nameAltern, a, b, c, d);
            //        break;

            //    default:
            //        Console.WriteLine("Что-то не чисто...");
            //        break;
            //}


            if (typeKey.Key == ConsoleKey.D1)           //Треугольная
            {
                Console.WriteLine("Введите параметр c");
                double c = Convert.ToDouble(Console.ReadLine());
                altern = new TriangleFunc(nameAltern, a, b, c);
                return altern;
            }
            //else if (typeKey ==2)       //Трапецеидальная
            //{
            //    Console.WriteLine("Введите параметр c");
            //    double c = Convert.ToDouble(Console.ReadLine());

            //    Console.WriteLine("Введите параметр d");
            //    double d = Convert.ToDouble(Console.ReadLine());
            //    altern = new TrapezeFunc(nameAltern, a, b, c,d);
            //    return altern;
            //}
            //else if (typeKey == 3)       //Z-образная
            //{
            //    altern = new
            //}
            //else if (typeKey == 4)       //S-образная
            //{
            //    altern = new
            //}
            else
            {
                Console.WriteLine("Введите параметр c");
                double c = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Введите параметр d");
                double d = Convert.ToDouble(Console.ReadLine());
                altern = new TrapezeFunc(nameAltern, a, b, c, d);
                return altern;
            }


        }

        public void InitializationAltern()
        {

            for (int i = 0; i < alternArray.Length; i++)
            {
                Console.Clear();
                Console.WriteLine("Введите параметры необходимые для инициализации критерия "
                    + this.Name);
                alternArray[i] = SetAltern(i);

            }


        }
    }
}
