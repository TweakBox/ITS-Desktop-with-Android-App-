using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSLA.Administrator.AccountManager
{
    public partial class AccountManager : Form
    {
        private Database _db;

        public AccountManager(Database db)
        {
            InitializeComponent();

            _db = db;
        }

        private void btManageStudent_Click(object sender, EventArgs e)
        {
            AccountListManager alm = new AccountListManager(_db, AccountListManager.AccountList.Student)
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            alm.FormClosed += childForm_Closed;
            Hide();
            Parent.Controls.Add(alm);
            alm.Show();
        }

        private void btnManageTeacher_Click(object sender, EventArgs e)
        {
            AccountListManager alm = new AccountListManager(_db, AccountListManager.AccountList.Teacher)
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            alm.FormClosed += childForm_Closed;
            Hide();
            Parent.Controls.Add(alm);
            alm.Show();
        }

        private void childForm_Closed(object sender, EventArgs e)
        {
            Show();
        }
    }
}
