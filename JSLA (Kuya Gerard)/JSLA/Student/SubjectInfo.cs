using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSLA.Student
{
    public partial class SubjectInfo : Form
    {
        private Database _db;
        private Classess.AccountInfo _account;

        public SubjectInfo(Database db, Classess.AccountInfo account, string title)
        {
            InitializeComponent();

            _db = db;
            _account = account;

            lblTitle.Text = title;
        }

        private void SubjectInfo_Load(object sender, EventArgs e)
        {
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SubjectInfo_Shown(object sender, EventArgs e)
        {
            fetchHomeworks();
        }

        private void fetchHomeworks()
        {
            object[,] results = _db.ScanRecords(
                @"tbl_studentinfo
                    INNER JOIN tbl_classlist ON tbl_classlist.Student_no = tbl_studentinfo._id
                    INNER JOIN tbl_sectionlist ON tbl_classlist.Section_id = tbl_sectionlist.Section_id
                    INNER JOIN tbl_homeworks ON tbl_homeworks.SectionList_id = tbl_sectionlist._id",
                new string[] { "tbl_homeworks._id", "Title", "Description", "DateDue" },
                "tbl_studentinfo._id = '" + _account.UserId + "' and DateDue > '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + '\'');

            flpHomeworks.Controls.Clear();
            if (results.GetLength(0) > 0)
            {
                for (int i = 0; i < results.GetLength(0); i++)
                {
                    Usercontrols.ItemInfoButton iib = new Usercontrols.ItemInfoButton()
                    {
                        Tag = results[i, 0],
                        Title = results[i, 1].ToString(),
                        Description = results[i, 2].ToString(),
                        Subtitle = "Due: " + DateTime.Parse(results[i, 3].ToString()).ToLongDateString(),
                        Width = flpHomeworks.Width
                    };
                    iib.Click += Iib_Click;
                    flpHomeworks.Controls.Add(iib);
                }
            }
            else
                flpHomeworks.Controls.Add(new Label() {
                    Font = new Font(this.Font, FontStyle.Italic),
                    Text = "No homeworks! Yey! :D",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Height = flpHomeworks.Height - 15,
                    Width = flpHomeworks.Width - 15
                });
        }

        private void Iib_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            HomeworkInfo hi = new HomeworkInfo(_db, control.Tag.ToString());
            
            hi.ShowDialog();
        }

        private void fetchNotes()
        {

        }

        private void fetchQuizzes()
        {

        }

        private void Containers_ControlAdded(object sender, ControlEventArgs e)
        {
            ScrollableControl container = (ScrollableControl)sender;
            foreach (Control item in container.Controls)
                item.Width = !container.VerticalScroll.Visible ? container.Width - 6 : container.Width - 23;
        }

        private void btnHandouts_Click(object sender, EventArgs e)
        {
            object sectionListId = _db.ScanRecordScalar(
                @"tbl_studentinfo
                    INNER JOIN tbl_classlist ON tbl_classlist.Student_no = tbl_studentinfo._id
                    INNER JOIN tbl_sectionlist ON tbl_classlist.Section_id = tbl_sectionlist.Section_id",
                "tbl_sectionlist._id",
                "tbl_studentinfo._id = '" + _account.UserId + '\''
                );

            Subjects.Handouts h = new Subjects.Handouts(_db, sectionListId.ToString()) { Dock = DockStyle.Fill, TopLevel = false };
            h.FormClosed += H_FormClosed;
            this.Parent.Controls.Add(h);
            Hide();
            h.Show();
        }

        private void H_FormClosed(object sender, FormClosedEventArgs e)
        {
            Show();
        }
    }
}
