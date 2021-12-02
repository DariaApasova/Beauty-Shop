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

namespace sk
{
    public partial class FormVisit : Form
    {
        string check;
        int curid;
        public FormVisit(string check1, int id)
        {
            InitializeComponent();
            curid = id;
            check = check1;
            load();
        }
        private void load()
        {
            if(check=="see")
            {
                dataGridView2.Columns[7].Visible = false;
                using (VisitContext vc = new VisitContext())
                {
                    dataGridView2.Rows.Clear();
                    int r = 0;
                    var visits = vc.Visits.Include("Client").Include("Branch").ToList();
                    foreach (var v in visits)
                    {

                        dataGridView2.Rows.Add();
                        dataGridView2[0, r].Value = v.id;
                        dataGridView2[1, r].Value = v.client.name;
                        dataGridView2[2, r].Value = v.branch.name;
                        dataGridView2[3, r].Value = v.date_visit;
                        dataGridView2[4, r].Value = v.duration;
                        dataGridView2[5, r].Value = v.price;
                        dataGridView2[6, r].Value = v.notes;
                        r++;
                    }
                }
            }
            if(check=="detClient")
            {
                dataGridView2.Columns[7].Visible = false;
                using (VisitContext vc = new VisitContext())
                {
                    dataGridView2.Rows.Clear();
                    int r = 0;
                    var visits = vc.Visits.Include("Client").Include("Branch").ToList();
                    foreach (var v in visits)
                    {
                        if (v.client.id == curid)
                        {
                            dataGridView2.Rows.Add();
                            dataGridView2[0, r].Value = v.id;
                            dataGridView2[1, r].Value = v.client.name;
                            dataGridView2[2, r].Value = v.branch.name;
                            dataGridView2[3, r].Value = v.date_visit;
                            dataGridView2[4, r].Value = v.duration;
                            dataGridView2[5, r].Value = v.price;
                            dataGridView2[6, r].Value = v.notes;
                            r++;
                        }
                    }
                }
            }
            if(check=="detWorker")
            {
                dataGridView2.Columns[7].Visible = false;
                Dictionary<int, Attendance> dict = AttendanceCache.lstWorkers();
                int r = 0;
                foreach (Attendance a in dict.Values)
                {
                    if(curid==a.worker.id)
                    {
                        using (VisitContext vc = new VisitContext())
                        {
                            var visits = vc.Visits.Include("Client").Include("Branch").ToList();
                            foreach(var v in visits)
                            {
                                if (a.visit.id == v.id)
                                {
                                    dataGridView2.Rows.Add();
                                    dataGridView2[0, r].Value = v.id;
                                    dataGridView2[1, r].Value = v.client.name;
                                    dataGridView2[2, r].Value = v.branch.name;
                                    dataGridView2[3, r].Value = v.date_visit;
                                    dataGridView2[4, r].Value = v.duration;
                                    dataGridView2[5, r].Value = v.price;
                                    dataGridView2[6, r].Value = v.notes;
                                    r++;
                                }
                            }
                        }
                    }
                }
            }
            if(check=="detCabinet")
            {
                dataGridView2.Columns[7].Visible = false;
                Dictionary<int, Attendance> dict = AttendanceCache.lstWorkers();
                int r = 0;
                foreach(Attendance a in dict.Values)
                {
                    if(curid==a.cabinet.id)
                    {
                        using (VisitContext vc = new VisitContext())
                        {
                            var visits = vc.Visits.Include("CLient").Include("Branch").ToList();
                            foreach(var v in visits)
                            {
                                if(a.visit.id==v.id)
                                {
                                    dataGridView2.Rows.Add();
                                    dataGridView2[0, r].Value = v.id;
                                    dataGridView2[1, r].Value = v.client.name;
                                    dataGridView2[2, r].Value = v.branch.name;
                                    dataGridView2[3, r].Value = v.date_visit;
                                    dataGridView2[4, r].Value = v.duration;
                                    dataGridView2[5, r].Value = v.price;
                                    dataGridView2[6, r].Value = v.notes;
                                    r++;
                                }
                            }
                        }
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
    }
}
