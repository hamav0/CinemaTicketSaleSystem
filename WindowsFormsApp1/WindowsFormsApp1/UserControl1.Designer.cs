namespace WindowsFormsApp1
{
    partial class UserControl1
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Rname = new System.Windows.Forms.Label();
            this.Rcountry = new System.Windows.Forms.Label();
            this.Ryear = new System.Windows.Forms.Label();
            this.Rpg = new System.Windows.Forms.Label();
            this.Rzal = new System.Windows.Forms.Label();
            this.Rform = new System.Windows.Forms.Label();
            this.Rwhen = new System.Windows.Forms.Label();
            this.Rlen = new System.Windows.Forms.Label();
            this.Rtime = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gd3 = new System.Windows.Forms.Panel();
            this.gd2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gd3.SuspendLayout();
            this.gd2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Rname
            // 
            this.Rname.AutoEllipsis = true;
            this.Rname.AutoSize = true;
            this.Rname.Font = new System.Drawing.Font("Rodondo", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.Rname.Location = new System.Drawing.Point(3, 0);
            this.Rname.Name = "Rname";
            this.Rname.Size = new System.Drawing.Size(112, 30);
            this.Rname.TabIndex = 0;
            this.Rname.Text = "Название";
            this.Rname.Click += new System.EventHandler(this.Child_Click);
            // 
            // Rcountry
            // 
            this.Rcountry.AutoSize = true;
            this.Rcountry.Font = new System.Drawing.Font("Rodondo", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.Rcountry.Location = new System.Drawing.Point(4, 30);
            this.Rcountry.Name = "Rcountry";
            this.Rcountry.Size = new System.Drawing.Size(57, 19);
            this.Rcountry.TabIndex = 1;
            this.Rcountry.Text = "Страна";
            this.Rcountry.Click += new System.EventHandler(this.Child_Click);
            // 
            // Ryear
            // 
            this.Ryear.AutoSize = true;
            this.Ryear.Font = new System.Drawing.Font("Rodondo", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.Ryear.Location = new System.Drawing.Point(4, 52);
            this.Ryear.Name = "Ryear";
            this.Ryear.Size = new System.Drawing.Size(33, 19);
            this.Ryear.TabIndex = 2;
            this.Ryear.Text = "Год";
            this.Ryear.Click += new System.EventHandler(this.Child_Click);
            // 
            // Rpg
            // 
            this.Rpg.AutoSize = true;
            this.Rpg.Font = new System.Drawing.Font("Rodondo", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.Rpg.Location = new System.Drawing.Point(3, 10);
            this.Rpg.Name = "Rpg";
            this.Rpg.Size = new System.Drawing.Size(144, 19);
            this.Rpg.TabIndex = 2;
            this.Rpg.Text = "Возрастной рейтинг";
            this.Rpg.Click += new System.EventHandler(this.Child_Click);
            // 
            // Rzal
            // 
            this.Rzal.AutoSize = true;
            this.Rzal.Font = new System.Drawing.Font("Rodondo", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.Rzal.Location = new System.Drawing.Point(3, 30);
            this.Rzal.Name = "Rzal";
            this.Rzal.Size = new System.Drawing.Size(34, 19);
            this.Rzal.TabIndex = 2;
            this.Rzal.Text = "Зал";
            this.Rzal.Click += new System.EventHandler(this.Child_Click);
            // 
            // Rform
            // 
            this.Rform.AutoSize = true;
            this.Rform.Font = new System.Drawing.Font("Rodondo", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.Rform.Location = new System.Drawing.Point(3, 49);
            this.Rform.Name = "Rform";
            this.Rform.Size = new System.Drawing.Size(62, 19);
            this.Rform.TabIndex = 2;
            this.Rform.Text = "Формат";
            this.Rform.Click += new System.EventHandler(this.Child_Click);
            // 
            // Rwhen
            // 
            this.Rwhen.AutoSize = true;
            this.Rwhen.Font = new System.Drawing.Font("Rodondo", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.Rwhen.Location = new System.Drawing.Point(3, 68);
            this.Rwhen.Name = "Rwhen";
            this.Rwhen.Size = new System.Drawing.Size(151, 19);
            this.Rwhen.TabIndex = 2;
            this.Rwhen.Text = "Через сколько минут";
            this.Rwhen.Click += new System.EventHandler(this.Child_Click);
            // 
            // Rlen
            // 
            this.Rlen.AutoSize = true;
            this.Rlen.Font = new System.Drawing.Font("Rodondo", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.Rlen.Location = new System.Drawing.Point(200, 10);
            this.Rlen.Name = "Rlen";
            this.Rlen.Size = new System.Drawing.Size(58, 19);
            this.Rlen.TabIndex = 2;
            this.Rlen.Text = "92 мин.";
            this.Rlen.Click += new System.EventHandler(this.Child_Click);
            // 
            // Rtime
            // 
            this.Rtime.AutoSize = true;
            this.Rtime.Font = new System.Drawing.Font("Rodondo", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.Rtime.Location = new System.Drawing.Point(3, 0);
            this.Rtime.Name = "Rtime";
            this.Rtime.Size = new System.Drawing.Size(130, 30);
            this.Rtime.TabIndex = 3;
            this.Rtime.Text = "Во сколько";
            this.Rtime.Click += new System.EventHandler(this.Child_Click);
            // 
            // gd3
            // 
            this.gd3.BackColor = System.Drawing.Color.Transparent;
            this.gd3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gd3.Controls.Add(this.Rname);
            this.gd3.Controls.Add(this.Ryear);
            this.gd3.Controls.Add(this.Rcountry);
            this.gd3.Font = new System.Drawing.Font("Rodondo", 14F);
            this.gd3.Location = new System.Drawing.Point(3, 3);
            this.gd3.Name = "gd3";
            this.gd3.Size = new System.Drawing.Size(261, 85);
            this.gd3.TabIndex = 3;
            this.gd3.Click += new System.EventHandler(this.Child_Click);
            // 
            // gd2
            // 
            this.gd2.BackColor = System.Drawing.Color.Transparent;
            this.gd2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gd2.Controls.Add(this.Rwhen);
            this.gd2.Controls.Add(this.Rform);
            this.gd2.Controls.Add(this.Rtime);
            this.gd2.Controls.Add(this.Rzal);
            this.gd2.Font = new System.Drawing.Font("Rodondo", 14F);
            this.gd2.Location = new System.Drawing.Point(269, 3);
            this.gd2.Name = "gd2";
            this.gd2.Size = new System.Drawing.Size(157, 134);
            this.gd2.TabIndex = 6;
            this.gd2.Click += new System.EventHandler(this.Child_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Rpg);
            this.panel1.Controls.Add(this.Rlen);
            this.panel1.Font = new System.Drawing.Font("Rodondo", 14F);
            this.panel1.Location = new System.Drawing.Point(3, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 43);
            this.panel1.TabIndex = 7;
            this.panel1.Click += new System.EventHandler(this.Child_Click);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gd2);
            this.Controls.Add(this.gd3);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(430, 140);
            this.gd3.ResumeLayout(false);
            this.gd3.PerformLayout();
            this.gd2.ResumeLayout(false);
            this.gd2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Rname;
        private System.Windows.Forms.Label Rcountry;
        private System.Windows.Forms.Label Ryear;
        private System.Windows.Forms.Label Rpg;
        private System.Windows.Forms.Label Rzal;
        private System.Windows.Forms.Label Rform;
        private System.Windows.Forms.Label Rwhen;
        private System.Windows.Forms.Label Rlen;
        private System.Windows.Forms.Label Rtime;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel gd3;
        private System.Windows.Forms.Panel gd2;
        private System.Windows.Forms.Panel panel1;
    }
}
