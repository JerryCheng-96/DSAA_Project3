namespace DSAA_Project3
{
    partial class frmInfo
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
            this.btnConfirm = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lName = new System.Windows.Forms.Label();
            this.lEngName = new System.Windows.Forms.Label();
            this.lType = new System.Windows.Forms.Label();
            this.lInfo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.SteelBlue;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnConfirm.Location = new System.Drawing.Point(2, 538);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(300, 40);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "完成";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SeaGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(2, 498);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(300, 40);
            this.button1.TabIndex = 2;
            this.button1.Text = "出发...";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lName.Location = new System.Drawing.Point(6, 231);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(128, 46);
            this.lName.TabIndex = 3;
            this.lName.Text = "不高山";
            this.lName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lName.Click += new System.EventHandler(this.lName_Click);
            // 
            // lEngName
            // 
            this.lEngName.AutoSize = true;
            this.lEngName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lEngName.Location = new System.Drawing.Point(8, 265);
            this.lEngName.Name = "lEngName";
            this.lEngName.Size = new System.Drawing.Size(174, 27);
            this.lEngName.TabIndex = 4;
            this.lEngName.Text = "Bugao Moutain";
            this.lEngName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lType
            // 
            this.lType.AutoSize = true;
            this.lType.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lType.ForeColor = System.Drawing.Color.DarkGray;
            this.lType.Location = new System.Drawing.Point(250, 234);
            this.lType.Name = "lType";
            this.lType.Size = new System.Drawing.Size(38, 31);
            this.lType.TabIndex = 5;
            this.lType.Text = "楼";
            this.lType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lInfo
            // 
            this.lInfo.AutoEllipsis = true;
            this.lInfo.AutoSize = true;
            this.lInfo.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lInfo.Location = new System.Drawing.Point(11, 299);
            this.lInfo.MaximumSize = new System.Drawing.Size(280, 0);
            this.lInfo.Name = "lInfo";
            this.lInfo.Size = new System.Drawing.Size(0, 27);
            this.lInfo.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(2, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 225);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(304, 579);
            this.Controls.Add(this.lInfo);
            this.Controls.Add(this.lType);
            this.Controls.Add(this.lEngName);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmInfo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lEngName;
        private System.Windows.Forms.Label lType;
        private System.Windows.Forms.Label lInfo;
    }
}