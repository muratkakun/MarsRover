using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Abstract
{
    public abstract class Command
    {
        public string Name { get; set; }
        public abstract Movement Proccess(Movement move);
    }
}
