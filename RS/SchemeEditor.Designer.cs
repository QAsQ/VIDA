namespace RS
{
    partial class SchemeEditor
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
            RS.DrawStyle drawStyle1 = new RS.DrawStyle();
            this.StateChoice = new System.Windows.Forms.ComboBox();
            this.cancel = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.backGroundColor = new RS.ColorView();
            this.MiniDV = new RS.MiniDependencyView();
            this.drawStyleEditor = new RS.DrawStyleEditor();
            this.SuspendLayout();
            // 
            // StateChoice
            // 
            this.StateChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StateChoice.FormattingEnabled = true;
            this.StateChoice.Items.AddRange(new object[] {
            "已经学习",
            "可以学习",
            "不能学习"});
            this.StateChoice.Location = new System.Drawing.Point(12, 12);
            this.StateChoice.Name = "StateChoice";
            this.StateChoice.Size = new System.Drawing.Size(121, 20);
            this.StateChoice.TabIndex = 1;
            this.StateChoice.SelectedIndexChanged += new System.EventHandler(this.StateChoice_SelectedIndexChanged);
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.Location = new System.Drawing.Point(483, 435);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 25);
            this.cancel.TabIndex = 6;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // OK
            // 
            this.OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OK.Location = new System.Drawing.Point(402, 435);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 25);
            this.OK.TabIndex = 5;
            this.OK.Text = "应用";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // backGroundColor
            // 
            this.backGroundColor.Location = new System.Drawing.Point(12, 42);
            this.backGroundColor.Name = "backGroundColor";
            this.backGroundColor.Size = new System.Drawing.Size(110, 25);
            this.backGroundColor.TabIndex = 3;
            this.backGroundColor.Texts = "背景";
            // 
            // MiniDV
            // 
            this.MiniDV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MiniDV.Location = new System.Drawing.Point(12, 73);
            this.MiniDV.Name = "MiniDV";
            this.MiniDV.Size = new System.Drawing.Size(546, 350);
            this.MiniDV.size_circle = 62;
            this.MiniDV.TabIndex = 2;
            // 
            // drawStyleEditor
            // 
            this.drawStyleEditor.drawStyle = drawStyle1;
            this.drawStyleEditor.Location = new System.Drawing.Point(139, 12);
            this.drawStyleEditor.Name = "drawStyleEditor";
            this.drawStyleEditor.Size = new System.Drawing.Size(387, 55);
            this.drawStyleEditor.TabIndex = 0;
            // 
            // SchemeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 472);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.backGroundColor);
            this.Controls.Add(this.MiniDV);
            this.Controls.Add(this.StateChoice);
            this.Controls.Add(this.drawStyleEditor);
            this.Name = "SchemeEditor";
            this.Text = "SchemeEditor";
            this.ResumeLayout(false);

        }

        #endregion

        private DrawStyleEditor drawStyleEditor;
        private System.Windows.Forms.ComboBox StateChoice;
        private MiniDependencyView MiniDV;
        private ColorView backGroundColor;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button OK;
    }
}