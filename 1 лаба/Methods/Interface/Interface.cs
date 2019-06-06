using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _1_лаба
{
    public abstract class Interface
    {
        public string EnglishAlphabet = "abcdefghijklmnopqrstuvwxyz ,.-";
        public string UkraineAlphabet = "абвгдєжзишїйклмнопрстуфхцчшщьюя ,.-";
        public bool CheckText(string Text)
        {
            if (Text == null || Text == "")
            {
                MessageBox.Show("Поле пусте");
                return true;
            }
            return false;
        }
        public bool CheckKey(string method, string[] Methods)
        {
            bool key = true;
            foreach (string word in Methods)
            {
                if (word == method)
                {
                    key = false;
                }
            }
            return key;
        }
    }
}
