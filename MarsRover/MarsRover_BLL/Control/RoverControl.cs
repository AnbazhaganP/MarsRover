using MarsRover.MarsRover_BLL.Helper;
using MarsRover.MarsRover_BLL.Models;

namespace MarsRover.MarsRover_BLL.Control
{
    /// <summary>
    /// Rover Control
    /// </summary>
    public abstract class RoverControl
    {
        protected int moventIncrementValue;
        public EnumDirection direction;
        protected IRover rover;

        /// <summary>
        /// Rover
        /// </summary>
        /// <param name="rover"></param>
        public RoverControl(IRover rover)
        {
            this.rover = rover;
        }

        /// <summary>
        /// Move the Rover to given meter bsaed on the Rover Direction
        /// </summary>
        /// <param name="meters">Meter to move</param>
        /// <returns>New positon of the Rover</returns>
        public abstract Position MoveForward(int meters);

        /// <summary>
        /// Trun the Rover to Right
        /// </summary>
        /// <returns>Return the Rover</returns>
        public RoverControl TrunRight()
        {
            return DirectionFactory.getRoverDirection(this.rover, Utility.TurnRight(this.direction));
        }

        /// <summary>
        /// Trun the Rover to Left
        /// </summary>
        /// <returns>Retrun the Direction</returns>
        public RoverControl TurnLeft()
        {
            return DirectionFactory.getRoverDirection(this.rover, Utility.TurnLeft(this.direction));
        }
    }
}