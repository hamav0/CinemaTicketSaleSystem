using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        public string username { get; private set; }
        public string password { get; private set; }
        private void button1_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            password = textBox2.Text;
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND PasswordHash = HASHBYTES('SHA2_256', @Password)";
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=База_Кинотеатра_Имя;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    conn.Open();
                    int userCount = (int)cmd.ExecuteScalar();

                    if (userCount > 0)
                    {
                        MessageBox.Show("Успешный вход!");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверное имя пользователя или пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
    }
}
