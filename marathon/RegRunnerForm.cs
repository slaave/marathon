using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace marathon
{
    public partial class RegRunnerForm : Form
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime();
        public RegRunnerForm()
        {
            InitializeComponent();
            date = new DateTime(2020, 11, 24, 6, 0, 0);
            timer1.Start();
        }

        private void button5_Click(object sender, EventArgs e) // назад
        {
            RunnerForm RF  = new RunnerForm();
            RF.Show();
            Hide();
        }
        // переменный для отслеживания errorprovider
        bool EmailIsValid;
        bool PassIsValid;
        bool PassIsEqually;
        private void button2_Click(object sender, EventArgs e) // регистрация
        {
            // проверка заполненны ли поля
            if (EmailField.Text != String.Empty & PassField1.Text != String.Empty & PassField2.Text != String.Empty & FNameField.Text != String.Empty & LNameField.Text != String.Empty &
                GenderField.Text != String.Empty & PhotoField.Text != String.Empty & DateField.Text != String.Empty & CountryField.Text != String.Empty)
            {
                if (EmailIsValid == true & PassIsValid == true & PassIsEqually == true)
                {
                    // подключение к БД
                    string connection = "Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;";
                    MySqlConnection connect = new MySqlConnection(connection);
                    connect.Open();//открытие соединения
                                   //записи через sql запросы
                    MySqlCommand command = new MySqlCommand("INSERT INTO `user` (`Email`, `Password`, `FirstName`, `LastName`, `RoleId`, `pick`) VALUES('" + EmailField.Text + "', '" + PassField1.Text + 
                        "', '" + FNameField.Text + "', '" + LNameField.Text + "', 'R', @img);", connect);

                    MySqlCommand cmd = new MySqlCommand("INSERT INTO `runner` (`Email`, `Gender`, `DateOfBirth`, `CountryCode`) VALUES('" + EmailField.Text + "', '"
                    + GenderField.Text + "', '" + DateField.Value + "', '" + CountryField.Text + "');", connect);

                    MemoryStream ms = new MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    byte[] img = ms.ToArray();
                    command.Parameters.Add("@img", MySqlDbType.LongBlob);
                    command.Parameters["@img"].Value = img;

                    //проверка была ли команда выполнена успешно
                    if (command.ExecuteNonQuery() == 1 & cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Спасибо за регистрацию!\nТеперь вам необходимо авторизоваться.");
                    }
                    else
                    {
                        MessageBox.Show("Регистрация не прошла.");
                    }
                    connect.Close();  // закрытие соединения
                }
                else 
                {
                    MessageBox.Show("Введённые данные не корректны.");
                }

            }
            else
            {
                MessageBox.Show("Все поля обязательны для заполнения. \nПроверьте все ли Вы ввели."); // ошибка в случе если поьзователь не заполнил все поля
            }
        }

            private void button3_Click(object sender, EventArgs e) // отмена
            {
                RunnerForm frrunner = new RunnerForm();
                frrunner.Show();
                Hide();
            }

            private void button1_Click(object sender, EventArgs e) // обзор
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
            private void timer1_Tick(object sender, EventArgs e) // таймер
            {
            d = date - DateTime.Now;
            Ltimer.Text = "До начала марафона осталось: " + d.Days + " д. " + d.Hours + " ч. " + d.Minutes + " мин. " + d.Seconds + " с. ";
        }
            private void EmailField_Leave(object sender, EventArgs e) // проверяет походит ли email по фрмату
            {
                //....................[x].............................@..[x].............................[.x].............
                string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$"; // шаблон
                if (Regex.IsMatch(EmailField.Text, pattern)) // проверка подходит ли по шаблону
                {
                    EmailIsValid = true;
                    errorEmail.Clear(); // все класс - ошибка не всплывает
                }
                else
                {
                    EmailIsValid = false;
                    errorEmail.SetError(this.EmailField, "Таких адресов не бывает.");// не подходит по шаблону - ошибка всплывает
                    return;
                }
            }
        private void PassField1_Leave(object sender, EventArgs e) // всплыющая ошибка для пароля
        {
            if (PassField1.TextLength > 6)// проверка длинны пароля
            {
                int score = 0;
                Dictionary<string, int> patterns = new Dictionary<string, int> { { @"\d", 5 }, //включает цифры
                                                                         { @"[a-zA-Z]", 10 }, //буквы
                                                                         { @"[!,@,#,\$,%,\^,&,\*,?,_,~]", 15 } }; //символы
                foreach (var pattern in patterns)
                    score += Regex.Matches(PassField1.Text, pattern.Key).Count * pattern.Value;
                //MessageBox.Show(""+score);
                if (score > 50)
                {
                    PassIsValid = true;
                    errorPass1.Clear();// все класс - ошибка не всплывает
                }
                else
                {
                    PassIsValid = false;
                    errorPass1.SetError(this.PassField1, "Напоминание - пароль должен содержать: \n  1) Не менее 6-ти символов. \n  2) Минимум 1 цифру. \n  3) Набор специальных знаков ( ! @ # $ % ^ ). \n  4) Не менее 1-ой прописной буквы.");
                }
            }
            else // пароль короче 6 символов
            {
                PassIsValid = false;
                errorPass1.SetError(this.PassField1, "Напоминание - пароль должен содержать: \n  1) Не менее 6-ти символов. \n  2) Минимум 1 цифру. \n  3) Набор специальных знаков ( ! @ # $ % ^ ). \n  4) Не менее 1-ой прописной буквы.");

            }
        }
        private void PassField2_Leave(object sender, EventArgs e) // всплыющая ошибка для повтора пароля
        {
                if (PassField1.Text == PassField2.Text)
                {
                    PassIsEqually = true;
                    errorPass2.Clear();// если совпадают то ошибка не всплывает
                }
                else
                {
                    PassIsEqually = false;
                    errorPass2.SetError(this.PassField2, "Пароли не совпадают.");// если не совпадают то ошибка всплывает
                    return;
                }
        }
            private void RegRunnerForm_Load(object sender, EventArgs e) // загрузка значений в комбобоксы
            {
            CountryField.DropDownStyle = ComboBoxStyle.DropDownList; // запрет на ввод символов комбобокс

            GenderField.DropDownStyle = ComboBoxStyle.DropDownList; // запрет на ввод символов комбобокс
            // для стран
            string connection = "Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;"; // адрес БД
                MySqlConnection connect = new MySqlConnection(connection);
                connect.Open(); // поключение к БД
                                // выбор значений через SQL запрос
                MySqlCommand command1 = new MySqlCommand("Select concat(CountryCode) from country Where 1", connect);
                MySqlDataReader reader1 = command1.ExecuteReader(); // объявление ридера
                while (reader1.Read())
                {
                    CountryField.Items.Add(reader1.GetString(0)); // добавление в комбобокс
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
                    GenderField.Items.Add(reader11.GetString(0)); // добавление в комбобокс
                }
                reader11.Close();
                connect.Close();

                DateField.MaxDate = new DateTime(2010, 6, 20);
            }

        private void RegRunnerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        
    }
}
