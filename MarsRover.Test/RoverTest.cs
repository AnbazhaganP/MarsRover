using MarsRover.MarsRover_BLL;
using MarsRover.MarsRover_BLL.Command;
using MarsRover.MarsRover_BLL.Control;
using MarsRover.MarsRover_BLL.Models;
using MarsRover.MarsRover_BLL.Notification;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MarsRover.Test
{
    /// <summary>
    /// Test the Rover
    /// </summary>
    [TestClass]
    public class RoverTest
    {
        private static ServiceProvider serviceProvider;
        private RoverOperator roverOperator;
        private IRover rover;
        private List<ICommand> commandList;

        /// <summary>
        /// Initalise the Depedency Injection Fraework
        /// </summary>
        /// <param name="context"></param>
        [ClassInitialize]
        public static void TestClassInitialise(TestContext context)
        {
            serviceProvider = GetServiceProvider();
        }

        /// <summary>
        /// Initilise the Rover object before each testcase execution.
        /// </summary>
        [TestInitialize]
        public void TestCaseInitialise()
        {
            roverOperator = new RoverOperator();
            rover = serviceProvider.GetService<IRover>();
            commandList = new List<ICommand>();
        }

        /// <summary>
        /// Test the Rover Direction change scenarios
        /// </summary>
        /// <param name="commd"></param>
        /// <param name="expectedDirection"></param>
        [DataTestMethod]
        [DataRow(EnumCommand.Left, "Rover Current Position :- Direction: East, Position: 1")]
        [DataRow(EnumCommand.Right, "Rover Current Position :- Direction: West, Position: 1")]
        public void RoverMomentDirectionChangeTest(EnumCommand commd, String expectedDirection)
        {
            commandList.Add(RoverCommandsFactory.getCommand(rover, commd));
            IObserver observer = serviceProvider.GetService<IObserver>();
            rover.Attach(observer);

            roverOperator.SetCommand(commandList);
            roverOperator.Execute();

            var ActualDirection = ((RoverMonitor)observer).message;

            Assert.AreEqual(expectedDirection, ActualDirection);
        }

        /// <summary>
        /// Rover movement Test
        /// </summary>
        [TestMethod]
        public void RoverMomentDistanceTest()
        {
            var ExpectedValue = 4001;

            commandList.Add(RoverCommandsFactory.getCommand(rover, EnumCommand.Forward, 40));

            roverOperator.SetCommand(commandList);
            roverOperator.Execute();
            var ActualDirection = ((Rover)rover).GetCurrentPosition();

            Assert.AreEqual(ExpectedValue, ActualDirection);
        }

        /// <summary>
        /// Move the rover to outside of the exploration area test.
        /// </summary>
        [TestMethod]
        public void RoverMomentOutOfZExplorationAreaTest()
        {
            var ExpectedValue = "Rover halted and it can't venuture outside of exploration area";

            IObserver observer = serviceProvider.GetService<IObserver>();
            rover.Attach(observer);
            commandList.Add(RoverCommandsFactory.getCommand(rover, EnumCommand.Right));
            commandList.Add(RoverCommandsFactory.getCommand(rover, EnumCommand.Forward, 1));

            roverOperator.SetCommand(commandList);
            roverOperator.Execute();
            var ValidationMessage = ((RoverMonitor)observer).message;

            Assert.AreEqual(ExpectedValue, ValidationMessage);
        }

        /// <summary>
        /// Mutli command test of ROver
        /// </summary>
        [TestMethod]
        public void RoverMultiCommandTest()
        {
            var ExpectedValue = 4624;

            commandList.Add(RoverCommandsFactory.getCommand(rover, EnumCommand.Forward, 50));
            commandList.Add(RoverCommandsFactory.getCommand(rover, EnumCommand.Left));
            commandList.Add(RoverCommandsFactory.getCommand(rover, EnumCommand.Forward, 23));
            commandList.Add(RoverCommandsFactory.getCommand(rover, EnumCommand.Left));
            commandList.Add(RoverCommandsFactory.getCommand(rover, EnumCommand.Forward, 4));

            roverOperator.SetCommand(commandList);
            roverOperator.Execute();

            var ActualDirection = ((Rover)rover).GetCurrentPosition();

            Assert.AreEqual(ExpectedValue, ActualDirection);
        }

        /// <summary>
        /// Max Command Test
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception), "Can't Take more than 5 commands")]
        public void MoveRoverMaxCommandTest()
        {
            commandList.Add(RoverCommandsFactory.getCommand(rover, EnumCommand.Forward, 50));
            commandList.Add(RoverCommandsFactory.getCommand(rover, EnumCommand.Left));
            commandList.Add(RoverCommandsFactory.getCommand(rover, EnumCommand.Forward, 23));
            commandList.Add(RoverCommandsFactory.getCommand(rover, EnumCommand.Left));
            commandList.Add(RoverCommandsFactory.getCommand(rover, EnumCommand.Right, 4));
            commandList.Add(RoverCommandsFactory.getCommand(rover, EnumCommand.Right, 4));
            roverOperator.SetCommand(commandList);
        }

        /// <summary>
        /// No Command Test
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception), "No Command to execute")]
        public void MoveRoverNoCommandTest()
        {
            roverOperator.Execute();
        }

        /// <summary>
        /// Get the Dependecy Injector Framework
        /// </summary>
        /// <returns></returns>
        private static ServiceProvider GetServiceProvider()
        {
            return new ServiceCollection()
                            .AddScoped<IObserver, RoverMonitor>()
                            .AddTransient<IRover>(rover => new Rover(new Position { x = 100, y = 100 }, EnumDirection.South))
                            .BuildServiceProvider();
        }
    }
}