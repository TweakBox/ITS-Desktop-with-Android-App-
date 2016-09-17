using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSLA.Student.Subjects
{
    public partial class Handouts : Form
    {
        private Database _db;
        private string _sectionListId;

        public Handouts(Database db, string sectionListId)
        {
            InitializeComponent();

            _db = db;
            _sectionListId = sectionListId;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Handouts_Load(object sender, EventArgs e)
        {
            fetchHandouts();
        }

        private void fetchHandouts()
        {
            object[,] results = _db.ScanRecords(
                @"tbl_sectionlist
                    INNER JOIN tbl_teacherupload ON tbl_teacherupload.SectionList_id = tbl_sectionlist._id",
                new string[] { "tbl_teacherupload._id",
                    "tbl_teacherupload.Filename",
                    "tbl_teacherupload.Fileaddress",
                    "tbl_teacherupload.DateUploaded" },
                "tbl_sectionList._id = '" + _sectionListId + '\''
                );

            flpList.Controls.Clear();
            for (int i = 0; i < results.GetLength(0); i++)
            {
                Usercontrols.DownloadableFileItem dfi = new Usercontrols.DownloadableFileItem(
                    results[i, 0].ToString(), 
                    results[i, 2].ToString())
                {
                    Title = results[i, 1].ToString(),
                    Width = flpList.Width - 15
                };

                flpList.Controls.Add(dfi);
            }
        }

        private void flpList_Resize(object sender, EventArgs e)
        {
            foreach (Control item in flpList.Controls)
                item.Width = flpList.Width - 15;
        }
    }
}
