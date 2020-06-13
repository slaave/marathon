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
    public partial class RunnerMenu : Form
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime();
        public RunnerMenu()
        {
            InitializeComponent();
            date = new DateTime(2020, 11, 24, 6, 0, 0);
            timer1.Start();
        }

        private void button5_Click(object sender, EventArgs e) // мои результаты
        {
            MessageBox.Show("У вас нет результатов с предыдущих марафонов.");
        }

        private void button6_Click(object sender, EventArgs e) // logout
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

        private void button1_Click(object sender, EventArgs e) //регистрация на марафон
        {
            RegMarathone regMarathone = new RegMarathone();
            regMarathone.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e) // редактирование профиля
        {
            EditProfileRunner EPR = new EditProfileRunner();
            EPR.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e) // контакты
        {
            MessageBox.Show("Для получения дополнительной информации\nпожалуйста свяжитесь с координаторами.\n\nТелефон: +55-11-9988-7766\n\nEmail: coordinators@maratonskills.org");
        }

        private void button4_Click(object sender, EventArgs e) // мой спонсор
        {
            string connection = "Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;";
            MySqlConnection connect = new MySqlConnection(connection);
            MySqlCommand command = new MySqlCommand("SELECT registration.RegistrationId FROM registration INNER JOIN runner WHERE registration.RunnerId = runner.RunnerId " +
                "AND runner.Email = '"+DataStorage.login+"';", connect);
            connect.Open();
            int check = 0;
           // bool IsUserReg;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                check = reader.GetInt32(0);
            }
            reader.Close();
            if (check != 0)
            {
                MySponsors MS = new MySponsors();
                MS.Show();
                Hide();
            }
            else 
            {
                MessageBox.Show("Вы еще не зарегистрированны на марафон!\nТак как Вы не зарегистрированны на марафон, у Вас еще нет ни спонсора ни благотворительной организации.");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d = date - DateTime.Now;
            Ltimer.Text = "До начала марафона осталось: " + d.Days + " д. " + d.Hours + " ч. " + d.Minutes + " мин. " + d.Seconds + " с. ";
        }

        private void RunnerMenu_Load(object sender, EventArgs e)
        {
            UserName.Text = (DataStorage.firsname + " " + DataStorage.lasname);
            
            try
            {
                string connection = "Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;";
                MySqlConnection connect = new MySqlConnection(connection);
                MySqlCommand cmd = new MySqlCommand("SELECT user.pick FROM user WHERE user.Email = '" + DataStorage.login + "';", connect);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                byte[] img = (byte[])table.Rows[0][0];
                MemoryStream ms = new MemoryStream(img);
                Avatar.Image = Image.FromStream(ms);
                da.Dispose();
            }
            catch { }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Ltimer_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RunnerMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
