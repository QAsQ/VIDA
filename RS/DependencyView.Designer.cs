namespace RS
{
    partial class DependencyView
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
            this.components = new System.ComponentModel.Container();
            this.MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.刷新 = new System.Windows.Forms.ToolStripMenuItem();
            this.重命名 = new System.Windows.Forms.ToolStripMenuItem();
            this.添加技能 = new System.Windows.Forms.ToolStripMenuItem();
            this.删除技能 = new System.Windows.Forms.ToolStripMenuItem();
            this.学习技能 = new System.Windows.Forms.ToolStripMenuItem();
            this.添加依赖关系 = new System.Windows.Forms.ToolStripMenuItem();
            this.删除依赖关系 = new System.Windows.Forms.ToolStripMenuItem();
            this.检查依赖关系 = new System.Windows.Forms.ToolStripMenuItem();
            this.添加后继 = new System.Windows.Forms.ToolStripMenuItem();
            this.删除后继 = new System.Windows.Forms.ToolStripMenuItem();
            this.reNameBox = new System.Windows.Forms.TextBox();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新,
            this.重命名,
            this.添加技能,
            this.删除技能,
            this.学习技能,
            this.添加依赖关系,
            this.删除依赖关系,
            this.检查依赖关系,
            this.添加后继,
            this.删除后继});
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(170, 224);
            // 
            // 刷新
            // 
            this.刷新.Name = "刷新";
            this.刷新.Size = new System.Drawing.Size(169, 22);
            this.刷新.Text = "刷新";
            this.刷新.Click += new System.EventHandler(this.刷新_Click);
            // 
            // 重命名
            // 
            this.重命名.Name = "重命名";
            this.重命名.Size = new System.Drawing.Size(169, 22);
            this.重命名.Text = "重命名(&Rename)";
            this.重命名.Click += new System.EventHandler(this.重命名_Click);
            // 
            // 添加技能
            // 
            this.添加技能.Name = "添加技能";
            this.添加技能.Size = new System.Drawing.Size(169, 22);
            this.添加技能.Text = "添加技能(&New)";
            this.添加技能.Click += new System.EventHandler(this.添加技能_Click);
            // 
            // 删除技能
            // 
            this.删除技能.Name = "删除技能";
            this.删除技能.Size = new System.Drawing.Size(169, 22);
            this.删除技能.Text = "删除技能(&Delete)";
            this.删除技能.Click += new System.EventHandler(this.删除技能_Click);
            // 
            // 学习技能
            // 
            this.学习技能.Name = "学习技能";
            this.学习技能.Size = new System.Drawing.Size(169, 22);
            this.学习技能.Text = "学习技能";
            this.学习技能.Click += new System.EventHandler(this.学习技能_Click);
            // 
            // 添加依赖关系
            // 
            this.添加依赖关系.Name = "添加依赖关系";
            this.添加依赖关系.Size = new System.Drawing.Size(169, 22);
            this.添加依赖关系.Text = "添加依赖关系";
            this.添加依赖关系.Click += new System.EventHandler(this.添加依赖关系_Click);
            // 
            // 删除依赖关系
            // 
            this.删除依赖关系.Name = "删除依赖关系";
            this.删除依赖关系.Size = new System.Drawing.Size(169, 22);
            this.删除依赖关系.Text = "删除依赖关系";
            this.删除依赖关系.Click += new System.EventHandler(this.删除依赖关系_Click);
            // 
            // 检查依赖关系
            // 
            this.检查依赖关系.Name = "检查依赖关系";
            this.检查依赖关系.Size = new System.Drawing.Size(169, 22);
            this.检查依赖关系.Text = "检查依赖关系";
            this.检查依赖关系.Click += new System.EventHandler(this.检查依赖关系_Click);
            // 
            // 添加后继
            // 
            this.添加后继.Name = "添加后继";
            this.添加后继.Size = new System.Drawing.Size(169, 22);
            this.添加后继.Text = "添加后继(&Link)";
            this.添加后继.Click += new System.EventHandler(this.添加后继_Click);
            // 
            // 删除后继
            // 
            this.删除后继.Name = "删除后继";
            this.删除后继.Size = new System.Drawing.Size(169, 22);
            this.删除后继.Text = "删除后继(&Cut)";
            this.删除后继.Click += new System.EventHandler(this.删除后继_Click);
            // 
            // reNameBox
            // 
            this.reNameBox.AllowDrop = true;
            this.reNameBox.BackColor = System.Drawing.SystemColors.Control;
            this.reNameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.reNameBox.Location = new System.Drawing.Point(54, 55);
            this.reNameBox.Name = "reNameBox";
            this.reNameBox.Size = new System.Drawing.Size(100, 14);
            this.reNameBox.TabIndex = 1;
            this.reNameBox.TabStop = false;
            this.reNameBox.Visible = false;
            this.reNameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.reNameBox_KeyDown);
            // 
            // DependencyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.reNameBox);
            this.Name = "DependencyView";
            this.Size = new System.Drawing.Size(698, 472);
            this.Load += new System.EventHandler(this.RelationView_Load);
            this.SizeChanged += new System.EventHandler(this.DependencyView_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RelationView_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RelationView_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RelationView_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RelationView_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RelationView_MouseUp);
            this.MenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 刷新;
        private System.Windows.Forms.ToolStripMenuItem 重命名;
        private System.Windows.Forms.ToolStripMenuItem 添加技能;
        private System.Windows.Forms.ToolStripMenuItem 删除技能;
        private System.Windows.Forms.ToolStripMenuItem 学习技能;
        private System.Windows.Forms.ToolStripMenuItem 添加依赖关系;
        private System.Windows.Forms.ToolStripMenuItem 删除依赖关系;
        private System.Windows.Forms.ToolStripMenuItem 检查依赖关系;
        private System.Windows.Forms.TextBox reNameBox;
        private System.Windows.Forms.ToolStripMenuItem 添加后继;
        private System.Windows.Forms.ToolStripMenuItem 删除后继;

    }
}
