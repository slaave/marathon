using marathon.Properties;
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
    public partial class Form1 : Form
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime();
        public Form1()
        {
            InitializeComponent();
            date = new DateTime(2020, 11, 24, 6, 0, 0);
            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e) // ЛОГИН
        {
            LoginForm frlog = new LoginForm();
            frlog.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e) // хочу стать БЕГУНОМ
        {
            RunnerForm frrunner = new RunnerForm();
            frrunner.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e) // хочу стать СПОНСОРОМ
        {
            SponsorForm frspons = new SponsorForm();
            frspons.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e) // хочу УЗНАТЬ БОЛЬШЕ о событии
        {
            InfoForm infoform = new InfoForm();
            infoform.Show();
            Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // timer1.Start();
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d = date - DateTime.Now;
            Ltimer.Text = "До начала марафона осталось: " + d.Days + " д. " + d.Hours + " ч. " + d.Minutes + " мин. " + d.Seconds + " с. ";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
