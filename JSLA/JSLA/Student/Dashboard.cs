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

namespace JSLA.Student
{
    public partial class Dashboard : Form
    {
        private Database _db;
        private string _id;
        private Classess.AccountInfo _accountInfo;

        private bool _isSideDrawerCollapsed = true;
        private Actions _action = Actions.Announcements;
        private Button[] ActionButtons;
        
        public enum Actions { Announcements, Subjects }

        public Dashboard(Database db, string id)
        {
            InitializeComponent();
            lblDateTime.Text = DateTime.Now.ToLongDateString() + ' ' + DateTime.Now.ToLongTimeString();

            _db = db;
            _id = id;

            ActionButtons = new Button[] { btnAnnouncements, btnSubjects };
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            fetchUserInfo();

            lblFullname.Text = _accountInfo.Lastname + ", " + _accountInfo.Firstname + ' ' + _accountInfo.Middlename[0] + '.';
            lblUserid.Text = _id;
            pbxAvatar.Image = _accountInfo.Avatar;

            pnlSidedrawer.Location = new Point(-250, 0);
            actions_Click(btnAnnouncements, EventArgs.Empty);
        }

        private void fetchUserInfo()
        {
            object[,] result = _db.ScanRecords("tbl_studentinfo", new string[] { "Lastname", "Firstname", "Middlename", "Avatar" }, "_id = '" + _id + '\'');
            _accountInfo = new Classess.AccountInfo(
                _id,
                result[0, 0].ToString(),
                result[0, 1].ToString(),
                result[0, 2].ToString(),
                Classess.AccountInfo.AccountTypeEnum.Student,
                result[0, 3] != DBNull.Value ? Image.FromStream(new MemoryStream((byte[])result[0, 3])) : null
                );
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            for (int i = pnlSidedrawer.Location.X; i <= 0; i += 5)
            {
                pnlSidedrawer.Location = new Point(i, 0);
                Thread.Sleep(1);
            }
            _isSideDrawerCollapsed = false;
        }

        private void collapseSidedrawer()
        {
            for (int i = pnlSidedrawer.Location.X; i >= -250; i -= 5)
            {
                pnlSidedrawer.Location = new Point(i, 0);
                Thread.Sleep(1);
            }
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
                case "Subjects":
                    _action = Actions.Subjects;
                    break;
            }

            setWorkspace(_action);
            foreach (var item in ActionButtons)
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
                    f = new Announcements();
                    break;
                case Actions.Subjects:
                    f = new Subjects.Subjects(_accountInfo, _db);
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
    }
}
