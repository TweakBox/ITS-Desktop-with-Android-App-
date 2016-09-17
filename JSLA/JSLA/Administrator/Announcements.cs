using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSLA.Administrator
{
    public partial class Announcements : Form
    {
        private Database _db;
        private List<Classess.Announcement> _announcementList = new List<Classess.Announcement>();

        private int index = 0;

        public Announcements(Database db)
        {
            InitializeComponent();

            _db = db;
        }

        private void Announcements_Load(object sender, EventArgs e)
        {
            object[,] result = _db.ExecuteQuery("select _id, Title, Poster from tbl_announcements where Status = 'Active'");

            if (result.GetLength(0) > 1)
            {
                _announcementList.Clear();
                for (int i = 0; i < result.GetLength(0); i++)
                {
                    Classess.Announcement a = new Classess.Announcement();
                    a.ID = int.Parse(result[i, 0].ToString());
                    a.Title = result[i, 1].ToString();

                    byte[] data = (byte[])result[i, 2];
                    a.Poster = Image.FromStream(new MemoryStream(data));
                    _announcementList.Add(a);
                }

                displayPoster(index);
                return;
            }
            else if (result.GetLength(0) == 1)
                pbxPoster.Image = Image.FromStream(new MemoryStream((byte[])result[0, 2]));
            
            btnNext.Enabled = false;
            btnPrevious.Enabled = false;
            llbFastforward.Enabled = false;
            llbNext.Enabled = false;
            llbRewind.Enabled = false;
            llbPrevious.Enabled = false;
            timer1.Stop();
        }

        private void displayPoster(int index)
        {
            pbxPoster.Image = _announcementList[index].Poster;
            toolTip1.SetToolTip(pbxPoster, _announcementList[index].Title);


            btnNext.Enabled = true;
            btnPrevious.Enabled = true;
            llbNext.Enabled = true;
            llbPrevious.Enabled = true;
            llbFastforward.Enabled = true;
            llbRewind.Enabled = true;
            
            if (index == 0)
            {
                btnPrevious.Enabled = false;
                llbPrevious.Enabled = false;
                llbRewind.Enabled = false;
            }
            else if (index == _announcementList.Count - 1)
            {
                btnNext.Enabled = false;
                llbNext.Enabled = false;
                llbFastforward.Enabled = false;
            }

            lblPage.Text = (index + 1).ToString() + " of " + _announcementList.Count.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (index < _announcementList.Count - 1)
                displayPoster(++index);
            else
                displayPoster(index = 0);
        }

        private void previous_Click(object sender, EventArgs e)
        {
            if (index > 0)
                displayPoster(--index);
            timer1.Stop();
            timer1.Start();
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (index < _announcementList.Count - 1)
                displayPoster(++index);
            timer1.Stop();
            timer1.Start();
        }

        private void llbRewind_Click(object sender, EventArgs e)
        {
            displayPoster(index = 0);
            timer1.Stop();
            timer1.Start();
        }

        private void llbFastforward_Click(object sender, EventArgs e)
        {
            displayPoster(index = _announcementList.Count - 1);
            timer1.Stop();
            timer1.Start();
        }
    }
}
