using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace _1лаб
{
    public class Save
    {
        private Criterion[] critArray;
        private Criterion yCrit;
        private Rule[] ruleArray;








        Save(Criterion yCrit, Criterion[] critArray, Rule rule)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter myWriter = new StreamWriter(myStream);
                    try
                    {
                        for (int i = 0; i < clmnCount; i++)
                        {
                            myWriter.Write(columnName[i] + ';');
                        }
                        myWriter.WriteLine();
                        for (int row = 0; row < rowCount; row++)
                        {
                            //str = str1[row + 1].Split(';');
                            for (int column = 0; column < clmnCount; column++)
                            {
                                myWriter.Write(matrix[row, column].ToString() + ';');
                            }
                            myWriter.WriteLine();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        myWriter.Close();
                    }
                }
            }
        }
    }
}