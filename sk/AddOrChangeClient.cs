using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace sk
{
    public partial class AddOrChangeClient : Form
    {
        string check;
        Dictionary<int, Client> dict = ClientsCache.getCache();
        Client client1 = new Client();
        int curid;
        public  AddOrChangeClient(Client s, string check1)
        {
            InitializeComponent();
            client1 = s;
            curid = s.id;
            check = check1;
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
                loadClient(client1);
            }
        }
        private void loadClient(Client s)
        {
            textBox1.Text = s.name;
            if (s.notes != null)
            {
                richTextBox1.Text = s.notes;
            }
            maskedTextBox1.Text = s.phone;
        }
        private void loadNew()
        {
            textBox1.Text = "";
            richTextBox1.Text = "";
        }
        private void saveClient()
        {
            using (ClientContext sc = new ClientContext())
            {
                if (check == "add")
                {
                    Client s1 = new Client { id = curid, name = textBox1.Text, phone = maskedTextBox1.Text, notes = richTextBox1.Text, date_delete = Convert.ToDateTime("31.12.9999 12:00:00") };
                    sc.Clients.Add(s1);
                }
                if (check == "change")
                {
                    Client client = client1;
                    client1.name = textBox1.Text;
                    client1.phone =maskedTextBox1.Text;
                    client1.notes = richTextBox1.Text;
                    client1.date_delete = Convert.ToDateTime("31.12.9999 12:00:00");
                    sc.Entry(client1).State = System.Data.Entity.EntityState.Modified;
                }
                sc.SaveChanges();
                ClientsCache.updateCache();
            }
        }
        private void save_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
           maskedTextBox1.Enabled = false;
            richTextBox1.Enabled = false;
            saveClient();
            string text = "Клиент успешно сохранен.";
            string caption = "Уведомление";
            MessageBox.Show(text, caption);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
