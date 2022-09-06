using RobotWars.Domain.Enums;
using RobotWars.Domain.Exceptions;
using RobotWars.Domain.Models;

namespace RobotWars.Tests
{
    [TestClass]
    public class PositionTests
    {
        [TestMethod]
        public void Parse()
        {
            var position = Position.Parse("1 2 N", 5, 5);

            Assert.IsTrue(position.XPos == 1);
            Assert.IsTrue(position.YPos == 2);
            Assert.IsTrue(position.Direction is CardinalDirectionEnum.North);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPositionException))]
        public void Parse_FailArenaTooSmall()
        {
            var position = Position.Parse("6 4 N", 5, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPositionException))]
        public void Parse_FailNotEnoughArgs()
        {
            var position = Position.Parse("2 4", 5, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPositionException))]
        public void Parse_FailInvalidDirection()
        {
            var position = Position.Parse("2 4 K", 5, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPositionException))]
        public void Parse_FailInvalidX()
        {
            var position = Position.Parse("H 4 N", 5, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPositionException))]
        public void Parse_FailInvalidY()
        {
            var position = Position.Parse("2 L N", 5, 5);
        }

        [TestMethod]
        public void MoveCommand()
        {
            var position = new Position(1, 2, CardinalDirectionEnum.North);

            position.MoveCommand(5, 5);

            Assert.IsTrue(position.XPos == 1);
            Assert.IsTrue(position.YPos == 3);
            Assert.IsTrue(position.Direction is CardinalDirectionEnum.North);
        }

        [TestMethod]
        public void ChangeDirection()
        {
            var position = new Position(1, 2, CardinalDirectionEnum.North);

            position.ChangeDirection(CardinalDirectionEnum.East);

            Assert.IsTrue(position.XPos == 1);
            Assert.IsTrue(position.YPos == 2);
            Assert.IsTrue(position.Direction is CardinalDirectionEnum.East);
        }

        [TestMethod]
        public void PosToString()
        {
            var position = new Position(1, 2, CardinalDirectionEnum.North);

            var stringValue = position.ToString();

            Assert.IsTrue(stringValue == "1 2 N");
        }
    }
}