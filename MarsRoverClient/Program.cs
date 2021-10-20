using MarsRover.MarsRover_BLL;
using MarsRover.MarsRover_BLL.Command;
using MarsRover.MarsRover_BLL.Control;
using MarsRover.MarsRover_BLL.Models;
using MarsRover.MarsRover_BLL.Notification;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace MarsRoverClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IObserver, RoverMonitor>()
                .AddScoped<IRover>(rover => new Rover(new Position { x = 100, y = 100 }, EnumDirection.South))
                .BuildServiceProvider();

            RoverOperator roverOperator = new RoverOperator();
            List<ICommand> command = new List<ICommand>();
            IObserver observer = serviceProvider.GetService<IObserver>();
            IRover rover = serviceProvider.GetService<IRover>();

            rover.Attach(observer);

            command.Add(RoverCommandsFactory.getCommand(rover, EnumCommand.Forward, 50));
            command.Add(RoverCommandsFactory.getCommand(rover, EnumCommand.Left));
            command.Add(RoverCommandsFactory.getCommand(rover, EnumCommand.Forward, 23));
            command.Add(RoverCommandsFactory.getCommand(rover, EnumCommand.Left));
            command.Add(RoverCommandsFactory.getCommand(rover, EnumCommand.Right));

            roverOperator.SetCommand(command);
            roverOperator.Execute();

            command.Add(RoverCommandsFactory.getCommand(rover, EnumCommand.Forward, 5));
            command.Add(RoverCommandsFactory.getCommand(rover, EnumCommand.Left));
            roverOperator.SetCommand(command);
            roverOperator.Execute();
        }
    }
}