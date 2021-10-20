using MarsRover.MarsRover_BLL;
using MarsRover.MarsRover_BLL.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Client
    {
        private RoverOperator RoverOperator;
        private Rover Rover;
        private LeftCommand leftCommand;
        private RightCommand rightCommand;
        private MoveForwardCommand forwardCommand;
    }
}