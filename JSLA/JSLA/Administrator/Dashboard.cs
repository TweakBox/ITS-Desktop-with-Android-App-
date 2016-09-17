using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace JSLA.Administrator
{
    public partial class Dashboard : Form
    {
        private Database _db;
        private string _id;
        private Classess.AccountInfo _accountInfo;

        private bool _isSideDrawerCollapsed = true;
        private Actions _action = Actions.Announcements;
        private Button[] _actionButtons;

        public enum Actions { Announcements, FileManager, AccountManager}

        public Dashboard(Database db, string id)
        {
            InitializeComponent();
            
            _db = db;
            _id = id;

            _actionButtons = new Button[]{ btnAnnouncements, btnFileManager, btnSubjects };
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            //fetchUserInfo();

            //lblFullname.Text = _accountInfo.Lastname + ", " + _accountInfo.Firstname + ' ' + _accountInfo.Middlename[0] + '.';
            lblUserid.Text = _id;
            
            actions_Click(btnAnnouncements, EventArgs.Empty);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fetchUserInfo()
        {
            object[,] result = _db.ScanRecords("tbl_teacherinfo", new string[] { "Lastname", "Firstname", "Middlename", "Avatar" }, "_id = '" + _id + '\'');

            _accountInfo = new Classess.AccountInfo(
                _id,
                result[0, 0].ToString(),
                result[0, 1].ToString(),
                result[0, 2].ToString(),
                Classess.AccountInfo.AccountTypeEnum.Student,
                Image.FromStream(new MemoryStream((byte[])result[0, 3]))
                );
        }

        private void btnTogglesidedrawer_Click(object sender, EventArgs e)
        {
            if (_isSideDrawerCollapsed)
                expandSidedrawer();
            else
                collapseSidedrawer();
        }

        private void expandSidedrawer()
        {
            pnlSidedrawer.Visible = true;
            _isSideDrawerCollapsed = false;
        }

        private void collapseSidedrawer()
        {
            pnlSidedrawer.Visible = false;
            _isSideDrawerCollapsed = true;
        }

        private void actions_Click(object sender, EventArgs e)
        {
            Button action = (Button)sender;

            switch (action.Tag.ToString())
            {
                case "Announcements":
                    _action = Actions.Announcements;
                    break;
                case "File Manager":
                    _action = Actions.FileManager;
                    break;
                case "Account Manager":
                    _action = Actions.AccountManager;
                    break;
            }

            setWorkspace(_action);
            foreach (var item in _actionButtons)
                item.BackColor = Color.White;

            action.BackColor = Color.Gainsboro;
            collapseSidedrawer();
        }

        private void setWorkspace(Actions action)
        {
            Form f = null;
            switch (action)
            {
                case Actions.Announcements:
                    f = new Announcements(_db);
                    break; 
                case Actions.FileManager:
                    f = new FileManager.FileManager(_db);
                    break;
                case Actions.AccountManager:
                    f = new AccountManager.AccountManager(_db);
                    break;
            }
            pnlContent.Controls.Clear();
            if (f != null)
            {
                f.TopLevel = false;
                pnlContent.Controls.Add(f);
                f.Show();
                f.Dock = DockStyle.Fill;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToLongDateString() + ' ' + DateTime.Now.ToLongTimeString();
        }

        public void ShowMessageBar(string message, int duration)
        {
            lblMessage.Text = message;
            lblMessage.Visible = true;

            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer() { Interval = duration };
            t.Tick += (object sender, EventArgs e) => {
                lblMessage.Visible = false;
                t.Stop();
                t.Dispose();
            };
            t.Start();
        }
    }
}
