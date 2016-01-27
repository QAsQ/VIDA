namespace RS
{
    partial class ColorView
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.colorButton = new System.Windows.Forms.Button();
            this.colorCheck = new System.Windows.Forms.CheckBox();
            this.colorGet = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // colorButton
            // 
            this.colorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorButton.Location = new System.Drawing.Point(0, 0);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(40, 14);
            this.colorButton.TabIndex = 0;
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.colorChange_Click);
            // 
            // colorCheck
            // 
            this.colorCheck.AutoSize = true;
            this.colorCheck.Location = new System.Drawing.Point(46, 0);
            this.colorCheck.Name = "colorCheck";
            this.colorCheck.Size = new System.Drawing.Size(15, 14);
            this.colorCheck.TabIndex = 1;
            this.colorCheck.UseVisualStyleBackColor = true;
            this.colorCheck.CheckedChanged += new System.EventHandler(this.checker_CheckedChanged);
            // 
            // ColorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.colorCheck);
            this.Controls.Add(this.colorButton);
            this.Name = "ColorView";
            this.Size = new System.Drawing.Size(65, 14);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.CheckBox colorCheck;
        private System.Windows.Forms.ColorDialog colorGet;
    }
}
