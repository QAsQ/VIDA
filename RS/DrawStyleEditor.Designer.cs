namespace RS
{
    partial class DrawStyleEditor
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
            this.FontCV = new RS.ColorView();
            this.FillCV = new RS.ColorView();
            this.EdgeCV = new RS.ColorView();
            this.SuspendLayout();
            // 
            // FontCV
            // 
            this.FontCV.Location = new System.Drawing.Point(220, 0);
            this.FontCV.Name = "FontCV";
            this.FontCV.Size = new System.Drawing.Size(110, 25);
            this.FontCV.TabIndex = 2;
            this.FontCV.Texts = "null";
            // 
            // FillCV
            // 
            this.FillCV.Location = new System.Drawing.Point(110, 0);
            this.FillCV.Name = "FillCV";
            this.FillCV.Size = new System.Drawing.Size(110, 25);
            this.FillCV.TabIndex = 1;
            this.FillCV.Texts = "null";
            // 
            // EdgeCV
            // 
            this.EdgeCV.Location = new System.Drawing.Point(0, 0);
            this.EdgeCV.Name = "EdgeCV";
            this.EdgeCV.Size = new System.Drawing.Size(110, 25);
            this.EdgeCV.TabIndex = 0;
            this.EdgeCV.Texts = "null";
            this.EdgeCV.UseWaitCursor = true;
            // 
            // DrawStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FontCV);
            this.Controls.Add(this.FillCV);
            this.Controls.Add(this.EdgeCV);
            this.Name = "DrawStyleEditor";
            this.Size = new System.Drawing.Size(330, 25);
            this.ResumeLayout(false);

        }

        #endregion

        private ColorView EdgeCV;
        private ColorView FillCV;
        private ColorView FontCV;




    }
}
