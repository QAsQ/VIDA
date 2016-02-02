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
            this.SkillFillCV = new RS.ColorView();
            this.SkillEdgeCV = new RS.ColorView();
            this.ArrowLineCV = new RS.ColorView();
            this.ArrowEdgeCV = new RS.ColorView();
            this.ArrowFillCV = new RS.ColorView();
            this.SkilLabel = new System.Windows.Forms.Label();
            this.ArrowLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FontCV
            // 
            this.FontCV.Location = new System.Drawing.Point(52, 0);
            this.FontCV.Name = "FontCV";
            this.FontCV.Size = new System.Drawing.Size(110, 25);
            this.FontCV.TabIndex = 2;
            this.FontCV.Texts = "字色";
            // 
            // SkillFillCV
            // 
            this.SkillFillCV.Location = new System.Drawing.Point(162, 0);
            this.SkillFillCV.Name = "SkillFillCV";
            this.SkillFillCV.Size = new System.Drawing.Size(110, 25);
            this.SkillFillCV.TabIndex = 1;
            this.SkillFillCV.Texts = "填充";
            // 
            // SkillEdgeCV
            // 
            this.SkillEdgeCV.Location = new System.Drawing.Point(272, 0);
            this.SkillEdgeCV.Name = "SkillEdgeCV";
            this.SkillEdgeCV.Size = new System.Drawing.Size(110, 25);
            this.SkillEdgeCV.TabIndex = 0;
            this.SkillEdgeCV.Texts = "描边";
            // 
            // ArrowLineCV
            // 
            this.ArrowLineCV.Location = new System.Drawing.Point(52, 29);
            this.ArrowLineCV.Name = "ArrowLineCV";
            this.ArrowLineCV.Size = new System.Drawing.Size(110, 25);
            this.ArrowLineCV.TabIndex = 3;
            this.ArrowLineCV.Texts = "线色";
            // 
            // ArrowEdgeCV
            // 
            this.ArrowEdgeCV.Location = new System.Drawing.Point(162, 31);
            this.ArrowEdgeCV.Name = "ArrowEdgeCV";
            this.ArrowEdgeCV.Size = new System.Drawing.Size(110, 25);
            this.ArrowEdgeCV.TabIndex = 4;
            this.ArrowEdgeCV.Texts = "描边";
            // 
            // ArrowFillCV
            // 
            this.ArrowFillCV.Location = new System.Drawing.Point(272, 29);
            this.ArrowFillCV.Name = "ArrowFillCV";
            this.ArrowFillCV.Size = new System.Drawing.Size(110, 25);
            this.ArrowFillCV.TabIndex = 5;
            this.ArrowFillCV.Texts = "填充";
            // 
            // SkilLabel
            // 
            this.SkilLabel.AutoSize = true;
            this.SkilLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SkilLabel.Location = new System.Drawing.Point(10, 2);
            this.SkilLabel.Name = "SkilLabel";
            this.SkilLabel.Size = new System.Drawing.Size(37, 19);
            this.SkilLabel.TabIndex = 6;
            this.SkilLabel.Text = "Skill";
            // 
            // ArrowLabel
            // 
            this.ArrowLabel.AutoSize = true;
            this.ArrowLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ArrowLabel.Location = new System.Drawing.Point(0, 32);
            this.ArrowLabel.Name = "ArrowLabel";
            this.ArrowLabel.Size = new System.Drawing.Size(53, 19);
            this.ArrowLabel.TabIndex = 7;
            this.ArrowLabel.Text = "Arrow";
            // 
            // DrawStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ArrowLabel);
            this.Controls.Add(this.SkilLabel);
            this.Controls.Add(this.ArrowFillCV);
            this.Controls.Add(this.ArrowEdgeCV);
            this.Controls.Add(this.ArrowLineCV);
            this.Controls.Add(this.FontCV);
            this.Controls.Add(this.SkillFillCV);
            this.Controls.Add(this.SkillEdgeCV);
            this.Name = "DrawStyleEditor";
            this.Size = new System.Drawing.Size(384, 55);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ColorView SkillEdgeCV;
        private ColorView SkillFillCV;
        private ColorView FontCV;
        private ColorView ArrowLineCV;
        private ColorView ArrowEdgeCV;
        private ColorView ArrowFillCV;
        private System.Windows.Forms.Label SkilLabel;
        private System.Windows.Forms.Label ArrowLabel;




    }
}
