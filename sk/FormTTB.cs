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
    public partial class FormTTB : Form
    {
        public int num;
        string check;
        int curid;
        Dictionary<int, TimetableBranch> dict = TimetableBranchCache.getCache();
        public FormTTB(string check1)
        {
            InitializeComponent();
            check = check1;
            load();
        }
        private void load()
        {
            dataGridView2.Rows.Clear();
            if(check=="see")
            {
                dataGridView2.Columns[6].Visible = false;
                dataGridView2.Columns[7].Visible = true;
            }
            if(check=="choose")
            {
                dataGridView2.Columns[6].Visible = true;
                dataGridView2.Columns[7].Visible = false;
            }
            int r = 0;
            foreach (TimetableBranch t in dict.Values)
                {
                    if(checkBox2.Checked)
                    {
                        load_real(t, r);
                        r++;
                    }
                    else
                    {
                        load_all(t, r);
                        r++;
                    }
                }
        }
        private void load_real(TimetableBranch t, int r)
        {
            if(t.date_delete==Convert.ToDateTime("31.12.9999 12:00:00"))
            {
                int count = 0;
                Dictionary<int, Branch> d = BranchCache.getCache();
                foreach (Branch w in d.Values)
                {
                    if (w.timetable.id == t.id)
                    {
                        count++;
                    }
                }
                dataGridView2.Rows.Add();
                dataGridView2[0, r].Value = t.id;
                dataGridView2[1, r].Value = count;
                dataGridView2[2, r].Value = t.beginning;
                dataGridView2[3, r].Value = t.start;
                dataGridView2[4, r].Value = t.end;
                dataGridView2[5, r].Value = t.ending;
            }
        }
        private void load_all(TimetableBranch t, int r)
        {
            int count = 0;
            Dictionary<int, Branch> d = BranchCache.getCache();
            foreach (Branch w in d.Values)
            {
                if (w.timetable.id == t.id)
                {
                    count++;
                }
            }
            dataGridView2.Rows.Add();
            dataGridView2[0, r].Value = t.id;
            dataGridView2[1, r].Value = count;
            dataGridView2[2, r].Value = t.beginning;
            dataGridView2[3, r].Value = t.start;
            dataGridView2[4, r].Value = t.end;
            dataGridView2[5, r].Value = t.ending;
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==6)
            {
                int t = e.RowIndex;
                var n =dataGridView2.Rows[t].Cells[0].Value;
                num = Convert.ToInt16(n);
                Close();
            }
            if(e.ColumnIndex==7)
            {
                int t = e.RowIndex;
                var n = dataGridView2.Rows[t].Cells[0].Value;
                TimetableBranch l = dict.FirstOrDefault(x => x.Key ==Convert.ToInt16(n)).Value;
                AddOrChangeTTB form = new AddOrChangeTTB(l, "change");
                form.StartPosition = FormStartPosition.CenterScreen;
                form.FormClosing += new FormClosingEventHandler(formclosing);
                form.ShowDialog();
            }
        }
        void formclosing(object sender, FormClosingEventArgs e)
        {
            load();
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            load();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TimetableBranch t = new TimetableBranch();
            AddOrChangeTTB form = new AddOrChangeTTB(t, "add");
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormClosing += new FormClosingEventHandler(formclosing);
            form.ShowDialog();
        }
    }
}
