using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Domain.Models
{
    public class Arena
    {
        private readonly int _maxXPos;
        private readonly int _maxYPos;

        private readonly List<IRobot> _robots = new();

        public Arena(int maxXPos, int maxYPos)
        {
            _maxXPos = maxXPos;
            _maxYPos = maxYPos;
        }

        public void AddRobotWithCommands(string positionCommand, string movementCommands)
        {
            try
            {
                var position = Position.Parse(positionCommand, _maxXPos, _maxYPos);
                var robot = new Robot(position);
                robot.PerformCommands(movementCommands, _maxXPos, _maxYPos);
                _robots.Add(robot);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var robot in _robots)
            {
                builder.AppendLine(robot.ToString());
            }

            return builder.ToString();
        }
    }
}
