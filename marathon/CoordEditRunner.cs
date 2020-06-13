using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace marathon
{
    public partial class CoordEditRunner : Form
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime();
        bool PassIsEqually;
        bool PassIsValid;
        public CoordEditRunner()
        {
            InitializeComponent();
            date = new DateTime(2020, 11, 24, 6, 0, 0);
            timer1.Start();
        }

        private void CoordEditRunner_Load(object sender, EventArgs e)
        {
            label9.Text = DataStorage.rEmail;
            // для стран
            string connection = "Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;"; // адрес БД
            MySqlConnection connect = new MySqlConnection(connection);
            connect.Open(); // поключение к БД
                            // выбор значений через SQL запрос
            MySqlCommand command1 = new MySqlCommand("Select concat(CountryCode) from country Where 1", connect);
            MySqlDataReader reader1 = command1.ExecuteReader(); // объявление ридера
            while (reader1.Read())
            {
                CountryBox.Items.Add(reader1.GetString(0)); // добавление в комбобокс
            }
            reader1.Close();
            connect.Close();
            // для пола
            connect.Open();// поключение к БД
                           // выбор значений через SQL запрос
            MySqlCommand command11 = new MySqlCommand("Select concat(Gender) from gender Where 1", connect);
            MySqlDataReader reader11 = command11.ExecuteReader();
            while (reader11.Read())
            {
                GenderBox.Items.Add(reader11.GetString(0)); // добавление в комбобокс
            }
            reader11.Close();
            MySqlCommand command111 = new MySqlCommand("Select concat(RegistrationStatus) from registrationstatus Where 1", connect);
            MySqlDataReader reader111 = command111.ExecuteReader();
            while (reader111.Read())
            {
                StatusBox.Items.Add(reader111.GetString(0)); // добавление в комбобокс
            }
            reader111.Close();
            connect.Close();
            DateBox.MaxDate = new DateTime(2010, 6, 20);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d = date - DateTime.Now;
            Ltimer.Text = "До начала марафона осталось: " + d.Days + " д. " + d.Hours + " ч. " + d.Minutes + " мин. " + d.Seconds + " с. ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog(); // создание объекта для вызова окна диалога
            ofd.Filter = "Image Files (*.BMP;*.JPG;*.PNG;*JPEG)|*.BMP;*.JPG;*.PNG;*JPEG|All files (*.*)|*.*"; // фильтр для открытия изображения формата BMP, JPG, PNG, JPEG
            if (ofd.ShowDialog() == DialogResult.OK) // проверка выбран ли файл
            {
                try
                {
                    pictureBox1.Image = new Bitmap(ofd.FileName);// загрузка изображения в пикчабокс
                    PhotoField.Text = ofd.FileName;// запись имени изображения в текстбокс
                }
                catch
                {
                    MessageBox.Show("Не возможно открыть выбранный файл"); // сообщение об ошибке если выбрано не изображение
                }
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.TextLength > 6)// проверка длинны пароля
            {
                if (textBox7.TextLength > 6)// проверка длинны пароля
                {
                    int score = 0;
                    Dictionary<string, int> patterns = new Dictionary<string, int> { { @"\d", 5 }, //включает цифры
                                                                         { @"[a-zA-Z]", 10 }, //буквы
                                                                         { @"[!,@,#,\$,%,\^,&,\*,?,_,~]", 15 } }; //символы
                    foreach (var pattern in patterns)
                        score += Regex.Matches(textBox7.Text, pattern.Key).Count * pattern.Value;
                    if (score > 15)
                    {
                        PassIsValid = true;
                        textBox7.Clear();// все класс - ошибка не всплывает
                    }
                    else
                    {
                        PassIsValid = false;
                        errorProvider1.SetError(this.textBox7, "Напоминание - пароль должен содержать: \n  1) Не менее 6-ти символов. \n  2) Минимум 1 цифру. \n  3) Набор специальных знаков ( ! @ # $ % ^ ). \n  4) Не менее 1-ой прописной буквы.");
                    }
                }
                else // пароль короче 6 символов
                {
                    PassIsValid = false;
                    errorProvider2.SetError(this.textBox7, "Напоминание - пароль должен содержать: \n  1) Не менее 6-ти символов. \n  2) Минимум 1 цифру. \n  3) Набор специальных знаков ( ! @ # $ % ^ ). \n  4) Не менее 1-ой прописной буквы.");

                }
            }
            else // пароль короче 6 символов
            {
                PassIsValid = false;
                errorProvider1.SetError(this.textBox7, "Напоминание - пароль должен содержать: \n  1) Не менее 6-ти символов. \n  2) Минимум 1 цифру. \n  3) Набор специальных знаков ( ! @ # $ % ^ ). \n  4) Не менее 1-ой прописной буквы.");

            }
        
    }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Text == textBox7.Text)
            {
                PassIsEqually = true;
                errorProvider2.Clear();// если совпадают то ошибка не всплывает
            }
            else
            {
                PassIsEqually = false;
                errorProvider2.SetError(this.textBox8, "Пароли не совпадают.");// если не совпадают то ошибка всплывает
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e) // СОХРАНИТЬ
        {
            int statusID = StatusBox.SelectedIndex + 1;
            if (FNameBox.Text != String.Empty & LNameBox.Text != String.Empty & GenderBox.Text != String.Empty & DateBox.Text != String.Empty & CountryBox.Text != String.Empty)
            {

                string connection = "Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;";
                MySqlConnection connect = new MySqlConnection(connection);
                MySqlCommand findID = new MySqlCommand("SELECT runner.RunnerId FROM runner WHERE Email = '" + label9.Text + "';", connect);
                connect.Open();
                MySqlDataReader reader1 = findID.ExecuteReader();
                int rID = 0;
                while (reader1.Read())
                {
                    rID = reader1.GetInt32(0);
                }
                reader1.Close();
                connect.Close();
                MySqlCommand command1 = new MySqlCommand("UPDATE `runner` SET `Gender` = '" + GenderBox.Text + "', `DateOfBirth` = '" + DateBox.Value + "', `CountryCode` = '" + CountryBox.Text + "' WHERE `runner`.`Email` = '" + label9.Text + "'; ", connect);
                MySqlCommand command = new MySqlCommand("UPDATE `user` SET `FirstName` = '" + FNameBox.Text + "', `LastName` = '" + LNameBox.Text + "', `RoleId` = 'R', `pick` = @img WHERE `user`.`Email` = '" + label9.Text + "';", connect);
                MySqlCommand cmd = new MySqlCommand("UPDATE `registration` SET `RegistrationStatusId` = '" + statusID + "' WHERE `registration`.`RunnerId` = '"+ rID +"';", connect);
                connect.Open();
                if (textBox7.Text != String.Empty & textBox8.Text != String.Empty)
                {
                    if (PassIsEqually == true & PassIsValid == true)
                    {

                        command = new MySqlCommand("UPDATE `user` SET `Password` = '" + textBox8.Text + "', `FirstName` = '" + FNameBox.Text + "', `LastName` = '" + LNameBox.Text + "', `RoleId` = 'R', `pick` = @img WHERE `user`.`Email` = '" + label9.Text + "';", connect);
                    }
                }
                else
                {
                    command = new MySqlCommand("UPDATE `user` SET `FirstName` = '" + FNameBox.Text + "', `LastName` = '" + LNameBox.Text + "', `RoleId` = 'R', `pick` = @img WHERE `user`.`Email` = '" + label9.Text + "';", connect);
                }
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] img = ms.ToArray();
                command.Parameters.Add("@img", MySqlDbType.LongBlob);
                command.Parameters["@img"].Value = img;

                if (command.ExecuteNonQuery() == 1 & cmd.ExecuteNonQuery() == 1 & command1.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Информация обновлена.");
                }
                connect.Close();
            }
            else
            {
                MessageBox.Show("Все поля кроме пароля обязательны для заполнения");
            }
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
            RunnerControl2 RC2 = new RunnerControl2();
            RC2.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RunnerControl2 RC2 = new RunnerControl2();
            RC2.Show();
            Hide();
        }

        private void CoordEditRunner_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
