using System.Text;
using System.IO;
using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace MyNET
{
    public class TrackError
    {
        public static bool ReportError(string exception, string comment = "")
        {
            try
            {
                //MessageBox.Show("Ka ndodhur një gabim", "Gabim", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string filename = Application.StartupPath + @"\ExceptionLog.txt";
                FileMode fm = FileMode.Append;

                if (!File.Exists(filename))
                {
                    fm = FileMode.Create;
                }

                StringBuilder sb = new StringBuilder();
                FileStream fs = new FileStream(filename, fm);
                sb.Append(DateTime.Now.ToString());
                sb.Append(Environment.NewLine);
                sb.Append("---------------------------------------------------------");
                sb.Append(Environment.NewLine);
                sb.Append(exception.ToString());
                sb.Append(Environment.NewLine);
                sb.Append(comment.ToString());
                sb.Append(Environment.NewLine);
                sb.Append("---------------------------------------------------------");
                sb.Append(Environment.NewLine);
                string s = sb.ToString();
                Byte[] byt = Encoding.ASCII.GetBytes(s);
                fs.Write(byt, 0, byt.Length);
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

}
