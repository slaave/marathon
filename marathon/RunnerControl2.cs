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
    public partial class RunnerControl2 : Form
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime();
        public RunnerControl2()
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

        private void button1_Click(object sender, EventArgs e)
        {
            CoordEditRunner CER = new CoordEditRunner();
            CER.Show();
            Hide();
        }

        private void RunnerControl2_Load(object sender, EventArgs e)
        {
            string connection = "Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;";
            MySqlConnection connect = new MySqlConnection(connection);
            MySqlCommand command = new MySqlCommand("SELECT runner.Gender, runner.DateOfBirth, country.CountryName, charity.CharityName, registration.Cost, " +
                "registration.RaceKitOptionId FROM runner INNER JOIN country INNER JOIN registration INNER JOIN charity WHERE runner.Email = '" + DataStorage.rEmail + "' " +
                "AND charity.CharityId =  registration.CharityId AND runner.RunnerId = registration.RunnerId AND country.CountryCode = runner.CountryCode;", connect);
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT user.pick FROM user WHERE Email = '" + DataStorage.rEmail + "';", connect);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                byte[] img = (byte[])table.Rows[0][0];
                MemoryStream ms = new MemoryStream(img);
                pictureBox1.Image = Image.FromStream(ms);
                da.Dispose();
            }
            catch { }

            connect.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DataStorage.rGender = reader.GetString("Gender");
                DataStorage.rDate = reader.GetString("DateOfBirth");
                DataStorage.rCountry = reader.GetString("CountryName");
                DataStorage.rCharity = reader.GetString("CharityName"); 
                DataStorage.rDonate = reader.GetString("Cost"); ;
                DataStorage.rKit = reader.GetString("RaceKitOptionId");
            }
            reader.Close();
            connect.Close();

            Email.Text = DataStorage.rEmail;
            FName.Text = DataStorage.rFName;
            LName.Text = DataStorage.rLName;
            Gender.Text = DataStorage.rGender;
            DateB.Text = DataStorage.rDate;
            Country.Text = DataStorage.rCountry;
            Donate.Text = DataStorage.rDonate;
            Kit.Text = "Вариант " + DataStorage.rKit;
            Charity.Text = DataStorage.rCharity;
            if (DataStorage.rStatus == "Registered")
            {
                errorProvider1.SetError(this.L1, "+");
                errorProvider2.SetError(this.L2, "-");
                errorProvider2.SetError(this.L3, "-");
                errorProvider2.SetError(this.L4, "-");   
            }
            if (DataStorage.rStatus == "Payment Confirmed")
            {
                errorProvider1.SetError(this.L2, "+");
                errorProvider1.SetError(this.L1, "+");
                errorProvider2.SetError(this.L3, "-");
                errorProvider2.SetError(this.L4, "-");
            }
            if (DataStorage.rStatus == "Race Kit Sent")
            {
                errorProvider1.SetError(this.L3, "+");
                errorProvider1.SetError(this.L2, "+");
                errorProvider1.SetError(this.L1, "+");
                errorProvider2.SetError(this.L4, "-");
            }
            if (DataStorage.rStatus == "Race Attended")
            {
                errorProvider1.SetError(this.L4, "+");
                errorProvider1.SetError(this.L2, "+");
                errorProvider1.SetError(this.L3, "+");
                errorProvider1.SetError(this.L1, "+");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RunnerControl RL = new RunnerControl();
            RL.Show();
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

        private void RunnerControl2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
