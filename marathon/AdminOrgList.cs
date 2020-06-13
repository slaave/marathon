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
    public partial class AdminOrgList : Form
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime();
        MySqlConnection connection = new MySqlConnection("Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;");
        MySqlCommand command;
        MySqlDataAdapter da;
        public AdminOrgList()
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
            DataStorage.IsItEdit = false;
            CharityControl cc = new CharityControl();
            cc.Show();
            Hide();
        }

        private void AdminOrgList_Load(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM `charity`";
            command = new MySqlCommand(selectQuery, connection);
            da = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 55;
            dataGridView1.AllowUserToAddRows = false;

            da.Fill(table);

            dataGridView1.DataSource = table;
            
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)dataGridView1.Columns[4];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

            da.Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

             DataStorage.CharID = e.RowIndex + 1;
                  command = new MySqlCommand("SELECT * FROM `charity` WHERE CharityId LIKE'" + DataStorage.CharID + "';", connection);
              
              connection.Open();
                  MySqlDataReader reader1 = command.ExecuteReader();
                  while (reader1.Read())
                  {
                      DataStorage.OrgName = reader1.GetString("CharityName");
                      DataStorage.OrgDiscr = reader1.GetString("CharityDescription");
                  }
                  reader1.Close();
                  connection.Close();
            DataStorage.IsItEdit = true;
                  CharityControl cc = new CharityControl();
                  cc.Show();
                  Hide();
            // }
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

        private void AdminOrgList_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
