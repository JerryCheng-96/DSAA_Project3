namespace DSAA_Project3.Forms
{
    partial class frmRoute
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
            this.domainStart = new System.Windows.Forms.DomainUpDown();
            this.domainEnd = new System.Windows.Forms.DomainUpDown();
            this.btnExchange = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // domainStart
            // 
            this.domainStart.BackColor = System.Drawing.Color.White;
            this.domainStart.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.domainStart.Items.Add("不高山");
            this.domainStart.Items.Add("东门");
            this.domainStart.Items.Add("东南门");
            this.domainStart.Items.Add("二基楼");
            this.domainStart.Items.Add("二十一舍");
            this.domainStart.Items.Add("工程训练中心");
            this.domainStart.Items.Add("建环学院");
            this.domainStart.Items.Add("南门");
            this.domainStart.Items.Add("青春广场");
            this.domainStart.Items.Add("体育馆");
            this.domainStart.Items.Add("体育学院");
            this.domainStart.Items.Add("图书馆");
            this.domainStart.Items.Add("文科楼");
            this.domainStart.Items.Add("西南门");
            this.domainStart.Items.Add("校医院");
            this.domainStart.Items.Add("一基楼");
            this.domainStart.Items.Add("一教");
            this.domainStart.Items.Add("一舍");
            this.domainStart.Items.Add("一舍");
            this.domainStart.Items.Add("艺术学院");
            this.domainStart.Items.Add("综合楼");
            this.domainStart.Location = new System.Drawing.Point(44, 0);
            this.domainStart.Name = "domainStart";
            this.domainStart.ReadOnly = true;
            this.domainStart.Size = new System.Drawing.Size(212, 33);
            this.domainStart.Sorted = true;
            this.domainStart.TabIndex = 0;
            this.domainStart.Text = "（起点）";
            // 
            // domainEnd
            // 
            this.domainEnd.BackColor = System.Drawing.Color.White;
            this.domainEnd.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.domainEnd.Items.Add("不高山");
            this.domainEnd.Items.Add("东门");
            this.domainEnd.Items.Add("东南门");
            this.domainEnd.Items.Add("二基楼");
            this.domainEnd.Items.Add("二十一舍");
            this.domainEnd.Items.Add("工程训练中心");
            this.domainEnd.Items.Add("建环学院");
            this.domainEnd.Items.Add("南门");
            this.domainEnd.Items.Add("青春广场");
            this.domainEnd.Items.Add("体育馆");
            this.domainEnd.Items.Add("体育学院");
            this.domainEnd.Items.Add("图书馆");
            this.domainEnd.Items.Add("文科楼");
            this.domainEnd.Items.Add("西南门");
            this.domainEnd.Items.Add("校医院");
            this.domainEnd.Items.Add("一基楼");
            this.domainEnd.Items.Add("一教");
            this.domainEnd.Items.Add("一舍");
            this.domainEnd.Items.Add("一舍");
            this.domainEnd.Items.Add("艺术学院");
            this.domainEnd.Items.Add("综合楼");
            this.domainEnd.Location = new System.Drawing.Point(44, 23);
            this.domainEnd.Name = "domainEnd";
            this.domainEnd.ReadOnly = true;
            this.domainEnd.Size = new System.Drawing.Size(212, 33);
            this.domainEnd.Sorted = true;
            this.domainEnd.TabIndex = 1;
            this.domainEnd.Text = "（终点）";
            // 
            // btnExchange
            // 
            this.btnExchange.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExchange.Location = new System.Drawing.Point(1, -1);
            this.btnExchange.Name = "btnExchange";
            this.btnExchange.Size = new System.Drawing.Size(43, 49);
            this.btnExchange.TabIndex = 2;
            this.btnExchange.Text = "↑↓";
            this.btnExchange.UseVisualStyleBackColor = true;
            this.btnExchange.Click += new System.EventHandler(this.btnExchange_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(256, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 49);
            this.button1.TabIndex = 3;
            this.button1.Text = ">>";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(1, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(298, 560);
            this.panel1.TabIndex = 4;
            // 
            // frmRoute
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(300, 600);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnExchange);
            this.Controls.Add(this.domainEnd);
            this.Controls.Add(this.domainStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "frmRoute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "寻找路线";
            this.Load += new System.EventHandler(this.frmRoute_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DomainUpDown domainStart;
        private System.Windows.Forms.DomainUpDown domainEnd;
        private System.Windows.Forms.Button btnExchange;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
    }
}