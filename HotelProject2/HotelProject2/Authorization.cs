using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace HotelProject2
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }



        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            
        }

        // Установка плейсхолдера
        private string placeholderTextLogin = "Логин";

        // Инициализация
        private void InitializePlaceholderLogin()
        {
            textBoxLogin.Text = placeholderTextLogin;
            textBoxLogin.ForeColor = Color.Gray;
            textBoxLogin.GotFocus += RemovePlaceholderLogin;
            textBoxLogin.LostFocus += SetPlaceholderLogin;
        }

        private void RemovePlaceholderLogin(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == placeholderTextLogin)
            {
                textBoxLogin.Text = "";
                textBoxLogin.ForeColor = Color.Black;
            }
        }

        private void SetPlaceholderLogin(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxLogin.Text))
            {
                textBoxLogin.Text = placeholderTextLogin;
                textBoxLogin.ForeColor = Color.Gray;
            }
        }

        // Установка плейсхолдера
        private string placeholderTextPassword = "Пароль";

        // Инициализация
        private void InitializePlaceholderPassword()
        {
            textBoxPassword.Text = placeholderTextPassword;
            textBoxPassword.ForeColor = Color.Gray;
            textBoxPassword.GotFocus += RemovePlaceholderPassword;
            textBoxPassword.LostFocus += SetPlaceholderPassword;
        }

        private void RemovePlaceholderPassword(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == placeholderTextPassword)
            {
                textBoxPassword.Text = "";
                textBoxPassword.ForeColor = Color.Black;
            }
        }

        private void SetPlaceholderPassword(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                textBoxPassword.Text = placeholderTextPassword;
                textBoxPassword.ForeColor = Color.Gray;
            }
        }

        private void Authorization_Load(object sender, EventArgs e)
        {
            InitializePlaceholderLogin();
            InitializePlaceholderPassword();
        }

        private void buttonEntrance_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "admin")
            {
                if (textBoxPassword.Text == "admin")
                {
                    FormAdmin admin = new FormAdmin();
                    admin.ShowDialog();
                }
            }
            else
                MessageBox.Show("Неправильный логин или пароль", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
