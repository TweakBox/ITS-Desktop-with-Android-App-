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
    public partial class DownloadableFileItem : UserControl
    {
        private string _id;

        public string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        public string WebAddress { get; set; }

        private long _totalSize;
        public long TotalSize
        {
            get { return _totalSize; }
            set { _totalSize = value; setSizeText(); }
        }

        private long _downloadedSize;
        public long DownloadedSize
        {
            get { return _downloadedSize; }
            private set { _downloadedSize = value; setSizeText(); }
        }

        private DownloadStateEnum _downloadState;
        public DownloadStateEnum DownloadState
        {
            get { return _downloadState; }
            set { _downloadState = value; stateChanged(); }
        }

        public enum DownloadStateEnum { Available, Downloading, Downloaded }

        
        private WebServer _server = new WebServer("http://localhost/ITS/");


        public DownloadableFileItem(string id, string webAddress)
        {
            InitializeComponent();

            _id = id;
            WebAddress = webAddress;
            _server.DownloadProgressChanged += _server_DownloadProgressChanged;
            _server.DownloadDataCompleted += _server_DownloadDataCompleted;
        }

        private void _server_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            DownloadedSize = e.BytesReceived;
            TotalSize = e.TotalBytesToReceive;
            pbrProgress.Value = (int)(((float)e.BytesReceived / (float)e.TotalBytesToReceive) * 100f);
        }

        private void _server_DownloadDataCompleted(object sender, System.Net.DownloadDataCompletedEventArgs e)
        {
            if (!e.Cancelled)
                DownloadState = DownloadStateEnum.Downloaded;
            else
            {
                if (e.Error != null)
                    MessageBox.Show("Error occured while downloading!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DownloadState = DownloadStateEnum.Available;
                lblSize.Text = formatByteSize(e.Result.Length);
            }
        }

        private void setSizeText()
        {
            switch (DownloadState)
            {
                case DownloadStateEnum.Available:
                    lblSize.Text = formatByteSize(_totalSize);
                    break;
                case DownloadStateEnum.Downloading:
                    lblSize.Text = formatByteSize(_downloadedSize) + " of " + formatByteSize(_totalSize);
                    break;
                case DownloadStateEnum.Downloaded:
                    lblSize.Text = formatByteSize(_totalSize);
                    break;
            }
        }

        private string formatByteSize(double size)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            int order = 0;
            while (size >= 1024 && ++order < sizes.Length - 1)
                size = size / 1024;
            
            return String.Format("{0:0.##} {1}", size, sizes[order]);
        }

        private void stateChanged()
        {
            switch (DownloadState)
            {
                case DownloadStateEnum.Available:
                    pbrProgress.Visible = false;
                    btnAction.Text = "Download";
                    btnAction.Image = Properties.Resources.Download;
                    break;
                case DownloadStateEnum.Downloading:
                    pbrProgress.Visible = true;
                    btnAction.Text = "Cancel";
                    btnAction.Image = Properties.Resources.Cancel;
                    break;
                case DownloadStateEnum.Downloaded:
                    pbrProgress.Visible = false;
                    btnAction.Text = "Open";
                    btnAction.Image = Properties.Resources.OpenSmall;
                    break;
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            switch (DownloadState)
            {
                case DownloadStateEnum.Available:
                    _server.DownloadData("Handouts/" + WebAddress, "Handouts/" + _id + " - " + Title, true);
                    DownloadState = DownloadStateEnum.Downloading;
                    break;
                case DownloadStateEnum.Downloading:
                    _server.CancelAsync();
                    DownloadState = DownloadStateEnum.Available;
                    break;
                case DownloadStateEnum.Downloaded:
                    System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "Handouts/" + _id + " - " +  Title);
                    break;
            }
        }
    }
}
