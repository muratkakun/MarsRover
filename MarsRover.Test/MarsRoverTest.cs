using Xunit;

namespace MarsRover.Test
{
    public class MarsRoverTest
    {
        IMarsRoverCalculation calculator;
        public MarsRoverTest()
        {
            calculator = new Calculation();
        }

        [Theory]
        [InlineData("5 5\r\n1 2 N\r\nLMLMLMLMM", "1 3 N")]
        public void SinglePosition_Test(string input, string output)
        {
            //string input = "5 5" + Environment.NewLine + "1 2 N" + Environment.NewLine + "LMLMLMLMM";
            //input += Environment.NewLine + "3 3 E" + Environment.NewLine + "MMRMMRMRRM";

            var result = calculator.GetFinalPosition(input);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            Assert.Equal(output, result[0]);
        }

        [Theory]
        [InlineData("5 5\r\n1 2 N\r\nLMLMLMLMM\r\n3 3 E\r\nMMRMMRMRRM", "1 3 N", "5 1 E")]
        public void TwoPosition_Test(string input, string output1, string output2)
        {
            var result = calculator.GetFinalPosition(input);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count);
            Assert.Equal(output1, result[0]);
            Assert.Equal(output2, result[1]);
        }
    }
}
