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
    public partial class Sponsorship : Form
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime();
        MySqlConnection connection = new MySqlConnection("Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;");
        public Sponsorship()
        {
            InitializeComponent();
            date = new DateTime(2020, 11, 24, 6, 0, 0);
            timer1.Start();
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
            KoordMenu KM = new KoordMenu();
            KM.Show();
            Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d = date - DateTime.Now;
            Ltimer.Text = "До начала марафона осталось: " + d.Days + " д. " + d.Hours + " ч. " + d.Minutes + " мин. " + d.Seconds + " с. ";
        }

        private void Sponsorship_Load(object sender, EventArgs e)
        {
            string selectQuery = "SELECT charity.CharityName, charity.CharityLogo FROM charity;";
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 55;
            dataGridView1.AllowUserToAddRows = false;

            da.Fill(table);

            dataGridView1.DataSource = table;

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)dataGridView1.Columns[1];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

            da.Dispose();

            int c = 0; // кол-во организаций
            connection.Open();
            MySqlCommand myCommand = new MySqlCommand("SELECT COUNT(*) as count FROM `charity`", connection);
            MySqlDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                c = reader.GetInt32(0);
            }
            reader.Close();
            connection.Close();

            int d = 0; // кол-во организаций
            connection.Open();
            MySqlCommand Command = new MySqlCommand("SELECT `Amount` FROM `sponsorship` WHERE 1", connection);
            MySqlDataReader reader1 = Command.ExecuteReader();
            while (reader1.Read())
            {
                d += reader1.GetInt32(0);
            }
            reader1.Close();
            connection.Close();

            TotalOrg.Text = $"{c}";
            TotalDolar.Text = $"{d}$";
        }

        private void Sponsorship_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
