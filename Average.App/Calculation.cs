using System.Linq;

namespace Average.App
{
    public class Calculation
    {
        public double GetAverageArithmetric(int[] numbers)
        {
            int sum = numbers.Sum();

            int count = numbers.Length;

            double result = sum / count;

            return result;
        }
    }
}