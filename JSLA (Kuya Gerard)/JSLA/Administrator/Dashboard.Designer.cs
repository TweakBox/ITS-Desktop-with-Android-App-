namespace JSLA.Administrator
{
    partial class Dashboard
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
            this.lblDateTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlSidedrawer = new System.Windows.Forms.Panel();
            this.flpActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAnnouncements = new System.Windows.Forms.Button();
            this.btnFileManager = new System.Windows.Forms.Button();
            this.btnSubjects = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnTogglesidedrawer = new System.Windows.Forms.Button();
            this.pbxHeader = new System.Windows.Forms.PictureBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label7 = new JSLA.Usercontrols.LabelDropShadow();
            this.lblFullname = new JSLA.Usercontrols.LabelDropShadow();
            this.lblUserid = new JSLA.Usercontrols.LabelDropShadow();
            this.pbxAvatar = new System.Windows.Forms.PictureBox();
            this.pnlSidedrawer.SuspendLayout();
            this.flpActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDateTime
            // 
            this.lblDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            this.lblDateTime.ForeColor = System.Drawing.Color.White;
            this.lblDateTime.Location = new System.Drawing.Point(409, 0);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(350, 30);
            this.lblDateTime.TabIndex = 17;
            this.lblDateTime.Text = "--/--/-- --:--";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnlSidedrawer
            // 
            this.pnlSidedrawer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSidedrawer.BackColor = System.Drawing.Color.White;
            this.pnlSidedrawer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSidedrawer.Controls.Add(this.lblUserid);
            this.pnlSidedrawer.Controls.Add(this.lblFullname);
            this.pnlSidedrawer.Controls.Add(this.pbxAvatar);
            this.pnlSidedrawer.Controls.Add(this.flpActions);
            this.pnlSidedrawer.ForeColor = System.Drawing.Color.Black;
            this.pnlSidedrawer.Location = new System.Drawing.Point(538, 81);
            this.pnlSidedrawer.Name = "pnlSidedrawer";
            this.pnlSidedrawer.Size = new System.Drawing.Size(250, 401);
            this.pnlSidedrawer.TabIndex = 19;
            this.pnlSidedrawer.Visible = false;
            // 
            // flpActions
            // 
            this.flpActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpActions.AutoScroll = true;
            this.flpActions.AutoSize = true;
            this.flpActions.BackColor = System.Drawing.Color.White;
            this.flpActions.Controls.Add(this.btnExit);
            this.flpActions.Controls.Add(this.pictureBox1);
            this.flpActions.Controls.Add(this.label1);
            this.flpActions.Controls.Add(this.btnAnnouncements);
            this.flpActions.Controls.Add(this.btnFileManager);
            this.flpActions.Controls.Add(this.btnSubjects);
            this.flpActions.Controls.Add(this.pictureBox2);
            this.flpActions.Controls.Add(this.btnLogout);
            this.flpActions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpActions.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.flpActions.ForeColor = System.Drawing.Color.Black;
            this.flpActions.Location = new System.Drawing.Point(0, 84);
            this.flpActions.Name = "flpActions";
            this.flpActions.Size = new System.Drawing.Size(249, 315);
            this.flpActions.TabIndex = 7;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F);
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Image = global::JSLA.Properties.Resources.Exit_Dark;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(3, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnExit.Size = new System.Drawing.Size(242, 45);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Quit";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox1.Location = new System.Drawing.Point(11, 56);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 2);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(3, 63);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(97, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Actions";
            // 
            // btnAnnouncements
            // 
            this.btnAnnouncements.AutoEllipsis = true;
            this.btnAnnouncements.BackColor = System.Drawing.Color.White;
            this.btnAnnouncements.FlatAppearance.BorderSize = 0;
            this.btnAnnouncements.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnouncements.Image = global::JSLA.Properties.Resources.Announcements;
            this.btnAnnouncements.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnnouncements.Location = new System.Drawing.Point(3, 96);
            this.btnAnnouncements.Name = "btnAnnouncements";
            this.btnAnnouncements.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnAnnouncements.Size = new System.Drawing.Size(242, 45);
            this.btnAnnouncements.TabIndex = 1;
            this.btnAnnouncements.Tag = "Announcements";
            this.btnAnnouncements.Text = "Announcements";
            this.btnAnnouncements.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnnouncements.UseVisualStyleBackColor = false;
            this.btnAnnouncements.Click += new System.EventHandler(this.actions_Click);
            // 
            // btnFileManager
            // 
            this.btnFileManager.AutoEllipsis = true;
            this.btnFileManager.BackColor = System.Drawing.Color.White;
            this.btnFileManager.FlatAppearance.BorderSize = 0;
            this.btnFileManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileManager.Image = global::JSLA.Properties.Resources.Data;
            this.btnFileManager.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFileManager.Location = new System.Drawing.Point(3, 147);
            this.btnFileManager.Name = "btnFileManager";
            this.btnFileManager.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnFileManager.Size = new System.Drawing.Size(242, 45);
            this.btnFileManager.TabIndex = 1;
            this.btnFileManager.Tag = "File Manager";
            this.btnFileManager.Text = "File manager";
            this.btnFileManager.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFileManager.UseVisualStyleBackColor = false;
            this.btnFileManager.Click += new System.EventHandler(this.actions_Click);
            // 
            // btnSubjects
            // 
            this.btnSubjects.AutoEllipsis = true;
            this.btnSubjects.BackColor = System.Drawing.Color.White;
            this.btnSubjects.FlatAppearance.BorderSize = 0;
            this.btnSubjects.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubjects.Image = global::JSLA.Properties.Resources.Accounts;
            this.btnSubjects.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubjects.Location = new System.Drawing.Point(3, 198);
            this.btnSubjects.Name = "btnSubjects";
            this.btnSubjects.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnSubjects.Size = new System.Drawing.Size(242, 45);
            this.btnSubjects.TabIndex = 1;
            this.btnSubjects.Tag = "Account Manager";
            this.btnSubjects.Text = "Account Manager";
            this.btnSubjects.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSubjects.UseVisualStyleBackColor = false;
            this.btnSubjects.Click += new System.EventHandler(this.actions_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox2.Location = new System.Drawing.Point(11, 251);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(225, 2);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F);
            this.btnLogout.ForeColor = System.Drawing.Color.Black;
            this.btnLogout.Image = global::JSLA.Properties.Resources.Logout;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(3, 261);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(242, 45);
            this.btnLogout.TabIndex = 13;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlContent.Location = new System.Drawing.Point(0, 75);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(800, 525);
            this.pnlContent.TabIndex = 20;
            // 
            // btnTogglesidedrawer
            // 
            this.btnTogglesidedrawer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTogglesidedrawer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            this.btnTogglesidedrawer.FlatAppearance.BorderSize = 0;
            this.btnTogglesidedrawer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTogglesidedrawer.Font = new System.Drawing.Font("Segoe UI Light", 1F);
            this.btnTogglesidedrawer.ForeColor = System.Drawing.Color.White;
            this.btnTogglesidedrawer.Image = global::JSLA.Properties.Resources.Hamburger;
            this.btnTogglesidedrawer.Location = new System.Drawing.Point(765, 0);
            this.btnTogglesidedrawer.Name = "btnTogglesidedrawer";
            this.btnTogglesidedrawer.Size = new System.Drawing.Size(35, 35);
            this.btnTogglesidedrawer.TabIndex = 18;
            this.btnTogglesidedrawer.UseVisualStyleBackColor = false;
            this.btnTogglesidedrawer.Click += new System.EventHandler(this.btnTogglesidedrawer_Click);
            // 
            // pbxHeader
            // 
            this.pbxHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            this.pbxHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbxHeader.Font = new System.Drawing.Font("Segoe UI Semilight", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pbxHeader.ForeColor = System.Drawing.Color.White;
            this.pbxHeader.Location = new System.Drawing.Point(0, 0);
            this.pbxHeader.Name = "pbxHeader";
            this.pbxHeader.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.pbxHeader.Size = new System.Drawing.Size(800, 75);
            this.pbxHeader.TabIndex = 14;
            this.pbxHeader.TabStop = false;
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(0, 565);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(800, 35);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMessage.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            this.label7.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Italic);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(51, 0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.label7.ShadowDepth = 3;
            this.label7.Size = new System.Drawing.Size(439, 45);
            this.label7.Softness = 1F;
            this.label7.TabIndex = 16;
            this.label7.Text = "Juan Sumulong Learning App";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFullname
            // 
            this.lblFullname.AutoEllipsis = true;
            this.lblFullname.Location = new System.Drawing.Point(84, 25);
            this.lblFullname.Name = "lblFullname";
            this.lblFullname.ShadowDepth = 2;
            this.lblFullname.Size = new System.Drawing.Size(163, 30);
            this.lblFullname.Softness = 1F;
            this.lblFullname.TabIndex = 8;
            this.lblFullname.Text = "Fullname";
            // 
            // lblUserid
            // 
            this.lblUserid.AutoEllipsis = true;
            this.lblUserid.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserid.Location = new System.Drawing.Point(84, 55);
            this.lblUserid.Name = "lblUserid";
            this.lblUserid.ShadowDepth = 2;
            this.lblUserid.Size = new System.Drawing.Size(163, 23);
            this.lblUserid.Softness = 1F;
            this.lblUserid.TabIndex = 9;
            this.lblUserid.Text = "User ID";
            // 
            // pbxAvatar
            // 
            this.pbxAvatar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxAvatar.Location = new System.Drawing.Point(3, 3);
            this.pbxAvatar.Name = "pbxAvatar";
            this.pbxAvatar.Size = new System.Drawing.Size(75, 75);
            this.pbxAvatar.TabIndex = 0;
            this.pbxAvatar.TabStop = false;
            // 
            // Dashboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pnlSidedrawer);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.btnTogglesidedrawer);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.pbxHeader);
            this.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.pnlSidedrawer.ResumeLayout(false);
            this.pnlSidedrawer.PerformLayout();
            this.flpActions.ResumeLayout(false);
            this.flpActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private Usercontrols.LabelDropShadow label7;
        private System.Windows.Forms.PictureBox pbxHeader;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Button btnTogglesidedrawer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlSidedrawer;
        private Usercontrols.LabelDropShadow lblFullname;
        private System.Windows.Forms.FlowLayoutPanel flpActions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFileManager;
        private System.Windows.Forms.Button btnSubjects;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAnnouncements;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblMessage;
        private Usercontrols.LabelDropShadow lblUserid;
        private System.Windows.Forms.PictureBox pbxAvatar;
    }
}