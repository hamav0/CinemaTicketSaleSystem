using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        // Поле для хранения ID сеанса, чтобы потом открыть зал
        public int SessionID { get; set; }
        public int HallNumber { get; set; }

        public void FillData(System.Data.DataRow row, int index)
        {
            SessionID = Convert.ToInt32(row["Сеанс_ИД"]);
            HallNumber = Convert.ToInt32(row["Зал"]);

            Rname.Text = row["Название"].ToString();
            Rcountry.Text = row["Страны"].ToString();
            Ryear.Text = Convert.ToDateTime(row["Год"]).Year.ToString() + " г.";
            Rpg.Text = "Рейтинг: " + row["Рейтинг"].ToString();
            Rzal.Text = "Зал №" + row["Зал"].ToString();
            Rform.Text = row["Форматы"].ToString();
            Rlen.Text = row["Длительность"].ToString() + " мин.";
            Rtime.Text = row["Время_Начала"].ToString();


            // Расчет "Через сколько минут"
            DateTime sessionTime = Convert.ToDateTime(row["Дата_Время"]);
            TimeSpan diff = sessionTime - DateTime.Now;

            if (diff.TotalMinutes > 0 && diff.TotalMinutes <= 180) // Показываем, если осталось меньше 3 часов
            {
                Rwhen.Text = $"Через {(int)diff.TotalMinutes} мин.";
            }
            else
            {
                Rwhen.Text = ""; // Скрываем, если сеанс не скоро или в другой день
            }
            toolTip1.SetToolTip(Rname, row["Название"].ToString());
        }
        private void Child_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
    }
}
