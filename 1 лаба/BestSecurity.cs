using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace _1_лаба
{
    public partial class BestSecurity : Form
    {
        public string[] Methods;
        string Key;
        string LastOpenFile;
        string TempCopyString;
        public BestSecurity()
        {
            InitializeComponent();
            if (Info.keys != null)
            {
                Key = Info.keys[0];
                int methods = 0;
                for (int i = 0; i < Info.keys[1].Length; i++)
                {
                    if (Info.keys[1][i] == '\n')
                    {
                        methods++;
                    }
                }
                Methods = new string[methods + 1];
                Methods = Info.keys[1].Split(new char[] { '\n' });
                EntryField.Text = Info.keys[1] + "fuck";
            }
            else
            {
                Info.encrypt = true;
                Info.language = "Англійський";
            }
            Info.index_of = new int[50, 2];
            Info.main_icon = this;
            English_Alphabet.Image = Image.FromFile(Application.StartupPath + @"\Picture\galka.jpg");
            Encrypt.Image = Image.FromFile(Application.StartupPath + @"\Picture\galka.jpg");
            System.IO.File.Delete(Application.StartupPath + @"\diagrama.txt");
            System.IO.File.Delete(Application.StartupPath + @"\Key_for_bag.txt");
            System.IO.File.Delete(Application.StartupPath + @"\Key_close.txt");
            System.IO.File.Delete(Application.StartupPath + @"\publicKey.txt");
            System.IO.File.Delete(Application.StartupPath + @"\privateKey.txt");

        }
        public void SetInformation()
        {
            Key = Info.keys[0];
            int methods = 0;
            for (int i = 0; i < Info.keys[1].Length; i++)
            {
                if (Info.keys[1][i] == '\n')
                {
                    methods++;
                }
            }
            Methods = new string[methods + 1];
            Methods = Info.keys[1].Split(new char[] { '\n' });
            Info.main_icon = this;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            LastOpenFile = filename;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, EntryField.Text);
            MessageBox.Show("Файл створено");
        }
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            LastOpenFile = filename;
            string fileText = System.IO.File.ReadAllText(filename);
            EntryField.Text = fileText;
            MessageBox.Show("Файл відкрито");
        }
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LastOpenFile == null)
            {
                MessageBox.Show("Створіть спочатку файл");
                return;
            }
            else
            {
                System.IO.File.WriteAllText(LastOpenFile, EntryField.Text);
                MessageBox.Show("Файл збережено");
            }
        }
        private void HowSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            LastOpenFile = filename;
            System.IO.File.WriteAllText(filename, EntryField.Text);
            MessageBox.Show("Файл збережено");
        }
        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.Cancel)
                return;
        }
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TempCopyString = EntryField.Text;
        }
        private void InsertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TempCopyString != null)
                EntryField.Text += TempCopyString;
        }
        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TempCopyString = EntryField.Text;
            EntryField.Text = null;
        }
        private void CreaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ім'я: Семенюк Максим\nГрупа: ТМ-61");
        }
        private void Encrypt_Click(object sender, EventArgs e)
        {
            Encrypt.Image = Image.FromFile(Application.StartupPath + @"\Picture\galka.jpg");
            Decrypt.Image = null;
            Info.encrypt = true;
            KeysInspector ss = new KeysInspector(EntryField.Text);
            ss.ShowDialog();
        }
        private void Decrypt_Click(object sender, EventArgs e)
        {
            Decrypt.Image = Image.FromFile(Application.StartupPath + @"\Picture\galka.jpg");
            Encrypt.Image = null;
            Info.encrypt = false;
            KeysInspector ss = new KeysInspector(EntryField.Text);
            ss.ShowDialog();
        }
        private void English_Alphabet_Click(object sender, EventArgs e)
        {
            English_Alphabet.Image = Image.FromFile(Application.StartupPath + @"\Picture\galka.jpg");
            Ukraine_Alphabet.Image = null;
            Info.language = "Англійський";
        }
        private void Ukraine_Alphabet_Click(object sender, EventArgs e)
        {
            Ukraine_Alphabet.Image = Image.FromFile(Application.StartupPath + @"\Picture\galka.jpg");
            English_Alphabet.Image = null;
            Info.language = "Український";
        }
        private void Caesar_Click(object sender, EventArgs e)
        {
            CaesarClick.Image = Image.FromFile(Application.StartupPath + @"\Picture\galka.jpg");
            TritemiusClick.Image = null;
            Lineare.Image = null;
            NonLineare.Image = null;
            Motto.Image = null;
            Caesar algorithm = new Caesar();
            if (algorithm.CheckText(EntryField.Text))
                return;
            if (algorithm.CheckKey("Caesar", Methods))
                return;
            string[] key_word = Key.Split(new char[] { ' ' });
            double key = Convert.ToDouble(key_word[0]);
            switch (Info.language)
            {
                case "Англійський":
                    if (Info.encrypt)
                        EntryField.Text = algorithm.caesar(EntryField.Text, algorithm.EnglishAlphabet, Convert.ToInt32(key));
                    else
                        EntryField.Text = algorithm.caesar(EntryField.Text, algorithm.EnglishAlphabet, -Convert.ToInt32(key)); break;
                case "Український":
                    if (Info.encrypt)
                        EntryField.Text = algorithm.caesar(EntryField.Text, algorithm.UkraineAlphabet, Convert.ToInt32(key));
                    else
                        EntryField.Text = algorithm.caesar(EntryField.Text, algorithm.UkraineAlphabet, -Convert.ToInt32(key)); break;
            }

        }
        private void TritemiusClick_Click(object sender, EventArgs e)
        {
            TritemiusClick.Image = Image.FromFile(Application.StartupPath + @"\Picture\galka.jpg");
            CaesarClick.Image = null;
        }
        private void Lineare_Click(object sender, EventArgs e)
        {
            Motto.Image = null;
            Lineare.Image = Image.FromFile(Application.StartupPath + @"\Picture\galka.jpg");
            NonLineare.Image = null;
            CaesarClick.Image = null;
            Tritemius algorithm = new Tritemius();
            if (algorithm.CheckText(EntryField.Text))
                return;
            if (algorithm.CheckKey("Tritemius.Lineare", Methods))
            {
                return;
            }
            double[] key = new double[2];
            string[] key_word = Key.Split(new char[] { ' ' });
            key[0] = Convert.ToDouble(key_word[0]);
            key[1] = Convert.ToDouble(key_word[1]);
            switch (Info.language)
            {
                case "Англійський": EntryField.Text = algorithm.tritemius(EntryField.Text, algorithm.EnglishAlphabet, "Lineare", key, Info.encrypt); break;
                case "Український": EntryField.Text = algorithm.tritemius(EntryField.Text, algorithm.UkraineAlphabet, "Lineare", key, Info.encrypt); break;
            }

        }
        private void NonLineare_Click(object sender, EventArgs e)
        {
            Motto.Image = null;
            Lineare.Image = null;
            CaesarClick.Image = null;
            NonLineare.Image = Image.FromFile(Application.StartupPath + @"\Picture\galka.jpg");
            Tritemius algorithm = new Tritemius();
            if (algorithm.CheckText(EntryField.Text))
                return;
            if (algorithm.CheckKey("Tritemius.NonLineare", Methods))
            {
                return;
            }
            double[] key = new double[3];
            string[] key_word = Key.Split(new char[] { ' ' });
            key[0] = Convert.ToDouble(key_word[0]);
            key[1] = Convert.ToDouble(key_word[1]);
            key[1] = Convert.ToDouble(key_word[2]);
            switch (Info.language)
            {
                case "Англійський": EntryField.Text = algorithm.tritemius(EntryField.Text, algorithm.EnglishAlphabet, "NonLineare", key, Info.encrypt); break;
                case "Український": EntryField.Text = algorithm.tritemius(EntryField.Text, algorithm.UkraineAlphabet, "NonLineare", key, Info.encrypt); break;
            }
        }
        private void Motto_Click(object sender, EventArgs e)
        {
            Motto.Image = Image.FromFile(Application.StartupPath + @"\Picture\galka.jpg");
            Lineare.Image = null;
            NonLineare.Image = null;
            Tritemius algorithm = new Tritemius();
            if (algorithm.CheckText(EntryField.Text))
                return;
            if (algorithm.CheckKey("Tritemius.Motto", Methods))
                return;
            MessageBox.Show("Here");
            switch (Info.language)
            {
                case "Англійський": EntryField.Text = algorithm.tritemius(EntryField.Text, algorithm.EnglishAlphabet, "Motto", Key, Info.encrypt); break;
                case "Український": EntryField.Text = algorithm.tritemius(EntryField.Text, algorithm.UkraineAlphabet, "Motto", Key, Info.encrypt); break;
            }
        }
        private void GammaClick_Click(object sender, EventArgs e)
        {
            Gamma algorithm = new Gamma();
            if (algorithm.CheckText(EntryField.Text))
                return;
            if (algorithm.CheckKey("Gamma", Methods))
                return;
            string[] key_word = Key.Split(new char[] { ' ' });
            int key = Convert.ToInt32(key_word[0]);
            switch (Info.language)
            {
                case "Англійський":
                    EntryField.Text = algorithm.gamma(EntryField.Text, algorithm.EnglishAlphabet, key, Info.encrypt);
                    break;
                case "Український":
                    EntryField.Text = algorithm.gamma(EntryField.Text, algorithm.EnglishAlphabet, key, Info.encrypt);
                    break;
            }
        }
        private void InVerse_Click(object sender, EventArgs e)
        {
            InVerse algorithm = new InVerse();
            if (algorithm.CheckText(EntryField.Text))
                return;
            if (algorithm.CheckKey("InVerse", Methods))
                return;
            switch (Info.language)
            {
                case "Англійський": EntryField.Text = algorithm.inverse(EntryField.Text, algorithm.EnglishAlphabet, Info.inverse_verse, Info.encrypt); break;
                case "Український": EntryField.Text = algorithm.inverse(EntryField.Text, algorithm.UkraineAlphabet, Info.inverse_verse, Info.encrypt); break;
            }
        }

        private void DES_Click(object sender, EventArgs e)
        {
            DES algorithm = new DES();
            if (algorithm.CheckText(EntryField.Text))
                return;
            if (algorithm.CheckKey("DES", Methods))
                return;
            string[] key_word = Key.Split(new char[] { ' ' });
            string key = (key_word[0]);
            switch (Info.language)
            {
                case "Англійський": EntryField.Text = algorithm.des(Info.encrypt, EntryField.Text, key); break;
                case "Український": EntryField.Text = algorithm.des(Info.encrypt, EntryField.Text, key); break;
            }
        }

        private void Bag_start_Click(object sender, EventArgs e)
        {
            BAG algorithm = new BAG();
            if (algorithm.CheckText(EntryField.Text))
                return;
            if (algorithm.CheckKey("BAG", Methods))
                return;
            string[] keys_string = Key.Split(new char[] { ' ' });
            int[] keys;
            if (Info.encrypt)
            {
                keys = new int[8];
                for (int i = 0; i < 8; i++)
                {
                    keys[i] = Convert.ToInt32(keys_string[i]);
                }
            }
            else
            {
                keys = new int[keys_string.Length];
                for (int i = 0; i < keys_string.Length; i++)
                {
                    keys[i] = Convert.ToInt32(keys_string[i]);
                }
            }
            
            switch (Info.language)
            {
                case "Англійський":
                    if (Info.encrypt)
                        EntryField.Text = algorithm.bag_encription(EntryField.Text, algorithm.EnglishAlphabet, keys);
                    else
                        EntryField.Text = algorithm.bag_decription(EntryField.Text, algorithm.EnglishAlphabet, keys); break;
                case "Український":
                    if (Info.encrypt)
                        EntryField.Text = algorithm.bag_encription(EntryField.Text, algorithm.UkraineAlphabet, keys);
                    else
                        EntryField.Text = algorithm.bag_decription(EntryField.Text, algorithm.UkraineAlphabet, keys); break;
            }
            //2 3 6 13 27 52 105 210
            for (int i = 0; i < Info.bag_open_key.Length; i++)
            {
                System.IO.File.AppendAllText(Application.StartupPath + @"\key_for_bag.txt", Info.bag_open_key[i] + " ");
            }
        }
    }
    class Info
    {
        public static bool encrypt { get; set; }
        public static string language { get; set; }
        public static BestSecurity main_icon { get; set; }
        public static string[] keys { get; set; }
        public static OpenFileDialog inverse_verse { get; set; }
        public static int[,] index_of { get; set; }
        public static int[] bag_open_key { get; set; }
        public static int[] open_key { get; set; }
    }
}