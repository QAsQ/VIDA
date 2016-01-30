namespace RS
{
    partial class colorSchemeForm
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
            this.描边 = new System.Windows.Forms.Label();
            this.填充 = new System.Windows.Forms.Label();
            this.SkillColor = new System.Windows.Forms.GroupBox();
            this.Status = new System.Windows.Forms.ComboBox();
            this.Fonts = new RS.ColorView();
            this.Edge = new RS.ColorView();
            this.Fill = new RS.ColorView();
            this.字色 = new System.Windows.Forms.Label();
            this.背景 = new System.Windows.Forms.Label();
            this.Flash = new System.Windows.Forms.Button();
            this.MiniDV = new RS.MiniDependencyView();
            this.back_ground = new RS.ColorView();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SkillColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // 描边
            // 
            this.描边.AutoSize = true;
            this.描边.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.描边.Location = new System.Drawing.Point(337, 15);
            this.描边.Name = "描边";
            this.描边.Size = new System.Drawing.Size(37, 20);
            this.描边.TabIndex = 4;
            this.描边.Text = "描边";
            // 
            // 填充
            // 
            this.填充.AutoSize = true;
            this.填充.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.填充.Location = new System.Drawing.Point(224, 15);
            this.填充.Name = "填充";
            this.填充.Size = new System.Drawing.Size(37, 20);
            this.填充.TabIndex = 5;
            this.填充.Text = "填充";
            // 
            // SkillColor
            // 
            this.SkillColor.Controls.Add(this.Status);
            this.SkillColor.Controls.Add(this.Fonts);
            this.SkillColor.Controls.Add(this.Edge);
            this.SkillColor.Controls.Add(this.Fill);
            this.SkillColor.Controls.Add(this.填充);
            this.SkillColor.Controls.Add(this.描边);
            this.SkillColor.Controls.Add(this.字色);
            this.SkillColor.Location = new System.Drawing.Point(126, 8);
            this.SkillColor.Name = "SkillColor";
            this.SkillColor.Size = new System.Drawing.Size(454, 35);
            this.SkillColor.TabIndex = 6;
            this.SkillColor.TabStop = false;
            this.SkillColor.Text = " ";
            // 
            // Status
            // 
            this.Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Status.FormattingEnabled = true;
            this.Status.Items.AddRange(new object[] {
            "已经学习",
            "可以学习",
            "无法学习"});
            this.Status.SelectedIndexChanged += new System.EventHandler(this.Status_SelectedIndexChanged);
            this.Status.Location = new System.Drawing.Point(9, 11);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(96, 20);
            this.Status.TabIndex = 10;
            // 
            // Fonts
            // 
            this.Fonts.ColorChange += new RS.ColorView.ColorChangeHandler(this.Color_Change);
            this.Fonts.color = System.Drawing.Color.Empty;
            this.Fonts.Location = new System.Drawing.Point(153, 17);
            this.Fonts.Name = "Fonts";
            this.Fonts.Size = new System.Drawing.Size(65, 14);
            this.Fonts.TabIndex = 9;
            // 
            // Edge
            // 
            this.Edge.ColorChange += new RS.ColorView.ColorChangeHandler(this.Color_Change);
            this.Edge.color = System.Drawing.Color.Empty;
            this.Edge.Location = new System.Drawing.Point(380, 17);
            this.Edge.Name = "Edge";
            this.Edge.Size = new System.Drawing.Size(65, 14);
            this.Edge.TabIndex = 7;
            // 
            // Fill
            // 
            this.Fill.ColorChange += new RS.ColorView.ColorChangeHandler(this.Color_Change);
            this.Fill.color = System.Drawing.Color.Empty;
            this.Fill.Location = new System.Drawing.Point(267, 17);
            this.Fill.Name = "Fill";
            this.Fill.Size = new System.Drawing.Size(65, 14);
            this.Fill.TabIndex = 6;
            // 
            // 字色
            // 
            this.字色.AutoSize = true;
            this.字色.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.字色.Location = new System.Drawing.Point(110, 15);
            this.字色.Name = "字色";
            this.字色.Size = new System.Drawing.Size(37, 20);
            this.字色.TabIndex = 8;
            this.字色.Text = "字色";
            // 
            // 背景
            // 
            this.背景.AutoSize = true;
            this.背景.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.背景.Location = new System.Drawing.Point(12, 23);
            this.背景.Name = "背景";
            this.背景.Size = new System.Drawing.Size(37, 20);
            this.背景.TabIndex = 10;
            this.背景.Text = "背景";
            // 
            // Flash
            // 
            this.Flash.Click += new System.EventHandler(this.Flash_Click);
            this.Flash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Flash.Location = new System.Drawing.Point(12, 363);
            this.Flash.Name = "Flash";
            this.Flash.Size = new System.Drawing.Size(75, 23);
            this.Flash.TabIndex = 8;
            this.Flash.Text = "刷新";
            this.Flash.UseVisualStyleBackColor = true;
            // 
            // MiniDV
            // 
            this.MiniDV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(122)))), ((int)(((byte)(146)))));
            this.MiniDV.Fs = new RS.DrawStyle[] {
        null,
        null,
        null};
            this.MiniDV.Location = new System.Drawing.Point(12, 49);
            this.MiniDV.Name = "MiniDV";
            this.MiniDV.Size = new System.Drawing.Size(564, 308);
            this.MiniDV.size_circle = 22;
            this.MiniDV.TabIndex = 11;
            // 
            // back_ground
            // 
            this.back_ground.ColorChange += new RS.ColorView.ColorChangeHandler(this.Color_Change);
            this.back_ground.color = System.Drawing.Color.Empty;
            this.back_ground.Location = new System.Drawing.Point(55, 25);
            this.back_ground.Name = "back_ground";
            this.back_ground.Size = new System.Drawing.Size(65, 14);
            this.back_ground.TabIndex = 10;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(415, 363);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 12;
            this.OK.Text = "确定";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(496, 363);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 13;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // colorSchemeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 400);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.MiniDV);
            this.Controls.Add(this.back_ground);
            this.Controls.Add(this.Flash);
            this.Controls.Add(this.SkillColor);
            this.Controls.Add(this.背景);
            this.Name = "colorSchemeForm";
            this.Text = "colorSchemeForm";
            this.Load += new System.EventHandler(this.colorSchemeForm_Load);
            this.SkillColor.ResumeLayout(false);
            this.SkillColor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.Label 描边;
        private System.Windows.Forms.Label 填充;
        private System.Windows.Forms.GroupBox SkillColor;
        private ColorView Edge;
        private ColorView Fill;
        private ColorView Fonts;
        private System.Windows.Forms.Label 字色;
        private System.Windows.Forms.Label 背景;
        private ColorView back_ground;
        private System.Windows.Forms.Button Flash;
        private System.Windows.Forms.ComboBox Status;
        private MiniDependencyView MiniDV;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;

    }
}