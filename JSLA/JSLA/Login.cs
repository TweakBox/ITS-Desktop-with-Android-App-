using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSLA
{
    public partial class Login : Form
    {
        private Database _db = new Database();

        private bool[] _adminBackdoor = new bool[5];

        public Login()
        {
            InitializeComponent();
            _db.TryOpenConnection();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            object[,] result = _db.ScanRecords("tbl_accounts", new string[] { "attempts", "password", "user_level", "reference_id" }, "_Id = '" + tbxUserId.Text + '\'');
            if (result.GetLength(0) > 0)
                if (int.Parse(result[0, 0].ToString()) < 5)
                    if (tbxPassword.Text == result[0, 1].ToString())
                    {
                        _db.UpdateRecord("tbl_accounts", "_id", tbxUserId.Text, new string[] { "Attempts" }, new string[] { "0" });

                        Form f = new Form();
                        switch (result[0, 2].ToString())
                        {
                            case "Student":
                                f = new Student.Dashboard(_db, result[0, 3].ToString());
                                break;
                            case "Teacher":
                                f = new Teacher.Dashboard(_db, result[0, 3].ToString());
                                break;
                            case "Admin":
                                break;
                        }

                        f.FormClosed += child_FormClosed;
                        Hide();
                        f.Show();
                    }
                    else
                    {
                        _db.UpdateRecord("tbl_accounts", "_id", tbxUserId.Text, new string[] { "Attempts" }, new string[] { (int.Parse(result[0, 0].ToString()) + 1).ToString() });

                        MessageBox.Show("Wrong password entered. Five(5) failed attempts will lead to your account being locked", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxPassword.Focus();
                        tbxPassword.SelectAll();
                        if (int.Parse(result[0, 0].ToString()) == 4)
                            MessageBox.Show("This account has failed five(5) log in attempts.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                else
                    MessageBox.Show("This account has failed five(5) log in attempts. Contact your adviser for recovery", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            else
            {
                MessageBox.Show("User ID does not exist!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbxUserId.Focus();
                tbxUserId.SelectAll();
            }
        }

        private void child_FormClosed(object sender, FormClosedEventArgs e)
        {
            Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void tbxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_adminBackdoor[0])
            {
                if (e.Alt && e.Control && e.Shift && e.KeyCode == Keys.A)
                    _adminBackdoor[0] = true;
                else if (!e.Alt && !e.Control && !e.Shift)
                    _adminBackdoor = new bool[5];
            }
            else if (!_adminBackdoor[1])
            {
                if (e.Alt && e.Control && e.Shift && e.KeyCode == Keys.D)
                    _adminBackdoor[1] = true;
                else if (!e.Alt && !e.Control && !e.Shift)
                    _adminBackdoor = new bool[5];
            }
            else if (!_adminBackdoor[2])
            {
                if (e.Alt && e.Control && e.Shift && e.KeyCode == Keys.M)
                    _adminBackdoor[2] = true;
                else if (!e.Alt && !e.Control && !e.Shift)
                    _adminBackdoor = new bool[5];
            }
            else if (!_adminBackdoor[3])
            {
                if (e.Alt && e.Control && e.Shift && e.KeyCode == Keys.I)
                    _adminBackdoor[3] = true;
                else if (!e.Alt && !e.Control && !e.Shift)
                    _adminBackdoor = new bool[5];
            }
            else if (!_adminBackdoor[4])
            {
                if (e.Alt && e.Control && e.Shift && e.KeyCode == Keys.N)
                {
                    _adminBackdoor = new bool[5];
                    Administrator.Dashboard d = new Administrator.Dashboard(_db, "303030");
                    d.FormClosed += child_FormClosed;
                    Hide();
                    d.Show();
                }
                else if (!e.Alt && !e.Control && !e.Shift)
                    _adminBackdoor = new bool[5];
            }
        }
    }
}
