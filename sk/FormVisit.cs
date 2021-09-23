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
    public partial class FormVisit : Form
    {
        string check;
        public FormVisit(string check1)
        {
            InitializeComponent();
            check = check1;
            load();
        }
        private void load()
        {
            if(check=="see")
            {
                dataGridView2.Columns[7].Visible = false;
            }
            using (VisitContext vc = new VisitContext())
            {
                dataGridView2.Rows.Clear();
                var visits = vc.Visits;
                int r = 0;
                foreach(Visit v in visits)
                {
                   /* dataGridView2.Rows.Add();
                    dataGridView2[0, r].Value = v.id;
                    dataGridView2[1,r].Value=v.*/
                }
            }
        }
    }
}
