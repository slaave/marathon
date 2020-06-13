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
    public partial class Volunteer : Form
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime();
        public Volunteer()
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

        private void Volunteer_Load(object sender, EventArgs e)
        {
            string connection = "Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;";
            MySqlConnection connect = new MySqlConnection(connection);
            MySqlCommand command = new MySqlCommand("SELECT volunteer.FirstName, volunteer.LastName, volunteer.Gender, country.CountryName FROM volunteer INNER JOIN country WHERE volunteer.CountryCode = country.CountryCode;", connect);
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.AllowUserToAddRows = false;

            da.Fill(table);

            dataGridView1.DataSource = table;

            da.Dispose();

            int c = 0; // кол-во волонтеров
            connect.Open();
            MySqlCommand myCommand = new MySqlCommand("SELECT COUNT(*) as count FROM volunteer", connect);
            MySqlDataReader reader = myCommand.ExecuteReader(); 
            while (reader.Read())
            {
                c = reader.GetInt32(0);
            }
            reader.Close();
            connect.Close();

            label4.Text = $"{c}";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminMenu AM = new AdminMenu();
            AM.Show();
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

        private void Volunteer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
