namespace RS
{
    partial class tailGetForm
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
            this.cancel = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.To = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(172, 38);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 25);
            this.cancel.TabIndex = 4;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(91, 38);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 25);
            this.OK.TabIndex = 3;
            this.OK.Text = "确定";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // To
            // 
            this.To.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.To.FormattingEnabled = true;
            this.To.Location = new System.Drawing.Point(12, 12);
            this.To.Name = "To";
            this.To.Size = new System.Drawing.Size(235, 20);
            this.To.TabIndex = 6;
            // 
            // tailGetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 70);
            this.Controls.Add(this.To);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.OK);
            this.MinimumSize = new System.Drawing.Size(275, 108);
            this.Name = "tailGetForm";
            this.Text = "请选择后继";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.ComboBox To;
    }
}