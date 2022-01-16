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
    public partial class AddOrChangeVisit : Form
    {
        string check;
        Visit visit1 = new Visit();
        int curid;
        int rows = 0;
        //Даша, солнышко. ты забыла про форму с добавлением AddInVisit
        //вспомни про нее пожалуйста:*
        int num;
        int r = 0;
        public AddOrChangeVisit(string ch, Visit v)
        {
            InitializeComponent();
            check = ch;
            visit1 = v;
            curid = v.id;
            load();
        }
        private void load()
        {
            if(check=="add")
            {
                loadNewVisit();
            }
            if(check=="change")
            {
                loadVisit(visit1);
            }
        }
        private void loadNewVisit()
        {
            label6.Text = "Не выбран";
            label7.Text ="Не выбран";
            dateTimePicker1.Value = DateTime.Now;
        }
        private void loadVisit(Visit v)
        {
            label6.Text = v.client.name;
            label7.Text = v.branch.name;
            textBox2.Text =Convert.ToString(v.price);
            dateTimePicker1.Value = v.date_visit;
            richTextBox1.Text = v.notes;
            int r = 0;
            Dictionary<int, Attendance> dict = AttendanceCache.getCache();
            foreach(Attendance at in dict.Values)
            {
                if(at.visit.id==curid)
                {
                    dataGridView1[0, r].Value = at.cabinet.cabinet_name;
                    dataGridView1[1, r].Value = at.service.title;
                    dataGridView1[2, r].Value = at.worker.name;
                    dataGridView1[3, r].Value = at.service.price;
                    r++;
                }
                rows = r - 1;
            }
            
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            FormClient form = new FormClient("choose", 0);
            form.StartPosition = FormStartPosition.CenterScreen;
            Dictionary<int, Client> dictc = ClientsCache.getCache();
            form.ShowDialog();
            label6.Text = dictc.FirstOrDefault(x => x.Key == Convert.ToInt16(form.num)).Value.name;
        }
        private void formClosed(string c, string s, string w, decimal p)
        {
            dataGridView1.Rows.Add();
            dataGridView1[0, r].Value = c;
            dataGridView1[1, r].Value = s;
            dataGridView1[2, r].Value = w;
            dataGridView1[3, r].Value = p;
            r++;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AddInVisit form = new AddInVisit(label7.Text);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
            if (form.cab != "" && form.serv != "" && form.wor != "" && form.price != 0)
            {
                formClosed(form.cab, form.serv, form.wor, form.price);
            }
            //добавить обработчик закрытия формы
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormBranch form = new FormBranch("choose");
            form.StartPosition = FormStartPosition.CenterScreen;
            Dictionary<int, Branch> dictb = BranchCache.getCache();
            form.ShowDialog();
            label7.Text = dictb.FirstOrDefault(x => x.Key == Convert.ToInt16(form.num)).Value.name;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==4)
            {
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                dataGridView1.Refresh();
            }
        }
    }
}
