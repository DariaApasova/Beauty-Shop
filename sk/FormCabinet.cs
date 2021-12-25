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
    public partial class FormCabinet : Form
    {

        string check = "";
        int id;
        int all;
        int count;
        int page;
        int lastindex;
        int firstindex;
        List<int> pages = new List<int>();
        Dictionary<int, Cabinet> used = new Dictionary<int, Cabinet>();
        Dictionary<int, Cabinet> dict = CabinetsCache.getCache();
        Dictionary<int, Branch> dictb = BranchCache.getCache();
        public FormCabinet(string check1, int idd)
        {
            InitializeComponent();
            check = check1;
            id = idd;
            all = dict.Count;
            load_filters();
            statistic("all");
        }
        private void load_filters()
        {
            comboBox1.Items.Add("От новых к старым");
            comboBox1.Items.Add("От старых к новым");
            if (check == "see")
            {
                if (all > 10)
                {
                    numericUpDown3.Value = 10;
                    for (int i = 1; i <= 10; i++)
                    {
                        used.Add(i, dict[i]);
                    }
                }
                else
                {
                    numericUpDown3.Value = all;
                    for (int i = 0; i <= all; i++)
                    {
                        used.Add(i, dict[i]);
                    }
                }
            }
            if(check=="detBranch")
            {
                numericUpDown3.Value = dictb.FirstOrDefault(x => x.Key == id).Value.Cabinets.Count;
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
                    if (Convert.ToDecimal(count / numericUpDown3.Value) > 1)
                    {
                        page = Convert.ToInt16(Math.Ceiling(Convert.ToDecimal(count / numericUpDown3.Value)));
                        for (int i = 1; i <= page; i++)
                        {
                            pages.Add(i);
                        }
                    }
                    else
                    {
                        pages.Add(1);
                    }
                    count = Convert.ToInt16(numericUpDown3.Value);
                    updUsed();
                }
                if (f == "all")
                {
                    count = dict.Count;
                    if (Convert.ToDecimal(count / numericUpDown3.Value) > 1)
                    {
                        page = Convert.ToInt16(Math.Ceiling(Convert.ToDecimal(count / numericUpDown3.Value)));
                        for (int i = 1; i <= page; i++)
                        {
                            pages.Add(i);
                        }
                    }
                    else
                    {
                        pages.Add(1);
                    }
                    count = Convert.ToInt16(numericUpDown3.Value);
                    updUsed();
                    load();
                }
            }
            if(check=="detBranch")
            {
                foreach(Branch b in dictb.Values)
                {
                    if(b.id==id)
                    {
                        count = b.Cabinets.Count;
                        all = count;
                        break;
                    }
                }
                pages.Clear();
                if(f=="filters")
                {
                    if(Convert.ToDecimal(count/numericUpDown3.Value)>1)
                    {
                        page = Convert.ToInt16(Math.Ceiling(Convert.ToDecimal(count / numericUpDown3.Value)));
                        for(int i=1;i<=page;i++)
                        {
                            pages.Add(i);
                        }
                    }
                    else
                    {
                        pages.Add(1);
                    }
                    count = Convert.ToInt16(numericUpDown3.Value);
                    updUsed();
                }
                if(f=="all")
                {
                    if (Convert.ToDecimal(count / numericUpDown3.Value) > 1)
                    {
                        page = Convert.ToInt16(Math.Ceiling(Convert.ToDecimal(count / numericUpDown3.Value)));
                        for (int i = 1; i <= page; i++)
                        {
                            pages.Add(i);
                        }
                    }
                    else
                    {
                        pages.Add(1);
                    }
                    count = Convert.ToInt16(numericUpDown3.Value);
                    updUsed();
                    load();
                }
            }
            textBox3.Text = Convert.ToString(1);
            test();
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
            if(check=="detBranch")
            {
                foreach(Branch b in dictb.Values)
                {
                    if(b.id==id)
                    {
                        var r = b.Cabinets.ToList();
                        for(int i=0;i<count;i++)
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
            if(textBox3.Text == "1" && textBox3.Text == Convert.ToString(pages[pages.Count - 1]))
            {
                button6.Enabled = false;
                button7.Enabled = false;
            }
        }
        private void sort()
        {
            bool a = (textBox1.Text == string.Empty);//ид
            bool b = (textBox2.Text == string.Empty);//название
            bool c = (label3.Text == "Филиал");//ид филиала
            bool d = (numericUpDown1.Value == 0);//стоимость от
            bool e = (numericUpDown2.Value == 0);//стоимость до
            if(a==false||b==false||c==false||d==false||e==false)
            {
                dataGridView1.Rows.Clear();
            }
            if(a==false)
            {
                b=true; c=true; d = true; e = true;
                int t = Convert.ToInt16(textBox1.Text);
                if (check == "see")
                {
                    foreach (Cabinet cab in dict.Values)
                    {
                        if (cab.id == t)
                        {
                            if (checkBox2.Checked)
                            {
                                load_real(cab, 0);
                            }
                            else
                            {
                                load_all(cab, 0);
                            }
                        }
                    }
                }
                if(check=="detBranch")
                {
                    count = all;
                    updUsed();
                    foreach (Cabinet cab in used.Values)
                    {
                        if (cab.id == t)
                        {
                            if (checkBox2.Checked)
                            {
                                load_real(cab, 0);
                            }
                            else
                            {
                                load_all(cab, 0);
                            }
                        }
                    }
                }
            }
            if(b==false&&c==true)
            {
                string t = textBox2.Text;
                int r = 0;
                if (check == "see")
                {
                    foreach (Cabinet cab in dict.Values)
                    {
                        if (cab.cabinet_name == t)
                        {
                            if (checkBox2.Checked)
                            {
                                load_real(cab, r);
                                r++;
                            }
                            else
                            {
                                load_all(cab, r);
                                r++;
                            }
                        }
                    }
                }
                if(check=="detBranch")
                {
                    count = all;
                    updUsed();
                    foreach (Cabinet cab in used.Values)
                    {
                        if (cab.cabinet_name == t)
                        {
                            if (checkBox2.Checked)
                            {
                                load_real(cab, r);
                                r++;
                            }
                            else
                            {
                                load_all(cab, r);
                                r++;
                            }
                        }
                    }
                }
            }
            if(b==true&&c==false)
            {
                int  t =Convert.ToInt16(label3.Text);
                int r = 0;
                if (check == "see")
                {
                    foreach (Cabinet cab in dict.Values)
                    {
                        if (cab.branch.id == t)
                        {
                            if (checkBox2.Checked)
                            {
                                load_real(cab, r);
                                r++;
                            }
                            else
                            {
                                load_all(cab, r);
                                r++;
                            }
                        }
                    }
                }
                if(check=="detBranch")
                {
                    count = all;
                    updUsed();
                    foreach (Cabinet cab in used.Values)
                    {
                        if (cab.branch.id == t)
                        {
                            if (checkBox2.Checked)
                            {
                                load_real(cab, r);
                                r++;
                            }
                            else
                            {
                                load_all(cab, r);
                                r++;
                            }
                        }
                    }
                }
            }
            if(b==false&&c==false)
            {
                string t = textBox2.Text;
                int y = Convert.ToInt16(label3.Text);
                int r = 0;
                if (check == "see")
                {
                    foreach (Cabinet cab in dict.Values)
                    {
                        if (cab.branch.id == y && cab.cabinet_name == t)
                        {
                            if (checkBox2.Checked)
                            {
                                load_real(cab, r);
                                r++;
                            }
                            else
                            {
                                load_all(cab, r);
                                r++;
                            }
                        }
                    }
                }
                if(check=="detBranch")
                {
                    count = all;
                    updUsed();
                    foreach (Cabinet cab in used.Values)
                    {
                        if (cab.branch.id == y && cab.cabinet_name == t)
                        {
                            if (checkBox2.Checked)
                            {
                                load_real(cab, r);
                                r++;
                            }
                            else
                            {
                                load_all(cab, r);
                                r++;
                            }
                        }
                    }
                }
            }
            if(d==false&&e==true)
            {
                int r = 0;
                int t = Convert.ToInt16(numericUpDown1.Value);
                if (check == "see")
                {
                    foreach (Cabinet cab in dict.Values)
                    {
                        if (cab.capacity >= t)
                        {
                            if (checkBox2.Checked)
                            {
                                load_real(cab, r);
                                r++;
                            }
                            else
                            {
                                load_all(cab, r);
                                r++;
                            }
                        }
                    }
                }
                if(check=="detBranch")
                {
                    count = all;
                    updUsed();
                    foreach (Cabinet cab in used.Values)
                    {
                        if (cab.capacity >= t)
                        {
                            if (checkBox2.Checked)
                            {
                                load_real(cab, r);
                                r++;
                            }
                            else
                            {
                                load_all(cab, r);
                                r++;
                            }
                        }
                    }
                }
            }
            if (d == true && e == false)
            {
                int r = 0;
                int t = Convert.ToInt16(numericUpDown2.Value);
                if (check == "see")
                {
                    foreach (Cabinet cab in dict.Values)
                    {
                        if (cab.capacity <= t)
                        {
                            if (checkBox2.Checked)
                            {
                                load_real(cab, r);
                                r++;
                            }
                            else
                            {
                                load_real(cab, r);
                                r++;
                            }
                        }
                    }
                }
                if(check=="detBranch")
                {
                    count = all;
                    updUsed();
                    foreach (Cabinet cab in used.Values)
                    {
                        if (cab.capacity <= t)
                        {
                            if (checkBox2.Checked)
                            {
                                load_real(cab, r);
                                r++;
                            }
                            else
                            {
                                load_real(cab, r);
                                r++;
                            }
                        }
                    }
                }
            }
            if(d==false&&e==false)
            {
                int r = 0;
                int t = Convert.ToInt16(numericUpDown1.Value);
                int y = Convert.ToInt16(numericUpDown2.Value);
                if (check == "see")
                {
                    foreach (Cabinet cab in dict.Values)
                    {
                        if (cab.capacity >= t && cab.capacity <= y)
                        {
                            if (checkBox2.Checked)
                            {
                                load_real(cab, r);
                                r++;
                            }
                            else
                            {
                                load_all(cab, r);
                                r++;
                            }
                        }
                    }
                }
                if(check=="detBranch")
                {
                    count = all;
                    updUsed();
                    foreach (Cabinet cab in used.Values)
                    {
                        if (cab.capacity >= t && cab.capacity <= y)
                        {
                            if (checkBox2.Checked)
                            {
                                load_real(cab, r);
                                r++;
                            }
                            else
                            {
                                load_all(cab, r);
                                r++;
                            }
                        }
                    }
                }
            }
        }
        private void checkBox2_ChechedChanged(object sender, EventArgs e)
        {
            load();
        }
        private void load()
        {
            dataGridView1.ReadOnly = true;
            if (check == "see")
            {
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Rows.Clear();
                int r = 0;
                foreach (Cabinet c in used.Values)
                {
                    int i = 1;
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
            if(check=="detBranch")
            {
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Rows.Clear();
                int r = 0;
                        foreach (Cabinet c in used.Values)
                        {
                            if(checkBox2.Checked)
                            {
                                load_real(c, r);
                                r++;
                            }
                            else
                            {
                                load_all(c, r);
                                r++;
                            }
                        }
                    }
        }
        private void load_real(Cabinet c, int r)
        {
            if(c.date_delete==Convert.ToDateTime("31.12.9999 12:00:00"))
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, r].Value = c.id;
                dataGridView1[1, r].Value = c.cabinet_name;
                dataGridView1[2, r].Value = c.capacity;
                dataGridView1[3, r].Value = c.notes;
                dataGridView1[4, r].Value = c.branch.name;
            }
            if(r==0)
            {
                firstindex = c.id;
            }
            if(r==count-1)
            {
                lastindex = c.id;
            }
        }
        private void load_all(Cabinet c, int r)
        {
            dataGridView1.Rows.Add();
            dataGridView1[0, r].Value = c.id;
            dataGridView1[1, r].Value = c.cabinet_name;
            dataGridView1[2, r].Value = c.capacity;
            dataGridView1[3, r].Value = c.notes;
            dataGridView1[4, r].Value = c.branch.name;
            if (r == 0)
            {
                firstindex = c.id;
            }
            if (r == count - 1)
            {
                lastindex = c.id;
            }
        }
        private void choice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex!=-1)
            {
                int t = e.RowIndex;
                var h = dataGridView1.Rows[t].Cells[0].Value;
                id = Convert.ToInt16(h);
                seeCabinet();
            }
        }
        private void seeCabinet()
        {
            Cabinet see =dict.FirstOrDefault(t => t.Key == id).Value;
            SeeCabinet form = new SeeCabinet(see);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormClosing += new FormClosingEventHandler(formClosing);
            form.ShowDialog();

        }
        private void addNew_Click(object sender, EventArgs e)
        {
            Cabinet newc = new Cabinet();
            AddOrChangeCabinet form = new AddOrChangeCabinet(newc, "add");
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormClosing += new FormClosingEventHandler(formClosing);
            form.ShowDialog();
        }
        void formClosing(object sender, FormClosingEventArgs E)
        {
            dict.Clear();
            dict = CabinetsCache.getCache();
            updUsed();
            load();
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
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            label3.Text = "Филиал";
            statistic("all");
            load();
        }
        private void select_ttb_Click(object sender, EventArgs e)
        {
            FormBranch form = new FormBranch("choose");
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
            label3.Text = Convert.ToString(form.num);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty&&textBox2.Text == string.Empty&&label3.Text == "Филиал"&&numericUpDown1.Value == 0&&numericUpDown2.Value == 0)
            {
                statistic("all");
            }
            else
            {
                statistic("filters");
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(Convert.ToInt16(textBox3.Text) - 1);
            used.Clear();
            if (check == "see")
            {
                if (textBox3.Text == "1")
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
            if (check == "detBranch")
            {
                var r = dictb.FirstOrDefault(x => x.Key == id).Value.Cabinets.ToList();
                int ind = r.FindIndex(x => x.id == firstindex);
                for (int i = 1; i <= count; i++)
                {
                    used.Add(r[ind - i].id, r[ind - i]);
                }
            }
            test();
            load();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(Convert.ToInt16(textBox3.Text) + 1);
            used.Clear();
            if (check == "see")
            {
                if (textBox3.Text == Convert.ToString(pages[pages.Count - 1]))
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
            if(check=="detBranch")
            {
                var r = dictb.FirstOrDefault(x => x.Key == id).Value.Cabinets.ToList();
                int ind = r.FindIndex(x=>x.id==lastindex);
                for(int i=1;i<=count;i++)
                {
                    used.Add(r[ind + i].id, r[ind + i]);
                }
            }
            test();
            load();
        }
    }
}
