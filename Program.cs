using System;
using System.Windows.Forms;

namespace TestProgram
{ 
    public class frmMain : Form
    {
        const int MAXITERATIONS = 200000;

        private Button btnClose;
        private Label lblAnswer;
        private Label label1;
        private TextBox txtMax;
        private Button btnStart;

        #region Windows code
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
        }
        #endregion Windows code
        public frmMain()
        {
            InitializeComponent();
        }

        public static void Main()
        {
            frmMain main = new frmMain();
            Application.Run(main);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            bool flag;
            int counter;
            int max;
            int last;
            int current;
            Random randomNumber = new Random();

            flag = int.TryParse(txtMax.Text, out max);
            if (flag == false)
            {
                MessageBox.Show("Digit characters only.", "Input Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtMax.Focus();
                return;
            }

            counter = 0;
            last = (int) randomNumber.Next(max);
            do 
            {
                current = randomNumber.Next(max);
                if (last == current)
                {
                    break;
                }
                last = current;
                counter++;
            } while (counter < MAXITERATIONS);
            if (counter < MAXITERATIONS)
            {
                lblAnswer.Text = "It took" + counter.ToString() + "passes to match";
            } else
            {
                lblAnswer.Text = "No back-to-back match";
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}