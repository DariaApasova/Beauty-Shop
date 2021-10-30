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
    public partial class SeeCabinet : Form
    {
        Cabinet c = new Cabinet();
        Dictionary<int, Cabinet> dict = CabinetsCache.getCache();
        public SeeCabinet(Cabinet c1)
        {
            InitializeComponent();
            c = c1;
            load();
        }
        private void load()
        {
            textBox1.Text = Convert.ToString(c.id);
            textBox2.Text = c.cabinet_name;
            textBox3.Text = Convert.ToString(c.capacity);
            textBox4.Text = c.branch.name;
            richTextBox1.Text = c.notes;
            
            textBox5.Text = Convert.ToString(c.Services.Count);
        }
    }
}
