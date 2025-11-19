using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelProject2
{
    public partial class FormAdmin : Form
    {
        String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DatabaseHotel.mdf;Integrated Security = True";
        private Dictionary<string, string> tables;
        
        private string currentTable;


        public FormAdmin()
        {
            InitializeComponent();
            InitializeTables();
            LoadTables();
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {

        }

        private void InitializeTables()
        {
            tables = new Dictionary<string, string>
            {
                { "Categories", "SELECT * FROM Categories" },
                { "Roles", "SELECT * FROM Roles" },
                { "RoomOccupancy", "SELECT * FROM RoomOccupancy" },
                { "Rooms", "SELECT * FROM Rooms" },
                { "StatusCleaning", "SELECT * FROM StatusCleaning" },
                { "StatusRoom", "SELECT * FROM StatusRoom" },
                { "Users", "SELECT * FROM Users" }
            };
        }

        private void LoadTables()
        {
            comboBoxTables.DataSource = new List<string>(tables.Keys);
            comboBoxTables.SelectedIndexChanged += ComboBoxTables_SelectedIndexChanged;
            dataGridView.SelectionChanged += DataGridView_SelectionChanged;
            // Загружаем первую таблицу по умолчанию
            if (comboBoxTables.Items.Count > 0)
            {
                comboBoxTables.SelectedIndex = 0;
            }
        }

        private void ComboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTable = comboBoxTables.SelectedItem.ToString();
            LoadTableData(currentTable);
        }

        private void LoadTableData(string tableName)
        {
            string query = tables[tableName];

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView.DataSource = dt;
            }
            // Очистка связанных данных при смене таблицы
            dataGridViewRelated.DataSource = null;
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null || currentTable == null)
                return;

            int selectedId = -1;
            string idColumn = "ID"; // предполагается, что у всех таблиц есть поле ID

            if (dataGridView.CurrentRow.Cells[idColumn].Value != null)
            {
                selectedId = Convert.ToInt32(dataGridView.CurrentRow.Cells[idColumn].Value);
            }
            else
            {
                return;
            }

            switch (currentTable)
            {
                case "Categories":
                    ShowCategoryRoles(selectedId);
                    ShowCategoryRooms(selectedId);
                    break;
                case "Roles":
                    ShowRoleCategories(selectedId);
                    break;
                case "Rooms":
                    ShowRoomOccupancy(selectedId);
                    break;
                case "RoomOccupancy":
                    ShowOccupancyRooms(selectedId);
                    break;
                case "StatusCleaning":
                    ShowStatusCleaningDetails(selectedId);
                    break;
                case "StatusRoom":
                    ShowStatusRoomDetails(selectedId);
                    break;
                case "Users":
                    ShowUserDetails(selectedId);
                    break;
                default:
                    dataGridViewRelated.DataSource = null;
                    break;
            }
        }

        private void ShowCategoryRoles(int IDCategory)
        {
            string query = $@"
        SELECT r.* FROM Roles r
        WHERE r.CategoryID = {IDCategory}";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewRelated.DataSource = dt;
            }
        }

        private void ShowCategoryRooms(int IDCategory)
        {
            string query = $@"
        SELECT r.* FROM Rooms r
        WHERE r.CategoryID = {IDCategory}";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewRelated.DataSource = dt;
            }
        }

        private void ShowRoleCategories(int roleId)
        {
            string query = $@"
        SELECT c.* FROM Categories c
        INNER JOIN Roles r ON c.ID = r.CategoryID
        WHERE r.ID = {roleId}";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewRelated.DataSource = dt;
            }
        }

        private void ShowRoomOccupancy(int roomId)
        {
            string query = $@"
        SELECT ro.* FROM RoomOccupancy ro
        WHERE ro.RoomID = {roomId}";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewRelated.DataSource = dt;
            }
        }

        private void ShowOccupancyRooms(int occupancyId)
        {
            string query = $@"
        SELECT r.* FROM Rooms r
        INNER JOIN RoomOccupancy ro ON r.ID = ro.RoomID
        WHERE ro.ID = {occupancyId}";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewRelated.DataSource = dt;
            }
        }

        private void ShowStatusCleaningDetails(int statusCleaningId)
        {
            string query = $@"
        SELECT sc.* FROM StatusCleaning sc
        WHERE sc.ID = {statusCleaningId}";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewRelated.DataSource = dt;
            }
        }

        private void ShowStatusRoomDetails(int statusRoomId)
        {
            string query = $@"
        SELECT sr.* FROM StatusRoom sr
        WHERE sr.ID = {statusRoomId}";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewRelated.DataSource = dt;
            }
        }

        private void ShowUserDetails(int userId)
        {
            string query = $@"
        SELECT u.* FROM Users u
        WHERE u.ID = {userId}";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewRelated.DataSource = dt;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
