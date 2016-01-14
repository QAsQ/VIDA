namespace RS
{
    partial class edgeGetForm
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
            this.OK = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.from = new System.Windows.Forms.TextBox();
            this.to = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(42, 64);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(110, 38);
            this.OK.TabIndex = 0;
            this.OK.Text = "确定";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(187, 64);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(109, 38);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // from
            // 
            this.from.Location = new System.Drawing.Point(42, 22);
            this.from.Name = "from";
            this.from.Size = new System.Drawing.Size(110, 21);
            this.from.TabIndex = 2;
            // 
            // to
            // 
            this.to.Location = new System.Drawing.Point(187, 22);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(109, 21);
            this.to.TabIndex = 3;
            // 
            // edgeGetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 128);
            this.Controls.Add(this.to);
            this.Controls.Add(this.from);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.OK);
            this.Name = "edgeGetForm";
            this.Text = "edgeGetForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.TextBox from;
        private System.Windows.Forms.TextBox to;
    }
}