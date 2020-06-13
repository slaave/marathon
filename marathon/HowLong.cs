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
    public partial class HowLong : Form
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime();
        MySqlConnection connection = new MySqlConnection("Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;");
        MySqlCommand command;
        MySqlDataAdapter da;
        public HowLong()
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

        private void HowLong_Load(object sender, EventArgs e)
        {
            string selectQuery = "SELECT image, name FROM `speed`";
            command = new MySqlCommand(selectQuery, connection);
            da = new MySqlDataAdapter(command);

            DataTable table1 = new DataTable();
            DataTable table2 = new DataTable();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 55;
            dataGridView1.AllowUserToAddRows = false;

            da.Fill(table1);

            dataGridView1.DataSource = table1;

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)dataGridView1.Columns[0];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

            da.Dispose();

            command = new MySqlCommand("SELECT image, name FROM `distance`", connection);
            da = new MySqlDataAdapter(command);

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.RowTemplate.Height = 55;
            dataGridView2.AllowUserToAddRows = false;

            da.Fill(table2);

            dataGridView2.DataSource = table2;

            DataGridViewImageColumn imageColumn1 = new DataGridViewImageColumn();
            imageColumn1 = (DataGridViewImageColumn)dataGridView2.Columns[0];
            imageColumn1.ImageLayout = DataGridViewImageCellLayout.Zoom;

            da.Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string speed = "";
            double c = 0;
            int d = e.RowIndex;
            try
            {
                NameL.Text = "Имя выбранного пункта: " + dataGridView1[1, d].Value.ToString();
                string connection = "Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;";
                MySqlConnection connect = new MySqlConnection(connection);
                MySqlCommand command = new MySqlCommand("SELECT `top speed` FROM `speed` WHERE name = '" + dataGridView1[1, d].Value.ToString() + "';", connect);
                connect.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    speed = reader.GetString(0);
                }
                reader.Close();
                connect.Close();

                string str = speed;
                str = str.Substring(0, str.Length - 4);
               c = double.Parse(str);
                double ccc = 42 / c;

                DiscrL.Text = "Максимальная скорость " + dataGridView1[1, d].Value.ToString() + " - " + speed + ". Это займет " + ccc + " ч. чтобы завершить 42km марафон.";
                try
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT image FROM `speed` WHERE name = '" + dataGridView1[1, d].Value.ToString() + "';", connect);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    byte[] img = (byte[])table.Rows[0][0];
                    MemoryStream ms = new MemoryStream(img);
                    pictureBox1.Image = Image.FromStream(ms);
                    da.Dispose();
                }
                catch { }
            }
            catch
            {
                MessageBox.Show("Данной ячейки не существует!");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string len = "";
            int d = e.RowIndex;
            double c = 0;
            try
            {
                NameL.Text = "Имя выбранного пункта: " + dataGridView2[1, d].Value.ToString();
                string connection = "Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;";
                MySqlConnection connect = new MySqlConnection(connection);
                MySqlCommand command = new MySqlCommand("SELECT length FROM `distance` WHERE name = '" + dataGridView2[1, d].Value.ToString() + "';", connect);
                connect.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    len = reader.GetString(0);
                }
                reader.Close();
                connect.Close();

                string str = len;
                    str = str.Substring(0, str.Length - 1);
                c = double.Parse(str);
                double ccc = 42000 / c;

                DiscrL.Text = "Длина " + dataGridView2[1, d].Value.ToString()+ " - " + len + ". Это займет "+ ccc + " из них, чтобы покрыть расстояние в 42 км марафона.";
                try
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT image FROM `distance` WHERE name = '" + dataGridView2[1, d].Value.ToString() + "';", connect);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    byte[] img = (byte[])table.Rows[0][0];
                    MemoryStream ms = new MemoryStream(img);
                    pictureBox1.Image = Image.FromStream(ms);
                    da.Dispose();
                }
                catch { }
            }
            catch
            {
                MessageBox.Show("Данной ячейки не существует!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            InfoForm IF = new InfoForm();
            IF.Show();
            Hide();
        }

        private void HowLong_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
