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
    public partial class FormTTB : Form
    {
        public int num;
        string check;
        public FormTTB(string check1)
        {
            InitializeComponent();
            check = check1;
            load();
        }
        private void load()
        {
            if(check=="see")
            {
                dataGridView2.Columns[6].Visible = false;
            }
            if(check=="choose")
            {
                dataGridView2.Columns[6].Visible = true;
            }
            using (TTBContext timetableb = new TTBContext())
            {
                dataGridView2.ReadOnly = true;
                dataGridView2.Rows.Clear();
                var ttb = timetableb.TTBs;
                int r = 0;
                int count = 0;
                foreach(TimetableBranch t in ttb)
                {
                    Dictionary<int, Branch> d = BranchCache.getCache();
                        foreach(Branch w in d.Values)
                        {
                            if(w.timetable.id==t.id)
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
                    r++;
                    count = 0; 
                }
            }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==6)
            {
                int t = e.RowIndex;
                var n =dataGridView2.Rows[t].Cells[0].Value;
                num = Convert.ToInt16(n);
            }
            Close();
        }
    }
}
