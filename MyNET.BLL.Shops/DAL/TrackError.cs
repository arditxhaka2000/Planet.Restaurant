using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNET.DAL
{
    public class TrackError
    {
        public static bool SqlError(Exception exception)
        {
            try
            {
                MessageBox.Show("Referenca apo numri i Fatures ekziston", "Gabim", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
