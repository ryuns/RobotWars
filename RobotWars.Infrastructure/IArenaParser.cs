using RobotWars.Domain.Models;

namespace RobotWars.Infrastructure
{
    public interface IArenaParser
    {
        public Arena GenerateArena(string input);
    }
}