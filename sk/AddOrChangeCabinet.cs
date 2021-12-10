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
    public partial class AddOrChangeCabinet : Form
    {
        int idb = 0;
        string check;
        Dictionary<int, Cabinet> dict = CabinetsCache.getCache();
        Cabinet cab1 = new Cabinet();
        int curid;
        public AddOrChangeCabinet(Cabinet b, string g)
        {
            InitializeComponent();
            cab1 = b;
            check = g;
            curid = b.id;
            load();
        }
        private void load()
        {
            if(check=="add")
            {
                load_new();
            }
            if(check=="change")
            {
                if(cab1.date_delete!=Convert.ToDateTime("31.12.9999 12:00:00"))
                {
                    MessageBox.Show("Вы не можете изменить удаленный кабинет");
                    this.Close();
                }
                else
                {
                    load_cab();
                }
            }
        }
        private void load_new()
        {
            label4.Text = "Расписание не выбрано";
            textBox1.Text = "";
            numericUpDown1.Value = 1;
            richTextBox1.Text = "";
        }
        private void load_cab()
        {
            label4.Text =Convert.ToString(cab1.branch.id);
            textBox1.Text = cab1.cabinet_name;
            numericUpDown1.Value = cab1.capacity;
            richTextBox1.Text = cab1.notes;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FormBranch form = new FormBranch("choose");
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
            label4.Text = Convert.ToString(form.num);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            numericUpDown1.Enabled = false;
            richTextBox1.Enabled = false;
            save();
            string text = "Кабинет успешно сохранен";
            string caption = "Уведомление";
            MessageBox.Show(text, caption);
        }
        private void save()
        {
            Cabinet c = cab1;
            Branch b = new Branch();
            Dictionary<int, Branch> branches = BranchCache.getCache();
            foreach(Branch f in branches.Values)
            {
                if(f.id==Convert.ToInt16(label4.Text))
                {
                    b = f;
                }
            }
            using (CabinetsContext cc = new CabinetsContext())
            {
                if(check=="add")
                {
                    Branch br = cc.Branches.Where(x => x.id == b.id).FirstOrDefault();
                    Cabinet c1 = new Cabinet { id = curid, branch=br, cabinet_name = textBox1.Text, capacity = Convert.ToInt16(numericUpDown1.Value), notes = richTextBox1.Text, date_delete = Convert.ToDateTime("31.12.9999 12:00:00") };
                    cc.Cabinets.Add(c1);
                }
                if(check=="change")
                {
                    if(textBox1.Text!=cab1.cabinet_name||numericUpDown1.Value!=Convert.ToDecimal(cab1.capacity)||richTextBox1.Text!=cab1.notes)
                    {
                        cab1.cabinet_name = textBox1.Text;
                        cab1.capacity = Convert.ToInt16(numericUpDown1.Value);
                        cab1.notes = richTextBox1.Text;
                        cc.Entry(cab1).State = System.Data.Entity.EntityState.Modified;
                    }
                    if(Convert.ToInt16(label4.Text)!=c.branch.id)
                    {
                        Cabinet cabinet = cc.Cabinets.Where(x => x.id == cab1.id).FirstOrDefault();
                        Branch branch = cc.Branches.Where(x => x.id == b.id).FirstOrDefault();
                        cab1.branch = branch;
                    }
                }
                cc.SaveChanges();
                CabinetsCache.updateCache();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
