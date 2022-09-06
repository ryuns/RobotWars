using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotWars.Domain.Enums;

namespace RobotWars.Domain.Models
{
    public class Robot : IRobot
    {
        private Position position;
        public Position Position
        {
            get
            {
                return position;
            }
            private set
            {
                position = value;
            }
        }

        public Robot(Position position)
        {
            this.position = position;
        }

        public void PerformCommands(string commandString, int maxXPos, int maxYPos)
        {
            try
            {
                var commands = commandString.ToCommandArray();
                foreach (var command in commands)
                {
                    CommandActioner.PerformCommand(command, maxXPos, maxYPos, ref position);
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        public override string ToString() => Position.ToString();
    }
}
