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
    public partial class RepeatTTW : Form
    {
        TimetableWorker ttw = new TimetableWorker();
        int curid;
        public RepeatTTW(int t)
        {
            InitializeComponent();
            curid = t;
            load();
        }
        private void load()
        {
            using(TTWContext ttwc=new TTWContext())
            {
                var list = ttwc.TTWs.Include("Branch").Include("Worker").ToList();
                ttw = list.FirstOrDefault(x => x.id == curid);
            }
            comboBox1.Items.Add("День");
            comboBox1.Items.Add("Неделя");
            comboBox1.Items.Add("Месяц");
            dateTimePicker1.Value =Convert.ToDateTime(DateTime.Now.ToShortDateString());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using(TTWContext ttwc=new TTWContext())
            {
               // TimetableWorker ttw1=new TimetableWorker { }
            }
        }
    }
}
