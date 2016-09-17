namespace JSLA.Teacher
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
            this.flpActions = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAnnouncements = new System.Windows.Forms.Button();
            this.btnSubjects = new System.Windows.Forms.Button();
            this.btnHandouts = new System.Windows.Forms.Button();
            this.pnlSidedrawer = new System.Windows.Forms.Panel();
            this.lblUserid = new JSLA.Usercontrols.LabelDropShadow();
            this.lblFullname = new JSLA.Usercontrols.LabelDropShadow();
            this.pbxAvatar = new System.Windows.Forms.PictureBox();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblDateTime = new JSLA.Usercontrols.LabelDropShadow();
            this.label7 = new JSLA.Usercontrols.LabelDropShadow();
            this.btnTogglesidedrawer = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pbxHeader = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lblMessage = new System.Windows.Forms.Label();
            this.flpActions.SuspendLayout();
            this.pnlSidedrawer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flpActions
            // 
            this.flpActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpActions.AutoScroll = true;
            this.flpActions.BackColor = System.Drawing.Color.White;
            this.flpActions.Controls.Add(this.label1);
            this.flpActions.Controls.Add(this.btnAnnouncements);
            this.flpActions.Controls.Add(this.btnSubjects);
            this.flpActions.Controls.Add(this.btnHandouts);
            this.flpActions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpActions.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.flpActions.ForeColor = System.Drawing.Color.Black;
            this.flpActions.Location = new System.Drawing.Point(0, 118);
            this.flpActions.Name = "flpActions";
            this.flpActions.Size = new System.Drawing.Size(248, 481);
            this.flpActions.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(3, 0);
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
            this.btnAnnouncements.Location = new System.Drawing.Point(3, 33);
            this.btnAnnouncements.Name = "btnAnnouncements";
            this.btnAnnouncements.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnAnnouncements.Size = new System.Drawing.Size(242, 35);
            this.btnAnnouncements.TabIndex = 1;
            this.btnAnnouncements.Tag = "Announcements";
            this.btnAnnouncements.Text = "Announcements";
            this.btnAnnouncements.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnnouncements.UseVisualStyleBackColor = false;
            this.btnAnnouncements.Click += new System.EventHandler(this.actions_Click);
            // 
            // btnSubjects
            // 
            this.btnSubjects.AutoEllipsis = true;
            this.btnSubjects.BackColor = System.Drawing.Color.White;
            this.btnSubjects.FlatAppearance.BorderSize = 0;
            this.btnSubjects.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubjects.Image = global::JSLA.Properties.Resources.Subjects;
            this.btnSubjects.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubjects.Location = new System.Drawing.Point(3, 74);
            this.btnSubjects.Name = "btnSubjects";
            this.btnSubjects.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnSubjects.Size = new System.Drawing.Size(242, 35);
            this.btnSubjects.TabIndex = 1;
            this.btnSubjects.Tag = "Subjects";
            this.btnSubjects.Text = "Subjects";
            this.btnSubjects.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSubjects.UseVisualStyleBackColor = false;
            this.btnSubjects.Click += new System.EventHandler(this.actions_Click);
            // 
            // btnHandouts
            // 
            this.btnHandouts.AutoEllipsis = true;
            this.btnHandouts.BackColor = System.Drawing.Color.White;
            this.btnHandouts.FlatAppearance.BorderSize = 0;
            this.btnHandouts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHandouts.Image = global::JSLA.Properties.Resources.Upload;
            this.btnHandouts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHandouts.Location = new System.Drawing.Point(3, 115);
            this.btnHandouts.Name = "btnHandouts";
            this.btnHandouts.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnHandouts.Size = new System.Drawing.Size(242, 35);
            this.btnHandouts.TabIndex = 1;
            this.btnHandouts.Tag = "Handouts";
            this.btnHandouts.Text = "Handouts";
            this.btnHandouts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHandouts.UseVisualStyleBackColor = false;
            this.btnHandouts.Click += new System.EventHandler(this.actions_Click);
            // 
            // pnlSidedrawer
            // 
            this.pnlSidedrawer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlSidedrawer.BackColor = System.Drawing.Color.DarkGray;
            this.pnlSidedrawer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSidedrawer.Controls.Add(this.lblUserid);
            this.pnlSidedrawer.Controls.Add(this.lblFullname);
            this.pnlSidedrawer.Controls.Add(this.pbxAvatar);
            this.pnlSidedrawer.Controls.Add(this.flpActions);
            this.pnlSidedrawer.ForeColor = System.Drawing.Color.White;
            this.pnlSidedrawer.Location = new System.Drawing.Point(0, 0);
            this.pnlSidedrawer.Name = "pnlSidedrawer";
            this.pnlSidedrawer.Size = new System.Drawing.Size(250, 600);
            this.pnlSidedrawer.TabIndex = 15;
            // 
            // lblUserid
            // 
            this.lblUserid.AutoEllipsis = true;
            this.lblUserid.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserid.Location = new System.Drawing.Point(84, 69);
            this.lblUserid.Name = "lblUserid";
            this.lblUserid.ShadowDepth = 3;
            this.lblUserid.Size = new System.Drawing.Size(163, 23);
            this.lblUserid.Softness = 1F;
            this.lblUserid.TabIndex = 9;
            this.lblUserid.Text = "User ID";
            // 
            // lblFullname
            // 
            this.lblFullname.AutoEllipsis = true;
            this.lblFullname.Location = new System.Drawing.Point(84, 39);
            this.lblFullname.Name = "lblFullname";
            this.lblFullname.ShadowDepth = 3;
            this.lblFullname.Size = new System.Drawing.Size(163, 30);
            this.lblFullname.Softness = 1F;
            this.lblFullname.TabIndex = 8;
            this.lblFullname.Text = "Fullname";
            // 
            // pbxAvatar
            // 
            this.pbxAvatar.Location = new System.Drawing.Point(3, 39);
            this.pbxAvatar.Name = "pbxAvatar";
            this.pbxAvatar.Size = new System.Drawing.Size(75, 75);
            this.pbxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxAvatar.TabIndex = 0;
            this.pbxAvatar.TabStop = false;
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(36, 120);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(764, 480);
            this.pnlContent.TabIndex = 18;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            this.lblDateTime.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Italic);
            this.lblDateTime.ForeColor = System.Drawing.Color.White;
            this.lblDateTime.Location = new System.Drawing.Point(54, 90);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblDateTime.ShadowDepth = 3;
            this.lblDateTime.Size = new System.Drawing.Size(135, 30);
            this.lblDateTime.Softness = 1F;
            this.lblDateTime.TabIndex = 19;
            this.lblDateTime.Text = "--/--/-- --:--";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            this.label7.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Italic);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(57, 40);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.label7.ShadowDepth = 3;
            this.label7.Size = new System.Drawing.Size(439, 45);
            this.label7.Softness = 1F;
            this.label7.TabIndex = 20;
            this.label7.Text = "Juan Sumulong Learning App";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTogglesidedrawer
            // 
            this.btnTogglesidedrawer.BackColor = System.Drawing.Color.DarkGray;
            this.btnTogglesidedrawer.FlatAppearance.BorderSize = 0;
            this.btnTogglesidedrawer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTogglesidedrawer.Font = new System.Drawing.Font("Segoe UI Light", 1F);
            this.btnTogglesidedrawer.ForeColor = System.Drawing.Color.White;
            this.btnTogglesidedrawer.Image = global::JSLA.Properties.Resources.Hamburger;
            this.btnTogglesidedrawer.Location = new System.Drawing.Point(1, 1);
            this.btnTogglesidedrawer.Name = "btnTogglesidedrawer";
            this.btnTogglesidedrawer.Size = new System.Drawing.Size(35, 35);
            this.btnTogglesidedrawer.TabIndex = 16;
            this.btnTogglesidedrawer.UseVisualStyleBackColor = false;
            this.btnTogglesidedrawer.Click += new System.EventHandler(this.btnTogglesidedrawer_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Image = global::JSLA.Properties.Resources.Exit;
            this.btnExit.Location = new System.Drawing.Point(765, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(35, 25);
            this.btnExit.TabIndex = 13;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pbxHeader
            // 
            this.pbxHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            this.pbxHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbxHeader.Font = new System.Drawing.Font("Segoe UI Semilight", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pbxHeader.ForeColor = System.Drawing.Color.White;
            this.pbxHeader.Location = new System.Drawing.Point(36, 0);
            this.pbxHeader.Name = "pbxHeader";
            this.pbxHeader.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.pbxHeader.Size = new System.Drawing.Size(764, 120);
            this.pbxHeader.TabIndex = 14;
            this.pbxHeader.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 600);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 500;
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(0, 564);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(800, 35);
            this.lblMessage.TabIndex = 21;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMessage.Visible = false;
            // 
            // Dashboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pnlSidedrawer);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnTogglesidedrawer);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pbxHeader);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.flpActions.ResumeLayout(false);
            this.flpActions.PerformLayout();
            this.pnlSidedrawer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpActions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAnnouncements;
        private System.Windows.Forms.Button btnSubjects;
        private System.Windows.Forms.Panel pnlSidedrawer;
        private Usercontrols.LabelDropShadow lblUserid;
        private Usercontrols.LabelDropShadow lblFullname;
        private System.Windows.Forms.PictureBox pbxAvatar;
        private System.Windows.Forms.Button btnTogglesidedrawer;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private Usercontrols.LabelDropShadow lblDateTime;
        private Usercontrols.LabelDropShadow label7;
        private System.Windows.Forms.PictureBox pbxHeader;
        private System.Windows.Forms.Button btnHandouts;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label lblMessage;
    }
}