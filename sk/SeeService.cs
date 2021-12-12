using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace sk
{
    public partial class SeeService : Form
    {
        Dictionary<int, Service> dict = ServicesCache.getCache();
        Service service1 = new Service();
        public SeeService(Service s)
        {
            InitializeComponent();
            service1= s;
            load();
        }
        private void load()
        {
            textBox1.Text = Convert.ToString(service1.id);
            textBox1.Enabled = false;
            textBox2.Text = service1.title;
            textBox2.Enabled = false;
            textBox3.Text =Convert.ToString( service1.price);
            textBox3.Enabled = false;
            textBox4.Text = Convert.ToString(service1.duration);
            textBox4.Enabled = false;
            richTextBox1.Text = service1.notes;
            richTextBox1.Enabled = false;
            textBox7.Enabled = false;
            textBox7.Text = Convert.ToString(service1.Cabinets.Count());
            textBox6.Enabled = false;
            textBox6.Text = Convert.ToString(service1.Workers.Count());
            int count = 0;
            Dictionary<int, Attendance> lst = AttendanceCache.lstWorkers();
            foreach(Attendance a in lst.Values)
            {
                if(a.service.id==service1.id)
                {
                    count++;
                }
            }
            textBox5.Enabled = false;
            textBox5.Text = Convert.ToString(count);
            if(service1.date_delete==Convert.ToDateTime("31.12.9999 12:00:00"))
            {
                label9.Visible = false;
            }
            else
            {
                label9.Text = "Услуга удалена";
                delete.Visible = false;
                change.Visible = false;
            }
        }
        private void change_CLick(object sender, EventArgs e)
        {
            AddOrChangeService form = new AddOrChangeService(service1, "change");
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormClosing += new FormClosingEventHandler(formClosing);
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormWorker form = new FormWorker("detService", service1.id);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
        void formClosing(object sender, FormClosingEventArgs e)
        {
            load();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
            service1.date_delete = Convert.ToDateTime(time);
            using (ServiceContext sc = new ServiceContext())
            {
                sc.Entry(service1).State = System.Data.Entity.EntityState.Modified;
                sc.SaveChanges();
            }
            string text = "Услуга успешно удалена.";
            string caption = "Уведомление";
            MessageBox.Show(text, caption);
        }
    }
}
