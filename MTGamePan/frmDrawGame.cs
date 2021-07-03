using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MTGamePan
{
    public partial class frmDrawGame : Form
    {
        int tmrStartTime = 0;
        int timer = 0;
        int now_idx = 0;
        string[] q_data;

        System.Media.SoundPlayer player;
        public frmDrawGame(int tmrStartTime, string[] q_data)
        {
            InitializeComponent();
            this.tmrStartTime = tmrStartTime;
            this.q_data = q_data;
            player = new System.Media.SoundPlayer(Environment.CurrentDirectory + "/alert.wav");
        }

        private void frmDrawGame_Load(object sender, EventArgs e)
        {
            initView();
        }

        private void initView()
        {
            lblTimer.Left = (this.Width - lblTimer.Width) / 2;
            btnStart.Left = (this.Width - btnStart.Width) / 2;
            lblQuestion.Left = (this.Width - lblQuestion.Width) / 2;
            btnExit.Left = this.Width - btnExit.Width;
            lblTimer.Top = 0;
            btnExit.Top = 0;
            btnStart.Top = this.Height - btnStart.Height;
            lblQuestion.Top = lblTimer.Height + 50;
            lblQuestion.Height = btnStart.Top - lblQuestion.Top - 30;
            lblQuestion.Width = this.Width - 2 * lblQuestion.Left;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "Start!!")
            {
                btnStart.Text = "Next";
            }

            
            if (now_idx < q_data.Length)
            {
                lblQuestion.Text = q_data[now_idx];
                timer = tmrStartTime;
                tmrTimer.Start();
                ++now_idx;
            }
        }

        private void timer_update(object sender, EventArgs e)
        {
            timer -= 15;
            if(timer <= 0)
            {
                timer = 0;
                lblTimer.Text = "00:00";
                tmrTimer.Stop();
                player.Play();
            }
            lblTimer.Text = (timer / 1000).ToString() + ":" + (timer % 1000 / 10).ToString();
        }
    }
}
