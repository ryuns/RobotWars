using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotWars.Domain.Enums;
using RobotWars.Domain.Models;

namespace RobotWars.Domain
{
    public static class CommandActioner
    {
        public static void PerformCommand(Command command, int maxXPos, int maxYPos, ref Position position)
        {
            if(command is Command.Left or Command.Right)
            {
                var direction = position.Direction.ActionCommand(command);
                position.ChangeDirection(direction);
                return;
            }

            position.MoveCommand(maxXPos, maxYPos);
        }
    }
}
