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
    public partial class HomeworkInfo : Form
    {
        private Database _db;
        private string _id;

        public HomeworkInfo(Database db, string id)
        {
            InitializeComponent();

            _db = db;
            _id = id;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HomeworkInfo_Load(object sender, EventArgs e)
        {
            object[,] result = _db.ScanRecords("tbl_homeworks", new string[] { "Title", "Description", "DatePosted", "DateDue" }, "_id = '" + _id + '\'');

            tbxId.Text = _id;
            tbxTitle.Text = result[0, 0].ToString();
            tbxDescription.Text = result[0, 1].ToString();
            tbxPosted.Text = result[0, 2].ToString();
            tbxDue.Text = result[0, 3].ToString();
        }
    }
}
