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
            this.EdgeCV = new RS.ColorView();
            this.FillCV = new RS.ColorView();
            this.FontCV = new RS.ColorView();
            this.edgeLable = new System.Windows.Forms.Label();
            this.FillLable = new System.Windows.Forms.Label();
            this.FontLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Edge
            // 
            this.EdgeCV.Location = new System.Drawing.Point(39, 0);
            this.EdgeCV.Name = "Edge";
            this.EdgeCV.Size = new System.Drawing.Size(77, 21);
            this.EdgeCV.TabIndex = 0;
            // 
            // Fill
            // 
            this.FillCV.Location = new System.Drawing.Point(165, 0);
            this.FillCV.Name = "Fill";
            this.FillCV.Size = new System.Drawing.Size(77, 21);
            this.FillCV.TabIndex = 1;
            // 
            // Font
            // 
            this.FontCV.Location = new System.Drawing.Point(288, 0);
            this.FontCV.Name = "Font";
            this.FontCV.Size = new System.Drawing.Size(77, 21);
            this.FontCV.TabIndex = 2;
            // 
            // edgeLable
            // 
            this.edgeLable.AutoSize = true;
            this.edgeLable.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.edgeLable.Location = new System.Drawing.Point(-4, 0);
            this.edgeLable.Name = "edgeLable";
            this.edgeLable.Size = new System.Drawing.Size(37, 20);
            this.edgeLable.TabIndex = 3;
            this.edgeLable.Text = "描边";
            // 
            // FillLable
            // 
            this.FillLable.AutoSize = true;
            this.FillLable.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.FillLable.Location = new System.Drawing.Point(122, 0);
            this.FillLable.Name = "FillLable";
            this.FillLable.Size = new System.Drawing.Size(37, 20);
            this.FillLable.TabIndex = 4;
            this.FillLable.Text = "填充";
            // 
            // FontLable
            // 
            this.FontLable.AutoSize = true;
            this.FontLable.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.FontLable.Location = new System.Drawing.Point(245, 0);
            this.FontLable.Name = "FontLable";
            this.FontLable.Size = new System.Drawing.Size(37, 20);
            this.FontLable.TabIndex = 5;
            this.FontLable.Text = "字色";
            // 
            // DrawStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FontLable);
            this.Controls.Add(this.FillLable);
            this.Controls.Add(this.edgeLable);
            this.Controls.Add(this.FontCV);
            this.Controls.Add(this.FillCV);
            this.Controls.Add(this.EdgeCV);
            this.Name = "DrawStyleEditor";
            this.Size = new System.Drawing.Size(375, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ColorView EdgeCV;
        private ColorView FillCV;
        private ColorView FontCV;
        private System.Windows.Forms.Label edgeLable;
        private System.Windows.Forms.Label FillLable;
        private System.Windows.Forms.Label FontLable;

    }
}
