namespace DSAA_Project3.Forms
{
    partial class frmRouteElem
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
            this.lInfo = new System.Windows.Forms.Label();
            this.GEIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GEIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lInfo
            // 
            this.lInfo.AutoSize = true;
            this.lInfo.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lInfo.Location = new System.Drawing.Point(138, 14);
            this.lInfo.Name = "lInfo";
            this.lInfo.Size = new System.Drawing.Size(158, 31);
            this.lInfo.TabIndex = 1;
            this.lInfo.Text = "工程训练中心";
            this.lInfo.Click += new System.EventHandler(this.lInfo_Click);
            // 
            // GEIcon
            // 
            this.GEIcon.BackgroundImage = global::DSAA_Project3.Properties.Resources.Station;
            this.GEIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GEIcon.Location = new System.Drawing.Point(42, 0);
            this.GEIcon.Name = "GEIcon";
            this.GEIcon.Size = new System.Drawing.Size(60, 60);
            this.GEIcon.TabIndex = 0;
            this.GEIcon.TabStop = false;
            // 
            // frmRouteElem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(300, 60);
            this.Controls.Add(this.lInfo);
            this.Controls.Add(this.GEIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRouteElem";
            this.Load += new System.EventHandler(this.frmRouteElem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GEIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox GEIcon;
        private System.Windows.Forms.Label lInfo;
    }
}