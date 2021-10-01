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
                fillNewService();
            }
            if (check == "change")
            {
                if (client1.date_delete != Convert.ToDateTime("31.12.9999 12:00:00"))
                {
                    MessageBox.Show("Вы не можете изменить удаленную услугу");
                    this.Close();
                }
                else
                {
                    loadClient(client1);
                }
            }
        }
        private void loadClient(Client s)
        {
            textBox1.Text = s.name;
            if (s.notes != null)
            {
                richTextBox1.Text = s.notes;
            }
            textBox2.Text = Convert.ToString(s.phone);
        }
        private void fillNewService()
        {
           /* save.Enabled = true;
            title.Text = "";
            notes.Text = "";
            duration.Text = "";
            price.Text = "";*/
        }
        private void saveClient()
        {
            Client client = client1;
            client1.name = textBox1.Text;
            client1.phone = textBox2.Text;
            client1.notes = richTextBox1.Text;
            client1.date_delete = Convert.ToDateTime("31.12.9999 12:00:00");
            using (ClientContext sc = new ClientContext())
            {
                Client s1 = new Client { id = curid, phone=textBox2.Text, notes=richTextBox1.Text, date_delete = Convert.ToDateTime("31.12.9999 12:00:00") };
                if (check == "add")
                {
                    sc.Clients.Add(s1);
                }
                if (check == "change")
                {
                    sc.Entry(client1).State = System.Data.Entity.EntityState.Modified;
                }
                sc.SaveChanges();

            }
        }
        private void save_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            richTextBox1.Enabled = false;
            saveClient();
            string text = "Услуга успешно сохранена.";
            string caption = "Уведомление";
            MessageBox.Show(text, caption);


        }
    }
}
