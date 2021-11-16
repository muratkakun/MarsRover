using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class N : Movement
    {    
        public N(int x, int y, int maxX, int maxY)
        {
            NextX = x;
            NextY = y;
            Direction = DirectionType.N;
            MaxX = maxX;
            MaxY = maxY;
        }

        public override Movement L()
        {
            return new W(NextX, NextY, MaxX, MaxY);
        }

        public override Movement M()
        {
            NextY += 1;
            return this;
        }

        public override Movement R()
        {
            return new E(NextX, NextY, MaxX, MaxY); ;
        }

        public override bool IsLValid()
        {
            return NextX >= 0;
        }

        public override bool IsRValid()
        {
            return NextX + 1 <= MaxX;
        }

        public override bool IsMValid()
        {
            return NextY + 1 <= MaxY;
        }
    }
}
