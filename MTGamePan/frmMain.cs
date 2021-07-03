using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTGamePan
{
    public partial class frmMain : Form
    {
        int redPoint, bluePoint;
        frmEvent fe = new frmEvent();
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            initUI();
        }

        private void initUI()
        {
            initBluePointUI();

            initRedPointUI();
        }

        private void initBluePointUI()
        {
            lblBluePoint.Left = this.Width / 2 + 10;
            lblBluePoint.Top = this.Height / 4;
            lblBluePoint.Width = this.Width / 4;
            lblBluePoint.Height = this.Height / 2;

            initBlueButtons();
        }

        private void initRedPointUI()
        {
            lblRedPoint.Width = this.Width / 4;
            lblRedPoint.Height = this.Height / 2;
            lblRedPoint.Left = this.Width / 2 - lblRedPoint.Width - 10;
            lblRedPoint.Top = this.Height / 4;

            initRedButtons();
        }

        private void initBlueButtons()
        {
            btnBlueAdd1.Left = lblBluePoint.Left + lblBluePoint.Width + 10;
            btnBlueAdd2.Left = lblBluePoint.Left + lblBluePoint.Width + 10;
            btnBlueAdd3.Left = lblBluePoint.Left + lblBluePoint.Width + 10;
            btnBlueAddCtm.Left = lblBluePoint.Left + lblBluePoint.Width + 10;
            btnBlueAdd1.Top = lblBluePoint.Top;
            btnBlueAdd2.Top = btnBlueAdd1.Top + btnBlueAdd1.Height + 10;
            btnBlueAdd3.Top = btnBlueAdd2.Top + btnBlueAdd2.Height + 10;
            btnBlueAddCtm.Top = lblBluePoint.Top + lblBluePoint.Height - btnBlueAddCtm.Height;
            txtBlueCustomP.Left = btnBlueAddCtm.Left + (btnBlueAddCtm.Width - txtBlueCustomP.Width) / 2;
            txtBlueCustomP.Top = btnBlueAddCtm.Top + (btnBlueAddCtm.Height - txtBlueCustomP.Height) / 2;
        }
        private void initRedButtons()
        {
            btnRedAdd1.Left = lblRedPoint.Left - btnRedAdd1.Width - 10;
            btnRedAdd2.Left = lblRedPoint.Left - btnRedAdd1.Width - 10;
            btnRedAdd3.Left = lblRedPoint.Left - btnRedAdd1.Width - 10;
            btnRedAddCtm.Left = lblRedPoint.Left - btnRedAdd1.Width - 10;
            btnRedAdd1.Top = lblRedPoint.Top;
            btnRedAdd2.Top = btnRedAdd1.Top + btnRedAdd1.Height + 10;
            btnRedAdd3.Top = btnRedAdd2.Top + btnRedAdd2.Height + 10;
            btnRedAddCtm.Top = lblRedPoint.Top + lblRedPoint.Height - btnRedAddCtm.Height;
            txtRedCustomP.Left = btnRedAddCtm.Left + (btnRedAddCtm.Width - txtRedCustomP.Width) / 2;
            txtRedCustomP.Top = btnRedAddCtm.Top + (btnRedAddCtm.Height - txtRedCustomP.Height) / 2;
        }

        private void btnRedAdd1_Click(object sender, EventArgs e)
        {
            redPoint += 1;
            update();
        }

        private void btnRedAdd2_Click(object sender, EventArgs e)
        {
            redPoint += 5;
            update();
        }

        private void btnRedAdd3_Click(object sender, EventArgs e)
        {
            redPoint += 10;
            update();
        }

        private void btnRedAddCtm_Click(object sender, EventArgs e)
        {
            string txtPoint = txtRedCustomP.Text;
            int point = 0;
            if (txtPoint.StartsWith("-"))
                point = -1 * Int32.Parse(txtPoint.Substring(1));
            else if (txtPoint.StartsWith("+"))
                point = Int32.Parse(txtPoint.Substring(1));
            else
                point = Int32.Parse(txtPoint);

            redPoint += point;
            update();
        }

        private void btnBlueAdd1_Click(object sender, EventArgs e)
        {
            bluePoint += 1;
            update();
        }

        private void btnBlueAdd2_Click(object sender, EventArgs e)
        {
            bluePoint += 5;
            update();
        }

        private void btnBlueAdd3_Click(object sender, EventArgs e)
        {
            bluePoint += 10;
            update();

        }

        private void btnBlueAddCtm_Click(object sender, EventArgs e)
        {
            string txtPoint = txtBlueCustomP.Text;
            int point = 0;
            if (txtPoint.StartsWith("-"))
                point = -1 * Int32.Parse(txtPoint.Substring(1));
            else if (txtPoint.StartsWith("+"))
                point = Int32.Parse(txtPoint.Substring(1));
            else
                point = Int32.Parse(txtPoint);

            bluePoint += point;
            update();
        }

        private void btnMvDrawGame_Click(object sender, EventArgs e)
        {
            string[] q_data = new string[] {
                "1",
                "2",
                "3"
            };
            frmDrawGame fdg = new frmDrawGame(30000, q_data);
            fdg.Show();
        }

        private void btnEvent_Click(object sender, EventArgs e)
        {
            fe.Show();
        }

        private void update()
        {
            lblRedPoint.Text = redPoint.ToString();
            lblBluePoint.Text = bluePoint.ToString();
        }
    }
}
