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
    public partial class FormClient : Form
    {
        string check;
        Dictionary<int, Client> dict = ClientsCache.getCache();
        public FormClient(string check1)
        {
            InitializeComponent();
            check = check1;
            load();
        }

        private void load()
        {
            if(check=="see")
            {
                dataGridView1.Columns[4].Visible = false;
            }
            dataGridView1.Rows.Clear();
                int r = 0;
                foreach(Client c in dict.Values)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1[0, r].Value = c.id;
                    dataGridView1[1, r].Value = c.name;
                    dataGridView1[2, r].Value = c.phone;
                    dataGridView1[3, r].Value = c.notes;
                    r++;
                }
            }
    }
}
