using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Domain.Models
{
    public interface IRobot
    {
        public void PerformCommands(string commandString, int maxXPos, int maxYPos);
    }
}
