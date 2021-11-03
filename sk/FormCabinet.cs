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
        string check;
        int idChange;
        Dictionary<int, Cabinet> dict = CabinetsCache.getCache();
        public FormCabinet(string check1)
        {
            InitializeComponent();
            check = check1;
            load();
        }
        private void load()
        {
            dataGridView1.ReadOnly = true;
            if (check == "see")
            {
                dataGridView1.Columns[5].Visible = false;
            }
            dataGridView1.Rows.Clear();
            int r = 0;
            foreach(Cabinet c in dict.Values)
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, r].Value = c.id;
                dataGridView1[1, r].Value = c.cabinet_name;
                dataGridView1[2, r].Value = c.capacity;
                dataGridView1[3, r].Value = c.notes;
                dataGridView1[4, r].Value = c.branch.name;
                r++;
            }
        }
        private void choice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex!=-1)
            {
                int t = e.RowIndex;
                var h = dataGridView1.Rows[t].Cells[0].Value;
                idChange = Convert.ToInt16(h);
                seeCabinet();
            }
        }
        private void seeCabinet()
        {
            Cabinet see =dict.FirstOrDefault(t => t.Key == idChange).Value;
            SeeCabinet form = new SeeCabinet(see);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();

        }
    }
}
