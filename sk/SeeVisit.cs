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
        Dictionary<int, Attendance> att = AttendanceCache.getCache();
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
            int count = 0;
            dataGridView1.Rows.Clear();
            int r = 0;
            foreach(Attendance a in att.Values)
            {
                if (a.visit.id == visit.id)
                {
                    count++;
                    dataGridView1[0, r].Value = a.service.title;
                    dataGridView1[1, r].Value = a.worker.name;
                    dataGridView1[2, r].Value = a.cabinet.cabinet_name;
                    dataGridView1[3, r].Value = a.price;
                    r++;
                }
            }
            textBox7.Text = Convert.ToString(count);
            textBox8.Text = visit.branch.name;
            richTextBox1.Text = visit.notes;

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
