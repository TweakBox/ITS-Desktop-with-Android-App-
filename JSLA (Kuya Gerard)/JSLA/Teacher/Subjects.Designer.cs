namespace JSLA.Teacher
{
    partial class Subjects
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
            this.flpGallery = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new JSLA.Usercontrols.LabelDropShadow();
            this.flpSections = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpGallery
            // 
            this.flpGallery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpGallery.AutoScroll = true;
            this.flpGallery.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flpGallery.Location = new System.Drawing.Point(12, 49);
            this.flpGallery.Name = "flpGallery";
            this.flpGallery.Padding = new System.Windows.Forms.Padding(25);
            this.flpGallery.Size = new System.Drawing.Size(570, 539);
            this.flpGallery.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.ShadowDepth = 1;
            this.label1.Size = new System.Drawing.Size(115, 37);
            this.label1.Softness = 1F;
            this.label1.TabIndex = 1;
            this.label1.Text = "Subjects:";
            // 
            // flpSections
            // 
            this.flpSections.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flpSections.Location = new System.Drawing.Point(588, 49);
            this.flpSections.Name = "flpSections";
            this.flpSections.Size = new System.Drawing.Size(200, 539);
            this.flpSections.TabIndex = 2;
            // 
            // Subjects
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.flpGallery);
            this.Controls.Add(this.flpSections);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Subjects";
            this.Text = "Subjects";
            this.Load += new System.EventHandler(this.Subjects_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flpGallery;
        private JSLA.Usercontrols.LabelDropShadow label1;
        private System.Windows.Forms.FlowLayoutPanel flpSections;
    }
}