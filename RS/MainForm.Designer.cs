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
            this.MainRV = new RS.RelationView();
            this.SuspendLayout();
            // 
            // MainRV
            // 
            this.MainRV.circleR = 50;
            this.MainRV.Location = new System.Drawing.Point(0, 0);
            this.MainRV.Name = "MainRV";
            this.MainRV.Size = new System.Drawing.Size(1920, 1080);
            this.MainRV.TabIndex = 3;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(810, 489);
            this.Controls.Add(this.MainRV);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "mainForm";
            this.Text = "MainForm";
            this.LocationChanged += new System.EventHandler(this.mainForm_LocationChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private RelationView MainRV;




    }
}

