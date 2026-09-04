namespace MathLibrary
{
    public class MathEngine
    {
        public static double Calculate(double num1, double num2, string op)
        {
            switch (op)
            {
                case "+": return num1 + num2;
                case "-": return num1 - num2;
                case "*": return num1 * num2;
                case "/":
                    if (num2 == 0) throw new DivideByZeroException();
                    return num1 / num2;
                default: return 0;
            }
        }
    }
}
