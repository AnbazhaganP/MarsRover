using MarsRover.MarsRover_BLL.Notification;
using System;

namespace MarsRover.Test
{
    internal class RoverMonitor : IObserver
    {
        public String message = "";

        public void UpdateCurrentPosition(string message)
        {
            this.message = message;
            Console.WriteLine(message);
        }
    }
}