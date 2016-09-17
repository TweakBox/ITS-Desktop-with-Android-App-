using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace JSLA
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            bool isOnline;
            bool isLoggedIn;

            Database db = new Database();
            if (db.TryOpenConnection())
                isOnline = true;
            else
                isOnline = false;
            db.TryCloseConnection();

            if (File.Exists("UserCredentials.dat"))
            {
                if (true)
                    isLoggedIn = true;
            }
            else
                isLoggedIn = false;

            //Thread.Sleep(3000);

            if (isOnline && !isLoggedIn)
            {
                Hide();
                new Login().Show();
            }
            else
                MessageBox.Show("Test");
        }
    }
}
