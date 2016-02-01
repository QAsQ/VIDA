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
            this.ColorGeter = new System.Windows.Forms.ColorDialog();
            this.checker = new System.Windows.Forms.CheckBox();
            this.button = new System.Windows.Forms.Button();
            this.lable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checker
            // 
            this.checker.AutoSize = true;
            this.checker.Location = new System.Drawing.Point(95, 6);
            this.checker.Name = "checker";
            this.checker.Size = new System.Drawing.Size(15, 14);
            this.checker.TabIndex = 0;
            this.checker.UseVisualStyleBackColor = true;
            this.checker.CheckStateChanged += new System.EventHandler(this.checker_CheckStateChanged);
            // 
            // button
            // 
            this.button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button.Location = new System.Drawing.Point(37, 2);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(52, 21);
            this.button.TabIndex = 1;
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // lable
            // 
            this.lable.AutoSize = true;
            this.lable.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lable.Location = new System.Drawing.Point(-3, 1);
            this.lable.Name = "lable";
            this.lable.Size = new System.Drawing.Size(35, 20);
            this.lable.TabIndex = 4;
            this.lable.Text = "null";
            // 
            // ColorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checker);
            this.Controls.Add(this.button);
            this.Controls.Add(this.lable);
            this.Name = "ColorView";
            this.Size = new System.Drawing.Size(110, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog ColorGeter;
        private System.Windows.Forms.CheckBox checker;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Label lable;
    }
}
