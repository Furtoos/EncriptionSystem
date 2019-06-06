using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1_лаба
{
    public class Caesar : Interface
    {
        public string caesar(string Text, string alphabet, int key)
        {
            for (int i = 0; i < Text.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (Text[i] == alphabet[j])
                    {
                        int temp = ((j + key) % alphabet.Length);
                        if (temp < 0)
                            temp += alphabet.Length;
                        Text = Text.Remove(i, 1).Insert(i, alphabet[temp].ToString());
                        break;
                    }
                }
            }
            return Text;
        }
    }
}
