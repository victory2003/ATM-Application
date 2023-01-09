using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Media;

namespace ATMApplication
{
    public partial class Form1 : Form
    {
        String pinNO;
        double balance = 0;
        double deposit = 0;
        double withdraw;
        double newBalance = 0;

        int enterEventsNo = 0;
        public void pinEvent()
        {
            
            rtDisplay.Clear();

            enterEventsNo = 0;

            if ((txtEnterPin.Text == "1234") || (txtEnterPin.Text == "2345") || (txtEnterPin.Text == "3456") || (txtEnterPin.Text == "4567"))
            {
                pinNO = String.Format(txtEnterPin.Text);

                btnLoan.Enabled = true;
                btnMiniStatement.Enabled = true;
                btnPrintStatement.Enabled = true;
                btnRequestPin.Enabled = true;

                btnDeposit.Enabled = true;
                btnCashWithdrawal.Enabled = true;
                btnCashReceipt.Enabled = true;
                btnBalance.Enabled = true;

                txtEnterPin.Visible = false;

                rtDisplay.AppendText("\t Welcome to SpaceBank\n \n");
                rtDisplay.AppendText("Withdraw Cash" + "\t\t" + "Loan" + "\n\n\n");
                rtDisplay.AppendText("Cash with Receipt" + "\t\t" + "Deposit" + "\n\n\n");
                rtDisplay.AppendText("Request New Pin" + "\t\t" + "Balance" + "\n\n\n");
                rtDisplay.AppendText("Mini Statement" + "\t\t" + "Print Statement");

            }
            else
            {
                txtEnterPin.Text = "Invalid Pin";
            }
        }
        
        public void loanEvent()
        {
            
            if(txtEnterPin.Text != string.Empty)
            {
                rtDisplay.Clear();
                rtDisplay.AppendText("Loan Confirmed");
                txtEnterPin.Visible = true;
                txtEnterPin.Hide();
            }
            else
            {
                rtDisplay.AppendText("Invalid");
            }
        }
        public void depositEvent()
        {

            if (txtEnterPin.Text != string.Empty)
            {
                double depositBal = Convert.ToDouble(txtEnterPin.Text);
                balance += depositBal;
                rtDisplay.Clear();
                rtDisplay.AppendText("Deposit Confirmed. \n");
                txtEnterPin.Visible = true;
                txtEnterPin.Hide();
            }
            else
            {
                rtDisplay.AppendText("Invalid");
            }
        }
        public void withdrawEvent()
        {
            if (txtEnterPin.Text != string.Empty)
            {
                double withdraw = Convert.ToDouble(txtEnterPin.Text);
                if (withdraw > balance)
                {
                    rtDisplay.AppendText("Insuffient Funds");
                }
                else
                {
                    double withdrawBal = Convert.ToDouble(txtEnterPin.Text);
                    rtDisplay.Clear();
                    rtDisplay.AppendText("Wihdrawal Confirmed. \n");
                    txtEnterPin.Visible = true;
                    txtEnterPin.Hide();
                    balance -= withdraw;
                }
               
            }
            else
            {
                rtDisplay.AppendText("Invalid");
            }
            
        }
        public void requestPinEvent()
        {

            if (txtEnterPin.Text != string.Empty)
            {
               
                rtDisplay.Clear();
                rtDisplay.AppendText("your new pin will be sent to your home address. \n");
                txtEnterPin.Visible = true;
                txtEnterPin.Hide();
            }
            else
            {
                rtDisplay.AppendText("Invalid");
            }
        }


        
        public Form1()
        {
            
            InitializeComponent();
            
            rtDisplay.AppendText("Enter PIN");
        }
        public void Withdraw()
        {
            enterEventsNo = 3;
            SoundPlayer withdraws = new SoundPlayer(@"C:\Users\User\Documents\DISM\C#\ATMApplication\bin\Debug\net6.0-windows\withdraw.wav");
            withdraws.Play();

            rtDisplay.Clear();
            rtDisplay.AppendText("Enter amount to Withdraw: \n\n\n");
            txtEnterPin.Visible = true;
            txtEnterPin.Clear();
            txtEnterPin.Focus();   
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Withdraw();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SoundPlayer cashreceipt = new SoundPlayer(@"C:\Users\User\Documents\DISM\C#\ATMApplication\bin\Debug\net6.0-windows\cash.wav");
            cashreceipt.Play();

            rtDisplay.Clear();
            txtEnterPin.Visible = false;
            Statement();
            printPreviewDialog1.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EnableButton();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            enterEventsNo = 4;

            SoundPlayer request = new SoundPlayer(@"C:\Users\User\Documents\DISM\C#\ATMApplication\bin\Debug\net6.0-windows\request.wav");
            request.Play();

            rtDisplay.Clear();
            rtDisplay.AppendText("Enter new Pin: \n \n");
            txtEnterPin.Visible = true;
            txtEnterPin.Clear();
            txtEnterPin.Focus();   
        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            txtEnterPin.Text = txtEnterPin.Text + "9";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            txtEnterPin.Text = txtEnterPin.Text + "6";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult iExit;

            iExit = MessageBox.Show("Confirm you want to exit", "ATM System", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void EnableButton()
        {
            btnLoan.Enabled = false;
            btnMiniStatement.Enabled = false;
            btnPrintStatement.Enabled = false;
            btnRequestPin.Enabled = false;

            btnDeposit.Enabled = false;
            btnCashWithdrawal.Enabled = false;
            btnCashReceipt.Enabled = false;
            btnBalance.Enabled = false;

            rtDisplay.Clear();
            txtEnterPin.Text = "";
            txtEnterPin.Visible = true;
            txtEnterPin.Focus();
        }
        private void Balance()
        {
            SoundPlayer balla = new SoundPlayer(@"C:\Users\User\Documents\DISM\C#\ATMApplication\bin\Debug\net6.0-windows\balance.wav");
            balla.Play();
            rtDisplay.Clear();
            rtDisplay.AppendText("Your new balance is: " + balance + "\n\n");
        }

        private void Statement()
        {
            rtDisplay.Clear();
                rtDisplay.AppendText("Balance is: " + "\t\t\t" + balance + "\n\n");
                rtDisplay.AppendText("Tax is: " + "\t\t\t\t" + "#200" + "\n\n");
                rtDisplay.AppendText("Telephone is: " + "\t\t\t" + "#30" + "\n\n");
                rtDisplay.AppendText("Rent is: " + "\t\t\t" + "#12" + "\n\n");
                rtDisplay.AppendText("Tesco is: " + "\t\t\t" + "#749");
           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
         EnableButton();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtEnterPin.Text = txtEnterPin.Text + "1";

        }


        private void btn2_Click(object sender, EventArgs e)
        {
            txtEnterPin.Text = txtEnterPin.Text + "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtEnterPin.Text = txtEnterPin.Text + "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtEnterPin.Text = txtEnterPin.Text + "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtEnterPin.Text = txtEnterPin.Text + "5";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtEnterPin.Text = txtEnterPin.Text + "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtEnterPin.Text = txtEnterPin.Text + "8";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtEnterPin.Text = txtEnterPin.Text + "0";
        }
   

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if(enterEventsNo == 0)//pin
            {
                pinEvent();
                SoundPlayer bb = new SoundPlayer(@"C:\Users\User\Documents\DISM\C#\ATMApplication\bin\Debug\net6.0-windows\sound.wav");
                bb.Play();
                //bb.Stop();
            }
            else if(enterEventsNo == 1)//loan
            {
                loanEvent();
            }
            else if(enterEventsNo == 2)//deposit
            {
                depositEvent();
            }else if(enterEventsNo == 3)//withdraw
            {
                withdrawEvent();
            }else if(enterEventsNo == 4)//requestpin
            {
                requestPinEvent();
            }
        }

        public void Loan()
        {
            enterEventsNo = 1;

            

            rtDisplay.Clear();
            rtDisplay.AppendText("Enter amount to loan: \n\n\n");
            txtEnterPin.Visible = true;
            txtEnterPin.Clear();
            txtEnterPin.Focus();
        }
        private void btnLoan_Click(object sender, EventArgs e)
        {
            Loan();
          
        }
        public void Deposit()
        {
            SoundPlayer depos = new SoundPlayer(@"C:\Users\User\Documents\DISM\C#\ATMApplication\bin\Debug\net6.0-windows\deposit.wav");
            depos.Play();

            enterEventsNo = 2;

            rtDisplay.Clear();
            rtDisplay.AppendText("Enter amount to deposit: \n\n\n");
            txtEnterPin.Visible = true;
            txtEnterPin.Clear();
            txtEnterPin.Focus();
        }
        private void btnDeposit_Click(object sender, EventArgs e)
        {
            Deposit();
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            txtEnterPin.Visible = false;
            Balance();
        }

        private void btnPrintStatement_Click(object sender, EventArgs e)
        {

            rtDisplay.Clear();
            txtEnterPin.Visible = false;
            Statement();
            printPreviewDialog1.ShowDialog();
        }

        private void btnMiniStatement_Click(object sender, EventArgs e)
        {
            SoundPlayer mini = new SoundPlayer(@"C:\Users\User\Documents\DISM\C#\ATMApplication\bin\Debug\net6.0-windows\mini.wav");
            mini.Play();
            rtDisplay.Clear();
            txtEnterPin.Visible = false;
            Statement();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            FontFamily myFontFamily = new FontFamily("Arial");
            Font myFont = new Font(
            myFontFamily,
            20,
            FontStyle.Bold,
            GraphicsUnit.Pixel);

            e.Graphics.DrawString(rtDisplay.Text, myFont, Brushes.Black, 100, 100);
        }

        private void rtDisplay_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtEnterPin_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            rtDisplay.Clear();
            txtEnterPin.Visible = true;    
            rtDisplay.Text = "Enter Your Pin";
            enterEventsNo = 0;
        }
    }
}