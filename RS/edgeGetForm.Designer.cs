﻿namespace RS
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
            this.From = new System.Windows.Forms.ComboBox();
            this.To = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(93, 38);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 25);
            this.OK.TabIndex = 0;
            this.OK.Text = "确定";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(174, 38);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 25);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // From
            // 
            this.From.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.From.FormattingEnabled = true;
            this.From.Location = new System.Drawing.Point(10, 12);
            this.From.Name = "From";
            this.From.Size = new System.Drawing.Size(117, 20);
            this.From.TabIndex = 4;
            this.From.SelectedIndexChanged += new System.EventHandler(this.From_SelectedIndexChanged);
            // 
            // To
            // 
            this.To.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.To.FormattingEnabled = true;
            this.To.Location = new System.Drawing.Point(133, 12);
            this.To.Name = "To";
            this.To.Size = new System.Drawing.Size(117, 20);
            this.To.TabIndex = 5;
            // 
            // edgeGetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 70);
            this.Controls.Add(this.To);
            this.Controls.Add(this.From);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.OK);
            this.Name = "edgeGetForm";
            this.Text = "请依次选择依赖的起点和终点";
            this.Load += new System.EventHandler(this.edgeGetForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.ComboBox From;
        private System.Windows.Forms.ComboBox To;
    }
}