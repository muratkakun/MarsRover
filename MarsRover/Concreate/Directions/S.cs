using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class S : Movement
    {
        public S(int x, int y, int maxX, int maxY)
        {
            NextX = x;
            NextY = y;
            Direction = DirectionType.S;
            MaxX = maxX;
            MaxY = maxY;
        }

        public override Movement L()
        {
            return new E(NextX, NextY, base.MaxX, base.MaxY);
        }

        public override Movement M()
        {
            NextY -= 1;
            return this;
        }

        public override Movement R()
        {
            return new W(NextX, NextY, base.MaxX, base.MaxY);
        }

        public override bool IsLValid()
        {
            return NextX + 1 <= MaxX;
        }

        public override bool IsRValid()
        {
            return NextX - 1 >= 0; 
        }

        public override bool IsMValid()
        {
            return NextY - 1 >= 0;
        }
    }
}
