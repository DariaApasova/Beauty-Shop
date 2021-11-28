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
    public partial class SeeCabinet : Form
    {
        Cabinet c = new Cabinet();
        Dictionary<int, Cabinet> dict = CabinetsCache.getCache();
        public SeeCabinet(Cabinet c1)
        {
            InitializeComponent();
            c = c1;
            load();
        }
        private void load()
        {
            textBox1.Text = Convert.ToString(c.id);
            textBox1.Enabled = false;
            textBox2.Text = c.cabinet_name;
            textBox2.Enabled = false;
            textBox3.Text = Convert.ToString(c.capacity);
            textBox3.Enabled = false;
            textBox4.Text = c.branch.name;
            textBox4.Enabled = false;
            richTextBox1.Text = c.notes;
            richTextBox1.Enabled = false;
            textBox6.Enabled = false;
            Dictionary<int, Attendance> lst = AttendanceCache.lstWorkers();
            int count = 0;
            foreach(Attendance a in lst.Values)
            {
                if(a.cabinet.id==c.id)
                {
                    count++;
                }
            }
            textBox6.Text = Convert.ToString(count);
            textBox5.Enabled = false;
            textBox5.Text = Convert.ToString(c.Services.Count);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormVisit form = new FormVisit("detCabinet", c.id);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormService form = new FormService("detCabinet", c.id);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
    }
}
