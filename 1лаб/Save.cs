using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;


namespace _1лаб
{
    public class Save
    {
        //private Criterion[] critArray;
        //private Criterion yCrit;
        //private Rule[] ruleArray;



        public void CritSave(StreamWriter writer, Criterion crit)
        {
            writer.WriteLine(crit.Name + ';' + crit.CountAlt());
            FunctionMembership alt;
            for (int i = 0; i < crit.CountAlt(); i++)
            {
                alt = crit.GetAltern(i);
                writer.Write(alt.Name+';'+alt.GetType().ToString()+';');
                double[] options = alt.Options();
                for(int k = 0; k < options.Length; k++)
                {
                    writer.Write(options[k].ToString() + ';');
                }
                writer.WriteLine();
            }
            
        }


        //public void CritSave(string[] writer, Criterion crit)
        //{
        //    writer[w]=(crit.Name.ToString() + ';' + crit.CountAlt().ToString());
        //    FunctionMembership alt;
        //    for (int i = 0; i < crit.CountAlt(); i++)
        //    {
        //        alt = crit.GetAltern(i);
        //        w++;
        //        writer[w]=(alt.Name + ';' + alt.GetType().ToString() + ';');
        //        double[] options = alt.GetOptions();
        //        for (int k = 0; k < options.Length; k++)
        //        {
        //            writer[w]+=(options[i].ToString() + ';');
        //        }
        //        //writer.WriteLine();
        //    }

        //}

        //public void RuleSave(string[] writer, Rule rule)
        //{
        //    w++;
        //    writer[w] = rule.AndBool.ToString() + ';' +
        //                            rule.ACriterion.ToString() + ';' + rule.AAltIndex.ToString() + ';' +
        //                            rule.BCriterion.ToString() + ';' + rule.BAltIndex.ToString()
        //                                + ';' + rule.YAltIndex.ToString();
        //}

        public void RuleSave(StreamWriter writer, Rule rule)
        {
           
            writer.WriteLine(rule.AndBool.ToString() + ';' + 
                                    rule.ACriterion.ToString() + ';' + rule.AAltIndex.ToString() + ';' + 
                                    rule.BCriterion.ToString() + ';' + rule.BAltIndex.ToString()
                                        + ';' + rule.YAltIndex.ToString());
        }
        //public Criterion GetCriterion(string name,int countAlt,string []str )
        //{
        //    Criterion crit = new Criterion(name, countAlt);
        //    //string str[0]
        //    for (int i = 0; i < str.Length; i++)
        //    {
        //        FunctionMembership alt= GetAlt(str[i].Split(';') );
        //        crit.AddAltern(alt,i);
        //    }
        //    return crit;
        //}

        public (int, Criterion) GetCriterion( int index, string[] strFile)
        {

            string [] str = strFile[index].Split(';');
            int countAlt = int.Parse(str[1]);
            index++;
            Criterion crit = new Criterion(str[0], countAlt);
            //string str[0]
            for (int i = 0; i < countAlt; i++)
            {
                FunctionMembership alt = GetAlt(strFile[index + i].Split(';'));
                crit.AddAltern(alt, i);
            }
            index += countAlt;
            return (index, crit);
        }

        public FunctionMembership GetAlt( string [] str)//дополни потом
        {
            FunctionMembership alt;
            int type = int.Parse(str[1]);
            double[] options = new double[str.Length - 2];
            for(int i = 0; i < options.Length-1; i++)// потому что в конце стоит ";"
            {
                options[i] = double.Parse(str[i + 2]);
            }
            string name = str[0];
            if (type == 1)
            {
                alt =new TriangleFunc(name, options);
                return alt;
            }
            else if (type == 2)
            {
                alt = new TrapezeFunc(name, options);
                return alt;
            }
            //////////////////////
            ////


            else
            {
                return new FunctionMembership();
            }
        }

        public Rule GetRule(int index, string[] strFile)//rule
        {
            string[] str = strFile[index].Split(';');

            int[] options= new int[5];
            for(int i = 0; i < 5; i++)
            {
                options[i] = Convert.ToInt32(str[i + 1]);
            }

            Rule rule = new Rule(Convert.ToBoolean(str[0]), options);
            return rule;
        }

        //public void Restore(Criterion yCrit, Criterion[] critArray, Rule[] ruleArray, string nameFile = "D:/MIREX/1ч/MO/3сем/нс шахм/лабы/1лаб/1лаб/test.txt")
        //{

        //    using (StreamReader reader = new StreamReader(nameFile))
        //    {
        //        string[] str;


        //        try
        //        {
        //            string[] strFile = reader.ReadToEnd().Split('\n');
        //            int index = 0;
        //            str = strFile[index].Split(';');

        //            index++;

        //            int[] count = new int[] { int.Parse(str[0]), int.Parse(str[1]) };
        //            critArray = new Criterion[count[0]];
        //            ruleArray = new Rule[count[1]];

        //            //GetCriterion(Array.Copy(strFile,index))
        //            (index, yCrit) = GetCriterion(index, strFile);

        //            for(int i = 0; i < critArray.Length; i++)
        //            {
        //                (index, critArray[i] ) = GetCriterion(index, strFile);
        //            }

        //            for(int i = 0; i < ruleArray.Length; i++)
        //            {
        //                ruleArray[i] = GetRule(index + i, strFile);
        //            }

        //            //return (yCrit, critArray, ruleArray);
        //        }
        //        catch (IOException ex)
        //        {
        //            Console.WriteLine("Ошибка загрузки файла: " + ex.Message);
        //            return;
        //        }
        //        finally
        //        {
        //            reader.Close();
        //        }


        //    }
        //}



        public (Criterion, Criterion[],Rule[]) Restore( string nameFile = "test.txt")
        {
            string pathFile = "D:/MIREX/1ч/MO/3сем/нс шахм/лабы/1лаб/1лаб/"+nameFile;

            Criterion [] critArray;
            Criterion yCriterion ;
            Rule[] ruleArray;

            using (StreamReader reader = new StreamReader(pathFile))
            {
                string[] str;


                try
                {
                    string[] strFile = reader.ReadToEnd().Split('\n');
                    int index = 0;
                    str = strFile[index].Split(';');

                    index++;

                    int[] count = new int[] { int.Parse(str[0]), int.Parse(str[1]) };
                    critArray = new Criterion[count[0]];
                    ruleArray = new Rule[count[1]];

                    //GetCriterion(Array.Copy(strFile,index))
                    (index, yCriterion) = GetCriterion(index, strFile);

                    for (int i = 0; i < critArray.Length; i++)
                    {
                        (index, critArray[i]) = GetCriterion(index, strFile);
                    }

                    for (int i = 0; i < ruleArray.Length; i++)
                    {
                        ruleArray[i] = GetRule(index + i, strFile);
                    }

                    return (yCriterion, critArray, ruleArray);
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Ошибка загрузки файла: " + ex.Message);
                    return (null, null, null);
                }
                finally
                {
                    reader.Close();
                }


            }
        }




        public Save()
        {
            
        }

        //public int w = 0;
        //public string[] writer;
        public Save(Criterion yCrit, Criterion[] critArray, Rule []ruleArray, string nameFile = "test.txt")
        {
            string pathFile = "D:/MIREX/1ч/MO/3сем/нс шахм/лабы/1лаб/1лаб/" + nameFile;
            using (StreamWriter writer = new StreamWriter(pathFile, false))
            {
                //writer = new string[20];
                try
                {
                    ////int k = critArray.Length;
                    ////
                
                    writer.WriteLine( critArray.Length.ToString() + ';' + ruleArray.Length.ToString());
                        //w++;

                        //writer.WriteLine(critArray.Length + ';' + ruleArray.Length);

                   // double [] op= yCrit.GetAltern(0).Options();
                    CritSave(writer, yCrit);
                    

                    for (int i = 0; i < critArray.Length; i++)
                    {
                        CritSave(writer, critArray[i]);
                    }

                    for (int i = 0; i < ruleArray.Length; i++)
                    {
                        RuleSave(writer, ruleArray[i]);
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Ошибка записи в файл: " + ex.Message);
                    return;
                }
                finally
                {
                    writer.Close();
                }
                
            }

        }
    }
}