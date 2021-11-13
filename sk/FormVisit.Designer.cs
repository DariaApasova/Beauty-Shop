namespace sk
{
    partial class FormVisit
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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.id_visit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.client_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_visit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.select = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.addNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_visit,
            this.client_name,
            this.branch,
            this.date_visit,
            this.duration,
            this.price,
            this.note,
            this.select});
            this.dataGridView2.Location = new System.Drawing.Point(3, 172);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(843, 458);
            this.dataGridView2.TabIndex = 3;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dataGridView2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // id_visit
            // 
            this.id_visit.HeaderText = "Номер посещения";
            this.id_visit.Name = "id_visit";
            // 
            // client_name
            // 
            this.client_name.HeaderText = "Имя клиента";
            this.client_name.Name = "client_name";
            // 
            // branch
            // 
            this.branch.HeaderText = "Филиал";
            this.branch.Name = "branch";
            // 
            // date_visit
            // 
            this.date_visit.HeaderText = "Дата и время";
            this.date_visit.Name = "date_visit";
            // 
            // duration
            // 
            this.duration.HeaderText = "Продолжительность";
            this.duration.Name = "duration";
            // 
            // price
            // 
            this.price.HeaderText = "Стоимость";
            this.price.Name = "price";
            // 
            // note
            // 
            this.note.HeaderText = "Примечания";
            this.note.Name = "note";
            this.note.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.note.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // select
            // 
            this.select.HeaderText = "Выбрать";
            this.select.Name = "select";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.comboBox4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(849, 154);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поиск";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(690, 30);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(85, 17);
            this.label16.TabIndex = 39;
            this.label16.Text = "не выбрана";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(632, 30);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 17);
            this.label15.TabIndex = 38;
            this.label15.Text = "Услуга";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(533, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 17);
            this.label14.TabIndex = 36;
            this.label14.Text = "не выбран";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(455, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 17);
            this.label13.TabIndex = 35;
            this.label13.Text = "Работник";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(757, 87);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(86, 22);
            this.textBox4.TabIndex = 34;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(636, 89);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(86, 22);
            this.textBox3.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(727, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 17);
            this.label4.TabIndex = 32;
            this.label4.Text = "до";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(533, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 17);
            this.label12.TabIndex = 31;
            this.label12.Text = "Стоимость от";
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(307, 23);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 24);
            this.comboBox4.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "Филиал";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(157, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 17);
            this.label11.TabIndex = 23;
            this.label11.Text = "не выбран";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(338, 122);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(182, 21);
            this.checkBox1.TabIndex = 22;
            this.checkBox1.Text = "Сортировать наоборот";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(133, 119);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(199, 24);
            this.comboBox2.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "Сортировать по";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(683, 117);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 28);
            this.button2.TabIndex = 17;
            this.button2.Text = "Сбросить";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(569, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 26);
            this.button1.TabIndex = 16;
            this.button1.Text = "Применить";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(335, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "до";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(370, 87);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(157, 22);
            this.textBox6.TabIndex = 14;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(176, 89);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(153, 22);
            this.textBox5.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Продолжительность от";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(395, 59);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(215, 22);
            this.dateTimePicker2.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(361, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "до";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(133, 59);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(222, 22);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Дата и время от";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Клиент";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(36, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(53, 22);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(461, 646);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(338, 653);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 17);
            this.label10.TabIndex = 14;
            this.label10.Text = "Показывать по";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(229, 646);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 32);
            this.button7.TabIndex = 13;
            this.button7.Text = "Вперед";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(53, 646);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(76, 32);
            this.button6.TabIndex = 12;
            this.button6.Text = "Назад";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(136, 650);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(79, 24);
            this.comboBox3.TabIndex = 16;
            // 
            // addNew
            // 
            this.addNew.Location = new System.Drawing.Point(647, 641);
            this.addNew.Name = "addNew";
            this.addNew.Size = new System.Drawing.Size(131, 32);
            this.addNew.TabIndex = 17;
            this.addNew.Text = "Добавить новый";
            this.addNew.UseVisualStyleBackColor = true;
            // 
            // FormVisit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 692);
            this.Controls.Add(this.addNew);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView2);
            this.Name = "FormVisit";
            this.Text = "Визиты";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_visit;
        private System.Windows.Forms.DataGridViewTextBoxColumn client_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn branch;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_visit;
        private System.Windows.Forms.DataGridViewTextBoxColumn duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn note;
        private System.Windows.Forms.DataGridViewButtonColumn select;
        private System.Windows.Forms.Button addNew;
    }
}