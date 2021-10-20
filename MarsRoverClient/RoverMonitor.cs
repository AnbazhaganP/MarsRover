using MarsRover.MarsRover_BLL.Notification;
using System;

namespace MarsRoverClient
{
    internal class RoverMonitor : IObserver
    {
        public void UpdateCurrentPosition(string message)
        {
            Console.WriteLine(message);
        }
    }
}