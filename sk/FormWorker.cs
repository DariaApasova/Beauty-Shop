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
        public FormWorker(string check1)
        {
            InitializeComponent();
            check = check1;
            load();
        }
        private void load()
        {
            if(check=="see")
            {
                dataGridView1.Columns[5].Visible = false;
            }
            using (WorkerContext wc = new WorkerContext())
            {
                dataGridView1.Rows.Clear();
                var workers = wc.Workers;
                int r = 0;
                foreach(Worker w in workers)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1[0,r].Value = w.id;
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
