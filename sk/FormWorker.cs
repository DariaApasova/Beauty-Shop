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
    public partial class FormWorker : Form
    {
        public int num;
        string check;
        int curid;
        int count;
        int all;
        int page;
        int lastindex;
        int firstindex;
        List<int> pages = new List<int>();
        Dictionary<int, Worker> used = new Dictionary<int, Worker>();
        Dictionary<int, Worker> dict = WorkersCache.getCache();
        Dictionary<int, Service> dicts = ServicesCache.getCache();
        public FormWorker(string check1, int id)
        {
            InitializeComponent();
            check = check1;
            curid = id;
            all = dict.Count();
            load_filters();
            statistic("all");
        }
        private void load_filters()
        {
            comboBox3.Items.Add("От новых к старым");
            comboBox3.Items.Add("От старых к новым");
            foreach(Worker w in dict.Values)
            {
                bool a =comboBox1.Items.Contains(w.position);
                if(a==false)
                {
                    comboBox1.Items.Add(w.position);
                }
            }
            if (check == "see")
            {
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
                    for (int i = 1; i <= all; i++)
                    {
                        used.Add(i, dict[i]);
                    }
                }
            }
            if (check == "detService")
            {
                numericUpDown1.Value = dicts.FirstOrDefault(x => x.Key == curid).Value.Workers.Count();
            }
        }
        private void statistic(string f)
        {
            if (check == "see")
            {
                pages.Clear();
                if (f == "filters")
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
                if (f == "all")
                {
                    count = dict.Count;
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
                textBox7.Text = Convert.ToString(1);
                test();
            }
            if (check == "detService")
            {
                foreach (Service c in dicts.Values)
                {
                    if (c.id == curid)
                    {
                        count = c.Workers.Count();
                        all = count;
                        break;
                    }
                }
                pages.Clear();
                if (f == "filters")
                {
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
                if (f == "all")
                {
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
                textBox7.Text = Convert.ToString(1);
                test();
            }
        }
        private void updUsed()
        {
            used.Clear();
            if (check == "see")
            {
                for (int i = 1; i <= count; i++)
                {
                    used.Add(i, dict[i]);
                }
            }
            if (check == "detService")
            {
                foreach (Service c in dicts.Values)
                {
                    if (c.id == curid)
                    {
                        var r = c.Workers.ToList();
                        for (int i = 0; i < count; i++)
                        {
                            used.Add(i + 1, r[i]);
                        }
                        break;
                    }
                }
            }
        }
        private void test()
        {
            if (textBox7.Text == "1")
            {
                button3.Enabled = false;
                button4.Enabled = true;
            }
            else
            {
                button3.Enabled = true;
                button4.Enabled = false;
            }
            if (textBox7.Text != "1" && textBox7.Text != Convert.ToString(pages[pages.Count - 1]))
            {
                button3.Enabled = true;
                button4.Enabled = true;
            }
            if (textBox7.Text == "1" && textBox7.Text == Convert.ToString(pages[pages.Count - 1]))
            {
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }
        private void sort()
        {
            bool a = (textBox1.Text == string.Empty);
            bool b = (textBox2.Text == string.Empty);
            bool c = (maskedTextBox1.Text == "+7(   )");
            bool d = (comboBox1.SelectedIndex == -1);
            if(a==false||b==false||c==false||d==false)
            {
                dataGridView1.Rows.Clear();
            }
            if(a==false)
            {
                b = true;c = true;d = true;
                int t = Convert.ToInt16(textBox1.Text);
                if(check=="see")
                {
                    foreach(Worker w in dict.Values)
                    {
                        if(w.id==t)
                        {
                            if(checkBox2.Checked)
                            {
                                load_real(w, 0);
                            }
                            else
                            {
                                load_all(w, 0);
                            }
                            break;
                        }
                    }
                }
                if(check=="detService")
                {
                    count = all;
                    updUsed();
                    foreach(Worker w in used.Values)
                    {
                        if(w.id==t)
                        {
                            if(checkBox2.Checked)
                            {
                                load_real(w, 0);
                            }
                            else
                            {
                                load_all(w, 0);
                            }
                            break;
                        }
                    }
                }
            }
            if(b==false&&c==true&&d==true)
            {
                string t = textBox2.Text.ToLower();
                int r = 0;
                if(check=="see")
                {
                    foreach (Worker w in dict.Values)
                    {
                        bool l = w.name.ToLower().Contains(t);
                        if (l)
                        {
                                if (checkBox2.Checked)
                                {
                                    load_real(w, r);
                                    r++;
                                }
                                else
                                {
                                    load_all(w, r);
                                    r++;
                                }
                        }
                    }
                }
                if(check=="detService")
                {
                    count = all;
                    updUsed();
                    foreach(Worker w in used.Values)
                    {
                        bool l = w.name.ToLower().Contains(t);
                        if(l)
                        {
                            if(checkBox2.Checked)
                            {
                                load_real(w, r);
                                r++;
                            }
                            else
                            {
                                load_all(w, r);
                                r++;
                            }
                        }
                    }
                }
            }
            if(c==false&&b==true&&d==true)
            {
                string t = maskedTextBox1.Text;
                int r = 0;
                if(check=="see")
                {
                    foreach(Worker w in dict.Values)
                    {
                        string u = w.phone.Replace("-", "");
                        if(u.Contains(t))
                        {
                            if(checkBox2.Checked)
                            {
                                load_real(w, r);
                                r++;
                            }
                            else
                            {
                                load_all(w, r);
                                r++;
                            }
                        }
                    }
                }
                if(check=="detService")
                {
                    count = all;
                    updUsed();
                    foreach(Worker w in used.Values)
                    {
                        string u = w.phone.Replace("-", "");
                        if (u.Contains(t))
                        {
                            if(checkBox2.Checked)
                            {
                                load_real(w, r);
                                r++;
                            }
                            else
                            {
                                load_all(w, r);
                                r++;
                            }
                        }
                    }
                }
            }
            if(d==false&&c==true&&b==true)
            {
                string t = comboBox1.SelectedItem.ToString();
                int r = 0;
                if(check=="see")
                {
                    foreach(Worker w in dict.Values)
                    {
                        if(w.position==t)
                        {
                            if(checkBox2.Checked)
                            {
                                load_real(w, r);
                            }
                            else
                            {
                                load_all(w, r);
                            }
                            r++;
                        }
                    }
                }
                if(check=="detService")
                {
                    count = all;
                    updUsed();
                    foreach(Worker w in used.Values)
                    {
                        if(w.position==t)
                        {
                            if(checkBox2.Checked)
                            {
                                load_real(w, r);
                            }
                            else
                            {
                                load_all(w, r);
                            }
                            r++;
                        }
                    }
                }
            }
            if(b==false&&c==false&&d==true)
            {
                string q = textBox2.Text.ToLower();
                string e = maskedTextBox1.Text;
                int r = 0;
                if(check=="see")
                {
                    foreach(Worker w in dict.Values)
                    {
                        bool l = (w.name.ToLower().Contains(q));
                        bool k = (w.phone.Replace("-", "").Contains(e));
                        if(k&&l)
                        {
                            if(checkBox2.Checked)
                            {
                                load_real(w, r);
                            }
                            else
                            {
                                load_all(w, r);
                            }
                            r++;
                        }
                    }
                }
                if(check=="detService")
                {
                    count = all;
                    updUsed();
                    foreach(Worker w in used.Values)
                    {
                        bool l = (w.name.ToLower().Contains(q));
                        bool k = (w.phone.Replace("-", "").Contains(e));
                        if(k&&l)
                        {
                            if(checkBox2.Checked)
                            {
                                load_real(w, r);
                            }
                            else
                            {
                                load_all(w, r);
                            }
                            r++;
                        }
                    }
                }
            }
            if(b==false&&c==true&&d==false)
            {
                string q = textBox2.Text;
                string e = comboBox1.SelectedItem.ToString();
                int r = 0;
                if(check=="see")
                {
                    foreach(Worker w in dict.Values)
                    {
                        bool l = (w.name.ToLower().Contains(q));
                        bool k = (w.position.Contains(e));
                        if(k&&l)
                        {
                            if(checkBox2.Checked)
                            {
                                load_real(w, r);
                            }
                            else
                            {
                                load_all(w, r);
                            }
                            r++;
                        }
                    }
                }
                if(check=="derService")
                {
                    count = all;
                    updUsed();
                    foreach(Worker w in used.Values)
                    {
                        bool l = (w.name.ToLower().Contains(q));
                        bool k = (w.position.Contains(e));
                        if(k&&l)
                        {
                            if(checkBox2.Checked)
                            {
                                load_real(w, r);
                            }
                            else
                            {
                                load_all(w, r);
                            }
                            r++;
                        }
                    }
                }
            }
            if(b==true&&c==false&&d==false)
            {
                string q = maskedTextBox1.Text;
                string e = comboBox1.SelectedItem.ToString();
                int r = 0;
                if(check=="see")
                {
                    foreach(Worker w in dict.Values)
                    {
                        bool l = (w.phone.Replace("-", "").Contains(q));
                        bool k = (w.position.Contains(e));
                        if(k&&l)
                        {
                            if(checkBox2.Checked)
                            {
                                load_real(w, r);
                            }
                            else
                            {
                                load_all(w, r);
                            }
                            r++;
                        }
                    }
                }
                if(check=="detService")
                {
                    count = all;
                    updUsed();
                    foreach(Worker w in used.Values)
                    {
                        bool l = (w.phone.Replace("-", "").Contains(q));
                        bool k = (w.position.Contains(e));
                        if(k&&l)
                        {
                            if(checkBox2.Checked)
                            {
                                load_real(w, r);
                            }
                            else
                            {
                                load_all(w, r);
                            }
                            r++;
                        }
                    }
                }
            }
            if(b==false&&c==false&&d==false)
            {
                string q = textBox2.Text.ToLower();
                string e = maskedTextBox1.Text;
                string t = comboBox1.SelectedItem.ToString();
                int r = 0;
                if(check=="see")
                {
                    foreach(Worker w in dict.Values)
                    {
                        bool l=(w.name.ToLower().Contains(q));
                        bool k = (w.phone.Replace("-", "").Contains(e));
                        bool j = (w.position.Contains(t));
                        if(l&&k&&j)
                        {
                            if(checkBox2.Checked)
                            {
                                load_real(w, r);
                            }
                            else
                            {
                                load_all(w,r);
                            }
                            r++;
                        }
                    }
                }
                if(check=="derService")
                {
                    count = all;
                    updUsed();
                    foreach(Worker w in used.Values)
                    {
                        bool l = (w.name.ToLower().Contains(q));
                        bool k = (w.phone.Replace("-", "").Contains(e));
                        bool j = (w.position.Contains(t));
                        if (l && k && j)
                        {
                            if (checkBox2.Checked)
                            {
                                load_real(w, r);
                            }
                            else
                            {
                                load_all(w, r);
                            }
                            r++;
                        }
                    }
                }
            }
        }
        private void load()
        {
            if(check=="see")
            {
                dataGridView1.ReadOnly = true;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Rows.Clear();
                int r = 0;
                foreach (Worker w in used.Values)
                {
                    int i = 1;
                    if (i < count)
                    {
                        if (checkBox2.Checked)
                        {
                            load_real(w, r);
                            r++;
                        }
                        else
                        {
                            load_all(w, r);
                            r++;
                        }
                    }
                }
            }
            if(check=="detService")
            {
                dataGridView1.ReadOnly = true;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Rows.Clear();
                int r = 0;
                foreach(Worker s in used.Values)
                {
                   if(checkBox2.Checked)
                    {
                        load_real(s, r);
                        r++;
                    }
                    else
                    {
                        load_all(s, r);
                        r++;
                    }
                }
            }
             if(check=="choose")
            {
                dataGridView1.ReadOnly = true;
                dataGridView1.Columns[5].Visible = true;
                dataGridView1.Rows.Clear();
                int r = 0;
                foreach (Worker s in used.Values)
                {
                    if (checkBox2.Checked)
                    {
                        load_real(s, r);
                        r++;
                    }
                    else
                    {
                        load_all(s, r);
                        r++;
                    }
                }
            }  
        }
        private void load_real(Worker w, int r)
        {
            if(w.date_delete==Convert.ToDateTime("31.12.9999 12:00:00"))
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, r].Value = w.id;
                dataGridView1[1, r].Value = w.name;
                dataGridView1[2, r].Value = w.phone;
                dataGridView1[3, r].Value = w.position;
                dataGridView1[4, r].Value = w.notes;
                if(r==0)
                {
                    firstindex = w.id;
                }
                if(r==count-1)
                {
                    lastindex = w.id;
                }
            }
        }
        private void load_all(Worker w, int r)
        {
            dataGridView1.Rows.Add();
            dataGridView1[0, r].Value = w.id;
            dataGridView1[1, r].Value = w.name;
            dataGridView1[2, r].Value = w.phone;
            dataGridView1[3, r].Value = w.position;
            dataGridView1[4, r].Value = w.notes;
            if (r == 0)
            {
                firstindex = w.id;
            }
            if (r == count - 1)
            {
                lastindex = w.id;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int t = e.RowIndex;
                var h = dataGridView1.Rows[t].Cells[0].Value;
                curid = Convert.ToInt32(h);
            }
            Worker see = dict[curid];
            SeeWorker form = new SeeWorker(see);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormClosing += new FormClosingEventHandler(formCLosed);
            form.ShowDialog();

        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            load();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox7.Text = Convert.ToString(Convert.ToInt16(textBox7.Text) - 1);
            used.Clear();
            if (check == "see")
            {
                if (textBox7.Text == "1")
                {
                    for (int i = 1; i <= count; i++)
                    {
                        used.Add(i, dict[i]);
                    }
                }
                else
                {
                    for (int i = firstindex - count; i < lastindex; i++)
                    {
                        used.Add(i, dict[i]);
                    }
                }
            }
            if (check == "detService")
            {
                var r = dicts.FirstOrDefault(x => x.Key == curid).Value.Workers.ToList();
                int ind = r.FindIndex(x => x.id == firstindex);
                for (int i = 1; i <= count; i++)
                {
                    used.Add(r[ind - i].id, r[ind - i]);
                }
            }
            test();
            load();
          }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox7.Text = Convert.ToString(Convert.ToInt16(textBox7.Text) + 1);
            used.Clear();
            if (check == "see")
            {
                if (textBox7.Text == Convert.ToString(pages[pages.Count - 1]))
                {
                    for (int i = lastindex + 1; i < all + 1; i++)
                    {
                        used.Add(i, dict[i]);
                    }
                }
                else
                {
                    for (int i = lastindex + 1; i < lastindex + count + 1; i++)
                    {
                        used.Add(i, dict[i]);
                    }
                }
            }
            if (check == "detService")
            {
                var r = dicts.FirstOrDefault(x => x.Key == curid).Value.Workers.ToList();
                int ind = r.FindIndex(x => x.id == lastindex);
                for (int i = 1; i <= count; i++)
                {
                    used.Add(r[ind + i].id, r[ind + i]);
                }
            }
            test();
            load();
        }
        private void addNew_Click(object sender, EventArgs e)
        {
            Worker wor = new Worker();
            wor.id = curid;
            AddOrChangeWorker form = new AddOrChangeWorker(wor, "add");
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormClosing += new FormClosingEventHandler(formCLosed);
            form.ShowDialog();
        }
        void formCLosed(object sender, FormClosingEventArgs e)
        {
            WorkersCache.updateCache();
            dict.Clear();
            dict = WorkersCache.getCache();
            updUsed();
            load();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty&&textBox2.Text == string.Empty&&maskedTextBox1.Text == "+7(   )"&&comboBox1.SelectedIndex == -1)
            {
                statistic("all");
            }
            else
            {
                statistic("filters");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex > -1)
            {
                if (comboBox3.SelectedIndex == 0)
                {
                    sort();
                    dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
                }
                if (comboBox3.SelectedIndex == 1)
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
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            maskedTextBox1.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            statistic("all");
            load();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==5)
            {
                int r = e.RowIndex;
                num = Convert.ToInt16(dataGridView1.Rows[r].Cells[0].Value);
                Close();
            }
        }
    }
}
