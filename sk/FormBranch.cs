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
        int idChange;
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
                if (checkBox2.Checked)
                {
                    load_real(b, r);
                    r++;
                }
                else
                {
                    load_all(b, r);
                    r++;
                }
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            load();
        }
        private void load_real(Branch b, int r)
        {
            if (b.date_delete == Convert.ToDateTime("31.12.9999 12:00:00"))
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, r].Value = b.id;
                dataGridView1[1, r].Value = b.timetable.id;
                dataGridView1[2, r].Value = b.name;
                dataGridView1[3, r].Value = b.address;
            }
        }
        private void load_all(Branch b, int r)
        {
            dataGridView1.Rows.Add();
            dataGridView1[0, r].Value = b.id;
            dataGridView1[1, r].Value = b.timetable.id;
            dataGridView1[2, r].Value = b.name;
            dataGridView1[3, r].Value = b.address;
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
        private void choice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int t = e.RowIndex;
                var h = dataGridView1.Rows[t].Cells[0].Value;
                idChange = Convert.ToInt16(h);
                seeCabinet();
            }
        }
        private void seeCabinet()
        {
            Branch see = dict.FirstOrDefault(t => t.Key == idChange).Value;
            SeeBranch form = new SeeBranch(see);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();

        }
    }
}
