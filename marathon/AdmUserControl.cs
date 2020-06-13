using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace marathon
{
    public partial class AdmUserControl : Form
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime();
        public AdmUserControl()
        {
            InitializeComponent();
            date = new DateTime(2020, 11, 24, 6, 0, 0);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d = date - DateTime.Now;
            Ltimer.Text = "До начала марафона осталось: " + d.Days + " д. " + d.Hours + " ч. " + d.Minutes + " мин. " + d.Seconds + " с. ";
        }

        private void AdmUserControl_Load(object sender, EventArgs e)
        {
            string connection = "Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;";
            MySqlConnection connect = new MySqlConnection(connection);
            MySqlCommand command = new MySqlCommand("SELECT user.FirstName, user.LastName, user.Email, role.RoleName FROM user INNER JOIN role WHERE role.RoleId = user.RoleId;", connect);

            MySqlDataAdapter da = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.AllowUserToAddRows = false;

            da.Fill(table);

            dataGridView1.DataSource = table;

            da.Dispose();

            int c = 0; // кол-во пользователей
            connect.Open();
            MySqlCommand myCommand = new MySqlCommand("SELECT COUNT(*) as count FROM user", connect);
            MySqlDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                c = reader.GetInt32(0);
            }
            reader.Close();
            connect.Close();

            TotalUsers.Text = $"{c}";

            Filter.DropDownStyle = ComboBoxStyle.DropDownList; // запрет на ввод символов комбобокс

            connect.Open(); // поключение к БД
            // выбор значений через SQL запрос
            command = new MySqlCommand("SELECT * FROM `role`", connect);
            MySqlDataReader reader1 = command.ExecuteReader(); // объявление ридера
            while (reader1.Read())
            {
                Filter.Items.Add(reader1.GetString(1)); // добавление в комбобокс
            }
            reader1.Close();
            connect.Close(); // закрытие соединения
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Filter.Text != String.Empty)
            {
                string connection = "Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;";
                MySqlConnection connect = new MySqlConnection(connection);
                MySqlCommand command = new MySqlCommand("SELECT user.FirstName, user.LastName, user.Email, role.RoleName FROM user INNER JOIN role WHERE role.RoleId = user.RoleId AND role.RoleName = '" + Filter.Text + "';", connect);

                MySqlDataAdapter da = new MySqlDataAdapter(command);

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowTemplate.Height = 25;
                dataGridView1.AllowUserToAddRows = false;

                DataTable table = new DataTable();

                da.Fill(table);

                dataGridView1.DataSource = table;

                da.Dispose();

                int c = 0; // кол-во пользователей
                connect.Open();
                MySqlCommand myCommand = new MySqlCommand("SELECT COUNT(*) as count FROM user INNER JOIN role WHERE user.RoleId = role.RoleId AND role.RoleName = '" + Filter.Text + "';", connect);
                MySqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    c = reader.GetInt32(0);
                }
                reader.Close();
                connect.Close();

                TotalUsers.Text = $"{c}";
            }
            else
            {
                MessageBox.Show("Ничего не выбрано.");
            }
        }

        public void searchData(string valueToFind)
        {
            string connection = "Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;";
            MySqlConnection connect = new MySqlConnection(connection);
            string searchQuery = "SELECT user.FirstName, user.LastName, user.Email, role.RoleName FROM user INNER JOIN role on role.RoleId = user.RoleId WHERE CONCAT(user.FirstName,user.LastName,user.Email) LIKE '%" + valueToFind + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, connect);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

        }

        private void Serch_TextChanged(object sender, EventArgs e)
        {
            searchData(Serch.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            try
            {
                DataStorage.rEmail = dataGridView1[3, d].Value.ToString();
                DataStorage.rFName = dataGridView1[1, d].Value.ToString();
                DataStorage.rLName = dataGridView1[2, d].Value.ToString();
                
                UserEdit UE = new UserEdit();
                UE.Show();
                Hide();
            }
            catch
            {
                MessageBox.Show("Данной ячейки не существует!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewUser NU = new NewUser();
            NU.Show();
            Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            Hide();

            DataStorage.login = "";
            DataStorage.role = "";
            DataStorage.firsname = "";
            DataStorage.lasname = "";
            DataStorage.image = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminMenu AM = new AdminMenu();
            AM.Show();
            Hide();
        }

        private void AdmUserControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
