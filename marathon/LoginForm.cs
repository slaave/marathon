using MySql.Data.MySqlClient;
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
    public partial class LoginForm : Form
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime();
        public LoginForm()

        {
            InitializeComponent();
            date = new DateTime(2020, 11, 24, 6, 0, 0);
            timer1.Start();
        }

        private void button5_Click(object sender, EventArgs e) // Назад
        {
            Form fr1 = new Form1();
            fr1.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e) // отмена
        {
            RunnerForm frrunner = new RunnerForm();
            frrunner.Show();
            Hide();
        }

        private void buttonlogin_Click(object sender, EventArgs e)// логин
        {
            // подключение к БД
            string connection = "Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;";
            MySqlConnection connect = new MySqlConnection(connection);
            connect.Open();
            // ищем нужную запись в БД через SQL запрос
            MySqlCommand command = new MySqlCommand("SELECT COUNT(*) ,RoleId,Password,Email,FirstName,LastName,pick " + "FROM user "
                + "WHERE Email LIKE'" + loginField.Text + "'" + " AND " + "Password LIKE '" + passwordField.Text + "';", connect);
            int countuser = 0;
            // запись значений
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                countuser = reader.GetInt32(0);
                DataStorage.role = reader.GetString("RoleId");
                DataStorage.login = reader.GetString("Email");
                DataStorage.firsname = reader.GetString("FirstName");
                DataStorage.lasname = reader.GetString("LastName");
                try
                {
                    DataStorage.image = reader.GetString("pick");
                }
                catch
                {
                    DataStorage.image = "";
                }
            }
            reader.Close();
            if (countuser != 0) // проверка на данных на совпадение с БД
            { // распределение в зависимоти от роли
                if (DataStorage.role == "R") // для бегуна
                {
                    RunnerMenu runnermenu = new RunnerMenu();
                    runnermenu.Show();
                    this.Hide();
                }
                if (DataStorage.role == "A") // для администратора
                {
                    AdminMenu form = new AdminMenu();
                    form.Show();
                    this.Hide();
                }
                if (DataStorage.role == "C") // для координатора
                {
                    KoordMenu koordmenu = new KoordMenu();
                    koordmenu.Show();
                    this.Hide();
                }
                connect.Close(); // отключение от БД
            }
            else
            {
                MessageBox.Show("Не верно введен логин или пароль"); // оповещени о том что пользователя с такими данными нет
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d = date - DateTime.Now;
            Ltimer.Text = "До начала марафона осталось: " + d.Days + " д. " + d.Hours + " ч. " + d.Minutes + " мин. " + d.Seconds + " с. ";
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
