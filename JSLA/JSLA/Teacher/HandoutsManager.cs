using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSLA.Teacher
{
    public partial class HandoutsManager : Form
    {
        private Database _db;
        private string _id;

        private DialogType _dialogType;

        private enum DialogType { Add, Edit };

        public HandoutsManager(Database db, string id)
        {
            InitializeComponent();

            _db = db;
            _id = id;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Handouts_Load(object sender, EventArgs e)
        {
            fetchHandledSections();
        }

        private void fetchHandledSections()
        {
            object[,] results = _db.ScanRecords(
                @"tbl_sectionlist
                    INNER JOIN tbl_sectioninfo ON tbl_sectionlist.Section_id = tbl_sectioninfo._id
                    INNER JOIN tbl_subjectinfo ON tbl_sectionlist.Subject_id = tbl_subjectinfo._id",
                new string[] { "tbl_sectionlist._id", "tbl_sectioninfo.Section", "tbl_subjectinfo.`Subject`" },
                "tbl_sectionlist.Faculty_id = '" + _id + '\'');


            lvwSectionList.Items.Clear();
            cbxSections.Items.Clear();
            for (int i = 0; i < results.GetLength(0); i++)
            {
                ListViewItem item = new ListViewItem(results[i, 0].ToString());
                item.SubItems.Add(results[i, 1].ToString());
                item.SubItems.Add(results[i, 2].ToString());

                lvwSectionList.Items.Add(item);

                cbxSections.Items.Add(results[i, 0].ToString() + " - " + results[i, 1].ToString() + " - " + results[i, 2].ToString());
            }
        }

        private void fetchHandouts(string sectionlistId)
        {
            object[,] results = _db.ScanRecords(
                @"tbl_teacherupload
                    INNER JOIN tbl_sectionlist ON tbl_teacherupload.SectionList_id = tbl_sectionlist._id",
                new string[] { "tbl_teacherupload._id", "Filename", "FileAddress", "DateUploaded" },
                "tbl_sectionlist.Faculty_id = '" + _id + "\' and Status = 'Active'");

            lvwHandouts.Items.Clear();
            for (int i = 0; i < results.GetLength(0); i++)
            {
                ListViewItem item = new ListViewItem(results[i, 0].ToString());
                item.SubItems.Add(results[i, 1].ToString());
                item.SubItems.Add(results[i, 2].ToString());
                item.SubItems.Add(DateTime.Parse(results[i, 3].ToString()).ToShortDateString());

                lvwHandouts.Items.Add(item);
            }
        }

        private void lvwSectionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwSectionList.SelectedItems.Count > 0)
            {
                fetchHandouts(lvwSectionList.SelectedItems[0].Text);
                cbxSections.SelectedItem = lvwSectionList.SelectedItems[0].Text + " - " + lvwSectionList.SelectedItems[0].SubItems[1].Text + " - " + lvwSectionList.SelectedItems[0].SubItems[2].Text;
            }
            else
            {
                lvwHandouts.Items.Clear();

                btnEdit.Enabled = false;
                btnRemove.Enabled = false;
                gbxHandoutInfo.Enabled = false;

                clearText();
            }
        }

        private void lvwHandouts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwHandouts.SelectedItems.Count > 0)
            {
                btnEdit.Enabled = true;
                btnRemove.Enabled = true;

                tbxId.Text = lvwHandouts.SelectedItems[0].Text;
                tbxFilename.Text = lvwHandouts.SelectedItems[1].Text;
            }
            else
            {
                btnEdit.Enabled = false;
                btnRemove.Enabled = false;
                gbxHandoutInfo.Enabled = false;
            }
        }

        private void clearText()
        {
            tbxId.ResetText();
            tbxFilename.ResetText();
            cbxSections.SelectedIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clearText();
            gbxHandoutInfo.Enabled = true;
            lvwSectionList.Enabled = false;
            lvwHandouts.Enabled = false;
            gbxActions.Enabled = false;

            object[,] results = _db.ScanRecords("tbl_teacherupload", "_id");

            int index = 0;
            for (int i = 0; i < results.GetLength(0); i++)
                if (index == (int)results[i, 0])
                {
                    index++;
                    i = -1;
                    break;
                }

            tbxId.Text = index.ToString();

            _dialogType = DialogType.Add;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            gbxHandoutInfo.Enabled = true;
            lvwSectionList.Enabled = false;
            lvwHandouts.Enabled = false;
            gbxActions.Enabled = false;
            _dialogType = DialogType.Edit;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to remove this file?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
                _db.UpdateRecord("tbl_teacherupload", "_Id", lvwHandouts.SelectedItems[0].Text, new string[] { "Status" }, new string[] { "Inactive" });

            fetchHandouts(lvwSectionList.SelectedItems[0].Text);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            tbxFilename.Text = openFileDialog1.SafeFileName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName != String.Empty)
            {
                switch (_dialogType)
                {
                    case DialogType.Add:
                        _db.InsertRecord("tbl_teacherupload", tbxId.Text, cbxSections.Text, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "Active");
                        break;
                    case DialogType.Edit:
                        break;
                }

                fetchHandouts(lvwSectionList.SelectedItems[0].Text);
                ((Dashboard)Parent.Parent).ShowMessageBar("Handout saved!", 3000);
                
                clearText();
                gbxHandoutInfo.Enabled = false;
                gbxActions.Enabled = true;
                lvwSectionList.Enabled = true;
                lvwHandouts.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearText();
            gbxHandoutInfo.Enabled = false;
            gbxActions.Enabled = true;
            lvwSectionList.Enabled = true;
            lvwHandouts.Enabled = true;
        }
    }
}
