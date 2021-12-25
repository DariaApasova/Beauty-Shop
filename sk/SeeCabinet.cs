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
            Dictionary<int, Attendance> lst = AttendanceCache.getCache();
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
            if (c.date_delete == Convert.ToDateTime("31.12.9999 12:00:00"))
            {
                label8.Visible = false;
            }
            else
            {
                label8.Text = "Кабинет удален";
                button3.Visible = false;
                button2.Visible = false;
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
            c.date_delete = Convert.ToDateTime(time);
            using (CabinetsContext sc = new CabinetsContext())
            {
                sc.Entry(c).State = System.Data.Entity.EntityState.Modified;
                sc.SaveChanges();
            }
            string text = "Кабинет успешно удален.";
            string caption = "Уведомление";
            MessageBox.Show(text, caption);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddOrChangeCabinet form = new AddOrChangeCabinet(c, "change");
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormClosing += new FormClosingEventHandler(formclosing);
            form.ShowDialog();
        }
        void formclosing(object sender, FormClosingEventArgs e)
        {
            load();
        }
    }
}
