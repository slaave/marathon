using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace marathon
{
    public partial class NewUser : Form
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime();
        bool PassIsEqually;
        bool PassIsValid;
        bool EmailIsValid;
        public NewUser()
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
            if (EmailBox.Text != String.Empty & textBox7.Text != String.Empty & textBox8.Text != String.Empty & FNameBox.Text != String.Empty & LNameBox.Text != String.Empty &
                roleBox.Text != String.Empty)
            {
                if (EmailIsValid == true & PassIsValid == true & PassIsEqually == true)
                {
                    string connection = "Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;";
                    MySqlConnection connect = new MySqlConnection(connection);
                    char roleID = 'a';
                    if (roleBox.SelectedIndex == 0) { roleID = 'A'; }
                    else if (roleBox.SelectedIndex == 1) { roleID = 'C'; }
                    else if (roleBox.SelectedIndex == 2) { roleID = 'R'; }
                    connect.Open();//открытие соединения
                                   //записи через sql запросы
                    MySqlCommand command = new MySqlCommand("INSERT INTO `user` (`Email`, `Password`, `FirstName`, `LastName`, `RoleId`) VALUES('" + EmailBox.Text + "', '" + textBox7.Text +
                        "', '" + FNameBox.Text + "', '" + LNameBox.Text + "', '"+roleID+"');", connect);

                    //проверка была ли команда выполнена успешно
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Hегистрация прошла успешно.");
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

        private void EmailBox_Leave(object sender, EventArgs e)
        {
            //....................[x].............................@..[x].............................[.x].............
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$"; // шаблон
            if (Regex.IsMatch(EmailBox.Text, pattern)) // проверка подходит ли по шаблону
            {
                EmailIsValid = true;
                errorProvider1.Clear(); // все класс - ошибка не всплывает
            }
            else
            {
                EmailIsValid = false;
                errorProvider1.SetError(this.EmailBox, "Таких адресов не бывает.");// не подходит по шаблону - ошибка всплывает
                return;
            }
        }

        private void NewUser_Load(object sender, EventArgs e)
        {
            roleBox.DropDownStyle = ComboBoxStyle.DropDownList; // запрет на ввод символов комбобокс
            string connection = "Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;";
            MySqlConnection connect = new MySqlConnection(connection);
            MySqlCommand command = new MySqlCommand("SELECT * FROM `role`", connect);
            connect.Open();
            MySqlDataReader reader = command.ExecuteReader(); // объявление ридера
            while (reader.Read())
            {
                roleBox.Items.Add(reader.GetString(1)); // добавление в комбобокс
            }
            reader.Close();
            connect.Close(); // закрытие соединения
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdmUserControl AUC = new AdmUserControl();
            AUC.Show();
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

        private void NewUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
