using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.Entity;

namespace sk
{
    public partial class FormVisit : Form
    {
        string check;
        int curid;
        int all;
        int count;
        int page;
        int lastindex;
        int firstindex;
        List<int> pages = new List<int>();
        Dictionary<int, Visit> used = new Dictionary<int, Visit>();
        Dictionary<int, Client> dictcl = ClientsCache.getCache();
        Dictionary<int, Cabinet> dictcab = CabinetsCache.getCache();
        Dictionary<int, Service> dicts = ServicesCache.getCache();
        Dictionary<int, Worker> dictw = WorkersCache.getCache();
        Dictionary<int, Attendance> att = AttendanceCache.getCache();
        public FormVisit(string check1, int id)
        {
            InitializeComponent();
            curid = id;
            check = check1;
            load_filters();
            statistic("all");
        }
        private void load_filters()
        {
            comboBox2.Items.Add("От новых к старым");
            comboBox2.Items.Add("От старых к новым");
            if(check=="see")
            {
                using (VisitContext vc = new VisitContext())
                {
                    var visits = vc.Visits.Include("Client").Include("Branch").ToList();
                    all = visits.Count();
                    if (all > numericUpDown1.Value)
                    {
                        count = Convert.ToInt16(numericUpDown1.Value);
                        int i = 1;
                        if (i <= count)
                        {
                            foreach (var v in visits)
                            {
                                used.Add(v.id, v);
                            }
                            i++;
                        }
                    }
                    else
                    {
                        numericUpDown1.Value = all;
                        count = all;
                        int i = 1;
                        if(i<=count)
                        {
                            foreach(var v in visits)
                            {
                                used.Add(v.id, v);
                            }
                            i++;
                        }
                    }
                }
            }
            if(check=="detClient")
            {
                numericUpDown1.Value = dictcl.FirstOrDefault(x => x.Key == curid).Value.Visits.Count;
            }
            if(check=="detCabinet")
            {
                numericUpDown1.Value = dictcab.FirstOrDefault(x => x.Key == curid).Value.Visits.Count;
            }
            if(check=="detWorker")
            {
                numericUpDown1.Value = dictw.FirstOrDefault(x => x.Key == curid).Value.Visits.Count();
            }
            if(check=="detService")
            {
                numericUpDown1.Value = dicts.FirstOrDefault(x => x.Key == curid).Value.Visits.Count();
            }
        }
        private void statistic(string f)
        {
            if(check=="see")
            {
                pages.Clear();
                if(f=="filters")
                {
                    count = dataGridView2.Rows.Count;
                    if(Convert.ToDecimal(count/numericUpDown1.Value)>1)
                    {
                        page = Convert.ToInt16(Math.Ceiling(Convert.ToDecimal(count / numericUpDown1.Value)));
                        for(int i=1;i<=page; i++)
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
                    count = all;
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
                    load();
                }
                textBox7.Text = "1";
                test();
            }
            if(check=="detClient")
            {
                count = dictcl.FirstOrDefault(x => x.Key == curid).Value.Visits.Count();
                all = count;
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
                textBox7.Text = "1";
                test();
            }
            if (check == "detCabinet")
            {
                count = dictcab.FirstOrDefault(x => x.Key == curid).Value.Visits.Count();
                all = count;
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
                textBox7.Text = "1";
                test();
            }
            if (check == "detService")
            {
                count = dicts.FirstOrDefault(x => x.Key == curid).Value.Visits.Count();
                all = count;
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
                textBox7.Text = "1";
                test();
            }
            if (check == "detWorker")
            {
                count = dictw.FirstOrDefault(x => x.Key == curid).Value.Visits.Count();
                all = count;
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
                textBox7.Text = "1";
                test();
            }
        }
        private void updUsed()
        {
            used.Clear();
            if (check == "see")
            {
                int i = 1;
                using (VisitContext vc = new VisitContext())
                {
                    var visits = vc.Visits.Include("Client").Include("Branch").ToList();
                    foreach (var v in visits)
                    {
                        if (i <= count) 
                        {
                            used.Add(v.id, v);
                        }
                        i++;
                    }
                }
            }
            if(check=="detClient")
            {
                var t = dictcl.FirstOrDefault(x => x.Key == curid).Value.Visits.ToList();
                for(int i=0;i<count;i++)
                {
                    used.Add(i + 1, t[i]);
                }
            }
            if(check=="detCabinet")
            {
                foreach (Attendance a in att.Values)
                {
                    if (curid == a.cabinet.id)
                    {
                        using (VisitContext vc = new VisitContext())
                        {
                            var visits = vc.Visits.Include("CLient").Include("Branch").ToList();
                            foreach (var v in visits)
                            {
                                if (a.visit.id == v.id)
                                {
                                    used.Add(v.id, v);
                                }
                            }
                        }
                    }
                }
            }
            if(check=="detWorker")
            {
                foreach (Attendance a in att.Values)
                {
                    if (curid == a.worker.id)
                    {
                        using (VisitContext vc = new VisitContext())
                        {
                            var visits = vc.Visits.Include("Client").Include("Branch").ToList();
                            foreach (var v in visits)
                            {
                                if (a.visit.id == v.id)
                                {
                                    used.Add(v.id, v);
                                }
                            }
                        }
                    }
                }
            }
            if(check=="detService")
            {
                foreach(Attendance a in att.Values)
                {
                    if(curid==a.service.id)
                    {
                        using (VisitContext vc = new VisitContext())
                        {
                            var visits=vc.Visits.Include("Client").Include("Branch").ToList();
                            foreach(var v in visits)
                            {
                                if(a.visit.id==v.id)
                                {
                                    used.Add(v.id, v);
                                }
                            }
                        }
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
        private void load()
        {
            dataGridView2.Columns[7].Visible = false;
            dataGridView2.Rows.Clear();
            dataGridView2.ReadOnly = true;
            if (check=="see")
            {
                int r = 0;
                foreach (Visit v in used.Values)
                {
                    int i = 1;
                    if (i <= count)
                    {
                        if (checkBox2.Checked)
                        {
                            load_real(v, r);
                        }
                        else
                        {
                            load_all(v, r);
                        }
                        r++;
                        i++;
                    }
                }
            }
            if(check=="detClient")
            {
                int r = 0;
                foreach(Visit v in used.Values)
                {
                    if(checkBox2.Checked)
                    {
                        load_real(v, r);
                    }
                    else
                    {
                        load_all(v, r);
                    }
                    r++;
                }
            }
            if(check=="detWorker")
            {
                int r = 0;
                foreach(Visit v in used.Values)
                {
                    if(checkBox2.Checked)
                    {
                        load_real(v, r);
                    }
                    else
                    {
                        load_all(v, r);
                    }
                    r++;
                }
            }
            if (check == "detCabinet")
            {
                int r = 0;
                foreach(Visit v in used.Values)
                {
                    if (checkBox2.Checked)
                    {
                        load_real(v, r);
                    }
                    else
                    {
                        load_all(v, r);
                    }
                    r++;
                }
            }
            if(check=="detService")
            {
                int r = 0;
                foreach(Visit v in used.Values)
                {
                    if(checkBox2.Checked)
                    {
                        load_real(v, r);
                    }
                    else
                    {
                        load_all(v, r);
                    }
                    r++;
                }
            }
        }
        private void load_real(Visit v, int r)
        {
            if(v.date_delete==Convert.ToDateTime("31.12.9999 12:00:00"))
            {
                dataGridView2.Rows.Add();
                dataGridView2[0, r].Value = v.id;
                dataGridView2[1, r].Value = v.client.name;
                dataGridView2[2, r].Value = v.branch.name;
                dataGridView2[3, r].Value = v.date_visit;
                dataGridView2[4, r].Value = v.duration;
                dataGridView2[5, r].Value = v.price;
                dataGridView2[6,r].Value=v.notes;
                if(r==0)
                {
                    firstindex = v.id;
                }
                if(r==count-1)
                {
                    lastindex = v.id;
                }
            }
        }
        private void load_all(Visit v , int r)
        {
            dataGridView2.Rows.Add();
            dataGridView2[0, r].Value = v.id;
            dataGridView2[1, r].Value = v.client.name;
            dataGridView2[2, r].Value = v.branch.name;
            dataGridView2[3, r].Value = v.date_visit;
            dataGridView2[4, r].Value = v.duration;
            dataGridView2[5, r].Value = v.price;
            dataGridView2[6, r].Value = v.notes;
            if (r == 0)
            {
                firstindex = v.id;
            }
            if (r == count - 1)
            {
                lastindex = v.id;
            }
        }
        private void sort()
        {
            bool a = (textBox1.Text == string.Empty);//номер посещения
            bool b = (label2.Text == "Клиент");//имя клиента
            bool c = (label3.Text == "Филиал");//ид филиала
            bool d = (label13.Text == "Работник");//id работника
            bool e = (label15.Text == "Услуга");//ид услуги
            List<Visit> rez1 = new List<Visit>();
            bool date1 = (dateTimePicker1.Value.ToShortDateString() == "01.01.2018");//дата и время начала
            bool date2 = (dateTimePicker2.Value.ToShortDateString() == "01.01.2018");//дата и время конца
            List<Visit> rez2 = new List<Visit>();
            bool dur1 = (maskedTextBox1.Text == "  :  :");//продолжительность от
            bool dur2 = (maskedTextBox2.Text == "  :  :");//продолжительность до
            List<Visit> rez3 = new List<Visit>();
            bool price1 = (textBox3.Text == string.Empty);//цена от
            bool price2 = (textBox4.Text == string.Empty);//цена до
            List<Visit> rez4 = new List<Visit>();
            if (a == false || b == false || c == false == false || d == false || e == false || date1 == false || date2 == false || dur1 == false || dur2 == false || price1 == false || price2 == false)
            {
                dataGridView2.Rows.Clear();
            }
            if (a == false)
            {
                int t = Convert.ToInt16(textBox1.Text);
                b = true; c = true; d = true; e = true; date1 = true; date2 = true; dur1 = true; dur2 = true; price1 = true; price2 = true;
                using (VisitContext vc = new VisitContext())
                {
                    var visits = vc.Visits.Include("Client").Include("Branch").ToList();
                    foreach (Visit v in visits)
                    {
                        if (v.id == t)
                        {
                            if (checkBox2.Checked)
                            {
                                load_real(v, 0);
                            }
                            else
                            {
                                load_all(v, 0);
                            }
                            break;
                        }
                    }
                }
            }
            if (b == false && c == true && d == true && e == true)
            {
                string name = label2.Text;
                using (VisitContext vc = new VisitContext())
                {
                    rez1 = vc.Visits.Include("Client").Include("Branch").Where(x => x.client.name.Contains(name)).ToList();
                }
            }
            if (b == true && c == false && d == true && d == true)
            {
                int r = Convert.ToInt16(label3.Text);
                using (VisitContext vc = new VisitContext())
                {
                    rez1 = vc.Visits.Include("Client").Include("Branch").Where(x => x.branch.id == r).ToList();
                }
            }
            if (b == true && c == true & d == false && e == true)
            {
                int r = Convert.ToInt16(label13.Text);
                foreach (Attendance at in att.Values)
                {
                    if (at.worker.id == r)
                    {
                        rez1.Add(at.visit);
                    }
                }
            }
            if (b == true && c == true & d == true && e == false)
            {
                int r = Convert.ToInt16(label15.Text);
                foreach (Attendance at in att.Values)
                {
                    if (at.service.id == r)
                    {
                        rez1.Add(at.visit);
                    }
                }
            }
            if (b == false && c == false && d == true && e == true)
            {
                int t = Convert.ToInt16(label3.Text);
                string name = label2.Text;
                using (VisitContext vc = new VisitContext())
                {
                    rez1 = vc.Visits.Include("Client").Include("Branch").Where(x => x.client.name.Contains(name)).Where(x => x.branch.id == t).ToList();
                }

            }
            if (b == false && c == true && d == false && e == true)
            {
                string h = label2.Text;
                int t = Convert.ToInt16(label13.Text);
                foreach (Attendance at in att.Values)
                {
                    if (at.visit.client.name == h && at.worker.id == t)
                    {
                        rez1.Add(at.visit);
                    }
                }
            }
            if (b == false && c == true && d == true && e == false)
            {
                string h = label2.Text;
                int r = Convert.ToInt16(label15.Text);
                foreach (Attendance at in att.Values)
                {
                    if (at.service.id == r && at.visit.client.name == h)
                    {
                        rez1.Add(at.visit);
                    }
                }
            }
            if (b == true && c == false && d == false && e == true)
            {
                int br = Convert.ToInt16(label3.Text);
                int w = Convert.ToInt16(label13.Text);
                foreach (Attendance at in att.Values)
                {
                    if (at.worker.id == w && at.visit.branch.id == br)
                    {
                        rez1.Add(at.visit);
                    }
                }
            }
            if (b == true && c == false && d == true && e == false)
            {
                int br = Convert.ToInt16(label3.Text);
                int s = Convert.ToInt32(label15.Text);
                foreach (Attendance at in att.Values)
                {
                    if (at.service.id == s && at.visit.branch.id == br)
                    {
                        rez1.Add(at.visit);
                    }
                }
            }
            if (b == true && c == true && d == false && e == false)
            {
                int w = Convert.ToInt16(label13.Text);
                int s = Convert.ToInt16(label15.Text);
                foreach (Attendance at in att.Values)
                {
                    if (at.worker.id == w && at.service.id == s)
                    {
                        rez1.Add(at.visit);
                    }
                }
            }
            if (b == false && c == false && d == false && e == true)
            {
                string cl = label2.Text;
                int br = Convert.ToInt16(label3.Text);
                int w = Convert.ToInt16(label13.Text);
                foreach (Attendance at in att.Values)
                {
                    if (at.visit.client.name == cl && at.visit.branch.id == br && at.worker.id == w)
                    {
                        rez1.Add(at.visit);
                    }
                }
            }
            if (b == false && c == false && d == true && e == false)
            {
                string cl = label2.Text;
                int br = Convert.ToInt16(label3.Text);
                int ser = Convert.ToInt16(label15.Text);
                foreach (Attendance at in att.Values)
                {
                    if (at.visit.client.name == cl && at.visit.branch.id == br && at.service.id == ser)
                    {
                        rez1.Add(at.visit);
                    }
                }
            }
            if (b == false && c == true && d == false && e == false)
            {
                string cl = label2.Text;
                int w = Convert.ToInt16(label13.Text);
                int s = Convert.ToInt16(label15.Text);
                foreach (Attendance at in att.Values)
                {
                    if (at.visit.client.name == cl && at.worker.id == w && at.service.id == s)
                    {
                        rez1.Add(at.visit);
                    }
                }
            }
            if (b = true && c == false && d == false && e == false)
            {
                int br = Convert.ToInt16(label3.Text);
                int w = Convert.ToInt16(label13.Text);
                int s = Convert.ToInt16(label15.Text);
                foreach (Attendance at in att.Values)
                {
                    if (at.visit.branch.id == br && at.worker.id == w && at.service.id == s)
                    {
                        rez1.Add(at.visit);
                    }
                }
            }
            if (date1 == false && date2 == true)
            {
                DateTime q = dateTimePicker1.Value;
                using (VisitContext vc = new VisitContext())
                {
                    rez2 = vc.Visits.Where(x => x.date_visit >= q).ToList();
                }
            }
            if (date1 == true && date2 == false)
            {
                DateTime q = dateTimePicker2.Value;
                using (VisitContext vc = new VisitContext())
                {
                    rez2 = vc.Visits.Where(x => x.date_visit >= q).ToList();
                }
            }
            if (date1 == false && date2 == false)
            {
                DateTime q = dateTimePicker1.Value;
                DateTime w = dateTimePicker2.Value;
                using (VisitContext vc = new VisitContext())
                {
                    rez2 = vc.Visits.Where(x => x.date_visit >= q).Where(x => x.date_visit <= w).ToList();
                }
            }
            if (dur1 == false && dur2 == true)
            {
                TimeSpan q = TimeSpan.Parse(maskedTextBox1.Text);
                using (VisitContext vc = new VisitContext())
                {
                    rez3 = vc.Visits.Where(x => TimeSpan.Parse(x.duration) >= q).ToList();
                }
            }
            if (dur1 == true && dur2 == false)
            {
                TimeSpan q = TimeSpan.Parse(maskedTextBox2.Text);
                using (VisitContext vc = new VisitContext())
                {
                    rez3 = vc.Visits.Where(x => TimeSpan.Parse(x.duration) <= q).ToList();
                }
            }
            if (dur1 == false && dur2 == false)
            {
                TimeSpan q = TimeSpan.Parse(maskedTextBox1.Text);
                TimeSpan w = TimeSpan.Parse(maskedTextBox2.Text);
                using (VisitContext vc = new VisitContext())
                {
                    rez3 = vc.Visits.Where(x => TimeSpan.Parse(x.duration) >= q).Where(x => TimeSpan.Parse(x.duration) <= w).ToList();
                }
            }
            if (price1 == false && price2 == true)
            {
                decimal q = Convert.ToDecimal(textBox3.Text);
                using (VisitContext vc = new VisitContext())
                {
                    rez4 = vc.Visits.Where(x => x.price >= q).ToList();
                }
            }
            if (price1 == true && price2 == false)
            {
                decimal q = Convert.ToDecimal(textBox4.Text);
                using (VisitContext vc = new VisitContext())
                {
                    rez4 = vc.Visits.Where(x => x.price <= q).ToList();
                }
            }
            if (price1 == false && price2 == false)
            {
                decimal q = Convert.ToDecimal(textBox3.Text);
                decimal w = Convert.ToDecimal(textBox4.Text);
                using (VisitContext vc = new VisitContext())
                {
                    rez4 = vc.Visits.Where(x => x.price >= q).Where(x => x.price <= w).ToList();
                }
            }
            if ((b == false || c == false || d == false || e == false) && (date1 == false || date2 == false) && (dur1 == false || dur2 == false) && (price1 == false || price2 == false))
            {
                List<Visit> rez = rez1.Intersect(rez2).Intersect(rez3).Intersect(rez4).ToList();
                int r = 0;
                foreach (Visit v in rez)
                {
                    if (checkBox2.Checked)
                    {
                        load_real(v, r);
                    }
                    else
                    {
                        load_all(v, r);
                    }
                    r++;
                }
            }
            if ((b == false || c == false || d == false || e == false) && (date1 == false || date2 == false) && (dur1 == false || dur2 == false))
            {
                List<Visit> rez = rez1.Intersect(rez2).Intersect(rez3).ToList();
                int r = 0;
                foreach (Visit v in rez)
                {
                    if (checkBox2.Checked)
                    {
                        load_real(v, r);
                    }
                    else
                    {
                        load_all(v, r);
                    }
                    r++;
                }
            }
            if ((b == false || c == false || d == false || e == false) && (date1 == false || date2 == false) && (price1 == false || price2 == false))
            {
                List<Visit> rez = rez1.Intersect(rez2).Intersect(rez4).ToList();
                int r = 0;
                foreach (Visit v in rez)
                {
                    if (checkBox2.Checked)
                    {
                        load_real(v, r);
                    }
                    else
                    {
                        load_all(v, r);
                    }
                    r++;
                }
            }
            if ((b == false || c == false || d == false || e == false) && (dur1 == false || dur2 == false) && (price1 == false || price2 == false))
            {
                List<Visit> rez = rez1.Intersect(rez3).Intersect(rez4).ToList();
                int r = 0;
                foreach (Visit v in rez)
                {
                    if (checkBox2.Checked)
                    {
                        load_real(v, r);
                    }
                    else
                    {
                        load_all(v, r);
                    }
                    r++;
                }
            }
            if ((date1 == false || date2 == false) && (dur1 == false || dur2 == false) && (price1 == false||price2==false))
            {
                List<Visit> rez = rez2.Intersect(rez3).Intersect(rez4).ToList();
                int r = 0;
                foreach(Visit v in rez)
                {
                    if(checkBox2.Checked)
                    {
                        load_real(v, r);
                    }
                    else
                    {
                        load_all(v, r);
                    }
                    r++;
                }
            }
            if((b==false||c==false||d==false||e==false)&&(date1==false||date2==false))
            {
                List<Visit> rez = rez1.Intersect(rez2).ToList();
                int r = 0;
                foreach(Visit v in rez)
                {
                    if(checkBox2.Checked)
                    {
                        load_real(v, r);
                    }
                    else
                    {
                        load_all(v, r);
                    }
                    r++;
                }
            }
            if((b==false||c==false||d==false||e==false)&&(dur1==false||dur2==false))
            {
                List<Visit> rez = rez1.Intersect(rez3).ToList();
                int r = 0;
                foreach(Visit v in rez)
                {
                    if(checkBox2.Checked)
                    {
                        load_real(v, r);
                    }
                    else
                    {
                        load_all(v, r);
                    }
                    r++;
                }
            }
            if((b==false||c==false||d==false||e==false)&&(price1==false||price2==false))
            {
                List<Visit> rez = rez1.Intersect(rez4).ToList();
                int r = 0;
                foreach(Visit v in rez)
                {
                    if(checkBox2.Checked)
                    {
                        load_real(v, r);
                    }
                    else
                    {
                        load_all(v, r);
                    }
                    r++;
                }
            }
            if((date1==false||date2==false)&&(dur1==false||dur2==false))
            {
                List<Visit> rez = rez2.Intersect(rez3).ToList();
                int r = 0;
                foreach(Visit v in rez)
                {
                    if(checkBox2.Checked)
                    {
                        load_real(v, r);
                    }
                    else
                    {
                        load_all(v, r);
                    }
                    r ++;
                }
            }
            if((date1==false||date2==false)&&(price1==false||price2==false))
            {
                List<Visit> rez = rez2.Intersect(rez4).ToList();
                int r = 0;
                foreach(Visit v in rez)
                {
                    if(checkBox2.Checked)
                    {
                        load_real(v, r);
                    }
                    else
                    {
                        load_all(v, r);
                    }
                    r++;
                }
            }
            if((dur1==false||dur2==false)&&(price1==false||price2==false))
            {
                List<Visit> rez = rez3.Intersect(rez4).ToList();
                int r = 0;
                foreach(Visit v in rez)
                {
                    if(checkBox2.Checked)
                    {
                        load_real(v, r);
                    }
                    else
                    {
                        load_all(v, r);
                    }
                    r++;
                }
            }
            if((date1==true&&date2==true)&&(dur1==true&&dur2==true)&&(price1==true&&price2==true))
            {
                int r = 0;
                foreach(Visit v in rez1)
                {
                    if(checkBox2.Checked)
                    {
                        load_real(v, r);
                    }
                    else
                    {
                        load_all(v, r);
                    }
                    r++;
                }
            }
            if((b==true&&c==true&&d==true&&e==true)&&(dur1==true&&dur2==true)&&(price1==true&&price2==true))
            {
                int r = 0;
                foreach(Visit v in rez2)
                {
                    if(checkBox2.Checked)
                    {
                        load_real(v, r);
                    }
                    else
                    {
                        load_all(v, r);
                    }
                    r++;
                }
            }
            if((b==true&&c==true&&d==true&&e==true)&&(date1==true&&date2==true)&&(price1==true&&price2==true))
            {
                int r = 0;
                foreach(Visit v in rez3)
                {
                    if(checkBox2.Checked)
                    {
                        load_real(v, r);
                    }
                    else
                    {
                        load_all(v, r);
                    }
                    r++;
                }
            }
            if((b==true&&c==true&&d==true&&e==true)&&(date1==true&&date2==true)&&(dur1==true&&dur2==true))
            {
                int r = 0;
                foreach(Visit v in rez4)
                {
                    if(checkBox2.Checked)
                    {
                        load_real(v, r);
                    }
                    else
                    {
                        load_all(v, r);
                        r++;
                    }
                }
            }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int t = e.RowIndex;
                var h = dataGridView2.Rows[t].Cells[0].Value;
                curid = Convert.ToInt32(h);
            }
            using (VisitContext vc = new VisitContext())
            {
                var visits = vc.Visits.Include("Client").Include("Branch").ToList();
                foreach (var v in visits)
                {
                    if (v.id == curid)
                    {
                       Visit visit = v;
                        SeeVisit form = new SeeVisit(visit);
                        form.StartPosition = FormStartPosition.CenterScreen;
                        form.ShowDialog();
                    }
                }
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            load();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            FormClient form = new FormClient("choose", 0);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
            label2.Text = Convert.ToString(form.num);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            FormBranch form = new FormBranch("choose");
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
            label3.Text = Convert.ToString(form.num);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            FormWorker form = new FormWorker("choose", 0);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
            label13.Text = Convert.ToString(form.num);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            FormService form = new FormService("choose", 0);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
            label15.Text = Convert.ToString(form.num);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex > -1)
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
            label2.Text = "Клиент";
            label3.Text = "Филиал";
            label13.Text = "Работник";
            label15.Text = "Услуга";
            dateTimePicker1.Value = Convert.ToDateTime("01.01.2018 00:00:00");
            dateTimePicker2.Value = Convert.ToDateTime("01.01.2018 00:00:00");
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox2.SelectedIndex = -1;
            statistic("all");
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
                    int i = 1;                    
                    using(VisitContext vc = new VisitContext())
                    {
                        var visits = vc.Visits.Include("Client").Include("Branch").ToList();
                        foreach(Visit v in visits)
                        {
                            if(i<=count)
                            {
                                used.Add(v.id, v);
                            }
                            i++;
                        }
                    }
                }
                else
                {
                    int i = firstindex - count;
                    using (VisitContext vc = new VisitContext())
                    {
                        var visits = vc.Visits.Include("Client").Include("Branch").ToList();
                        foreach (Visit v in visits)
                        {
                            if (i <lastindex)
                            {
                                used.Add(v.id, v);
                            }
                            i++;
                        }
                    }
                }
            }
            if (check == "detWorker")
            {
                var r = dictw.FirstOrDefault(x => x.Key == curid).Value.Visits.ToList();
                int ind = r.FindIndex(x => x.id == firstindex);
                for (int i = 1; i <= count; i++)
                {
                    used.Add(r[ind - i].id, r[ind - i]);
                }
            }
            if (check == "detCabinet")
            {
                var r = dictcab.FirstOrDefault(x => x.Key == curid).Value.Visits.ToList();
                int ind = r.FindIndex(x => x.id == firstindex);
                for (int i = 1; i <= count; i++)
                {
                    used.Add(r[ind - i].id, r[ind - i]);
                }
            }
            if(check=="detClient")
            {
                var r = dictcl.FirstOrDefault(x => x.Key == curid).Value.Visits.ToList();
                int ind = r.FindIndex(x => x.id == firstindex);
                for(int i=1;i<=count;i++)
                {
                    used.Add(r[ind - 1].id, r[ind - 1]);
                }
            }
            if(check=="detService")
            {
                var v = dicts.FirstOrDefault(x => x.Key == firstindex).Value.Visits.ToList();
                int ind = v.FindIndex(x => x.id == firstindex);
                for(int i=1;i<=count;i++)
                {
                    used.Add(v[ind - 1].id, v[ind - 1]);
                }
            }
            test();
            load();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            textBox7.Text = Convert.ToString(Convert.ToInt16(textBox7.Text) + 1);
            used.Clear();
            if (check == "see")
            {
                if (textBox7.Text == Convert.ToString(pages[pages.Count-1]))
                {
                    int i = lastindex + 1; ;
                    using (VisitContext vc = new VisitContext())
                    {
                        var visits = vc.Visits.Include("Client").Include("Branch").Where(x=>x.id>=i).ToList();
                        foreach (Visit v in visits)
                        {
                            if (i <all+1)
                            {
                                used.Add(v.id, v);
                            }
                            i++;
                        }
                    }
                }
                else
                {
                    int i = lastindex + 1;
                    using (VisitContext vc = new VisitContext())
                    {
                        var visits = vc.Visits.Include("Client").Include("Branch").Where(x=>x.id>=i).ToList();
                        foreach (Visit v in visits)
                        {
                            if (i < lastindex+count+1)
                            {
                                used.Add(v.id, v);
                            }
                            i++;
                        }
                    }
                }
            }
            if (check == "detWorker")
            {
                var r = dictw.FirstOrDefault(x => x.Key == curid).Value.Visits.ToList();
                int ind = r.FindIndex(x => x.id == lastindex);
                for (int i = 1; i <= count; i++)
                {
                    used.Add(r[ind - i].id, r[ind - i]);
                }
            }
            if (check == "detCabinet")
            {
                var r = dictcab.FirstOrDefault(x => x.Key == curid).Value.Visits.ToList();
                int ind = r.FindIndex(x => x.id == lastindex);
                for (int i = 1; i <= count; i++)
                {
                    used.Add(r[ind - i].id, r[ind - i]);
                }
            }
            if (check == "detClient")
            {
                var r = dictcl.FirstOrDefault(x => x.Key == curid).Value.Visits.ToList();
                int ind = r.FindIndex(x => x.id == lastindex);
                for (int i = 1; i <= count; i++)
                {
                    used.Add(r[ind - 1].id, r[ind - 1]);
                }
            }
            if (check == "detService")
            {
                var v = dicts.FirstOrDefault(x => x.Key == firstindex).Value.Visits.ToList();
                int ind = v.FindIndex(x => x.id == lastindex);
                for (int i = 1; i <= count; i++)
                {
                    used.Add(v[ind - 1].id, v[ind - 1]);
                }
            }
            test();
            load();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == string.Empty&&label2.Text == "Клиент"&&label3.Text == "Филиал"&&label13.Text == "Работник"
                &&label15.Text == "Услуга"&&dateTimePicker1.Value.ToShortDateString() == "01.01.2018"
                &&dateTimePicker2.Value.ToShortDateString() == "01.01.2018"&&maskedTextBox1.Text == "  :  :"&&maskedTextBox2.Text == "  :  :"
                &&textBox3.Text == string.Empty&&textBox4.Text == string.Empty)
            {
                statistic("all");
            }
            else
            {
                statistic("filters");
            }
        }
        private void addNew_Click(object sender, EventArgs e)
        {
            Visit v = new Visit();
            AddOrChangeVisit form = new AddOrChangeVisit("add", v);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormClosing += new FormClosingEventHandler(formCLosed);
            form.ShowDialog();

        }
        private void formCLosed(object sednerr, FormClosingEventArgs e)
        {
            updUsed();
            load();
        }
    }
}
