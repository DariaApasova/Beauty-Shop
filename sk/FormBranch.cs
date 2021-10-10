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
        Dictionary<int, Branch> dict = BranchCache.getCache();
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
            dataGridView1.Rows.Clear();
            int r = 0;
            foreach(Branch b in dict.Values)
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, r].Value = b.id;
                dataGridView1[1, r].Value = b.timetable.id;
                dataGridView1[2, r].Value = b.name;
                dataGridView1[3, r].Value = b.address;
                r++;
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
