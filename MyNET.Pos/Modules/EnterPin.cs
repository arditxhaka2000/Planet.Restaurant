using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNET.Pos.Modules
{
    public partial class EnterPin : Form
    {
        public bool flag = false;
        private static readonly string EncryptionKey = "3hWj7GKp9sRvNtDm6yZa4bXu2QxL8CfY";

        public EnterPin()
        {
            InitializeComponent();
        }

        private void word_save_Click(object sender, EventArgs e)
        {
            var settings = Settings.Get(); 
            if (HashString(txtPin.Text) == settings.PIN)
            {
                flag = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrent Pin!");
                
                txtPin.Text = "";
            }
        }
        public static string HashString(string input)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(EncryptionKey);
                aesAlg.IV = new byte[16]; // Initialization Vector

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(input);
                    }

                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        private void txtPin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                word_save_Click(null, null); 

            }
        }
    }
}
