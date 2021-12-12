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
    public partial class AddOrChangeTTB : Form
    {
        string check;
        Dictionary<int, TimetableBranch> dicr = TimetableBranchCache.getCache();
        TimetableBranch ttb1 = new TimetableBranch();
        int curid;
        public AddOrChangeTTB(TimetableBranch t, string h)
        {
            InitializeComponent();
            ttb1 = t;
            check = h;
            curid = t.id;
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
                load_ttb();
            }
        }
        private void load_new()
        {
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
        }
        private void load_ttb()
        {
            dateTimePicker1.Value.ToShortDateString();
            dateTimePicker1.Value= Convert.ToDateTime(ttb1.beginning);
            dateTimePicker2.Value.ToShortDateString();
            dateTimePicker2.Value = Convert.ToDateTime(ttb1.ending);
            maskedTextBox1.Text = ttb1.start;
            maskedTextBox2.Text = ttb1.end;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            maskedTextBox1.Enabled = false;
            maskedTextBox2.Enabled = false;
            save();
            string text = "Расписание сохранено";
            string caption = "Уведомление";
            MessageBox.Show(text, caption);
        }
        private void save()
        {
            using (TTBContext context = new TTBContext())
            {
                if (check == "add")
                {
                    TimetableBranch b = new TimetableBranch { beginning = dateTimePicker1.Value.ToShortDateString(), ending = dateTimePicker2.Value.ToShortDateString(), start = maskedTextBox1.Text, end = maskedTextBox2.Text, date_delete = Convert.ToDateTime("31.12.9999 12:00:00") };
                    context.TTBs.Add(b);
                }
                if(check=="change")
                {
                    ttb1.beginning = dateTimePicker1.Value.ToShortDateString();
                    ttb1.ending = dateTimePicker2.Value.ToShortDateString();
                    ttb1.start = maskedTextBox1.Text;
                    ttb1.end = maskedTextBox2.Text;
                    context.Entry(ttb1).State = System.Data.Entity.EntityState.Modified;
                }
                context.SaveChanges();
                TimetableBranchCache.updateCache();
            }
        }
    }
}
