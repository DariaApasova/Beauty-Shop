using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sk
{
    public partial class FormTTW : Form
    {
        string check;
        public FormTTW(string check1)
        {
            InitializeComponent();
            check = check1;
            load();
        }
        private void load()
        {
            if(check=="see")
            {
                dataGridView2.Columns[6].Visible = false;
            }
        }
    }
}
