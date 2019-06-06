using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace _1_лаба
{
    public partial class KeysInspector : Form
    {
        public string Methods;
        public string EntryText;
        public KeysInspector(string EntryField)
        {
            EntryText = EntryField;
            InitializeComponent();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            Info.keys = new string[2];
            if (Key.Text != "\0")
                Info.keys[0] = Key.Text;
            else
            {
                Info.keys[0] = "0";
                Hide();
                this.Close();
            }
            Methods += "\nNULL";
            Info.keys[1] = Methods;
            Info.main_icon.SetInformation();
            Hide();
            this.Close();
        }
        private void Check_Click(object sender, EventArgs e)
        {
            if(Methods != "InVerse")
            {
                Methods = null;
            }
            int probel = 0;
            string word_NonInt = null;
            string[] words = Key.Text.Split(new char[] { ' ' });
            foreach(string word in words)
            {
                if (!Int32.TryParse(word, out int key) && probel == 0)
                {
                    Methods = "Tritemius.Motto";
                    break;
                }
                if (!Int32.TryParse(word, out key))
                {
                    word_NonInt = Convert.ToString(probel);
                }
                probel++;
            }
            probel--;
            if(Methods == "Tritemius.Motto")
            {
                if (Key.Text.Length % 8 == 0)
                {
                    Methods += "\nDES";
                }
                Methods_rich.Text = Methods;
                return;
            }
            if (probel == 0)
            {
                Methods = "Caesar\nTritemius.Motto\nGamma";
            }
            else
            {
                if (probel == 1 && word_NonInt == null)
                {
                    Methods = "Caesar\nTritemius.Lineare\nTritemius.Motto\nGamma";
                }
                else
                {
                    if (probel == 1)
                    {
                        Methods = "Caesar\nTritemius.Motto\nGamma";
                    }
                    else
                    {
                        if (probel == 2 && word_NonInt == null)
                        {
                            Methods = "Caesar\nTritemius.Lineare\nTritemius.NonLineare\nTritemius.Motto\nGamma";
                        }
                        else
                        {
                            Methods = "Caesar\nTritemius.Lineare\nTritemius.Motto\nGamma";
                        }
                    }
                }
            }
            if(Key.Text.Length % 8  == 0)
            {
                Methods += "\nDES\nRES";
            }
            int numerics = 0;
            for(int i = 0; i < Key.Text.Length;i++)
            {
                if(Key.Text[i] == ' ')
                {
                    numerics++;
                }
            }
            string[] Keys;
            bool BAG = true;
            if(Info.encrypt)
            {
                if (numerics == 7)
                {
                    Keys = Key.Text.Split(new char[] { ' ' });
                    int temp;
                    for (int i = 0; i < Keys.Length; i++)
                    {
                        if (!Int32.TryParse(Keys[i], out temp))
                        {
                            BAG = false;
                        }
                    }
                    if (BAG)
                    {
                        Methods += "\nBAG";
                    }
                }
            }
            else
            {
                    Keys = Key.Text.Split(new char[] { ' ' });
                    int temp;
                    for (int i = 0; i < Keys.Length; i++)
                    {
                        if (!Int32.TryParse(Keys[i], out temp))
                        {
                            BAG = false;
                        }
                    }
                    if (BAG)
                    {
                        Methods += "\nBAG";
                    }
            } 
            Methods_rich.Text = Methods;
        }

        private void Review_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Info.inverse_verse = openFileDialog1;
            if(Methods == null)
            {
                Methods = "InVerse";
                Methods_rich.Text = "InVerse";
            }
            else
            {
                Methods += "\nInVerse";
                Methods_rich.Text += "\nInVerse";
            }    
        }
    }
}
