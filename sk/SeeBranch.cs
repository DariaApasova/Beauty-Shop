﻿using System;
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
            textBox1.Enabled = false;
            textBox1.Text =Convert.ToString(b.id);
            textBox11.Enabled = false;
            textBox11.Text = Convert.ToString(b.timetable.beginning);
            textBox12.Enabled = false;
            textBox12.Text = Convert.ToString(b.timetable.ending);
            textBox2.Enabled = false;
            textBox2.Text = Convert.ToString(b.name);
            textBox3.Enabled = false;
            textBox3.Text = Convert.ToString(b.address);
            textBox4.Enabled = false;
            textBox4.Text = Convert.ToString(b.Cabinets.Count());
            Dictionary<int, Attendance> lst = AttendanceCache.lstWorkers();
            int count = 0;
            foreach(Attendance a in lst.Values)
            {
                foreach(Cabinet c in b.Cabinets.ToList())
                {
                    if(c.id==a.cabinet.id)
                    {
                        count++;
                    }
                }
            }
            textBox5.Enabled = false;
            textBox5.Text = Convert.ToString(count);

        }
    }
}
