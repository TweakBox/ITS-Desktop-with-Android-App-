namespace JSLA.Administrator
{
    partial class Announcements
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.pbxPoster = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.llbRewind = new System.Windows.Forms.LinkLabel();
            this.llbPrevious = new System.Windows.Forms.LinkLabel();
            this.lblPage = new System.Windows.Forms.Label();
            this.llbNext = new System.Windows.Forms.LinkLabel();
            this.llbFastforward = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnManage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPoster)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(192)))), ((int)(((byte)(60)))));
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Image = global::JSLA.Properties.Resources.Next;
            this.btnNext.Location = new System.Drawing.Point(765, 49);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(35, 500);
            this.btnNext.TabIndex = 1;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.next_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(192)))), ((int)(((byte)(60)))));
            this.btnPrevious.FlatAppearance.BorderSize = 0;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Image = global::JSLA.Properties.Resources.Previous;
            this.btnPrevious.Location = new System.Drawing.Point(0, 49);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(35, 500);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.previous_Click);
            // 
            // pbxPoster
            // 
            this.pbxPoster.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxPoster.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxPoster.Location = new System.Drawing.Point(35, 49);
            this.pbxPoster.Name = "pbxPoster";
            this.pbxPoster.Size = new System.Drawing.Size(730, 500);
            this.pbxPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxPoster.TabIndex = 0;
            this.pbxPoster.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.llbRewind);
            this.flowLayoutPanel1.Controls.Add(this.llbPrevious);
            this.flowLayoutPanel1.Controls.Add(this.lblPage);
            this.flowLayoutPanel1.Controls.Add(this.llbNext);
            this.flowLayoutPanel1.Controls.Add(this.llbFastforward);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 548);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(400, 35);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // llbRewind
            // 
            this.llbRewind.AutoSize = true;
            this.llbRewind.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.llbRewind.Location = new System.Drawing.Point(3, 0);
            this.llbRewind.Name = "llbRewind";
            this.llbRewind.Size = new System.Drawing.Size(41, 30);
            this.llbRewind.TabIndex = 7;
            this.llbRewind.TabStop = true;
            this.llbRewind.Text = "<<";
            this.llbRewind.Click += new System.EventHandler(this.llbRewind_Click);
            // 
            // llbPrevious
            // 
            this.llbPrevious.AutoSize = true;
            this.llbPrevious.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.llbPrevious.Location = new System.Drawing.Point(50, 0);
            this.llbPrevious.Name = "llbPrevious";
            this.llbPrevious.Size = new System.Drawing.Size(27, 30);
            this.llbPrevious.TabIndex = 5;
            this.llbPrevious.TabStop = true;
            this.llbPrevious.Text = "<";
            this.llbPrevious.Click += new System.EventHandler(this.previous_Click);
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Location = new System.Drawing.Point(83, 0);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(74, 30);
            this.lblPage.TabIndex = 8;
            this.lblPage.Text = "-- of --";
            // 
            // llbNext
            // 
            this.llbNext.AutoSize = true;
            this.llbNext.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.llbNext.Location = new System.Drawing.Point(163, 0);
            this.llbNext.Name = "llbNext";
            this.llbNext.Size = new System.Drawing.Size(27, 30);
            this.llbNext.TabIndex = 6;
            this.llbNext.TabStop = true;
            this.llbNext.Text = ">";
            this.llbNext.Click += new System.EventHandler(this.next_Click);
            // 
            // llbFastforward
            // 
            this.llbFastforward.AutoSize = true;
            this.llbFastforward.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.llbFastforward.Location = new System.Drawing.Point(196, 0);
            this.llbFastforward.Name = "llbFastforward";
            this.llbFastforward.Size = new System.Drawing.Size(41, 30);
            this.llbFastforward.TabIndex = 4;
            this.llbFastforward.TabStop = true;
            this.llbFastforward.Text = ">>";
            this.llbFastforward.Click += new System.EventHandler(this.llbFastforward_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 37);
            this.label2.TabIndex = 2;
            this.label2.Text = "Announcements";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnManage
            // 
            this.btnManage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(192)))), ((int)(((byte)(60)))));
            this.btnManage.FlatAppearance.BorderSize = 0;
            this.btnManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManage.ForeColor = System.Drawing.Color.White;
            this.btnManage.Image = global::JSLA.Properties.Resources.Edit;
            this.btnManage.Location = new System.Drawing.Point(638, 555);
            this.btnManage.Name = "btnManage";
            this.btnManage.Size = new System.Drawing.Size(150, 40);
            this.btnManage.TabIndex = 1;
            this.btnManage.Text = "Manage";
            this.btnManage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnManage.UseVisualStyleBackColor = false;
            this.btnManage.Click += new System.EventHandler(this.next_Click);
            // 
            // Announcements
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnManage);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.pbxPoster);
            this.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Announcements";
            this.Text = "Announcements";
            this.Load += new System.EventHandler(this.Announcements_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPoster)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxPoster;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.LinkLabel llbRewind;
        private System.Windows.Forms.LinkLabel llbPrevious;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.LinkLabel llbNext;
        private System.Windows.Forms.LinkLabel llbFastforward;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnManage;
    }
}