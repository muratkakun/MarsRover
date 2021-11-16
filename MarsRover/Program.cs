using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IMarsRoverCalculation, Calculation>()
                .BuildServiceProvider();

            string input = "5 5" + Environment.NewLine + "1 2 N" + Environment.NewLine + "LMLMLMLMM";
            input += Environment.NewLine + "3 3 E" + Environment.NewLine + "MMRMMRMRRM";

            var calculator = serviceProvider.GetService<IMarsRoverCalculation>();

            var result = calculator.GetFinalPosition(input);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();

        }

    }
}
