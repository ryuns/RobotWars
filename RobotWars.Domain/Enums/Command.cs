using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotWars.Domain.Exceptions;

namespace RobotWars.Domain.Enums
{
    public enum Command
    {
        Left,
        Right,
        Move
    }

    public static class CommandExtensions
    {
        public static Command[] ToCommandArray(this string commandString)
        {
            return commandString.Select(x => x.ToCommand()).ToArray();
        }

        public static Command ToCommand(this char command)
        {
            return command switch
            {
                'L' or 'l' => Command.Left,
                'R' or 'r' => Command.Right,
                'M' or 'm' => Command.Move,
                _ => throw new InvalidCommandException(),
            };
        }
    }
}
