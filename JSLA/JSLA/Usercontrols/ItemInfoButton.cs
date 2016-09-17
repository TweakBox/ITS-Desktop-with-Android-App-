using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSLA.Usercontrols
{
    public partial class ItemInfoButton : UserControl
    {
        public string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        public string Subtitle
        {
            get { return lblSubtitle.Text; }
            set { lblSubtitle.Text = value; }
        }

        public string Description
        {
            get { return lblDescription.Text; }
            set { lblDescription.Text = value; }
        }

        public ItemInfoButton()
        {
            InitializeComponent();

            foreach (Control item in Controls)
                item.Click += Controls_Click;
            lblTitle.Width = Width - lblSubtitle.Width + 6;
        }

        private void Controls_Click(object sender, EventArgs e)
        {
            OnClick(EventArgs.Empty);
        }



        
    }
}
