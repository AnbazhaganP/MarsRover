using MarsRover.MarsRover_BLL.Models;

namespace MarsRover.MarsRover_BLL.Control
{
    /// <summary>
    /// West Direction
    /// </summary>
    internal class WestDirection : RoverControl
    {
        /// <summary>
        /// Contractor to initalise the dependency and vlaue.
        /// </summary>
        /// <param name="vehicle"></param>
        public WestDirection(IRover vehicle) : base(vehicle)
        {
            this.moventIncrementValue = -1;
            this.direction = EnumDirection.West;
        }

        /// <summary>
        /// Move the Rover to given meter based on the West Direction
        /// </summary>
        /// <param name="meters">Given meters</param>
        /// <returns>New postion of the rover</returns>
        public override Position MoveForward(int meters)
        {
            var newpos = this.rover.GetPosition().Clone();
            newpos.y = this.rover.GetPosition().y + (meters * this.moventIncrementValue);
            return newpos;
        }
    }
}