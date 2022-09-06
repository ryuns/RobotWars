using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotWars.Domain.Enums;
using RobotWars.Domain.Exceptions;
using RobotWars.Domain.Models;

namespace RobotWars.Infrastructure
{
    public class ArenaParser : IArenaParser
    {
        public Arena GenerateArena(string input)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    throw new InvalidInputException();
                }

                var lines = input.Split("\r\n").Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

                if (lines.Length < 1)
                {
                    throw new InvalidInputException();
                }

                var maxPos = lines[0].Split(' ');

                if (maxPos.Length != 2)
                {
                    throw new InvalidInputException();
                }

                Arena arena = int.TryParse(maxPos[0], out var maxXPos) && int.TryParse(maxPos[1], out var maxYPos)
                    ? (new(maxXPos, maxYPos))
                    : throw new InvalidInputException();

                for (int i = 1; i < lines.Length; i += 2)
                {
                    var initialPosition = lines[i];
                    var commands = lines[i + 1];

                    arena.AddRobotWithCommands(initialPosition, commands);
                }

                return arena;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
