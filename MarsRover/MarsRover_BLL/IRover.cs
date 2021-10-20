using MarsRover.MarsRover_BLL.Models;
using MarsRover.MarsRover_BLL.Notification;

namespace MarsRover.MarsRover_BLL
{
    /// <summary>
    /// Rover Interface
    /// </summary>
    public interface IRover
    {
        /// <summary>
        /// Trun the Rover to the Right direction
        /// </summary>
        void TurnRight();

        /// <summary>
        /// Trun the rover to Left direction
        /// </summary>
        void TurnLeft();

        /// <summary>
        /// Move the Rover to given meters
        /// </summary>
        /// <param name="meter"></param>
        void MoveForward(int meter);

        /// <summary>
        /// Get the Rover Current position
        /// </summary>
        /// <returns></returns>
        Position GetPosition();

        /// <summary>
        /// Attach Observer
        /// </summary>
        /// <param name="observer"></param>
        void Attach(IObserver observer);

        /// <summary>
        /// Deatch Observer
        /// </summary>
        /// <param name="observer"></param>
        void Deatach(IObserver observer);

        /// <summary>
        /// Nofify Current Postion to Observers
        /// </summary>
        void NotifyCurrentPosition();

        /// <summary>
        /// Check whether the Rove can move forward
        /// </summary>
        /// <param name="meter"></param>
        /// <returns></returns>
        bool CanForward(int meter);
    }
}