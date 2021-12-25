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
    public partial class FormService : Form
    {
        public int num;
        string check="";
        int idChange;
        int all;
        int count;
        int page;
        int lastindex;
        int firstindex;
        List<int> pages = new List<int>();
        Dictionary<int, Service> used = new Dictionary<int, Service>();
        Dictionary<int, Service> dict = ServicesCache.getCache();
        Dictionary<int, Cabinet> dictc = CabinetsCache.getCache();
        Dictionary<int, Worker> dictw = WorkersCache.getCache();
        int curid;
        Cabinet cab = new Cabinet();
        public FormService(string check1, int idd)
        {
            InitializeComponent();
            check = check1;
            curid = idd;
            all = dict.Count();
            load_filters();
            statistic("all");
        }
        private void load_filters()
        {
            comboBox2.Items.Add("От новых к старым");
            comboBox2.Items.Add("От старых к новым");
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
            if(check=="detWorker")
            {
                numericUpDown1.Value = dictw.FirstOrDefault(x => x.Key == curid).Value.Services.Count();
                
            }
            if(check=="detCabinet")
            {
                numericUpDown1.Value = dictc.FirstOrDefault(x => x.Key == curid).Value.Services.Count();
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
            if(check=="detCabinet")
            {
                foreach (Cabinet c in dictc.Values)
                {
                    if (c.id == curid)
                    {
                        count = c.Services.Count();
                        all = count;
                        break;
                    }
                }
                        pages.Clear();
                if(f=="filters")
                {
                    if(Convert.ToDecimal(count/numericUpDown1.Value)>1)
                    {
                        page = Convert.ToInt16(Math.Ceiling(Convert.ToDecimal(count / numericUpDown1.Value)));
                        for(int i=1;i<=page;i++)
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
                if(f=="all")
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
            if(check=="detWorker")
            {
                foreach (Worker w  in dictw.Values)
                {
                    if (w.id == curid)
                    {
                        count = w.Services.Count();
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
            if(check=="see")
            {
                for(int i=1;i<=count;i++)
                {
                    used.Add(i, dict[i]);
                }
            }
            if(check=="detCabinet")
            {
                foreach(Cabinet c in dictc.Values)
                {
                    if(c.id==curid)
                    {
                        var r = c.Services.ToList();
                        for(int i=0;i<count;i++)
                        {
                            used.Add(i+1, r[i]);
                        }
                        break;
                    }
                }
            }
            if(check=="detWorker")
            {
                foreach(Worker w in dictw.Values)
                {
                    if(w.id==curid)
                    {
                        var r = w.Services.ToList();
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
            if (textBox7.Text == "1")
            {
                button6.Enabled = false;
                button7.Enabled = true;
            }
            else
            {
                button6.Enabled = true;
                button7.Enabled = false;
            }
            if (textBox7.Text != "1" && textBox7.Text != Convert.ToString(pages[pages.Count - 1]))
            {
                button6.Enabled = true;
                button7.Enabled = true;
            }
            if (textBox7.Text == "1" && textBox7.Text == Convert.ToString(pages[pages.Count - 1]))
            {
                button6.Enabled = false;
                button7.Enabled = false;
            }
        }
        private void sort()
        {
            bool a = (textBox1.Text == string.Empty);
            bool b = (textBox2.Text == string.Empty);
            bool c = (textBox3.Text == string.Empty);//стоимость от
            bool d = (textBox4.Text == string.Empty);//стоимость до
            bool dur1 = (maskedTextBox1.Text == "  :  :");//продолжительность от
            bool dur2 = (maskedTextBox2.Text == "  :  :");//продолжительность до
            if(a==false||b==false||c==false||d==false||dur1==false||dur2==false)
            {
                dataGridView1.Rows.Clear();
            }
            if (a == false)
            {
                b = true; c = true; d = true; dur1 = true; dur2 = true;
                int t = Convert.ToInt16(textBox1.Text);
                if (check == "see")
                {
                    foreach (Service s in dict.Values)
                    {
                        if (s.id == t)
                        {
                            if (checkBox2.Checked)
                            {
                                load_real(s, 0);
                            }
                            else
                            {
                                load_all(s, 0);
                            }
                        }
                    }
                }
                if (check == "detCabinet"||check=="detWorker")
                {
                    count = all;
                    updUsed();
                    foreach (Service s in used.Values)
                    {
                        if (s.id == t)
                        {
                            if (checkBox2.Checked)
                            {
                                load_real(s, 0);
                            }
                            else
                            {
                                load_all(s, 0);
                            }
                        }
                    }
                }
            }
            if(b==false)
            {
                c = true;d = true;dur1 = true;dur2 = true;
                string t = textBox2.Text.ToLower();
                if(check=="see")
                {
                    int r = 0;
                    foreach(Service s in dict.Values)
                    {
                        bool yes = s.title.ToLower().Contains(t);
                        if(yes)
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
                }
                if(check=="detCabinet"||check=="detWorker")
                {
                    count = all;
                    updUsed();
                    int r = 0;
                    foreach(Service s in used.Values)
                    {
                        bool yes = s.title.ToLower().Contains(t);
                        if(yes)
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
                }
            }
            if(c==false&&d==true&&dur1==true&&dur2==true)
            {
                decimal t = Convert.ToDecimal(textBox3.Text);
                int r = 0;
                if(check=="see")
                {
                    foreach(Service s in dict.Values)
                    {
                        if(s.price>=t)
                        {
                            if(checkBox2.Checked)
                            {
                                load_real(s, r);
                                r++; ;
                            }
                            else
                            {
                                load_all(s, r);
                                r++;
                            }
                        }
                    }
                }
                if(check=="detCabinet"||check=="detWorker")
                {
                    count = all;
                    updUsed();
                    foreach (Service s in used.Values)
                    {
                        if(s.price>=t)
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
                }
            }
            if(c==false&&d==true&&dur1==false&&dur2==true)
            {
                int r = 0;
                decimal q = Convert.ToDecimal(textBox3.Text);
                TimeSpan w = TimeSpan.Parse(maskedTextBox1.Text);
                if(check=="see")
                {
                    foreach(Service s in dict.Values)
                    {
                        if(s.price>=q&&TimeSpan.Parse(s.duration)>=w)
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
                }
                if(check=="detCabinet" || check == "detWorker")
                {
                    count = all;
                    updUsed();
                    foreach (Service s in used.Values)
                    {
                        if (s.price >= q && TimeSpan.Parse(s.duration) >= w)
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
            }
            if (c == false && d == true && dur1 == true && dur2 == false)
            {
                int r = 0;
                decimal q = Convert.ToDecimal(textBox3.Text);
                TimeSpan w = TimeSpan.Parse(maskedTextBox2.Text);
                if(check=="all")
                {
                    foreach(Service s in dict.Values)
                    {
                        if(s.price>=q&&TimeSpan.Parse(s.duration)<=w)
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
                }
                if(check=="detCabinet" || check == "detWorker")
                {
                    count = all;
                    updUsed();
                    foreach (Service s in used.Values)
                    {
                        if (s.price >= q && TimeSpan.Parse(s.duration) <= w)
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
            }
            if(c==false&&d==true&&dur1==false&&dur2==false)
            {
                int r = 0;
                decimal q = Convert.ToDecimal(textBox3.Text);
                TimeSpan w = TimeSpan.Parse(maskedTextBox1.Text);
                TimeSpan e = TimeSpan.Parse(maskedTextBox2.Text);
                if(check=="see")
                {
                    foreach(Service s in dict.Values)
                    {
                        if(s.price>=q&&TimeSpan.Parse(s.duration)>=w&&TimeSpan.Parse(s.duration)<=e)
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
                }
                if(check=="detCabinet" || check == "detWorker")
                {
                    count = all;
                    updUsed();
                    foreach (Service s in used.Values)
                    {
                        if (s.price >= q && TimeSpan.Parse(s.duration) >= w && TimeSpan.Parse(s.duration) <= e)
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
            }
            if (c == true&&d == false&&dur1==true&&dur2==true)
            {
                int r = 0;
                decimal t = Convert.ToDecimal(textBox4.Text);
                if(check=="see")
                {
                    foreach(Service s in dict.Values)
                    {
                        if(s.price<=t)
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
                }
                if(check=="detCabinet" || check == "detWorker")
                {
                    count = all;
                    updUsed();
                    foreach (Service s in used.Values)
                    {
                        if(s.price<=t)
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
                }
            }
            if(c==true&&d==false&&dur1==false&&dur2==true)
            {
                decimal q = Convert.ToDecimal(textBox4.Text);
                TimeSpan w = TimeSpan.Parse(maskedTextBox1.Text);
                int r = 0;
                if(check=="see")
                {
                    foreach(Service s in dict.Values)
                    {
                        if(s.price<=q&&TimeSpan.Parse(s.duration)>=w)
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
                }
                if(check=="detCabinet" || check == "detWorker")
                {
                    count = all;
                    updUsed();
                    foreach (Service s in used.Values)
                    {
                        if (s.price <= q && TimeSpan.Parse(s.duration) >= w)
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
            }
            if(c==true&&d==false&&dur1==true&&dur2==false)
            {
                decimal q = Convert.ToDecimal(textBox4.Text);
                TimeSpan w = TimeSpan.Parse(maskedTextBox2.Text);
                int r = 0;
                if (check == "see")
                {
                    foreach (Service s in dict.Values)
                    {
                        if (s.price <= q && TimeSpan.Parse(s.duration) <= w)
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
                if (check == "detCabinet" || check == "detWorker")
                {
                    count = all;
                    updUsed();
                    foreach (Service s in used.Values)
                    {
                        if (s.price <= q && TimeSpan.Parse(s.duration) <= w)
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
            }
            if(c==true&&d==false&&dur1==false&&dur2==false)
            {
                decimal q = Convert.ToDecimal(textBox4.Text);
                TimeSpan w = TimeSpan.Parse(maskedTextBox1.Text);
                TimeSpan e = TimeSpan.Parse(maskedTextBox2.Text);
                int r = 0;
                if (check == "see")
                {
                    foreach (Service s in dict.Values)
                    {
                        if (s.price <= q && TimeSpan.Parse(s.duration) >= w&&TimeSpan.Parse(s.duration)<=e)
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
                if (check == "detCabinet" || check == "detWorker")
                {
                    count = all;
                    updUsed();
                    foreach (Service s in used.Values)
                    {
                        if (s.price <= q && TimeSpan.Parse(s.duration) >= w&&TimeSpan.Parse(s.duration)<=e)
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
            }
            if(c==false&&d==false&&dur1==true&&dur2==true)
            {
                int r = 0;
                decimal q = Convert.ToDecimal(textBox3.Text);
                decimal w = Convert.ToDecimal(textBox4.Text);
                if(check=="see")
                {
                    foreach(Service s in dict.Values)
                    {
                        if(s.price>=q&&s.price<=w)
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
                }
                if(check=="detCabinet" || check == "detWorker")
                {
                    count = all;
                    updUsed();
                    foreach (Service s in used.Values)
                    {
                        if(s.price>=q&&s.price<=w)
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
                }
            }
            if(c==false&&d==false&&dur1==false&&dur2==true)
            {
                int r = 0;
                decimal q = Convert.ToDecimal(textBox3.Text);
                decimal w = Convert.ToDecimal(textBox4.Text);
                TimeSpan e = TimeSpan.Parse(maskedTextBox1.Text);
                if(check=="see")
                {
                    foreach(Service s in dict.Values)
                    {
                        if(s.price>=q&&s.price<=w&&TimeSpan.Parse(s.duration)>=e)
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
                }
                if(check=="detCabinet" || check == "detWorker")
                {
                    count = all;
                    updUsed();
                    foreach (Service s in used.Values)
                    {
                        if (s.price >= q && s.price <= w && TimeSpan.Parse(s.duration) >= e)
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
            }
            if(c == false && d == false && dur1 == true && dur2 ==false)
            {
                int r = 0;
                decimal q = Convert.ToDecimal(textBox3.Text);
                decimal w = Convert.ToDecimal(textBox4.Text);
                TimeSpan e = TimeSpan.Parse(maskedTextBox2.Text);
                if (check == "see")
                {
                    foreach (Service s in dict.Values)
                    {
                        if (s.price >= q && s.price <= w && TimeSpan.Parse(s.duration) <= e)
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
                if (check == "detCabinet" || check == "detWorker")
                {
                    count = all;
                    updUsed();
                    foreach (Service s in used.Values)
                    {
                        if (s.price >= q && s.price <= w && TimeSpan.Parse(s.duration) <= e)
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
            }
            if (c == false && d == false && dur1 == false && dur2 == false)
            {
                int r = 0;
                decimal q = Convert.ToDecimal(textBox3.Text);
                decimal w = Convert.ToDecimal(textBox4.Text);
                TimeSpan e = TimeSpan.Parse(maskedTextBox1.Text);
                TimeSpan t = TimeSpan.Parse(maskedTextBox2.Text);
                if (check == "see")
                {
                    foreach (Service s in dict.Values)
                    {
                        if (s.price >= q && s.price <= w && TimeSpan.Parse(s.duration) >= e&&TimeSpan.Parse(s.duration)<=t)
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
                if (check == "detCabinet" || check == "detWorker")
                {
                    count = all;
                    updUsed();
                    foreach (Service s in used.Values)
                    {
                        if (s.price >= q && s.price <= w && TimeSpan.Parse(s.duration) >= e&&TimeSpan.Parse(s.duration)<=t)
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
            }
            if (c==true&&d==true&&dur1==false&&dur2==true)
            {
                TimeSpan t = TimeSpan.Parse(maskedTextBox1.Text);
                int r = 0;
                if(check=="see")
                {
                    foreach(Service s in dict.Values)
                    {
                        if(TimeSpan.Parse(s.duration)>=t)
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
                }
                if(check=="detCabinet" || check == "detWorker")
                {
                    count = all;
                    updUsed();
                    foreach (Service s in used.Values)
                    {
                        if(TimeSpan.Parse(s.duration)>=t)
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
                }
            }
            if(c==true&&d==true&&dur1==true&&dur2==false)
            {
                TimeSpan t = TimeSpan.Parse(maskedTextBox2.Text);
                int r = 0;
                if(check=="see")
                {
                    foreach(Service s in dict.Values)
                    {
                        if(TimeSpan.Parse(s.duration)<=t)
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
                }
                if(check=="detCabinet" || check == "detWorker")
                {
                    count = all;
                    updUsed();
                    foreach (Service s in used.Values)
                    {
                        if (TimeSpan.Parse(s.duration) <= t)
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
                }
            }
            if(c==true&&d==true&&dur1==false&&dur2==false)
            {
                int r = 0;
                TimeSpan q = TimeSpan.Parse(maskedTextBox1.Text);
                TimeSpan w = TimeSpan.Parse(maskedTextBox2.Text);
                if(check=="see")
                {
                    foreach(Service s in dict.Values)
                    {
                        if(TimeSpan.Parse(s.duration)>=q&&TimeSpan.Parse(s.duration)<=w)
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
                }
                if(check=="detCabinet" || check == "detWorker")
                {
                    count = all;
                    updUsed();
                    foreach (Service s in used.Values)
                    {
                        if(TimeSpan.Parse(s.duration)>=q&&TimeSpan.Parse(s.duration)<=w)
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
                }
            }
        }
        private void load()
        {
            if (check == "see")
            {
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.ReadOnly = true;
                dataGridView1.Rows.Clear();
                int r = 0;
                foreach (Service s in used.Values)
                {
                    int i = 1;
                    if (i <= count)
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
                        i++;
                    }
                }
            }
            if(check=="choose")
            {
                dataGridView1.Columns[5].Visible = true;
                dataGridView1.ReadOnly = true;
                dataGridView1.Rows.Clear();
                int r = 0;
                foreach (Service s in used.Values)
                {
                    int i = 1;
                    if (i <= count)
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
                        i++;
                    }
                }
            }
            if(check=="detCabinet")
            {
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.ReadOnly = true;
                dataGridView1.Rows.Clear();
                int r = 0;
                foreach (Service s in used.Values)
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
            if(check=="detWorker")
            {
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.ReadOnly = true;
                dataGridView1.Rows.Clear();
                int r = 0;
                foreach(Service  s in used.Values)
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
  
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            load();
        }
        private void load_real(Service s, int r)
        {
            if (s.date_delete == Convert.ToDateTime("31.12.9999 12:00:00"))
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, r].Value = s.id;
                dataGridView1[1, r].Value = s.title;
                dataGridView1[2, r].Value = s.price;
                dataGridView1[3, r].Value = s.duration;
                dataGridView1[4, r].Value = s.notes;
                if (r == 0)
                {
                    firstindex = s.id;
                }
                if (r == count - 1)
                {
                    lastindex = s.id;
                }
            }
        }
        private void load_all(Service s, int r)
        {
            dataGridView1.Rows.Add();
            dataGridView1[0, r].Value = s.id;
            dataGridView1[1, r].Value = s.title;
            dataGridView1[2, r].Value = s.price;
            dataGridView1[3, r].Value = s.duration;
            dataGridView1[4, r].Value = s.notes;
            if (r == 0)
            {
                firstindex = s.id;
            }
            if (r == count - 1)
            {
                lastindex = s.id;
            }
        }
        private void choice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int t = e.RowIndex;
                var h = dataGridView1.Rows[t].Cells[0].Value;
                idChange = Convert.ToInt16(h);
                seeService();
            }
        }
        private void seeService()
        {
            Service see = dict.FirstOrDefault(t => t.Key == idChange).Value;
            SeeService form = new SeeService(see);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormClosing += new FormClosingEventHandler(formCLosed);
            form.ShowDialog();

        }
        private void newService_CLick(object sender, EventArgs e)
        {
            Service serv = new Service();
            serv.id = curid;
            AddOrChangeService form = new AddOrChangeService(serv, "add");
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormClosing+=new FormClosingEventHandler(formCLosed);
            form.ShowDialog();
        }
        void formCLosed(object sender, FormClosingEventArgs e)
        {
            ServicesCache.updateCache();
            dict.Clear();
            dict = ServicesCache.getCache();
            updUsed();
            load();
        }
        private void button3_Click(object sender, EventArgs e)
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
            textBox3.Clear();
            textBox4.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            comboBox2.SelectedIndex = -1;
            statistic("all");
            load();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty&&textBox2.Text == string.Empty&&textBox3.Text == string.Empty&&textBox4.Text == string.Empty && maskedTextBox1.Text == "  :  :" && maskedTextBox2.Text == "  :  :")
            {
                statistic("all");
            }
            else
            {
                statistic("filters");
            }
        }
        private void button7_Click(object sender, EventArgs e)
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
            if(check=="detWorker")
            {
                var r = dictw.FirstOrDefault(x => x.Key == curid).Value.Services.ToList();
                int ind = r.FindIndex(x => x.id == lastindex);
                    for (int i = 1; i <= count; i++)
                    {
                        used.Add(r[ind + i].id, r[ind + i]);
                    }
            }
            if(check=="detCabinet")
            {
                var r = dictc.FirstOrDefault(x => x.Key == curid).Value.Services.ToList();
                int ind = r.FindIndex(x => x.id == lastindex);
                for(int i=1;i<=count;i++)
                {
                    used.Add(r[ind + i].id, r[ind + i]);
                }
            }
            test();
            load();
        }
        private void button6_Click(object sender, EventArgs e)
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
            if (check == "detWorker")
            {
                var r = dictw.FirstOrDefault(x => x.Key == curid).Value.Services.ToList();
                int ind = r.FindIndex(x => x.id == firstindex);
                for (int i = 1; i <= count; i++)
                {
                    used.Add(r[ind - i].id, r[ind - i]);
                }
            }
            if (check == "detCabinet")
            {
                var r = dictc.FirstOrDefault(x => x.Key == curid).Value.Services.ToList();
                int ind = r.FindIndex(x => x.id == firstindex);
                for (int i = 1; i <= count; i++)
                {
                    used.Add(r[ind - i].id, r[ind - i]);
                }
            }
            test();
            load();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==5)
            {
                int t = e.RowIndex;
                num = Convert.ToInt16(dataGridView1.Rows[t].Cells[0].Value);
                Close();
            }
        }
    }
}
