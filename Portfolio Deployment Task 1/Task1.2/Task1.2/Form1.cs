using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string userInput = txtInput.Text;

            if (double.TryParse(userInput, out double number))
            {
                double result = number * number;

                lblResult.Text = $"Result: {result}";
            }
            else
            {
                MessageBox.Show("Please enter a valid number.", "Invalid Input");
            }
        }
    }
}
