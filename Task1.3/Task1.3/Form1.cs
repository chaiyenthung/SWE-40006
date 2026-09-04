using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1._3
{
    public partial class Calculator : Form
    {
        private double firstValue = 0;
        private string operationSelected = "";
        private bool isOperationPerformed = false;

        public Calculator()
        {
            InitializeComponent();
            this.Text = "Standard Calculator (Multi-DLL)";

            // 1. Programmatically wire up all digit buttons (0-9) to the digit handler
            btn0.Click += btnDigit_Click;
            btn1.Click += btnDigit_Click;
            btn2.Click += btnDigit_Click;
            btn3.Click += btnDigit_Click;
            btn4.Click += btnDigit_Click;
            btn5.Click += btnDigit_Click;
            btn6.Click += btnDigit_Click;
            btn7.Click += btnDigit_Click;
            btn8.Click += btnDigit_Click;
            btn9.Click += btnDigit_Click;

            // 2. Programmatically wire up all operators (+, -, x, ÷) to the operator handler
            btnAdd.Click += btnOperator_Click;
            btnSubtract.Click += btnOperator_Click;
            btnMultiply.Click += btnOperator_Click;
            btnDivide.Click += btnOperator_Click;

            // 3. Programmatically wire up system control buttons
            btnClear.Click += btnClear_Click;
            btnEquals.Click += btnEquals_Click;
        }

        // --- HANDLER 1: Digit Inputs (0-9) ---
        private void btnDigit_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            // Clear display if starting a new input or if display is currently "0"
            if (txtDisplay.Text == "0" || isOperationPerformed)
            {
                txtDisplay.Clear();
            }

            isOperationPerformed = false;
            txtDisplay.Text += button.Text;
        }

        // --- HANDLER 2: Operators (+, -, x, ÷) ---
        private void btnOperator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (double.TryParse(txtDisplay.Text, out double val))
            {
                firstValue = val;
                operationSelected = button.Text;
                isOperationPerformed = true;
            }
        }

        // --- HANDLER 3: Clear Screen (C) ---
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            firstValue = 0;
            operationSelected = "";
            isOperationPerformed = false;
            lblHistory.Text = "Last Calculation: None";
        }

        // --- HANDLER 4: Equals (=) calling both external DLLs ---
        private void btnEquals_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtDisplay.Text, out double secondValue))
            {
                try
                {
                    // Map the UI characters "x" and "÷" to the standard math operators "*" and "/"
                    string opToUse = operationSelected;
                    if (opToUse == "x") opToUse = "*";
                    if (opToUse == "÷") opToUse = "/";

                    // Step A: Perform core math operations using MyMathLibrary.dll
                    double result = MathEngine.Calculate(firstValue, secondValue, opToUse);

                    // Show raw calculated result on display
                    txtDisplay.Text = result.ToString();
                    isOperationPerformed = true;

                    // Step B: Formulate log and timestamp history label using MyFormattingLibrary.dll
                    string formattedHistory = Formatter.LogCalculation(firstValue, secondValue, operationSelected, result);
                    lblHistory.Text = formattedHistory;
                }
                catch (DivideByZeroException)
                {
                    MessageBox.Show("Cannot divide by zero.", "Math Error");
                    txtDisplay.Text = "0";
                }
                catch (Exception)
                {
                    MessageBox.Show("An error occurred during calculation.", "Error");
                }
            }
        }

        // Standard event handlers required by your designer configurations
        private void Calculator_Load(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}
