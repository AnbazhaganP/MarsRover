using System;

namespace MarsRover.MarsRover_BLL.Notification
{
    /// <summary>
    /// Observe the Rover Position
    /// </summary>
    public interface IObserver
    {
        void UpdateCurrentPosition(String message);
    }
}