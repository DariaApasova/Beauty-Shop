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
    public partial class SeeService : Form
    {
        Dictionary<int, Service> dict = ServicesCache.getCache();
        Service service1 = new Service();
        public SeeService(Service s)
        {
            InitializeComponent();
            service1= s;
            load();
        }
        private void load()
        {
            textBox1.Text = Convert.ToString(service1.id);
            textBox1.Enabled = false;
            textBox2.Text = service1.title;
            textBox2.Enabled = false;
            textBox3.Text =Convert.ToString( service1.price);
            textBox3.Enabled = false;
            textBox4.Text = Convert.ToString(service1.duration);
            textBox4.Enabled = false;
            richTextBox1.Text = service1.notes;
            richTextBox1.Enabled = false;
          //  fillStatistics();
        }
        private void fillStatistics()
        {
            using (var connect = new SQLiteConnection(@"Data Source=EducationDB"))
            {
                connect.Open();
                SQLiteCommand comm = connect.CreateCommand();
                comm.CommandText = $"SELECT count(*) as count FROM services_visits_workers WHERE id_service={service1.id};";
                var str = comm.ExecuteReader();
                textBox5.Text = Convert.ToString(str);
            }
        }
        private void change_CLick(object sender, EventArgs e)
        {
            AddOrChangeService form = new AddOrChangeService(service1, "change");
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
    }
}
