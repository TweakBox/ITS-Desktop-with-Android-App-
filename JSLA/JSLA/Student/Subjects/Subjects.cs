using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JSLA.Classess;

namespace JSLA.Student.Subjects
{
    public partial class Subjects : Form
    {
        private AccountInfo _account;
        private Database _db;

        public Subjects(AccountInfo accountinfo, Database db)
        {
            InitializeComponent();
            _account = accountinfo;
            _db = db;
        }

        private void Subjects_Load(object sender, EventArgs e)
        {
            //homeworks
            //...

            object[,] result = _db.ScanRecords(
                @"tbl_studentinfo
                    INNER JOIN tbl_classlist ON tbl_classlist.Student_no = tbl_studentinfo._id
                    INNER JOIN tbl_sectionlist ON tbl_classlist.Section_id = tbl_sectionlist.Section_id
                    INNER JOIN tbl_subjectinfo ON tbl_sectionlist.Subject_id = tbl_subjectinfo._id",
                new string[] { "Subject" },
                "tbl_studentinfo._id = '" + _account.UserId + '\''
                );
            for (int i = 0; i < result.GetLength(0); i++)
            {
                Random r = new Random();
                Color c = Color.FromArgb(r.Next(75, 125), r.Next(75, 125), 175);

                Usercontrols.PictureButton pb = new Usercontrols.PictureButton()
                {
                    Title = result[i, 0].ToString(),
                    Count = r.Next(5),
                    BackColor = c,
                    ForeColor = Color.White
                };
                pb.Click += Pb_Click;

                flpGallery.Controls.Add(pb);
            }
            flpGallery.VerticalScroll.Maximum += 135;
        }

        private void Pb_Click(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            SubjectInfo si = new SubjectInfo(_db, _account, ((Usercontrols.PictureButton)sender).Title);
            si.FormClosed += child_FormClosed;

            si.Dock = DockStyle.Fill;
            si.TopLevel = false;
            Parent.Controls.Add(si);
            Hide();
            si.Show();
        }

        private void child_FormClosed(object sender, FormClosedEventArgs e)
        {
            Show();
        }
    }
}
