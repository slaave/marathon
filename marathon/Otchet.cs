using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace marathon
{
    public partial class Otchet : Form
    {
        MySqlConnection connection = new MySqlConnection("Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;");
        MySqlCommand command;
        MySqlDataAdapter da;
        public Otchet()
        {
            InitializeComponent();
        }

        private void Otchet_Load(object sender, EventArgs e)
        {
            string selectQuery = "SELECT inventory.Инвентарь, skald.Остаток FROM inventory INNER JOIN skald WHERE inventory.Инвентарь = skald.name;";
            command = new MySqlCommand(selectQuery, connection);
            da = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.AllowUserToAddRows = false;

            da.Fill(table);

            dataGridView1.DataSource = table;

            dataGridView1.Columns[0].DisplayIndex = 3;
            dataGridView1.Columns[1].DisplayIndex = 2;

            da.Dispose();

            for (int i = 0; i <= 1; i++) { DataStorage.need = DataStorage.a + DataStorage.b + DataStorage.c; dataGridView1.Rows[i].Cells[1].Value = DataStorage.need; }
            for (int i = 2; i <= 3; i++) { DataStorage.need = DataStorage.b + DataStorage.c; dataGridView1.Rows[i].Cells[1].Value = DataStorage.need; }
            for (int i = 4; i <= 5; i++) { DataStorage.need = DataStorage.c; dataGridView1.Rows[i].Cells[1].Value = DataStorage.need; }
            try
            {
                for (int i = 0; i <= 6; i++)
                {
                    string a = dataGridView1[1, i].Value.ToString();
                    string b = dataGridView1[3, i].Value.ToString();
                    int x = Convert.ToInt32(a);
                    int y = Convert.ToInt32(a);
                    if (x > y)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = y - x;
                    }
                    else
                    { dataGridView1.Rows[i].Cells[0].Value = 0; }
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDocument Document = new PrintDocument();
            Document.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.Document = Document;
            dlg.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(dataGridView1.Size.Width + 100, dataGridView1.Size.Height + 100);
            dataGridView1.DrawToBitmap(bmp, dataGridView1.Bounds);
            e.Graphics.DrawImage(bmp, 0, 0);

        }

        private void Otchet_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
