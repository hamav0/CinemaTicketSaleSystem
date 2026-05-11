using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormHall : Form
    {
        private readonly int _sessionId;
        private readonly int _hallId;
        private readonly string _connectionString;

        private List<string> _selectedSeats = new List<string>();
        private Dictionary<int, decimal> _seatPrices = new Dictionary<int, decimal>();
        private decimal _totalPrice = 0;

        private float _scale = 1.0f;
        private Point _mouseOffset;
        private bool _isDragging = false;
        private Dictionary<string, Point> _originalLocations = new Dictionary<string, Point>();
        private const int BaseSeatSize = 37;

        public FormHall(int sessionId, string username, string password, int hallId)
        {
            InitializeComponent();

            // Убираем любое мерцание и настраиваем режим фона
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, pnlCanvas, new object[] { true });

            pnlCanvas.BackgroundImageLayout = ImageLayout.None; // Важно: убирает дублирование фона

            _sessionId = sessionId;
            _hallId = hallId;
            _connectionString = $"Server=localhost\\SQLEXPRESS;Database=База_Кинотеатра_Имя;User Id={username};Password={password};";

            SetupEvents();

        }

        private void SetupEvents()
        {
            pnlCanvas.MouseDown += (s, e) => { if (e.Button == MouseButtons.Left) { _isDragging = true; _mouseOffset = e.Location; } };
            pnlCanvas.MouseMove += pnlCanvas_MouseMove;
            pnlCanvas.MouseUp += (s, e) => _isDragging = false;
            btnZoomIn.Click += (s, e) => ApplyZoom(0.3f);
            btnZoomOut.Click += (s, e) => ApplyZoom(-0.3f);
        }

        private void FormHall_Load(object sender, EventArgs e)
        {
            LoadPrices();
            RenderHall();
            UpdateBuyButton(); // Обязательно восстанавливаем кнопку покупки
        }

        private void LoadPrices()
        {
            switch (_hallId)
            {
                case 1:
                    _seatPrices.Clear();
                    _seatPrices.Add(1, 400m);
                    _seatPrices.Add(2, 450m);
                    _seatPrices.Add(3, 500m);
                    break;
                case 2:
                    _seatPrices.Clear();
                    _seatPrices.Add(1, 400m);
                    _seatPrices.Add(2, 550m);
                    _seatPrices.Add(3, 500m);
                    break;
                default:
                    _seatPrices.Clear();
                    _seatPrices.Add(1, 530m);
                    _seatPrices.Add(2, 660m);
                    _seatPrices.Add(3, 560m);
                    break;
            }
           
        }

        private void RenderHall()
        {
            pnlCanvas.Controls.Clear();
            _originalLocations.Clear();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                // Запрос проверяет наличие места в таблице Места для данного сеанса
                string query = $@"
                    SELECT h.Место_ИД, h.Тип_Места, h.Координата_X, h.Координата_Y, 
                    CASE WHEN m.Место_ИД IS NOT NULL THEN 1 ELSE 0 END AS IsSold
                    FROM Зал{_hallId} h
                    LEFT JOIN (
                        SELECT m.Место_ИД 
                        FROM Места m 
                        JOIN Заказы z ON m.Заказ_ИД = z.Заказ_ИД 
                        WHERE z.Сеанс_ИД = @sid
                    ) m ON h.Место_ИД = m.Место_ИД";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@sid", _sessionId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string id = reader["Место_ИД"].ToString();
                    int type = Convert.ToInt32(reader["Тип_Места"]);
                    int x = Convert.ToInt32(reader["Координата_X"]);
                    int y = Convert.ToInt32(reader["Координата_Y"]);
                    bool isSold = Convert.ToInt32(reader["IsSold"]) == 1;

                    _originalLocations[id] = new Point(x, y);

                    Button btn = new Button
                    {
                        Name = id,
                        Tag = type,
                        FlatStyle = FlatStyle.Flat,
                        Cursor = isSold ? Cursors.No : Cursors.Hand,
                        Font = new Font("Arial", 7, FontStyle.Bold),
                        Enabled = !isSold // Занятые места нельзя нажать
                    };

                    if (isSold)
                    {
                        btn.BackColor = Color.Transparent;
                        btn.FlatAppearance.BorderColor = Color.White;
                        btn.Text = "X"; // Пометка занятого места
                        btn.ForeColor = Color.DimGray;
                    }
                    else
                    {
                        btn.BackColor = GetColorByType(type);
                        btn.FlatAppearance.BorderColor = GetColorByType(type);
                        btn.FlatAppearance.BorderSize = 1;
                    }

                    btn.Click += Seat_Click;
                    pnlCanvas.Controls.Add(btn);
                }
            }
            UpdateHallView();
        }

        private void UpdateHallView()
        {
            foreach (Control c in pnlCanvas.Controls)
            {
                if (c is Button btn && _originalLocations.ContainsKey(btn.Name))
                {
                    btn.Size = new Size((int)(BaseSeatSize * _scale), (int)(BaseSeatSize * _scale));
                    btn.Location = new Point(
                        (int)(_originalLocations[btn.Name].X * _scale),
                        (int)(_originalLocations[btn.Name].Y * _scale)
                    );

                    // Обновляем шрифт кнопки при зуме
                    btn.Font = new Font("Arial", Math.Max(6, 8 * _scale), FontStyle.Bold);
                }
            }
            GenerateBackground();
            UpdateCanvasSize();
        }

        private void GenerateBackground()
        {
            if (_originalLocations.Count == 0) return;

            // НАСТРОЙКИ СМЕЩЕНИЙ 
            int offsetTextAboveRows = 50;  // Расстояние от верхнего ряда до надписи "ЭКРАН"
            int offsetImageAboveText = 0; // Расстояние от надписи до самой картинки

            int minX = _originalLocations.Values.Min(p => p.X);
            int maxX = _originalLocations.Values.Max(p => p.X);
            int minY = _originalLocations.Values.Min(p => p.Y);
            int maxY = _originalLocations.Values.Max(p => p.Y);

            // Координаты колонн с номерами рядов
            int columnLeftX = (int)((minX - 60) * _scale);
            int columnRightX = (int)((maxX + BaseSeatSize + 25) * _scale);

            // Вычисляем ширину экрана (между колоннами подписей)
            int screenW = columnRightX - columnLeftX;

            // Создаем Bitmap с запасом сверху под экран
            int topPadding = (int)((offsetTextAboveRows + offsetImageAboveText + 100) * _scale);
            Bitmap bmp = new Bitmap((int)((maxX + 200) * _scale), (int)((maxY + 100) * _scale) + topPadding);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                g.Clear(Color.White);

                // 1. Позиция надписи "ЭКРАН"
                int textY = (int)((minY - offsetTextAboveRows) * _scale);
                int centerX = (int)((minX + (maxX - minX) / 2.0) * _scale);

                Font screenTextFont = new Font("Arial", 12 * _scale + 2, FontStyle.Bold);
                g.DrawString("ЭКРАН", screenTextFont, Brushes.Black,
                             new RectangleF(columnLeftX, textY, screenW, 30 * _scale),
                             new StringFormat { Alignment = StringAlignment.Center });

                // 2. Позиция Изображения экрана
                if (Properties.Resources.Экран != null)
                {
                    Image img = Properties.Resources.Экран;
                    int imgY = (int)((minY - (offsetTextAboveRows + offsetImageAboveText)) * _scale);

                    // Сохраняем пропорции картинки, но растягиваем по ширине screenW
                    float aspect = (float)img.Height / img.Width;
                    int imgH = (int)(screenW * aspect);

                    g.DrawImage(img, columnLeftX, imgY - imgH, screenW, imgH);
                }

                // 3. Рисуем НОМЕРА РЯДОВ
                var rows = _originalLocations.GroupBy(p => p.Key.Split('_')[0]);
                Font rowFont = new Font("Arial", 9 * _scale + 2, FontStyle.Bold);

                foreach (var row in rows)
                {
                    int rowY = (int)(row.First().Value.Y * _scale);
                    string rowNum = row.Key.Replace("s", "");
                    float textOffY = (BaseSeatSize * _scale) / 4;

                    g.DrawString(rowNum, rowFont, Brushes.Gray, columnLeftX, rowY + textOffY);
                    g.DrawString(rowNum, rowFont, Brushes.Gray, columnRightX, rowY + textOffY);
                }
            }

            pnlCanvas.BackgroundImage?.Dispose();
            pnlCanvas.BackgroundImage = bmp;
        }

        private void Seat_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string id = btn.Name;
            int type = (int)btn.Tag;
            decimal price = _seatPrices.ContainsKey(type) ? _seatPrices[type] : 0;
            string seatNumber = id.Split('_').Last();

            if (_selectedSeats.Contains(id))
            {
                _selectedSeats.Remove(id);
                btn.BackColor = GetColorByType(type);
                btn.ForeColor = btn.Parent.ForeColor;
                btn.Text = "";
                btn.FlatAppearance.BorderSize = 1;
                _totalPrice -= price;
            }
            else
            {
                _selectedSeats.Add(id);
                // Новый стиль: Черный фон, белые цифры, цветная рамка
                btn.BackColor = Color.Black;
                btn.ForeColor = Color.White;
                btn.Text = seatNumber;
                btn.FlatAppearance.BorderSize = 2; // Чуть толще рамка при выборе
                _totalPrice += price;
            }

            if (type == 2) HandleSofaNeighbor(id);
            UpdateBuyButton();
        }

        // Восстановленная логика кнопки покупки
        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (_selectedSeats.Count == 0) return;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    // 1. Создаем заказ
                    using (SqlCommand cmdOrder = new SqlCommand("Ввод_Заказы", conn, transaction))
                    {
                        cmdOrder.CommandType = CommandType.StoredProcedure;
                        cmdOrder.Parameters.AddWithValue("@Сеанс_ИД", _sessionId);
                        cmdOrder.Parameters.AddWithValue("@Сумма_Оплаты", _totalPrice);
                        cmdOrder.ExecuteNonQuery();
                    }
                    // 2. Бронируем места
                    foreach (string seatId in _selectedSeats)
                    {
                        using (SqlCommand cmdSeat = new SqlCommand("Ввод_Места", conn, transaction))
                        {
                            cmdSeat.CommandType = CommandType.StoredProcedure;
                            cmdSeat.Parameters.AddWithValue("@Место_ИД", seatId);
                            cmdSeat.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                    MessageBox.Show($"Билеты куплены! Сумма: {_totalPrice:N0} руб.", "Успех");
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Ошибка базы данных: " + ex.Message);
                }
            }
        }

        private void UpdateBuyButton()
        {
            if (_selectedSeats.Count == 0)
            {
                btnBuy.Text = "Выберите места";
                btnBuy.BackColor = Color.LightGray;
                btnBuy.ForeColor = Color.DimGray;
                btnBuy.Enabled = false;
            }
            else
            {
                btnBuy.Text = $"Купить ({_totalPrice:N0} руб.)";
                btnBuy.BackColor = Color.DeepSkyBlue;
                btnBuy.ForeColor = Color.White;
                btnBuy.Enabled = true;
            }
        }

        private void HandleSofaNeighbor(string id)
        {
            var parts = id.Split('_');
            if (parts.Length < 2) return;
            int num = int.Parse(parts[1]);
            string neighborId = $"{parts[0]}_{(num % 2 == 0 ? num + 1 : num - 1)}";

            Control[] found = pnlCanvas.Controls.Find(neighborId, false);
            if (found.Length > 0 && found[0] is Button neighborBtn)
            {
                if (_selectedSeats.Contains(id) != _selectedSeats.Contains(neighborId))
                    Seat_Click(neighborBtn, EventArgs.Empty);
            }
        }

        private void ApplyZoom(float delta)
        {
            _scale = Math.Max(0.4f, Math.Min(2.5f, _scale + delta));
            UpdateHallView();
        }

        private void UpdateCanvasSize()
        {
            int maxX = 0, maxY = 0;
            foreach (Control c in pnlCanvas.Controls)
            {
                if (c.Right > maxX) maxX = c.Right;
                if (c.Bottom > maxY) maxY = c.Bottom;
            }
            pnlCanvas.Size = new Size(maxX + 100, maxY + 100);
        }

        private void pnlCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                pnlCanvas.Left += e.X - _mouseOffset.X;
                pnlCanvas.Top += e.Y - _mouseOffset.Y;
            }
        }

        private Color GetColorByType(int type)
        {
            if (_hallId == 3)
            {
                switch (type)
                {
                    case 1: return Color.LightGreen;
                    case 2: return Color.Purple;
                    case 3: return Color.DarkOrange;
                    default: return Color.Gray;
                }
            }
            else
            {
                switch (type)
                {
                    case 1: return Color.LightSeaGreen;
                    case 2: return Color.Purple;
                    case 3: return Color.DarkOrange;
                    default: return Color.Gray;
                }
            }
        }
    }
}