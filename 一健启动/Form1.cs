using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using 一键启动.Utils;

namespace 一键启动
{
    public partial class Form1 : Form
    {

        private void InitListView()
        {
            this.listView.CheckBoxes = true;
            this.listView.Columns.Add("程序名", 80, HorizontalAlignment.Center);
            this.listView.Columns.Add("启动次数", 93, HorizontalAlignment.Center);
            this.listView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            GetStarPrograms();
        }

        private void GetStarPrograms()
        {
            this.listView.Items.Clear();
            this.listView.BeginUpdate();

            List<ProgramModel> pms = new ConfigFileAccess().readConfig();
            pms.ForEach(pm =>
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = pm.FileName;
                lvi.SubItems.Add(pm.Count);
                this.listView.Items.Add(lvi);
            });
            this.listView.EndUpdate();
        }

        public Form1()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.MaximizeBox = false;
            InitListView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "可执行文件(*.exe)|*.exe";
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPrograms_Click(object sender, EventArgs e)
        {

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string FilePath = openFileDialog.FileName;
                string FileName = System.IO.Path.GetFileNameWithoutExtension(FilePath);
                //写入到XML需要传输文件名、启动次数(默认:1)、文件目录
                if (new ConfigFileAccess().WriteStartPath(FileName, FilePath))
                {
                    GetStarPrograms();
                    MessageBox.Show("添加成功!");
                }
                else
                {
                    MessageBox.Show("添加失败!");
                }
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeletePrograms_Click(object sender, EventArgs e)
        {
            if (listView.CheckedItems.Count > 0)
            {

                if (MessageBox.Show("确定删除" + listView.CheckedItems.Count + "项?", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    List<int> indexs = new List<int>();
                    foreach (int index in listView.CheckedIndices)
                    {
                        indexs.Add(index);
                    }
                    indexs.Reverse();
                    foreach (int i in indexs)
                    {
                        new ConfigFileAccess().DeleteNode(i);
                    }
                    CheckAll.Checked = false;
                    GetStarPrograms();

                }
            }
            else
            {
                try
                {
                    int tryy = listView.SelectedIndices[0];
                    if (MessageBox.Show("确定删除你的选择?", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        new ConfigFileAccess().DeleteNode(listView.SelectedIndices[0]);
                        GetStarPrograms();
                    }
                }
                catch
                {
                    MessageBox.Show("请点击或者勾选要删除的程序!", "一键启动");

                }

            }
        }


        /// <summary>
        /// listview双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_DoubleClick(object sender, EventArgs e)
        {
            string FileName = listView.SelectedItems[0].Text;
            int count = int.Parse(listView.SelectedItems[0].SubItems[1].Text);
            int index = listView.SelectedIndices[0];
            EditStartCount ed = new EditStartCount(FileName, count, index);
            if (ed.ShowDialog() == DialogResult.OK)
            {
                GetStarPrograms();
            }

        }

        private void CheckAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView.Items)
            {
                item.Checked = (sender as CheckBox).Checked;
            }
        }

        private void btn_StartProgram_Click(object sender, EventArgs e)
        {
            if (listView.CheckedItems.Count > 0)
            {
                foreach (int index in listView.CheckedIndices)
                {
                    new ConfigFileAccess().StarApp(index, listView.Items[index].SubItems[1].Text);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("请勾选要启动的程序!", "一键启动");
            }

        }
    }
}
