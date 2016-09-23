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
    public partial class AccountListManager : Form
    {
        private Database _db;

        private List<ListViewItem> _items = new List<ListViewItem>();
        private string _table;

        private AccountList _listType
        {
            set
            {
                switch (value)
                {
                    case AccountList.Student:
                        lblListType.Text = "Student Manager";

                        lvwList.Columns.Add("Student ID", 150);
                        lvwList.Columns.Add("Lastname", 250);
                        lvwList.Columns.Add("Firstname", 250);
                        lvwList.Columns.Add("Middlename", 250);
                        lvwList.Columns.Add("Gender", 150);
                        lvwList.Columns.Add("Guardian Lastname", 250);
                        lvwList.Columns.Add("Guardian Firstname", 250);
                        lvwList.Columns.Add("Guardian Middlename", 250);
                        lvwList.Columns.Add("Guardian Contact No.", 250);
                        lvwList.Columns.Add("Status", 150);

                        _table = "tbl_studentinfo";

                        btnAdd.Click += btnAddStudent_Click;
                        btnEdit.Click += btnEditStudent_Click;
                        btnAdd.Click -= btnAddTeacher_Click;
                        btnEdit.Click -= btnEditTeacher_Click;

                        fetchStudents();
                        break;

                    case AccountList.Teacher:
                        lblListType.Text = "Teacher Manager";

                        lvwList.Columns.Add("Teacher ID", 150);
                        lvwList.Columns.Add("Lastname", 250);
                        lvwList.Columns.Add("Firstname", 250);
                        lvwList.Columns.Add("Middlename", 250);
                        lvwList.Columns.Add("Gender", 150);
                        lvwList.Columns.Add("Status", 150);

                        _table = "tbl_teacherinfo";

                        btnAdd.Click += btnAddTeacher_Click;
                        btnEdit.Click += btnEditTeacher_Click;
                        btnAdd.Click -= btnAddStudent_Click;
                        btnEdit.Click -= btnEditStudent_Click;

                        fetchTeachers();
                        break;
                    case AccountList.Limited:
                        break;
                    default:
                        break;
                }
            }
        }

        public enum AccountList { Student, Teacher, Limited };

        public AccountListManager(Database db, AccountList listType)
        {
            InitializeComponent();

            _db = db;
            _listType = listType;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AccountListManager_Load(object sender, EventArgs e)
        {
            filterItems();
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            filterItems();
        }

        private void filterItems()
        {
            lvwList.Items.Clear();

            for (int i = 0; i < _items.Count; i++)
                for (int i2 = 0; i2 < _items[i].SubItems.Count; i2++)
                    if (_items[i].SubItems[i2].Text.ToLower().Contains(tbxSearch.Text.ToLower()))
                    {
                        lvwList.Items.Add(_items[i]);
                        break;
                    }
        }

        private void StudentForm_Closed(object sender, EventArgs e)
        {
            Show();
            fetchStudents();
        }

        private void TeacherForm_Closed(object sender, EventArgs e)
        {
            Show();
            fetchTeachers();
        }

        private void lvwList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count > 0)
            {
                btnReset.Enabled = true;
                btnEdit.Enabled = true;
                btnRemove.Enabled = true;
            }
            else
            {
                btnReset.Enabled = false;
                btnEdit.Enabled = false;
                btnRemove.Enabled = false;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to reset this account's password?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Random r = new Random();
                _db.UpdateRecord(_table, "_id", lvwList.SelectedItems[0].Text, new string[] { "password", "attempts" }, new string[] { r.Next(100000, 999999).ToString(), "0" });
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to remove this account?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                _db.UpdateRecord(_table, "_id", lvwList.SelectedItems[0].Text, new string[] { "Status" }, new string[] { "Inactive" });
            fetchStudents();
        }

        #region Student
        private void fetchStudents()
        {
            object[,] results = _db.ExecuteQuery("select _id, LastName, FirstName, MiddleName, Gender, GLastname, GFirstname, GMiddlename, GContact, Status from " + _table);

            _items.Clear();
            for (int i = 0; i < results.GetLength(0); i++)
            {
                ListViewItem item = new ListViewItem(results[i, 0].ToString());
                for (int i2 = 1; i2 < results.GetLength(1); i2++)
                    item.SubItems.Add(results[i, i2] != null ? results[i, i2].ToString() : "");

                _items.Add(item);
            }
            tbxSearch.Text = "";
            filterItems();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            StudentInfoDialog sid = new StudentInfoDialog(_db, StudentInfoDialog.DialogType.Add, new string[0])
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            sid.FormClosed += StudentForm_Closed;
            Hide();
            Parent.Controls.Add(sid);
            sid.Show();
        }

        private void btnEditStudent_Click(object sender, EventArgs e)
        {
            string[] values = new string[lvwList.Columns.Count];
            ListViewItem item = lvwList.SelectedItems[0];
            for (int i = 0; i < item.SubItems.Count; i++)
                values[i] = item.SubItems[i].Text;

            StudentInfoDialog sid = new StudentInfoDialog(_db, StudentInfoDialog.DialogType.Edit, values)
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            sid.FormClosed += StudentForm_Closed;
            Hide();
            Parent.Controls.Add(sid);
            sid.Show();
        }
        #endregion

        #region Teacher
        private void fetchTeachers()
        {
            object[,] results = _db.ExecuteQuery("select _id, LastName, FirstName, MiddleName, Gender, Status from " + _table);

            _items.Clear();
            for (int i = 0; i < results.GetLength(0); i++)
            {
                ListViewItem item = new ListViewItem(results[i, 0].ToString());
                for (int i2 = 1; i2 < results.GetLength(1); i2++)
                    item.SubItems.Add(results[i, i2] != null ? results[i, i2].ToString() : "");

                _items.Add(item);
            }
            tbxSearch.Text = "";
            filterItems();
        }

        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            TeacherInfoDialog tid = new TeacherInfoDialog(_db, TeacherInfoDialog.DialogType.Add, new string[0])
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            tid.FormClosed += TeacherForm_Closed;
            Hide();
            Parent.Controls.Add(tid);
            tid.Show();
        }

        private void btnEditTeacher_Click(object sender, EventArgs e)
        {
            string[] values = new string[lvwList.Columns.Count];
            ListViewItem item = lvwList.SelectedItems[0];
            for (int i = 0; i < item.SubItems.Count; i++)
                values[i] = item.SubItems[i].Text;

            TeacherInfoDialog tid = new TeacherInfoDialog(_db, TeacherInfoDialog.DialogType.Edit, values)
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            tid.FormClosed += TeacherForm_Closed;
            Hide();
            Parent.Controls.Add(tid);
            tid.Show();
        }
        #endregion
    }
}
