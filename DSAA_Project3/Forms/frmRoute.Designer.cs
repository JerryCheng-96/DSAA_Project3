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
            this.lGlance = new System.Windows.Forms.Label();
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
            this.domainStart.Location = new System.Drawing.Point(46, 0);
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
            this.domainEnd.Location = new System.Drawing.Point(46, 23);
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
            this.btnExchange.Location = new System.Drawing.Point(3, -1);
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
            this.button1.Location = new System.Drawing.Point(258, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 49);
            this.button1.TabIndex = 3;
            this.button1.Text = ">>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(3, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(298, 484);
            this.panel1.TabIndex = 4;
            // 
            // lGlance
            // 
            this.lGlance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lGlance.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lGlance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lGlance.Location = new System.Drawing.Point(5, 48);
            this.lGlance.Name = "lGlance";
            this.lGlance.Size = new System.Drawing.Size(295, 42);
            this.lGlance.TabIndex = 6;
            this.lGlance.Text = "经过 5 个地点 · 距离 1580 m";
            this.lGlance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmRoute
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(304, 579);
            this.Controls.Add(this.lGlance);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnExchange);
            this.Controls.Add(this.domainEnd);
            this.Controls.Add(this.domainStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
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
        private System.Windows.Forms.Label lGlance;
    }
}