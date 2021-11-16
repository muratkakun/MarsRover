using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public abstract class Movement
    {
        public int NextX { get; set; }
        public int NextY { get; set; }
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public DirectionType Direction { get; set; }

        public Movement()
        {

        }

        public abstract Movement M();
        public abstract Movement L();
        public abstract Movement R();

        public abstract bool IsLValid();
        public abstract bool IsRValid();
        public abstract bool IsMValid();
    }
}
