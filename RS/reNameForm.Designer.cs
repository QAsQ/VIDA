namespace RS
{
    partial class reNameForm
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
            this.Cancel = new System.Windows.Forms.Button();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(14, 60);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(101, 33);
            this.OK.TabIndex = 0;
            this.OK.Text = "确定";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(139, 60);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(106, 33);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // inputBox
            // 
            this.inputBox.Location = new System.Drawing.Point(108, 26);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(137, 21);
            this.inputBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "请输入新名称";
            // 
            // reNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 105);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Name = "reNameForm";
            this.Text = "重命名";
            this.Activated += new System.EventHandler(this.reNameForm_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Label label1;
    }
}