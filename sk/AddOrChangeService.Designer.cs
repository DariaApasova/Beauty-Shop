namespace sk
{
    partial class AddOrChangeService
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.TextBox();
            this.notes = new System.Windows.Forms.RichTextBox();
            this.save = new System.Windows.Forms.Button();
            this.duration = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Наименование:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Стоимость:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Продолжительность:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Примечания:";
            // 
            // price
            // 
            this.price.Location = new System.Drawing.Point(121, 72);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(197, 22);
            this.price.TabIndex = 5;
            // 
            // notes
            // 
            this.notes.Location = new System.Drawing.Point(121, 170);
            this.notes.Name = "notes";
            this.notes.Size = new System.Drawing.Size(197, 73);
            this.notes.TabIndex = 7;
            this.notes.Text = "";
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(12, 202);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(93, 41);
            this.save.TabIndex = 8;
            this.save.Text = "Сохранить";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // duration
            // 
            this.duration.Location = new System.Drawing.Point(161, 105);
            this.duration.Name = "duration";
            this.duration.Size = new System.Drawing.Size(157, 22);
            this.duration.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "(в минутах)";
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(121, 12);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(199, 53);
            this.title.TabIndex = 11;
            this.title.Text = "";
            // 
            // AddOrChangeService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 259);
            this.Controls.Add(this.title);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.duration);
            this.Controls.Add(this.save);
            this.Controls.Add(this.notes);
            this.Controls.Add(this.price);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddOrChangeService";
            this.Text = "AddOrChangeService";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.RichTextBox notes;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.TextBox duration;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox title;
    }
}