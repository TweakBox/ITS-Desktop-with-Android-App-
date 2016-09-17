using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSLA.Administrator.FileManager
{
    public partial class SubjectManager : Form
    {
        private Database _db;
        private object[,] _subjects;
        private object[,] _tracks;

        private _editmodeenum _editmode;

        private enum _editmodeenum { Add, Edit };

        public SubjectManager(Database db)
        {
            InitializeComponent();

            _db = db;
        }

        private void SubjectManager_Load(object sender, EventArgs e)
        {
            fetchSubjects();
            fetchTracks();
        }

        private void fetchSubjects()
        {
            _subjects = _db.ScanRecords("tbl_subjectinfo", new string[] { "*" }, "Status = 'Active'");
            tbxSearch.ResetText();

            filterList();
        }

        private void fetchTracks()
        {

            _tracks = _db.ScanRecords("tbl_trackinfo");

            cbxTrack.Items.Clear();
            for (int i = 0; i < _tracks.GetLength(0); i++)
                cbxTrack.Items.Add(_tracks[i, 1]);
        }

        private void filterList()
        {
            lbxSubjects.Items.Clear();
            for (int i = 0; i < _subjects.GetLength(0); i++)
                if (_subjects[i, 1].ToString().ToLower().Contains(tbxSearch.Text.ToLower()))
                    lbxSubjects.Items.Add(_subjects[i, 1]);
        }

        private void lbxSubjects_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbxSubjects.SelectedItem != null)
            {
                tbxTitle.Text = lbxSubjects.SelectedItem.ToString();
                cbxYearLevel.SelectedItem = _subjects[lbxSubjects.SelectedIndex, 2].ToString();
                cbxTrack.SelectedItem = _subjects[lbxSubjects.SelectedIndex, 3].ToString();

                btnEdit.Enabled = btnRemove.Enabled = true;
            }
            else
            {
                clearFields();

                btnEdit.Enabled = btnRemove.Enabled = false;
            }
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            filterList();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void forEdit()
        {
            gbxList.Enabled = gbxActions.Enabled = false;
            gbxDialog.Enabled = true;
        }

        private void forPick()
        {
            gbxList.Enabled = gbxActions.Enabled = true;
            gbxDialog.Enabled = false;
        }

        private void clearFields()
        {
            tbxTitle.ResetText();
            cbxYearLevel.SelectedIndex = cbxTrack.SelectedIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clearFields();
            forEdit();

            _editmode = _editmodeenum.Add;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            forEdit();
            _editmode = _editmodeenum.Edit;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to remove this subject?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                _db.UpdateRecord("tbl_subjectinfo", "_id", _subjects[lbxSubjects.SelectedIndex, 0].ToString(), new string[] { "Status" }, new string[] { "Inactive" });

                ((Dashboard)Parent.Parent).ShowMessageBar("Account removed!", 3000);
                forPick();
                clearFields();
                fetchSubjects();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string mode = "";
            switch (_editmode)
            {
                case _editmodeenum.Add:
                    _db.InsertRecord("tbl_subjectinfo", new string[] { "Subject", "Yearlevel", "Status" }, new string[] { tbxTitle.Text, cbxYearLevel.Text, "Active" });
                    mode = "added";
                    break;
                case _editmodeenum.Edit:
                    _db.UpdateRecord("tbl_subjectinfo", "_id", _subjects[lbxSubjects.SelectedIndex, 0].ToString(), new string[] { "Subject", "Yearlevel" }, new string[] { tbxTitle.Text, cbxYearLevel.Text/*, _tracks[cbxTrack.SelectedIndex, 0].ToString()*/ });
                    mode = "updated";
                    break;
            }

            ((Dashboard)Parent.Parent).ShowMessageBar("Account " + mode + '!', 3000);
            forPick();
            clearFields();
            fetchSubjects();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearFields();
            forPick();
        }
    }
}
