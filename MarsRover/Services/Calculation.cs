using MarsRover.Abstract;
using MarsRover.Concreate.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover
{
    public class Calculation: IMarsRoverCalculation
    {
        public List<string> GetFinalPosition(string input)
        {

            int x = 0, y = 0, maxX = 0, maxY = 0;
            DirectionType directionType;

            string[] inputsArr = input.Split(Environment.NewLine);

            string[] max = inputsArr[0].Split(' ');
            if (!int.TryParse(max[0], out maxX))
            {
                return null;
            }

            if (!int.TryParse(max[1], out maxY))
            {
                return null;
            }

            List<string> results = new List<string>();
            var cmdList = GetCommandList();
            for (int i = 1; i < inputsArr.Length; i += 2)
            {
                StringBuilder finalPosition = new StringBuilder();
                string[] pos = inputsArr[i].Split(' ');

                if (pos.Length != 3)
                    continue;

                if (!int.TryParse(pos[0], out x))
                {
                    continue;
                }

                if (!int.TryParse(pos[1], out y))
                {
                    continue;
                }

                if(!Enum.TryParse(pos[2], false, out directionType))
                {
                    continue;
                }

                Movement move = GetFirstMoveState(x, y, directionType, maxX, maxY);
                if (move == null)
                    continue;

                Command cmd;

                foreach (var item in inputsArr[i + 1])
                {
                    cmd = cmdList.First(x => x.Name == item.ToString());
                    move = cmd.Proccess(move);
                }

                finalPosition.Append(move.NextX);
                finalPosition.Append(" ");
                finalPosition.Append(move.NextY);
                finalPosition.Append(" ");
                finalPosition.Append(move.Direction.ToString());

                results.Add(finalPosition.ToString());
            }

            return results;
        }

        private List<Command> GetCommandList()
        {
            List<Command> cmdList = new List<Command>(3);
            cmdList.Add(new L());
            cmdList.Add(new R());
            cmdList.Add(new M());

            return cmdList;
        }

        private Movement GetFirstMoveState(int x, int y, DirectionType direcionType, int maxX, int maxY)
        {
            List<Movement> moveList = new List<Movement>(4);
            moveList.Add(new E(x, y, maxX, maxY));
            moveList.Add(new N(x, y, maxX, maxY));
            moveList.Add(new W(x, y, maxX, maxY));
            moveList.Add(new S(x, y, maxX, maxY));

            return moveList.FirstOrDefault(x => x.Direction == direcionType);
        }
    }
}
