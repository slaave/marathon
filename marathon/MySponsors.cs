using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace marathon
{
    public partial class MySponsors : Form
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime();
        public MySponsors()
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

        private void button5_Click(object sender, EventArgs e)
        {
            RunnerMenu RM = new RunnerMenu();
            RM.Show();
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

        private void MySponsors_Load(object sender, EventArgs e)
        {
                string connection = "Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;";
                MySqlConnection connect = new MySqlConnection(connection);
                MySqlCommand command = new MySqlCommand("SELECT charity.CharityName, charity.CharityDescription FROM charity INNER JOIN " +
                    "registration INNER JOIN runner WHERE registration.RunnerId = runner.RunnerId AND runner.Email = '" + DataStorage.login + "' AND registration.CharityId = charity.CharityId;", connect);
                connect.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Org.Text = reader.GetString(0);
                    Discr.Text = reader.GetString(1);
                }
                reader.Close();
                try
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT charity.CharityLogo FROM charity INNER JOIN " +
                        "registration INNER JOIN runner WHERE registration.RunnerId = runner.RunnerId AND runner.Email = '" + DataStorage.login + "' AND registration.CharityId = charity.CharityId;", connect);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    byte[] img = (byte[])table.Rows[0][0];
                    MemoryStream ms = new MemoryStream(img);
                    pictureBox1.Image = Image.FromStream(ms);
                    da.Dispose();
                }
                catch { }

                command = new MySqlCommand("SELECT SponsorName, Amount FROM sponsorship INNER JOIN runner INNER JOIN registration WHERE sponsorship.RegistrationId = registration.RegistrationId " +
                    "AND runner.RunnerId = registration.RunnerId AND runner.Email = '" + DataStorage.login + "';", connect);

                MySqlDataAdapter da1 = new MySqlDataAdapter(command);

                DataTable table1 = new DataTable();

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowTemplate.Height = 25;
                dataGridView1.AllowUserToAddRows = false;

                da1.Fill(table1);

                dataGridView1.DataSource = table1;

                da1.Dispose();

                double Money = 0;
                for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                {
                    Money += Convert.ToDouble(dataGridView1[1, i].Value);
                }

                TotalMoney.Text = "Всего: " + $"{Money}$";

                connect.Close();

               // MessageBox.Show("Вы еще не зарегистрированны на марафрн!\nТак как Вы не зарегистрированны на марафон, у Вас еще нет ни спонсора ни благотворительной организации.");
        }

        private void MySponsors_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
