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
    public partial class AddOrChangeWorker : Form
    {
        string check;
        Dictionary<int, Worker> dict = WorkersCache.getCache();
        Worker w1 = new Worker();
        int curid;
        public AddOrChangeWorker(Worker w, string d)
        {
            InitializeComponent();
            w1 = w;
            curid = w.id;
            check = d;
            load();
        }
        private void load()
        {
            if (check == "add")
            {
                loadNew();
            }
            if (check == "change")
            {
                loadWorker(w1);
            }
        }
        private void loadWorker(Worker s)
        {
            textBox2.Text = s.name;
            if (s.notes != null)
            {
                richTextBox1.Text = s.notes;
            }
            maskedTextBox1.Text = s.phone;
            textBox1.Text = s.position;
        }
        private void loadNew()
        {
            textBox2.Text = "";
            textBox1.Text = "";
            richTextBox1.Text = "";
        }
        private void saveWorker()
        {
            using (WorkerContext sc = new WorkerContext())
            {
                if (check == "add")
                {
                    Worker s1 = new Worker { id = curid, name = textBox2.Text, phone = maskedTextBox1.Text, notes = richTextBox1.Text, position=textBox1.Text, date_delete = Convert.ToDateTime("31.12.9999 12:00:00") };
                    sc.Workers.Add(s1);
                }
                if (check == "change")
                {
                    Worker worker= w1;
                    w1.name = textBox2.Text;
                    w1.phone = maskedTextBox1.Text;
                    w1.notes = richTextBox1.Text;
                    w1.date_delete = Convert.ToDateTime("31.12.9999 12:00:00");
                    w1.position = textBox1.Text;
                    sc.Entry(w1).State = System.Data.Entity.EntityState.Modified;
                }
                sc.SaveChanges();
                WorkersCache.updateCache();
            }
        }
        private void save_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            maskedTextBox1.Enabled = false;
            richTextBox1.Enabled = false;
            saveWorker();
            string text = "Работник успешно сохранен.";
            string caption = "Уведомление";
            MessageBox.Show(text, caption);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
