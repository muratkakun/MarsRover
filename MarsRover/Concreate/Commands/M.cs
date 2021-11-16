using MarsRover.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Concreate.Commands
{
    public class M : Command
    {
        public M()
        {
            Name = this.GetType().Name;
        }
        public override Movement Proccess(Movement move)
        {
            return move.M();
        }
    }
}
