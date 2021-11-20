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
    public partial class SeeClient : Form
    {
        Dictionary<int, Client> dict = ClientsCache.getCache();
        Client client1 = new Client();
        public SeeClient(Client s)
        {
            InitializeComponent();
            client1 = s;
            load();
        }
        private void load()
        {
            textBox1.Text = Convert.ToString(client1.id);
            textBox1.Enabled = false;
            textBox2.Text = client1.name;
            textBox2.Enabled = false;
            textBox3.Text = Convert.ToString(client1.phone);
            textBox3.Enabled = false;
            richTextBox1.Text = client1.notes;
            richTextBox1.Enabled = false;
            textBox4.Enabled = false;
            
        }
        private void change_CLick(object sender, EventArgs e)
        {
            AddOrChangeClient form = new AddOrChangeClient(client1, "change");
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
    }
}
