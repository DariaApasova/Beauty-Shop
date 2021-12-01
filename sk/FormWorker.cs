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
    public partial class FormWorker : Form
    {
        string check;
        int curid;
        Dictionary<int, Worker> dict = WorkersCache.getCache();
        public FormWorker(string check1, int id)
        {
            InitializeComponent();
            check = check1;
            curid = id;
            load();
        }
        private void load()
        {
            if(check=="see")
            {
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Rows.Clear();
                int r = 0;
                foreach (Worker w in dict.Values)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1[0, r].Value = w.id;
                    dataGridView1[1, r].Value = w.name;
                    dataGridView1[2, r].Value = w.phone;
                    dataGridView1[3, r].Value = w.position;
                    dataGridView1[4, r].Value = w.notes;
                    r++;
                }
            }
            if(check=="detService")
            {
                Dictionary<int, Service> lst = ServicesCache.getCache();
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Rows.Clear();
                int r = 0;
                foreach(Service s in lst.Values)
                {
                    if (s.id == curid)
                    {
                        foreach(Worker w in s.Workers.ToList())
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1[0, r].Value = w.id;
                            dataGridView1[1, r].Value = w.name;
                            dataGridView1[2, r].Value = w.phone;
                            dataGridView1[3, r].Value = w.position;
                            dataGridView1[4, r].Value = w.notes;
                            r++;
                        }
                    }
                }
            }
               
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int t = e.RowIndex;
                var h = dataGridView1.Rows[t].Cells[0].Value;
                curid = Convert.ToInt32(h);
            }
            Worker see = dict[curid];
            SeeWorker form = new SeeWorker(see);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();

        }
    }
}
