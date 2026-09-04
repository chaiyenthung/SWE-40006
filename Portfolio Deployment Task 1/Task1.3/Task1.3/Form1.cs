using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarkingRules;
using ResultGenerator;


namespace Task1._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Grade Calculator";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Group  5 rows of TextBoxes into arrays 
            TextBox[] asgNames = { txtInput1, txtInput2, txtInput3, txtInput4, txtInput5 };
            TextBox[] asgGrades = { txtGrade1, txtGrade2, txtGrade3, txtGrade4, txtGrade5 };
            TextBox[] asgWeights = { txtWeight1, txtWeight2, txtWeight3, txtWeight4, txtWeight5 };

            List<string> activeNames = new List<string>();
            List<double> activeGrades = new List<double>();
            List<double> activeWeights = new List<double>();

            // Loop through all 5 rows
            for (int i = 0; i < 5; i++)
            {
                string name = asgNames[i].Text.Trim();
                string gradeText = asgGrades[i].Text.Trim();
                string weightText = asgWeights[i].Text.Trim();

                if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(gradeText) && string.IsNullOrEmpty(weightText))
                {
                    continue;
                }

                double grade = 0;
                double weight = 0;

                if (!string.IsNullOrEmpty(gradeText) && !double.TryParse(gradeText, out grade))
                {
                    MessageBox.Show($"Please enter a valid numeric grade in row {i + 1}.\n(Found invalid value: '{gradeText}')", "Input Error");
                    return;
                }

                if (!string.IsNullOrEmpty(weightText) && !double.TryParse(weightText, out weight))
                {
                    MessageBox.Show($"Please enter a valid numeric weight in row {i + 1}.\n(Found invalid value: '{weightText}')", "Input Error");
                    return;
                }

                // Value boundaries validation
                if (grade < 0 || grade > 100 || weight < 0)
                {
                    MessageBox.Show($"Grade in row {i + 1} must be between 0-100%, and weight cannot be negative.", "Input Error");
                    return;
                }

                activeNames.Add(string.IsNullOrEmpty(name) ? $"Task {i + 1}" : name);
                activeGrades.Add(grade);
                activeWeights.Add(weight);
            }

            // Ensure at least one active row has been filled out
            if (activeWeights.Count == 0)
            {
                MessageBox.Show("Please fill out at least one row with a valid grade and weight.", "Input Error");
                return;
            }

            string[] finalNames = activeNames.ToArray();
            double[] finalGrades = activeGrades.ToArray();
            double[] finalWeights = activeWeights.ToArray();

            // Calculate the weighted average using MarkingRules.dll
            double finalScore = Evaluator.CalculateWeightedAverage(finalGrades, finalWeights);
            string finalGrade = Evaluator.GetGradeBand(finalScore);

            // Generate the formatted transcript report using Result-Generator.dll
            string detailedReport = Generator.GenerateDetailedReport(finalNames, finalGrades, finalWeights, finalScore, finalGrade);

            //Display in a clean pop-up window (MessageBox)
            MessageBox.Show(detailedReport, "Grade Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Gather all textboxes in the grid
            TextBox[] allTextBoxes = {
                txtInput1, txtInput2, txtInput3, txtInput4, txtInput5,
                txtGrade1, txtGrade2, txtGrade3, txtGrade4, txtGrade5,
                txtWeight1, txtWeight2, txtWeight3, txtWeight4, txtWeight5
            };

            // Loop and clear the text inside every box
            foreach (TextBox tb in allTextBoxes)
            {
                tb.Clear();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

      
    }
}
