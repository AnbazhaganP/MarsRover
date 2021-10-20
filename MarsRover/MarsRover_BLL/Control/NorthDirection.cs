using MarsRover.MarsRover_BLL.Models;

namespace MarsRover.MarsRover_BLL.Control
{
    /// <summary>
    /// North Direction
    /// </summary>
    internal class NorthDirection : RoverControl
    {
        /// <summary>
        /// Initalise the Direction
        /// </summary>
        /// <param name="vehicle">Rover</param>
        public NorthDirection(IRover vehicle) : base(vehicle)
        {
            this.moventIncrementValue = -1;
            this.direction = EnumDirection.North;
        }

        /// <summary>
        /// Move the Rover to given meter based on the North direction
        /// </summary>
        /// <param name="meters">Move the rover to given meters</param>
        /// <returns>Return the new positon</returns>
        public override Position MoveForward(int meters)
        {
            var newpos = this.rover.GetPosition().Clone();
            newpos.x = this.rover.GetPosition().x + (meters * this.moventIncrementValue);
            return newpos;
        }
    }
}