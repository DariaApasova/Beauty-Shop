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
        string check;
        public FormTTB(string check1)
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
            using (TTBContext timetableb = new TTBContext())
            {
                dataGridView2.Rows.Clear();
                var ttb = timetableb.TTBs;
                int r = 0;
                foreach(TimetableBranch t in ttb)
                {
                    dataGridView2.Rows.Add();
                    dataGridView2[0, r].Value = t.id;
                    dataGridView2[2, r].Value = t.beginning;
                    dataGridView2[3, r].Value = t.start;
                    dataGridView2[4, r].Value = t.end;
                    dataGridView2[5, r].Value = t.ending;
                    r++;
                }
            }
        }
    }
}
