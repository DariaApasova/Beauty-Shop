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
    public partial class AddInVisit : Form
    {
        int ids;
        string b;
        public string serv;
        public string cab;
        public string wor;
        public decimal price;
        public AddInVisit(string br)
        {
            InitializeComponent();
            b = br;
            load();
        }
        private void load()
        {
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            checkBox1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
       private  void formclosing()
        {
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            checkBox1.Enabled = true;
            Dictionary<int, Cabinet> dictc = CabinetsCache.getCache();
            foreach(Cabinet cab in dictc.Values)
            {
                foreach(Service s in cab.Services.ToList())
                {
                    if(s.id==ids&&cab.branch.name==b)
                    {
                        comboBox1.Items.Add(cab.cabinet_name);
                    }
                }
            }
            Dictionary<int, Worker> dictw = WorkersCache.getCache();
            foreach(Worker w in dictw.Values)
            {
                foreach(Service s in w.Services.ToList())
                {
                    if(s.id==ids)
                    {
                        comboBox2.Items.Add(w.name);
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FormService form = new FormService("choose", 0);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
            Dictionary<int, Service> dicts = ServicesCache.getCache();
            label5.Text = dicts.FirstOrDefault(x => x.Key == form.num).Value.title;
            textBox1.Text =Convert.ToString(dicts.FirstOrDefault(x => x.Key == form.num).Value.price);
            ids = form.num;
            formclosing();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Text = Convert.ToString(Convert.ToInt16(textBox1.Text) * 0.9);
            }
            else
            {
                textBox1.Text = Convert.ToString(Convert.ToInt16(textBox1.Text) /0.9);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label5.Text != "Не выбрана" && comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1 && textBox1.Text != string.Empty)
            {
                serv = label5.Text;
                cab = Convert.ToString(comboBox1.SelectedItem);
                wor = Convert.ToString(comboBox2.SelectedItem);
                price = Convert.ToDecimal(textBox1.Text);
                Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля на форме", "Предупреждение");
            }
        }
    }
}
