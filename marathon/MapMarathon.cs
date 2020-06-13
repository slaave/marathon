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
    public partial class MapMarathon : Form
    {
        public MapMarathon()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Nomber.Text = "В секторе 1 расположен:";
            Name.Text = "ДОМ ПРАВИТЕЛЬСТВА";
            pictureBox2.Image = Properties.Resources.DOM_PRAV;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Nomber.Text = "В секторе 2 расположен:";
            Name.Text = "МОСКВА-СИТИ";
            pictureBox2.Image = Properties.Resources.MSC_CITY;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Nomber.Text = "В секторе 3 расположен:";
            Name.Text = "МИНИСТЕРСТВО ИНОСТРАННЫЙХ ДЕЛ";
            pictureBox2.Image = Properties.Resources.MINISTERSTVO;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Nomber.Text = "В секторе 4 расположен:";
            Name.Text = "СТЕНД С НАПИТКАМИ";
            pictureBox2.Image = Properties.Resources.stend;
        }

        private void buton5_Click(object sender, EventArgs e)
        {
            Nomber.Text = "В секторе 5 расположен:";
            Name.Text = "НИКОЛЬСКАЯ ЦЕРКОВЬ";
            pictureBox2.Image = Properties.Resources.cerkov;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Nomber.Text = "В секторе 6 расположен:";
            Name.Text = "СОБОРНАЯ МЕЧЕТЬ";
            pictureBox2.Image = Properties.Resources.mechet;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Nomber.Text = "В секторе 7 расположен:";
            Name.Text = "БОЛЬШОЙ ТЕАТР";
            pictureBox2.Image = Properties.Resources.teatr;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Nomber.Text = "В секторе 8 расположен:";
            Name.Text = "МОСКОВСКИЙ КРЕМЛЬ";
            pictureBox2.Image = Properties.Resources.kreml;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MSInfo msi = new MSInfo();
            msi.Show();
            Hide();
        }

        private void MapMarathon_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
