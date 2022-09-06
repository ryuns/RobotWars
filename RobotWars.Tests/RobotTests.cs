using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using RobotWars.Domain.Enums;
using RobotWars.Domain.Models;

namespace RobotWars.Tests
{
    [TestClass]
    public class RobotTests
    {
        [TestMethod]
        public void TestMovingPosition()
        {
            var robot = new Robot(new(1, 2, CardinalDirectionEnum.North));
            robot.PerformCommands("LMLMLMLMM", 5, 5);

            Assert.IsTrue(robot.Position.XPos == 1);
            Assert.IsTrue(robot.Position.YPos == 3);
            Assert.IsTrue(robot.Position.Direction is CardinalDirectionEnum.North);
        }

        [TestMethod]
        public void RobToString()
        {
            var robot = new Robot(new(1, 2, CardinalDirectionEnum.North));

            var stringValue = robot.ToString();

            Assert.IsTrue(stringValue == "1 2 N");
        }
    }
}
