using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

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
                dataGridView2.Columns[5].Visible = false;
            }
            using (TTWContext ttwc = new TTWContext())
            {
                dataGridView2.Rows.Clear();
                int r = 0;
                var ttw = ttwc.TTWs.Include("Branch").Include("Worker").ToList();
                foreach(var t in ttw)
                {
                    dataGridView2.Rows.Add();
                    dataGridView2[0, r].Value = t.id;
                    dataGridView2[1, r].Value = t.opening;
                    dataGridView2[2, r].Value = t.closing;
                    dataGridView2[3, r].Value = t.branch.name;
                    dataGridView2[4, r].Value = t.worker.name;
                    r++;

                }
            }
        }
    }
}
