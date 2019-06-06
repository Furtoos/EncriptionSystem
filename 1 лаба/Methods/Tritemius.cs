using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1_лаба
{
    public class Tritemius : Interface
    {
        public string tritemius(string Text, string alphabet, string method, double[] key, bool encription)
        {
            for (int i = 0; i < Text.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (Text[i] == alphabet[j])
                    {
                        int temp;
                        if (method == "Lineare")
                        {
                            if (encription)
                                temp = (j + Lineare(i, key[0], key[1])) % alphabet.Length;
                            else
                                temp = (j + alphabet.Length - ((Lineare(i, key[0], key[1])) % alphabet.Length)) % alphabet.Length;
                            Text = Text.Remove(i, 1).Insert(i, alphabet[temp].ToString());
                        }
                        if (method == "NonLineare")
                        {
                            if (encription)
                                temp = (j + NonLineare(i, key[0], key[1], key[2])) % EnglishAlphabet.Length;
                            else
                                temp = (j + alphabet.Length - ((NonLineare(i, key[0], key[1], key[2])) % alphabet.Length)) % alphabet.Length;
                            Text = Text.Remove(i, 1).Insert(i, alphabet[temp].ToString());
                        }
                        break;
                    }
                }
            }
            return Text;
        }
        public string tritemius(string Text, string alphabet, string method, string key, bool encription)
        {
            int k = 0;
            for (int i = 0; i < Text.Length; i++, k++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (Text[i] == alphabet[j])
                    {
                        if (k >= key.Length)
                            k = 0;
                        int temp;
                        if (encription)
                            temp = (j + Motto(key[k])) % alphabet.Length;
                        else
                            temp = (j + alphabet.Length - ((Motto(key[k])) % alphabet.Length)) % alphabet.Length;
                        Text = Text.Remove(i, 1).Insert(i, alphabet[temp].ToString());
                        break;
                    }
                }
            }
            return Text;
        }
        private int Lineare(int i, double a, double b)
        {
            return Convert.ToInt32(a * i + b);
        }
        private int NonLineare(int i, double a, double b, double c)
        {
            return Convert.ToInt32(a * Math.Pow(i, 2) + b * i + c);
        }
        private int Motto(char i)
        {
            return i;
        }
    }
}
