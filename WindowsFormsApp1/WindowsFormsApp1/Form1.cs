using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string connectionString;
        private string username;
        private string password;
        public Form1(string username, string password)
        {
            InitializeComponent();
            connectionString = $"Server=localhost\\SQLEXPRESS;Database=База_Кинотеатра_Имя;User Id={username};Password={password};";
            this.username = username;
            this.password = password;
            CheckDB();
            LoadFilterLists();
            LoadSessions(DateTime.Today.Date);
        }
        DataTable dtSessions = new DataTable();
        DataView dvSessions;
       
        private void CheckDB()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM View_SessionCards WHERE CAST(Дата_Время AS DATE) < CAST(GETDATE() AS DATE)";
                string sql2 = "SELECT COUNT(*) FROM View_SessionCards";
                SqlCommand check = new SqlCommand(sql, conn);
                SqlCommand check2 = new SqlCommand(sql2, conn);
                int count = (int)check.ExecuteScalar();
                int clear = (int)check2.ExecuteScalar();
                if (count > 0 || clear == 0)
                { // STRING_AGG может не работать на компах колле
                    string refill = @"
                    use База_Кинотеатра_Имя
                    go
                    alter VIEW View_SessionCards AS
                    SELECT 
                        S.Сеанс_ИД,
                        R.Название,
                        R.Возрастной_Рейтинг AS Рейтинг,
                        R.Год_Производства AS Год,
                        R.Хронометраж_Минут AS Длительность,
                        S.Номер_Зала AS Зал,
                        S.Дата_Время,
                        FORMAT(S.Дата_Время, 'HH:mm') AS Время_Начала,
                        ISNULL((SELECT STRING_AGG(Str.Название, ', ') 
                                FROM База_Релизов.dbo.Страны Str JOIN База_Релизов.dbo.Релиз_Страны RS ON Str.Страна_ИД = RS.Страна_ИД 
                                WHERE RS.Релиз_ИД = R.Релиз_ИД), 'Не указано') AS Страны,
                        ISNULL((SELECT STRING_AGG(F.Название, ', ') 
                                FROM База_Релизов.dbo.Форматы F JOIN Сеансы_Форматы SF ON F.Формат_ИД = SF.Формат_ИД 
                                WHERE SF.Сеанс_ИД = S.Сеанс_ИД), 'Стандарт') AS Форматы,
                        ISNULL((SELECT STRING_AGG(D.Название, ', ') 
                                FROM База_Релизов.dbo.Дистрибьюторы D JOIN База_Релизов.dbo.Релиз_Дистрибьюторы RD ON D.Дистрибьютор_ИД = RD.Дистрибьютор_ИД 
                                WHERE RD.Релиз_ИД = R.Релиз_ИД), 'Не указан') AS Дистрибьюторы
                    FROM База_Кинотеатра_Имя.dbo.Сеансы S
                    JOIN База_Релизов.dbo.Релизы R ON S.Релиз_ИД = R.Релиз_ИД
                    WHERE S.Дата_Время >= CAST(GETDATE() AS DATE);";
                    new SqlCommand(refill, conn).ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        private void LoadFilterLists()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmdFormats = new SqlCommand("SELECT Название FROM База_Релизов.dbo.Форматы", conn);
                using (SqlDataReader r = cmdFormats.ExecuteReader())
                {
                    clbFormats.Items.Clear();
                    while (r.Read()) clbFormats.Items.Add(r["Название"].ToString());
                }
                SqlCommand cmdDist = new SqlCommand("SELECT Название FROM База_Релизов.dbo.Дистрибьюторы", conn);
                using (SqlDataReader r = cmdDist.ExecuteReader())
                {
                    clbDist.Items.Clear();
                    while (r.Read()) clbDist.Items.Add(r["Название"].ToString());
                } 
                SqlCommand cmdName = new SqlCommand("SELECT Название FROM База_Релизов.dbo.Релизы", conn);
                using (SqlDataReader r = cmdName.ExecuteReader())
                {
                    clbName.Items.Clear();
                    while (r.Read()) clbName.Items.Add(r["Название"].ToString());
                } // other ones
            }
        }
        private void LoadSessions(DateTime targetDate)
        {
            flpSessions.Controls.Clear(); // Очистка старых карточек

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Берем данные из View, фильтруем только по дате и времени чтобы не показывать старые
                string query = "SELECT * FROM View_SessionCards WHERE CAST(Дата_Время AS DATE) = @date AND Дата_Время > GETDATE() ORDER BY Дата_Время";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@date", targetDate);

                dtSessions.Clear();
                adapter.Fill(dtSessions);
                int i = 0;
                foreach (DataRow row in dtSessions.Rows)
                {
                    UserControl1 card = new UserControl1();
                    card.FillData(row, i++);

                    // Событие клика для открытия заказа
                    card.Click += (s, e) => OpenBooking(card.SessionID, card.HallNumber);
                    if (i % 2 == 0) // Для каждой четной карточки
                    {
                        card.BackColor = Color.LightGray;
                    }
                    else
                    {
                        card.BackColor = Color.White;
                    }
                    flpSessions.Controls.Add(card);
                }
                dvSessions = new DataView(dtSessions);
                UpdateSessionCards();
                // Проверка на пустоту
                lblNotFound.Visible = (dtSessions.Rows.Count == 0);
            }
        }

        private void rbToday_CheckedChanged(object sender, EventArgs e)
        {
            if (rbToday.Checked) {
                LoadSessions(DateTime.Today.Date); 
            }
        }

        private void rbTomorrow_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTomorrow.Checked)
            {
                LoadSessions(DateTime.Today.Date.AddDays(1));
            }
        }

        private void rbCustomDate_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCustomDate.Checked)
            {
                dtpCalendar.Visible = true;
            }
            else dtpCalendar.Visible = false;  
        }
        private void dtpCalendar_ValueChanged(object sender, EventArgs e)
        {
            LoadSessions(dtpCalendar.Value.Date);
        }
        private void Filter_Changed(object sender, EventArgs e)
        {
            ApplyFilters();
        } // «Окно» в данные для фильтрации
        private void UpdateSessionCards()
        {
            flpSessions.Controls.Clear();
            flpSessions.SuspendLayout();
            int i = 0;
            foreach (DataRowView rowView in dvSessions)
            {
                UserControl1 card = new UserControl1();
                card.FillData(rowView.Row, i++);

                // Событие клика для открытия заказа
                card.Click += (s, e) => OpenBooking(card.SessionID, card.HallNumber);
                if (i % 2 == 0) // Для каждой четной карточки
                {
                    card.BackColor = Color.LightGray;
                }
                else
                {
                    card.BackColor = Color.White;
                }
                flpSessions.Controls.Add(card);
            }

            flpSessions.ResumeLayout();

            // Проверка на пустоту
            lblNotFound.Visible = (dvSessions.Count == 0);
        }
        private void ApplyFilters()
        {
            
            List<string> mainFilters = new List<string>();

            // Фильтр по времени 
            List<string> timeParts = new List<string>();
            if (cbMorning.Checked) timeParts.Add("(DATEPART(HOUR, Дата_Время) >= 10 AND DATEPART(HOUR, Дата_Время) < 12)");
            if (cbDay.Checked) timeParts.Add("(DATEPART(HOUR, Дата_Время) >= 12 AND DATEPART(HOUR, Дата_Время) < 17)");
            if (cbEvening.Checked) timeParts.Add("(DATEPART(HOUR, Дата_Время) >= 17 AND DATEPART(HOUR, Дата_Время) < 22)");

            if (timeParts.Count > 0)
                mainFilters.Add("(" + string.Join(" OR ", timeParts) + ")");

            // Фильтр по возрастному рейтингу
            List<string> pgParts = new List<string>();
            if (cbPG.Checked) pgParts.Add("'PG'");
            if (cbPG13.Checked) pgParts.Add("'PG-13'");
            if (cbR.Checked) pgParts.Add("'R'");

            if (pgParts.Count > 0)
                mainFilters.Add("Рейтинг IN (" + string.Join(",", pgParts) + ")");

            // Фильтр по залам 
            if (clbHalls.CheckedItems.Count > 0)
            {
                List<string> hallParts = new List<string>();
                foreach (var item in clbHalls.CheckedItems)
                    hallParts.Add(item.ToString());
                mainFilters.Add("Зал IN (" + string.Join(",", hallParts) + ")");
            }

            // Фильтр по форматам, можно изменить на что угодно, или добавиь все фильтры сразу
            // LIKE так как форматов может быть несколько через запятую
            if (clbFormats.CheckedItems.Count > 0)
            {
                List<string> formatParts = new List<string>();
                foreach (var item in clbFormats.CheckedItems)
                    formatParts.Add($"Список_Форматов LIKE '%{item}%'");
                mainFilters.Add("(" + string.Join(" OR ", formatParts) + ")");
            }
            if (clbDist.CheckedItems.Count > 0)
            {
                List<string> distParts = new List<string>();
                foreach (var item in clbDist.CheckedItems)
                    distParts.Add($"Дистрибьюторы LIKE '%{item}%'");
                mainFilters.Add("(" + string.Join(" OR ", distParts) + ")");
            }
            if (clbName.CheckedItems.Count > 0)
            {
                List<string> nameParts = new List<string>();
                foreach (var item in clbName.CheckedItems)
                    nameParts.Add($"Название LIKE '%{item}%'");
                mainFilters.Add("(" + string.Join(" OR ", nameParts) + ")");
            } // есть проблема с Терминатор, так как используется условие Like, то подходят все три, вместо первого
            // к сожалению не исправил
              // применяем итоговую строку
            dvSessions.RowFilter = string.Join(" AND ", mainFilters);

            // перерисовываем интерфейс
            UpdateSessionCards();
        }

        private void clb_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // BeginInvoke чтобы фильтр читал уже обновленное состояние
            this.BeginInvoke(new Action(() => ApplyFilters()));
        }
        private void OpenBooking(int sessionId, int hallNumber)
        {
            Form hallForm = null;
            hallForm = new FormHall(sessionId, username, password, hallNumber);
            if (hallForm != null)
            {
                hallForm.ShowDialog();
                UpdateSessionCards();
            }
        }
    }
}
