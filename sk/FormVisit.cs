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
        Client c;
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
                int r = 0;
                var visits = vc.Visits.Include("Client").ToList();
                    foreach (var v in visits)
                    {

                        dataGridView2.Rows.Add();
                        dataGridView2[0, r].Value = v.id;
                        dataGridView2[1, r].Value = v.client.name;
                        dataGridView2[3, r].Value = v.date_visit;
                        dataGridView2[4, r].Value = v.duration;
                        dataGridView2[5, r].Value = v.price;
                        dataGridView2[6, r].Value = v.notes;
                        r++;
                }
            }
        }
    }
}
