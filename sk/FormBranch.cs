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
    public partial class FormBranch : Form
    {
        string check;
        public FormBranch(string check1)
        {
            InitializeComponent();
            check = check1;
            load();
        }
        private void load()
        {
            if (check=="see")
            {
                dataGridView1.Columns[4].Visible = false;
            }
        }
        private void select_ttb_Click(object sender, EventArgs e)
        {
            FormTTB form = new FormTTB("select");
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
        private void addNew_Click(object sender, EventArgs e)
        {
            AddOrChangeBranch form = new AddOrChangeBranch();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
    }
}
