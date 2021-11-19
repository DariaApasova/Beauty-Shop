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
    public partial class SeeVisit : Form
    {
        Visit visit=new Visit();
        public SeeVisit(Visit t)
        {
            InitializeComponent();
            visit = t;
            load();
        }
        private void load()
        {

            textBox1.Text = Convert.ToString(visit.id);
            textBox2.Text = visit.client.name;
            string line = Convert.ToString(visit.date_visit);
            string[] l = line.Split(' ');
            textBox3.Text = l[0];
            textBox4.Text = l[1];
            textBox5.Text = Convert.ToString(visit.duration);
            textBox6.Text = Convert.ToString(visit.price);
            using (VisitContext vc = new VisitContext())
            {
                var vis = vc.Visits.Include("Services").ToList();
                foreach(Visit v in vis)
                {
                    if(v.id==visit.id)
                    {
                        textBox7.Text = Convert.ToString(v.Services.Count());
                    }
                }
            }
                //  int n = visit.Services.Count();
               
            textBox8.Text = visit.branch.name;
            richTextBox1.Text = visit.notes;

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
