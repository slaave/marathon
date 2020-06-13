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
    public partial class InfoForm : Form
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime();
        public InfoForm()
        {
            InitializeComponent();
            date = new DateTime(2020, 11, 24, 6, 0, 0);
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)// марафон скилс
        {
            MSInfo msi = new MSInfo();
            msi.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e) // предыдущие результаты
        {

        }

        private void button3_Click(object sender, EventArgs e)// БМИ
        {

        }

        private void button4_Click(object sender, EventArgs e) // на сколько долгий марафон
        {
            HowLong HL = new HowLong();
            HL.Show();
            Hide();
        }

        private void button6_Click(object sender, EventArgs e) // список благотв. орг.
        {
            OrgList orglist = new OrgList();
            orglist.Show();
            Hide();
        }

        private void button7_Click(object sender, EventArgs e) //БМР
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form fr1 = new Form1();
            fr1.Show();
            Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d = date - DateTime.Now;
            Ltimer.Text = "До начала марафона осталось: " + d.Days + " д. " + d.Hours + " ч. " + d.Minutes + " мин. " + d.Seconds + " с. ";
        }

        private void InfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
