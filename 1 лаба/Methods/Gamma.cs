using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1_лаба
{
    public class Gamma : Interface
    {
        public string gamma(string Text, string alphabet, int key, bool encription)
        {
            Random rand = new Random(key);
            int random;
            for (int i = 0; i < Text.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (Text[i] == alphabet[j])
                    {
                        int temp;
                        random = rand.Next();
                        if (encription)
                        {
                            temp = (j + random) % alphabet.Length;
                        }
                        else
                        {
                            temp = (j + alphabet.Length - (random % alphabet.Length)) % alphabet.Length;
                        }
                        Text = Text.Remove(i, 1).Insert(i, alphabet[temp].ToString());
                        break;
                    }
                }
            }
            return Text;
        }

    }
}
