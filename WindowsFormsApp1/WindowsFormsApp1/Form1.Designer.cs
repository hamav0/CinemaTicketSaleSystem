namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.flpSessions = new System.Windows.Forms.FlowLayoutPanel();
            this.rbToday = new System.Windows.Forms.RadioButton();
            this.rbTomorrow = new System.Windows.Forms.RadioButton();
            this.rbCustomDate = new System.Windows.Forms.RadioButton();
            this.dtpCalendar = new System.Windows.Forms.DateTimePicker();
            this.lblNotFound = new System.Windows.Forms.Label();
            this.cbEvening = new System.Windows.Forms.CheckBox();
            this.cbDay = new System.Windows.Forms.CheckBox();
            this.cbMorning = new System.Windows.Forms.CheckBox();
            this.cbR = new System.Windows.Forms.CheckBox();
            this.cbPG13 = new System.Windows.Forms.CheckBox();
            this.cbPG = new System.Windows.Forms.CheckBox();
            this.clbHalls = new System.Windows.Forms.CheckedListBox();
            this.clbFormats = new System.Windows.Forms.CheckedListBox();
            this.Halls = new System.Windows.Forms.Label();
            this.Formats = new System.Windows.Forms.Label();
            this.Filters = new System.Windows.Forms.Label();
            this.Dist = new System.Windows.Forms.Label();
            this.clbDist = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Time = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LName = new System.Windows.Forms.Label();
            this.clbName = new System.Windows.Forms.CheckedListBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpSessions
            // 
            this.flpSessions.AutoScroll = true;
            this.flpSessions.BackColor = System.Drawing.SystemColors.ControlDark;
            this.flpSessions.Location = new System.Drawing.Point(12, 44);
            this.flpSessions.Name = "flpSessions";
            this.flpSessions.Size = new System.Drawing.Size(450, 509);
            this.flpSessions.TabIndex = 2;
            // 
            // rbToday
            // 
            this.rbToday.AutoSize = true;
            this.rbToday.Checked = true;
            this.rbToday.Font = new System.Drawing.Font("Rodondo", 16F);
            this.rbToday.Location = new System.Drawing.Point(12, 12);
            this.rbToday.Name = "rbToday";
            this.rbToday.Size = new System.Drawing.Size(93, 26);
            this.rbToday.TabIndex = 3;
            this.rbToday.TabStop = true;
            this.rbToday.Text = "Сегодня";
            this.rbToday.UseVisualStyleBackColor = true;
            this.rbToday.CheckedChanged += new System.EventHandler(this.rbToday_CheckedChanged);
            // 
            // rbTomorrow
            // 
            this.rbTomorrow.AutoSize = true;
            this.rbTomorrow.Font = new System.Drawing.Font("Rodondo", 16F);
            this.rbTomorrow.Location = new System.Drawing.Point(111, 12);
            this.rbTomorrow.Name = "rbTomorrow";
            this.rbTomorrow.Size = new System.Drawing.Size(84, 26);
            this.rbTomorrow.TabIndex = 4;
            this.rbTomorrow.Text = "Завтра";
            this.rbTomorrow.UseVisualStyleBackColor = true;
            this.rbTomorrow.CheckedChanged += new System.EventHandler(this.rbTomorrow_CheckedChanged);
            // 
            // rbCustomDate
            // 
            this.rbCustomDate.AutoSize = true;
            this.rbCustomDate.Font = new System.Drawing.Font("Rodondo", 16F);
            this.rbCustomDate.Location = new System.Drawing.Point(194, 12);
            this.rbCustomDate.Name = "rbCustomDate";
            this.rbCustomDate.Size = new System.Drawing.Size(67, 26);
            this.rbCustomDate.TabIndex = 5;
            this.rbCustomDate.Text = "Дата";
            this.rbCustomDate.UseVisualStyleBackColor = true;
            this.rbCustomDate.CheckedChanged += new System.EventHandler(this.rbCustomDate_CheckedChanged);
            // 
            // dtpCalendar
            // 
            this.dtpCalendar.Font = new System.Drawing.Font("Rodondo", 14F);
            this.dtpCalendar.Location = new System.Drawing.Point(262, 12);
            this.dtpCalendar.Name = "dtpCalendar";
            this.dtpCalendar.Size = new System.Drawing.Size(200, 26);
            this.dtpCalendar.TabIndex = 6;
            this.dtpCalendar.Visible = false;
            this.dtpCalendar.ValueChanged += new System.EventHandler(this.dtpCalendar_ValueChanged);
            // 
            // lblNotFound
            // 
            this.lblNotFound.AutoSize = true;
            this.lblNotFound.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblNotFound.Font = new System.Drawing.Font("Rodondo", 24F);
            this.lblNotFound.Location = new System.Drawing.Point(104, 180);
            this.lblNotFound.Name = "lblNotFound";
            this.lblNotFound.Size = new System.Drawing.Size(259, 32);
            this.lblNotFound.TabIndex = 7;
            this.lblNotFound.Text = "Сеансов не найдено";
            this.lblNotFound.Visible = false;
            // 
            // cbEvening
            // 
            this.cbEvening.AutoSize = true;
            this.cbEvening.Location = new System.Drawing.Point(3, 61);
            this.cbEvening.Name = "cbEvening";
            this.cbEvening.Size = new System.Drawing.Size(86, 23);
            this.cbEvening.TabIndex = 2;
            this.cbEvening.Text = "Вечером";
            this.cbEvening.UseVisualStyleBackColor = true;
            this.cbEvening.CheckedChanged += new System.EventHandler(this.Filter_Changed);
            // 
            // cbDay
            // 
            this.cbDay.AutoSize = true;
            this.cbDay.Location = new System.Drawing.Point(3, 32);
            this.cbDay.Name = "cbDay";
            this.cbDay.Size = new System.Drawing.Size(64, 23);
            this.cbDay.TabIndex = 1;
            this.cbDay.Text = "Днём";
            this.cbDay.UseVisualStyleBackColor = true;
            this.cbDay.CheckedChanged += new System.EventHandler(this.Filter_Changed);
            // 
            // cbMorning
            // 
            this.cbMorning.AutoSize = true;
            this.cbMorning.Location = new System.Drawing.Point(3, 3);
            this.cbMorning.Name = "cbMorning";
            this.cbMorning.Size = new System.Drawing.Size(69, 23);
            this.cbMorning.TabIndex = 0;
            this.cbMorning.Text = "Утром";
            this.cbMorning.UseVisualStyleBackColor = true;
            this.cbMorning.CheckedChanged += new System.EventHandler(this.Filter_Changed);
            // 
            // cbR
            // 
            this.cbR.AutoSize = true;
            this.cbR.Location = new System.Drawing.Point(3, 61);
            this.cbR.Name = "cbR";
            this.cbR.Size = new System.Drawing.Size(36, 23);
            this.cbR.TabIndex = 2;
            this.cbR.Text = "R";
            this.cbR.UseVisualStyleBackColor = true;
            this.cbR.CheckedChanged += new System.EventHandler(this.Filter_Changed);
            // 
            // cbPG13
            // 
            this.cbPG13.AutoSize = true;
            this.cbPG13.Location = new System.Drawing.Point(3, 32);
            this.cbPG13.Name = "cbPG13";
            this.cbPG13.Size = new System.Drawing.Size(64, 23);
            this.cbPG13.TabIndex = 1;
            this.cbPG13.Text = "PG-13";
            this.cbPG13.UseVisualStyleBackColor = true;
            this.cbPG13.CheckedChanged += new System.EventHandler(this.Filter_Changed);
            // 
            // cbPG
            // 
            this.cbPG.AutoSize = true;
            this.cbPG.Location = new System.Drawing.Point(3, 3);
            this.cbPG.Name = "cbPG";
            this.cbPG.Size = new System.Drawing.Size(46, 23);
            this.cbPG.TabIndex = 0;
            this.cbPG.Text = "PG";
            this.cbPG.UseVisualStyleBackColor = true;
            this.cbPG.CheckedChanged += new System.EventHandler(this.Filter_Changed);
            // 
            // clbHalls
            // 
            this.clbHalls.Font = new System.Drawing.Font("Rodondo", 14F);
            this.clbHalls.FormattingEnabled = true;
            this.clbHalls.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.clbHalls.Location = new System.Drawing.Point(482, 179);
            this.clbHalls.Name = "clbHalls";
            this.clbHalls.Size = new System.Drawing.Size(120, 109);
            this.clbHalls.TabIndex = 10;
            this.clbHalls.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clb_ItemCheck);
            // 
            // clbFormats
            // 
            this.clbFormats.Font = new System.Drawing.Font("Rodondo", 14F);
            this.clbFormats.FormattingEnabled = true;
            this.clbFormats.Items.AddRange(new object[] {
            "DVD",
            "Blu-ray",
            "Digital",
            "dox",
            "swat"});
            this.clbFormats.Location = new System.Drawing.Point(608, 179);
            this.clbFormats.Name = "clbFormats";
            this.clbFormats.Size = new System.Drawing.Size(120, 109);
            this.clbFormats.TabIndex = 11;
            this.clbFormats.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clb_ItemCheck);
            // 
            // Halls
            // 
            this.Halls.AutoSize = true;
            this.Halls.Font = new System.Drawing.Font("Rodondo", 14F);
            this.Halls.Location = new System.Drawing.Point(478, 157);
            this.Halls.Name = "Halls";
            this.Halls.Size = new System.Drawing.Size(44, 19);
            this.Halls.TabIndex = 12;
            this.Halls.Text = "Залы";
            // 
            // Formats
            // 
            this.Formats.AutoSize = true;
            this.Formats.Font = new System.Drawing.Font("Rodondo", 14F);
            this.Formats.Location = new System.Drawing.Point(604, 157);
            this.Formats.Name = "Formats";
            this.Formats.Size = new System.Drawing.Size(72, 19);
            this.Formats.TabIndex = 13;
            this.Formats.Text = "Форматы";
            // 
            // Filters
            // 
            this.Filters.AutoSize = true;
            this.Filters.Font = new System.Drawing.Font("Rodondo", 22F);
            this.Filters.Location = new System.Drawing.Point(482, 8);
            this.Filters.Name = "Filters";
            this.Filters.Size = new System.Drawing.Size(112, 30);
            this.Filters.TabIndex = 14;
            this.Filters.Text = "Фильтры:";
            // 
            // Dist
            // 
            this.Dist.AutoSize = true;
            this.Dist.Font = new System.Drawing.Font("Rodondo", 14F);
            this.Dist.Location = new System.Drawing.Point(483, 291);
            this.Dist.Name = "Dist";
            this.Dist.Size = new System.Drawing.Size(116, 19);
            this.Dist.TabIndex = 15;
            this.Dist.Text = "Дистрибьютеры";
            // 
            // clbDist
            // 
            this.clbDist.Font = new System.Drawing.Font("Rodondo", 14F);
            this.clbDist.FormattingEnabled = true;
            this.clbDist.Location = new System.Drawing.Point(483, 314);
            this.clbDist.Name = "clbDist";
            this.clbDist.Size = new System.Drawing.Size(246, 88);
            this.clbDist.TabIndex = 16;
            this.clbDist.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clb_ItemCheck);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbEvening);
            this.panel1.Controls.Add(this.cbMorning);
            this.panel1.Controls.Add(this.cbDay);
            this.panel1.Font = new System.Drawing.Font("Rodondo", 14F);
            this.panel1.Location = new System.Drawing.Point(482, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 88);
            this.panel1.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cbR);
            this.panel2.Controls.Add(this.cbPG);
            this.panel2.Controls.Add(this.cbPG13);
            this.panel2.Font = new System.Drawing.Font("Rodondo", 14F);
            this.panel2.Location = new System.Drawing.Point(611, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(120, 88);
            this.panel2.TabIndex = 18;
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Font = new System.Drawing.Font("Rodondo", 14F);
            this.Time.Location = new System.Drawing.Point(478, 44);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(51, 19);
            this.Time.TabIndex = 19;
            this.Time.Text = "Время";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rodondo", 14F);
            this.label2.Location = new System.Drawing.Point(600, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 19);
            this.label2.TabIndex = 20;
            this.label2.Text = "Возрастной рейтинг";
            // 
            // LName
            // 
            this.LName.AutoSize = true;
            this.LName.Font = new System.Drawing.Font("Rodondo", 14F);
            this.LName.Location = new System.Drawing.Point(483, 405);
            this.LName.Name = "LName";
            this.LName.Size = new System.Drawing.Size(73, 19);
            this.LName.TabIndex = 15;
            this.LName.Text = "Название";
            // 
            // clbName
            // 
            this.clbName.Font = new System.Drawing.Font("Rodondo", 14F);
            this.clbName.FormattingEnabled = true;
            this.clbName.Location = new System.Drawing.Point(483, 427);
            this.clbName.Name = "clbName";
            this.clbName.Size = new System.Drawing.Size(246, 88);
            this.clbName.TabIndex = 16;
            this.clbName.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clb_ItemCheck);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 565);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.clbName);
            this.Controls.Add(this.clbDist);
            this.Controls.Add(this.lblNotFound);
            this.Controls.Add(this.LName);
            this.Controls.Add(this.Dist);
            this.Controls.Add(this.Filters);
            this.Controls.Add(this.Formats);
            this.Controls.Add(this.Halls);
            this.Controls.Add(this.clbFormats);
            this.Controls.Add(this.clbHalls);
            this.Controls.Add(this.dtpCalendar);
            this.Controls.Add(this.rbCustomDate);
            this.Controls.Add(this.rbTomorrow);
            this.Controls.Add(this.rbToday);
            this.Controls.Add(this.flpSessions);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(760, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(760, 600);
            this.Name = "Form1";
            this.Text = "It\'s about Quality, not Quantity";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.FlowLayoutPanel flpSessions;
        private System.Windows.Forms.RadioButton rbToday;
        private System.Windows.Forms.RadioButton rbTomorrow;
        private System.Windows.Forms.RadioButton rbCustomDate;
        private System.Windows.Forms.DateTimePicker dtpCalendar;
        private System.Windows.Forms.Label lblNotFound;
        private System.Windows.Forms.CheckBox cbEvening;
        private System.Windows.Forms.CheckBox cbDay;
        private System.Windows.Forms.CheckBox cbMorning;
        private System.Windows.Forms.CheckedListBox clbHalls;
        private System.Windows.Forms.CheckBox cbR;
        private System.Windows.Forms.CheckBox cbPG13;
        private System.Windows.Forms.CheckBox cbPG;
        private System.Windows.Forms.CheckedListBox clbFormats;
        private System.Windows.Forms.Label Halls;
        private System.Windows.Forms.Label Formats;
        private System.Windows.Forms.Label Filters;
        private System.Windows.Forms.Label Dist;
        private System.Windows.Forms.CheckedListBox clbDist;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LName;
        private System.Windows.Forms.CheckedListBox clbName;
    }
}

