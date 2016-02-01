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
            RS.ColorScheme colorScheme1 = new RS.ColorScheme();
            RS.DrawStyle drawStyle1 = new RS.DrawStyle();
            this.StateChoice = new System.Windows.Forms.ComboBox();
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
            // MiniDV
            // 
            this.MiniDV.Location = new System.Drawing.Point(12, 68);
            this.MiniDV.Name = "MiniDV";
            this.MiniDV.Scheme = colorScheme1;
            this.MiniDV.Size = new System.Drawing.Size(555, 361);
            this.MiniDV.size_circle = 50;
            this.MiniDV.TabIndex = 2;
            // 
            // drawStyleEditor
            // 
            this.drawStyleEditor.drawStyle = drawStyle1;
            this.drawStyleEditor.Location = new System.Drawing.Point(12, 38);
            this.drawStyleEditor.Name = "drawStyleEditor";
            this.drawStyleEditor.Size = new System.Drawing.Size(346, 24);
            this.drawStyleEditor.TabIndex = 0;
            // 
            // SchemeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 483);
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
    }
}