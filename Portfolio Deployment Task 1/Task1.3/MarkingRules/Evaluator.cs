namespace MarkingRules
{
    public class Evaluator
    {
        public static double CalculateWeightedAverage(double[] grades, double[] weights)
        {
            double weightedSum = 0;
            double totalWeight = 0;

            for (int i = 0; i < grades.Length; i++)
            {
                weightedSum += grades[i] * weights[i];
                totalWeight += weights[i];
            }

            if (totalWeight == 0) return 0;

            return weightedSum / totalWeight;
        }

        public static string GetGradeBand(double score)
        {
            if (score >= 80) return "High Distinction (HD)";
            if (score >= 70) return "Distinction (D)";
            if (score >= 60) return "Credit (C)";
            if (score >= 50) return "Pass (P)";
            return "Fail (F)";
        }
    }
}
