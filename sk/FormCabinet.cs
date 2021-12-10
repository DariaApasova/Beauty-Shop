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
    public partial class FormCabinet : Form
    {

        string check = "";
        int id;
        Dictionary<int, Cabinet> dict = CabinetsCache.getCache();
        public FormCabinet(string check1, int idd)
        {
            InitializeComponent();
            check = check1;
            id = idd;
            load();
        }
        private void checkBox2_ChechedChanged(object sender, EventArgs e)
        {
            load();
        }
        private void load()
        {
            dataGridView1.ReadOnly = true;
            if (check == "see")
            {
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Rows.Clear();
                int r = 0;
                foreach (Cabinet c in dict.Values)
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
            if(check=="detBranch")
            {
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Rows.Clear();
                int r = 0;
                Dictionary<int,Branch > dictb= BranchCache.getCache();
                foreach (Branch b in dictb.Values)
                {
                    if(b.id==id)
                    {
                        foreach (Cabinet c in b.Cabinets.ToList())
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
               
            }
        }
        private void load_real(Cabinet c, int r)
        {
            if(c.date_delete==Convert.ToDateTime("31.12.9999 12:00:00"))
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, r].Value = c.id;
                dataGridView1[1, r].Value = c.cabinet_name;
                dataGridView1[2, r].Value = c.capacity;
                dataGridView1[3, r].Value = c.notes;
                dataGridView1[4, r].Value = c.branch.name;
            }
        }
        private void load_all(Cabinet c, int r)
        {
            dataGridView1.Rows.Add();
            dataGridView1[0, r].Value = c.id;
            dataGridView1[1, r].Value = c.cabinet_name;
            dataGridView1[2, r].Value = c.capacity;
            dataGridView1[3, r].Value = c.notes;
            dataGridView1[4, r].Value = c.branch.name;
        }
        private void choice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex!=-1)
            {
                int t = e.RowIndex;
                var h = dataGridView1.Rows[t].Cells[0].Value;
                id = Convert.ToInt16(h);
                seeCabinet();
            }
        }
        private void seeCabinet()
        {
            Cabinet see =dict.FirstOrDefault(t => t.Key == id).Value;
            SeeCabinet form = new SeeCabinet(see);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormClosing += new FormClosingEventHandler(formClosing);
            form.ShowDialog();

        }

        private void addNew_Click(object sender, EventArgs e)
        {
            Cabinet newc = new Cabinet();
            AddOrChangeCabinet form = new AddOrChangeCabinet(newc, "add");
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormClosing += new FormClosingEventHandler(formClosing);
            form.ShowDialog();
        }
        void formClosing(object sender, FormClosingEventArgs E)
        {
            load();
        }
    }
}
