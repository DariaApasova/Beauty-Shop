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
        int curid;
        Dictionary<int, Client> dict = ClientsCache.getCache();
        public FormClient(string check1, int idd)
        {
            InitializeComponent();
            check = check1;
            curid = idd;
            load();
        }

        private void load()
        {
            dataGridView1.ReadOnly = true;
            if (check == "see")
            {
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Rows.Clear();
                int r = 0;
                foreach (Client c in dict.Values)
                {
                    if(checkBox2.Checked)
                    {
                        load_real(c, r);
                        r++;
                    }
                    else
                    {
                        load_all(c, r);
                        r++;
                    }
                }
            }
        }
        private void checkBox2_ChechedChanged(object sender, EventArgs e)
        {
            load();
        }
        private void load_real(Client c, int r)
        {
            if(c.date_delete==Convert.ToDateTime("31.12.9999 12:00:00"))
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, r].Value = c.id;
                dataGridView1[1, r].Value = c.name;
                dataGridView1[2, r].Value = c.phone;
                dataGridView1[3, r].Value = c.notes;
            }
        }
        private void load_all(Client c, int r)
        {
            dataGridView1.Rows.Add();
            dataGridView1[0, r].Value = c.id;
            dataGridView1[1, r].Value = c.name;
            dataGridView1[2, r].Value = c.phone;
            dataGridView1[3, r].Value = c.notes;
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int t = e.RowIndex;
                var h = dataGridView1.Rows[t].Cells[0].Value;
                curid = Convert.ToInt32(h);
            }
            seeCLient();
        }
        private void seeCLient()
        {
            Client see = dict.FirstOrDefault(x => x.Key == curid).Value;
            SeeClient form = new SeeClient(see);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormClosing += new FormClosingEventHandler(formCLosing);
            form.ShowDialog();
        }
        void formCLosing(object sender, FormClosingEventArgs e)
        {
            load();
        }

        private void addNew_Click(object sender, EventArgs e)
        {
            Client newc = new Client();
            AddOrChangeClient form = new AddOrChangeClient(newc, "add");
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormClosing += new FormClosingEventHandler(formCLosing);
            form.ShowDialog();
        }
    }
}
