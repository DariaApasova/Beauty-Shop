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
    public partial class FormService : Form
    {
        string check;
        Service s;
        ServicesCache services;
        int curid;
        public FormService(string check1, ServicesCache s)
        {
            InitializeComponent();
            check = check1;
            services = s;
            load();
        }
        private void load()
        {
            if (check == "see")
            {
                dataGridView1.Columns[5].Visible = false;
            }
            dataGridView1.Rows.Clear();
            int r = 0;
            foreach (Service s in services.getCache().Values)
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, r].Value = s.id;
                dataGridView1[1, r].Value = s.title;
                dataGridView1[2, r].Value = s.price;
                dataGridView1[3, r].Value = s.duration;
                dataGridView1[4, r].Value = s.notes;
                r++;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int t = e.RowIndex;
                var h = dataGridView1.Rows[t].Cells[0].Value;
                curid = Convert.ToInt32(h);
            }
            Service see = services.getService(curid);
            SeeService form = new SeeService(see, services);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormClosing += new FormClosingEventHandler(formCLosed);
            form.ShowDialog();
           
        }
        private void newService_CLick(object sender, EventArgs e)
        {
            curid = services.getMaxID() + 1;
            Service serv = new Service(Convert.ToInt32(curid));
            serv.id = curid;
            services.addService(serv);
            AddOrChangeService form = new AddOrChangeService(serv, services, "add");
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormClosing+=new FormClosingEventHandler(formCLosed);
            form.ShowDialog();
        }
        void formCLosed(object sender, FormClosingEventArgs e)
        {
            load();
        }
    }
}
