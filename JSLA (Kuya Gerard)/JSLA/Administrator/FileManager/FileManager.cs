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
    public partial class FileManager : Form
    {
        private Database _db;

        public FileManager(Database db)
        {
            InitializeComponent();

            _db = db;
        }

        private void btnManageSubjects_Click(object sender, EventArgs e)
        {
            SubjectManager sm = new SubjectManager(_db) { Dock = DockStyle.Fill, TopLevel = false };
            sm.FormClosed += child_FormClosed;
            this.Parent.Controls.Add(sm);
            Hide();
            sm.Show();
        }

        private void child_FormClosed(object sender, EventArgs e)
        {

        }
    }
}
