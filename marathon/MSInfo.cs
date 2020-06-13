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
    public partial class MSInfo : Form
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime();
        public MSInfo()
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

        private void MSInfo_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.map;
            pictureBox2.Image = Properties.Resources.banco_banespa;
            pictureBox3.Image = Properties.Resources.ibirapuera_park_lake;
            pictureBox4.Image = Properties.Resources.marathon_image;
            pictureBox5.Image = Properties.Resources.teatro_municipal;
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            InfoForm iform = new InfoForm();
            iform.Show();
            Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MapMarathon mp = new MapMarathon();
            mp.Show();
            Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void MSInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
