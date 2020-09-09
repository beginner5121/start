using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 一健启动
{
    public partial class EditStartCount : Form
    {
        public EditStartCount(string title,int count)
        {
            InitializeComponent();
            this.Name = title;
            this.NumShow.Value = count;
        }
    }
}
