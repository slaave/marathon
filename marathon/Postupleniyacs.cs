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
    public partial class Postupleniyacs : Form
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime();
        MySqlConnection connection = new MySqlConnection("Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;");
        MySqlCommand command;
        MySqlDataAdapter da;
        public Postupleniyacs()
        {
            InitializeComponent();
            date = new DateTime(2020, 11, 24, 6, 0, 0);
            timer1.Start();
        }

        private void Postupleniyacs_Load(object sender, EventArgs e)
        {
            string selectQuery = "SELECT inventory.Инвентарь FROM inventory;";
            command = new MySqlCommand(selectQuery, connection);
            da = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.AllowUserToAddRows = false;

            da.Fill(table);

            dataGridView1.DataSource = table;

            dataGridView1.Columns[0].DisplayIndex = 1;

            da.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d = date - DateTime.Now;
            Ltimer.Text = "До начала марафона осталось: " + d.Days + " д. " + d.Hours + " ч. " + d.Minutes + " мин. " + d.Seconds + " с. ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string a = ""; int x=0; string name = ""; int ost = 0;
            for (int i = 0; i <= 5; i++)
            {
                x = 0; a = "";

                if (dataGridView1[0, i].Value != null)
                {
                    a = dataGridView1[0, i].Value.ToString();
                }
                if (a != "")
                {
                    name = dataGridView1[1, i].Value.ToString();
                    x = Convert.ToInt32(a);

                    command = new MySqlCommand("SELECT Остаток FROM `skald` WHERE name = '" + name +"';", connection);
                    connection.Open();
                    MySqlDataReader r = command.ExecuteReader();
                    while(r.Read())
                    {
                        ost = r.GetInt32(0);
                    }
                    r.Close();
                    connection.Close();
                    int newost = ost + x;
                    if (newost < 0)
                    { MessageBox.Show("Кол-во инвенторя (" + name + ") на складе составляет: " + ost); }
                    else 
                    {
                        command = new MySqlCommand("UPDATE `skald` SET `Остаток`= '" + newost + "' WHERE skald.name = '" + name + "';", connection);
                        connection.Open();
                        if (command.ExecuteNonQuery() == 1)
                        { MessageBox.Show("Изменения внесены."); }
                        connection.Close();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            Inventory I = new Inventory();
            I.Show();
            Hide();
        }

        private void Postupleniyacs_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
