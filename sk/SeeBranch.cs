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
            textBox1.Text =Convert.ToString(b.id);
            textBox11.Text = Convert.ToString(b.timetable.beginning);
            textBox12.Text = Convert.ToString(b.timetable.ending);
            textBox2.Text = Convert.ToString(b.name);
            textBox3.Text = Convert.ToString(b.address);
            textBox4.Text = Convert.ToString(b.Cabinets.Count());

        }
    }
}
