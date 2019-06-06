using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _1_лаба
{
    public class BAG : Interface
    {
        public string bag_encription(string Text, string alphabet, int[] array_close)
        {
            Info.bag_open_key = new int[Text.Length];
            for (int i = 0; i < 8; i++)
            {
                System.IO.File.AppendAllText(Application.StartupPath + @"\Key_close.txt", array_close[i] + " ");
            }
            int m = 0;
            for (int i = 0; i < array_close.Length; i++)
            {
                m += array_close[i];
            }
            m += 2;
            int n = 0;
            for (int i = 1; n == 0; i++)
            {
                if (NOD(i, m) == 1)
                {
                    n = i;
                }
            }
            //int[] array_close = {2, 3, 6, 13, 27, 52, 105, 210};
            int[] array_open = new int[8];
            Info.open_key = new int[8];
            for (int i = 0; i < array_close.Length; i++)
            {
                array_open[i] = array_close[i] * n % m;
                Info.open_key[i] = array_close[i] * n % m;
            }
            for (int i = 0; i < Text.Length; i++)
            {
                int numeric = Convert.ToInt32(Text[i]);
                string str = "";
                for (int j = 0; j < 8; j++)
                {
                    if (numeric % 2 == 1)
                        str += "1";
                    else
                        str += "0";
                    numeric /= 2;
                }
                string str2 = "00000000";
                for (int j = 0; j < 8; j++)
                {
                    str2 = str2.Remove(7 - j, 1).Insert(7 - j, str[j].ToString());
                }
                int sum = 0;
                for (int j = 0; j < 8; j++)
                {
                    if (str2[j] == '1')
                    {
                        sum += array_open[j];
                    }
                }
                Info.bag_open_key[i] = sum;
                char simvol = Convert.ToChar(sum);
                Text = Text.Remove(i, 1).Insert(i, simvol.ToString());
            }
            return Text;
        }
        public string bag_decription(string Text, string alphabet, int[] bag_open)
        {

            int m = 0;
            string array_close_string = System.IO.File.ReadAllText(Application.StartupPath + @"\Key_close.txt");

            string[] array_string = array_close_string.Split(new char[] { ' ' });
            int[] array_close = new int[8];
            for (int i = 0; i < 8; i++)
            {
                array_close[i] = Convert.ToInt32(array_string[i]);
            }
            for (int i = 0; i < array_close.Length; i++)
            {
                m += array_close[i];
            }
            m += 2;
            int n = 0;
            for (int i = 1; n == 0; i++)
            {
                if (NOD(i, m) == 1)
                {
                    n = i;
                }
            }
            int n_ = ModPow(n, 20, m);
            //int[] array_close = { 2, 3, 6, 13, 27, 52, 105, 210 };
            for (int i = 0; i < Text.Length; i++)
            {
                string bag = Bag_function(array_close, (bag_open[i] * n_) % m);
                int sum = 0;
                for (int j = 7; j >= 0; j--)
                {
                    if (bag[j] == '1')
                    {
                        sum += Convert.ToInt32(Math.Pow(2, 7 - j));
                    }
                }
                char simvol = Convert.ToChar(sum);
                //Text += bag + "   " + sum + "\n";
                Text = Text.Remove(i, 1).Insert(i, simvol.ToString());
            }
            return Text;
        }
        public string Bag_function(int[] array, int numeric)
        {
            string full_bag = "00000000";
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (numeric >= array[i])
                {
                    full_bag = full_bag.Remove(i, 1).Insert(i, "1");
                    numeric -= array[i];
                }
            }
            return full_bag;
        }
        public static int NOD(int a, int b)
        {
            if (a == b)
                return a;
            else
                if (a > b)
                return NOD(a - b, b);
            else
                return NOD(b - a, a);
        }
        public int ModPow(int a, int b, int n)
        {
            int result = 1;
            for (int i = 1; i <= b; ++i)
                result *= a % n;
            result %= n;
            return result;
        }
    }
}
