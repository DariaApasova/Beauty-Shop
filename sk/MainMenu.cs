using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace sk
{
    public partial class MainMenu : Form
    {
        string check = "see";
        public MainMenu()
        {
            InitializeComponent();            
        }
        private void seeClients_Click(object sender, EventArgs e)
        {
          
            FormClient form = new FormClient(check);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
        private void seeCabinets_Click(object sender, EventArgs e)
        {
            Branch b = new Branch();
            FormCabinet form = new FormCabinet(check, 0);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
        private void seeBranches_Click(object sender, EventArgs e)
        {
            FormBranch form = new FormBranch(check);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
        private void seeServices_Click(object sender, EventArgs e)
        {
            FormService form = new FormService(check, 0);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
        private void seeVisits_Click(object sender, EventArgs e)
        {
            FormVisit form = new FormVisit(check,0);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
        private void seeWorkers_Click(object sender, EventArgs e)
        {
            FormWorker form = new FormWorker(check);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
        private void seeTTB_CLick(object sender, EventArgs e)
        {
            FormTTB form = new FormTTB(check);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
        private void seeTTW_CLick(object sender, EventArgs e)
        {
            FormTTW form = new FormTTW(check);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
    }
}
