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
    public partial class KoordMenu : Form
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime();
        public KoordMenu()
        {
            InitializeComponent();
            date = new DateTime(2020, 11, 24, 6, 0, 0);
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e) // бегуны
        {
            RunnerControl CER = new RunnerControl();
            CER.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e) // спонсоры
        {
            Sponsorship s = new Sponsorship();
            s.Show();
            Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d = date - DateTime.Now;
            Ltimer.Text = "До начала марафона осталось: " + d.Days + " д. " + d.Hours + " ч. " + d.Minutes + " мин. " + d.Seconds + " с. ";
        }

        private void button6_Click(object sender, EventArgs e)// logout
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

        private void KoordMenu_Load(object sender, EventArgs e)
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

        private void KoordMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
