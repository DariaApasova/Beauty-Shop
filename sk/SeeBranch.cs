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
    public partial class SeeBranch : Form
    {
        Branch b = new Branch();
        Dictionary<int, Branch> dict = BranchCache.getCache();
        public SeeBranch(Branch b1)
        {
            b = b1;
            InitializeComponent();
            load();
        }
        private void load()
        {
            textBox1.Enabled = false;
            textBox1.Text =Convert.ToString(b.id);
            textBox11.Enabled = false;
            textBox11.Text = Convert.ToString(b.timetable.beginning);
            textBox12.Enabled = false;
            textBox12.Text = Convert.ToString(b.timetable.ending);
            textBox2.Enabled = false;
            textBox2.Text = Convert.ToString(b.name);
            textBox3.Enabled = false;
            textBox3.Text = Convert.ToString(b.address);
            textBox4.Enabled = false;
            textBox4.Text = Convert.ToString(b.Cabinets.Count());
            Dictionary<int, Attendance> lst = AttendanceCache.lstWorkers();
            int count = 0;
            foreach(Attendance a in lst.Values)
            {
                foreach(Cabinet c in b.Cabinets.ToList())
                {
                    if(c.id==a.cabinet.id)
                    {
                        count++;
                    }
                }
            }
            textBox5.Enabled = false;
            textBox5.Text = Convert.ToString(count);
            textBox6.Enabled = false;
            textBox6.Text =Convert.ToString( b.timetable.id);
            textBox7.Enabled = false;
            textBox7.Text = b.timetable.beginning;
            textBox8.Enabled = false;
            textBox8.Text = b.timetable.start;
            textBox9.Enabled = false;
            textBox9.Text = b.timetable.end;
            textBox10.Enabled = false;
            textBox10.Text = b.timetable.ending;
            if (b.date_delete == Convert.ToDateTime("31.12.9999 12:00:00"))
            {
                label13.Visible = false;
            }
            else
            {
                label13.Text = "Услуга удалена";
                button6.Visible = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormCabinet form = new FormCabinet("detBranch", b.id);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
            b.date_delete = Convert.ToDateTime(time);
            using (BranchContext sc = new BranchContext())
            {
                sc.Entry(b).State = System.Data.Entity.EntityState.Modified;
                sc.SaveChanges();
            }
            string text = "Филиал успешно удален.";
            string caption = "Уведомление";
            MessageBox.Show(text, caption);
        }
    }
}
