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
    public partial class FormClient : Form
    {
        public string num;
        string check;
        int curid;
        int all;
        int count;
        int page;
        int lastinex;
        int fistindex;
        List<int> pages = new List<int>();
        Dictionary<int, Client> used = new Dictionary<int, Client>();
        Dictionary<int, Client> dict = ClientsCache.getCache();
        public FormClient(string check1, int idd)
        {
            InitializeComponent();
            check = check1;
            all = dict.Count();
            curid = idd;
            load_filters();
            statistic("all");
        }
        private void load_filters()
        {
            comboBox2.Items.Add("От новых к старым");
            comboBox2.Items.Add("От старых к новым");
            if (all > 10)
            {
                numericUpDown1.Value = 10;
                for (int i = 1; i <= 10; i++)
                {
                    used.Add(i, dict[i]);
                }
            }
            else
            {
                numericUpDown1.Value = all;
                for(int i=1;i<=all;i++)
                {
                    used.Add(i, dict[i]);
                }
            }
        }
        private void load()
        {
            dataGridView1.ReadOnly = true;
            if (check == "see")
            {
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Rows.Clear();      
            }
            if(check=="choose")
            {
                dataGridView1.Columns[4].Visible = true;
                dataGridView1.Rows.Clear();
            }
            int r = 0;
            int i = 1;
            foreach (Client c in used.Values)
            {
                if (i <= count)
                {
                    if (checkBox2.Checked)
                    {
                        load_real(c, r);
                        r++;
                    }
                    else
                    {
                        load_all(c, r);
                        r++;
                    }
                    i++;
                }
            }
        }
        private void checkBox2_ChechedChanged(object sender, EventArgs e)
        {
            load();
        }
        private void load_real(Client c, int r)
        {
            if(c.date_delete==Convert.ToDateTime("31.12.9999 12:00:00"))
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, r].Value = c.id;
                dataGridView1[1, r].Value = c.name;
                dataGridView1[2, r].Value = c.phone;
                dataGridView1[3, r].Value = c.notes;
            }
            if(r==0)
            {
                fistindex = c.id;
            }
            if(r==count-1)
            {
                lastinex = c.id;
            }
        }
        private void load_all(Client c, int r)
        {
            dataGridView1.Rows.Add();
            dataGridView1[0, r].Value = c.id;
            dataGridView1[1, r].Value = c.name;
            dataGridView1[2, r].Value = c.phone;
            dataGridView1[3, r].Value = c.notes;
            if (r == 0)
            {
                fistindex = c.id;
            }
            if (r == count-1)
            {
                lastinex = c.id;
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int t = e.RowIndex;
                var h = dataGridView1.Rows[t].Cells[0].Value;
                curid = Convert.ToInt32(h);
            }
            seeCLient();
        }
        private void seeCLient()
        {
            Client see = dict.FirstOrDefault(x => x.Key == curid).Value;
            SeeClient form = new SeeClient(see);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormClosing += new FormClosingEventHandler(formCLosing);
            form.ShowDialog();
        }
        private void updUsed()
        {
            used.Clear();
            for(int i=1;i<=count;i++)
            {
                used.Add(i, dict[i]);
            }
        }
        void formCLosing(object sender, FormClosingEventArgs e)
        {
            dict.Clear();
            dict = ClientsCache.getCache();
            updUsed();
            load();
        }
        private void addNew_Click(object sender, EventArgs e)
        {
            Client newc = new Client();
            AddOrChangeClient form = new AddOrChangeClient(newc, "add");
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormClosing += new FormClosingEventHandler(formCLosing);
            form.ShowDialog();
        }
        private void sort()
        {
            bool a = (textBox1.Text == string.Empty);
            bool b = (textBox2.Text == string.Empty);
            bool c = (maskedTextBox1.Text == "+7(   )");
            if(a==false||b==false||c==false)
            {
                dataGridView1.Rows.Clear();
            }
            if (a == false)
            {
                int t = Convert.ToInt16(textBox1.Text);
                foreach (Client cl in dict.Values)
                {
                    if (cl.id == t)
                    {
                        if (checkBox2.Checked)
                        {
                            load_real(cl, 0);
                        }
                        else
                        {
                            load_all(cl, 0);
                        }
                    }
                }
                b = true; c = true;
            }
            if (b == false&&c==true)
            {
                string n = textBox2.Text;
                foreach (Client ck in dict.Values)
                {
                    int r = 0;
                    if (ck.name == n)
                    {
                        if (checkBox2.Checked)
                        {
                            load_real(ck, r);
                        }
                        else
                        {
                            load_all(ck, r);
                        }
                        r++;
                    }
                }
            }
            if (c == false&&b==true)
            {
                string n = maskedTextBox1.Text;
                int r = 0;
                foreach (Client cg in dict.Values)
                {
                    string u = cg.phone.Replace("-", "");
                    if (u.Contains(n))
                    {
                        if (checkBox2.Checked)
                        {
                            load_real(cg, r);
                        }
                        else
                        {
                            load_all(cg, r);
                        }
                        r++;
                    }
                }
            }
            if(b==false&&c==false)
            {
                string q = textBox2.Text;
                string w = maskedTextBox1.Text;
                int r = 0;
                foreach(Client e in used.Values)
                {
                    if(e.name==q&&e.phone.Contains(w))
                    {
                        if(checkBox2.Checked)
                        {
                            load_real(e,r);
                        }
                        else
                        {
                            load_all(e, r);
                        }
                        r++;
                    }
                }
            }
            statistic("filters");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex > -1)
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    sort();
                    dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
                }
                if (comboBox2.SelectedIndex == 1)
                {
                    sort();
                    dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
                }
            }
            else
            {
                sort();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            maskedTextBox1.Clear();
            comboBox2.SelectedIndex = -1;
            statistic("all");
            load();
        }
        private void statistic(string f)
        {
            pages.Clear();
            if (f=="filters")
            {
                count = dataGridView1.RowCount;
                if (Convert.ToDecimal(count/numericUpDown1.Value)>1)
                {
                    page = Convert.ToInt16(Math.Ceiling(Convert.ToDecimal(count / numericUpDown1.Value)));
                    for(int i=1; i<=page;i++)
                    {
                        pages.Add(i);
                    }
                }
                else
                {
                    pages.Add(1);
                }
                count = Convert.ToInt16(numericUpDown1.Value);
                updUsed();
            }
            if (f == "all")
            {
                count = dict.Count();
                if (Convert.ToDecimal(count / numericUpDown1.Value) > 1)
                {
                    page = Convert.ToInt16(Math.Ceiling(Convert.ToDecimal(count / numericUpDown1.Value)));
                    for (int i = 1; i <= page; i++)
                    {
                        pages.Add(i);
                    }
                }
                count = Convert.ToInt16(numericUpDown1.Value);
                updUsed();
                load();
            }
            textBox3.Text = Convert.ToString(1);
            test();
        }
        private void test()
        {
            if (textBox3.Text == "1")
            {
                button3.Enabled = false;
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = true;
                button3.Enabled = false;
            }
            if (textBox3.Text != "1" && textBox3.Text != Convert.ToString(pages[pages.Count - 1]))
            {
                button3.Enabled = true;
                button2.Enabled = true;
            }
            if (textBox3.Text == "1" && textBox3.Text == Convert.ToString(pages[pages.Count - 1]))
            {
                button3.Enabled = false;
                button2.Enabled = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty && textBox2.Text == string.Empty && maskedTextBox1.Text == "+7(   )")
            {
                statistic("all");
            }
            else
            {
                statistic("filters");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(Convert.ToInt16(textBox3.Text) - 1);
            used.Clear();
            if (textBox3.Text == "1")
            {
                for (int i = 1; i <= count; i++)
                {
                    used.Add(i, dict[i]);
                }
            }
            else
            {
                for (int i = fistindex - count; i < lastinex; i++)
                {
                    used.Add(i, dict[i]);
                }
            }
            test();
            load();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(Convert.ToInt16(textBox3.Text) + 1);
            used.Clear();
            if (Convert.ToInt16(textBox3.Text) == pages[pages.Count-1])
            {
                for (int i = lastinex+1; i < all+1; i++)
                {
                    used.Add(i, dict[i]);
                }
            }
            else
            {
                for (int i = lastinex + 1; i < lastinex + count + 1; i++)
                {
                    used.Add(i, dict[i]);
                }
            }
            test();
            load();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==4)
            {
                int t = e.RowIndex;
                var n = dataGridView1.Rows[t].Cells[1].Value;
                num = Convert.ToString(n);
                Close();
            }
        }
    }
}
