namespace 一健启动
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.AddPrograms = new System.Windows.Forms.ToolStripMenuItem();
            this.DeletePrograms = new System.Windows.Forms.ToolStripMenuItem();
            this.listView = new System.Windows.Forms.ListView();
            this.CheckAll = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddPrograms,
            this.DeletePrograms});
            this.menuStrip.Location = new System.Drawing.Point(10, 3);
            this.menuStrip.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(194, 28);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "菜单栏";
            // 
            // AddPrograms
            // 
            this.AddPrograms.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.AddPrograms.Name = "AddPrograms";
            this.AddPrograms.Size = new System.Drawing.Size(51, 24);
            this.AddPrograms.Text = "添加";
            this.AddPrograms.Click += new System.EventHandler(this.AddPrograms_Click);
            // 
            // DeletePrograms
            // 
            this.DeletePrograms.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.DeletePrograms.Name = "DeletePrograms";
            this.DeletePrograms.Size = new System.Drawing.Size(51, 24);
            this.DeletePrograms.Text = "删除";
            this.DeletePrograms.Click += new System.EventHandler(this.DeletePrograms_Click);
            // 
            // listView
            // 
            this.listView.Dock = System.Windows.Forms.DockStyle.Top;
            this.listView.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(10, 31);
            this.listView.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(194, 184);
            this.listView.TabIndex = 2;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            // 
            // CheckAll
            // 
            this.CheckAll.AutoSize = true;
            this.CheckAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.CheckAll.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CheckAll.Location = new System.Drawing.Point(10, 215);
            this.CheckAll.Name = "CheckAll";
            this.CheckAll.Size = new System.Drawing.Size(194, 28);
            this.CheckAll.TabIndex = 4;
            this.CheckAll.Text = "全选/全不选";
            this.CheckAll.UseVisualStyleBackColor = true;
            this.CheckAll.CheckedChanged += new System.EventHandler(this.CheckAll_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.button1.Location = new System.Drawing.Point(10, 243);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 54);
            this.button1.TabIndex = 5;
            this.button1.Text = "一键启动";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 307);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CheckAll);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10, 3, 10, 10);
            this.Text = "Form1";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem AddPrograms;
        private System.Windows.Forms.ToolStripMenuItem DeletePrograms;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.CheckBox CheckAll;
        private System.Windows.Forms.Button button1;
    }
}

