using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RobotWars.Domain.Exceptions;

namespace RobotWars.Domain.Enums
{
    public enum CardinalDirectionEnum
    {
        North,
        East,
        South,
        West
    }

    public static class CardinalDirection
    {
        public static bool TryParse(string input, out CardinalDirectionEnum direction)
        {
            if (!char.TryParse(input, out char directionChar))
            {
                direction = CardinalDirectionEnum.North;
                return false;
            }

            try
            {
                direction = directionChar.ToDirection();
                return true;
            }
            catch (InvalidDirectionException)
            {
                direction = CardinalDirectionEnum.North;
                return false;
            }
        }
    }

    public static class CardinalDirectionExtensions
    {
        public static CardinalDirectionEnum ToDirection(this char charValue)
        {
            return charValue switch
            {
                'N' or 'n' => CardinalDirectionEnum.North,
                'E' or 'e' => CardinalDirectionEnum.East,
                'S' or 's' => CardinalDirectionEnum.South,
                'W' or 'w' => CardinalDirectionEnum.West,
                _ => throw new InvalidDirectionException(),
            };
        }

        public static string ToShortDirection(this CardinalDirectionEnum direction)
        {
            return direction switch
            {
                CardinalDirectionEnum.North => "N",
                CardinalDirectionEnum.East => "E",
                CardinalDirectionEnum.South => "S",
                CardinalDirectionEnum.West => "W",
                _ => throw new InvalidDirectionException()
            };
        }

        public static CardinalDirectionEnum ActionCommand(this CardinalDirectionEnum direction, Command command)
        {
            return direction switch
            {
                CardinalDirectionEnum.North => command is Command.Left ? CardinalDirectionEnum.West : command is Command.Right ? CardinalDirectionEnum.East : throw new InvalidCommandException(),
                CardinalDirectionEnum.East => command is Command.Left ? CardinalDirectionEnum.North : command is Command.Right ? CardinalDirectionEnum.South : throw new InvalidCommandException(),
                CardinalDirectionEnum.South => command is Command.Left ? CardinalDirectionEnum.East : command is Command.Right ? CardinalDirectionEnum.West : throw new InvalidCommandException(),
                CardinalDirectionEnum.West => command is Command.Left ? CardinalDirectionEnum.South : command is Command.Right ? CardinalDirectionEnum.North : throw new InvalidCommandException(),
                _ => throw new InvalidDirectionException(),
            };
        }

        public static (int newXPos, int newYPos) GetNewPosition(this CardinalDirectionEnum direction, int xPos, int yPos)
        {
            return direction switch
            {
                CardinalDirectionEnum.North => (xPos, yPos + 1),
                CardinalDirectionEnum.East => (xPos + 1, yPos),
                CardinalDirectionEnum.South => (xPos, yPos - 1),
                CardinalDirectionEnum.West => (xPos - 1, yPos),
                _ => throw new InvalidDirectionException(),
            };
        }
    }
}
