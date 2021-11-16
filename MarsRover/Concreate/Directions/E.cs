using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class E : Movement
    {
        public E(int x, int y, int maxX, int maxY)
        {
            NextX = x;
            NextY = y;
            Direction = DirectionType.E;
            MaxX = maxX;
            MaxY = maxY;
        }

        public override Movement L()
        {
            return new N(NextX, NextY, base.MaxX, base.MaxY); ;
        }

        public override Movement M()
        {
            NextX += 1;
            return this;
        }

        public override Movement R()
        {
            return new S(NextX, NextY, base.MaxX, base.MaxY); ;
        }

        public override bool IsLValid()
        {
            return NextY + 1 <= MaxY;
        }

        public override bool IsRValid()
        {
            return NextY - 1 >= 0;
        }

        public override bool IsMValid()
        {
            return NextX + 1 <= MaxX;
        }
    }
}
