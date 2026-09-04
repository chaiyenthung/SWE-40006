namespace Task1._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click_1(object sender, EventArgs e)
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
