using JLIDashboard.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JLIDashboard
{
    public partial class Form1 : Form
    {
        SoundPlayer ssplayer;
        public Form1()
        {
            InitializeComponent();
            ssplayer = new SoundPlayer("mm001.wav");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string result = Database.getSingleResultSet($"exec dbo.spfunc_017LG9PR '0002','006','00600000014','01','3PM','20210114','123' ");
            ssplayer.PlayLooping();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SoundPlayer splayer = new SoundPlayer("AlertRequest.wav");
            splayer.Play();
            Thread.Sleep(1000);
            ssplayer.PlayLooping();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SoundPlayer splayer = new SoundPlayer("AlertSuccess.wav");
            splayer.Play();
            Thread.Sleep(1000);
            ssplayer.PlayLooping();
        }
    }
}
