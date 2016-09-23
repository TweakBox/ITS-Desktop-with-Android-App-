using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSLA.Usercontrols
{
    public partial class PictureButton : UserControl
    {
        public Image Image
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        public string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        private int _count;
        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                lblCount.Text = !(value > 99) ? value.ToString() : "99+";
                lblCount.Visible = value > 0;
            }
        }

        public PictureButton()
        {
            InitializeComponent();
        }

        private void Controls_Click(object sender, EventArgs e)
        {
            OnClick(EventArgs.Empty);
        }
    }
}
