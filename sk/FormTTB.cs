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
    public partial class FormTTB : Form
    {
        public int num;
        string check;
        int curid;
        int page;
        int count;
        int all;
        int firstindex;
        int lastindex;
        List<int> pages = new List<int>();
        Dictionary<int, TimetableBranch> used = new Dictionary<int, TimetableBranch>();
        Dictionary<int, TimetableBranch> dict = TimetableBranchCache.getCache();
        public FormTTB(string check1)
        {
            InitializeComponent();
            check = check1;
            all = dict.Count();
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
                for (int i = 1; i <= all; i++)
                {
                    used.Add(i, dict[i]);
                }
            }
        }
        private void statistic(string f)
        {
            pages.Clear();
            if (f == "filters")
            {
                count = dataGridView2.RowCount;
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
            textBox2.Text = Convert.ToString(1);
            test();
        }
        private void test()
        {
            if (textBox2.Text == "1")
            {
                button6.Enabled = false;
                button7.Enabled = true;
            }
            else
            {
                button6.Enabled = true;
                button7.Enabled = false;
            }
            if (textBox2.Text != "1" && textBox2.Text != Convert.ToString(pages[pages.Count - 1]))
            {
                button6.Enabled = true;
                button7.Enabled = true;
            }
            if (textBox2.Text == "1" && textBox2.Text == Convert.ToString(pages[pages.Count - 1]))
            {
                button6.Enabled = false;
                button7.Enabled = false;
            }
        }
        private void updUsed()
        {
            used.Clear();
            for (int i = 1; i <= count; i++)
            {
                used.Add(i, dict[i]);
            }
        }
        private void load()
        {
            dataGridView2.Rows.Clear();
            if(check=="see")
            {
                dataGridView2.Columns[6].Visible = false;
                dataGridView2.Columns[7].Visible = true;
            }
            if(check=="choose")
            {
                dataGridView2.Columns[6].Visible = true;
                dataGridView2.Columns[7].Visible = false;
            }
            int r = 0;
            foreach (TimetableBranch t in used.Values)
                {
                    if(checkBox2.Checked)
                    {
                        load_real(t, r);
                        r++;
                    }
                    else
                    {
                        load_all(t, r);
                        r++;
                    }
                }
        }
        private void load_real(TimetableBranch t, int r)
        {
            if(t.date_delete==Convert.ToDateTime("31.12.9999 12:00:00"))
            {
                int count = 0;
                Dictionary<int, Branch> d = BranchCache.getCache();
                foreach (Branch w in d.Values)
                {
                    if (w.timetable.id == t.id)
                    {
                        count++;
                    }
                }
                dataGridView2.Rows.Add();
                dataGridView2[0, r].Value = t.id;
                dataGridView2[1, r].Value = count;
                dataGridView2[2, r].Value = t.beginning;
                dataGridView2[3, r].Value = t.start;
                dataGridView2[4, r].Value = t.end;
                dataGridView2[5, r].Value = t.ending;
            }
            if (r == 0)
            {
                firstindex = t.id;
            }
            if (r == count - 1)
            {
                lastindex = t.id;
            }
        }
        private void sort()
        {
            Dictionary<int, TimetableBranch> sortingDate = new Dictionary<int, TimetableBranch>();
            Dictionary<int, TimetableBranch> sortingTime = new Dictionary<int, TimetableBranch>();
            bool a = (textBox1.Text == string.Empty);
            bool date1 = (dateTimePicker1.Value.ToShortDateString() == "01.01.2018");
            bool date2 = (dateTimePicker2.Value.ToShortDateString() == "01.01.2018");
            bool date3 = (dateTimePicker3.Value.ToShortDateString() == "01.01.2018");
            bool date4 = (dateTimePicker4.Value.ToShortDateString() == "01.01.2018");
            bool time1 = (maskedTextBox1.Text == "  :  :");
            bool time2 = (maskedTextBox2.Text == "  :  :");
            bool time3 = (maskedTextBox3.Text == "  :  :");
            bool time4 = (maskedTextBox4.Text == "  :  :");
            if(a==false||date1==false||date2==false||date3==false||date4==false||time1==false||time2==false||time3==false||time4==false)
            {
                dataGridView2.Rows.Clear();
                sortingDate.Clear();
                sortingTime.Clear();
            }
            if(a==false)
            {
                date1 = true;date2 = true;date3 = true;date4 = true;time1 = true;time2 = true;time3 = true;time4 = true;
                int t = Convert.ToInt16(textBox1.Text);
                foreach(TimetableBranch ttb in dict.Values)
                {
                    if(ttb.id==t)
                    {
                        if(checkBox2.Checked)
                        {
                            load_real(ttb, 0);
                        }
                        else
                        {
                            load_all(ttb, 0);
                        }
                        break;
                    }
                }
            }
            //дата начала от
            if(date1==false&&date2==true&&date3==true&&date4==true)
            {
                DateTime t = dateTimePicker1.Value;
                foreach(TimetableBranch ttb in dict.Values)
                {
                    if(Convert.ToDateTime(ttb.beginning)>=t)
                    {
                        sortingDate.Add(ttb.id, ttb);
                    }
                }
            }
            //дата начала до
            if (date1 == true && date2 == false && date3 == true && date4 == true)
            {
                DateTime t = dateTimePicker2.Value;
                foreach (TimetableBranch ttb in dict.Values)
                {
                    if (Convert.ToDateTime(ttb.beginning) <= t)
                    {
                        sortingDate.Add(ttb.id, ttb);
                    }
                }
            }
            //дата конца от
            if (date1 == true && date2 == true && date3 == false && date4 == true)
            {
                DateTime t = dateTimePicker3.Value;
                foreach (TimetableBranch ttb in dict.Values)
                {
                    if (Convert.ToDateTime(ttb.ending) >= t)
                    {
                        sortingDate.Add(ttb.id, ttb);
                    }
                }
            }
            //дата конца до
            if (date1 == true && date2 == true && date3 == true && date4 == false)
            {
                DateTime t = dateTimePicker4.Value;
                foreach (TimetableBranch ttb in dict.Values)
                {
                    if (Convert.ToDateTime(ttb.ending) <= t)
                    {
                        sortingDate.Add(ttb.id, ttb);
                    }
                }
            }
            //дата начала от и до
            if (date1==false&&date2==false&&date3==true&&date4==true)
            {
                DateTime q = dateTimePicker1.Value;
                DateTime w = dateTimePicker2.Value;
                foreach(TimetableBranch ttb in dict.Values)
                {
                    if(Convert.ToDateTime(ttb.beginning)>=q&&Convert.ToDateTime(ttb.beginning)<=w)
                    {
                        sortingDate.Add(ttb.id, ttb);
                    }
                }
            }
            //дата начала от и дата конца от
            if (date1 == false && date2 == true && date3 == false && date4 == true)
            {
                DateTime q = dateTimePicker1.Value;
                DateTime w = dateTimePicker3.Value;
                foreach (TimetableBranch ttb in dict.Values)
                {
                    if (Convert.ToDateTime(ttb.beginning) >= q && Convert.ToDateTime(ttb.ending) >= w)
                    {
                        sortingDate.Add(ttb.id, ttb);
                    }
                }
            }
            //дата начала от и дата конца до
            if (date1 == false && date2 == true && date3 == true && date4 == false)
            {
                DateTime q = dateTimePicker1.Value;
                DateTime w = dateTimePicker4.Value;
                foreach (TimetableBranch ttb in dict.Values)
                {
                    if (Convert.ToDateTime(ttb.beginning) >= q && Convert.ToDateTime(ttb.ending) <= w)
                    {
                        sortingDate.Add(ttb.id, ttb);
                    }
                }
            }
            //дата начала до и дата конца от
            if (date1 == true && date2 == false && date3 == false && date4 == true)
            {
                DateTime q = dateTimePicker2.Value;
                DateTime w = dateTimePicker3.Value;
                foreach (TimetableBranch ttb in dict.Values)
                {
                    if (Convert.ToDateTime(ttb.beginning) <= q && Convert.ToDateTime(ttb.ending) >= w)
                    {
                        sortingDate.Add(ttb.id, ttb);
                    }
                }
            }
            //дата начала до и дата конца до
            if (date1 == true && date2 == false && date3 == true && date4 == false)
            {
                DateTime q = dateTimePicker2.Value;
                DateTime w = dateTimePicker4.Value;
                foreach (TimetableBranch ttb in dict.Values)
                {
                    if (Convert.ToDateTime(ttb.beginning) <= q && Convert.ToDateTime(ttb.ending) <= w)
                    {
                        sortingDate.Add(ttb.id, ttb);
                    }
                }
            }
            //дата конца от и до
            if (date1 == true && date2 == true && date3 == false && date4 == false)
            {
                DateTime q = dateTimePicker3.Value;
                DateTime w = dateTimePicker4.Value;
                foreach (TimetableBranch ttb in dict.Values)
                {
                    if (Convert.ToDateTime(ttb.ending) >= q && Convert.ToDateTime(ttb.ending) <= w)
                    {
                        sortingDate.Add(ttb.id, ttb);
                    }
                }
            }
            //дата начала от и до дата конца от
            if (date1 == false && date2 == false && date3 == false && date4 == true)
            {
                DateTime q = dateTimePicker1.Value;
                DateTime w = dateTimePicker2.Value;
                DateTime e = dateTimePicker3.Value;
                foreach (TimetableBranch ttb in dict.Values)
                {
                    if (Convert.ToDateTime(ttb.beginning) >= q && Convert.ToDateTime(ttb.beginning) <= w&&Convert.ToDateTime(ttb.ending)>=e)
                    {
                        sortingDate.Add(ttb.id, ttb);
                    }
                }
            }
            //дата начала от и до дата конца до
            if (date1 == false && date2 == false && date3 == true && date4 == false)
            {
                DateTime q = dateTimePicker1.Value;
                DateTime w = dateTimePicker2.Value;
                DateTime e = dateTimePicker4.Value;
                foreach (TimetableBranch ttb in dict.Values)
                {
                    if (Convert.ToDateTime(ttb.beginning) >= q && Convert.ToDateTime(ttb.beginning) <= w && Convert.ToDateTime(ttb.ending) <= e)
                    {
                        sortingDate.Add(ttb.id, ttb);
                    }
                }
            }
            //дата конца от и до дата начала от
            if (date1 == false && date2 == true && date3 == false && date4 == false)
            {
                DateTime q = dateTimePicker1.Value;
                DateTime w = dateTimePicker3.Value;
                DateTime e = dateTimePicker4.Value;
                foreach (TimetableBranch ttb in dict.Values)
                {
                    if (Convert.ToDateTime(ttb.beginning) >= q && Convert.ToDateTime(ttb.ending) >= w && Convert.ToDateTime(ttb.ending) <= e)
                    {
                        sortingDate.Add(ttb.id, ttb);
                    }
                }
            }
            //дата конца от и до дата начала до
            if (date1 == true && date2 == false && date3 == false && date4 ==false)
            {
                DateTime q = dateTimePicker2.Value;
                DateTime w = dateTimePicker3.Value;
                DateTime e = dateTimePicker4.Value;
                foreach (TimetableBranch ttb in dict.Values)
                {
                    if (Convert.ToDateTime(ttb.beginning) <= q && Convert.ToDateTime(ttb.ending) >= w && Convert.ToDateTime(ttb.ending) <= e)
                    {
                        sortingDate.Add(ttb.id, ttb);
                    }
                }
            }
            //дата начала от идо дата конца от и до
            if (date1 == false && date2 == false && date3 == false && date4 == false)
            {
                DateTime q = dateTimePicker1.Value;
                DateTime w = dateTimePicker2.Value;
                DateTime e = dateTimePicker3.Value;
                DateTime r = dateTimePicker4.Value;
                foreach (TimetableBranch ttb in dict.Values)
                {
                    if (Convert.ToDateTime(ttb.beginning) >= q && Convert.ToDateTime(ttb.beginning) <= w
                        && Convert.ToDateTime(ttb.ending) >= e&&Convert.ToDateTime(ttb.ending)<=r)
                    {
                        sortingDate.Add(ttb.id, ttb);
                    }
                }
            }
            //время открытия от
            if(time1==false&&time2==true&&time3==true&&time4==true)
            {
                TimeSpan q = TimeSpan.Parse(maskedTextBox1.Text);
                foreach(TimetableBranch ttb in dict.Values)
                {
                    if(TimeSpan.Parse(ttb.start)>=q)
                    {
                        sortingTime.Add(ttb.id, ttb);
                    }
                }
            }
            //время открытия до
            if (time1 == true && time2 ==false && time3 == true && time4 == true)
            {
                TimeSpan q = TimeSpan.Parse(maskedTextBox2.Text);
                foreach (TimetableBranch ttb in dict.Values)
                {
                    if (TimeSpan.Parse(ttb.start) <= q)
                    {
                        sortingTime.Add(ttb.id, ttb);
                    }
                }
            }
            //время закрытия от
            if (time1 == true && time2 == true && time3 == false && time4 == true)
            {
                TimeSpan q = TimeSpan.Parse(maskedTextBox3.Text);
                foreach (TimetableBranch ttb in dict.Values)
                {
                    if (TimeSpan.Parse(ttb.end) >= q)
                    {
                        sortingTime.Add(ttb.id, ttb);
                    }
                }
            }
            //время закрытия до
            if (time1 == true && time2 == true && time3 == true && time4 == false )
            {
                TimeSpan q = TimeSpan.Parse(maskedTextBox4.Text);
                foreach (TimetableBranch ttb in dict.Values)
                {
                    if (TimeSpan.Parse(ttb.end) <= q)
                    {
                        sortingTime.Add(ttb.id, ttb);
                    }
                }
            }
            //время открытия от и до
            if (time1 == false && time2 == false && time3 == true && time4 == true)
            {
                TimeSpan q = TimeSpan.Parse(maskedTextBox1.Text);
                TimeSpan w = TimeSpan.Parse(maskedTextBox2.Text);
                foreach (TimetableBranch ttb in dict.Values)
                {
                    if (TimeSpan.Parse(ttb.start) >= q&&TimeSpan.Parse(ttb.start)<=w)
                    {
                        sortingTime.Add(ttb.id, ttb);
                    }
                }
            }
            //время открытия от и время закрытия от
            if (time1 == false && time2 == true && time3 == false && time4 == true )
            {
                TimeSpan q = TimeSpan.Parse(maskedTextBox1.Text);
                TimeSpan w = TimeSpan.Parse(maskedTextBox3.Text);
                foreach (TimetableBranch ttb in dict.Values)
                {
                    if (TimeSpan.Parse(ttb.start) >= q && TimeSpan.Parse(ttb.end) >= w)
                    {
                        sortingTime.Add(ttb.id, ttb);
                    }
                }
            }
            //время открытия от и время закрытия до
            if (time1 == false && time2 ==true && time3 == true && time4 ==false)
            {
                TimeSpan q = TimeSpan.Parse(maskedTextBox1.Text);
                TimeSpan w = TimeSpan.Parse(maskedTextBox4.Text);
                foreach (TimetableBranch ttb in dict.Values)
                {
                    if (TimeSpan.Parse(ttb.start) >= q && TimeSpan.Parse(ttb.end) <= w)
                    {
                        sortingTime.Add(ttb.id, ttb);
                    }
                }
            }
            //время закрытия от и до 
            if (time1 == true && time2 ==true && time3 == false && time4 ==false)
            {
                TimeSpan q = TimeSpan.Parse(maskedTextBox3.Text);
                TimeSpan w = TimeSpan.Parse(maskedTextBox4.Text);
                foreach (TimetableBranch ttb in dict.Values)
                {
                    if (TimeSpan.Parse(ttb.end) >= q && TimeSpan.Parse(ttb.end) <= w)
                    {
                        sortingTime.Add(ttb.id, ttb);
                    }
                }
            }
            //время закрытия от и время открытия до
            if (time1 == true && time2 == false && time3 ==false && time4 == true)
            {
                TimeSpan q = TimeSpan.Parse(maskedTextBox2.Text);
                TimeSpan w = TimeSpan.Parse(maskedTextBox3.Text);
                foreach (TimetableBranch ttb in dict.Values)
                {
                    if (TimeSpan.Parse(ttb.start) <= q && TimeSpan.Parse(ttb.end) >= w)
                    {
                        sortingTime.Add(ttb.id, ttb);
                    }
                }
            }
            //время закрытия до и время откртытия до
            if (time1 == true && time2 == false && time3 == true && time4 == false)
            {
                TimeSpan q = TimeSpan.Parse(maskedTextBox3.Text);
                TimeSpan w = TimeSpan.Parse(maskedTextBox4.Text);
                foreach (TimetableBranch ttb in dict.Values)
                {
                    if (TimeSpan.Parse(ttb.start) <= q && TimeSpan.Parse(ttb.end) <= w)
                    {
                        sortingTime.Add(ttb.id, ttb);
                    }
                }
            }
            //время открытия от и до время закрытия от 
            if (time1 == false && time2 == false && time3 == false && time4 == true)
            {
                TimeSpan q = TimeSpan.Parse(maskedTextBox1.Text);
                TimeSpan w = TimeSpan.Parse(maskedTextBox2.Text);
                TimeSpan e = TimeSpan.Parse(maskedTextBox3.Text);
                foreach (TimetableBranch ttb in dict.Values)
                {
                    if (TimeSpan.Parse(ttb.start) >= q && TimeSpan.Parse(ttb.start) <= w&&TimeSpan.Parse(ttb.end)>=e)
                    {
                        sortingTime.Add(ttb.id, ttb);
                    }
                }
            }
            //время открытия от и до время закрытия до
            if (time1 == false && time2 == false && time3 == true && time4 == false )
            {
                TimeSpan q = TimeSpan.Parse(maskedTextBox1.Text);
                TimeSpan w = TimeSpan.Parse(maskedTextBox2.Text);
                TimeSpan e = TimeSpan.Parse(maskedTextBox4.Text);
                foreach (TimetableBranch ttb in dict.Values)
                {
                    if (TimeSpan.Parse(ttb.start) >= q && TimeSpan.Parse(ttb.start) <= w && TimeSpan.Parse(ttb.end) <= e)
                    {
                        sortingTime.Add(ttb.id, ttb);
                    }
                }
            }
            //время открытия от и время закрытия от и до
            if (time1 == false && time2 == true && time3 == false && time4 == false)
            {
                TimeSpan q = TimeSpan.Parse(maskedTextBox1.Text);
                TimeSpan w = TimeSpan.Parse(maskedTextBox3.Text);
                TimeSpan e = TimeSpan.Parse(maskedTextBox4.Text);
                foreach (TimetableBranch ttb in dict.Values)
                {
                    if (TimeSpan.Parse(ttb.start) >= q && TimeSpan.Parse(ttb.end) >= w && TimeSpan.Parse(ttb.end) <= e)
                    {
                        sortingTime.Add(ttb.id, ttb);
                    }
                }
            }
            //время открытия до и время закрытия от и до
            if (time1 == true && time2 == false && time3 == false && time4 == false )
            {
                TimeSpan q = TimeSpan.Parse(maskedTextBox2.Text);
                TimeSpan w = TimeSpan.Parse(maskedTextBox3.Text);
                TimeSpan e = TimeSpan.Parse(maskedTextBox4.Text);
                foreach (TimetableBranch ttb in dict.Values)
                {
                    if (TimeSpan.Parse(ttb.start) <= q && TimeSpan.Parse(ttb.end) >= w && TimeSpan.Parse(ttb.end) <= e)
                    {
                        sortingTime.Add(ttb.id, ttb);
                    }
                }
            }
            //время открытия от и до время закрытия от и до
            if (time1 == false && time2 == false && time3 == false && time4 == false)
            {
                TimeSpan q = TimeSpan.Parse(maskedTextBox1.Text);
                TimeSpan w = TimeSpan.Parse(maskedTextBox2.Text);
                TimeSpan e = TimeSpan.Parse(maskedTextBox3.Text);
                TimeSpan r = TimeSpan.Parse(maskedTextBox4.Text);
                foreach (TimetableBranch ttb in dict.Values)
                {
                    if (TimeSpan.Parse(ttb.start) >= q && TimeSpan.Parse(ttb.start) <= w && TimeSpan.Parse(ttb.end) >= e&&TimeSpan.Parse(ttb.end)<=r)
                    {
                        sortingTime.Add(ttb.id, ttb);
                    }
                }
            }
            if((date1==false||date2==false||date3==false||date4==false)&&(time1==false||time2==false||time3==false||time4==false))
            {
                var equal = sortingDate.Intersect(sortingTime);
                int r = 0;
                foreach(var ttb in equal)
                {
                    if(checkBox2.Checked)
                    {
                        load_real(ttb.Value, r);
                        r++;
                    }
                    else
                    {
                        load_all(ttb.Value, r);
                        r++;
                    }
                }
            }
            if((date1==false||date2==false||date3==false||date4==false)&&(time1==true&&time2==true&&time3==true&&time4==true))
            {
                int r = 0;
                foreach(TimetableBranch ttb in sortingDate.Values)
                {
                    if(checkBox2.Checked)
                    {
                        load_real(ttb, r);
                        r++;
                    }
                    else
                    {
                        load_all(ttb, r);
                        r++;
                    }
                }
            }
            if((time1==false||time2==false||time3==false||time4==false)&&(date1==true&&date2==true&&date3==true&&date4==true))
            {
                int r = 0;
                foreach(TimetableBranch ttb in sortingTime.Values)
                {
                    if(checkBox2.Checked)
                    {
                        load_real(ttb, r);
                        r++;
                    }
                    else
                    {
                        load_all(ttb, r);
                        r++;
                    }
                }
            }
            statistic("filters");
        }
        private void load_all(TimetableBranch t, int r)
        {
            int countt= 0;
            Dictionary<int, Branch> d = BranchCache.getCache();
            foreach (Branch w in d.Values)
            {
                if (w.timetable.id == t.id)
                {
                    countt++;
                }
            }
            dataGridView2.Rows.Add();
            dataGridView2[0, r].Value = t.id;
            dataGridView2[1, r].Value = countt;
            dataGridView2[2, r].Value = t.beginning;
            dataGridView2[3, r].Value = t.start;
            dataGridView2[4, r].Value = t.end;
            dataGridView2[5, r].Value = t.ending;
            if (r == 0)
            {
                firstindex = t.id;
            }
            if (r == count - 1)
            {
                lastindex = t.id;
            }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==6)
            {
                int t = e.RowIndex;
                var n =dataGridView2.Rows[t].Cells[0].Value;
                num = Convert.ToInt16(n);
                Close();
            }
            if(e.ColumnIndex==7)
            {
                int t = e.RowIndex;
                var n = dataGridView2.Rows[t].Cells[0].Value;
                TimetableBranch l = dict.FirstOrDefault(x => x.Key ==Convert.ToInt16(n)).Value;
                AddOrChangeTTB form = new AddOrChangeTTB(l, "change");
                form.StartPosition = FormStartPosition.CenterScreen;
                form.FormClosing += new FormClosingEventHandler(formclosing);
                form.ShowDialog();
            }
        }
        void formclosing(object sender, FormClosingEventArgs e)
        {
            dict.Clear();
            dict = TimetableBranchCache.getCache();
            updUsed();
            load();
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            load();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            TimetableBranch t = new TimetableBranch();
            AddOrChangeTTB form = new AddOrChangeTTB(t, "add");
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormClosing += new FormClosingEventHandler(formclosing);
            form.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex>-1)
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    sort();
                    dataGridView2.Sort(dataGridView2.Columns[0], ListSortDirection.Descending);
                }
                if (comboBox2.SelectedIndex == 1)
                {
                    sort();
                    dataGridView2.Sort(dataGridView2.Columns[0], ListSortDirection.Ascending);
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
            dateTimePicker1.Value =Convert.ToDateTime("01.01.2018 00:00:00");
            dateTimePicker2.Value = Convert.ToDateTime("01.01.2018 00:00:00");
            dateTimePicker3.Value = Convert.ToDateTime("01.01.2018 00:00:00");
            dateTimePicker4.Value = Convert.ToDateTime("01.01.2018 00:00:00");
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();
            maskedTextBox4.Clear();
            comboBox2.SelectedIndex = -1;
            statistic("all");
            load();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToString(Convert.ToInt16(textBox2.Text) - 1);
            used.Clear();
            if (textBox2.Text == "1")
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
            test();
            load();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToString(Convert.ToInt16(textBox2.Text) + 1);
            used.Clear();
            if (Convert.ToInt16(textBox2.Text) == pages[pages.Count - 1])
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
            test();
            load();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            bool a = (textBox1.Text == string.Empty);
            bool date1 = (dateTimePicker1.Value.ToShortDateString() == "01.01.2018");
            bool date2 = (dateTimePicker2.Value.ToShortDateString() == "01.01.2018");
            bool date3 = (dateTimePicker3.Value.ToShortDateString() == "01.01.2018");
            bool date4 = (dateTimePicker4.Value.ToShortDateString() == "01.01.2018");
            bool time1 = (maskedTextBox1.Text == "  :  :");
            bool time2 = (maskedTextBox2.Text == "  :  :");
            bool time3 = (maskedTextBox3.Text == "  :  :");
            bool time4 = (maskedTextBox4.Text == "  :  :");
            if (a==true&&date1==true&&date2==true&&date3==true&&date4==true&&time1==true&&time2==true&&time3==true&&time4==true)
            {
                statistic("all");
            }
            else
            {
                statistic("filters");
            }
        }
    }
}
