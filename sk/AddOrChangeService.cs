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
    public partial class AddOrChangeService : Form
    {
        string check;
        Dictionary<int, Service> dict = ServicesCache.getCache();
        Service service1 = new Service();
        int curid;
        public  AddOrChangeService(Service s, string check1)
        {
            InitializeComponent();
            service1 = s;
            curid = s.id;
            check = check1;
            load();
        }
        private void load()
        {
            if(check=="add")
            {
                fillNewService();
            }
            if(check=="change")
            {
                if(service1.date_delete!=Convert.ToDateTime("31.12.9999 12:00:00"))
                {
                    MessageBox.Show("Вы не можете изменить удаленную услугу");
                    this.Close();
                }
                else
                {
                    loadService(service1);
                }
            }
        }
        private void loadService(Service s)
        {
            title.Text = s.title;
            if(s.notes!=null)
            {
                notes.Text = s.notes;
            }
            duration.Text =Convert.ToString( s.duration);
            price.Text =Convert.ToString(s.price);
        }
        private void fillNewService()
        {
            save.Enabled = true;
            title.Text = "";
            notes.Text = "";
            duration.Text = "";
            price.Text = "";
        }
        private void saveService()
        {
            Service service = service1;
            service1.title = title.Text;
            service1.duration = duration.Text;
            service1.price = Convert.ToDecimal(price.Text);
            service1.notes = notes.Text;
            service1.date_delete = Convert.ToDateTime("31.12.9999 12:00:00");
            using (ServiceContext sc = new ServiceContext())
            {
                string time = convertTime(duration.Text);
                Service s1 = new Service { id = curid, title = title.Text, price = Convert.ToDecimal(price.Text), duration = time, notes = notes.Text, date_delete = Convert.ToDateTime("31.12.9999 12:00:00")};
                if (check == "add")
                {
                    sc.Services.Add(s1);
                }
                if(check=="change")
                {
                    sc.Entry(service1).State = System.Data.Entity.EntityState.Modified;
                }
                sc.SaveChanges();
                ServicesCache.updateCache();
            }
        }
        private string convertTime(string t)
        {
            try
            {
                string h = Convert.ToString(TimeSpan.FromMinutes(Convert.ToDouble(duration.Text)).TotalHours);
                string[] hh = h.Split(',');
                string m = Convert.ToString(Convert.ToInt32(duration.Text) - (Convert.ToInt16(hh[0]) * 60));
                if (m.Length == 1)
                {
                    m = $"0+{m}";
                }
                string time = $"0{hh[0]}:{m}:00";
                return time;
            }
            catch(Exception e)
            {
                return t;
            }
        }
        private void save_Click(object sender, EventArgs e)
        {
            title.Enabled = false;
            duration.Enabled = false;
            price.Enabled = false;
            notes.Enabled = false;
            saveService();
            string text = "Услуга успешно сохранена.";
            string caption = "Уведомление";
            MessageBox.Show(text, caption);
        }
    }
}
