using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace _1_лаба
{
    public class DES : Interface
    {
        public string des(bool encription, string Text, string key)
        {
            if (encription)
            {
                DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider();
                cryptic.Key = Encoding.Default.GetBytes(key);
                cryptic.IV = Encoding.Default.GetBytes(key);
                cryptic.Mode = CipherMode.CBC;
                FileStream stream = new FileStream(Application.StartupPath + @"\test.txt", FileMode.OpenOrCreate);
                CryptoStream crStream = new CryptoStream(stream, cryptic.CreateEncryptor(), CryptoStreamMode.Write);
                byte[] data = Encoding.Default.GetBytes(Text);
                crStream.Write(data, 0, data.Length);
                crStream.Close();
                stream.Close();
                Text = Convert.ToBase64String(data, 0, data.Length);
            }
            else
            {
                DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider();
                cryptic.Key = Encoding.Default.GetBytes(key);
                cryptic.IV = Encoding.Default.GetBytes(key);
                cryptic.Mode = CipherMode.CBC;
                FileStream stream = new FileStream(Application.StartupPath + @"\test.txt", FileMode.Open, FileAccess.Read);
                CryptoStream crStream = new CryptoStream(stream, cryptic.CreateDecryptor(), CryptoStreamMode.Read);
                StreamReader reader = new StreamReader(crStream);
                Text = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            return Text;
        }
    }
}
