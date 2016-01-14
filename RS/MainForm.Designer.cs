namespace RS
{
    partial class mainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.MainRV = new RS.RelationView();
            this.tea = new System.Windows.Forms.Button();
            this.sut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(712, 445);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainRV
            // 
            this.MainRV.circleR = 50;
            this.MainRV.Location = new System.Drawing.Point(28, 21);
            this.MainRV.Name = "MainRV";
            this.MainRV.Size = new System.Drawing.Size(742, 418);
            this.MainRV.TabIndex = 3;
            // 
            // tea
            // 
            this.tea.Location = new System.Drawing.Point(594, 444);
            this.tea.Name = "tea";
            this.tea.Size = new System.Drawing.Size(75, 23);
            this.tea.TabIndex = 4;
            this.tea.Text = "tea";
            this.tea.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tea.UseVisualStyleBackColor = true;
            this.tea.Click += new System.EventHandler(this.button2_Click);
            // 
            // sut
            // 
            this.sut.Location = new System.Drawing.Point(488, 444);
            this.sut.Name = "sut";
            this.sut.Size = new System.Drawing.Size(75, 23);
            this.sut.TabIndex = 5;
            this.sut.Text = "stu";
            this.sut.UseVisualStyleBackColor = true;
            this.sut.Click += new System.EventHandler(this.sut_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(810, 489);
            this.Controls.Add(this.sut);
            this.Controls.Add(this.tea);
            this.Controls.Add(this.MainRV);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "mainForm";
            this.Text = "MainForm";
            this.LocationChanged += new System.EventHandler(this.mainForm_LocationChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private RelationView MainRV;
        private System.Windows.Forms.Button tea;
        private System.Windows.Forms.Button sut;




    }
}

