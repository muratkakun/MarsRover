using System.Collections.Generic;

namespace MarsRover
{
    public interface IMarsRoverCalculation
    {
        List<string> GetFinalPosition(string input);
    }
}