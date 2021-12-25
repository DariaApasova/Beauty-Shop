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
    public partial class FormBranch : Form
    {
        public int num;
        string check;
        int idChange;
        int all;
        int count;
        int page;
        int lastIndex;
        int firstIndex;
        List<int> pages = new List<int>();
        Dictionary<int, Branch> used = new Dictionary<int, Branch>();
        Dictionary<int, Branch> dict = BranchCache.getCache();
        public FormBranch(string check1)
        {
            InitializeComponent();
            check = check1;
            all = dict.Count();
            load_filters();
            statistic("all");
        }
        private void load_filters()
        {
            comboBox1.Items.Add("От новых к старым");
            comboBox1.Items.Add("От старых к новым");
            numericUpDown1.Value = 5;
            for(int i=1;i<=5;i++)
            {
                used.Add(i, dict[i]);
            }
        }
        private void statistic(string h)
        {
            pages.Clear();
            if (h == "filters")
            {
                count = dataGridView1.Rows.Count;
                if (Convert.ToDecimal(count / numericUpDown1.Value) > 1)
                {
                    page = Convert.ToInt16(Math.Ceiling(Convert.ToDecimal(count / numericUpDown1.Value)));
                    for (int i = 1; i <= page; i++)
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
            if (h == "all")
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
                else
                {
                    pages.Add(1);
                }
                count = Convert.ToInt16(numericUpDown1.Value);
                updUsed();
                load();
            }
            textBox3.Text = Convert.ToString(1);
            test();
        }
        private void updUsed()
        {
            used.Clear();
            for(int i=1; i<=count;i++)
            {
                used.Add(i, dict[i]);
            }
        }
        private void test()
        {
            if (textBox3.Text == "1")
            {
                button6.Enabled = false;
                button7.Enabled = true;
            }
            else
            {
                button6.Enabled = true;
                button7.Enabled = false;
            }
            if (textBox3.Text != "1" && textBox3.Text != Convert.ToString(pages[pages.Count - 1]))
            {
                button6.Enabled = true;
                button7.Enabled = true;
            }
            if (textBox3.Text == "1" && textBox3.Text == Convert.ToString(pages[pages.Count - 1]))
            {
                button6.Enabled = false;
                button7.Enabled = false;
            }
        }
        private void sort()
        {
            bool a = (textBox1.Text == string.Empty);
            bool b = (label2.Text == "Номер расписания");
            bool c = (textBox2.Text == string.Empty);
            bool d = (textBox4.Text == string.Empty);
            if(a==false||b==false||c==false||d==false)
            {
                dataGridView1.Rows.Clear();
            }
            if(a==false)
            {
                int t = Convert.ToUInt16(textBox1.Text);
                foreach(Branch br in dict.Values)
                {
                    if(br.id==t)
                    {
                        if(checkBox2.Checked)
                        {
                            load_real(br, 0);
                        }
                        else
                        {
                            load_all(br, 0);
                        }
                    }
                }
                b = true;c = true;b = true;
            }
            if(d==false)
            {
                int r = 0;
                string t = textBox4.Text;
                foreach (Branch br in dict.Values)
                {
                    if (br.address == t) 
                    {
                        if (checkBox2.Checked)
                        {
                            load_real(br, r);
                            r++;
                        }
                        else
                        {
                            load_all(br, r);
                            r++;
                        }
                    }
                }
                b = true;c = true;
            }
            if(b==false&&c==true)
            {
                int r = 0;
                int t = Convert.ToInt16(label2.Text);
                foreach(Branch br in dict.Values)
                {
                    if(br.timetable.id==t)
                    {
                        if(checkBox2.Checked)
                        {
                            load_real(br,r);
                            r++;
                        }
                        else
                        {
                            load_all(br, r);
                            r++;
                        }
                    }
                }
            }
            if (b == true&&c==false)
            {
                int r = 0;
                string t = textBox2.Text;
                foreach(Branch br in dict.Values)
                {
                    if(br.name==t)
                    {
                        if(checkBox2.Checked)
                        {  
                            load_real(br, r);
                            r++;
                        }
                        else
                        {
                            load_all(br, r);
                            r++;
                        }
                    }
                }
            }
            if(b==false&&c==false)
            {
                int r = 0;
                int t = Convert.ToInt16(label2.Text);
                string y = textBox2.Text;
                foreach(Branch br in dict.Values)
                {
                    if(br.timetable.id==t&&br.name==y)
                    {
                        if(checkBox2.Checked)
                        {
                            load_real(br, r);
                            r++;
                        }
                        else
                        {
                            load_all(br, r);
                            r++;
                        }
                    }
                }
            }
            statistic("filters");
        }
        private void load()
        {
            if (check=="see")
            {
                dataGridView1.Columns[4].Visible = false;
            }
            if(check=="choose")
            {
                dataGridView1.Columns[4].Visible = true;
            }
            dataGridView1.Rows.Clear();
            int r = 0;
            int i = 1;
            foreach(Branch b in used.Values)
            {
                if (i <= count)
                {
                    if (checkBox2.Checked)
                    {
                        load_real(b, r);
                        r++;
                    }
                    else
                    {
                        load_all(b, r);
                        r++;
                    }
                    i++;
                }
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            load();
        }
        private void load_real(Branch b, int r)
        {
            if (b.date_delete == Convert.ToDateTime("31.12.9999 12:00:00"))
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, r].Value = b.id;
                dataGridView1[1, r].Value = b.timetable.id;
                dataGridView1[2, r].Value = b.name;
                dataGridView1[3, r].Value = b.address;
            }
            if(r==0)
            {
                firstIndex = b.id;
            }
            if(r==count-1)
            {
                lastIndex = b.id;
            }
        }
        private void load_all(Branch b, int r)
        {
                dataGridView1.Rows.Add();
                dataGridView1[0, r].Value = b.id;
                dataGridView1[1, r].Value = b.timetable.id;
                dataGridView1[2, r].Value = b.name;
                dataGridView1[3, r].Value = b.address;
            if (r == 0)
            {
                firstIndex = b.id;
            }
            if (r == count - 1)
            {
                lastIndex = b.id;
            }
        }
        private void addNew_Click(object sender, EventArgs e)
        {
            Branch newb = new Branch();
            AddOrChangeBranch form = new AddOrChangeBranch(newb, "add");
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormClosing += new FormClosingEventHandler(formClosing);
            form.ShowDialog();
        }
        private void choice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int t = e.RowIndex;
                var h = dataGridView1.Rows[t].Cells[0].Value;
                idChange = Convert.ToInt16(h);
                seeCabinet();
            }
        }
        private void seeCabinet()
        {
            Branch see = dict.FirstOrDefault(t => t.Key == idChange).Value;
            SeeBranch form = new SeeBranch(see);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormClosing += new FormClosingEventHandler(formClosing);
            form.ShowDialog();
        }
        void formClosing(object sender, FormClosingEventArgs e)
        {
            BranchCache.updateCache();
            dict.Clear();
            dict = BranchCache.getCache();
            updUsed();
            load();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==4)
            {
                int t = e.RowIndex;
                var n = dataGridView1.Rows[t].Cells[0].Value;
                num = Convert.ToInt16(n);
                Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    sort();
                    dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
                }
                if (comboBox1.SelectedIndex == 1)
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
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            label2.Text = "Номер расписания";
            comboBox1.SelectedIndex = -1;
            statistic("all");
            load();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(Convert.ToInt16(textBox3.Text) + 1);
            used.Clear();
            if (textBox3.Text ==Convert.ToString(pages[pages.Count-1]))
            {
                for(int i=lastIndex+1;i<all+1;i++)
                {
                    used.Add(i, dict[i]);
                }
            }
            else
            {
                for(int i=lastIndex+1;i<lastIndex+count+1;i++)
                {
                    used.Add(i, dict[i]);
                }
            }
            test();
            load();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(Convert.ToInt16(textBox3.Text) - 1);
            used.Clear();
            if(textBox3.Text=="1")
            {
                for (int i = 1; i <= count; i++)
                {
                    used.Add(i, dict[i]);
                }
            }
            else
            {
                for(int i=firstIndex-count;i<lastIndex;i++)
                {
                    used.Add(i, dict[i]);
                }
            }
            test();
            load();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty&&label2.Text == "Номер расписания"&&textBox2.Text == string.Empty&&textBox4.Text == string.Empty)
            {
                statistic("all");
            }
            else
            {
                statistic("filters");
            }
        }
        private void select_ttb_Click(object sender, EventArgs e)
        {
            FormTTB form = new FormTTB("choose");
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
            int t = form.num;
            label2.Text = Convert.ToString(t);
        }
    }
}
