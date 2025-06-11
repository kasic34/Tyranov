using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Каминский
{
    public partial class Form1 : Form
    {
        public static string ConnectString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True";

        // Цветовая палитра
        private readonly Color primaryColor = Color.FromArgb(51, 51, 76);
        private readonly Color secondaryColor = Color.FromArgb(231, 76, 60);
        private readonly Color lightBackground = Color.FromArgb(240, 240, 240);
        private readonly Color successColor = Color.FromArgb(46, 204, 113);

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            ApplyDesign();

            CenterControlsInGroupBox(groupBox1);
            CenterControlsInGroupBox(groupBox2);
        }

        /// <summary>
        /// Применяет дизайн ко всем элементам управления
        /// </summary>
        private void ApplyDesign()
        {
            // Настройка основной формы
            this.BackColor = lightBackground;
            this.Padding = new Padding(10);
            this.Text = "Система авторизации";
            this.Font = new Font("Times New Roman", 14, FontStyle.Regular); 

            // GroupBox
            GroupBox[] groups = { groupBox1, groupBox2 };
            foreach (var group in groups)
            {
                group.BackColor = Color.White;
                group.ForeColor = primaryColor;
                group.Font = new Font("Times New Roman", 14, FontStyle.Bold); 
                group.Padding = new Padding(10);
                group.FlatStyle = FlatStyle.Flat;
            }

            // Стили Label
            foreach (Control control in this.Controls)
            {
                if (control is Label lbl)
                {
                    lbl.ForeColor = primaryColor;
                    lbl.Font = new Font("Times New Roman", 14, FontStyle.Regular); 
                }
            }

            // Стили TextBox
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.BackColor = Color.White;
                    textBox.Font = new Font("Times New Roman", 14); 
                    textBox.ForeColor = Color.Black;
                    textBox.Margin = new Padding(5);
                }
            }

            // Кнопка регистрации
            StyleButton(button3, primaryColor, Color.FromArgb(123, 123, 123));

            // Кнопка входа
            StyleButton(button4, secondaryColor, Color.FromArgb(251, 96, 80));
        }


        private void StyleButton(Button btn, Color baseColor, Color hoverColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = baseColor;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Times New Roman", 14, FontStyle.Bold); 
            btn.Cursor = Cursors.Hand;
            btn.Height = 40;
            btn.Width = 140;
            btn.Margin = new Padding(5);
            btn.MouseEnter += (s, e) => btn.BackColor = hoverColor;
            btn.MouseLeave += (s, e) => btn.BackColor = baseColor;
        }


        /// <summary>
        /// Хэширование строки с использованием MD5
        /// </summary>
        public string md5(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in data)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // ===== РЕГИСТРАЦИЯ =====
       

        // ===== АВТОРИЗАЦИЯ =====
       

        /// <summary>
        /// Показывает сообщение с заданными параметрами
        /// </summary>
        private void ShowMessage(string text, string caption, MessageBoxIcon icon)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, icon);
        }

        /// <summary>
        /// Очищает поля регистрации
        /// </summary>
        private void ClearRegistrationFields()
        {
            FIO.Clear();
            LoginReg.Clear();
            PasswordReg.Clear();
            PasswordReg2.Clear();
        }

        /// <summary>
        /// Очищает поля авторизации
        /// </summary>
        private void ClearAuthFields()
        {
            LoginAuth.Clear();
            PasswordAuth.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Валидация полей
            if (string.IsNullOrWhiteSpace(FIO.Text) ||
                string.IsNullOrWhiteSpace(LoginReg.Text) ||
                string.IsNullOrWhiteSpace(PasswordReg.Text))
            {
                ShowMessage("Все поля обязательны для заполнения", "Ошибка ввода", MessageBoxIcon.Warning);
                return;
            }

            if (PasswordReg.Text != PasswordReg2.Text)
            {
                ShowMessage("Пароли не совпадают", "Ошибка проверки", MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectString))
                {
                    connection.Open();

                    string query = "INSERT INTO [Users] ([FIO], [Login], [Password]) VALUES (@fio, @login, @password)";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@fio", FIO.Text.Trim());
                    command.Parameters.AddWithValue("@login", LoginReg.Text.Trim());
                    command.Parameters.AddWithValue("@password", md5(PasswordReg.Text));

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        ShowMessage("Регистрация прошла успешно!", "Успех", MessageBoxIcon.Information);
                        ClearRegistrationFields();
                    }
                }
            }
            catch (SqlException ex)
            {
                ShowMessage($"Ошибка базы данных:\n{ex.Message}", "Ошибка регистрации", MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ShowMessage($"Непредвиденная ошибка:\n{ex.Message}", "Ошибка", MessageBoxIcon.Error);
            }
        }

        private void CenterControlsInGroupBox(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                // Центрирование по горизонтали относительно GroupBox
                control.Left = (groupBox.ClientSize.Width - control.Width) / 2;
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginAuth.Text) ||
               string.IsNullOrWhiteSpace(PasswordAuth.Text))
            {
                ShowMessage("Введите логин и пароль", "Ошибка ввода", MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectString))
                {
                    connection.Open();

                    string query = "SELECT [FIO], [Login], [Password], [role] FROM [Users] WHERE [Login] = @login";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@login", LoginAuth.Text.Trim());

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHash = reader["Password"].ToString();
                            if (storedHash == md5(PasswordAuth.Text))
                            {
                                string fio = reader["FIO"].ToString();
                                string role = reader["role"].ToString();

                                ShowMessage($"Добро пожаловать, {fio}!\nВаша роль: {role}",
                                           "Авторизация успешна",
                                           MessageBoxIcon.Information);
                                ClearAuthFields();
                            }
                            else
                            {
                                ShowMessage("Неверный пароль", "Ошибка авторизации", MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            ShowMessage("Пользователь не найден", "Ошибка авторизации", MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ShowMessage($"Ошибка базы данных:\n{ex.Message}", "Ошибка авторизации", MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ShowMessage($"Непредвиденная ошибка:\n{ex.Message}", "Ошибка", MessageBoxIcon.Error);
            }
        }
    }
}