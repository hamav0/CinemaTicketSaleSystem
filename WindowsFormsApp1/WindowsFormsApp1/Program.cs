using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK) // Успешная авторизация
            {
                string username = loginForm.username;
                string password = loginForm.password;
                Application.Run(new Form1(username, password));
            }
            else
            {
                // Если авторизация не удалась, завершаем приложение
                Application.Exit();
            }

        }
    }
}
