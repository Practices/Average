using System;
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

        public double GetAverageGeometric(int[] numbers)
        {
            int mult = numbers.Aggregate(1, ((current, number) => current * number));

            //Степень 1/n
            double pow = 1d / numbers.Length;

            double result = Math.Pow(mult, pow);

            return result;
        }
    }
}