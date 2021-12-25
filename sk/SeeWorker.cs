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
    public partial class SeeWorker : Form
    {
        Dictionary<int, Attendance> att = AttendanceCache.getCache();
        Dictionary<int, Worker> dict = WorkersCache.getCache();
        Worker w = new Worker();
        public SeeWorker(Worker wor)
        {
            InitializeComponent();
            w = wor;
            load();
        }
        private void load()
        {
            textBox4.Enabled = false;
            textBox4.Text = Convert.ToString(w.id);
            textBox1.Enabled = false;
            textBox1.Text = w.phone;
            richTextBox1.Text = w.notes;
            richTextBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox2.Text = w.name;
            textBox3.Enabled = false;
            textBox3.Text = w.position;
            textBox5.Enabled = false;
            textBox5.Text =Convert.ToString(w.Services.Count());
            textBox6.Enabled = false;
            int count =0;
            foreach(Attendance a in att.Values)
            {
                if(a.worker.id==w.id)
                {
                    count++;
                }
            }
            textBox6.Enabled = false;
            textBox6.Text = Convert.ToString(count);


        }
        void formCLosing(object sender, FormClosingEventArgs e)
        {
            load();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FormVisit form = new FormVisit("detWorker", w.id);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormService form = new FormService("detWorker",w.id);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddOrChangeWorker form = new AddOrChangeWorker(w, "change");
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormClosing += new FormClosingEventHandler(formCLosing);
            form.ShowDialog();
        }
    }
}
