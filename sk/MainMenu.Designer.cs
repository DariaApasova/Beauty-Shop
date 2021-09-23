namespace sk
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.seeCabinets = new System.Windows.Forms.Button();
            this.seeVisits = new System.Windows.Forms.Button();
            this.seeBranches = new System.Windows.Forms.Button();
            this.seeWorkers = new System.Windows.Forms.Button();
            this.seeServices = new System.Windows.Forms.Button();
            this.seeClients = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.seeTTW = new System.Windows.Forms.Button();
            this.seeTTB = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.seeCabinets);
            this.groupBox1.Controls.Add(this.seeVisits);
            this.groupBox1.Controls.Add(this.seeBranches);
            this.groupBox1.Controls.Add(this.seeWorkers);
            this.groupBox1.Controls.Add(this.seeServices);
            this.groupBox1.Controls.Add(this.seeClients);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 324);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Общий просмотр";
            // 
            // seeCabinets
            // 
            this.seeCabinets.Location = new System.Drawing.Point(27, 271);
            this.seeCabinets.Name = "seeCabinets";
            this.seeCabinets.Size = new System.Drawing.Size(136, 42);
            this.seeCabinets.TabIndex = 5;
            this.seeCabinets.Text = "Кабинеты";
            this.seeCabinets.UseVisualStyleBackColor = true;
            this.seeCabinets.Click += new System.EventHandler(this.seeCabinets_Click);
            // 
            // seeVisits
            // 
            this.seeVisits.Location = new System.Drawing.Point(27, 223);
            this.seeVisits.Name = "seeVisits";
            this.seeVisits.Size = new System.Drawing.Size(136, 42);
            this.seeVisits.TabIndex = 4;
            this.seeVisits.Text = "Посещения";
            this.seeVisits.UseVisualStyleBackColor = true;
            this.seeVisits.Click += new System.EventHandler(this.seeVisits_Click);
            // 
            // seeBranches
            // 
            this.seeBranches.Location = new System.Drawing.Point(27, 175);
            this.seeBranches.Name = "seeBranches";
            this.seeBranches.Size = new System.Drawing.Size(136, 42);
            this.seeBranches.TabIndex = 3;
            this.seeBranches.Text = "Филиалы";
            this.seeBranches.UseVisualStyleBackColor = true;
            this.seeBranches.Click += new System.EventHandler(this.seeBranches_Click);
            // 
            // seeWorkers
            // 
            this.seeWorkers.Location = new System.Drawing.Point(27, 127);
            this.seeWorkers.Name = "seeWorkers";
            this.seeWorkers.Size = new System.Drawing.Size(136, 42);
            this.seeWorkers.TabIndex = 2;
            this.seeWorkers.Text = "Работники";
            this.seeWorkers.UseVisualStyleBackColor = true;
            this.seeWorkers.Click += new System.EventHandler(this.seeWorkers_Click);
            // 
            // seeServices
            // 
            this.seeServices.Location = new System.Drawing.Point(27, 79);
            this.seeServices.Name = "seeServices";
            this.seeServices.Size = new System.Drawing.Size(136, 42);
            this.seeServices.TabIndex = 1;
            this.seeServices.Text = "Услуги";
            this.seeServices.UseVisualStyleBackColor = true;
            this.seeServices.Click += new System.EventHandler(this.seeServices_Click);
            // 
            // seeClients
            // 
            this.seeClients.Location = new System.Drawing.Point(27, 31);
            this.seeClients.Name = "seeClients";
            this.seeClients.Size = new System.Drawing.Size(136, 42);
            this.seeClients.TabIndex = 0;
            this.seeClients.Text = "Клиенты";
            this.seeClients.UseVisualStyleBackColor = true;
            this.seeClients.Click += new System.EventHandler(this.seeClients_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.seeTTW);
            this.groupBox2.Controls.Add(this.seeTTB);
            this.groupBox2.Location = new System.Drawing.Point(231, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(213, 284);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Расписание";
            // 
            // seeTTW
            // 
            this.seeTTW.Location = new System.Drawing.Point(27, 79);
            this.seeTTW.Name = "seeTTW";
            this.seeTTW.Size = new System.Drawing.Size(136, 42);
            this.seeTTW.TabIndex = 1;
            this.seeTTW.Text = "Расписание работников";
            this.seeTTW.UseVisualStyleBackColor = true;
            this.seeTTW.Click += new System.EventHandler(this.seeTTW_CLick);
            // 
            // seeTTB
            // 
            this.seeTTB.Location = new System.Drawing.Point(27, 31);
            this.seeTTB.Name = "seeTTB";
            this.seeTTB.Size = new System.Drawing.Size(136, 42);
            this.seeTTB.TabIndex = 0;
            this.seeTTB.Text = "Расписание филиалов";
            this.seeTTB.UseVisualStyleBackColor = true;
            this.seeTTB.Click += new System.EventHandler(this.seeTTB_CLick);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 341);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button seeVisits;
        private System.Windows.Forms.Button seeBranches;
        private System.Windows.Forms.Button seeWorkers;
        private System.Windows.Forms.Button seeServices;
        private System.Windows.Forms.Button seeClients;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button seeTTW;
        private System.Windows.Forms.Button seeTTB;
        private System.Windows.Forms.Button seeCabinets;
    }
}