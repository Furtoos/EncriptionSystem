using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _1_лаба
{
    public class InVerse : Interface
    {
        public string inverse(string Text, string alphabet, OpenFileDialog file, bool encription)
        {
            char[,] Net = new char[14, 14];
            string[] keys = new string[14];
            keys = System.IO.File.ReadAllLines(file.FileName);
            int size_lenght = 0;
            int size_width = 0;
            //Розмітка вірша
            for (int i = 0; size_lenght < 14; i++)
            {
                keys[i] = keys[i].ToLower();
                for (int j = 0; size_width < 14; j++)
                {
                    //if (keys[i][j] == ' ' || keys[i][j] == ',' || keys[i][j] == '.')
                    //{
                    //    continue;
                    //}
                    Net[size_lenght, size_width] = keys[i][j];
                    size_width++;
                }
                size_lenght++;
                size_width = 0;
            }
            //Шифрування
            bool simvol;
            bool letter_indentificate = true;
            char letter = '\0';
            if (encription)
            {
                for (int i = 0; i < Text.Length; i++)
                {
                    if (letter_indentificate)
                        letter = Text[i];
                    simvol = false;
                    for (int row = 0; row < 14; row++)
                    {
                        for (int column = 0; column < 14; column++)
                        {
                            if (Net[row, column] == letter)
                            {
                                simvol = true;
                                letter_indentificate = true;
                                for (int j = 0; j < alphabet.Length; j++)
                                {
                                    if (letter == alphabet[j])
                                    {
                                        int temp;
                                        string row_string = row.ToString();
                                        string column_string = column.ToString();
                                        System.IO.File.AppendAllText(Application.StartupPath + @"\diagrama.txt", row_string + " " + column_string + " ");
                                        temp = (j + row + column) % alphabet.Length;
                                        Text = Text.Remove(i, 1).Insert(i, alphabet[temp].ToString());
                                        break;
                                    }
                                }
                            }
                            if (simvol)
                                break;
                        }
                        if (simvol)
                            break;
                    }
                    if (!simvol)
                    {
                        Info.index_of[i, 0] = i;
                        Info.index_of[i, 1]++;
                        for (int k = 0; k < alphabet.Length; k++)
                        {
                            if (letter == alphabet[k])
                            {
                                if (k == alphabet.Length - 1)
                                {
                                    letter = alphabet[0];
                                    break;
                                }
                                letter = alphabet[k + 1];
                            }
                        }
                        i--;
                        letter_indentificate = false;
                        continue;
                    }
                }
                return Text;
            }
            else
            {
                string diagram = System.IO.File.ReadAllText(Application.StartupPath + @"\diagrama.txt");
                if (diagram == null)
                    MessageBox.Show("Шифродіаграма пуста");
                string[] diagram_key = diagram.Split(new char[] { ' ' });

                for (int i = 0; i < Text.Length; i++)
                {
                    for (int j = 0; j < alphabet.Length; j++)
                    {
                        if (Text[i] == alphabet[j])
                        {
                            int row = int.Parse(diagram_key[2 * i]);
                            int column = int.Parse(diagram_key[2 * i + 1]);
                            char temp = Net[row, column];
                            if (i == Info.index_of[i, 0])
                            {
                                while (Info.index_of[i, 1] != 0)
                                {
                                    Info.index_of[i, 1]--;
                                    for (int k = 0; k < alphabet.Length; k++)
                                    {
                                        if (temp == alphabet[k])
                                        {
                                            if (k == 0)
                                            {
                                                temp = alphabet[alphabet.Length - 1];
                                                break;
                                            }
                                            temp = alphabet[k - 1];
                                        }
                                    }
                                };
                            }
                            Text = Text.Remove(i, 1).Insert(i, temp.ToString());
                            break;
                        }
                    }
                }
                return Text;
            }
        }
    }
}
