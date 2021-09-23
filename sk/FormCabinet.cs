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
    public partial class FormCabinet : Form
    {
        string check;
        public FormCabinet(string check1)
        {
            InitializeComponent();
            check = check1;
            load();
        }
        private void load()
        {
            if (check == "see")
            {
                dataGridView1.Columns[5].Visible = false;
            }
        }
    }
}
