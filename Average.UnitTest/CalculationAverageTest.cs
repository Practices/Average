using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Average.App;
using Xunit;

namespace Average.UnitTest
{
    public class CalculationAverageTest
    {
        private readonly Calculation calculation;

        public CalculationAverageTest()
        {
            calculation = new Calculation();
        }

        [Fact]
        public void ShouldBeReturnAverageArithmetric()
        {
            //arrange
            var numbers = new int[] {1, 2, 3, 4, 5};

            //act
            var result = calculation.GetAverageArithmetric(numbers);

            //assert
            Assert.Equal(result, 3);          
        }
    }
}
