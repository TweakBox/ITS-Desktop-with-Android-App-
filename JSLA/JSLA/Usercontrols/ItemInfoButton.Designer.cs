namespace JSLA.Usercontrols
{
    partial class ItemInfoButton
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new JSLA.Usercontrols.LabelDropShadow();
            this.lblDescription = new JSLA.Usercontrols.LabelDropShadow();
            this.lblSubtitle = new JSLA.Usercontrols.LabelDropShadow();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F);
            this.lblTitle.Location = new System.Drawing.Point(18, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.ShadowDepth = 3;
            this.lblTitle.Size = new System.Drawing.Size(436, 30);
            this.lblTitle.Softness = 1F;
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Title";
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(18, 30);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.ShadowDepth = 3;
            this.lblDescription.Size = new System.Drawing.Size(488, 25);
            this.lblDescription.Softness = 1F;
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Description";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.Location = new System.Drawing.Point(460, 0);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.ShadowDepth = 3;
            this.lblSubtitle.Size = new System.Drawing.Size(49, 17);
            this.lblSubtitle.Softness = 1F;
            this.lblSubtitle.TabIndex = 4;
            this.lblSubtitle.Text = "Subtitle";
            // 
            // ItemInfoButton
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "ItemInfoButton";
            this.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.Size = new System.Drawing.Size(524, 55);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private LabelDropShadow lblTitle;
        private LabelDropShadow lblDescription;
        private LabelDropShadow lblSubtitle;
    }
}
