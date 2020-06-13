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
    public partial class RegMarathone : Form
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime();
        double price = 0;
        double temp;
        DateTime RegDateTime = DateTime.Now; // получение текущей даты и времни
        char RaceKitOption;
        
        public RegMarathone()
        {
            InitializeComponent();
            date = new DateTime(2020, 11, 24, 6, 0, 0);
            timer1.Start();
        }
        private void button1_Click(object sender, EventArgs e) // регистрация
        {
            if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked)
            {
                if (varA.Checked || varB.Checked || varC.Checked)
                {
                    if (temp > 0 & temp != 0)
                    {
                        if (comboBox1.SelectedIndex >= 0)
                        {
                            string connection = "Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;"; // адрес БД
                            MySqlConnection connect = new MySqlConnection(connection);
                            connect.Open(); // поключение к БД
                                            // выбор значений через SQL запрос
                            MySqlCommand command1 = new MySqlCommand("SELECT RunnerId " + "FROM runner "
                            + "WHERE Email LIKE'" + DataStorage.login + "';", connect);
                            int runnerID = 0;
                            MySqlDataReader reader1 = command1.ExecuteReader(); // объявление ридера
                            while (reader1.Read())
                            {
                                runnerID = reader1.GetInt32(0); // добавление в комбобокс
                            }
                            reader1.Close();
                            connect.Close(); // закрытие соединения

                            connect.Open();
                            int charityID = comboBox1.SelectedIndex + 1;
                            MySqlCommand command = new MySqlCommand("INSERT INTO `registration` (`RunnerId`, `RegistrationDateTime`, `RaceKitOptionId`, `RegistrationStatusId`, " +
                             "`Cost`, `CharityId`) VALUES('" + runnerID + "', '" + RegDateTime + "', '" + RaceKitOption + "', '1', '" + price + "', '" + charityID + "');", connect);
                            MySqlDataReader reader = command.ExecuteReader();
                                while (reader.Read())
                                {
                                }
                                reader.Close();
                                connect.Close();

                            RegRunnerEnd RGE = new RegRunnerEnd();
                            RGE.Show();
                            Hide();
                        }
                        else
                            MessageBox.Show("Не выбран взнос.");
                    }
                    else
                        MessageBox.Show("Сумма взноса должна быть действительным положительным числом");
                }
                else
                    MessageBox.Show("Нужно выбрать комплект.");
            }
            else
                MessageBox.Show("По крайней мере 1 вид марафона должен быть выбран.");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d = date - DateTime.Now;
            Ltimer.Text = "До начала марафона осталось: " + d.Days + " д. " + d.Hours + " ч. " + d.Minutes + " мин. " + d.Seconds + " с. ";
        }

        private void RegMarathone_Load(object sender, EventArgs e)// загрузка значений в комбобокс
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; // запрет на ввод символов комбобокс

            string connection = "Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;"; // адрес БД
            MySqlConnection connect = new MySqlConnection(connection);
            connect.Open(); // поключение к БД
            // выбор значений через SQL запрос
            MySqlCommand command = new MySqlCommand("Select concat(CharityName) from charity Where 1", connect);
            MySqlDataReader reader = command.ExecuteReader(); // объявление ридера
            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetString(0)); // добавление в комбобокс
            }
            reader.Close();
            connect.Close(); // закрытие соединения
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                price += 145;
            else
                price -= 145;
            MLabel.Text = $"{price}$";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                price += 75;
            else
                price -= 75;
            MLabel.Text = $"{price}$";
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                price += 20;
            else
                price -= 20;
            MLabel.Text = $"{price}$";
        }

        private void varA_CheckedChanged(object sender, EventArgs e)
        {
            if (varA.Checked)
            {
                RaceKitOption = 'A';
                price += 0;
            }
            else
                price -= 0;
            MLabel.Text = $"{price}$";
        }

        private void varB_CheckedChanged(object sender, EventArgs e)
        {
            if (varB.Checked)
            {
                RaceKitOption = 'B';
                price += 20;
            }
            else
            {
                RaceKitOption = 'A';
                price -= 20;
            }
            MLabel.Text = $"{price}$";
        }

        private void varC_CheckedChanged(object sender, EventArgs e)
        {
            if (varC.Checked)
            {
                RaceKitOption = 'C';
                price += 45;
            }
            else
            {
                RaceKitOption = 'A';
                price -= 45;
            }
            MLabel.Text = $"{price}$";
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.Text != String.Empty)
            {
                string connection = "Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;"; // адрес БД
                MySqlConnection connect = new MySqlConnection(connection);
                connect.Open(); // поключение к БД
                                // выбор значений через SQL запрос
                MySqlCommand command = new MySqlCommand("SELECT COUNT(*) CharityId,CharityDescription " + "FROM charity "
                + "WHERE CharityName LIKE'" + comboBox1.Text + "';", connect);
                string charitydiscr = "";
                MySqlDataReader reader = command.ExecuteReader(); // объявление ридера
                while (reader.Read())
                {
                   // charityID = reader.GetInt32(0);
                    charitydiscr = reader.GetString("CharityDescription");
                }
                reader.Close();
                connect.Close(); // закрытие соединения
                info.SetError(this.comboBox1, charitydiscr);
            }
            else
            {
                info.Clear();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) // ввод только чисел в текстбокс
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
            temp = double.Parse(textBox1.Text);
        }

        private void button5_Click(object sender, EventArgs e) // назад
        {
            RunnerMenu rmenu = new RunnerMenu();
            rmenu.Show();
            Hide();
        }

        private void textBox1_Layout(object sender, LayoutEventArgs e)
        {
            temp = double.Parse(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RunnerMenu rmenu = new RunnerMenu();
            rmenu.Show();
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

        private void RegMarathone_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
