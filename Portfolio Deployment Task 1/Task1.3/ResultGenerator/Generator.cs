using System;
using System.IO;
using System.Text;

namespace ResultGenerator
{
    public class Generator
    {
        public static string GenerateDetailedReport(string[] names, double[] grades, double[] weights, double finalScore, string finalGrade)
        {
            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=======================================");
            sb.AppendLine("             RESULT REPORT             ");
            sb.AppendLine("=======================================");
            sb.AppendLine($"Generated on: {timeStamp}");
            sb.AppendLine("---------------------------------------");
            sb.AppendLine(string.Format("{0,-15} | {1,-10} | {2,-10}", "Assignment", "Grade (%)", "Weight (%)"));
            sb.AppendLine("---------------------------------------");

            for (int i = 0; i < names.Length; i++)
            {
                if (!string.IsNullOrEmpty(names[i]))
                {
                    sb.AppendLine(string.Format("{0,-15} | {1,-10}% | {2,-10}%", names[i], grades[i], weights[i]));
                }
            }

            sb.AppendLine("---------------------------------------");
            sb.AppendLine($"Final Weighted Score: {Math.Round(finalScore, 2)}%");
            sb.AppendLine($"Grade Achieved: {finalGrade}");
            sb.AppendLine("=======================================");

            string report = sb.ToString();

            try
            {
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                // Saves the report under a generic report name on disk
                string fileName = Path.Combine(documentsPath, "Weighted_Grade_Report.txt");
                File.WriteAllText(fileName, report);
            }
            catch (Exception) { }

            return report;
        }
    }
}
