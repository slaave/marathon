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
    public partial class RunnerForm : Form
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime();
        public RunnerForm()
        {
            InitializeComponent();
            date = new DateTime(2020, 11, 24, 6, 0, 0);
            timer1.Start();
        }

        private void RunnerForm_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e) // назад
        {
            Form fr1 = new Form1();
            fr1.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e) // я учавтвовал ранее
        {
            LoginForm frlog = new LoginForm();
            frlog.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)// я новый участник
        {
            RegRunnerForm frregrunner = new RegRunnerForm();
            frregrunner.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)// LOGIN
        {
            LoginForm frlog = new LoginForm();
            frlog.Show();
            Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d = date - DateTime.Now;
            Ltimer.Text = "До начала марафона осталось: " + d.Days + " д. " + d.Hours + " ч. " + d.Minutes + " мин. " + d.Seconds + " с. ";
        }

        private void RunnerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
