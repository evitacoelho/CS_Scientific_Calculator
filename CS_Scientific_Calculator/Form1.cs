using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_Scientific_Calculator
{
    public partial class formCalculator : Form
    {
        double firstOperand, secondOperand;
        String op;
        double result;
        public formCalculator()
        {
            InitializeComponent();
        }
                   
        private void OperatorClick(object sender, EventArgs e)
        {
            Button oper = (Button)sender;
            if(txtResult.Text != "")
            {
                //on operator button click, save the display text as first operand
                firstOperand = Convert.ToDouble(txtResult.Text);

                //save the operator
                op = oper.Text;

                //reset the display
                txtResult.Text = "";
            }
        }
        private void EqualsClick(object sender, EventArgs e)
        {        
            String first = Convert.ToString(firstOperand);

            // ensure both operands are not empty
            if (txtResult.Text != "" && first != "") 
            {
                secondOperand = Convert.ToDouble(txtResult.Text);

                // for all arithmetic operations
                switch (op) 
                {
                    case "+":
                        txtResult.Text = (firstOperand + secondOperand).ToString();
                    break;
                    case "-":
                        txtResult.Text = (firstOperand - secondOperand).ToString();
                        break;
                    case "*":
                        txtResult.Text = (firstOperand * secondOperand).ToString();
                        break;
                    case "/":
                        if (secondOperand != 0)
                            txtResult.Text = (firstOperand / secondOperand).ToString();
                        break;
                    case "=":
                        txtResult.Text = "";
                        break;
                    case "Mod":
                        txtResult.Text = (firstOperand % secondOperand).ToString();
                        break;
                    case "Exp":
                        double i =Convert.ToDouble(txtResult.Text);
                        double j = secondOperand;
                        txtResult.Text = Math.Exp(i * Math.Log(j * 4)).ToString();
                        break;
                    default:
                        break;
                }
            }       
        }
        private void ClearClick(object sender, EventArgs e)
        {
            txtResult.Text = "";  //clears all history
        }
        private void ClearEntryClick(object sender, EventArgs e)
        {
            txtResult.Text = "";
            String first, second;
            first = Convert.ToString(firstOperand); 
            second = Convert.ToString(secondOperand);

            //reset the most recent operands
            first = "";
            second = "";
        }
        private void BackspaceClick(object sender, EventArgs e)
        {
            if (txtResult.Text.Length > 0)
            {
                //deletes the last input character
                txtResult.Text = txtResult.Text.Remove(txtResult.Text.Length - 1, 1); 
            }
            else
                // displays 0 if there is user tries to delete an empty input string
                txtResult.Text = "0";  
        }
        private void PlusMinusClick(object sender, EventArgs e)
        {
            double result = Convert.ToDouble(txtResult.Text);

            //toggles the sign bit of the input
            txtResult.Text = Convert.ToString(-1 * result); 
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }
        private void stdCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 280;

        }
        private void formCalculator_Load(object sender, EventArgs e)
        {
            this.Width = 280;
            txtResult.Width = 240 ;
        }
        private void scientificCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 550;
            txtResult.Width = 502;
        }
        private void extToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //property indicating the return value of a dialog box
            DialogResult exitCalculator;

            //Mesage box with options (Y/N) options - waits for user action
            exitCalculator = MessageBox.Show("Confirm if you want to exit", "Scientific Calculator",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //return value of the DialogResult property is 'yes'
            if (exitCalculator == DialogResult.Yes)  
                Application.Exit();   //method to shut down the application
        }
        private void btnPi_Click(object sender, EventArgs e)
        {
            txtResult.Text = "3.141592653589793238462643";
        }
        private void btnLog_Click(object sender, EventArgs e)
        {
            try
            {
                double logarithm = Convert.ToDouble(txtResult.Text);

                // calcuated log base 10 of input
                logarithm = Math.Log10(logarithm);   
                txtResult.Text = logarithm.ToString();
            }
            catch {

                //display a warning message box for invalid input and wait for user action
                DialogResult logButton;
                logButton = MessageBox.Show("Invalid format: Enter (number)Log ", "Log Button", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnSqrt_Click(object sender, EventArgs e)
        {
            try
            {
                double sqrt = Convert.ToDouble(txtResult.Text);

                //computes square root
                sqrt = Math.Sqrt(sqrt);    
                txtResult.Text = sqrt.ToString();
            }
            catch
            {
                //display a warning message box for invalid input and wait for user action
                DialogResult logButton;
                logButton = MessageBox.Show("Invalid format: Enter (number)Sqrt ", "Log Button",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnX2_Click(object sender, EventArgs e)
        {
            try
            {
                double input = Convert.ToDouble(txtResult.Text);

                //computer power raised to 2
                double exponetial = input * input;    
                txtResult.Text = exponetial.ToString();
            }
            catch
            {
                //display a warning message box for invalid input and wait for user action
                DialogResult logButton;
                logButton = MessageBox.Show("Invalid format: Enter (number) X2 ", "Log Button",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnX3_Click(object sender, EventArgs e)
        {
            try
            {
                double input = Convert.ToDouble(txtResult.Text);

                //computes power raised to 3
                double exponetial = input * input * input;   
                txtResult.Text = exponetial.ToString();
            }
            catch
            {
                //display a warning message box for invalid input and wait for user action
                DialogResult logButton;
                logButton = MessageBox.Show("Invalid format: Enter (number) X3 ", "Log Button",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnSinh_Click(object sender, EventArgs e)
        {
            try
            {
                double sinh = Convert.ToDouble(txtResult.Text);
                
                //compute sinh
                sinh = Math.Sinh(sinh);
                txtResult.Text = sinh.ToString();
            }
            catch
            {
                //display a warning message box for invalid input and wait for user action
                DialogResult logButton;
                logButton = MessageBox.Show("Invalid format: Enter (number)Sinh ", "Log Button",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnSin_Click(object sender, EventArgs e)
        {
            try
            {
                double sin = Convert.ToDouble(txtResult.Text);
                //compute sine
                sin = Math.Sin(sin);
                txtResult.Text = sin.ToString();
            }
            catch
            {
                //display a warning message box for invalid input and wait for user action
                DialogResult logButton;
                logButton = MessageBox.Show("Invalid format: Enter (number)Sin ", "Log Button",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnCosh_Click(object sender, EventArgs e)
        {
            try
            {
                double cosh = Convert.ToDouble(txtResult.Text);
                
                //compute cosh
                cosh = Math.Cosh(cosh);
                txtResult.Text = cosh.ToString();
            }
            catch
            {
                //display a warning message box for invalid input and wait for user action
                DialogResult logButton;
                logButton = MessageBox.Show("Invalid format: Enter (number)Cosh ", "Log Button",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnCos_Click(object sender, EventArgs e)
        {
            try
            {
                //compute cosine
                double cos = Convert.ToDouble(txtResult.Text);
                cos = Math.Cos(cos);
                txtResult.Text = cos.ToString();
            }
            catch
            {
                //display a warning message box for invalid input and wait for user action
                DialogResult logButton;
                logButton = MessageBox.Show("Invalid format: Enter (number)Cos ", "Log Button",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnTanh_Click(object sender, EventArgs e)
        {
            try
            {
                //compute tangent
                double tanh = Convert.ToDouble(txtResult.Text);
                tanh = Math.Tanh(tanh);
                txtResult.Text = tanh.ToString();
            }
            catch
            {
                //display a warning message box for invalid input and wait for user action
                DialogResult logButton;
                logButton = MessageBox.Show("Invalid format: Enter (number)Tanh ", "Log Button",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnTan_Click(object sender, EventArgs e)
        {
            try
            {
                //compute tangent
                double tan = Convert.ToDouble(txtResult.Text);
                tan = Math.Tan(tan);
                txtResult.Text = tan.ToString();
            }
            catch
            {
                //display a warning message box for invalid input and wait for user action
                DialogResult logButton;
                logButton = MessageBox.Show("Invalid format: Enter (number)Cos ", "Log Button",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btn1x_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(txtResult.Text);
                
                //type casting to compatible form
                x = Convert.ToDouble(1.0 / x);
                txtResult.Text = x.ToString();
            }
            catch
            {
                //display a warning message box for invalid input and wait for user action
                DialogResult logButton;
                logButton = MessageBox.Show("Invalid format: Enter (number)1/x ", "Log Button",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnPercentage_Click(object sender, EventArgs e)
        {
            try
            {
                double input = Convert.ToDouble(txtResult.Text);

                //type cast to compatible format
                double percentage = input/ Convert.ToDouble(100.0) ;
                txtResult.Text = percentage.ToString();
            }
            catch
            {
                //display a warning message box for invalid input and wait for user action
                DialogResult logButton;
                logButton = MessageBox.Show("Invalid format: Enter (number)% ", "Log Button",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnLnx_Click(object sender, EventArgs e)
        {
            try
            {
                //compute log
                double lnx = Convert.ToDouble(txtResult.Text);
                lnx = Math.Log(lnx);
                txtResult.Text = lnx.ToString();
            }
            catch
            {
                //display a warning message box for invalid input and wait for user action
                DialogResult logButton;
                logButton = MessageBox.Show("Invalid format: Enter (number)Lnx ", "Log Button",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnDec_Click(object sender, EventArgs e)
        {
            double dec = Convert.ToDouble(txtResult.Text);

            //convert decimal to its integer equivalent
            int decToInt = Convert.ToInt32(dec);
            txtResult.Text = decToInt.ToString();
        }
        private void btnBin_Click(object sender, EventArgs e)
        {
            try
            {
                //parse the input to integer
                int binary = int.Parse(txtResult.Text);

                //convert integer to binary equivalent
                txtResult.Text = Convert.ToString(binary, 2);
            }
            catch
            {
                //display a warning message box for invalid input and wait for user action
                DialogResult binButton;
                binButton = MessageBox.Show("Invalid input: Enter integer ", "Log Button",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private void btnHex_Click(object sender, EventArgs e)
        {
            try
            {
                //compute hex equivalent
                int hex = int.Parse(txtResult.Text);
                txtResult.Text = Convert.ToString(hex, 16);
            }
            catch
            {
                //display a warning message box for invalid input and wait for user action
                DialogResult hexButton;
                hexButton = MessageBox.Show("Invalid input: Enter integer ", "Log Button",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private void btnOct_Click(object sender, EventArgs e)
        {
            try
            {
                //compute oct equivalent
                int oct = int.Parse(txtResult.Text);
                txtResult.Text = Convert.ToString(oct, 8);
            }
            catch
            {
                //display a warning message box for invalid input and wait for user action
                DialogResult octButton;
                octButton = MessageBox.Show("Invalid input: Enter integer ", "Log Button",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void txtResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == '.'); 
               // allow only digits and . from keyboard input
        }

        private void NumberClick(object sender, EventArgs e)
        {
            //object that generates an event on click
            Button number = (Button)sender; 
            
            if (txtResult.Text == "0")
                txtResult.Text = "";    //reset to an empty display

            if (number.Text == ".")     //if "." is clicked
            {
                if (!txtResult.Text.Contains("."))      //Ensure there is a single "." in the input
                    txtResult.Text = txtResult.Text + number.Text;
            }
            else
            {
                txtResult.Text = txtResult.Text + number.Text;  //append numbers to the operand
            }
        }
    }
}
