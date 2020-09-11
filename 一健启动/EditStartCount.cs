using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 一键启动.Utils;

namespace 一键启动
{
    public partial class EditStartCount : Form
    {
        private int index;
        public int Index
        {
            get { return index; }
            set { index = value; }
        }



        public EditStartCount(string title,int count,int indexx)
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.tb_ProName.Text = title;
            this.NUD_StartCount.Value = count;
            Index = indexx;
        }

        private void EditStartCount_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            new ConfigFileAccess().EditConfig(index, tb_ProName.Text, NUD_StartCount.Value.ToString());
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
