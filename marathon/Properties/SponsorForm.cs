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

namespace marathon.Properties
{
    public partial class SponsorForm : Form
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime();
        bool CardTime;
        bool CardSize;
        public SponsorForm()
        {
            InitializeComponent();
            date = new DateTime(2020, 11, 24, 6, 0, 0);
            timer1.Start();

        }
        private void SponsorForm_Load(object sender, EventArgs e)
        {
            RunnerBox.DropDownStyle = ComboBoxStyle.DropDownList; // запрет на ввод символов комбобокс

            string connection = "Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;";
            MySqlConnection connect = new MySqlConnection(connection);
            MySqlCommand command = new MySqlCommand("SELECT user.FirstName, user.LastName, runner.CountryCode FROM user INNER JOIN runner INNER JOIN registration WHERE " +
                "user.Email = runner.Email AND registration.RunnerId = runner.RunnerId;", connect);
            string runner = "";
            connect.Open();
            MySqlDataReader reader = command.ExecuteReader(); // объявление ридера
            while (reader.Read())
            {
                DataStorage.sFName = reader.GetString(0);
                DataStorage.sLName = reader.GetString(1);
                DataStorage.sCountry = reader.GetString(2);

                runner = DataStorage.sFName + " " + DataStorage.sLName + " " + DataStorage.sCountry;

                RunnerBox.Items.Add(runner); // добавление в комбобокс
            }
            reader.Close();
            connect.Close(); // закрытие соединения;

            DateTime dt = DateTime.Now;
            if (dateCard.Value < dt)
            {
                CardTime = false;
                errorProvider1.SetError(this.dateCard, "Срок карты недействителен.");
            }
            else
            {
                CardTime = true;
                errorProvider1.Clear();
            }

        }

        private void button5_Click(object sender, EventArgs e) // назад
        {
            Form fr1 = new Form1();
            fr1.Show();
            Hide();
        }
        
        private void button3_Click(object sender, EventArgs e) // заплатить
        {
            if (NameBox.Text != String.Empty & RunnerBox.Text != String.Empty &
               NomberCardBox.Text != String.Empty & CardBox.Text != String.Empty & CVCBox.Text != String.Empty)
            {
                if (CardSize == true & CardTime == true)
                {
                    if (donateField.Text != String.Empty)
                    {
                        double a = Convert.ToDouble(donateField.Text);
                        if (a == 0)
                        {
                            MessageBox.Show("Минимальная сумма 10");
                        }
                        else
                        {
                             string connection = "Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;";
                             MySqlConnection connect = new MySqlConnection(connection);
                             MySqlCommand command = new MySqlCommand("SELECT registration.RegistrationId FROM registration INNER JOIN runner INNER JOIN user WHERE " +
                                 "registration.RunnerId = runner.RunnerId AND runner.Email = user.Email AND user.FirstName = '" + DataStorage.rFName + "' and user.LastName = '" + DataStorage.rLName + "'", connect);
                             int regID = 0;

                             connect.Open();
                             MySqlDataReader reader1 = command.ExecuteReader(); // объявление ридера
                             while (reader1.Read())
                             {
                                 regID = reader1.GetInt32(0);
                             }
                             reader1.Close();
                             connect.Close(); // закрытие соединения;

                             MySqlCommand cmd = new MySqlCommand("INSERT INTO `sponsorship`(`SponsorName`, `RegistrationId`, `Amount`) VALUES " +
                                 "( `SponsorName` = '" + NameBox.Text + "',sponsorship.RegistrationId = '" + regID + "',`Amount`= '" + a +"');", connect);
                            connect.Open();
                             if (cmd.ExecuteNonQuery() == 1)
                             {
                                DataStorage.sCost = a;
                                 tyForm frty = new tyForm();
                                 frty.Show();
                                 Hide();
                             }
                             else
                             {
                                 MessageBox.Show("Оплата не прошла.");
                             }
                             connect.Close();




                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы не ввели сумму пожертвования");
                    }
                }
            }
            else
            {
                MessageBox.Show("Все поля обязательны для заполнения");
                return;
            }

        }
        private void buttonPlus_Click(object sender, EventArgs e) // +
        {
            if (donateField.Text != String.Empty)
            {
                double a;
                a = Convert.ToDouble(donateField.Text);
                donateField.Text = Convert.ToString(a + 10);
            }
            else
                donateField.Text = Convert.ToString(10);
        }

        private void buttonMinus_Click(object sender, EventArgs e) // -
        {
            if (donateField.Text != String.Empty)
            {
                double a = Convert.ToDouble(donateField.Text);
                if (a == 0)
                {
                    MessageBox.Show("Минимальная сумма 10");
                }
                else
                {
                    if (a > 10 & a != 10)
                    {
                        a = Convert.ToDouble(donateField.Text);
                        donateField.Text = Convert.ToString(a - 10);
                    }
                }
            }
            else
                MessageBox.Show("Вы не ввели сумму пожертвования");
        }



        private void donateField_KeyPress(object sender, KeyPressEventArgs e) // ввод только цифр в поле с суммой пожертвования
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d = date - DateTime.Now;
            Ltimer.Text = "До начала марафона осталось: " + d.Days + " д. " + d.Hours + " ч. " + d.Minutes + " мин. " + d.Seconds + " с. ";
        }

        private void dateCard_Leave(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            if (dateCard.Value < dt)
            {
                CardTime = false;
                errorProvider1.SetError(this.dateCard, "Срок карты недействителен.");
            }
            else
            {
                CardTime = true;
                errorProvider1.Clear();
            }
        }

        private void RunnerBox_Leave(object sender, EventArgs e)
        {
            string[] words = RunnerBox.Text.Split(' ');
            foreach (string word in words)
            {
                DataStorage.rFName = words[0];
                DataStorage.rLName = words[1];
                DataStorage.rCountry = words[2];
            }
            string connection = "Database=marathonskills;" + "Data Source=127.0.0.1;" + "User Id=root;" + "Password=root;";
            MySqlConnection connect = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand("SELECT charity.CharityName, charity.CharityDescription, charity.CharityLogo FROM charity " +
                    "INNER JOIN registration INNER JOIN runner INNER JOIN user WHERE registration.CharityId = charity.CharityId AND " +
                    "registration.RunnerId = runner.RunnerId AND runner.Email = user.Email AND user.FirstName = '" + DataStorage.rFName + "' and user.LastName = '" + DataStorage.rLName + "';", connect);
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                byte[] img = (byte[])table.Rows[0][2];
                MemoryStream ms = new MemoryStream(img);
                pictureBox1.Image = Image.FromStream(ms);
                da.Dispose();
            }
            catch { }
            connect.Open();
            MySqlDataReader reader1 = cmd.ExecuteReader(); // объявление ридера
            while (reader1.Read())
            {
                DataStorage.cName = reader1.GetString(0);
                DataStorage.cDiscr = reader1.GetString(1);
            }
            reader1.Close();
            connect.Close(); // закрытие соединения;

            errorProvider2.SetError(Charity, DataStorage.cDiscr);
        }

        private void NomberCardBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 44) //цифры, клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void NomberCardBox_Leave(object sender, EventArgs e)
        {
            if (NomberCardBox.MaskCompleted)
            {
                CardSize = true;
                errorProvider1.Clear();
            }
            else
            {
                CardSize = false;
                errorProvider1.SetError(NomberCardBox, "Введеные данные не корректны.");
            }
        }

        private void CVCBox_Leave(object sender, EventArgs e)
        {
            if (CVCBox.MaskCompleted)
            {
                CardSize = true;
                errorProvider1.Clear();
            }
            else
            {
                CardSize = false;
                errorProvider1.SetError(CVCBox, "Введеные данные не корректны.");
            }
        }

        private void CVCBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 44) //цифры, клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            Hide();
        }

        private void SponsorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
