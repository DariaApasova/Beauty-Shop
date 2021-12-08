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
    public partial class AddOrChangeBranch : Form
    {
        int num = 0;
        string check;
        Dictionary<int, Branch> dict = BranchCache.getCache();
        Branch branch1 = new Branch();
        int curid;
        public AddOrChangeBranch(Branch b, string h)
        {
            InitializeComponent();
            branch1 = b;
            check = h;
            curid = b.id;
            load();
        }
        private void load()
        {
            if(check=="add")
            {
               // loadNew();
            }
            if(check=="change")
            {
                if(branch1.date_delete!=Convert.ToDateTime("31.12.9999 12:00:00"))
                {
                    MessageBox.Show("Вы не можете изменить удаленный филиал");
                    this.Close();
                }
                else
                {
                    loadBranch(branch1);
                }
            }
        }
        private void loadBranch(Branch b)
        {
            textBox1.Text = b.name;
            textBox2.Text = b.address;
            label1.Text =Convert.ToString(b.timetable.id);
        }
        private void loadNew()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            label1.Text = "Расписание не выбрано";
        }
        private void save()
        {
            Branch b = branch1;
            branch1.name = textBox1.Text;
            branch1.address = textBox2.Text;
            branch1.date_delete = Convert.ToDateTime("31.12.9999 12:00:00");
            using (BranchContext bc = new BranchContext())
            {
                Branch b1 = new Branch { id = curid, name = textBox1.Text, address = textBox2.Text, date_delete = Convert.ToDateTime("31.12.9999 12:00:00") };
                if (check == "add")
                {
                    bc.Branches.Add(b1);
                }
                if (check == "change")
                {
                    bc.Entry(branch1).State = System.Data.Entity.EntityState.Modified;
                }
                bc.SaveChanges();
            }
        }
        private void save_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            save();
            string text = "Филиал успешно сохранен";
            string caption = "Уведомление";
            MessageBox.Show(text, caption);
        }


        /* public void ttbchoose(int n)
        {
            label1.Text = Convert.ToString(n);
        }*/
        /*private void button2_Click(object sender, EventArgs e)
        {
            FormTTB form = new FormTTB("choose");
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }*/
    }
}
