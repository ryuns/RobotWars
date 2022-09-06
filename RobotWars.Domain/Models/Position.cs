using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotWars.Domain.Enums;
using RobotWars.Domain.Exceptions;

namespace RobotWars.Domain.Models
{
    public class Position
    {
        public int XPos { get; private set; }
        public int YPos { get; private set; }
        public CardinalDirectionEnum Direction { get; private set; }

        public Position(int xPos, int yPos, CardinalDirectionEnum direction)
        {
            XPos = xPos;
            YPos = yPos;
            Direction = direction;
        }

        public void ChangeDirection(CardinalDirectionEnum direction)
        {
            Direction = direction;
        }

        public void MoveCommand(int maxXPos, int maxYPos)
        {
            var (newXPos, newYPos) = Direction.GetNewPosition(XPos, YPos);

            if(newXPos < 0 || newYPos < 0 || newXPos > maxXPos || newYPos > maxYPos)
            {
                throw new InvalidPositionException();
            }

            XPos = newXPos;
            YPos = newYPos;
        }

        public static Position Parse(string input, int maxXPos, int maxYPos)
        {
            var splitInput = input.Split(' ');

            if (splitInput.Length != 3)
            {
                throw new InvalidPositionException();
            }

            if (!int.TryParse(splitInput[0], out var xPos) || !int.TryParse(splitInput[1], out var yPos) || !CardinalDirection.TryParse(splitInput[2], out var direction))
            {
                throw new InvalidPositionException();
            }

            if (xPos > maxXPos || yPos > maxYPos)
            {
                throw new InvalidPositionException();
            }

            return new(xPos, yPos, direction);
        }

        public override string ToString() => $"{XPos} {YPos} {Direction.ToShortDirection()}";
    }
}
