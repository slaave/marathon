using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace marathon
{
    public partial class CharityControl : Form
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime();
        MySqlConnection connection = new MySqlConnection("Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;");
        MySqlCommand command;
        MySqlDataAdapter da;
        public CharityControl()
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
        
        private void CharityControl_Load(object sender, EventArgs e)
        {
            if (DataStorage.IsItEdit == true)
            {
                try
                {
                    NameBox.Text = DataStorage.OrgName;
                    Discription.Text = DataStorage.OrgDiscr;

                    String selectQuery = "SELECT * FROM charity WHERE CharityName = '" + DataStorage.OrgName + "'";

                    command = new MySqlCommand(selectQuery, connection);
                    da = new MySqlDataAdapter(command);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    byte[] img = (byte[])table.Rows[0][3];
                    MemoryStream ms = new MemoryStream(img);
                    pictureBox1.Image = Image.FromStream(ms);
                    da.Dispose();
                }
                catch 
                {
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) //ОБЗОР
        {
            OpenFileDialog ofd = new OpenFileDialog(); // создание объекта для вызова окна диалога
            ofd.Filter = "Image Files (*.BMP;*.JPG;*.PNG;*JPEG)|*.BMP;*.JPG;*.PNG;*JPEG|All files (*.*)|*.*"; // фильтр для открытия изображения формата BMP, JPG, PNG, JPEG
            if (ofd.ShowDialog() == DialogResult.OK) // проверка выбран ли файл
            {
                try
                {
                    pictureBox1.Image = new Bitmap(ofd.FileName);// загрузка изображения в пикчабокс
                    LogoBox.Text = ofd.FileName;// запись имени изображения в текстбокс
                }
                catch
                {
                    MessageBox.Show("Не возможно открыть выбранный файл"); // сообщение об ошибке если выбрано не изображение
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) // СОХРАНИТЬ ( ДА Я ПОНИМАЮ что можно было бы сделать кароче все это но мне было лень думать, я устал уже)
        {
            if (DataStorage.IsItEdit == false) // INSERT
            {
                if (NameBox.Text != String.Empty & Discription.Text != String.Empty)
                {
                    if (LogoBox.Text != String.Empty) // если есть картинка
                    {
                        connection.Open();//открытие соединения
                                          //записи через sql запросы
                        MySqlCommand command = new MySqlCommand("INSERT INTO `charity` (`CharityName`, `CharityDescription`, `CharityLogo`) VALUES('" + NameBox.Text + "', '"
                            + Discription.Text + "', @img);", connection);
                        MemoryStream ms = new MemoryStream();
                        pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                        byte[] img = ms.ToArray();
                        command.Parameters.Add("@img", MySqlDbType.LongBlob);
                        command.Parameters["@img"].Value = img;
                        //проверка была ли команда выполнена успешно
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Организация добавлена.");
                        }
                        else
                        {
                            MessageBox.Show("Организация не добавлена.");
                        }
                        connection.Close();  // закрытие соединения
                    }
                    else // если нет картинки
                    {
                        connection.Open();//открытие соединения
                        //записи через sql запросы
                        MySqlCommand command = new MySqlCommand("INSERT INTO `charity` (`CharityName`, `CharityDescription`) VALUES('" + NameBox.Text + "', '"
                            + Discription.Text + "');", connection);
                        //проверка была ли команда выполнена успешно
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Организация добавлена.");
                        }
                        else
                        {
                            MessageBox.Show("Организация не добавлена.");
                        }
                        connection.Close();  // закрытие соединения
                    }
                }
                else
                {
                    MessageBox.Show("Нужно заполнить название и описание.");
                }
            }
            else // UPDATE
            {
                if (NameBox.Text != String.Empty & Discription.Text != String.Empty)
                {
                    if (LogoBox.Text != String.Empty) // если есть картинка
                    {
                        connection.Open();//открытие соединения
                                          //записи через sql запросы
                        MySqlCommand command = new MySqlCommand("UPDATE `charity` SET `CharityName` = '" + NameBox.Text + "', `CharityDescription` = '" + Discription.Text +
                            "', `CharityLogo` = @img WHERE `charity`.`CharityId` = '" + DataStorage.CharID + "'; ", connection);
                        MemoryStream ms = new MemoryStream();
                        pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                        byte[] img = ms.ToArray();
                        command.Parameters.Add("@img", MySqlDbType.LongBlob);
                        command.Parameters["@img"].Value = img;

                        //проверка была ли команда выполнена успешно
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Организация добавлена.");
                        }
                        else
                        {
                            MessageBox.Show("Организация не добавлена.");
                        }
                        connection.Close();  // закрытие соединения
                    }
                    else // если нет картинки
                    {
                        connection.Open();//открытие соединения
                        //записи через sql запросы
                        MySqlCommand command = new MySqlCommand("UPDATE `charity` SET `CharityName` = '" + NameBox.Text + "', `CharityDescription` = '" + Discription.Text + "'WHERE `charity`.`CharityId` = '" + DataStorage.CharID + "'; ", connection);
                        //проверка была ли команда выполнена успешно
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Организация добавлена.");
                        }
                        else
                        {
                            MessageBox.Show("Организация не добавлена.");
                        }
                        connection.Close();  // закрытие соединения
                    }
                }
                else
                {
                    MessageBox.Show("Нужно заполнить название и описание.");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e) // НАЗАД
        {
            AdminOrgList AOL = new AdminOrgList();
            AOL.Show();
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

        private void button3_Click(object sender, EventArgs e)
        {
            AdminOrgList AOL = new AdminOrgList();
            AOL.Show();
            Hide();
        }

        private void CharityControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
