// See https://aka.ms/new-console-template for more information
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using RobotWars.Infrastructure;

var serviceCollection = new ServiceCollection();

serviceCollection.AddTransient<IArenaParser, ArenaParser>();

var serviceProvider = serviceCollection.BuildServiceProvider();

var arenaParser = serviceProvider.GetRequiredService<IArenaParser>();

try
{
    Console.WriteLine("Please enter details in the format:");
    Console.WriteLine("Arena size: eg. 5 5");
    Console.WriteLine("Followed by any number of robots in the format:");
    Console.WriteLine("Initial robot position: eg. 1 2 N");
    Console.WriteLine("Robot commands: eg. LMLMLMLMM");
    Console.WriteLine("Followed by 'f' to tell the sytem you have finished entering commands");
    StringBuilder builder = new();
    string line;
    while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()) && line.ToLower() != "f")
    {
        builder.AppendLine(line);
    }

    var arena = arenaParser.GenerateArena(builder.ToString());
    Console.WriteLine("*****RESULTS*****");
    Console.WriteLine(arena);
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}
finally
{
    Console.ReadLine();
}
