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
    public partial class RunnerControl : Form
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime();
        public RunnerControl()
        {
            InitializeComponent();
            date = new DateTime(2020, 11, 24, 6, 0, 0);
            timer1.Start();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            try
            {
                DataStorage.rEmail = dataGridView1[1, d].Value.ToString();
                DataStorage.rFName = dataGridView1[2, d].Value.ToString();
                DataStorage.rLName = dataGridView1[3, d].Value.ToString();
                DataStorage.rStatus = dataGridView1[4, d].Value.ToString();
                RunnerControl2 RC2 = new RunnerControl2();
                RC2.Show();
                Hide();
            }
            catch
            {
                MessageBox.Show("Данной ячейки не существует!");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d = date - DateTime.Now;
            Ltimer.Text = "До начала марафона осталось: " + d.Days + " д. " + d.Hours + " ч. " + d.Minutes + " мин. " + d.Seconds + " с. ";
        }

        private void RunnerControl_Load(object sender, EventArgs e)
        {
            string connection = "Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;";
            MySqlConnection connect = new MySqlConnection(connection);
            MySqlCommand command = new MySqlCommand("SELECT runner.Email, user.FirstName, user.LastName, registrationstatus.RegistrationStatus FROM user " +
                "INNER JOIN runner INNER JOIN registration INNER JOIN registrationstatus WHERE registration.RunnerId = runner.RunnerId AND user.Email = runner.Email " +
                "AND registration.RegistrationStatusId = registrationstatus.RegistrationStatusId;", connect);

            MySqlDataAdapter da = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.AllowUserToAddRows = false;
                            
            da.Fill(table);

            dataGridView1.DataSource = table;

            da.Dispose();

            int c = 0; // кол-во бегунов
            connect.Open();
            MySqlCommand myCommand = new MySqlCommand("SELECT COUNT(*) as count FROM registration", connect);
            MySqlDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                c = reader.GetInt32(0);
            }
            reader.Close();
            connect.Close();

            TotalRunners.Text = $"{c}";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KoordMenu KM = new KoordMenu();
            KM.Show();
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

        private void RunnerControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
