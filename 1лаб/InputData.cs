using System;
using System.Collections.Generic;
using System.Text;

namespace _1лаб
{
    public class InputData
    {
        private Criterion yCrit;
        private Criterion[] critArray;
        private Rule[] ruleArray;







        private void Save()
        {
            Save save;
            bool fl = true;
            while (fl)
            {
                Console.WriteLine("Введите название нового документа\n" +
                                 " или нажмите Enter, если хотите загрузить данные в документ по умолчанию. ");

                try
                {
                    string nameFile = Console.ReadLine();
                    //if (nameFile == ConsoleKey.Enter)
                    //{
                    //    (yCrit, critArray, ruleArray) = save.Restore();
                    //}
                    if (nameFile == "")
                    {
                        save = new Save(yCrit, critArray, ruleArray);
                        fl = false;
                    }
                    else
                    {
                        save = new Save(yCrit, critArray, ruleArray, nameFile);
                        fl = false;
                    }

                }
                catch
                {
                    Console.WriteLine("Введены некорректные данные. Повторите попытку");
                }




                
            }
        }

        private void Restore()
        {
            Save save = new Save();
            bool fl = true;
            while (fl)
            {
                Console.WriteLine("Введите название документа с которого хотите загрузить данные\n" +
                                 " или нажмите Enter, если хотите загрузить данные из документа по умолчанию. ");
                try
                {
                    string nameFile = Console.ReadLine();
                    //if (nameFile == ConsoleKey.Enter)
                    //{
                    //    (yCrit, critArray, ruleArray) = save.Restore();
                    //}
                    if (nameFile == "")
                    {
                        (yCrit, critArray, ruleArray) = save.Restore();
                        fl = false;
                    }
                    else if (save.Restore(nameFile) != (null, null, null))
                    {
                        (yCrit, critArray, ruleArray) = save.Restore(nameFile);
                        /*1*/
                        fl = false;
                    }
                    else
                        Console.WriteLine("Введены некорректные данные. Повторите попытку ввода названия документа");
                }
                catch
                {
                    Console.WriteLine("Введены некорректные данные. Повторите попытку");
                }

            }


            //(yCrit, critArray, ruleArray) = save.Restore(nameFile);
        }

        private int InCheckData(int max=10000) 
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
                else if ((Convert.ToInt32(s) > max)&&(Convert.ToInt32(s)<1))
                {
                    Console.WriteLine("Вы ввели число которое не входит в ожидаемый диапазон.\n Повторите попытку.");
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
        public bool YesNo()
        {
            bool fl = true;
            bool value = true;
            while (fl)
            {
                string yesNo= Console.ReadLine();
                if (yesNo == "+")
                {
                    value = true;
                    fl = false;
                }
                else if (yesNo == "-")
                {
                    value= false;
                    fl = false;
                }
                else
                {
                    Console.WriteLine("Введен неверный символ.\nПовторите попытку");
                }
            }
            return value;


        }
        public void RedactCrit(Criterion crit)
        {
            
            bool fl = true;
            while (fl)
            {
                Console.Clear();
                PrintCrit(crit, true);

                Console.WriteLine("Введите номер элемента, который хотите отредактировать");
                Console.WriteLine("Если необходимо отредактировать критерий полностью нажмите " + (crit.CountAlt() + 1).ToString());
                int index = InCheckData(crit.CountAlt() + 1);

                if (index <= crit.CountAlt())
                {
                    crit.SetAltern(index - 1);// индексация начинается с 0, но для удобмства пользователя отображается индексация с 1
                }
                else
                    crit.CritSet();

                Console.WriteLine("Хотите продолжить редактирование данного критерия\n+/-");
                fl = YesNo();


            }
        }
        public void RedactRule(Rule rule)
        {
            rule = new Rule(critArray, yCrit);
        }

        public void RedactData()
        {
            int indexMax= PrintData();
            Console.WriteLine("\nВведите номер элемента, который хотите отредактировать");
            int index = InCheckData(indexMax);
            if (index <= critArray.Length)
            {
                RedactCrit(critArray[index]);
            }
            else if (index == critArray.Length + 1)
            {
                RedactCrit(yCrit);
            }
            else
                RedactRule(ruleArray[index - critArray.Length - 1]);//нужно вычисть все критерии 
        }

        public void PrintRule(Rule rule)
        {
            string and = rule.AndBool ? " and " : " or ";
            Console.WriteLine("Альтернатива " + critArray[rule.ACriterion].GetAltern(rule.AAltIndex).Name + " критерия" + critArray[rule.ACriterion].Name +
                                and + "Альтернатива " + critArray[rule.BCriterion].GetAltern(rule.BAltIndex).Name + " критерия" + critArray[rule.BCriterion].Name +
                                     " = " + "Альтернатива " + yCrit.GetAltern(rule.YAltIndex).Name + " критерия" + yCrit.Name);
        }
        public void PrintCrit(Criterion crit, bool flag = false)
        {
            Console.WriteLine(crit.Name + ": ");
            for(int i = 0; i < crit.CountAlt(); i++)
            {
                if (flag)
                    {
                        Console.WriteLine((i + 1).ToString());
                    }
                
                PrintAlt(crit.GetAltern(i));
            }
        }
        public void PrintAlt(FunctionMembership alt)
        {
            Console.WriteLine(alt.Name + ": " + alt.GetTypeSTR);
            double[] op = alt.GetOptions();
            for (int i = 0; i < op.Length; i++)
            {
                
                Console.Write(op[i].ToString() + "; ");
            }
            Console.WriteLine();
        }
        public int PrintData()
        {
            Console.Clear();
            int index = 0;
            for (int i = 0; i < critArray.Length; i++)
            {
                index++;
                Console.WriteLine("№ " + index);
                PrintCrit(critArray[i]);
            }
            index++;
            Console.WriteLine("№ " + index);
            Console.WriteLine("Результирующий критерий");
            PrintCrit(yCrit);

            for(int i = 0; i < ruleArray.Length; i++)
            {
                index++;
                Console.WriteLine("№ " + index);
                PrintRule(ruleArray[i]);
            }

            return index;
        }


        public void SetData()
        {
            //Criterion yCrit;
            //Criterion[] critArray;
            //Rule[] ruleArray;



            critArray = InputCrit();

            //critArray[1].getAltern(0).GetY()
            Console.Clear();
            Console.WriteLine("Вы заполнили критерии.\n");
            Console.WriteLine("Теперь необходимо заполнить результирующую переменную");

            //yCrit = new Criterion();
            yCrit = new Criterion();

            Console.WriteLine("Вы заполнили критерии.\n");

            ruleArray = InputRule(yCrit, critArray);


            // double[] op = yCriterion.GetAltern(0).Options();
        }
        //public InputData(Criterion yCrit,Criterion[] critArray, Rule[] ruleArray)
        //{




        //    critArray = InputCrit();

        //    //critArray[1].getAltern(0).GetY()
        //    Console.Clear();
        //    Console.WriteLine("Вы заполнили критерии.\n");
        //    Console.WriteLine("Теперь необходимо заполнить результирующую переменную");

        //    //yCrit = new Criterion();
        //    yCrit.CritSet();

        //    Console.WriteLine("Вы заполнили критерии.\n");

        //    ruleArray = InputRule(yCrit,critArray);


        //   // double[] op = yCriterion.GetAltern(0).Options();
        //}

        private void Calculation()
        {
            OutputVariable output = new OutputVariable(yCrit, ruleArray, critArray);
            bool fl = true;
            while (fl)
            {
                Console.WriteLine(output.Course());
                Console.WriteLine("Хотите ввести другие данные?(+/-)");
                fl = YesNo();
            }

        }

        public InputData()
        {
            Criterion yCrit;
            Criterion[] critArray;
            Rule[] ruleArray;
            Question();
        }





        void Question()
        {
            Console.Clear();
            bool flag = true;
            while (flag)
            {
                int max = 2;
                Console.WriteLine("Нажмите 1, если хотите загрузить данные с диска. ");
                Console.WriteLine("Нажмите 2, если хотите ввести данные с использованием консоли. ");


                if ((yCrit != null) && (critArray != null) && (ruleArray != null))
                {
                    Console.WriteLine("Нажмите 3, если хотите отредактировать введенные данные. ");
                    Console.WriteLine("Нажмите 4, если хотите сохранить введенные данные на диск. ");
                    Console.WriteLine("Нажмите 5, если хотите продолжить и произвести расчет. ");

                    max = 5;
                }
                max++;
                Console.WriteLine("Нажмите " + max .ToString() + ", если хотите выйти из программы. ");
                int value = InCheckData(max);
                Console.Clear();
                if(value == max)
                {
                    flag = false;
                }

                else if (value == 1)
                {

                Restore();
                }

                else if (value == 2)
                {
                    SetData();

                }

                else if(value == 3)
                {
                    RedactData();
                }
                else if (value == 4)
                {
                    Save();
                }
                else
                {
                    Calculation();
                }
                //else
                //{
                //    flag = false;
                //}

            }
            Console.WriteLine("Спасибо, за то что воспользовались нашей программой.");
            int hh = 0;

        }



    }
}
