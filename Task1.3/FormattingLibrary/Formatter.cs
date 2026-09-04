using System;

namespace FormattingLibrary
{
    public class Formatter
    {
        public static string LogCalculation(double num1, double num2, string op, double result)
        {
            string currentTime = DateTime.Now.ToString("HH:mm:ss");
            return $"Last calculation: {num1} {op} {num2} = {result} (Logged at {currentTime})";
        }
    }
}
