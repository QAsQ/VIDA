namespace RS
{
    partial class mainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            RS.ColorScheme colorScheme1 = new RS.ColorScheme();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.openfile = new System.Windows.Forms.OpenFileDialog();
            this.savefile = new System.Windows.Forms.SaveFileDialog();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.管理模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.学习模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.状态修改 = new System.Windows.Forms.ToolStripMenuItem();
            this.获取状态码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改状态ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置 = new System.Windows.Forms.ToolStripMenuItem();
            this.配色方案 = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑颜色 = new System.Windows.Forms.ToolStripMenuItem();
            this.从文件读取 = new System.Windows.Forms.ToolStripMenuItem();
            this.保存到文件 = new System.Windows.Forms.ToolStripMenuItem();
            this.MainDV = new RS.MainDependencyView();
            this.openScheme = new System.Windows.Forms.OpenFileDialog();
            this.saveScheme = new System.Windows.Forms.SaveFileDialog();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // openfile
            // 
            this.openfile.Filter = "DMA文件(*.dma)|*.dma";
            // 
            // savefile
            // 
            this.savefile.Filter = "DMA文件(*.dma)|*.dma";
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.模式ToolStripMenuItem,
            this.状态修改,
            this.设置});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(810, 25);
            this.menu.TabIndex = 4;
            this.menu.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.新建ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.新建ToolStripMenuItem.Text = "新建";
            // 
            // 模式ToolStripMenuItem
            // 
            this.模式ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.管理模式ToolStripMenuItem,
            this.学习模式ToolStripMenuItem});
            this.模式ToolStripMenuItem.Name = "模式ToolStripMenuItem";
            this.模式ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.模式ToolStripMenuItem.Text = "模式";
            // 
            // 管理模式ToolStripMenuItem
            // 
            this.管理模式ToolStripMenuItem.Name = "管理模式ToolStripMenuItem";
            this.管理模式ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.管理模式ToolStripMenuItem.Text = "编辑模式";
            this.管理模式ToolStripMenuItem.Click += new System.EventHandler(this.管理模式ToolStripMenuItem_Click);
            // 
            // 学习模式ToolStripMenuItem
            // 
            this.学习模式ToolStripMenuItem.Name = "学习模式ToolStripMenuItem";
            this.学习模式ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.学习模式ToolStripMenuItem.Text = "学习模式";
            this.学习模式ToolStripMenuItem.Click += new System.EventHandler(this.学习模式ToolStripMenuItem_Click);
            // 
            // 状态修改
            // 
            this.状态修改.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.获取状态码ToolStripMenuItem,
            this.修改状态ToolStripMenuItem});
            this.状态修改.Name = "状态修改";
            this.状态修改.Size = new System.Drawing.Size(44, 21);
            this.状态修改.Text = "进度";
            // 
            // 获取状态码ToolStripMenuItem
            // 
            this.获取状态码ToolStripMenuItem.Name = "获取状态码ToolStripMenuItem";
            this.获取状态码ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.获取状态码ToolStripMenuItem.Text = "获取进度码";
            this.获取状态码ToolStripMenuItem.Click += new System.EventHandler(this.获取状态码ToolStripMenuItem_Click);
            // 
            // 修改状态ToolStripMenuItem
            // 
            this.修改状态ToolStripMenuItem.Name = "修改状态ToolStripMenuItem";
            this.修改状态ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.修改状态ToolStripMenuItem.Text = "修改进度";
            this.修改状态ToolStripMenuItem.Click += new System.EventHandler(this.修改状态ToolStripMenuItem_Click);
            // 
            // 设置
            // 
            this.设置.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.配色方案});
            this.设置.Name = "设置";
            this.设置.Size = new System.Drawing.Size(44, 21);
            this.设置.Text = "设置";
            // 
            // 配色方案
            // 
            this.配色方案.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编辑颜色,
            this.从文件读取,
            this.保存到文件});
            this.配色方案.Name = "配色方案";
            this.配色方案.Size = new System.Drawing.Size(124, 22);
            this.配色方案.Text = "配色方案";
            // 
            // 编辑颜色
            // 
            this.编辑颜色.Name = "编辑颜色";
            this.编辑颜色.Size = new System.Drawing.Size(136, 22);
            this.编辑颜色.Text = "编辑颜色";
            this.编辑颜色.Click += new System.EventHandler(this.编辑颜色_Click);
            // 
            // 从文件读取
            // 
            this.从文件读取.Name = "从文件读取";
            this.从文件读取.Size = new System.Drawing.Size(136, 22);
            this.从文件读取.Text = "从文件读取";
            this.从文件读取.Click += new System.EventHandler(this.从文件读取_Click);
            // 
            // 保存到文件
            // 
            this.保存到文件.Name = "保存到文件";
            this.保存到文件.Size = new System.Drawing.Size(136, 22);
            this.保存到文件.Text = "保存到文件";
            this.保存到文件.Click += new System.EventHandler(this.保存到文件_Click);
            // 
            // MainDV
            // 
            this.MainDV.AutoSize = true;
            this.MainDV.BackColor = System.Drawing.SystemColors.Control;
            this.MainDV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainDV.Location = new System.Drawing.Point(0, 25);
            this.MainDV.Name = "MainDV";
            this.MainDV.Size = new System.Drawing.Size(810, 464);
            this.MainDV.size_circle = 50;
            this.MainDV.TabIndex = 3;
            this.MainDV.Load += new System.EventHandler(this.MainDV_Load);
            // 
            // openScheme
            // 
            this.openScheme.Filter = "VDAS文件(*.vdas)|*.vdas";
            // 
            // saveScheme
            // 
            this.saveScheme.Filter = "VDAS文件(*.vdas)|*.vdas";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(810, 489);
            this.Controls.Add(this.MainDV);
            this.Controls.Add(this.menu);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "mainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            this.LocationChanged += new System.EventHandler(this.mainForm_LocationChanged);
            this.Resize += new System.EventHandler(this.mainForm_Resize);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MainDependencyView MainDV;
        private System.Windows.Forms.OpenFileDialog openfile;
        private System.Windows.Forms.SaveFileDialog savefile;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 管理模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 学习模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 状态修改;
        private System.Windows.Forms.ToolStripMenuItem 获取状态码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改状态ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置;
        private System.Windows.Forms.ToolStripMenuItem 配色方案;
        private System.Windows.Forms.ToolStripMenuItem 编辑颜色;
        private System.Windows.Forms.ToolStripMenuItem 从文件读取;
        private System.Windows.Forms.ToolStripMenuItem 保存到文件;
        private System.Windows.Forms.OpenFileDialog openScheme;
        private System.Windows.Forms.SaveFileDialog saveScheme;
    }
}

