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

namespace 一健启动
{
    public partial class Form1 : Form
    {

        private void InitListView()
        {
            this.listView.CheckBoxes = true;
            this.listView.Columns.Add("程序名",80,HorizontalAlignment.Center);
            this.listView.Columns.Add("启动次数",93,HorizontalAlignment.Center);
            this.listView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            this.listView.BeginUpdate();
            for(int i = 0; i < 20; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text =  "程序" + i;
                lvi.SubItems.Add(i.ToString());
                this.listView.Items.Add(lvi);
            }
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

        private void AddPrograms_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void DeletePrograms_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("确定删除?","删除启动程序",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                listView.Items.Remove(listView.SelectedItems[0]);
            }
        }


        private void listView_DoubleClick(object sender, EventArgs e)
        {
            new EditStartCount(listView.SelectedItems[0].Text, int.Parse(listView.SelectedItems[0].SubItems[1].Text)).ShowDialog();
        }

        private void CheckAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach(ListViewItem item in listView.Items)
            {
                item.Checked = (sender as CheckBox).Checked;
            }
        }
    }
}
