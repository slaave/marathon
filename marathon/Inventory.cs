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
    public partial class Inventory : Form
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime();
        MySqlConnection connection = new MySqlConnection("Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;");
        MySqlCommand command;
        MySqlDataAdapter da;
        public Inventory()
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

        private void Inventory_Load(object sender, EventArgs e)
        {
            dataGridView2.Rows[0].Cells[0].Value = "Выброло этот вариант";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) as count FROM `registration` WHERE RaceKitOptionId ='A'", connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) { DataStorage.a = reader.GetInt32(0); }
            reader.Close();
            connection.Close();

            dataGridView2.Rows[0].Cells[1].Value = DataStorage.a;

            connection.Open();
            cmd = new MySqlCommand("SELECT COUNT(*) as count FROM `registration` WHERE RaceKitOptionId ='B'", connection);
            reader = cmd.ExecuteReader();
            while (reader.Read()) { DataStorage.b = reader.GetInt32(0); }
            reader.Close();
            connection.Close();

            dataGridView2.Rows[0].Cells[2].Value = DataStorage.b;

            connection.Open();
            cmd = new MySqlCommand("SELECT COUNT(*) as count FROM `registration` WHERE RaceKitOptionId ='C'", connection);
            reader = cmd.ExecuteReader();
            while (reader.Read()) { DataStorage.c = reader.GetInt32(0); }
            reader.Close();
            connection.Close();

            dataGridView2.Rows[0].Cells[3].Value = DataStorage.c;
          
            string selectQuery = "SELECT inventory.Инвентарь, inventory.A, inventory.B, inventory.C, skald.Остаток FROM inventory INNER JOIN skald WHERE inventory.Инвентарь = skald.name;";
            command = new MySqlCommand(selectQuery, connection);
            da = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.AllowUserToAddRows = false;

            da.Fill(table);

            dataGridView1.DataSource = table;

            dataGridView1.Columns[0].DisplayIndex = 4;

            DataGridViewImageColumn imageColumn1 = new DataGridViewImageColumn();
            imageColumn1 = (DataGridViewImageColumn)dataGridView1.Columns[2];
            imageColumn1.ImageLayout = DataGridViewImageCellLayout.Zoom;
            DataGridViewImageColumn imageColumn2 = new DataGridViewImageColumn();
            imageColumn2 = (DataGridViewImageColumn)dataGridView1.Columns[3];
            imageColumn2.ImageLayout = DataGridViewImageCellLayout.Zoom;
            DataGridViewImageColumn imageColumn3 = new DataGridViewImageColumn();
            imageColumn3 = (DataGridViewImageColumn)dataGridView1.Columns[4];
            imageColumn3.ImageLayout = DataGridViewImageCellLayout.Zoom;

            da.Dispose();

            for (int i = 0; i <= 1; i++) { DataStorage.need = DataStorage.a + DataStorage.b + DataStorage.c; dataGridView1.Rows[i].Cells[0].Value = DataStorage.need; }
            for (int i = 2; i <= 3; i++) { DataStorage.need = DataStorage.b + DataStorage.c; dataGridView1.Rows[i].Cells[0].Value = DataStorage.need; }
            for (int i = 4; i <= 5; i++) { DataStorage.need = DataStorage.c; dataGridView1.Rows[i].Cells[0].Value = DataStorage.need; }        

            int r = 0; // кол-во регистраций
            connection.Open();
            MySqlCommand myCommand = new MySqlCommand("SELECT COUNT(*) as count FROM `registration`", connection);
            MySqlDataReader myreader = myCommand.ExecuteReader();
            while (myreader.Read())
            {
                r = myreader.GetInt32(0);
            }
            myreader.Close();
            connection.Close();

            label4.Text = $"{r}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Otchet o = new Otchet();
            o.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Postupleniyacs P = new Postupleniyacs();
            P.Show();
            Hide();
        }

        private void Inventory_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
